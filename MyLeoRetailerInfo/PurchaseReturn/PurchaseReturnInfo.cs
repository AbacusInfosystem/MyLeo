using MyLeoRetailerInfo.PurchaseInvoice;
using MyLeoRetailerInfo.PurchaseOrder;
using MyLeoRetailerInfo.Vendor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerInfo.PurchaseReturn
{
    public class PurchaseReturnInfo
    {
        public PurchaseReturnInfo()
        {
            PurchaseReturns = new List<PurchaseReturnInfo>();

            Vendors = new List<VendorInfo>();

            PurchaseInvoices = new List<PurchaseInvoiceInfo>();

            Transporters = new List<VendorInfo>();
        }

        public List<PurchaseReturnInfo> PurchaseReturns { get; set; }

        public List<VendorInfo> Vendors { get; set; }

        public List<PurchaseInvoiceInfo> PurchaseInvoices { get; set; }

        public List<VendorInfo> Transporters { get; set; }

        public string Item_Ids { get; set; }

        public int Purchase_Return_Id { get; set; }

        public string Debit_Note_No { get; set; }

        public string GR_No { get; set; }

        public int Vendor_Id { get; set; }

        public string Vendor_Name { get; set; }

        public int Purchase_Invoice_Id { get; set; }

        public string Purchase_Invoice_No { get; set; }

        public DateTime Purchase_Return_Date { get; set; }

        public int Total_Quantity { get; set; }

        public decimal Total_Amount { get; set; }

        public decimal Discount_Percentage { get; set; }

        public decimal Discount_Amount { get; set; }

        public decimal Gross_Amount { get; set; }

        public decimal Tax_Percentage { get; set; }

        public decimal hdn_Tax_Percentage { get; set; }

        public decimal Round_Off_Amount { get; set; }

        public decimal Net_Amount { get; set; }

        public string Logistics_Person_Name { get; set; }

        public int Transporter_Id { get; set; }

        public string Transporter_Name { get; set; }

        public string Lr_No { get; set; }

        public DateTime Lr_Date { get; set; }


        public DateTime Created_Date { get; set; }

        public int Created_By { get; set; }

        public DateTime Updated_Date { get; set; }

        public int Updated_By { get; set; }


        public int Purchase_Return_Item_Id { get; set; }

        public int Purchase_Order_Id { get; set; }

        public string SKU_Code { get; set; }

        public string Article_No { get; set; }

        public int Color_Id { get; set; }

        public string Color { get; set; }

        public int Brand_Id { get; set; }

        public string Brand { get; set; }

        public int Category_Id { get; set; }

        public string Category { get; set; }

        public int SubCategory_Id { get; set; }

        public string SubCategory { get; set; }

        public int Size_Group_Id { get; set; }

        public string Size_Group_Name { get; set; }

        public int Size_Id { get; set; }

        public string Size_Name { get; set; }

        public int Quantity { get; set; }

        public decimal WSR_Price { get; set; }

        public decimal Amount { get; set; }



        public int Purchase_Credit_Note_Id { get; set; }

        public int Status { get; set; }

        public string Credit_Note_No { get; set; }

        public int Credit_Note_Type { get; set; }

        public decimal Credit_Note_Amount { get; set; }

        public bool Flag { get; set; }//Added by vinod mane on 29/09/2016

    }

    public class Filter_Purchase_Return
    {
        public string Debit_Note_No
        {
            get;
            set;
        }

        //Added by vinod mane on 29/09/2016
        public int Purchase_Return_Id
        {
            get;
            set;
        }

    }
}
