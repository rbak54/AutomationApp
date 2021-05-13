using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
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
            var fileContent = string.Empty;
            //var filePath = string.Empty;
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
                    //Get the path of specified file
                    filePath = openFileDialog.FileNames;
                    string filePathString = string.Join("\n", filePath);
                    lbl_1.Text = filePathString;


                    //for each in filePath
                    //open file
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
                        
                        
                        Excel.Application xlApp2 = new Excel.Application();
                        xlApp2.Visible = true;
                        Excel.Workbook xlWorkbook2 = xlApp2.Workbooks.Add();
                        Excel._Worksheet xlWorksheet2 = xlWorkbook2.Sheets[1];
                        //Excel.Range xlRange2;


                        //int filteredCols;
                        //xlRange.Sort(xlRange.Columns[3], Excel.XlSortOrder.xlAscending) ;
                        //for (int i=3; i<11; i++) 
                        //{

                       int lastUsedColumn = xlWorksheet.Cells.Find("*", System.Reflection.Missing.Value,
                               System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                               Excel.XlSearchOrder.xlByColumns, Excel.XlSearchDirection.xlPrevious,
                               false, System.Reflection.Missing.Value, System.Reflection.Missing.Value).Column;


                        ///RichTextBox box = new RichTextBox();

                        int rCnt = 0;
                        int cCnt = 0;
                        int i = 3; 


                        Excel._Worksheet column_rearrangement = xlWorksheet2;
                        Excel.Range xlRange1 = xlWorksheet.UsedRange;
                        xlRange1.Sort(xlRange1.Columns[i], Excel.XlSortOrder.xlAscending, Type.Missing, Type.Missing, Excel.XlSortOrder.xlAscending, Type.Missing, Excel.XlSortOrder.xlAscending, Excel.XlYesNoGuess.xlYes); xlWorksheet2.Cells[1, 1] = "Test";
                        column_rearrangement = xlRange1.AutoFilter(i, "<100");
                        Excel.Range rangeNew = column_rearrangement.UsedRange;

                        Excel.Range xlRange3 = xlWorksheet2.get_Range("B1", "B4");
                        Excel.Range sourceRng4 = xlWorksheet.get_Range("A2", "A5");
                        sourceRng4.Copy(Type.Missing);


                        Excel.Range range = xlWorksheet2.UsedRange;

                        rCnt = xlRange1.Rows.Count;
                        cCnt = xlRange1.Columns.Count;

                        for (int ih = 3; i < 4; ih++)  {
  
                        }

                        richTextBox1.Text = rangeNew.ToString();

                        ///richTextBox1.Text += cCnt.ToString();


                        //filter- i is column number 
                        //https://docs.microsoft.com/en-us/dotnet/api/microsoft.office.interop.excel.range.autofilter?view=excel-pia
                        //code to use filtered data-below aren't working, just messing around


                        //int rowCount = xlRange.Rows.Count;
                        //lbl_2.Text = rowCount.ToString();
                        //xlRange2 = xlWorksheet2.get_Range("C1", "C4");
                        //xlRange2.Insert(xlRange.AutoFilter(i, "<100")); 
                        Excel.Range xlRange2 = xlWorksheet2.get_Range("B1", "B4");
                        Excel.Range sourceRng = xlWorksheet.get_Range("A2", "A5");
                        sourceRng.Copy(Type.Missing);
                        //xlRange2.PasteSpecial(Excel.XlPasteType.xlPasteValues, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
                        ///xlRange2.PasteSpecial(Excel.XlPasteType.xlPasteValues);




                        //Excel.Range sourceRange = xlRange.get_Range("A1", "J10");
                        //Excel.Range destinationRange = secondWorksheet.get_Range("A15", "J25");
                        //int numbRows = xlWorksheet2.UsedRange.Rows.Count;
                        //      lbl_2.Text = numbRows.ToString();
                        //sourceRange.Copy(Type.Missing);
                        //destinationRange.PasteSpecial(Microsoft.Office.Interop.Excel.XlPasteType.xlPasteFormulas, Microsoft.Office.Interop.Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
                        //filteredCols =3;
                        //xlRange=xlWorksheet.get_Range("A1", "A"+filteredCols.ToString());
                        //back to normal
                        //xlRange.AutoFilter(i);
                        xlWorkbook2.SaveAs(@"C:\Users\YJu\Documents\HODSautomation");

                        //}


                        //cleanup
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                                               //rule of thumb for releasing com objects:
                        //  never use two dots, all COM objects must be referenced and released individually
                        //  ex: [somthing].[something].[something] is bad

                        //release com objects to fully kill excel process from running in the background
                      //s Marshal.ReleaseComObject(xlRange);
                        Marshal.ReleaseComObject(xlWorksheet);

                        //close and release
                        //xlWorkbook.Close();
                        Marshal.ReleaseComObject(xlWorkbook);

                        //quit and release
                        xlApp.Quit();
                        Marshal.ReleaseComObject(xlApp);
                  }
                    // edit file
                    // make word file
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


    }
}
