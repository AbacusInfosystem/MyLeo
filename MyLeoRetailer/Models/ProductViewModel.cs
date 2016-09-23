using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyLeoRetailer.Models.Common;
using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Product;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerInfo.Interface;
using MyLeoRetailerInfo.Size;
using MyLeoRetailerInfo.Category;
using MyLeoRetailerInfo.Brand;
using MyLeoRetailerInfo.Color;

namespace MyLeoRetailer.Models
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            Grid_Detail = new GridInfo();

            Query_Detail = new QueryInfo();

            Product = new ProductInfo();

            ProductImage = new ProductImagesInfo();

            ProductImages = new List<ProductImagesInfo>();

            //ProductColors = new List<ProductColorInfo>(); 

            ProductMRP = new ProductMRPInfo();

            ProductMRPs = new List<ProductMRPInfo>();

            //Vendors = new List<VendorInfo>();
            SizeGroups = new List<SizeGroupInfo>();
            Categories = new List<CategoryInfo>();
            SubCategories = new List<SubCategoryInfo>();
            Brands = new List<BrandInfo>();

            Color = new ColorInfo();
            Colours = new List<int>();
            Colors = new List<ColorInfo>();

            Filter = new Filter_Product(); 

            FriendlyMessages = new List<FriendlyMessage>();

            Grid_Detail.Pager.DivObject = "divProductPager";

            Grid_Detail.Pager.CallBackMethod = "Get_Products";
        }

        //public List<VendorInfo> Vendors { get; set; }
        public List<SizeGroupInfo> SizeGroups { get; set; }
        public List<CategoryInfo> Categories { get; set; }
        public List<SubCategoryInfo> SubCategories { get; set; }
        public List<BrandInfo> Brands { get; set; }
        public List<ColorInfo> Colors { get; set; }
        public List<int> Colours { get; set; }
        public ColorInfo Color { get; set; }

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

        public ProductInfo Product
        {
            get;
            set;
        }

        public Filter_Product Filter
        {
            get;
            set;
        }

        public List<ProductImagesInfo> ProductImages
        {
            get;
            set;
        }

        public ProductImagesInfo ProductImage
        {
            get;
            set;
        }

        public List<ProductMRPInfo> ProductMRPs
        {
            get;
            set;
        }

        public ProductMRPInfo ProductMRP
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

    public class Filter_Product
    {
        public string Article_No
        {
            get;
            set;
        }

        public string Product_Id
        {
            get;
            set;
        }

        public string Color
        {
            get;
            set;
        }
    }
}