using KHTV_ReportTool.Control;

namespace SGC_Tool.MyControls
{
    public static class Ctl_LogIn
    {
        public static string DEF(byte[] def)
        {
            return GetString(AESEncryption.Decrypt(def, "quelquechosedansmon"));
        }

        public static string GetString(byte[] s)
        {
            string str = "";
            for (int i = 0; i < s.Length; i++)
            {
                str = str + ((char)s[i]);
            }
            return str;
        }

       
    }
}
