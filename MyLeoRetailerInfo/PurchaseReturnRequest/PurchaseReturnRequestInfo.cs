﻿using MyLeoRetailerInfo.PurchaseInvoice;
using MyLeoRetailerInfo.Vendor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerInfo.PurchaseReturnRequest
{
    public class PurchaseReturnRequestInfo
    {
        public PurchaseReturnRequestInfo()
        {
            PurchaseReturnRequestItem = new PurchaseReturnRequestItemInfo();

            PurchaseReturnRequestItems = new List<PurchaseReturnRequestItemInfo>();

            Vendors = new List<VendorInfo>();

            Vendor = new VendorInfo();

            PurchaseInvoices = new List<PurchaseInvoiceInfo>();

        }

        public int Purchase_Return_Request_Id { get; set; }

        public int Purchase_Invoice_Id { get; set; }

        public string Purchase_Invoice_No { get; set; }

        public int Vendor_Id { get; set; }

        public string Vendor_Name { get; set; }

        public int Branch_Id { get; set; }

        public string Branch_Name { get; set; }

        public int Status { get; set; }

        public decimal Total_Quantity { get; set; }

        public decimal Total_Amount { get; set; }

        public decimal Discount_Percentage { get; set; }

        public decimal Discount_Amount { get; set; }

        public decimal Gross_Amount { get; set; }

        public decimal Tax_Percentage { get; set; }

        public decimal Round_Off_Amount { get; set; }

        public decimal Net_Amount { get; set; }

        public bool Is_Active { get; set; }

        public int Created_By { get; set; }

        public DateTime Created_Date { get; set; }

        public int Updated_By { get; set; }

        public DateTime Updated_Date { get; set; }

        public PurchaseReturnRequestItemInfo PurchaseReturnRequestItem { get; set; }

        public List<PurchaseReturnRequestItemInfo> PurchaseReturnRequestItems { get; set; }

        public List<VendorInfo> Vendors { get; set; }

        public VendorInfo Vendor { get; set; }

        public List<PurchaseInvoiceInfo> PurchaseInvoices { get; set; }


    }

    public class PurchaseReturnRequestItemInfo
    {
        public int Purchase_Return_Request_Item_Id { get; set; }

        public int Purchase_Return_Request_Id { get; set; }

        public string SKU_Code { get; set; }

        public int Size_Group_Id { get; set; }

        public string Size_Group_Name { get; set; }

        public int Size_Id { get; set; }

        public string Size_Name { get; set; }

        public int Quantity { get; set; }

        public decimal Total_Amount { get; set; }

        public decimal Amount { get; set; }

        public DateTime Created_Date { get; set; }

        public int Created_By { get; set; }

        public DateTime Updated_Date { get; set; }

        public int Updated_By { get; set; }

        public string Article_No { get; set; }

        public int Brand_Id { get; set; }

        public string Brand { get; set; }

        public int Color_Id { get; set; }

        public string Color { get; set; }

        public int Category_Id { get; set; }

        public string Category { get; set; }

        public int SubCategory_Id { get; set; }

        public string SubCategory { get; set; }

        public int WSR_Price { get; set; }

        public int Barcode { get; set; }

        public int Status { get; set; }



    }


    public class Request_Filter
    {
        public int Vendor_Id { get; set; }

        public int Purchase_Return_Request_Id { get; set; }
    }

}
