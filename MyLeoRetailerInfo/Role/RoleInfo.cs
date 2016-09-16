using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerInfo.Role
{
    public class RoleInfo
    {
        public int Role_Id { get; set; }

        public string Role_Name { get; set; }

        public bool Is_Active { get; set; }

        public int Created_By { get; set; }

        public DateTime Created_Date { get; set; }

        public int Updated_By { get; set; }

        public DateTime Updated_Date { get; set; }

     
    }
}
