using System.ComponentModel;

namespace TOOLChuyenDuLieu.HelpFile
{
  
    public class HelpProcess
    {
        public static bool OpenFile(string fullPath)
        {
            try
            {
                System.Diagnostics.Process.Start(fullPath);
            }
            catch (Win32Exception e)
            {
                e.StackTrace.ToString();
                System.Diagnostics.Process.Start("rundll32.exe", "shell32.dll, OpenAs_RunDLL " + fullPath);
            }

            return true;
        }
    }
}
