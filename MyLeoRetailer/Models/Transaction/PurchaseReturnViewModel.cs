using MyLeoRetailer.Models.Common;
using MyLeoRetailerInfo;
using MyLeoRetailerInfo.PurchaseReturn;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerInfo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLeoRetailer.Models.Transaction
{
    public class PurchaseReturnViewModel : IGridInfo, IQueryInfo
    {
        public PurchaseReturnViewModel()
        {
            Grid_Detail = new GridInfo();

            Query_Detail = new QueryInfo();

            PurchaseReturn = new PurchaseReturnInfo();

            Filter = new Filter_Purchase_Return();

            FriendlyMessages = new List<FriendlyMessage>();

            Pager = new Pagination_Info();

            Cookies = new LoginInfo();

            Grid_Detail.Pager.DivObject = "divPurchaseReturnPager";

            Grid_Detail.Pager.CallBackMethod = "Get_Purchase_Returns";

            //Added by vinod mane on 29/09/2016
            PurchaseReturnList = new List<PurchaseReturnInfo>();


            //End
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

        public PurchaseReturnInfo PurchaseReturn
        {
            get;
            set;
        }

        public Filter_Purchase_Return Filter
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

        public List<PurchaseReturnInfo> PurchaseReturnList { get; set; }//Added by vinod mane on 29/09/2016


    }

}
