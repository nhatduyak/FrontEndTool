using System;
using System.Data;
using System.Data.Odbc;
using System.IO;
using TOOLChuyenDuLieu.ControlEntity;

namespace TOOLChuyenDuLieu
{
    class TPSDataAccess
    {

        public TPSDataAccess(string filename)
        {
            _connectionString = BuildConnectionString(filename);
            //_sqlString = BuildTpsSqlString(filename, maps, criteria);
        }

        readonly string _connectionString;
        readonly string _sqlString;
        OdbcConnection _connection;
        OdbcCommand _command;
        private OdbcDataReader _reader;
        public bool Open()
        {
            try
            {
                _connection = new OdbcConnection(_connectionString);
                _connection.Open();
                return true;
            }
            catch (Exception exception)
            {
                CTLError.WriteError("TPSDataAccess Open", exception.Message);
                return false;
                throw;
            }


        }

        //private string BuildTpsSqlString(string filename, List<MapInfo> maps, string criteria)
        //{
        //    string filenameonly = Path.GetFileNameWithoutExtension(filename);
        //    return BuildSqlString(filenameonly, maps, criteria);
        //}

        private string BuildConnectionString(string filename)
        {
            try
            { 
                string path = Path.GetDirectoryName(filename);
                if (!path.EndsWith("\\")) path += "\\";
                //string connectionString = string.Format("Driver={{TopSpeed ODBC Driver (Read-Only)}};dbq={0};extension=tps;DSN=sgcoop_Topspeeds;" +
                //    "oem=N;Datefield=%Date%;Timefield=%Time%;nullemptystr=N", path);
                string connectionString = "DRIVER=Topspeed ODBC Driver;timeout=15;NullEmptyStr=N;Timefield=%Time%;Datefield=%Date%;Oem=N;Extension=tps;DBQ=" + path;
                //string connectionString = "DRIVER=SoftVelocity TopSpeed Driver (*.tps);timeout=15;NullEmptyStr=N;Timefield=%Time%;Datefield=%Date%;Oem=N;Extension=tps;DBQ=" + path;
                return connectionString;

            }
            catch (Exception exception)
            {
                CTLError.WriteError("TPSDataAccess BuildConnectionString", exception.Message);
                return "";
                throw;
            }
           
        }

