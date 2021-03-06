﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerInfo.SalesReturn
{
    public class SalesReturnInfo
    {

        public SalesReturnInfo()
        {
            
        }

        public int Sales_Return_Id { get; set; }

        public DateTime Sales_Return_Date { get; set; }

        public int Customer_Id { get; set; }

        //START

        public string Mobile { get; set; }

        public string Customer_Name { get; set; }

        //END


        //HIDDEN FIELD

        public string Mobile1 { get; set; }

        public int Quantity1 { get; set; }

        //END

        public string Sales_Return_No { get; set; }

        //public int Sales_Invoice_Id { get; set; }

        //public int Company_Branch_Id { get; set; }

        public string Branch_Name { get; set; }

        public int Branch_Id { get; set; }

        //Credit Note Fields

        public int Sales_Credit_Note_Id { get; set; }

        public string Credit_Note_No { get; set; }

        public int Credit_Note_Type { get; set; }


        //END

        public int Total_Quantity { get; set; }

        public decimal Gross_Amount { get; set; }

        public decimal Total_Amount_Return_By_Cash { get; set; }

        public decimal Total_Amount_Return_By_Credit_Note { get; set; }

        

        //Start Sales Return Item

        public string Barcode { get; set; }

        public string Sales_Invoice_No { get; set; }

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

        public int Quantity { get; set; }

        public decimal MRP_Price { get; set; }

        public decimal Discount_Percentage { get; set; }

        public decimal Amount { get; set; }

        public decimal Total_Amount { get; set; }

        public string Return_Reason { get; set; }

        public bool CreateCustomerFlag { get; set; }

        //End

        public DateTime Created_Date { get; set; }

        public int Created_By { get; set; }

        public DateTime Updated_Date { get; set; }

        public int Updated_By { get; set; }

    }

    public class SaleReturnItems
    {
        public string Barcode { get; set; }

        public int Sales_Invoice_Id { get; set; }

        public string Sales_Invoice_No { get; set; }

        public int Sales_Return_Id { get; set; }

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

        public decimal Amount { get; set; }

        public string Return_Reason { get; set; }


        public DateTime Created_Date { get; set; }

        public int Created_By { get; set; }

        public DateTime Updated_Date { get; set; }

        public int Updated_By { get; set; }
    }

}
