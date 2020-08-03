using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SanjyShop.Business.Common
{
    internal static class SecurityManagement
    {
        private static string EncryptionKey = "";

        static SecurityManagement()
        {
            System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
            //Get your key from config file to open the lock!
            EncryptionKey = (string)settingsReader.GetValue("SecurityKey", typeof(String));
        }

        public static string GenerateKey()
        {
            System.Security.Cryptography.TripleDESCryptoServiceProvider desc = new System.Security.Cryptography.TripleDESCryptoServiceProvider();
            desc.GenerateKey();
            string key = Convert.ToBase64String(desc.Key); //web.config KEY
            return key;
        }

        public static string Encrypt(string mystring)
        {

            //string EncryptionKey = "hasb123456";
            byte[] clearBytes = Encoding.Unicode.GetBytes(mystring);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[]
                {
                    0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
                });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    mystring = Convert.ToBase64String(ms.ToArray());
                    //txt_value.Text = myString;
                }
                return (mystring);
            }
        }
        public static string Decrypt(string Value)
        {
            //string Value = txt_value.Text;
           // string EncryptionKey = "hasb123456";
            Value = Value.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(Value);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[]
                {
                    0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
                });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    Value = Encoding.Unicode.GetString(ms.ToArray());
                    return Value;
                }
            }
        }
    }

}