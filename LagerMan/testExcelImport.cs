using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace LagerMan
{
    class testExcelImport
    {
        private DataSet CurrentSheet;
        private int SheetCount;
        private string FileName;
        private Application OXL;
        private Workbook OWB;
        private Worksheet OSheet;
        private Range ORng;
        private int TotSheet;
        private int CntSheet = 1;

        public testExcelImport(string fileName)
        {
            FileName = fileName;
            //  creat a Application object
            OXL = new Application();
            //   get   WorkBook  object
            OWB = OXL.Workbooks.Open(FileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                    Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                    Missing.Value, Missing.Value);

            TotSheet = OWB.Sheets.Count;
        }

        public DataSet importwIntOp(int CntSheet)
        {
            try
            {
               
                //   get   WorkSheet object 
                OSheet = (Microsoft.Office.Interop.Excel.Worksheet)OWB.Sheets[1];
                System.Data.DataTable dt = new System.Data.DataTable("dtExcel");
                DataSet ds = new DataSet();
                ds.Tables.Add(dt);
                DataRow dr;


                StringBuilder sb = new StringBuilder();
                int jValue = OSheet.UsedRange.Cells.Columns.Count;
                int iValue = OSheet.UsedRange.Cells.Rows.Count;
                //  get data columns
                for (int j = 1; j <= jValue; j++)
                {
                    dt.Columns.Add("column" + j, System.Type.GetType("System.String"));
                }


                //string colString = sb.ToString().Trim();
                //string[] colArray = colString.Split(':');


                //  get data in cell
                for (int i = 1; i <= iValue; i++)
                {
                    dr = ds.Tables["dtExcel"].NewRow();
                    for (int j = 1; j <= jValue; j++)
                    {
                        ORng = (Microsoft.Office.Interop.Excel.Range)OSheet.Cells[i, j];
                        string strValue = ORng.Text.ToString();
                        dr["column" + j] = strValue;
                    }
                    ds.Tables["dtExcel"].Rows.Add(dr);
                    Console.WriteLine("Debug");
                }
                return ds;
            }
            catch (Exception ex)
            {
                //Label1.Text = "Error: ";
                //Label1.Text += ex.Message.ToString();
                Console.WriteLine(ex);
                return null;
            }
            finally
            {
                Console.WriteLine("debug");
                //Dispose();
            }
        }

        private void commitDataSet(DataSet inDS)
    }
}
