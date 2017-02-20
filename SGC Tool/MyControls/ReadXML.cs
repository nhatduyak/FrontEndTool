using System.Xml;
using System.Windows.Forms;

namespace SGC_Tool.MyControls
{
    class ReadXML
    {
        public string db_server;
        public string db_name;
        public string db_username;
        public string db_password ;
        public int ChieuDaiMa7;
        public int SLGiaoDich;

        public void ReadConfig()
        {
            XmlTextReader reader = new XmlTextReader(Application.StartupPath + @"\Config.xml");
            while (reader.Read())
            {
                switch (reader.Name)
                {
                    case "ServerName":
                        db_server = reader.ReadInnerXml();
                        break;
                    case "DBName":
                        db_name = reader.ReadInnerXml();
                        break;
                    case "UserName":
                        db_username = reader.ReadInnerXml();
                        break;
                    case "Password":
                        db_password = Md5.Decrypt(reader.ReadInnerXml(),true);
                        break;
                }
            }

        }

        public string getPass(string passEncrypt)
        {
            string pass = "";
            if(passEncrypt.Length == 2)
            {
                pass = passEncrypt;
            }
            if(passEncrypt.Length == 3)
            {
                pass = (passEncrypt[1].ToString() + passEncrypt[2].ToString()).ToString();
            }
            if(passEncrypt.Length == 5)
            {
                pass = (passEncrypt[2].ToString() + passEncrypt[3].ToString()).ToString();
            }
            if(passEncrypt.Length == 8)
            {
                pass = (passEncrypt[2].ToString() + passEncrypt[3].ToString() + passEncrypt[5].ToString() + passEncrypt[7].ToString());
            }
            return pass;
        }

        
    }
}
