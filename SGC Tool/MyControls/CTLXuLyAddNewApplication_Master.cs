using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using TOOLChuyenDuLieu.ControlEntity;

namespace SGC_Tool.MyControls
{
    class CTLXuLyAddNewApplication_Master
    {
        
        #region AddNew và các hàm hỗ trợ

        /// <summary>
        /// Add new Application với tên item rỗng
        /// </summary>
        /// <param name="AppName"></param>
        /// <param name="Item"></param>
        /// <returns></returns>
        public int AddNewApp(string AppName, string Item)
        {
            string sqlString = string.Format(@"INSERT INTO ["+Config._DBNameFrontEnd+@"].dbo.SGC_ApplicationItem
                                                (
                                                    ID,
	                                                ApplicationName,
	                                                Item
                                                )
                                                VALUES
                                                (
                                                    @ID,
	                                                @ApplicationName,
	                                                @Item
                                                )");

            SqlParameter[] param_list = new SqlParameter[]
                                            {
                                                new SqlParameter("@ID",SqlDbType.Char,36,ParameterDirection.Input,false,0,0,"ID",DataRowVersion.Current,Guid.NewGuid().ToString()),
                                                new SqlParameter("@ApplicationName",SqlDbType.NVarChar,200,ParameterDirection.Input,false,0,0,"ApplicationName",DataRowVersion.Current,AppName),
                                                new SqlParameter("@Item",SqlDbType.NVarChar,500,ParameterDirection.Input,false,0,0,"Item",DataRowVersion.Current,Item)
                                            };
            int rowEff = ConnectDb.ExcuteNonQuery(sqlString, param_list);
            return rowEff;
        }

        /// <summary>
        /// Kiểm tra App có item rỗng hay không
        /// </summary>
        /// <param name="App"></param>
        /// <returns></returns>
        public bool CheckEmptyApp(string App)
        {
            string sqlString = string.Format(@"select ApplicationName from [" + Config._DBNameFrontEnd + "].dbo.SGC_ApplicationItem where (len(ltrim(Item)) = 0 or Item is null) and ApplicationName = N'{0}'", App);
            object kq = ConnectDb.ExcuteScalar(sqlString);
            if (kq == null || kq is DBNull)
                return false;
            return true;
        }

        /// <summary>
        /// Update tên item vào application, là 1 phần của addnew item
        /// </summary>
        /// <param name="AppName"></param>
        /// <param name="Item"></param>
        /// <returns></returns>
        public int UpdateApp(string AppName, string Item)
        {
            string sqlString = string.Format(@"UPDATE ["+Config._DBNameFrontEnd+@"].dbo.SGC_ApplicationItem
                                                SET    Item = N'{0}'
                                                WHERE  ApplicationName = N'{1}'", Item, AppName);
            int rowEff = ConnectDb.ExcuteNonQuery(sqlString);
            return rowEff;

        }

        /// <summary>
        /// Add new 1 event
        /// </summary>
        /// <param name="appName"></param>
        /// <param name="item"></param>
        /// <param name="Event"></param>
        /// <param name="idNhanVien"></param>
        /// <param name="issueContent"></param>
        /// <param name="Version"></param>
        /// <param name="reference"></param>
        /// <param name="fileNames"></param>
        /// <param name="names"></param>
        /// <returns></returns>
        public string AddNewEvent(string appName, string item, string Event, string idNhanVien, string issueContent, string Version, string reference, List<string> fileNames, List<string> names)
        {
            string ID = Guid.NewGuid().ToString();
            string sqlString_DocumentIssue = string.Format(@"INSERT INTO ["+Config._DBNameFrontEnd+@"].dbo.SGC_DocumentIssue
                                                            (
                                                                ID,
                                                                AppName,
                                                                Item,
                                                                [Event],
                                                                Creator,
                                                                DateCreated,
                                                                UpdateBy,
                                                                DateModify
                                                            )
                                                            VALUES
                                                            (
                                                                '{0}',
                                                                N'{1}',
                                                                N'{2}',
                                                                N'{3}',
                                                                N'{4}',
                                                                @Date,
                                                                N'{5}',
                                                                {6}
                                                            )",
                    ID, appName, item, Event, idNhanVien, "NULL", "NULL");
            SqlParameter param = new SqlParameter("@Date", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0,
                                                  "DateCreated", DataRowVersion.Current, DateTime.Now);
            string title = "";
            int num = GetMaxNumber();
            foreach (string name in names)
            {
                title += (num + 1) + "-" + name + ";";
                num++;
            }
            issueContent = issueContent.Replace("'", "''");
            string sqlString_DocumentDetail = string.Format(@"INSERT INTO ["+Config._DBNameFrontEnd+@"].dbo.SGC_DocumentDetail
                                                                (
	                                                                ID,
	                                                                [Version],
	                                                                Reference,
	                                                                Title,
                                                                    IssueContent
                                                                )
                                                                VALUES
                                                                (
	                                                                '{0}',
	                                                                N'{1}',
	                                                                N'{2}',
	                                                                N'{3}',
	                                                                N'{4}'
                                                                )",
                                        ID, Version, reference, title, issueContent);

            List<string> lstSql = new List<string>();
            lstSql.Add(sqlString_DocumentIssue);
            lstSql.Add(sqlString_DocumentDetail);
            int nextID = GetMaxNumber();

            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(param);

            foreach (string s in fileNames)
            {
                FileInfo fi = new FileInfo(s);
                byte[] b = ConvertFileToByte(fi);
                string attName = "@Att" + (nextID + 1).ToString();
                string sqlAtt = string.Format(@"INSERT INTO ["+Config._DBNameFrontEnd+@"].dbo.SGC_Attachment
                                                (
                                                    ID,
                                                    Attachment,
                                                    DocumentID
                                                )
                                                VALUES
                                                (
                                                    '{0}',
                                                     " + attName + @",
                                                    '{1}'
                                                )", (nextID + 1), ID);

                SqlParameter param_Byte = new SqlParameter(attName, SqlDbType.Binary, 232000, ParameterDirection.Input, true, 0, 0,
                                                            "Attachment", DataRowVersion.Current, b);
                sqlParams.Add(param_Byte);

                nextID++;
                lstSql.Add(sqlAtt);
            }

            if (ConnectDb.ExcuteNonQuery_WithTransaction(lstSql, sqlParams) == 0)
                return null;
            return ID;
        }

        #endregion

        #region Update và các hàm hỗ trợ
 
        /// <summary>
        /// Cập nhật tên application
        /// </summary>
        /// <param name="oldApp"></param>
        /// <param name="newApp"></param>
        public void UpdateAppName(string oldApp, string newApp)
        {
            // update 2 bảng
            string sql_AppItem = string.Format(@"Update [" + Config._DBNameFrontEnd + "].dbo.SGC_ApplicationItem set ApplicationName = N'{0}' where ApplicationName = N'{1}'",
                              newApp, oldApp);
            string sql_SGCDoc = string.Format(@"Update [" + Config._DBNameFrontEnd + "].dbo.SGC_DocumentIssue set AppName = N'{0}' where AppName = N'{1}'",
                              newApp, oldApp);

            List<string> lst = new List<string>();
            lst.Add(sql_AppItem);
            lst.Add(sql_SGCDoc);
            ConnectDb.ExcuteNonQuery_WithTransaction(lst);

        }

        /// <summary>
        /// Update item
        /// </summary>
        /// <param name="oldItem"></param>
        /// <param name="newItem"></param>
        /// <param name="appName"></param>
        public void UpdateItemName(string oldItem, string newItem, string appName)
        {
            // update 2 bảng
            string sql_AppItem = string.Format(@"Update [" + Config._DBNameFrontEnd + "].dbo.SGC_ApplicationItem set Item = N'{0}' where ApplicationName = N'{2}' AND Item = N'{1}'", newItem, oldItem, appName);
            string sql_SGCDoc = string.Format(@"Update [" + Config._DBNameFrontEnd + "].dbo.SGC_DocumentIssue set Item = N'{0}' where AppName = N'{2}' AND Item = N'{1}'", newItem, oldItem, appName);

            List<string> lst = new List<string>();
            lst.Add(sql_AppItem);
            lst.Add(sql_SGCDoc);
            ConnectDb.ExcuteNonQuery_WithTransaction(lst);

        }

        /// <summary>
        /// Rename Event
        /// </summary>
        /// <param name="oldEvent"></param>
        /// <param name="newEvent"></param>
        /// <param name="appName"></param>
        /// <param name="Item"></param>
        public void UpdateEventName(string oldEvent, string newEvent, string appName, string Item)
        {
            // update 1 bảng
            string sql_SGCDoc = string.Format(@"Update [" + Config._DBNameFrontEnd + "].dbo.SGC_DocumentIssue set Event = N'{0}' where AppName = N'{2}' AND Item = N'{3}' AND Event = N'{1}' ", newEvent, oldEvent, appName, Item);

            List<string> lst = new List<string>();
            lst.Add(sql_SGCDoc);
            ConnectDb.ExcuteNonQuery_WithTransaction(lst);

        }

        #endregion

        #region Delete và các hàm hỗ trợ

        /// <summary>
        /// Xóa application
        /// </summary>
        /// <param name="AppName"></param>
        /// <returns></returns>
        public bool DeleteApplication(string AppName)
        {
            List<string> lstSql = new List<string>();
            string sqlString = string.Format(@"select ID from [" + Config._DBNameFrontEnd + "].dbo.SGC_DocumentIssue where AppName = N'{0}'", AppName);
            DataTable kq = ConnectDb.ExcuteQuery(sqlString);
            foreach (DataRow row in kq.Rows)
            {
                string sqlDeleteDocument = string.Format(@"delete from [" + Config._DBNameFrontEnd + "].dbo.SGC_DocumentDetail where ID = '{0}'", row["ID"]);
                string sqlDeleteAtt = string.Format(@"delete from [" + Config._DBNameFrontEnd + "].dbo.SGC_Attachment where DocumentID = '{0}'", row["ID"]);

                lstSql.Add(sqlDeleteDocument);
                lstSql.Add(sqlDeleteAtt);

            }
            string sqlDeleteApp = string.Format(@"delete from [" + Config._DBNameFrontEnd + "].dbo.SGC_ApplicationItem where ApplicationName = N'{0}'",
                                                AppName);
            string sqlDeleteDocIssue = string.Format(@"delete from [" + Config._DBNameFrontEnd + "].dbo.SGC_DocumentIssue where AppName = N'{0}'", AppName);
            lstSql.Add(sqlDeleteApp);
            lstSql.Add(sqlDeleteDocIssue);

            try
            {
                ConnectDb.ExcuteNonQuery_WithTransaction(lstSql);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Delete 1 item
        /// </summary>
        /// <param name="AppName"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool DeleteItem(string AppName, string item)
        {
            List<string> lstSql = new List<string>();
            string sqlString = string.Format(@"select ID from [" + Config._DBNameFrontEnd + "].dbo.SGC_DocumentIssue where AppName = N'{0}' AND Item = N'{1}'", AppName, item);
            DataTable kq = ConnectDb.ExcuteQuery(sqlString);
            foreach (DataRow row in kq.Rows)
            {
                string sqlDeleteDocument = string.Format(@"delete from [" + Config._DBNameFrontEnd + "].dbo.SGC_DocumentDetail where ID = '{0}'", row["ID"]);
                string sqlDeleteAtt = string.Format(@"delete from [" + Config._DBNameFrontEnd + "].dbo.SGC_Attachment where DocumentID = '{0}'", row["ID"]);

                lstSql.Add(sqlDeleteDocument);
                lstSql.Add(sqlDeleteAtt);

            }
            string sqlDeleteApp = string.Format(@"delete from [" + Config._DBNameFrontEnd + "].dbo.SGC_ApplicationItem where ApplicationName = N'{0}' AND Item = N'{1}'", AppName, item);
            string sqlDeleteDocIssue = string.Format(@"delete from [" + Config._DBNameFrontEnd + "].dbo.SGC_DocumentIssue where AppName = N'{0}' AND Item = N'{1}'", AppName, item);
            lstSql.Add(sqlDeleteApp);
            lstSql.Add(sqlDeleteDocIssue);

            try
            {
                ConnectDb.ExcuteNonQuery_WithTransaction(lstSql);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Delete 1 event
        /// </summary>
        /// <param name="AppName"></param>
        /// <param name="item"></param>
        /// <param name="eventname"></param>
        /// <returns></returns>
        public bool DeleteEvent(string AppName, string item, string eventname)
        {
            List<string> lstSql = new List<string>();
            string sqlString = string.Format(@"select ID from [" + Config._DBNameFrontEnd + "].dbo.SGC_DocumentIssue where AppName = N'{0}' AND Item = N'{1}' AND Event = N'{2}'", AppName, item, eventname);
            DataTable kq = ConnectDb.ExcuteQuery(sqlString);
            foreach (DataRow row in kq.Rows)
            {
                string sqlDeleteDocument = string.Format(@"delete from [" + Config._DBNameFrontEnd + "].dbo.SGC_DocumentDetail where ID = '{0}'", row["ID"]);
                string sqlDeleteAtt = string.Format(@"delete from [" + Config._DBNameFrontEnd + "].dbo.SGC_Attachment where DocumentID = '{0}'", row["ID"]);
                string sqlDeleteDocIssue = string.Format(@"delete from [" + Config._DBNameFrontEnd + "].dbo.SGC_DocumentIssue where ID = '{0}'", row["ID"]);

                lstSql.Add(sqlDeleteDocument);
                lstSql.Add(sqlDeleteAtt);
                lstSql.Add(sqlDeleteDocIssue);
            }

            try
            {
                ConnectDb.ExcuteNonQuery_WithTransaction(lstSql);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        } 


        #endregion

        #region Cập nhật nội dung của event

        /// <summary>
        /// Update nội dung ngoài của event
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="detail"></param>
        /// <param name="version"></param>
        /// <param name="reference"></param>
        /// <returns></returns>
        public bool UpdateUserModify(string id)
        {
            string sqlString =
                string.Format(
                    @"UPDATE ["+Config._DBNameFrontEnd+@"].dbo.SGC_DocumentIssue
                                        SET	
	                                        UpdateBy = '{0}',
	                                        DateModify = GETDATE()                                        	
                                        where ID = '{1}'", Config._MaNV,id);
            try
            {
                if (ConnectDb.ExcuteNonQuery(sqlString) > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateDocument_Detail(string ID, string detail, string version, string reference)
        {
            detail = detail.Replace("'", "''");
            string sqlString = string.Format(@"UPDATE ["+Config._DBNameFrontEnd+@"].dbo.SGC_DocumentDetail
                                                SET IssueContent = N'{0}',
                                                    [Version] = N'{2}',
                                                    Reference = N'{3}'
                                                WHERE ID = '{1}'", detail, ID, version, reference);
            try
            {
                if (ConnectDb.ExcuteNonQuery(sqlString) > 0 && UpdateUserModify(ID))
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Xóa attachment
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool DeleteAtt(string ID)
        {
            string sqlString = string.Format(@"DELETE FROM [" + Config._DBNameFrontEnd + @"].dbo.SGC_Attachment WHERE ID = '{0}'", ID);
            try
            {
                int recEff = ConnectDb.ExcuteNonQuery(sqlString);
                if (recEff > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        /// <summary>
        /// Thêm attachment
        /// </summary>
        /// <param name="s"></param>
        /// <param name="DocumentID"></param>
        /// <param name="detail"></param>
        /// <param name="fileName"></param>
        /// <param name="version"></param>
        /// <param name="reference"></param>
        /// <param name="title_Att"></param>
        /// <returns></returns>
        public bool AddNewAtt(string s, string DocumentID, string detail,
                            string fileName, string version, string reference, string title_Att)
        {
            string sqlString_Title = string.Format(@"select Title from [" + Config._DBNameFrontEnd + "].dbo.SGC_DocumentDetail where ID= '{0}'", DocumentID);
            object tt = ConnectDb.ExcuteScalar(sqlString_Title);
            string title = "";
            if (tt is DBNull || tt == null)
            {
                title_Att = "";
            }
            else
                title_Att = tt.ToString();

            int nextID = GetMaxNumber();
            FileInfo fi = new FileInfo(s);
            byte[] b = ConvertFileToByte(fi);
            string attName = "@Att" + (nextID + 1).ToString();
            string sqlAtt = string.Format(@"INSERT INTO ["+Config._DBNameFrontEnd+@"].dbo.SGC_Attachment
                                                (
                                                    ID,
                                                    Attachment,
                                                    DocumentID
                                                )
                                                VALUES
                                                (
                                                    '{0}',
                                                     " + attName + @",
                                                    '{1}'
                                                )", (nextID + 1), DocumentID);

            SqlParameter param_Byte = new SqlParameter(attName, SqlDbType.Binary, b.Length, ParameterDirection.Input, true,
                                                       0, 0, "Attachment", DataRowVersion.Current, b);


            int num = GetMaxNumber();
            title += (num + 1) + "-" + fileName + ";";

            detail = detail.Replace("'", "''");
            string sqlString = string.Format(@"UPDATE ["+Config._DBNameFrontEnd+@"].dbo.SGC_DocumentDetail
                                                SET IssueContent = N'{0}',
                                                    [Version] = N'{2}',
                                                    Reference = N'{3}',
	                                                Title = N'{4}'
                                                WHERE ID = '{1}'", detail, DocumentID, version, reference, title_Att + title);

            List<string> sqlStrings = new List<string>();
            sqlStrings.Add(sqlAtt);
            sqlStrings.Add(sqlString);

            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(param_Byte);
            try
            {
                if (ConnectDb.ExcuteNonQuery_WithTransaction(sqlStrings, lstParam) > 0)
                    return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        #endregion

        #region Truy vấn

        /// <summary>
        /// Truy vấn tất cả application
        /// </summary>
        /// <returns></returns>
        public DataTable LoadAllApplication()
        {
            string sqlString = string.Format(@"select distinct ApplicationName from [" + Config._DBNameFrontEnd + "].dbo.SGC_ApplicationItem order by ApplicationName");
            DataTable appRel = ConnectDb.ExcuteQuery(sqlString);
            return appRel;
        }

        /// <summary>
        /// Load item khác rỗng
        /// </summary>
        /// <param name="AppName"></param>
        /// <returns></returns>
        public DataTable LoadItemForApp(string AppName)
        {
            string sqlString = string.Format("select Item from [" + Config._DBNameFrontEnd + "].dbo.SGC_ApplicationItem where ApplicationName = N'{0}' and len(ltrim(Item)) <> 0 order by Item",
                                             AppName);
            return ConnectDb.ExcuteQuery(sqlString);
        }

        /// <summary>
        /// Truy vấn danh sách event
        /// </summary>
        /// <param name="ApplicationName"></param>
        /// <param name="Item"></param>
        /// <returns></returns>
        public DataTable LoadEventList(string ApplicationName,string Item)
        {
            string sqlString = string.Format(@" select * from [" + Config._DBNameFrontEnd + "].dbo.SGC_DocumentIssue where AppName = N'{0}' and Item =N'{1}' ORDER BY Event",
                                             ApplicationName, Item);
            return ConnectDb.ExcuteQuery(sqlString);

        }

        /// <summary>
        /// Truy vấn event
        /// </summary>
        /// <param name="title"></param>
        /// <param name="appName"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public DataTable LoadEventContent(string title,string appName,string item)
        {
            string sqlString = string.Format(@" select * from ["+Config._DBNameFrontEnd+@"].dbo.SGC_DocumentDetail dd
                                                left join ["+Config._DBNameFrontEnd+@"].dbo.SGC_DocumentIssue di on dd.ID = di.ID
                                                where di.AppName = N'{0}' and di.Item =N'{1}' AND di.Event = N'{2}'",
                                                appName,item,title);
            return ConnectDb.ExcuteQuery(sqlString);

        }

        public byte[] ConvertFileToByte(FileInfo fi)
        {
            try
            {
                FileStream fs = fi.OpenRead();
                //Read all bytes into an array from the specified file.
                int nBytes = (int)fs.Length;
                byte[] ByteArray = new byte[nBytes];
                int nBytesRead = fs.Read(ByteArray, 0, nBytes);
                fs.Close();
                return ByteArray;
            }
            catch (Exception exception)
            {
                return null;
                throw;
            }

        }

        public int GetMaxNumber()
        {
            string sqlString = string.Format(@"SELECT TOP 1 CONVERT(INT, sa.ID) AS ID
                                                FROM   ["+Config._DBNameFrontEnd+@"].dbo.SGC_Attachment sa
                                                ORDER BY CONVERT(INT, sa.ID) DESC ");
            object kq = ConnectDb.ExcuteScalar(sqlString);
            if(kq == null || kq is DBNull)
            {
                return 0;
            }
            return int.Parse(Convert.ToString(kq));
        }
        #endregion

    }
}
