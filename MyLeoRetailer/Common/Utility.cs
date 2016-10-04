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

            if (System.Web.HttpContext.Current.Request.Cookies["MyLeoLoginInfo"] != null)
            {
                string token = System.Web.HttpContext.Current.Request.Cookies[cookieName][key];

                string branches = System.Web.HttpContext.Current.Request.Cookies[cookieName][key2];

                LoginRepo _lRepo = new LoginRepo();

                loginInfo = new LoginInfo();

                loginInfo = _lRepo.Get_User_Data_By_User_Token(token, branches);

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

        public static bool Check_Access_Function_Authorization(AppFunction appFunction)
        {
            string _appFunction = appFunction.ToString();

            int idx = _appFunction.LastIndexOf('_');

            string _accessFun = _appFunction.Substring(0, idx).Replace("_", " ");

            string _access = _appFunction.Substring(idx + 1);

            LoginInfo _cookies;

            _cookies = Utility.Get_Login_User("MyLeoLoginInfo", "MyLeoToken", "Branch_Ids");

            if (_cookies != null && _cookies.Access_Functions.Count() != 0 &&
                _cookies.Access_Functions.Any(x => x.Access_Function_Name == _accessFun && ((x.Is_Access && _access == Actions.Access.ToString()) || (x.Is_Create && _access == Actions.Create.ToString()) || (x.Is_Edit && _access == Actions.Edit.ToString()) || (x.Is_View && _access == Actions.View.ToString()))))
            {
                return true;
            }
            else
            {
               return false;
            }

           
        }

        public static string ConvertDecimalNumbertoWords(decimal number)
        {
            string Result = "";

            string str = number.ToString();

            if (str.Contains("."))
            {
                string value = str.Remove(str.IndexOf("."));
                string decimals = str.Substring(str.IndexOf(".") + 1);

                Result = ConvertNumbertoWords(Int32.Parse(value)) + " point " + ConvertNumbertoWords(Int32.Parse(decimals));
            }
            else
            {
                Result = ConvertNumbertoWords(Int32.Parse(str));
            }

            return Result;
        }

        public static string ConvertNumbertoWords(int number)
        {
            if (number == 0)
                return "Zero";
            if (number < 0)
                return "minus " + ConvertNumbertoWords(Math.Abs(number));
            string words = "";
            if ((number / 1000000) > 0)
            {
                words += ConvertNumbertoWords(number / 1000000) + " Million ";
                number %= 1000000;
            }
            if ((number / 1000) > 0)
            {
                words += ConvertNumbertoWords(number / 1000) + " Thousand ";
                number %= 1000;
            }
            if ((number / 100) > 0)
            {
                words += ConvertNumbertoWords(number / 100) + " Hundred ";
                number %= 100;
            }
            if (number > 0)
            {
                if (words != "")
                    words += "And ";
                var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Ninteen" };
                var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Fourty", "Fifty", "Sixty", "SEVENTY", "Eighty", "Ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += " " + unitsMap[number % 10];
                }
            }
            return words;

        }


        //Add By Gauravi 3-10-2016

        public static string Generate_Ref_No(string initialCharacter, string columnName, string substringStartIndex, string substringEndIndex, string tableName)
        {
            AutoGenerateNumberRepo _autogenerateRepo = new AutoGenerateNumberRepo();
            return _autogenerateRepo.Generate_Ref_No(initialCharacter, columnName, substringStartIndex, substringEndIndex, tableName);
        }

        //End

    }
}