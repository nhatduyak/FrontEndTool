using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using TOOLChuyenDuLieu.ControlEntity;

namespace TOOLChuyenDuLieu.HelpFile
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
                command.CommandTimeout = 0;
                adapter.Fill(dataTable);
                connection.Close();
                adapter = null;
                table2 = dataTable;
                table2.Columns.Add("NgayModify");
                table2.Columns.Add("Image",typeof(Image));
                table2.Columns.Add("Loai");
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
                OleDbCommand command = new OleDbCommand("SELECT * FROM [Sheet1$A1:C100000]", connection);
                command.CommandTimeout = 0;
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = command;
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                connection.Close();
                adapter = null;
                table2 = dataTable;
                table2.Columns.Add("NgayModify");
                table2.Columns.Add("Image", typeof(System.Byte[]));
            }
            catch (Exception exception)
            {
                CTLError.WriteError("CTLImportExcel GetDataFromXLS2007", exception.Message);
                return null;
                throw new Exception(exception.Message);
            }
            return table2;
        }
    }
}

