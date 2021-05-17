using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Drawing;
using System.IO;
using System.Collections.Generic;

namespace AutomationApp
{
    public partial class Form1 : Form
    {

        List<System.Windows.Forms.TextBox> textBoxes = new List<System.Windows.Forms.TextBox>();
        List<System.Windows.Forms.Label> labels = new List<System.Windows.Forms.Label>();


        public Form1()
        {
            InitializeComponent();

            /// Initialise lists of all text boxes and respective labels

            List<System.Windows.Forms.TextBox> textBoxes = new List<System.Windows.Forms.TextBox>
            {
                box_0101, box_0102, box_0103, box_0104, box_0105, box_0106, box_0107, box_0108
            };
            List<System.Windows.Forms.Label> labels = new List<System.Windows.Forms.Label>
            {
                label_1, label_2, label_3, label_4, label_5, label_6, label_7, label_8
            };

            /// hide the boxes and labels before the user selected number of samples
            for (int i = 0; i < 8; i++)
            {
                textBoxes[i].Hide();
                labels[i].Hide();
            }
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
                openFileDialog.Multiselect = false;
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

            /// check if user has selected a number of files
            if (comboBox1.SelectedIndex == -1)
            {
                warningLabel.ForeColor = Color.Red;
                warningLabel.Text = "Please select the number of samples in the file";
                return;
            }

            warningLabel.Text = "";

            string[] filePath = lbl_1.Text.Split('\n');
            foreach (string sFileName in filePath)
            {
                //https://coderwall.com/p/app3ya/read-excel-file-in-c
                //Create COM Objects. Create a COM object for everything that is referenced
                Excel.Application xlApp = new Excel.Application();
                xlApp.Visible = false;
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(sFileName);
                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;
                //Clipboard.Clear();
                //int rowCount = xlRange.Rows.Count;
                //int colCount = xlRange.Columns.Count;

                //create COM objects for copy of original document
                Excel.Application xlAppCopy = new Excel.Application();
                xlAppCopy.Visible = false;
                Excel.Workbook xlWorkbookCopy = xlAppCopy.Workbooks.Add();
                Excel._Worksheet xlWorksheetCopy = xlWorkbookCopy.Sheets[1];

                //Copy all contents from selected file to the new excel doc
                int nRows = xlRange.Rows.Count;
                int nEndDestinationCopy = nRows;
                string endDestinationCopy = "P" + nEndDestinationCopy.ToString(); // This will only work if all the docs are P columns wide!
                Excel.Range xlRangeCopy = xlWorksheetCopy.get_Range("A1", endDestinationCopy);
                //xlRange.Copy(Type.Missing);
                //xlRangeCopy.PasteSpecial(Excel.XlPasteType.xlPasteValues);
                //Clipboard.Clear();
                xlRangeCopy.Value2 = xlRange.Value2;
                //create COM objects for output file
                Excel.Application xlApp2 = new Excel.Application();
                xlApp2.Visible = false;
                Excel.Workbook xlWorkbook2 = xlApp2.Workbooks.Add();
                Excel._Worksheet xlWorksheet2 = xlWorkbook2.Sheets[1];

                //insert HODS codes
                xlWorksheet2.Cells[1, 1] = box_0101.Text;
                xlWorksheet2.Cells[1, 2] = box_0102.Text;
                xlWorksheet2.Cells[1, 3] = box_0103.Text;
                xlWorksheet2.Cells[1, 4] = box_0104.Text;
                xlWorksheet2.Cells[1, 5] = box_0105.Text;
                xlWorksheet2.Cells[1, 6] = box_0106.Text;
                xlWorksheet2.Cells[1, 7] = box_0107.Text;
                xlWorksheet2.Cells[1, 8] = box_0108.Text;

                //LOOP THROUGH SAMPLES 
                //for loop to repeat for each sample. Can reinstate this later.
                for (int sample=1; sample<comboBox1.SelectedIndex +2; sample++) 
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
                    //sourceRng.Copy(Type.Missing) ;
                    xlRange2.Value2 = sourceRng.Value2;
                    //xlRange2.PasteSpecial(Excel.XlPasteType.xlPasteValues);
                    //Clipboard.Clear();
                    xlRange2.RemoveDuplicates(1, Excel.XlYesNoGuess.xlNo);

                    //REMOVE FILTER
                    xlRangeCopy.AutoFilter(i);

                    Marshal.ReleaseComObject(sourceRng);
                    Marshal.ReleaseComObject(xlRange2);
                    Marshal.ReleaseComObject(xlRange3);

                }


                //TRANSPOSE

                Excel.Range xlRange2Used = xlWorksheet2.UsedRange;
                //xlRange2Used.Copy(Type.Missing);
                int rowsXlRange2Used = xlRange2Used.Rows.Count;
                int colsXlRange2Used = xlRange2Used.Columns.Count;

                string newRangeStart = "A" + (rowsXlRange2Used + 2).ToString();
                string newRangeEnd = ((char)(rowsXlRange2Used + 64)).ToString() + (rowsXlRange2Used + colsXlRange2Used + 1 ).ToString();

                Excel.Range xlRange2Replace = xlWorksheet2.get_Range(newRangeStart, newRangeEnd);
                // xlRange2Replace.PasteSpecial(Excel.XlPasteType.xlPasteValues, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, true);
                // Clipboard.Clear();

                // Object[,] transposedRange = (Object[,])xlApp.WorksheetFunction.Transpose(xlRange2Used.Value2);
                //xlWorksheet2.xlRange2Replace.Resize(transposedRange.GetUpperBound(0), transposedRange.GetUpperBound(1)) = transposedRange;

                //Object[,] transposedRange = xlApp.WorksheetFunction.Transpose(xlRange2Used.Value2);
                xlWorksheet2.Range[newRangeStart + ":" +newRangeEnd].Value = xlApp2.WorksheetFunction.Transpose(xlRange2Used);
                xlRange2Used.EntireRow.Delete();


                //SAVE OUTPUT DOCUMENT
                string fileName = Path.GetFileName(sFileName); //retreives the filename from the path
                string directoryName = Path.GetDirectoryName(sFileName); //retreives path of the directory of selected file
                xlWorkbook2.SaveAs(directoryName + "/" + "output_"+ (comboBox1.SelectedIndex + 1)+ fileName);
                label_output.Text = "Output file is complete: " + directoryName + "/" + "output_" + fileName;

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
                //Marshal.ReleaseComObject(xlRange2);
                //Marshal.ReleaseComObject(sourceRng);
                //close and release
                //xlWorkbook.Close(false, Type.Missing, Type.Missing);
                //xlWorkbook2.Close();
                //Marshal.ReleaseComObject(xlWorkbook);
                //Marshal.ReleaseComObject(xlWorkbook2);
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlRange2Replace);
                Marshal.ReleaseComObject(xlRange2Used);
                Marshal.ReleaseComObject(xlRangeCopy);
                
