using MyLeoRetailer.Models.Common;
using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerInfo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyLeoRetailerInfo.PurchaseOrderRequest;
using MyLeoRetailerInfo.Branch;

namespace MyLeoRetailer.Models
{
    public class PurchaseOrderRequestViewModel : IGridInfo, IQueryInfo
	{
        public PurchaseOrderRequestViewModel() 
		{
			Grid_Detail = new GridInfo();

			Query_Detail = new QueryInfo();

			PurchaseOrderRequest = new  PurchaseOrderRequestInfo();

            Branch = new BranchInfo();

            Filter = new Filter_Purchase_Order_Request();

			FriendlyMessages = new List<FriendlyMessage>();

            Pager = new Pagination_Info();

            Cookies = new LoginInfo();

			Grid_Detail.Pager.DivObject = "divPurchaseOrderRequestPager";

            Grid_Detail.Pager.CallBackMethod = "Get_Purchase_Order_Requests";
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

		public  PurchaseOrderRequestInfo PurchaseOrderRequest
		{
			get;
			set;
		}

        public BranchInfo Branch
        {
            get;
            set;
        }

        public Filter_Purchase_Order_Request Filter
		{
			get;
			set;
		}

		public List<FriendlyMessage> FriendlyMessages
		{
			get;
			set;
		}

        public Pagination_Info Pager
        {
            get;
            set;
        }

        public LoginInfo Cookies
        {
            get;
            set;
        }
	}

	
}