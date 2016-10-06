using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerInfo.GiftVoucher;
using MyLeoRetailerInfo.Interface;
using MyLeoRetailerInfo.Receivable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLeoRetailer.Models
{
    public class ReceivableViewModel : IGridInfo, IQueryInfo
    {
        public ReceivableViewModel()
        {
            Grid_Detail = new GridInfo();

            Query_Detail = new QueryInfo();

            Receivable = new ReceivableInfo();

            //Filter = new Filter_Receivable();

            FriendlyMessages = new List<FriendlyMessage>();

            Receivables = new List<ReceivableInfo>();

            Receivables1 = new List<ReceivableInfo>();

            Cookies = new LoginInfo();

            Pager = new Pagination_Info();

            GiftVoucher = new GiftVoucherInfo();

            GiftVouchers = new List<GiftVoucherInfo>();

            Credit_Notes = new List<CreditNote>();

            Grid_Detail.Pager.DivObject = "divReceivablePager";

            Grid_Detail.Pager.CallBackMethod = "Get_Receivable_Search_Details";


            Grid_Detail.Pager.CallBackMethod = "Get_Receivable";
        }

        public List<CreditNote> Credit_Notes { get; set; }

        public GiftVoucherInfo GiftVoucher
        {
            get;
            set;
        }

        public LoginInfo Cookies
        {
            get;
            set;
        }


        public Pagination_Info Pager
        {
            get;
            set;
        }

        public List<GiftVoucherInfo> GiftVouchers
        {
            get;
            set;
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

        public ReceivableInfo Receivable
        {
            get;
            set;
        }

        public List<ReceivableInfo> Receivables
        {
            get;
            set;
        }

        public List<ReceivableInfo> Receivables1
        {
            get;
            set;
        }

        //public Filter_Receivable Filter
        //{
        //    get;
        //    set;
        //}

        public List<FriendlyMessage> FriendlyMessages
        {
            get;
            set;
        }

      

    }

   
}