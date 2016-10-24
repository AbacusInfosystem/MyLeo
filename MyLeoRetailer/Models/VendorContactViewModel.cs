using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerInfo.Interface;
using MyLeoRetailerInfo.Vendor;
using MyLeoRetailerInfo.VendorContact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLeoRetailer.Models
{
    public class VendorContactViewModel : IGridInfo, IQueryInfo
    {
        public VendorContactViewModel() 
		{
			Grid_Detail = new GridInfo();

			Query_Detail = new QueryInfo();

            VendorContact = new VendorContactInfo();

            Filter = new Filter_Vendor_Contact();

			FriendlyMessages = new List<FriendlyMessage>();


            vendorinfo = new VendorInfo();

            this.Vendors = new List<VendorInfo>();
           
            Grid_Detail.Pager.DivObject = "divVendorContactPager";

            Grid_Detail.Pager.CallBackMethod = "Get_Vendor_Contacts";
		}

		public GridInfo Grid_Detail
		{
			get;
			set;
		}

		public QueryInfo Query_Detail
		{
			get;
			set;
		}

        public VendorContactInfo VendorContact
		{
			get;
			set;
		}
        public List<VendorContactInfo> Vendor_Contact// Added by vinod mane on 21/09/2016
        {
            get;
            set;
        }

        public Filter_Vendor_Contact Filter
		{
			get;
			set;
		}

		public List<FriendlyMessage> FriendlyMessages
		{
			get;
			set;
		}


        public VendorInfo vendorinfo
        {
            get;
            set;
        }

        public List<VendorInfo> Vendors
        {
            get;
            set;
        }
       
	}
        public class Filter_Vendor_Contact
	{
        public string Vendor_Contact_Name
		{
			get;
			set;
		}
	}
}