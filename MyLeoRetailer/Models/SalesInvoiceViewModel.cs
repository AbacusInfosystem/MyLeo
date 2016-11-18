using MyLeoRetailer.Models.Common;
using MyLeoRetailerInfo;
using MyLeoRetailerInfo.SalesInvoice;
using MyLeoRetailerInfo.Vendor;

using MyLeoRetailerInfo.Category;
using MyLeoRetailerInfo.Brand;
using MyLeoRetailerInfo.Tax;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerInfo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyLeoRetailerInfo.Branch;


namespace MyLeoRetailer.Models
{
    public class SalesInvoiceViewModel
    {

        public SalesInvoiceViewModel()
        {
            FriendlyMessages = new List<FriendlyMessage>();

            SalesInvoice = new SalesInvoiceInfo();

            Cookies = new LoginInfo();

            SalesInvoices = new List<SalesInvoiceInfo>();


            SaleOrderItemList = new List<SaleOrderItems>();

            ReceivableItem = new List<Receivable>();

            GiftVoucherDetails = new List<SalesInvoiceInfo>();//Added by vinod mane on 10/10/2016


            CreditNote = new  List<CreditNote>();

            Branch = new BranchInfo();


            Filter = new SalesOrderFilter();

            Grid_Detail = new GridInfo();

            Query_Detail = new QueryInfo();

            Grid_Detail.Pager.DivObject = "divSalesOrderPager";

            Grid_Detail.Pager.CallBackMethod = "Get_SalesOrders";

            //Grid_Detail.Pager.CallBackMethod = "Get_Sales_Summary_Report";
        }


        public List<FriendlyMessage> FriendlyMessages { get; set; }

        public SalesInvoiceInfo SalesInvoice { get; set; }

        public List<SalesInvoiceInfo> SalesInvoices { get; set; }

        public List<SalesInvoiceInfo> GiftVoucherDetails { get; set; }//Added by vinod mane on 10/10/2016

        public LoginInfo Cookies { get; set; }

        public List<SaleOrderItems> SaleOrderItemList { get; set; }

        public List<Receivable> ReceivableItem { get; set; }

        public List<CreditNote> CreditNote { get; set; }

        public BranchInfo Branch { get; set; }

        public SalesOrderFilter Filter { get; set; }

        public GridInfo Grid_Detail { get; set; }

        public QueryInfo Query_Detail { get; set; }

        public int Selected_Branch_Id { get; set; }
             

    }
}