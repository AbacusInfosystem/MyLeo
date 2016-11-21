using MyLeoRetailer.Models.Common;
using MyLeoRetailerInfo;
using MyLeoRetailerInfo.SalesReturn;
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
    public class SalesReturnViewModel
    {
        public SalesReturnViewModel()
        {
            FriendlyMessages = new List<FriendlyMessage>();

            SalesReturn = new SalesReturnInfo();

            SalesReturns = new List<SalesReturnInfo>();

            SaleReturnItemList = new List<SaleReturnItems>();

            Branch = new BranchInfo();

            Cookies = new LoginInfo();

            Filter = new SalesReturnFilter();

            Grid_Detail = new GridInfo();

            Query_Detail = new QueryInfo();

            Grid_Detail.Pager.DivObject = "divSalesReturnPager";

            Grid_Detail.Pager.CallBackMethod = "Get_SalesReturns";
        }


        public List<FriendlyMessage> FriendlyMessages { get; set; }

        public SalesReturnInfo SalesReturn { get; set; }

        public List<SalesReturnInfo> SalesReturns { get; set; }

        public List<SaleReturnItems> SaleReturnItemList { get; set; }

        public BranchInfo Branch { get; set; }

        public LoginInfo Cookies { get; set; }

        public SalesReturnFilter Filter { get; set; }

        public GridInfo Grid_Detail { get; set; }

        public QueryInfo Query_Detail { get; set; }


    }

    public class SalesReturnFilter
    {
        public int Sales_Return_Id { get; set; }

        public string Sales_Return_No { get; set; }

    
    }
}