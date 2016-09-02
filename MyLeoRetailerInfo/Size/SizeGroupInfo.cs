using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerInfo.Size
{
    public class SizeGroupInfo
    {

        public SizeGroupInfo()
        {

        }

        public int Size_Group_Id
        {
            get;
            set;
        }

        public string Size_Group_Name
        {
            get;
            set;
        }

        public int Size_Id { get; set; }

        public string Size_Name { get; set; }

        public int IsActive { get; set; }

        public bool Is_Active { get; set; }

        public DateTime Created_Date
        {
            get;
            set;
        }

        public int Created_By
        {
            get;
            set;
        }

        public DateTime Updated_Date
        {
            get;
            set;
        }

        public int Updated_By
        {
            get;
            set;
        }

    }
}
