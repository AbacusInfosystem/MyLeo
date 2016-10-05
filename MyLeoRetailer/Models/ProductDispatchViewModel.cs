using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerInfo.ProductDispatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLeoRetailer.Models
{
    public class ProductDispatchViewModel
    {
        public ProductDispatchViewModel()
        {
            product_Dispatch = new ProductDispatchInfo();

            List_product_Dispatch = new List<ProductDispatchInfo>();

            Grid_Detail = new GridInfo();

            Query_Detail = new QueryInfo();

            FriendlyMessages = new List<FriendlyMessage>();

            Grid_Detail.Pager.DivObject = "divProductDispatchPager";

            Grid_Detail.Pager.CallBackMethod = "Get_Product_Dispatch";

            Filter = new Filter();

            Cookies = new LoginInfo();
        }

        public GridInfo Grid_Detail
        {
            get;
            set;
        }

        public LoginInfo Cookies 
        { 
            get; 
            set; 
        }

        public QueryInfo Query_Detail
        {
            get;
            set;
        }

        public List<FriendlyMessage> FriendlyMessages
        {
            get;
            set;
        }

      public ProductDispatchInfo product_Dispatch 
        {
            get; 
            set; 
        }

       public List<ProductDispatchInfo> List_product_Dispatch 
        { 
            get; 
            set; 
        }

       public Filter Filter
       { 
       get;
       set;
       }
    }
}