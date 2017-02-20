using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using SGC_Tool.HelpFile;
using TOOLChuyenDuLieu.ControlEntity;
using TPMessageBox;

namespace SGC_Tool.FrmScaleAdappterTool
{
    class CTLScaleHanDung
    {
          public static DataTable GetDSSKUHanDung()
        {
            try
            {
                DataTable dt = new DataTable();
                SQLHelper sqlHelper = new SQLHelper();
                string sql = string.Format(@"SELECT *
                                                FROM   " + Config._DBNameFrontEnd + @"].dbo.ScaleAdHanDung s
                                                where 1=1       
                                                    ");
                dt = sqlHelper.GetDatasetByCommand(sql).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                CTLError.WriteError("CTLScaleHanDung GetDSSKUHanDung ", ex.Message);
                return null;
                throw;
            }
        }
      
        public static DataTable SearchHDScale(string SKU)
        {
            try
            {
                DataTable dt = new DataTable();
                SQLHelper sqlHelper = new SQLHelper();
                string sql = string.Format(@"SELECT *
                                            FROM   [" + Config._DBNameFrontEnd + @"].dbo.ScaleAdHanDung s		                                           
                                            WHERE s.SKU ='{0}'", SKU);
                dt = sqlHelper.GetDatasetByCommand(sql).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                CTLError.WriteError("CTLScaleHanDung SearchHDScale where SKU ", ex.Message);
                return null;
                throw;
            }
        }
        public static DataTable SearchHDScaleAll()
        {
            try
            {
                DataTable dt = new DataTable();
                SQLHelper sqlHelper = new SQLHelper();
                string sql = string.Format(@"SELECT *
                                            FROM   [" + Config._DBNameFrontEnd + @"].dbo.ScaleAdHanDung s		                                           
                                             order by HanDung");
                dt = sqlHelper.GetDatasetByCommand(sql).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                CTLError.WriteError("CTLScaleHanDung SearchHDScale ALL  ", ex.Message);
                return null;
                throw;
            }
        }
        public static bool InsertScaleAdHanDung(EntityScaleAdHanDung hanDung)
        {
            try
            {
                SQLHelper sqlHelper = new SQLHelper();
                string sql = string.Format(@"INSERT INTO [" + Config._DBNameFrontEnd + @"].dbo.ScaleAdHanDung
                                                                (
	                                                                SKU,
	                                                                HanDung,
	                                                                Node
                                                                )
                                                                VALUES
                                                                (
	                                                                '{0}'/* SKU	*/,
	                                                                {1}/* HanDung	*/,
	                                                                '{2}'/* Node	*/
                                                                )",hanDung.SKU,
                                                                  hanDung.HanDung,
                                                                  hanDung.Node);
                sqlHelper.GetExecuteNonQueryByCommand(sql);
                return true;
            }
            catch (Exception ex)
            {
                CTLError.WriteError("CTLScaleHanDung InsertScaleAdHanDung ", ex.Message);
                return false;
                throw;
            }
        }
        public static bool UpdateHanDung(string SKU,int HanDung)
        {
            try
            {

                SQLHelper sqlHelper = new SQLHelper();
                string sql = string.Format(@"
                                                    UPDATE [" + Config._DBNameFrontEnd + @"].dbo.ScaleAdHanDung
                                                    SET
                                                        Node = '{2}',
	                                                    HanDung = {1}
	                                                    
                                                    WHERE SKU='{0}'", SKU,
                                                                HanDung,DateTime.Now.ToString("dd-MM-yy hhmmss")
                                                                );
                int kq = sqlHelper.GetExecuteNonQueryByCommand(sql);
                if (kq <= 0)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                CTLError.WriteError("CTLScaleHanDung UpdateHanDung ", ex.Message);
                return false;
                throw;
            }
        }
    }
}
