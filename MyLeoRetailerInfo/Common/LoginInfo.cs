using MyLeoRetailerInfo.Employee;
using MyLeoRetailerInfo.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerInfo.Common
{
    public class LoginInfo
    {

        public LoginInfo()
        {
            Access_Functions = new List<AccessFunctionInfo>();

            Branch_List = new List<EmployeeInfo>();
        }

        //public string Token { get; set; }

        public int User_Id { get; set; }

        public string User_Name { get; set; }

        public string Password { get; set; }

        public string Employee_Name { get; set; }
        
        public int Role_Id { get; set; }

        public string Role_Name { get; set; }

        public string Branch_Ids { get; set; }

        //public string Branch_Names { get; set; }

        public bool Is_Online { get; set; }

        public List<AccessFunctionInfo> Access_Functions { get; set; }

        public List<EmployeeInfo> Branch_List { get; set; }


    }

}
