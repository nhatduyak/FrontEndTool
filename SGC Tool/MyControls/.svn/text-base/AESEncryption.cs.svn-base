using System.IO;
using System.Security.Cryptography;

namespace KHTV_ReportTool.Control
{
    public class AESEncryption
    {
        // Fields
        private static readonly byte[] SALT = new byte[] { 0x26, 220, 0xff, 0, 0xad, 0xed, 0x7a, 0xee, 0xc5, 0xfe, 7, 0xaf, 0x4d, 8, 0x22, 60 };

        // Methods
        public static byte[] Decrypt(byte[] cipher, string password)
        {
            Rijndael rijndael = Rijndael.Create();
            Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, SALT);
            rijndael.Key = bytes.GetBytes(0x20);
            rijndael.IV = bytes.GetBytes(0x10);
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, rijndael.CreateDecryptor(), CryptoStreamMode.Write);
            stream2.Write(cipher, 0, cipher.Length);
            stream2.Close();
            return stream.ToArray();
        }

        public static byte[] Encrypt(byte[] plain, string password)
        {
            Rijndael rijndael = Rijndael.Create();
            Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, SALT);
            rijndael.Key = bytes.GetBytes(0x20);
            rijndael.IV = bytes.GetBytes(0x10);
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, rijndael.CreateEncryptor(), CryptoStreamMode.Write);
            stream2.Write(plain, 0, plain.Length);
            stream2.Close();
            return stream.ToArray();
        }
    }


}
