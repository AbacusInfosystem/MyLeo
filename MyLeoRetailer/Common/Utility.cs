using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerRepo;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace MyLeoRetailer.Common
{
    public static class Utility
    {

        public static LoginInfo Get_Login_User(string cookieName, string key, string key2)
        {
            LoginInfo loginInfo = null;

            if (System.Web.HttpContext.Current.Request.Cookies["LoginInfo"] != null)
            {
                string token = System.Web.HttpContext.Current.Request.Cookies[cookieName][key];

                string branches = System.Web.HttpContext.Current.Request.Cookies[cookieName][key2];

                LoginRepo _lRepo = new LoginRepo();

                loginInfo = new LoginInfo();

                loginInfo = _lRepo.Get_User_Data_By_User_Token(token);

                loginInfo.Branch_Ids = branches;
            }
            
            return loginInfo;
        }

        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
    }
}