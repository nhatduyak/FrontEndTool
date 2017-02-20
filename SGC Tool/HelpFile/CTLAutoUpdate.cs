using System;
using System.Data;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using SGC_Tool.HelpFile;
using TOOLChuyenDuLieu.ControlEntity;
using System.Windows.Forms;

namespace TOOLChuyenDuLieu.HelpFile
{
    public class CTLAutoUpdate
    {
        public bool UpdateFile(string apptype)
        {
            try
            {
                DataSet ds = new DataSet();
                string pathdirectory = "";
                SQLHelper sqlHelper = new SQLHelper();
                ds = sqlHelper.GetDatasetByCommand("Select ID,Version,AppType,DesFolder,UpdateContent,IsUpdate,DateUpdate from Updatelist where 1=1" + (apptype == string.Empty ? "" : " and AppType='" + apptype + "'"));
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dataRow in ds.Tables[0].Rows)
                    {
                        pathdirectory = Path.GetDirectoryName(Path.Combine(Application.StartupPath,
                                                                     dataRow["DesFolder"].ToString()));
                        DirectoryInfo directoryInfo = new DirectoryInfo(pathdirectory);
                        if (!directoryInfo.Exists)
                            Directory.CreateDirectory(directoryInfo.FullName);
                        FileInfo fileInfo = new FileInfo(Path.Combine(Application.StartupPath, dataRow["DesFolder"].ToString()));
                        if (fileInfo.Exists)
                        {
                            if (fileInfo.LastWriteTime != Convert.ToDateTime(dataRow["DateUpdate"]))
                            {
                                File.WriteAllBytes(fileInfo.FullName, (byte[])dataRow["UpdateContent"]);
                                fileInfo.LastWriteTime = Convert.ToDateTime(dataRow["DateUpdate"]);
                                //Updateisupdate(dataRow["ID"].ToString());
                            }
                        }
                        else
                        {
                            File.WriteAllBytes(fileInfo.FullName, (byte[])dataRow["UpdateContent"]);
                            fileInfo.LastWriteTime = Convert.ToDateTime(dataRow["DateUpdate"]);

                        }
                        //Updateisupdate(dataRow["ID"].ToString());
                    }

                }
            }
            catch (Exception exception)
            {
                CTLError.WriteError("FrmMain UpdateClick", exception.Message);
                return false;
                throw;
            }
            return true;
        }
        public static bool UpdateFile()
        {
            try
            {
                DataSet ds = new DataSet();
                string pathdirectory = "";
                SQLHelper sqlHelper = new SQLHelper();
                ds = sqlHelper.GetDatasetByCommand("Select ID,Version,AppType,DesFolder,UpdateContent,IsUpdate,DateUpdate from Updatelist where 1=1 and AppType='" + Config._Apptype + "'");
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dataRow in ds.Tables[0].Rows)
                    {
                        pathdirectory = Path.GetDirectoryName(Path.Combine(Application.StartupPath,
                                                                     dataRow["DesFolder"].ToString()));
                        DirectoryInfo directoryInfo = new DirectoryInfo(pathdirectory);
                        if (!directoryInfo.Exists)
                            Directory.CreateDirectory(directoryInfo.FullName);
                        FileInfo fileInfo = new FileInfo(Path.Combine(Application.StartupPath, dataRow["DesFolder"].ToString()));
                        if (fileInfo.Exists)
                        {
                            if (fileInfo.LastWriteTime != Convert.ToDateTime(dataRow["DateUpdate"]))
                            {
                                File.WriteAllBytes(fileInfo.FullName, (byte[])dataRow["UpdateContent"]);
                                fileInfo.LastWriteTime = Convert.ToDateTime(dataRow["DateUpdate"]);
                                //Updateisupdate(dataRow["ID"].ToString());
                                if (fileInfo.Extension.ToUpper() == ".ZIP")
                                {
                                    if (ExtractAll(fileInfo.FullName, fileInfo.Directory.FullName) > 0)
                                        fileInfo.Delete();
                                }
                                return true;
                            }
                        }
                        else
                        {
                            File.WriteAllBytes(fileInfo.FullName, (byte[])dataRow["UpdateContent"]);
                            fileInfo.LastWriteTime = Convert.ToDateTime(dataRow["DateUpdate"]);
                            if (fileInfo.Extension.ToUpper() == ".ZIP")
                            {
                                if (ExtractAll(fileInfo.FullName, fileInfo.Directory.FullName) > 0)
                                    fileInfo.Delete();
                            }
                            return true;

                        }
                        //Updateisupdate(dataRow["ID"].ToString());
                    }

                }
            }
            catch (Exception exception)
            {
                CTLError.WriteError("FrmMain UpdateClick", exception.Message);
                return false;
                throw;
            }
            return false;
        }

        #region nen & giai nen

        private static void DecompressAndWriteFile(string destination, ZipInputStream source)
        {
            FileStream wstream = null;

            try
            {
                // create a stream to write the file to
                wstream = File.Create(destination);

                const int block = 2048; // number of bytes to decompress for each read from the source

                byte[] data = new byte[block]; // location to decompress the file to

                // now decompress and write each block of data for the zip file entry
                while (true)
                {
                    int size = source.Read(data, 0, data.Length);

                    if (size > 0)
                        wstream.Write(data, 0, size);
                    else
                        break; // no more data
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (wstream != null)
                    wstream.Close();
            }
        }

        public static int ExtractAll(string source, string destination)
        {
            ZipInputStream zinstream = null; // used to read from the zip file
            int numFileUnzipped = 0; // number of files extracted from the zip file

            try
            {
                // create a zip input stream from source zip file
                zinstream = new ZipInputStream(File.OpenRead(source));

                // we need to extract to a folder so we must create it if needed
                if (Directory.Exists(destination) == false)
                    Directory.CreateDirectory(destination);

                ZipEntry theEntry; // an entry in the zip file which could be a file or directory

                // now, walk through the zip file entries and copy each file/directory
                while ((theEntry = zinstream.GetNextEntry()) != null)
                {
                    string dirname = Path.GetDirectoryName(theEntry.Name); // the file path
                    string fname = Path.GetFileName(theEntry.Name);      // the file name

                    // if a path name exists we should create the directory in the destination folder
                    string target = destination + Path.DirectorySeparatorChar + dirname;
                    if (dirname.Length > 0 && !Directory.Exists(target))
                        Directory.CreateDirectory(target);

                    // now we know the proper path exists in the destination so copy the file there
                    if (fname != String.Empty)
                    {
                        DecompressAndWriteFile(destination + Path.DirectorySeparatorChar + theEntry.Name, zinstream);
                        numFileUnzipped++;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                zinstream.Close();
            }

            return numFileUnzipped;
        }

        #endregion
    }
}
