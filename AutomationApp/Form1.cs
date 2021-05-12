using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

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

                //create COM objects for intermediate app
                Excel.Application xlApp2 = new Excel.Application();
                xlApp2.Visible = true;
                Excel.Workbook xlWorkbook2 = xlApp2.Workbooks.Add();
                Excel._Worksheet xlWorksheet2 = xlWorkbook2.Sheets[1];

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
                //for (int i=3; i<11; i++) 
                //{
                int i = 3;
                //https://docs.microsoft.com/en-us/dotnet/api/microsoft.office.interop.excel.range.autofilter?view=excel-pia

                //PUT SAMPLE NAME IN EXCEL


                
                ///SORT AND FILTER- i is column number 
                xlRange.Sort(xlRange.Columns[i], Excel.XlSortOrder.xlAscending, Type.Missing, Type.Missing, Excel.XlSortOrder.xlAscending, Type.Missing, Excel.XlSortOrder.xlAscending, Excel.XlYesNoGuess.xlYes);
                xlRange.AutoFilter(i, "<100");

                //COUNT FILTERED ROWS
                //These were my attempts to count rows- haven't worked
                //int rowCount = xlRange.Rows.Count;
                //lbl_2.Text = rowCount.ToString();                        
                //int numbRows = xlWorksheet2.UsedRange.Rows.Count;
                //lbl_2.Text = numbRows.ToString();
                //sourceRange.Copy(Type.Missing);

                //COPY FILTERED ROWS- will need to change the values in get range to fit the sample and number of filtered genes
                Excel.Range xlRange2 = xlWorksheet2.get_Range("A2", "A6");
                Excel.Range sourceRng = xlWorksheet.get_Range("A2", "A6");
                sourceRng.Copy(Type.Missing);
                xlRange2.PasteSpecial(Excel.XlPasteType.xlPasteValues);


                //REMOVE FILTER
                xlRange.AutoFilter(i);

                //SAVE INTERMEDIATE DOCUMENT
                xlWorkbook2.SaveAs(@"test.xls");
                

                //}


                //cleanup
                GC.Collect();
                GC.WaitForPendingFinalizers();
                //rule of thumb for releasing com objects:
                //  never use two dots, all COM objects must be referenced and released individually
                //  ex: [somthing].[something].[something] is bad

                //release com objects to fully kill excel process from running in the background
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);
                Marshal.ReleaseComObject(xlRange2);
                Marshal.ReleaseComObject(xlWorksheet2);
                Marshal.ReleaseComObject(sourceRng);
                //close and release
                xlWorkbook.Close(false, Type.Missing, Type.Missing);
                xlWorkbook2.Close();
                Marshal.ReleaseComObject(xlWorkbook);
                Marshal.ReleaseComObject(xlWorkbook2);


                //quit and release
                xlApp.Quit();
                xlApp2.Quit();

                Marshal.ReleaseComObject(xlApp);
                Marshal.ReleaseComObject(xlApp2);


                // TRANSPOSE RESULTS
                // MAKE WORD FILE?
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void lbl_1_Click(object sender, EventArgs e)
        {

        }
    }
}
