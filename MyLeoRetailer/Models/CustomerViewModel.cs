using MyLeoRetailer.Models.Common;
using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Customer;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerInfo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLeoRetailer.Models
{
    public class CustomerViewModel:IGridInfo, IQueryInfo
	{
		public CustomerViewModel() 
		{
			Grid_Detail = new GridInfo();

			Query_Detail = new QueryInfo();

			Customer = new CustomerInfo();

			Filter = new Filter_Customer();

			FriendlyMessages = new List<FriendlyMessage>();

			Grid_Detail.Pager.DivObject = "divCustomerPager";

			Grid_Detail.Pager.CallBackMethod = "Get_Customers";
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

		public CustomerInfo Customer
		{
			get;
			set;
		}

		public Filter_Customer Filter
		{
			get;
			set;
		}

		public List<FriendlyMessage> FriendlyMessages
		{
			get;
			set;
		}
	}

	public class Filter_Customer
	{
		public string Customer_Name
		{
			get;
			set;
		}

        public string Customer_Mobile1
        {
            get;
            set;
        }
	}
}