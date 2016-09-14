using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerInfo.Role
{
    public class AccessFunctionInfo
    {

        public int Id { get; set; }

        public int Role_Id { get; set; }

        public int Access_Function_Id { get; set; }

        public string Access_Function_Name { get; set; }

        public bool Is_Access { get; set; }

        public bool Is_Create { get; set; }

        public bool Is_Edit { get; set; }

        public bool Is_View { get; set; }

        public bool Is_Active { get; set; }

        public int Created_By { get; set; }

        public DateTime Created_Date { get; set; }

        public int Updated_By { get; set; }

        public DateTime Updated_Date { get; set; }

    }
}
