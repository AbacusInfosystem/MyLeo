using MyLeoRetailerInfo.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerInfo.Customer
{
    public class CustomerInfo
    {
        public CustomerInfo()
		{
            States = new List<StateInfo>();
		}

		public int Customer_Id { get; set; }

        public string Customer_Name { get; set; }

        public string Customer_Billing_Address { get; set; }

        public string Customer_Billing_City { get; set; }

        public string Customer_Billing_State { get; set; }

        public string Customer_Billing_Country { get; set; }

        public int Customer_Billing_Pincode { get; set; }

        public string Customer_Shipping_Address { get; set; }

        public string Customer_Shipping_City { get; set; }

        public string Customer_Shipping_State { get; set; }

        public string Customer_Shipping_Country { get; set; }

        public int Customer_Shipping_Pincode { get; set; }

        public string Customer_Mobile1 { get; set; }

        public string Customer_Mobile2 { get; set; }

        public string Customer_Landline1 { get; set; }

        public string Customer_Landline2 { get; set; }

        public int Customer_Gender { get; set; }

        public DateTime Customer_DOB { get; set; }

        public string Customer_Child1_Name { get; set; }

        public string Customer_Child2_Name { get; set; }

        public DateTime Customer_Child1_DOB { get; set; }

        public DateTime Customer_Child2_DOB { get; set; }

        public DateTime Customer_Wedding_Anniversary { get; set; }

        public string Customer_Email1 { get; set; }

        public string Customer_Email2 { get; set; }

        public string Customer_Spouse_Name { get; set; }

        public DateTime Customer_Spouse_DOB { get; set; }


        public int IsActive { get; set; }

        public bool Is_Active { get; set; }

        public DateTime Created_Date { get; set; }

        public int Created_By { get; set; }

        public DateTime Updated_Date { get; set; }

        public int Updated_By { get; set; }


        public string Mobile { get; set; }

        public string First_Name { get; set; }

        public string Last_Name { get; set; }

        public List<StateInfo> States { get; set; }

    }
}
