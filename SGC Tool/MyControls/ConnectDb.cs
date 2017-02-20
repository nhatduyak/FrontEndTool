using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SGC_Tool.MyControls
{
    static class ConnectDb
    {
        public static SqlConnection sqlConn;
        static public void Connect(string serverName,string dbName,string user,string password)
        {
            sqlConn = new SqlConnection();
            string ServerName = serverName;
            string DbName = dbName;
            string User = user;
            string Password = password;
            string constr = string.Format(@"Server={0};Database={1};User ID={2};Password={3};Trusted_Connection=False;",
                                            ServerName,DbName,User,Password);
            sqlConn.ConnectionString = constr;
            if (sqlConn.State == ConnectionState.Closed)
                sqlConn.Open();
            
        }

        static public DataTable ExcuteQuery(string sqlString)
        {
            DataSet kq = new DataSet();
            SqlDataAdapter myAdapter = new SqlDataAdapter();
            SqlCommand myCom = new SqlCommand();
            myCom.CommandText = sqlString;
            myCom.Connection = sqlConn;
            myCom.CommandTimeout = 0;
            
            myAdapter.SelectCommand = myCom;
            myAdapter.Fill(kq);
            if (kq.Tables[0].Rows.Count == 0)
                return new DataTable();
            return kq.Tables[0];
        }

        static public object ExcuteScalar(string sqlString)
        {
            SqlCommand myCom = new SqlCommand();
            myCom.CommandText = sqlString;
            myCom.Connection = sqlConn;
            myCom.CommandTimeout = 0;

            object kq = myCom.ExecuteScalar();
            return kq;
        }

        static public int ExcuteNonQuery(string sqlString,SqlParameter[] param)
        {
            SqlCommand myCom = new SqlCommand();
            myCom.CommandText = sqlString;
            myCom.Connection = sqlConn;
            myCom.CommandTimeout = 0;
            foreach(SqlParameter p in param)
            {
                myCom.Parameters.Add(p);
            }
            myCom.Prepare();
            return myCom.ExecuteNonQuery();
        }

        static public int ExcuteNonQuery(string sqlString)
        {
            SqlCommand myCom = new SqlCommand();
            myCom.CommandText = sqlString;
            myCom.Connection = sqlConn;
            myCom.CommandTimeout = 0;
            return myCom.ExecuteNonQuery();
        }

        static public bool CheckTableExist(string tableName)
        {
            string sqlString = string.Format(@"SELECT *
                                            FROM   sysobjects
                                            WHERE  TYPE = 'U'
                                                   AND NAME = '{0}'",
                    tableName);
            DataTable kq = ExcuteQuery(sqlString);
            if (kq.Rows.Count == 0)
                return false;
            return true;
        }

        static public void ExcuteNonQuery_WithTransaction(List<string> lstSQLString)
        {
            SqlCommand myCom = new SqlCommand();
            SqlTransaction myTrans;
            myTrans = sqlConn.BeginTransaction();
            myCom.Connection = sqlConn;
            myCom.Transaction = myTrans;
            myCom.CommandTimeout = 0;
            foreach(string sql in lstSQLString)
            {
                myCom.CommandText = sql;
                try
                {
                    myCom.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    myTrans.Rollback();
                    break;
                }
            }
            myTrans.Commit();
        }

        static public int ExcuteNonQuery_WithTransaction(List<string> lstSQLString,List<SqlParameter> param)
        {
            SqlCommand myCom = new SqlCommand();
            SqlTransaction myTrans;
            myTrans = sqlConn.BeginTransaction();
            myCom.Connection = sqlConn;
            myCom.Transaction = myTrans;
            myCom.CommandTimeout = 0;
            foreach(SqlParameter sp in param)
            {
                myCom.Parameters.Add(sp);
            }
            int recEff = 0;
            foreach (string sql in lstSQLString)
            {
                myCom.CommandText = sql;
                try
                {
                    recEff += myCom.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    myTrans.Rollback();
                    break;
                }
            }
            myTrans.Commit();
            return recEff;
        }
    
        
    }
}
