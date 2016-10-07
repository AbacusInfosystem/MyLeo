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

        // Branch Info End


        //Hidden Field

        public string Mobile1 { get; set; }

        public DateTime Invoice_Date1 { get; set; }

       //End Hidden Field


       public string Sales_Invoice_No { get; set; }

       public int Branch_Id { get; set; }

       public string Branch_IDS { get; set; }

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

       public decimal Amount { get; set; }

       public string SalesMan { get; set; }

       public int SalesMan_Id { get; set; }

       public bool Flag { get; set; }

       public bool CreateCustomerFlag { get; set; }

       //End Sales Order Item


       // Receivable List //

       public int Receivable_Id { get; set; }

       //public int Sales_Invoice_Id { get; set; }

       public int Payment_Status { get; set; }

       public decimal Balance_Amount { get; set; }

       public DateTime Payament_Date { get; set; }

       //END

       //Receivable Item Table

       public int Receivable_Item_Id { get; set; }

       public int Payment_Mode { get; set; }

       public decimal Paid_Amount { get; set; }

       public decimal Cash_Amount { get; set; }

       public decimal Cheque_Amount { get; set; }

       public DateTime Cheque_Date { get; set; }

       public string Cheque_No { get; set; }

       public string Bank_Name { get; set; }

       public int Sales_Credit_Note_Id { get; set; }

       public decimal Card_Amount { get; set; }

       public string Credit_Card_No { get; set; }

       public string Debit_Card_No { get; set; }

       public int Gift_Voucher_Id { get; set; }

       //END

       public decimal Credit_Note_Amount { get; set; }

       public string Credit_Note_No { get; set; }

       public DateTime Credit_Note_Date { get; set; }

       public decimal Gift_Voucher_Amount { get; set; }

       public string Gift_Voucher_No { get; set; }

       //END Receivable List //


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

        public decimal Amount { get; set; }

        public string SalesMan { get; set; }

        public int SalesMan_Id { get; set; }

        public DateTime Created_Date { get; set; }

        public int Created_By { get; set; }

        public DateTime Updated_Date { get; set; }

        public int Updated_By { get; set; }
    }

    public class Receivable
    {

        //Recievable Main Table

        public int Receivable_Id { get; set; }

        public int Sales_Invoice_Id { get; set; }

        public int Payment_Status { get; set; }

        public decimal Balance_Amount { get; set; }

        public DateTime Payament_Date { get; set; }

        //END

        //Receivable Item Table

        public int Receivable_Item_Id { get; set; }

        public int Payment_Mode { get; set; }

        public decimal Paid_Amount { get; set; }

        public decimal Cash_Amount { get; set; }

        public decimal Cheque_Amount { get; set; }

        public DateTime Cheque_Date { get; set; }

        public string Cheque_No { get; set; }

        public string Bank_Name { get; set; }

        public int Sales_Credit_Note_Id { get; set; }

        public decimal Card_Amount { get; set; }

        public string Credit_Card_No { get; set;}

        public string Debit_Card_No { get; set; }

        public int Gift_Voucher_Id { get; set; }

        //END

        public decimal Credit_Note_Amount { get; set; }

        public string Credit_Note_No { get; set; }

        public DateTime Credit_Note_Date { get; set; }

        public decimal Gift_Voucher_Amount { get; set; }

        public string Gift_Voucher_No { get; set; }

        public DateTime Created_On { get; set; }

        public int Created_By { get; set; }

        public DateTime Updated_On { get; set; }

        public int Updated_By { get; set; }

        //public int Receivable_Status { get; set; }

        //public decimal Total_MRP_Amount { get; set; }

        public string Payment_Status_Value { get; set; }

    }

    public class CreditNote
    {
        public int Credit_Note_Id { get; set; }

        public string Credit_Note_No { get; set; }

        public decimal Credit_Note_Amount { get; set; }

        public DateTime Credit_Note_Date { get; set; }
    }

}
