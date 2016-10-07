using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerInfo.Interface;
using MyLeoRetailerInfo.ProductWarehouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLeoRetailer.Models
{
    public class ProductWarehouseViewModel : IGridInfo, IQueryInfo
    {
        public ProductWarehouseViewModel()
        {
            product_warehouse = new ProductWarehouseInfo();

            List_product_warehouse = new List<ProductWarehouseInfo>();

            Grid_Detail = new GridInfo();

            Query_Detail = new QueryInfo();

            Filter = new Filter_Warehouse();

            FriendlyMessages = new List<FriendlyMessage>();

            Cookies = new LoginInfo();

            Grid_Detail.Pager.DivObject = "divProductWarehousePager";

            Grid_Detail.Pager.CallBackMethod = "Get_ProductWarehouse";
        }

        ProductWarehouseInfo product_warehouse { get; set; }

        List<ProductWarehouseInfo> List_product_warehouse { get; set; }

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

        public Filter_Warehouse Filter
        {
            get;
            set;
        }

        public List<FriendlyMessage> FriendlyMessages
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

    public class Filter_Warehouse
    {
        public string Product_SKU
        {
            get;
            set;
        }
    }

}