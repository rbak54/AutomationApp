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
                        

                        //Copy everything to the new file and save - so we don't corrupt the original data
                        Excel.Range xlRange2 = xlWorksheet2.get_Range("A1", "P527");
                        Excel.Range sourceRng = xlWorksheet.get_Range("A1", "P527"); //This needs to not be hard-coded
                        sourceRng.Copy(Type.Missing);
                        xlRange2.PasteSpecial(Excel.XlPasteType.xlPasteValues);
                        xlWorkbook2.SaveAs(@"test.xls"); //This also needs to not be hard-coded

                        Excel.Workbook xlWorkbookNew = xlApp2.Workbooks.Open(@"test.xls"); //this also needs to not be hard coded
                        Excel._Worksheet xlWorksheetNew = xlWorkbookNew.Sheets[1];
                        Excel.Range xlRangeNew = xlWorksheetNew.UsedRange;

                        //LOOP THROUGH SAMPLES 
                        //for loop to repeat for each sample. Can reinstate this later.
                        //for (int i=3; i<11; i++) 
                        //{
                        int i = 3;
                        //https://docs.microsoft.com/en-us/dotnet/api/microsoft.office.interop.excel.range.autofilter?view=excel-pia
                        ///SORT AND FILTER- i is column number 
                        xlRangeNew.Sort(xlRangeNew.Columns[i], Excel.XlSortOrder.xlAscending, Type.Missing, Type.Missing, Excel.XlSortOrder.xlAscending, Type.Missing, Excel.XlSortOrder.xlAscending, Excel.XlYesNoGuess.xlYes); xlWorksheet2.Cells[1, 1] = "Test";
                        xlRangeNew.AutoFilter(i, "<100");
                        xlWorkbook2.SaveAs(@"test.xls");






                        Excel.Range newRange = xlWorksheetNew.UsedRange;

                        int rowCount = newRange.Rows.Count;
                        lbl_2.Text = rowCount.ToString(); //This still comes up with 527!

                        //COUNT FILTERED ROWS
                        //These were my attempts to count rows- haven't worked
                        //int rowCount = xlRange.Rows.Count;
                        //lbl_2.Text = rowCount.ToString();                        
                        //int numbRows = xlWorksheet2.UsedRange.Rows.Count;
                        //lbl_2.Text = numbRows.ToString();
                        //sourceRange.Copy(Type.Missing);

                        //COPY FILTERED ROWS- will need to change the values in get range to fit the sample and number of filtered genes
                        //Excel.Range xlRange2 = xlWorksheet2.get_Range("B1", "B5");
                        //Excel.Range sourceRng = xlWorksheet.get_Range("A2", "A6");
                        //sourceRng.Copy(Type.Missing);
                        //xlRange2.PasteSpecial(Excel.XlPasteType.xlPasteValues);


                        //REMOVE FILTER
                        //xlRange.AutoFilter(i);

                        //SAVE INTERMEDIATE DOCUMENT
                        //xlWorkbook2.SaveAs(@"test.xls");


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
                        //xlWorkbook.Close();
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
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
