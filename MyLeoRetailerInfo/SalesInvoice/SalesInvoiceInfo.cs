using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerInfo.SalesInvoice
{
   public class SalesInvoiceInfo
    {
       public SalesInvoiceInfo()
        {
            //SaleOrderItemList = new List<SaleOrderItems>();      
        }

       public int Sales_Invoice_Id { get; set; }

       public DateTime Invoice_Date { get; set; }

       public int Customer_Id { get; set; }

       //START

       public string Mobile { get; set; }

        public string Customer_Name { get; set; }

       //END

       //Branch Info

        public string Branch_Name { get; set; }

        public string Branch_Address { get; set; }

        public string Branch_City { get; set; }

        public string Branch_State { get; set; }

        public string Branch_Country { get; set; }

        public int Branch_Pincode { get; set; }

        public string Branch_Landline1 { get; set; }

        public string Branch_Landline2 { get; set; }

        public string Employee_Name { get; set; }


       //End

       public string Sales_Invoice_No { get; set; }

       public int Branch_Id { get; set; }

       public int Total_Quantity { get; set; }

       public decimal Total_MRP_Amount { get; set; }

       public decimal Total_Discount_Amount { get; set; }

       public decimal Gross_Amount { get; set; }

       public decimal Tax_Percentage { get; set; }

       public decimal Tax_Amount { get; set; }

       public decimal Round_Off_Amount { get; set; }

       public decimal Net_Amount { get; set; }


       //Start Sales Order Item

       public string Barcode { get; set; }

       public string SKU_Code { get; set; }

       public string Article_No { get; set; }

       public int Brand_Id { get; set; }

       public string Brand { get; set; }

       public int Category_Id { get; set; }

       public string Category { get; set; }

       public int SubCategory_Id { get; set; }

       public string SubCategory { get; set; }

       public int Size_Id { get; set; }

       public string Size_Name { get; set; }

       public int Colour_Id { get; set; }

       public string Colour_Name { get; set; }

       public decimal MRP_Price { get; set; }

       public int Quantity { get; set; }

       public decimal Discount_Percentage { get; set; }

       public decimal Discount_Amount { get; set; }

       public int Amount { get; set; }

       public string SalesMan { get; set; }

       public int SalesMan_Id { get; set; }

       public bool Flag { get; set; }


       //End


       public DateTime Created_Date { get; set; }

       public int Created_By { get; set; }

       public DateTime Updated_Date { get; set; }

       public int Updated_By { get; set; }


       //public List<SaleOrderItems> SaleOrderItemList { get; set; }

    }


    public class SaleOrderItems
    {
        public string Barcode { get; set; }

        public int Sales_Invoice_Id { get; set; }

        public string SKU_Code { get; set; }

        public string Article_No { get; set; }

        public int Brand_Id { get; set; }

        public string Brand { get; set; }

        public int Category_Id { get; set; }

        public string Category { get; set; }

        public decimal Total_MRP_Amount { get; set; }

        public int SubCategory_Id { get; set; }

        public string SubCategory { get; set; }

        public int Size_Id { get; set; }

        public string Size_Name { get; set; }

        public int Colour_Id { get; set; }

        public string Colour_Name { get; set; }

        public decimal MRP_Price { get; set; }

        public int Quantity { get; set; }

        public decimal Discount_Percentage { get; set; }

        public decimal Discount_Amount { get; set; }

        public int Amount { get; set; }

        public string SalesMan { get; set; }

        public int SalesMan_Id { get; set; }

        public DateTime Created_Date { get; set; }

        public int Created_By { get; set; }

        public DateTime Updated_Date { get; set; }

        public int Updated_By { get; set; }
    }
}
