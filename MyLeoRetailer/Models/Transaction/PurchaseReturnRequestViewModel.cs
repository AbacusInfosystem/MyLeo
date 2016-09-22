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

            Query_Detail = new QueryInfo();

            Grid_Detail = new GridInfo();


        }

        public List<FriendlyMessage> FriendlyMessages { get; set; }

        public PurchaseReturnRequestInfo PurchaseReturnRequest { get; set; }

        public List<PurchaseReturnRequestInfo> PurchaseReturnRequests { get; set; }

        public QueryInfo Query_Detail { get; set; }

        public GridInfo Grid_Detail { get; set; }


    }
}