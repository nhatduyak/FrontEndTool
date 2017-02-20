using System;
using System.Data;
using System.Data.SqlClient;
using TOOLChuyenDuLieu.ControlEntity;

namespace SGC_Tool.HelpFile
{
    class SQLHelper
    {
         private string mstr_ConnectionString;
        private SqlConnection mobj_SqlConnection;
         private SqlCommand mobj_SqlCommand;
        private int mint_CommandTimeout = 30;

         public enum ExpectedType
        {

            StringType = 0,
            NumberType = 1,
            DateType = 2,
            BooleanType = 3,
            ImageType = 4
        }

         public SQLHelper()
        {
             try
            {

                mstr_ConnectionString = string.Format("Server={0};Database={1};User ID={2};Password={3};Trusted_Connection=False;MultipleActiveResultSets=True;pooling=true;Max Pool Size=1000000;", Config._server, Config._dbname, Config._username, Config._pass);

                mobj_SqlConnection = new SqlConnection(mstr_ConnectionString);
                mobj_SqlCommand = new SqlCommand();
                mobj_SqlCommand.CommandTimeout = mint_CommandTimeout;
                mobj_SqlCommand.Connection = mobj_SqlConnection;
                //mobj_SqlCommand.Transaction = myTran;
                mobj_SqlConnection.Open();
                 //ParseConnectionString();
            }
            catch (Exception ex)
             {
                 throw new Exception("Error initializing data class." + Environment.NewLine + ex.Message);
             }
         }
         public SQLHelper(bool _isSynPrice)
         {
             try
             {
                  //string _server="10.10.2.38";
                    string _server = "10.10.1.71";
                  string _dbname = "SGC";
                  string _username = "intem";
                  string _pass = "intemFFAACC";

                 mstr_ConnectionString = string.Format("Server={0};Database={1};User ID={2};Password={3};Trusted_Connection=False;",_server,_dbname,_username,_pass);

                 mobj_SqlConnection = new SqlConnection(mstr_ConnectionString);
                 mobj_SqlCommand = new SqlCommand();
                 mobj_SqlCommand.CommandTimeout = mint_CommandTimeout;
                 mobj_SqlCommand.Connection = mobj_SqlConnection;

                 //ParseConnectionString();
             }
             catch (Exception ex)
             {
                 throw new Exception("Error initializing data class." + Environment.NewLine + ex.Message);
             }
         }
         public SQLHelper(string server,string dbname,string user,string pass)
         {
             try
             {
                 //string _server="10.10.2.38";
                 string _server = server;
                 string _dbname =dbname;
                 string _username =user;
                 string _pass = pass;

                 mstr_ConnectionString = string.Format("Server={0};Database={1};User ID={2};Password={3};Trusted_Connection=False;", _server, _dbname, _username, _pass);

                 mobj_SqlConnection = new SqlConnection(mstr_ConnectionString);
                 mobj_SqlCommand = new SqlCommand();
                 mobj_SqlCommand.CommandTimeout = mint_CommandTimeout;
                 mobj_SqlCommand.Connection = mobj_SqlConnection;
                 mobj_SqlConnection.Open();
                 //ParseConnectionString();
             }
             catch (Exception ex)
             {
                 throw new Exception("Error initializing data class." + Environment.NewLine + ex.Message);
             }
         }
        public void Dispose()
        {
             try
            {
                 //Clean Up Connection Object
                 if (mobj_SqlConnection != null)
                 {
                     if (mobj_SqlConnection.State != ConnectionState.Closed)
                      {
                          mobj_SqlConnection.Close();
                      }
                     mobj_SqlConnection.Dispose();
                 }

                 //Clean Up Command Object
                 if (mobj_SqlCommand != null)
                 {
                     mobj_SqlCommand.Dispose();
                 }

             }

             catch (Exception ex)
             {
                 throw new Exception("Error disposing data class." + Environment.NewLine + ex.Message);
             }

         }

