using System;
using System.Data.OleDb;
using System.Drawing;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
using Font = Microsoft.Office.Interop.Excel.Font;

namespace TOOLChuyenDuLieu.ControlEntity
{
    public class CTLImportExcel
    {
        public string ChuoiKetNoi = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={sourcefile}; Jet OLEDB:Engine Type=5;Extended Properties=Excel 8.0;";
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;
               Data Source={sourcefile};Extended Properties=""Excel 12.0;HDR=YES;""";

        public DataTable getDataFromXLS(string strFilePath)
        {
            DataTable table2;
            try
            {
                OleDbConnection connection = new OleDbConnection(this.ChuoiKetNoi.Replace("{sourcefile}", strFilePath));
                connection.Open();
                OleDbCommand command = new OleDbCommand("SELECT * FROM [Sheet1$]", connection);
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = command;
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                connection.Close();
                adapter = null;
                table2 = dataTable;
                connection.Close();
            }
            catch (Exception exception)
            {
                CTLError.WriteError("CTLImportExcel GetDataFromXLS", exception.Message);
                return null;
                throw new Exception(exception.Message);
            }
            return table2;
        }
        public DataTable getDataFromXLS2007(string strFilePath)
        {
            DataTable table2;
            try
            {
                OleDbConnection connection = new OleDbConnection(this.connectionString.Replace("{sourcefile}", strFilePath));
                connection.Open();
                OleDbCommand command = new OleDbCommand("SELECT * FROM [Sheet1$]", connection);
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = command;
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                connection.Close();
                adapter = null;
                table2 = dataTable;
            }
            catch (Exception exception)
            {
                CTLError.WriteError("CTLImportExcel GetDataFromXLS2007", exception.Message);
                return null;
                throw new Exception(exception.Message);
            }
            return table2;
        }
        public void WireGhiChuExcel(string path,string value,int index)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application xlApp;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                Microsoft.Office.Interop.Excel.Range chartRange;

                xlApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
                xlWorkBook = xlApp.Workbooks.Open(path, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue);

                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                //xlWorkSheet.Cells[1, 1] = "http://csharp.net-informations.com";
                xlWorkSheet.get_Range("A" + index, "H" + index).Merge(false);
                chartRange = xlWorkSheet.get_Range("A" + index, "H" + index);
                chartRange.FormulaR1C1 = value;
                chartRange.Font.Bold = true;
                chartRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                chartRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                chartRange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                chartRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter; 

                //xlWorkSheet.get_Range("A" + index, "H" + index+2).Formula = value;
                
                
                xlWorkBook.Save();
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);

            }
            catch (Exception exception)
            {
                CTLError.WriteError("CTLImportExcel WireGhiChuExcel", exception.Message);
                return;
            }
        }
        public void WireInfomationCIM(string path,int index, string name, string sdt,string Address)
        {
            try
            {



                Microsoft.Office.Interop.Excel.Application xlApp;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                Microsoft.Office.Interop.Excel.Range chartRange;

                xlApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
                xlWorkBook = xlApp.Workbooks.Open(path, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue);

                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                //xlWorkSheet.Cells[1, 1] = "http://csharp.net-informations.com";
                
                //xlWorkSheet.Rows.Insert(0, 0);
                //xlWorkSheet.Rows.Insert(0, 0);
                //xlWorkSheet.Rows.Insert(0, 0);
                //thong tin KH
                //Ten KH

                
                xlWorkSheet.get_Range("A" + index+1, "H" + index+1).Merge(false);
                chartRange = xlWorkSheet.get_Range("A" + index + 1, "H" + index + 1);
                chartRange.FormulaR1C1 = name;
                //So DT
                xlWorkSheet.get_Range("A" + index+2, "H" + index+2).Merge(false);
                chartRange = xlWorkSheet.get_Range("A" + index + 2, "H" + index + 2);
                chartRange.FormulaR1C1 = sdt;
                //Dia Chi
                xlWorkSheet.get_Range("A" + index + 3, "H" + index + 3).Merge(false);
                chartRange = xlWorkSheet.get_Range("A" + index + 3, "H" + index + 3);
                chartRange.FormulaR1C1 = Address;

                chartRange.Font.Bold = true;
                chartRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                chartRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                chartRange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                chartRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                //xlWorkSheet.get_Range("A" + index, "H" + index+2).Formula = value;


                xlWorkBook.Save();
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);

            }
            catch (Exception exception)
            {
                CTLError.WriteError("CTLImportExcel WireInfomationCIM", exception.Message);
                return;
            }
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                CTLError.WriteError("CTLImportExcel releaseObject", ex.Message);
                //MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

    }
}

