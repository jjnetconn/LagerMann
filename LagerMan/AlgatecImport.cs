using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using InterOpMarshal = System.Runtime.InteropServices.Marshal;
using System.Diagnostics;
using System.Windows.Forms;

namespace LagerMan
{
    class AlgatecImport
    {
        public int[] importSingleFlashXls(string FileName)
        {
            int supplier_id = 110101;
            int prod_id = 101;
            int n = 0, m = 0;
            int[] result = new int[2];

            System.Globalization.NumberFormatInfo decimalSeperator = new System.Globalization.NumberFormatInfo();
            decimalSeperator.NumberDecimalSeparator = "."; 
            decimalSeperator.NumberGroupSeparator = ",";


            List<object[]> dataArray = new List<object[]>();

            //Initialize Excel InterOp and open workbook
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(FileName);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            SQLQuery addData = new SQLQuery();

            //Add order decimalSeperator to _dataArray
            object[] tmpArr0 = new object[3];
            tmpArr0[0] = xlRange.Cells[Properties.Settings.Default.orderID_row, Properties.Settings.Default.orderID_col].Value2;
            tmpArr0[1] = xlRange.Cells[Properties.Settings.Default.articleNo_row, Properties.Settings.Default.articleNo_col].Value2;
            tmpArr0[2] = xlRange.Cells[Properties.Settings.Default.prodName_row, Properties.Settings.Default.prodName_col].Value2;

            for (int i = 4; i <= xlRange.Rows.Count; i++)
            {
                object[] tmpArr1 = new object[xlRange.Columns.Count];

                for (int j = 1; j <= xlRange.Columns.Count; j++)
                {
                    switch (j)
                    {
                        case 1: tmpArr1[j - 1] = Convert.ToInt32(xlRange.Cells[i, j].Value2); break;
                        case 2: tmpArr1[j - 1] = Convert.ToInt32(xlRange.Cells[i, j].Value2); break;
                        case 3: tmpArr1[j - 1] = DateTime.FromOADate(xlRange.Cells[i, j].Value2); break;
                        default: tmpArr1[j - 1] = Convert.ToDouble(xlRange.Cells[i, j].Value2, decimalSeperator); break;
                    }
                }
                object[] newArray = new object[tmpArr0.Length + tmpArr1.Length];
                Array.Copy(tmpArr0, newArray, tmpArr0.Length);
                Array.Copy(tmpArr1, 0, newArray, tmpArr0.Length, tmpArr1.Length);
                if(addData.sql_getPanel(newArray[4]) == false)
                {
                    addData.loadFlashData(newArray, supplier_id, prod_id);
                    n++;
                }
                else
                {
                    string tmpStr = newArray[4].ToString() + " findes allerede i databasen";
                    m++;
                }
                
            }

            //Release Excel file and COM Object
            xlWorkbook.Close();
            InterOpMarshal.ReleaseComObject(xlWorkbook);
            InterOpMarshal.ReleaseComObject(xlApp);
            InterOpMarshal.FinalReleaseComObject(xlApp);
            xlApp = null;
 
            //Kill excel.exe since it will not exit by releasing COM objectes
            KillExcel();
            result[0] = n;
            result[1] = m;
            return result;
        }

        public int importMultipleFlashXls(string[] FileName)
        {
            int i = 0;

            foreach (string element in FileName)
            {
                importSingleFlashXls(element);
                i++;
            }

            KillExcel();

            return i;
        }
        private void KillExcel()
        {
            Process[] AllProcesses = Process.GetProcessesByName("excel");

            // check to kill the right process
            foreach (Process ExcelProcess in AllProcesses)
            {
                ExcelProcess.Kill();
            }

            AllProcesses = null;
        }

     }
}
