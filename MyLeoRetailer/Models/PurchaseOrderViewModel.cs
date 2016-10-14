using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerInfo.Interface;
using MyLeoRetailerInfo.PurchaseOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLeoRetailer.Models
{
    public class PurchaseOrderViewModel : IGridInfo, IQueryInfo
    {
        public PurchaseOrderViewModel()
        {
            Grid_Detail = new GridInfo();

            Query_Detail = new QueryInfo();

            PurchaseOrder = new PurchaseOrderInfo();

            Filter = new Filter_PurchaseOrder();

            FriendlyMessages = new List<FriendlyMessage>();

            Pager = new Pagination_Info();

            Cookies = new LoginInfo();

            Grid_Detail.Pager.DivObject = "divPurchaseOrderPager";

            Grid_Detail.Pager.CallBackMethod = "Get_Purchase_Orders";
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

        public PurchaseOrderInfo PurchaseOrder
        {
            get;
            set;
        }

        public Filter_PurchaseOrder Filter
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