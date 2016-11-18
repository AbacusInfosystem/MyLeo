using MyLeoRetailerInfo.PurchaseOrder;
using MyLeoRetailerInfo.Vendor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerInfo.PurchaseInvoice
{
    public class PurchaseInvoiceInfo
    {
       public PurchaseInvoiceInfo()
        {
            PurchaseInvoices = new List<PurchaseInvoiceInfo>();

            Vendors = new List<VendorInfo>();

            PurchaseOrders = new List<PurchaseOrderInfo>();

            Transporters = new List<VendorInfo>();
        }

        public List<PurchaseInvoiceInfo> PurchaseInvoices { get; set; }

        public List<VendorInfo> Vendors { get; set; }

        public List<PurchaseOrderInfo> PurchaseOrders { get; set; }

        public List<VendorInfo> Transporters { get; set; }


        public int Purchase_Invoice_Id { get; set; }

        public string Purchase_Invoice_No { get; set; }

        public int Vendor_Id { get; set; }

        public string Vendor_Name { get; set; }

        public string Vendor_Address { get; set; }

        public string Vendor_Vat_No { get; set; }

        public int Payament_Status { get; set; }

        public int Against_Form { get; set; }

        public string Against_Form_No { get; set; }

        public string Purchase_Packing_No { get; set; }

        public string Challan_No { get; set; }

        public DateTime Purchase_Invoice_Date { get; set; }

        public DateTime Against_Form_Date { get; set; }

        public DateTime Purchase_Packing_Date { get; set; }

        public DateTime Challan_Date { get; set; }

        public int Total_Quantity { get; set; }

        public decimal Total_Amount { get; set; }

        public decimal Discount_Percentage { get; set; }

        public decimal Discount_Amount { get; set; }

        public decimal Gross_Amount { get; set; }

        public decimal Tax_Percentage { get; set; }

        public decimal hdn_Tax_Percentage { get; set; }

        public decimal Round_Off_Amount { get; set; }

        public decimal Net_Amount { get; set; }

        public DateTime Payment_Due_Date { get; set; }

        public decimal Discount_Percentage_Before_Due_Date { get; set; }

        public int Transporter_Id { get; set; }

        public string Transporter_Name { get; set; }

        public string Lr_No { get; set; }

        public DateTime Lr_Date { get; set; }


        public DateTime Created_Date { get; set; }

        public int Created_By { get; set; }

        public DateTime Updated_Date { get; set; }

        public int Updated_By { get; set; }

        public string Barcode { get; set; }
               
        public int Purchase_Invoice_Item_Id { get; set; }

        public int Purchase_Order_Id { get; set; }

        public string Purchase_Order_No { get; set; }

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

    }

    public class Filter_Purchase_Invoice
    {
        public string Purchase_Invoice_No
        {
            get;
            set;
        }

        public int Purchase_Invoice_Id
        {
            get;
            set;
        }
    }
}
