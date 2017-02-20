
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TOOLChuyenDuLieu.ControlEntity;
using SGC_Tool.HelpFile;

namespace SGC_Tool.MyControls
{
    class CTLSearchBug
    {
        public DataTable LoadAllApplication()
        {
            string sqlString = string.Format(@"select distinct ApplicationName from [" + Config._DBNameFrontEnd + "].dbo.SGC_ApplicationItem order by ApplicationName");
            //DataTable appRel = ConnectDb.ExcuteQuery(sqlString);
            SQLHelper sqlHelper=new SQLHelper();
            DataTable appRel = sqlHelper.GetDatasetByCommand(sqlString).Tables[0];
            return appRel;
        }

      

        public int UpdateApp(string AppName,string Item)
        {
            string sqlString = string.Format(@"UPDATE ["+Config._DBNameFrontEnd+@"].dbo.SGC_ApplicationItem
                                                SET    Item = N'{0}'
                                                WHERE  ApplicationName = '{1}'",Item, AppName);
            int rowEff = ConnectDb.ExcuteNonQuery(sqlString);
            return rowEff;

        }

        public int UpdateApp(string AppName, string NewItemText,string OldTextItem)
        {
            string sqlString = string.Format(@"UPDATE ["+Config._DBNameFrontEnd+@"].dbo.SGC_ApplicationItem
                                                SET    Item = N'{0}'
                                                WHERE  ApplicationName = '{1}' and Item = N'{2}'", NewItemText, AppName,OldTextItem);
            int rowEff = ConnectDb.ExcuteNonQuery(sqlString);
            return rowEff;

        }
        public bool CheckEmptyApp(string App)
        {
            string sqlString = string.Format(@"select ApplicationName from [" + Config._DBNameFrontEnd + "].dbo.SGC_ApplicationItem where len(ltrim(Item)) = 0 or Item is null and ApplicationName = '{0}'", App);
            object kq = ConnectDb.ExcuteScalar(sqlString);
            if (kq == null || kq is DBNull)
                return false;
            return true;
        }
        public DataTable LoadDetailForApp(string AppName)
        {
            string sqlString = string.Format("select Item from [" + Config._DBNameFrontEnd + "].dbo.SGC_ApplicationItem where ApplicationName = N'{0}' and len(ltrim(Item)) <> 0 order by Item",
                                             AppName);
            return ConnectDb.ExcuteQuery(sqlString);
        }
        public DataTable LoadEventForApp(string appName,string Itemname)
        {
            string sqlString = string.Format(@"SELECT *
                                                FROM   ["+Config._DBNameFrontEnd+@"].dbo.SGC_DocumentIssue sdi
                                                WHERE  sdi.AppName = N'{0}'
                                                       AND sdi.Item = N'{1}' ORDER BY Event ", appName, Itemname);

            return ConnectDb.ExcuteQuery(sqlString);
        }

        public DataTable SearchBytitle(string str)
        {
            string sqlString = string.Format(@"SELECT top 10 sdd.ID,
                                                   sdd.IssueContent,
                                                   sdd.Version,                                                 
                                                   sdd.Reference,
                                                   sdd.Title,
                                                    sdi.Event                                                
                                            FROM   ["+Config._DBNameFrontEnd+@"].dbo.SGC_DocumentDetail sdd
                                                    left join ["+Config._DBNameFrontEnd+@"].dbo.SGC_DocumentIssue sdi
                                                        on sdd.ID=sdi.ID                                          
                                            WHERE sdi.Event LIKE N'%{0}%'",
                                             str);
            return ConnectDb.ExcuteQuery(sqlString);
        }

        #region Search by Detail 

        public DataTable SearchByDetail(string str)
        {
            string sqlString = string.Format(@"SELECT top 10 sdd.ID,
                                                   sdd.IssueContent,
                                                   sdd.Version,                                                 
                                                   sdd.Reference,
                                                   sdd.Title,
                                                    sdi.Event                                                
                                            FROM   ["+Config._DBNameFrontEnd+@"].dbo.SGC_DocumentDetail sdd
                                                    left join ["+Config._DBNameFrontEnd+@"].dbo.SGC_DocumentIssue sdi
                                                        on sdd.ID=sdi.ID                                          
                                            WHERE sdd.IssueContent LIKE N'%{0}%'",
                                             str);
            return ConnectDb.ExcuteQuery(sqlString);
        }

        #endregion

        public DataTable SearchBySelectedDC(string appname,string strSerch)
        {
            string sqlString = string.Format(@"SELECT top 10 sdd.ID,
                                                       sdd.IssueContent,
                                                       sdd.Version,
                                                      sdi.Event,
                                                       sdd.Reference,
                                                       sdd.Title
                                                FROM   ["+Config._DBNameFrontEnd+@"].dbo.SGC_DocumentIssue sdi
		                                                LEFT JOIN ["+Config._DBNameFrontEnd+@"].dbo.SGC_DocumentDetail sdd
			                                                ON sdi.ID = sdd.ID		                                               
                                                WHERE sdi.Event LIKE '%{0}%' AND sdi.AppName='{1}' ",
                                             strSerch,appname);
            return ConnectDb.ExcuteQuery(sqlString);
        }
        public DataTable SearchBySelectedItem(string appname, string strSerch,string Item)
        {
            string sqlString = string.Format(@"SELECT top 10 sdd.ID,
                                                       sdd.IssueContent,
                                                       sdd.Version,
                                                        sdi.Event,
                                                       sdd.Reference,
                                                       sdd.Title
                                                FROM   ["+Config._DBNameFrontEnd+@"].dbo.SGC_DocumentIssue sdi
		                                                LEFT JOIN ["+Config._DBNameFrontEnd+@"].dbo.SGC_DocumentDetail sdd
			                                                ON sdi.ID = sdd.ID		                                                
                                                WHERE sdi.Event LIKE '%{0}%' AND sdi.AppName='{1}' AND sdi.Item=N'{2}' ",
                                             strSerch, appname,Item);
            return ConnectDb.ExcuteQuery(sqlString);
        }
        public DataTable GetAttachment(string ID)
        {
            string sqlString = string.Format(@"SELECT sa.*,sdd.Title FROM ["+Config._DBNameFrontEnd+@"].dbo.SGC_Attachment sa
                                                            left join ["+Config._DBNameFrontEnd+@"].dbo.SGC_DocumentDetail sdd
                                                                on sa.DocumentID=sdd.ID
                                                        WHERE sa.DocumentID='{0}'", ID);
            return ConnectDb.ExcuteQuery(sqlString);
        }
        public DataTable SearchByID(string ID)
        {
            string sqlString = string.Format(@"SELECT top 10 sdd.ID,
                                                       sdd.IssueContent,
                                                       sdd.Version,
                                                   
                                                       sdd.Reference,
                                                       sdd.Title
                                                FROM   ["+Config._DBNameFrontEnd+@"].dbo.SGC_DocumentIssue sdi
		                                                LEFT JOIN ["+Config._DBNameFrontEnd+@"].dbo.SGC_DocumentDetail sdd
			                                                ON sdi.ID = sdd.ID		                                                
                                                WHERE sdi.ID='{0}' ",
                                             ID);
            return ConnectDb.ExcuteQuery(sqlString);
        }
        public int insert(byte[] file)
        {
            string sqlString = string.Format(@"INSERT INTO ["+Config._DBNameFrontEnd+@"].dbo.SGC_Attachment
                                                (
	                                                ID,
	                                                Attachment,
	                                                DocumentID
                                                )
                                                VALUES
                                                (
	                                                NEWID(),
	                                                @file,
	                                                '8981dcc6-7fae-420c-8bb3-31308d43eb7e')
                                                ");
            SqlParameter param=new SqlParameter("@file",SqlDbType.Binary,5);
            param.Value = file;
            SqlParameter[] param_list = new SqlParameter[]
                                            {
                                               param
                                            };
            int rowEff = ConnectDb.ExcuteNonQuery(sqlString, param_list);
            return rowEff;
        }
        public DataTable GetDataFeedback(string id)
        {
            string sqlString = string.Format(@"SELECT *                                      
                                            FROM   ["+Config._DBNameFrontEnd+@"].dbo.SGC_Feedback fb                                                                    
                                            WHERE fb.IssueID ='{0}'
                                            order by DateCreated",
                                            id);
            return ConnectDb.ExcuteQuery(sqlString);
        }
        public bool InsertFeedBack(string issueid,string detail,string idcreate,string attID)
        {
            try
            {
                string sql =
                    string.Format(
                        @"INSERT INTO ["+Config._DBNameFrontEnd+@"].[dbo].[SGC_Feedback]
                                                           ([ID]
                                                           ,[IssueID]
                                                           ,[Detail]
                                                           ,[Creator]
                                                           ,[DateCreated]
                                                           ,[IsReplyFeedback]
                                                           ,[IDFeedback]
                                                           ,[AttachmentID])
                                                     VALUES
                                                           (NEWID()
                                                           ,'{0}'
                                                           ,'{1}'
                                                           ,'{2}'
                                                           ,GETDATE()
                                                           ,0
                                                           ,''
                                                           ,'{3}')",issueid,detail,idcreate,attID);
               
                int rowEff = ConnectDb.ExcuteNonQuery(sql);
            }
            catch (Exception exception)
            {
                CTLError.WriteError("InsertFeedback", exception.Message);
                return false;
                throw;
            }
            return true;
        }
        public string GetMaxdatemodify(string appname, string item)
        {
            string sqlString = string.Format(@"SELECT IsNull(max(dateModify),MAX(sdi.datecreated)) AS Ngay                                  
                                                FROM   ["+Config._DBNameFrontEnd+@"].dbo.SGC_DocumentIssue sdi 
                                                where sdi.AppName=N'{0}' and 
                                                        sdi.Item= N'{1}'
                                            ",
                                            appname,item);
            object kq = ConnectDb.ExcuteScalar(sqlString);
            if (kq.ToString() == string.Empty)
                return "";
            return Convert.ToDateTime(kq).ToString("dd-MM-yy HH:mm:ss");
        }
        public string GetMaxdatemodify(string appname)
        {
            string sqlString = string.Format(@"SELECT IsNull(max(dateModify),MAX(sdi.datecreated)) AS Ngay                                  
                                                FROM   ["+Config._DBNameFrontEnd+@"].dbo.SGC_DocumentIssue sdi 
                                                where sdi.AppName=N'{0}'                                                       
                                            ",
                                            appname);
            object kq = ConnectDb.ExcuteScalar(sqlString);
            if (kq.ToString() == string.Empty)
                return "";
            return Convert.ToDateTime(kq).ToString("dd-MM-yy HH:mm:ss");
        }
        public DataTable GetCreateDocument(string id)
        {
            string sqlString = string.Format(@"SELECT sdi.Creator,
                                                sdi.DateCreated, 
                                                sdi.UpdateBy,
                                                sdi.DateModify
                                                FROM ["+Config._DBNameFrontEnd+@"].dbo.SGC_DocumentIssue sdi 
                                                WHERE sdi.ID='{0}'",
                                            id);
            return ConnectDb.ExcuteQuery(sqlString);
        }
        public DataTable GetNameCreateDoc(string id)
        {
            string sqlString = string.Format(@"SELECT nv.TenNV,
                                                       st.MaST,
                                                       st.TenSieuThi
                                                FROM   NhanVien nv
                                                       LEFT JOIN SieuThi st
                                                            ON  nv.MaST = st.MaST
                                                WHERE  nv.MaNV='{0}'                                                       
                                            ",
                                            id);
            return ConnectDb.ExcuteQuery(sqlString);
        }
        public bool InsertTraceLog(string MaNV, DateTime LogInTime, string IP,string ReportForm,int isSuccess)
        {
            try
            {
                string sql =
                    string.Format(
                        @"INSERT INTO ReportLog
                                (
	                                ID,
	                                MaNV,
	                                LogInTime,
	                                IP,
	                                ReportForm,
	                                IsSuccess
                                )
                                VALUES
                                (
	                                NEWID(),
	                                '{0}',
	                               @logintime,
	                                '{1}',
	                               '{2}',
	                               {3}
                                )", MaNV, IP, ReportForm,isSuccess);
                 SqlParameter[] parameters=new SqlParameter[1];
                SqlParameter para=new SqlParameter("@logintime",SqlDbType.DateTime);
                para.Value = LogInTime;
                parameters[0] = para;
                int rowEff = ConnectDb.ExcuteNonQuery(sql,parameters);
            }
            catch (Exception exception)
            {
                CTLError.WriteError("InsertFeedback", exception.Message);
                return false;
                throw;
            }
            return true;
        }
        public bool InsertTraceLog(string MaNV, DateTime LogInTime, string IP, string ReportForm, int isSuccess,string appname,string viewtype)
        {
            try
            {
                string sql =
                    string.Format(
                        @"INSERT INTO ReportLog
                                (
	                                ID,
	                                MaNV,
	                                LogInTime,
	                                IP,
	                                ReportForm,
	                                IsSuccess,
                                    ApplicationName,
                                    ViewType
                                )
                                VALUES
                                (
	                                NEWID(),
	                                '{0}',
	                               @logintime,
	                                '{1}',
	                               '{2}',
	                               {3},
                                    '{4}',
                                    '{5}'
                                )", MaNV, IP, ReportForm, isSuccess,appname,viewtype);
                SqlParameter[] parameters = new SqlParameter[1];
                SqlParameter para = new SqlParameter("@logintime", SqlDbType.DateTime);
                para.Value = LogInTime;
                parameters[0] = para;
                int rowEff = ConnectDb.ExcuteNonQuery(sql, parameters);
            }
            catch (Exception exception)
            {
                CTLError.WriteError("InsertTraceLog", exception.Message);
                return false;
                throw;
            }
            return true;
        }
        public DataTable GetQuyenNhanVien(string id)
        {
            string sqlString = string.Format(@"SELECT *
                                                FROM   QuyenNhanVien qnv
                                                WHERE  qnv.MaNV = '{0}'                                                       
                                            ",
                                            id);
            return ConnectDb.ExcuteQuery(sqlString);
        }
    }
}