using MyLeoRetailer.Models.Common;
using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerInfo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyLeoRetailerInfo.PurchaseReturnRequest;

namespace MyLeoRetailer.Models.Transaction
{
    public class PurchaseReturnRequestViewModel : IGridInfo, IQueryInfo
    {

        public PurchaseReturnRequestViewModel()
        {
            Grid_Detail = new GridInfo();

            Query_Detail = new QueryInfo();

            PurchaseReturnRequest = new PurchaseReturnRequestInfo();

            PurchaseReturnRequests = new List<PurchaseReturnRequestInfo>();

            Filter = new Request_Filter();

            FriendlyMessages = new List<FriendlyMessage>();

            Pager = new Pagination_Info();

            Cookies = new LoginInfo();

            Grid_Detail.Pager.DivObject = "divPurchaseReturnRequestPager";

            Grid_Detail.Pager.CallBackMethod = "Get_Purchase_Return_Requests";

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

        public PurchaseReturnRequestInfo PurchaseReturnRequest
        {
            get;
            set;
        }

        public List<PurchaseReturnRequestInfo> PurchaseReturnRequests
        {
            get;
            set;
        }

        public Request_Filter Filter
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