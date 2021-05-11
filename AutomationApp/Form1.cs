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
                        //Create COM Objects. Create a COM object for everything that is referenced
                        Excel.Application xlApp = new Excel.Application();
                        xlApp.Visible = true;
                        Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(sFileName);
                        Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                        Excel.Range xlRange = xlWorksheet.UsedRange;

                        int rowCount = xlRange.Rows.Count;
                        int colCount = xlRange.Columns.Count;
                        
                        //xlRange.Sort(xlRange.Columns[3], Excel.XlSortOrder.xlAscending) ;
                        for (int i=3; i<11; i++) 
                        {
                        //filter- i is column number 
                         xlRange.AutoFilter(i,"<100");
                        //code to use filtered data

                        //back to normal
                        xlRange.AutoFilter(i);

                        }


                        //cleanup
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                                               //rule of thumb for releasing com objects:
                        //  never use two dots, all COM objects must be referenced and released individually
                        //  ex: [somthing].[something].[something] is bad

                        //release com objects to fully kill excel process from running in the background
                       Marshal.ReleaseComObject(xlRange);
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
