using System;
using System.Data;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using SGC_Tool.HelpFile;
using TOOLChuyenDuLieu.HelpFile;
using TPMisc.PublicUtility;
using TPMessageBox;
using System.Diagnostics;

namespace TOOLChuyenDuLieu.ControlEntity
{
    class Config
    {
        public static DataTable _tableDMSKU=null;
        public static string _loaican;
        public static int _Interval;
        public static string _pathfileWinDSS;
        public static string _timemer;
        public static string _chucNang;
        public static string _Apptype;
        public static string _ismanager;
        public static string _deletefile;

        public static string _idcreate;
        public static string _tennv;
        public static string _tenst;

        public static string _MaNV;

        public static string _DBNameFrontEnd = "SGCReport";
        public static string _version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        #region Kiểm tra siêu thị

        public static string _pathfileserver;
        public static string _UserKTST;
        public static string _passKTST;
        public static string _UserEmail;
        public static string _passEmail;

        #endregion


        #region Autoupdate

        public static string _server;
        public static string _username;
        public static string _pass;
        public static string _dbname;
        public static string _strKillapp;
        public static string _startapp;

#endregion
        public static void GetConfiguration()
        {
            XmlDocument document = new XmlDocument();
            try
            {
                document.Load(Application.StartupPath + @"\Config.xml");
                try
                {
                    //_pathfile = document.SelectSingleNode("//PathFile").Attributes["Value"].Value;
                    _loaican = document.SelectSingleNode("//LoaiCan").Attributes["Value"].Value;
                    _pathfileWinDSS = document.SelectSingleNode("//PathFileWindss").Attributes["Value"].Value;
                    //_timemer = document.SelectSingleNode("//Timemer").Attributes["Value"].Value;
                   

                    #region autoupdate

                    try
                    {
                        LayCauHinh();
                        _Apptype = document.SelectSingleNode("//AppType").Attributes["Value"].Value;
                        _chucNang = document.SelectSingleNode("//ChucNang").Attributes["Value"].Value;
                        _DBNameFrontEnd = document.SelectSingleNode("//DBNameFrontEnd").Attributes["Value"].Value != string.Empty ? document.SelectSingleNode("//DBNameFrontEnd").Attributes["Value"].Value : "SGCReport";
                        _ismanager = document.SelectSingleNode("//IsManager").Attributes["Value"].Value;
                        _strKillapp = document.SelectSingleNode("//StrKillApp").Attributes["Value"].Value;
                        _startapp = document.SelectSingleNode("//StrStartApp").Attributes["Value"].Value;
                        _deletefile = document.SelectSingleNode("//DeleteFile").Attributes["Value"].Value;
                    }
                    catch (Exception)
                    {
                        
                        return;
                    }
                    

                    #endregion

                    

                }
                catch (Exception exception)
                {
                    CTLError.WriteError("Config getCF", exception.Message);
                    
                }

            }
            catch (Exception exception)
            {
                CTLError.WriteError("Config getCF", exception.Message);
                throw new Exception(exception.Message);
            }
        }
        public static void LoadDanhMucSKU()
        {
            try
            {
                if (CheckFileINVMST())
                {
                    try
                    {
                        SplashScreen.SetCommentaryString("Load Danh mục .......");
                        TPSDataAccess access = new TPSDataAccess(@"C:\WINDOWS\Temp\INVMST.tps");
                        _tableDMSKU = access.GetDataTable("Select SKU,UPC,DESCRIPTION from INVMST where CONF_PRICE='N' and UPC<>''");
                        //_tableDMSKU.Columns.Add("GhiChu");
                    }
                    catch (Exception e)
                    {
                        CTLError.WriteError("GetDMSKU config GetConfiguration", e.Message);
                    }
                }
            }
            catch (Exception e)
            {
                CTLError.WriteError("LoadDanhMucSKU config GetConfiguration", e.Message);
                return;
                throw;
            }
            
        }
        public static void LayCauHinh()
        {
            byte[] key = Blowfish.GetBytes("ThinhPhat@JSC@123").Clone() as byte[];
            Blowfish blowfish = new Blowfish(key);
            StringReader reader = new StringReader(blowfish.ReadFromFile(Application.StartupPath + @"\Config.tps"));
            DataSet ds = new DataSet();
            ds.ReadXml(reader);
            if (ds.Tables[0].Rows.Count < 1)
            {
                throw new Exception("File cấu hình không có kết nối nào");
            }
            _dbname = Convert.ToString(ds.Tables["KetNoi"].Rows[0]["DBName"]);
            _server = Convert.ToString(ds.Tables["KetNoi"].Rows[0]["ServerName"]);
            _username = Convert.ToString(ds.Tables["KetNoi"].Rows[0]["UserName"]);
            _pass = Convert.ToString(ds.Tables["KetNoi"].Rows[0]["Password"]);
            //ConnectDb.Connect(xml.db_server, xml.db_name, xml.db_username, xml.db_password);

        }
        //AppType FrontEntTool 10
        static public bool CheckConfig()
        {
            try
            {
                DirectoryInfo directoryInfo=new DirectoryInfo(Application.StartupPath);
                foreach (FileInfo f in directoryInfo.GetFiles("*.tps"))
                {
                    if(f.Name.ToUpper()=="CONFIG.TPS")
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public static void CheckVersion()
        {
            string strCurrenVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            SQLHelper helper = new SQLHelper();
            string strVersion = "";
            strVersion =""+ helper.GetExecuteScalarByCommandBytext("Select Version from UpdateList where AppType='12'").ToString();
            //if(strVersion==string.Empty)
            //{
            //    return;
            //}
            if(strVersion!=strCurrenVersion)
            {
                SplashScreen.EndDisplay();
                InfoMessage.HienThi(
                    "Version Của Chương trình không đúng!Vui lòng liên hệ với vi tính hoặc Helpdesk để cập nhật",
                    "Vui lòng cập nhật version " + strVersion, "Thông báo", HinhAnhThongBao.LOI, NutThongBao.DONGY);
                Process.GetCurrentProcess().Kill();
            }
            
        }
        public static bool CheckFileINVMST()
        {
            try
            {
                FileInfo fileInfo = new FileInfo(@"C:\WINDOWS\Temp\INVMST.tps");
                SplashScreen.SetCommentaryString("Kiểm tra Danh mục .......");
                if (!fileInfo.Exists)
                {
                    File.Copy(Path.Combine(Config._pathfileWinDSS, "INVMST.TPS"), fileInfo.FullName,true);
                }
                else if (fileInfo.LastWriteTime.ToString("ddMMyyyy") != DateTime.Now.ToString("ddMMyyyy"))
                {
                    File.Copy(Path.Combine(Config._pathfileWinDSS, "INVMST.TPS"), fileInfo.FullName,true);
                }
                return true;
            }
            catch (Exception e)
            {
                CTLError.WriteError("CheckFile FormTimKiem Bang bao gia", e.Message);
                return false;
                throw;
            }
        }
    }
}
