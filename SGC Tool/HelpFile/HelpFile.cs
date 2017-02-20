using System;
using System.IO;

namespace TOOLChuyenDuLieu.HelpFile
{
    public class HelpFile 
    {
        public static bool CheckFileSize(string path, long maxFileSizeMB)
        {
            FileInfo fi = new FileInfo(path);
            if (fi.Length / 1048576 > maxFileSizeMB)
                return false;
            return true;
        }

        public static byte[] FileToBytes(string fullPath)
        {
            FileStream fs = null;
            byte[] bytes = null;
            try
            {
                fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read);
                bytes = new byte[fs.Length];
                int numBytesToRead = (int)fs.Length;
                int numBytesRead = 0;
                while (numBytesToRead > 0)
                {
                    int n = fs.Read(bytes, numBytesRead, numBytesToRead);
                    if (n == 0) break;
                    numBytesRead += n;
                    numBytesToRead -= n;
                }
                numBytesToRead = bytes.Length;
            }
            catch (IOException e)
            {
                return null;
            }
            catch (OutOfMemoryException oe)
            {
                return null;
            }
            finally
            {
                fs.Close();
            }

            return bytes;
        }

        public static bool BytesToFile(byte[] bytes, string fullPath)
        {
            int numBytesToWrite = bytes.Length;
            FileStream fs = null;
            try
            {
                fs = new FileStream(fullPath, FileMode.Create, FileAccess.Write);
                fs.Write(bytes, 0, numBytesToWrite);
            }
            catch (IOException e)
            {
                e.StackTrace.ToString();
                return false;
            }
            finally
            {
                fs.Close();
            }

            return true;
        }
                
        //public static bool OpenFile(string fullPath)
        //{
        //    return HelpProcess.OpenFile(fullPath);
        //}
    }
}
