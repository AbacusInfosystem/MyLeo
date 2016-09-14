using MyLeoRetailerInfo;
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

            Filter = new Filter_Role();

            Query_Detail = new QueryInfo();

            Grid_Detail = new GridInfo();

            accessFunctions = new List<AccessFunctionInfo>();

            Grid_Detail.Pager.DivObject = "divRolePager";

            Grid_Detail.Pager.CallBackMethod = "Get_Roles";

        }

        public List<FriendlyMessage> FriendlyMessages { get; set; }

        public RoleInfo role { get; set; }

        public Filter_Role Filter { get; set; }

        public QueryInfo Query_Detail { get; set; }

        public GridInfo Grid_Detail { get; set; }

        public List<AccessFunctionInfo> accessFunctions { get; set; }

    }


    public class Filter_Role
    {
        public string Role { get; set; }

    }

}