                Marshal.ReleaseComObject(xlWorksheet);
                Marshal.ReleaseComObject(xlWorksheetCopy);
                Marshal.ReleaseComObject(xlWorksheet2);
                Marshal.ReleaseComObject(xlWorkbook);
                Marshal.ReleaseComObject(xlWorkbook2);
                Marshal.ReleaseComObject(xlWorkbookCopy);
                //quit and release
                //xlApp.Quit();
               //xlApp2.Quit();

                Marshal.ReleaseComObject(xlApp);
                Marshal.ReleaseComObject(xlApp2);
                Marshal.ReleaseComObject(xlAppCopy);


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

      
            List<System.Windows.Forms.TextBox> textBoxes = new List<System.Windows.Forms.TextBox>
            {
                box_0101, box_0102, box_0103, box_0104, box_0105, box_0106, box_0107, box_0108
            };

            List<System.Windows.Forms.Label> labels = new List<System.Windows.Forms.Label>
            {
                label_1, label_2, label_3, label_4, label_5, label_6, label_7, label_8
            };

            List<System.Windows.Forms.Label> warnings = new List<System.Windows.Forms.Label>
            {
                textWarning1, textWarning2, textWarning3, textWarning4, textWarning5, textWarning6, textWarning7, textWarning8
            };

            /// hide the boxes and labels before the user selected number of samples
            for (int i = 0; i < 8; i++)
            {
                textBoxes[i].Hide();
                labels[i].Hide();
            }

            for (int i = 7; i > comboBox1.SelectedIndex; i--)
            {
                textBoxes[i].Text = "";
                warnings[i].Text = ""; 
            }

            for (int i = 0; i < comboBox1.SelectedIndex +1; i++ )
            {
                textBoxes[i].Show();
                labels[i].Show();

            }

        }

        private void label_1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
