using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerInfo.Branch
{
    public class BranchInfo
    {
        public BranchInfo()
        {
            //NearLocationDetailsList = new List<Location_Details>();

            //FarLocationDetailsList = new List<Location_Details>();

            LocationDetailsList = new List<Location_Details>();

        }

        public int Branch_ID { get; set; }

        public String Branch_Name { get; set; }

        public String Branch_Address { get; set; }

        public String Branch_City { get; set; }

        public String Branch_State { get; set; }

        public String Branch_Country { get; set; }

        public int Branch_Pincode { get; set; }

        public String Branch_Landline1 { get; set; }

        public String Branch_Landline2 { get; set; }  

        public int IsActive { get; set; }

        public bool Is_Active { get; set; }

        public DateTime Created_Date { get; set; }

        public int Created_By { get; set; }

        public DateTime Updated_Date { get; set; }

        public int Updated_By { get; set; }

        public List<BranchInfo> BranchLocationList { get; set; }

        //public List<Location_Details> NearLocationDetailsList { get; set; }

        //public List<Location_Details> FarLocationDetailsList { get; set; }

        public List<Location_Details> LocationDetailsList { get; set; }

        public int Branch_Location_ID { get; set; }

        public int Branch_Location_Flag { get; set; }

        public int Near_Branch_Location_Pincode { get; set; }

        public int Far_Branch_Location_Pincode { get; set; }

    }

    public class Location_Details
    {
        public int Branch_Location_ID { get; set; }

        public int Branch_Id { get; set; }

        public int Branch_Location_Flag { get; set; }

        public int Branch_Location_Pincode { get; set; }

        public DateTime Created_Date { get; set; }

        public int Created_By { get; set; }

        public DateTime Updated_Date { get; set; }

        public int Updated_By { get; set; }

        public bool Flag { get; set; }

    }

}
