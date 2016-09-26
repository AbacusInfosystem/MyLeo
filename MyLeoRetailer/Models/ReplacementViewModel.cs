using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Branch;
using MyLeoRetailerInfo.Brand;
using MyLeoRetailerInfo.Category;
using MyLeoRetailerInfo.Color;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerInfo.PurchaseInvoice;
using MyLeoRetailerInfo.PurchaseOrder;
using MyLeoRetailerInfo.Replacement;
using MyLeoRetailerInfo.Size;
using MyLeoRetailerInfo.Vendor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLeoRetailer.Models
{
    public class ReplacementViewModel
    {
        public ReplacementViewModel()
        {
            PurchaseInvoice = new PurchaseInvoiceInfo();

            PurchaseInvoices = new List<PurchaseInvoiceInfo>();

            Sizes = new List<Sizes>();

            Replacement = new ReplacementInfo();

            Replacements = new List<ReplacementInfo>();

            Branches = new List<BranchInfo>();

            Vendors = new List<VendorInfo>();

            Agents = new List<VendorInfo>();

            Transporters = new List<VendorInfo>();


            Colors = new List<ColorInfo>();

            Brands = new List<BrandInfo>();

            Categories = new List<CategoryInfo>();

            SubCategories = new List<SubCategoryInfo>();

            SizeGroups = new List<SizeGroupInfo>();

            SizeGroup = new SizeGroupInfo();

            FriendlyMessages = new List<FriendlyMessage>();


            Grid_Detail = new GridInfo();

            Query_Detail = new QueryInfo();

            Filter = new Filter_Replacemant();

            Cookies = new LoginInfo();

            Grid_Detail.Pager.DivObject = "divReplacementPager";

            Grid_Detail.Pager.CallBackMethod = "Get_Replacement";


        }

        public List<FriendlyMessage> FriendlyMessages{ get;set;}

        public ReplacementInfo Replacement { get; set; }

        public List<ReplacementInfo> Replacements { get; set; }

        public PurchaseInvoiceInfo PurchaseInvoice{ get;   set; }

        public List<PurchaseInvoiceInfo> PurchaseInvoices { get; set; }

        public List<Sizes> Sizes { get; set; }

        public List<BranchInfo> Branches { get; set; }

        public List<VendorInfo> Vendors { get; set; }

        public List<VendorInfo> Agents { get; set; }

        public List<VendorInfo> Transporters { get; set; }

        public List<ColorInfo> Colors { get; set; }

        public List<BrandInfo> Brands { get; set; }

        public List<CategoryInfo> Categories { get; set; }

        public List<SubCategoryInfo> SubCategories { get; set; }

        public List<SizeGroupInfo> SizeGroups { get; set; }

        public SizeGroupInfo SizeGroup { get; set; }


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

        public Filter_Replacemant Filter
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

    public class Filter_Replacemant
    {
        public string Replacement_No
        {
            get;
            set;
        }
    }
}