        public void CloseConnection()
        {
            if (mobj_SqlConnection.State != ConnectionState.Closed) mobj_SqlConnection.Close();
        }
         public int GetExecuteScalarByCommand(string Command)
        {

             object identity = 0;
             try
            {
                mobj_SqlCommand.CommandText = Command;
                mobj_SqlCommand.CommandTimeout = mint_CommandTimeout;
                mobj_SqlCommand.CommandType = CommandType.StoredProcedure;

                

                mobj_SqlCommand.Connection = mobj_SqlConnection;
                identity = mobj_SqlCommand.ExecuteScalar();
                 CloseConnection();
            }
            catch (Exception ex)
             {
                 CloseConnection();
                 throw ex;
            }
            return Convert.ToInt32(identity);
        }
         public int GetExecuteScalarByCommandText(string Command)
         {

             object identity = 0;
             try
             {
                 mobj_SqlCommand.CommandText = Command;
                 mobj_SqlCommand.CommandTimeout = mint_CommandTimeout;
                 mobj_SqlCommand.CommandType = CommandType.Text;
                 mobj_SqlCommand.Transaction = myTran;


                 mobj_SqlCommand.Connection = mobj_SqlConnection;
                 identity = mobj_SqlCommand.ExecuteScalar();
                 //CloseConnection();
             }
             catch (Exception ex)
             {
                 CloseConnection();
                 throw ex;
             }
             return Convert.ToInt32(identity);
         }
         public object GetExecuteScalarByCommandBytext(string Command)
         {

             object identity = 0;
             try
             {
                 mobj_SqlCommand.CommandText = Command;
                 mobj_SqlCommand.CommandTimeout = mint_CommandTimeout;
                 mobj_SqlCommand.CommandType = CommandType.Text;

                 //mobj_SqlConnection.Open();

                 mobj_SqlCommand.Connection = mobj_SqlConnection;
                 identity = mobj_SqlCommand.ExecuteScalar();
                 //CloseConnection();
             }
             catch (Exception ex)
             {
                 //CloseConnection();
                 throw ex;
             }
             return identity==null?"":identity;
         }
        public int GetExecuteNonQueryByCommand(string Command)
        {
             try
            {
                if (mobj_SqlConnection.State == ConnectionState.Closed)
                    mobj_SqlConnection.Open();
                
                mobj_SqlCommand.CommandText = Command;
                mobj_SqlCommand.CommandTimeout = mint_CommandTimeout;
                mobj_SqlCommand.CommandType = CommandType.Text;
                //mobj_SqlCommand.Transaction = myTran;

                //mobj_SqlConnection.Open();

                mobj_SqlCommand.Connection = mobj_SqlConnection;
                int res= mobj_SqlCommand.ExecuteNonQuery();

                 //CloseConnection();
                return res;
            }
             catch (Exception ex)
             {
                 CloseConnection();
                 return 0;
                 throw ex;
            }
        }

         public DataSet GetDatasetByCommand(string Command)
        {
             try
            {
                mobj_SqlCommand.CommandText = Command;
                mobj_SqlCommand.CommandTimeout = mint_CommandTimeout;
                mobj_SqlCommand.CommandType = CommandType.Text;

                //mobj_SqlConnection.Open();

                SqlDataAdapter adpt = new SqlDataAdapter(mobj_SqlCommand);
                DataSet ds = new DataSet();
                 adpt.Fill(ds);
                 return ds;
            }
            catch (Exception ex)
            {
                return null;
                 throw ex;
            }
            finally
            {
                 CloseConnection();
             }
         }

        public SqlDataReader GetReaderBySQL(string strSQL)
        {
             //mobj_SqlConnection.Open();
            try
            {
                SqlCommand myCommand = new SqlCommand(strSQL, mobj_SqlConnection);
                 return myCommand.ExecuteReader();
             }
             catch (Exception ex)
             {
                 //CloseConnection();
                 throw ex;
            }
        }

         public SqlDataReader GetReaderByCmd(string Command)
        {
            SqlDataReader objSqlDataReader = null;
            try
            {
                mobj_SqlCommand.CommandText = Command;
                mobj_SqlCommand.CommandType = CommandType.StoredProcedure;
                mobj_SqlCommand.CommandTimeout = mint_CommandTimeout;

                //mobj_SqlConnection.Open();
                mobj_SqlCommand.Connection = mobj_SqlConnection;

                objSqlDataReader = mobj_SqlCommand.ExecuteReader() ;
                 return objSqlDataReader;
             }
             catch (Exception ex)
             {
                 //CloseConnection();
                 throw ex;
            }
            
        }

