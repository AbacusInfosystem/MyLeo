using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerInfo.Common
{
    public class LoginUserInfo
    {
        public int User_Id { get; set; }

        public int Employee_Id { get; set; }

        public int Role_Id { get; set; }

        public string Role_Name { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Token { get; set; }

        public bool Is_Active { get; set; }

        public DateTime Created_Date { get; set; }

        public int Created_By { get; set; }

        public DateTime Updated_Date { get; set; }

        public int Updated_By { get; set; }

    }
}
