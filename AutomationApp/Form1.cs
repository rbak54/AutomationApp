using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Drawing;
using System.IO;

namespace AutomationApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            //SELECT FILE AND STORE
            var fileContent = string.Empty;
            string[] filePath;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "excel|*.xls";
                openFileDialog.Multiselect = true;
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file, View it
                    filePath = openFileDialog.FileNames;
                    string filePathString = string.Join("\n", filePath);
                    lbl_1.Text = filePathString;
                    //LOOP THROUGH FILES- if we choose to do this we'll probably want to use a separate output file for each file
                    
                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /// check if user has selected a file - if not then warn the user and return 
            /// verify a file has been selected by observing the label lbl_1.
            if (lbl_1.Text == "Please Select a File")
            {
                warningLabel.ForeColor = Color.Red;
                warningLabel.Text = "Please select a file before continuing";
                return;
            }

            warningLabel.Text = "";

            string[] filePath = lbl_1.Text.Split('\n');
            foreach (string sFileName in filePath)
            {
                //https://coderwall.com/p/app3ya/read-excel-file-in-c
                //Create COM Objects. Create a COM object for everything that is referenced
                Excel.Application xlApp = new Excel.Application();
                xlApp.Visible = true;
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(sFileName);
                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;
                //int rowCount = xlRange.Rows.Count;
                //int colCount = xlRange.Columns.Count;

                //create COM objects for copy of original document
                Excel.Application xlAppCopy = new Excel.Application();
                xlAppCopy.Visible = true;
                Excel.Workbook xlWorkbookCopy = xlAppCopy.Workbooks.Add();
                Excel._Worksheet xlWorksheetCopy = xlWorkbookCopy.Sheets[1];

                //Copy all contents from selected file to the new excel doc
                int nRows = xlRange.Rows.Count;
                int nEndDestinationCopy = nRows;
                string endDestinationCopy = "P" + nEndDestinationCopy.ToString(); // This will only work if all the docs are P columns wide!
                Excel.Range xlRangeCopy = xlWorksheetCopy.get_Range("A1", endDestinationCopy);
                xlRange.Copy(Type.Missing);
                xlRangeCopy.PasteSpecial(Excel.XlPasteType.xlPasteValues);

                //create COM objects for output file
                Excel.Application xlApp2 = new Excel.Application();
                xlApp2.Visible = true;
                Excel.Workbook xlWorkbook2 = xlApp2.Workbooks.Add();
                Excel._Worksheet xlWorksheet2 = xlWorkbook2.Sheets[1];

                //insert HODS codes
                //xlWorksheet2.Cells[1, 1] = box_0101.Text;
                xlWorksheet2.Cells[1, 2] = box_0102.Text;
                xlWorksheet2.Cells[1, 3] = box_0103.Text;
                xlWorksheet2.Cells[1, 4] = box_0104.Text;
                xlWorksheet2.Cells[1, 5] = box_0105.Text;
                xlWorksheet2.Cells[1, 6] = box_0106.Text;
                xlWorksheet2.Cells[1, 7] = box_0107.Text;
                xlWorksheet2.Cells[1, 8] = box_0108.Text;

                box_0101.Hide();
                //LOOP THROUGH SAMPLES 
                //for loop to repeat for each sample. Can reinstate this later.
                for (int sample=1; sample<9; sample++) 
                {
                    //i is the row we're interested in
                    int i = sample + 2;
                    //https://docs.microsoft.com/en-us/dotnet/api/microsoft.office.interop.excel.range.autofilter?view=excel-pia

                    //PUT SAMPLE NAME IN EXCEL
                
                
                    ///SORT AND FILTER- i is column number 
                    xlRangeCopy.Sort(xlRangeCopy.Columns[i], Excel.XlSortOrder.xlAscending, Type.Missing, Type.Missing, Excel.XlSortOrder.xlAscending, Type.Missing, Excel.XlSortOrder.xlAscending, Excel.XlYesNoGuess.xlYes);
                    xlRangeCopy.AutoFilter(i, "<100");
                                        
                    //COUNT FILTERED ROWS
                    //https://stackoverflow.com/questions/41731714/counting-rows-of-filtered-excel-range-in-c-sharp
                    //NOTE, this includes the first row in the count, so -1
                    //this counts visible cells
                    Excel.Range xlRange3 = xlRangeCopy.SpecialCells(Excel.XlCellType.xlCellTypeVisible);
                    // -1 because of headers  
                    int nFilteredRows = xlRange3.Rows.Count - 1;
                    string sampleLetter = ((char)(sample + 64)).ToString();
                    //COPY FILTERED ROWS- will need to change the values in get range to fit the sample and number of filtered genes
                    //-1 becaause to get 4 rows we need A2:A5 and  5-2 is 4-1

                    int nStartSource = 2;
                    int nEndSource = nStartSource + nFilteredRows - 1;
                    int nStartDestination = 2;
                    int nEndDestination = nStartDestination + nFilteredRows - 1;
                    string startSource = "A" + nStartSource.ToString();
                    string startDestination = sampleLetter + nStartDestination.ToString();
                    string endSource = "A" + nEndSource.ToString();
                    string endDestination = sampleLetter + nEndDestination.ToString();
                    Excel.Range xlRange2 = xlWorksheet2.get_Range(startDestination,endDestination);
                    Excel.Range sourceRng = xlWorksheetCopy.get_Range(startSource,endSource);
                    sourceRng.Copy(Type.Missing);
                    xlRange2.PasteSpecial(Excel.XlPasteType.xlPasteValues);
                    xlRange2.RemoveDuplicates(1, Excel.XlYesNoGuess.xlNo);

                    //REMOVE FILTER
                    xlRangeCopy.AutoFilter(i);

                }
                //SAVE OUTPUT DOCUMENT
                string fileName = Path.GetFileName(sFileName); //retreives the filename from the path
                string directoryName = Path.GetDirectoryName(sFileName); //retreives path of the directory of selected file
                xlWorkbook2.SaveAs(directoryName + "/" + "output_" + fileName);

                //Close documents without displaying any prompt boxes
                xlApp2.DisplayAlerts = false;
                xlApp2.Quit();
                xlAppCopy.DisplayAlerts = false;
                xlAppCopy.Quit();
                xlApp.DisplayAlerts = false;
                xlApp.Quit();

                //cleanup
                GC.Collect();
                GC.WaitForPendingFinalizers();
                //rule of thumb for releasing com objects:
                //  never use two dots, all COM objects must be referenced and released individually
                //  ex: [somthing].[something].[something] is bad

                //release com objects to fully kill excel process from running in the background
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);
                //Marshal.ReleaseComObject(xlRange2);
                Marshal.ReleaseComObject(xlWorksheet2);
                //Marshal.ReleaseComObject(sourceRng);
                //close and release
                //xlWorkbook.Close(false, Type.Missing, Type.Missing);
                //xlWorkbook2.Close();
                //Marshal.ReleaseComObject(xlWorkbook);
                //Marshal.ReleaseComObject(xlWorkbook2);


                //quit and release
                //xlApp.Quit();
               //xlApp2.Quit();

                Marshal.ReleaseComObject(xlApp);
                Marshal.ReleaseComObject(xlApp2);


                // TRANSPOSE RESULTS
                // MAKE WORD FILE?
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Validating the input for box_0101 - notifying the user if their input is valid
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void box_0101_TextChanged(object sender, EventArgs e)
        {
            if (box_0101.Text == "")
            {
                return;
            }
            /// if text is numerical and length = 5 then the input is valid
            if (int.TryParse(box_0101.Text, out _) && box_0101.Text.Length == 5){
                textWarning1.ForeColor = Color.Green;
                textWarning1.Text = "Valid Input";
            }
            else
            {
                textWarning1.ForeColor = Color.Red;
                textWarning1.Text = "Invalid Input";
            }
        }

        private void box_0102_TextChanged(object sender, EventArgs e)
        {
            if (box_0102.Text == "")
            {
                return;
            }
            if (int.TryParse(box_0102.Text, out _) && box_0102.Text.Length == 5)
            {
                textWarning2.ForeColor = Color.Green;
                textWarning2.Text = "Valid Input";
            }
            else
            {
                textWarning2.ForeColor = Color.Red;
                textWarning2.Text = "Invalid Input";
            }
        }

        private void box_0103_TextChanged(object sender, EventArgs e)
        {
            if (box_0103.Text == "")
            {
                return;
            }
            if (int.TryParse(box_0103.Text, out _) && box_0103.Text.Length == 5)
            {
                textWarning3.ForeColor = Color.Green;
                textWarning3.Text = "Valid Input";
            }
            else
            {
                textWarning3.ForeColor = Color.Red;
                textWarning3.Text = "Invalid Input";
            }
        }

        private void box_0104_TextChanged(object sender, EventArgs e)
        {
            if (box_0104.Text == "")
            {
                return;
            }
            if (int.TryParse(box_0104.Text, out _) && box_0104.Text.Length == 5)
            {
                textWarning4.ForeColor = Color.Green;
                textWarning4.Text = "Valid Input";
            }
            else
            {
                textWarning4.ForeColor = Color.Red;
                textWarning4.Text = "Invalid Input";
            }
        }

        private void box_0105_TextChanged(object sender, EventArgs e)
        {
            if (box_0105.Text == "")
            {
                return;
            }
            if (int.TryParse(box_0105.Text, out _) && box_0105.Text.Length == 5)
            {
                textWarning5.ForeColor = Color.Green;
                textWarning5.Text = "Valid Input";
            }
            else
            {
                textWarning5.ForeColor = Color.Red;
                textWarning5.Text = "Invalid Input";
            }
        }

        private void box_0106_TextChanged(object sender, EventArgs e)
        {
            if (box_0106.Text == "")
            {
                return;
            }
            if (int.TryParse(box_0106.Text, out _) && box_0106.Text.Length == 5)
            {
                textWarning6.ForeColor = Color.Green;
                textWarning6.Text = "Valid Input";
            }
            else
            {
                textWarning6.ForeColor = Color.Red;
                textWarning6.Text = "Invalid Input";
            }
        }

        private void box_0107_TextChanged(object sender, EventArgs e)
        {
            if (box_0107.Text == "")
            {
                return;
            }
            if (int.TryParse(box_0107.Text, out _) && box_0107.Text.Length == 5)
            {
                textWarning7.ForeColor = Color.Green;
                textWarning7.Text = "Valid Input";
            }
            else
            {
                textWarning7.ForeColor = Color.Red;
                textWarning7.Text = "Invalid Input";
            }
        }

        private void box_0108_TextChanged(object sender, EventArgs e)
        {
            if (box_0108.Text == "")
            {
                return;
            }
            if (int.TryParse(box_0108.Text, out _) && box_0108.Text.Length == 5)
            {
                textWarning8.ForeColor = Color.Green;
                textWarning8.Text = "Valid Input";
            }
            else
            {
                textWarning8.ForeColor = Color.Red;
                textWarning8.Text = "Invalid Input";
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
