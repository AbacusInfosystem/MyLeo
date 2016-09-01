using MyLeoRetailer.Models.Common;
using MyLeoRetailerInfo;
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

namespace MyLeoRetailer.Models
{
    public class VendorViewModel
    {

        public VendorViewModel()
        {
            Vendor = new VendorInfo();

            Vendors = new List<VendorInfo>();   
  
            Friendly_Message = new List<FriendlyMessage>();   
   
            Filter = new VendorFilter();

            Categories = new List<CategoryInfo>();

            Brands = new List<BrandInfo>();

            SubCategorys = new List<SubCategoryInfo>();

            VATS = new List<TaxInfo>();

            CSTS = new List<TaxInfo>();

            Grid_Detail = new GridInfo();

            Query_Detail = new QueryInfo();

            Grid_Detail.Pager.DivObject = "divVendorPager";

            Grid_Detail.Pager.CallBackMethod = "Get_Vendors";

        }

        public VendorInfo Vendor { get; set; }

        public List<VendorInfo> Vendors { get; set; }
        
        public List<FriendlyMessage> Friendly_Message { get; set; }
        
        public VendorFilter Filter { get; set; }

        public List<TaxInfo> VATS { get; set; }

        public List<TaxInfo> CSTS { get; set; }

        public List<CategoryInfo> Categories { get; set; }

        public List<BrandInfo> Brands { get; set; }

        public List<SubCategoryInfo> SubCategorys { get; set; }

        public GridInfo Grid_Detail { get; set; }

        public QueryInfo Query_Detail { get; set; }
           
    }

    public class VendorFilter
    {
        public int Vendor_Id { get; set; }

        public string Vendor_Name { get; set; }

        public bool Is_Active { get; set; }
    }


}