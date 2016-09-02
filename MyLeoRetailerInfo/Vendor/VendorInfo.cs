using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerInfo.Vendor
{
    public class VendorInfo
    {
        public int Vendor_Id { get; set; }

        public int Article_No { get; set; }

        public string Vendor_Name { get; set; }

        public int Vendor_Type { get; set; }

        public string Vendor_Address { get; set; }

        public string Vendor_City { get; set; }

        public string Vendor_State { get; set; }

        public string Vendor_Country { get; set; }

        public int Vendor_Pincode { get; set; }

        public string Vendor_Phone1 { get; set; }

        public string Vendor_Phone2 { get; set; }

        public string Vendor_Email1 { get; set; }

        public string Vendor_Email2 { get; set; }

        //public string Vendor_TIN_No { get; set; }

        public string Vendor_Product { get; set; }

        public int Vendor_PaymentTerms { get; set; }


        public string Vendor_Vat_Rate { get; set; }

        public string Vendor_Vat_No { get; set; }

        public DateTime Vendor_Vat_Effective_Date { get; set; }


        public string Vendor_CST_Rate { get; set; }

        public string Vendor_CST_No { get; set; }

        public DateTime Vendor_CST_Effective_Date { get; set; }



        public string Bank_Name { get; set; }

        public string Account_No { get; set; }

        public string Branch_Name { get; set; }

        public string Ifsc_Code { get; set; }


        public bool Is_Active { get; set; }



        public DateTime Created_Date { get; set; }

        public int Created_By { get; set; }

        public DateTime Updated_Date { get; set; }

        public int Updated_By { get; set; }
    

        public int Brand_Id { get; set; }

        public int Category_Id { get; set; }

        public int SubCategory_Id { get; set; }

        public string Brand_Name { get; set; }

        public string Category_Name { get; set; }

        public string SubCategory_Name { get; set; }

        public int Tax_Id { get; set; }

        public int Tax_Value { get; set; }


        public List<Bank_Details> BankDetailsList { get; set; }

        public List<Category_Details> CategoryDetailsList { get; set; }

        public List<Brand_Details> BrandDetailsList { get; set; }

        public List<SubCategory_Details> SubCategoryDetailsList { get; set; }
     

        public VendorInfo()
        {
            BankDetailsList = new List<Bank_Details>();

            CategoryDetailsList = new List<Category_Details>();

            BrandDetailsList = new List<Brand_Details>();

            SubCategoryDetailsList = new List<SubCategory_Details>();
        }

    }

    public class Category_Details
    {
        public int Category_Detail_Id { get; set; }

        public string Category { get; set; }
    }


    public class Brand_Details
    {
        public int Brand_Detail_Id { get; set; }

        public string Brand { get; set; }
    }


    public class SubCategory_Details
    {
        public int SubCategory_Id { get; set; }

        public string SubCategory { get; set; }
    }


    public class Bank_Details
    {
        public int Vendor_Bank_Detail_Id { get; set; }

        public string Bank_Name { get; set; }

        public string Account_No { get; set; }

        public string Branch_Name { get; set; }

        public string Ifsc_Code { get; set; }

        public bool Status { get; set; }
    }


}

