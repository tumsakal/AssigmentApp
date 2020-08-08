using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Assignment
{


    public static class ConfigurationHelper
    {
        public static string Configuration_FileName { get; set; }

        private static byte[] _key;

        public static string Key//12345
        {
            set
            {
                _key = new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.ASCII.GetBytes(value));
                //16 char
                //128 bit
            }
        }

        public static void Save<T>(T confg) where T : new()
        {
            try
            {
                FileStream fs = new FileStream(Configuration_FileName, FileMode.CreateNew, FileAccess.Write);
                AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                aes.Key = _key;
                aes.IV = _key;
                CryptoStream encryptor = new CryptoStream(fs, aes.CreateEncryptor(), CryptoStreamMode.Write);
                BinaryFormatter bs = new BinaryFormatter();
                bs.Serialize(encryptor, confg);
                encryptor.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static T Read<T>() where T : new()
        {
            T confg = new T();
            try
            {
                FileStream fs = new FileStream(Configuration_FileName, FileMode.Open, FileAccess.Read);
                AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                aes.Key = _key;
                aes.IV = _key;
                CryptoStream encryptor = new CryptoStream(fs, aes.CreateDecryptor(), CryptoStreamMode.Read);
                BinaryFormatter bs = new BinaryFormatter();
                confg = (T)bs.Deserialize(encryptor);
                encryptor.Close();
                fs.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return confg;
        }

    }
}
