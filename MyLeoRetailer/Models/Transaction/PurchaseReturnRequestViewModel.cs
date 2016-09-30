using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerInfo.PurchaseReturnRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLeoRetailer.Models.Transaction
{
    public class PurchaseReturnRequestViewModel
    {

        public PurchaseReturnRequestViewModel()
        {
            FriendlyMessages = new List<FriendlyMessage>();

            PurchaseReturnRequest = new PurchaseReturnRequestInfo();

            PurchaseReturnRequests = new List<PurchaseReturnRequestInfo>();

            PurchaseReturnRequestItems = new List<PurchaseReturnRequestItemInfo>();

            Query_Detail = new QueryInfo();

            Grid_Detail = new GridInfo();

            Filter = new Request_Filter();

            Pager = new Pagination_Info();


        }

        public List<FriendlyMessage> FriendlyMessages { get; set; }

        public PurchaseReturnRequestInfo PurchaseReturnRequest { get; set; }

        public List<PurchaseReturnRequestInfo> PurchaseReturnRequests { get; set; }

        public List<PurchaseReturnRequestItemInfo> PurchaseReturnRequestItems { get; set; }

        public QueryInfo Query_Detail { get; set; }

        public GridInfo Grid_Detail { get; set; }

        public Request_Filter Filter { get; set; }

        public Pagination_Info Pager { get; set; }

    }

    public class Request_Filter
    {
        public int Vendor_Id { get; set; }
    }

}