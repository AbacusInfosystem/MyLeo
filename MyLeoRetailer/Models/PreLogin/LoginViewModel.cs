using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyLeoRetailer.Models.Common;
using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Product;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerInfo.Interface;
using MyLeoRetailerInfo.Branch;

namespace MyLeoRetailer.Models.PreLogin
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {
            Cookies = new LoginInfo();

            FriendlyMessages = new List<FriendlyMessage>();


        }

        public LoginInfo Cookies { get; set; }

        public List<FriendlyMessage> FriendlyMessages { get; set; }


    }
}