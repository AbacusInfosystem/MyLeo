using MyLeoRetailerInfo.Common;
using MyLeoRetailerInfo.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLeoRetailer.Models
{
    public class RoleViewModel
    {
        public RoleViewModel()
        {
            FriendlyMessages = new List<FriendlyMessage>();

            role = new RoleInfo();


        }

        public List<FriendlyMessage> FriendlyMessages { get; set; }

        public RoleInfo role { get; set; }


    }
}