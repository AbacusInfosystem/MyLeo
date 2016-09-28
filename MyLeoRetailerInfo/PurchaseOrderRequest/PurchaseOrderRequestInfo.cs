using MyLeoRetailerInfo.Branch;
using MyLeoRetailerInfo.Brand;
using MyLeoRetailerInfo.Category;
using MyLeoRetailerInfo.Color;
using MyLeoRetailerInfo.Size;
using MyLeoRetailerInfo.Vendor;
using MyLeoRetailerInfo.VendorContact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerInfo.PurchaseOrderRequest
{
    public class PurchaseOrderRequestInfo
    {
        public PurchaseOrderRequestInfo()
		{
            PurchaseOrderRequests = new List<PurchaseOrderRequestInfo>();

            Sizes = new List<Sizes>();


            Vendors = new List<VendorInfo>();

            //Branches = new List<BranchInfo>();            

            //Agents = new List<VendorInfo>();

            //Transporters = new List<VendorInfo>();


            Colors = new List<ColorInfo>();

            Brands = new List<BrandInfo>();

            Categories = new List<CategoryInfo>();

            SubCategories = new List<SubCategoryInfo>();

            SizeGroups = new List<SizeGroupInfo>();

            SizeGroup = new SizeGroupInfo();

		}

        public List<PurchaseOrderRequestInfo> PurchaseOrderRequests { get; set; }

        public List<Sizes> Sizes { get; set; }
                
        public List<VendorInfo> Vendors { get; set; }

        //public List<BranchInfo> Branches { get; set; }

        //public List<VendorInfo> Agents { get; set; }

        //public List<VendorInfo> Transporters { get; set; }


        public List<ColorInfo> Colors { get; set; }

        public List<BrandInfo> Brands { get; set; }

        public List<CategoryInfo> Categories { get; set; }

        public List<SubCategoryInfo> SubCategories { get; set; }

        public List<SizeGroupInfo> SizeGroups { get; set; }

        public SizeGroupInfo SizeGroup { get; set; }

              
		public int Purchase_Order_Request_Id { get; set; }

        public int Vendor_Id { get; set; }

        public string Vendor_Name { get; set; }

        public int Branch_Id { get; set; }

        public string Branch_Name { get; set; }

        public int Status { get; set; }

        public string Status_Flag { get; set; }

        public int Total_Quantity { get; set; }

        public decimal Net_Amount { get; set; }


        public DateTime Created_Date { get; set; }

        public int Created_By { get; set; }

        public DateTime Updated_Date { get; set; }

        public int Updated_By { get; set; }


        public int Purchase_Order_Request_Item_Id { get; set; }

        public string Article_No { get; set; }

        public int Colour_Id { get; set; }

        public string Colour_Name { get; set; }

        public int Brand_Id { get; set; }

        public int Category_Id { get; set; }

        public int Sub_Category_Id { get; set; }

        public int Size_Group_Id { get; set; }

        public string Start_Size { get; set; }

        public string End_Size { get; set; }

        public string Center_Size { get; set; }

        public decimal Purchase_Price { get; set; }

        public decimal Size_Difference { get; set; }

        public decimal Total_Amount { get; set; }

        public int Item_Quantity { get; set; }

        public string Comment { get; set; }


        public int Size_Id { get; set; }

        public int Quantity { get; set; }
        
    }

    public class Sizes
    {
        public int Size_Id1 { get; set; }

        public int Quantity1 { get; set; }

        public decimal Amount1 { get; set; }

        public int Size_Id2 { get; set; }

        public int Quantity2 { get; set; }

        public decimal Amount2 { get; set; }

        public int Size_Id3 { get; set; }
        
        public int Quantity3 { get; set; }

        public decimal Amount3 { get; set; }

        public int Size_Id4 { get; set; }

        public int Quantity4 { get; set; }

        public decimal Amount4 { get; set; }

        public int Size_Id5 { get; set; }

        public int Quantity5 { get; set; }

        public decimal Amount5 { get; set; }

        public int Size_Id6 { get; set; }

        public int Quantity6 { get; set; }

        public decimal Amount6 { get; set; }

        public int Size_Id7 { get; set; }

        public int Quantity7 { get; set; }

        public decimal Amount7 { get; set; }

        public int Size_Id8 { get; set; }

        public int Quantity8 { get; set; }

        public decimal Amount8 { get; set; }

        public int Size_Id9 { get; set; }

        public int Quantity9 { get; set; }

        public decimal Amount9 { get; set; }

        public int Size_Id10 { get; set; }

        public int Quantity10 { get; set; }

        public decimal Amount10 { get; set; }

        public int Size_Id11 { get; set; }

        public int Quantity11 { get; set; }

        public decimal Amount11 { get; set; }

        public int Size_Id12 { get; set; }

        public int Quantity12 { get; set; }

        public decimal Amount12 { get; set; }

        public int Size_Id13 { get; set; }

        public int Quantity13 { get; set; }

        public decimal Amount13 { get; set; }

        public int Size_Id14 { get; set; }

        public int Quantity14 { get; set; }

        public decimal Amount14 { get; set; }

        public int Size_Id15 { get; set; }

        public int Quantity15 { get; set; }

        public decimal Amount15 { get; set; }

    }

}
