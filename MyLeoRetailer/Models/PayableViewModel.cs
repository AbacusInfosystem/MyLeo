using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerInfo.Interface;
using MyLeoRetailerInfo.Payable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLeoRetailer.Models
{
    public class PayableViewModel : IGridInfo, IQueryInfo
    {
        public PayableViewModel()
        {
            Grid_Detail = new GridInfo();

            Query_Detail = new QueryInfo();

            Payable = new PayableInfo();

            Filter = new Filter_Payble();

            FriendlyMessages = new List<FriendlyMessage>();

            Payables = new List<PayableInfo>();

            CreditNote = new List<PayableInfo>();

            //Grid_Detail.Pager.DivObject = "divGiftVoucherPager";

            //Grid_Detail.Pager.CallBackMethod = "Get_Gift_Vouchers";
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

        public PayableInfo Payable
        {
            get;
            set;
        }

        public List<PayableInfo> Payables
        {
            get;
            set;
        }

        public List<PayableInfo> CreditNote
        {
            get;
            set;
        }

        public Filter_Payble Filter
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

    public class Filter_Payble
    {
        public int Vendor_Name
        {
            get;
            set;
        }

        public DateTime From_Date
        {
            get;
            set;
        }

        public DateTime To_Date
        {
            get;
            set;
        }

        public int Payble_Status
        {
            get;
            set;
        }
        
    }
}