using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerInfo.GiftVoucher;
using MyLeoRetailerInfo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLeoRetailer.Models
{
    public class GiftVoucherViewModel : IGridInfo, IQueryInfo
    {
        public GiftVoucherViewModel()
        {

            Grid_Detail = new GridInfo();

            Query_Detail = new QueryInfo();

            GiftVoucher = new GiftVoucherInfo();

            Filter = new Filter_Gift_Voucher();

            FriendlyMessages = new List<FriendlyMessage>();

            Grid_Detail.Pager.DivObject = "divGiftVoucherPager";

            Grid_Detail.Pager.CallBackMethod = "Get_Gift_Vouchers";

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

        public GiftVoucherInfo GiftVoucher
        {
            get;
            set;
        }

        public Filter_Gift_Voucher Filter
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

    public class Filter_Gift_Voucher
    {
        public string Gift_Voucher_No
        {
            get;
            set;
        }
    }
}