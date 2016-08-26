using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerInfo.Employee
{
    public class EmployeeInfo
    {
        public EmployeeInfo()
		{

		}

        public int Employee_Id { get; set; }

        public int Branch_Id { get; set; }

        public string Employee_Name { get; set; }

        public int Designation_Id { get; set; }

        public DateTime Employee_DOB { get; set; }

        public int Employee_Gender { get; set; }

        public string Employee_Address { get; set; }

        public string Employee_City { get; set; }

        public string Employee_State { get; set; }

        public string Employee_Country { get; set; }

        public int Employee_Pincode { get; set; }

        public string Employee_Native_Address { get; set; }

        public string Employee_Mobile1 { get; set; }

        public string Employee_Mobile2 { get; set; }

        public string Employee_Home_Lindline { get; set; }

        public string Employee_EmailId { get; set; }

        public bool IsActive { get; set; }

        public DateTime Created_Date { get; set; }

        public int Created_By { get; set; }

        public DateTime Updated_Date { get; set; }

        public int Updated_By { get; set; }

    }
}