         public void AddParameterToSQLCommand(string ParameterName, SqlDbType ParameterType)
         {
             try
            {
                 mobj_SqlCommand.Parameters.Add(new SqlParameter(ParameterName, ParameterType));
             }

             catch (Exception ex)
             {
                 throw ex;
            }
        }
         public void AddParameterToSQLCommand(string ParameterName, SqlDbType ParameterType,int ParameterSize)
        {
             try
            {
                 mobj_SqlCommand.Parameters.Add(new SqlParameter(ParameterName, ParameterType, ParameterSize));
             }

             catch (Exception ex)
             {
                 throw ex;
            }
        }
         public void SetSQLCommandParameterValue(string ParameterName, object Value)
        {
             try
            {
                mobj_SqlCommand.Parameters[ParameterName].Value = Value;
             }

             catch (Exception ex)
             {
                 throw ex;
            }
        }
         public DataTable GetInfoCustommer(string  makh)
         {
             DataSet ds = new DataSet();
             try
             {
                    //mobj_SqlConnection.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_GET_CUSTOMER_ACCUMULATION_AT_SUPERMARKET", mobj_SqlConnection))
                     {
                         cmd.CommandType = System.Data.CommandType.StoredProcedure;
                         cmd.Parameters.AddWithValue("@MaThe", makh);
                         SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                         
                         adpt.Fill(ds);
                     }
                     //mobj_SqlConnection.Close();
                     if (ds.Tables.Count > 0)
                         return ds.Tables[0];
             }
             catch (Exception ex)
             {
                 CTLError.WriteError("CTLConfig GetInFoCustommer", ex.Message);
                 return null;
             }
             return null;
         }
         public DataTable InfoCustommer(string makh)
         {
             DataSet ds = new DataSet();
             try
             {
                 //mobj_SqlConnection.Open();
                 using (SqlCommand cmd = new SqlCommand("sp_GET_CUSTOMER_INFO_AT_SUPERMARKET", mobj_SqlConnection))
                 {
                     cmd.CommandType = System.Data.CommandType.StoredProcedure;
                     cmd.Parameters.AddWithValue("@MaThe", makh);
                     cmd.Parameters.AddWithValue("@SoDienThoai", "");
                     cmd.Parameters.AddWithValue("@Ho", "");
                     cmd.Parameters.AddWithValue("@Ten", "");
                     SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                     adpt.Fill(ds);
                 }
                 //mobj_SqlConnection.Close();
                 if (ds.Tables.Count > 0)
                     return ds.Tables[0];
             }
             catch (Exception ex)
             {
                 CTLError.WriteError("CTLConfig InFoCustommer", ex.Message);
                 return null;
             }
             return null;
         }
         public DataTable GetDatatableBySP(string Command)
         {
             try
             {
                 mobj_SqlCommand.CommandText = Command;
                 mobj_SqlCommand.CommandTimeout = mint_CommandTimeout;
                 mobj_SqlCommand.CommandType = CommandType.StoredProcedure;

                 //mobj_SqlConnection.Open();

                 SqlDataAdapter adpt = new SqlDataAdapter(mobj_SqlCommand);
                 DataTable ds = new DataTable();
                 adpt.Fill(ds);
                 return ds;
             }
             catch (Exception ex)
             {
                 throw ex;
             }
             finally
             {
                 //CloseConnection();
             }
         }
        public void BeginTransaction()
        {
            myTran = mobj_SqlConnection.BeginTransaction();
        }
        public void BeginTransaction(string transactionName)
        {
            myTran = mobj_SqlConnection.BeginTransaction(transactionName);
        }
        public void Commit()
        {
            myTran.Commit();
        }
        public void Rollback()
        {
            myTran.Rollback();
        } 
        public void Rollback(string transactionName)
        {
            myTran.Rollback(transactionName);
        } 
        
        public SqlTransaction myTran; 

    }

    //}
}