        public void Close()
        {
            if (_reader != null)
            {
                _reader.Dispose();
                _reader = null;
            }
            if (_command != null)
            {
                _command.Dispose();
                _command = null;
            }
            if (_connection != null)
            {
                _connection.Dispose();
                _connection.Close();
                _connection = null;
            }
        }
        public DataTable GetDataTable(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                if (this.Open())
                {
                    OdbcDataAdapter adapter = new OdbcDataAdapter(sql, _connection);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                CTLError.WriteError("TPSDataAccess GetData", ex.Message);
                return null;
                throw new Exception(ex.Message);
            }
            finally
            {
                this.Close();
            }
            return dt;
        }
        public string GetSkuToUPC(string UPC)
        {
            string SKU = "";
            try
            {
                if (this.Open())
                {
                    if (this.Open())
                    {
                        if (Convert.ToInt64(UPC).ToString().Substring(0, 2) == "29")
                        {
                            UPC = "00000000000".Substring(0, 6) + UPC.Substring(0, UPC.Length - 6);
                        }
                        OdbcCommand _cmdObj = new OdbcCommand();
                        _cmdObj.Connection = _connection;
                        _cmdObj.CommandText = "select SKU from INVUPC where 1=1 and UPC='" + UPC + "'";
                        _cmdObj.CommandType = CommandType.Text;
                        //OdbcParameter Ptungay = new OdbcParameter("@tungay", OdbcType.BigInt);
                        //Ptungay.Value = tungay.ToOADate();
                        //_cmdObj.Parameters.Add(Ptungay);
                        //OdbcParameter Pdenngay = new OdbcParameter("@denngay", OdbcType.BigInt);
                        //Pdenngay.Value = denngay.ToOADate();
                        //_cmdObj.Parameters.Add(Pdenngay);
                        //OdbcDataAdapter adapter = new OdbcDataAdapter(_cmdObj);
                        //adapter.Fill(dt);
                        SKU = (_cmdObj.ExecuteScalar() == null) ? "" : _cmdObj.ExecuteScalar().ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                CTLError.WriteError("TPSDataAccess GetSKUToUPC", ex.Message);
                return "";
                throw new Exception(ex.Message);
            }
            finally
            {
                this.Close();
            }
            return SKU;
        }
        public DataTable GetTableDM()
        {
            DataTable dt = new DataTable();
            string sql = @"Select SKU,UPC,Description,Price,CurrencyCode,Sell_Unit,0 as Check,0 as HanDung from INVMST where UPC like '%0000000000029%'";
            try
            {
                if (this.Open())
                {
                    OdbcCommand _cmdObj = new OdbcCommand();
                    _cmdObj.Connection = _connection;
                    _cmdObj.CommandText = sql;
                    _cmdObj.CommandType = CommandType.Text;
                    //OdbcParameter Ptungay = new OdbcParameter("@tungay", OdbcType.BigInt);
                    //Ptungay.Value = tungay.ToOADate();
                    //_cmdObj.Parameters.Add(Ptungay);
                    //OdbcParameter Pdenngay = new OdbcParameter("@denngay", OdbcType.BigInt);
                    //Pdenngay.Value = denngay.ToOADate();
                    //_cmdObj.Parameters.Add(Pdenngay);
                    OdbcDataAdapter adapter = new OdbcDataAdapter(_cmdObj);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                CTLError.WriteError("TPSDataAccess GetTableDM", ex.Message);
                return null;
                throw new Exception(ex.Message);
            }
            finally
            {
                //_command.Dispose();
                //_connection.Close();
                this.Close();
            }
            return dt;
        }
        public DataTable GetTableDM(int HanDungDefault)
        {
            DataTable dt = new DataTable();
            string sql = @"Select SKU,UPC,Description,Price,CurrencyCode,Sell_Unit,0 as Check,"+HanDungDefault+" as HanDung from INVMST where UPC like '%0000000000029%'";
            try
            {
                if (this.Open())
                {
                    OdbcCommand _cmdObj = new OdbcCommand();
                    _cmdObj.Connection = _connection;
                    _cmdObj.CommandText = sql;
                    _cmdObj.CommandType = CommandType.Text;
                    //OdbcParameter Ptungay = new OdbcParameter("@tungay", OdbcType.BigInt);
                    //Ptungay.Value = tungay.ToOADate();
                    //_cmdObj.Parameters.Add(Ptungay);
                    //OdbcParameter Pdenngay = new OdbcParameter("@denngay", OdbcType.BigInt);
                    //Pdenngay.Value = denngay.ToOADate();
                    //_cmdObj.Parameters.Add(Pdenngay);
                    OdbcDataAdapter adapter = new OdbcDataAdapter(_cmdObj);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                CTLError.WriteError("TPSDataAccess GetTableDM", ex.Message);
                return null;
                throw new Exception(ex.Message);
            }
            finally
            {
                //_command.Dispose();
                //_connection.Close();
                this.Close();
            }
            return dt;
        }
        public DataTable GetTableDM(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                if (this.Open())
                {
                    OdbcCommand _cmdObj = new OdbcCommand();
                    _cmdObj.Connection = _connection;
                    _cmdObj.CommandText = sql;
                    _cmdObj.CommandType = CommandType.Text;
                    //OdbcParameter Ptungay = new OdbcParameter("@tungay", OdbcType.BigInt);
                    //Ptungay.Value = tungay.ToOADate();
                    //_cmdObj.Parameters.Add(Ptungay);
                    //OdbcParameter Pdenngay = new OdbcParameter("@denngay", OdbcType.BigInt);
                    //Pdenngay.Value = denngay.ToOADate();
                    //_cmdObj.Parameters.Add(Pdenngay);
                    OdbcDataAdapter adapter = new OdbcDataAdapter(_cmdObj);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                CTLError.WriteError("TPSDataAccess GetTableDM sql", ex.Message);
                return null;
                throw new Exception(ex.Message);
            }
            finally
            {
                //_command.Dispose();
                //_connection.Close();
                this.Close();
            }
            return dt;
        }
        public DataTable GetDataTable_gia(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                if (this.Open())
                {
                    OdbcCommand _cmdObj = new OdbcCommand();
                    _cmdObj.Connection = _connection;
                    _cmdObj.CommandText = sql;
                    _cmdObj.CommandType = CommandType.Text;
                    //OdbcParameter Ptungay = new OdbcParameter("@tungay", OdbcType.BigInt);
                    //Ptungay.Value = tungay.ToOADate();
                    //_cmdObj.Parameters.Add(Ptungay);
                    //OdbcParameter Pdenngay = new OdbcParameter("@denngay", OdbcType.BigInt);
                    //Pdenngay.Value = denngay.ToOADate();
                    //_cmdObj.Parameters.Add(Pdenngay);
                    OdbcDataAdapter adapter = new OdbcDataAdapter(_cmdObj);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                //_command.Dispose();
                //_connection.Close();
                this.Close();
            }
            return dt;
        }
        public string getMaSieuthi()
        {
            string name = "";
            //OdbcConnection con = new OdbcConnection("DRIVER=Topspeed ODBC Driver;timeout=15;NullEmptyStr=N;Timefield=%Time%;Datefield=%Date%;Oem=N;Extension=tps;DBQ=" + Path.Combine(CTLConfig._pathfileWinDSS, ""));
            try
            {

                this.Open();
                OdbcCommand cmd = new OdbcCommand();
                cmd.Connection = _connection;
                cmd.CommandText = string.Format("Select STORE_NO from SYSMST");
                cmd.CommandType = CommandType.Text;
                //OdbcParameter Ptungay = new OdbcParameter("@tungay", OdbcType.BigInt);
                //Ptungay.Value = tungay.ToOADate();
                //_cmdObj.Parameters.Add(Ptungay);
                //OdbcParameter Pdenngay = new OdbcParameter("@denngay", OdbcType.BigInt);
                //Pdenngay.Value = denngay.ToOADate();
                //_cmdObj.Parameters.Add(Pdenngay);
                name = cmd.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
                CTLError.WriteError("TPSDataAccess GetStoreName", ex.Message);
                return "0";
                throw;
            }
            finally
            {
                _connection.Close();
            }
            return name;
        }
        public string GetPricecategory(string custnum)
        {
            string name = "";
            //OdbcConnection con = new OdbcConnection("DRIVER=Topspeed ODBC Driver;timeout=15;NullEmptyStr=N;Timefield=%Time%;Datefield=%Date%;Oem=N;Extension=tps;DBQ=" + Path.Combine(CTLConfig._pathfileWinDSS, ""));
            try
            {

                this.Open();
                OdbcCommand cmd = new OdbcCommand();
                cmd.Connection = _connection;
                cmd.CommandText = string.Format("Select Pricecategory from CUST where MCUSTNUM ="+custnum);
                cmd.CommandType = CommandType.Text;
                //OdbcParameter Ptungay = new OdbcParameter("@tungay", OdbcType.BigInt);
                //Ptungay.Value = tungay.ToOADate();
                //_cmdObj.Parameters.Add(Ptungay);
                //OdbcParameter Pdenngay = new OdbcParameter("@denngay", OdbcType.BigInt);
                //Pdenngay.Value = denngay.ToOADate();
                //_cmdObj.Parameters.Add(Pdenngay);
                name = cmd.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
                CTLError.WriteError("TPSDataAccess GetPricecategory", ex.Message);
                return "0";
                throw;
            }
            finally
            {
                _connection.Close();
            }
            return name;
        }
    }
}
