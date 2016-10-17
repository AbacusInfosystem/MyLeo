using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerInfo.Payable
{
   public class PayableInfo
    {
       public PayableInfo()
       {
           PurchaseInvoice_Details = new List<PurchaseInvoice_Details>();

           PurchaseInvoice_Detail = new PurchaseInvoice_Details();
       }



       public int Payable_Id
       {
           get;
           set;
       }

       public int Purchase_Invoice_Id
       {
           get;
           set;
       }

       public string Vendor_Name
       {
           get;
           set;
       }

       public int Purchase_Credit_Note_Id
       {
           get;
           set;
       }

       public string Credit_Note_No
       {
           get;
           set;
       }

       public decimal Credit_Note_Amount
       {
           get;
           set;
       }
      
       public int Payble_Status
       {
           get;
           set;
       }

       public decimal Balance_Amount
       {
           get;
           set;
       }

       public int Payable_Item_Id
       {
           get;
           set;
       }

       public int Payment_Mode
       {
           get;
           set;
       }

       public string Payment_Mode1
       {
           get;
           set;
       }

       public int Payament_Status
       {
           get;
           set;
       }

       public decimal Paid_Amount
       {
           get;
           set;
       }

       public DateTime Cheque_Date
       {
           get;
           set;
       }

       public string Cheque_No
       {
           get;
           set;
       }

       public string Bank_Name
       {
           get;
           set;
       }

       public decimal Total_Amount
       {
           get;
           set;
       }

       public string Credit_Card_No
       {
           get;
           set;
       }

       public string Remark
       {
           get;
           set;
       }

       public int Employee_Id
       {
           get;
           set;
       }

       public string Employee
       {
           get;
           set;
       }

       public decimal Final_Amount
       {
           get;
           set;
       }

       public string Debit_Card_No
       {
           get;
           set;
       }

       public int Gift_Voucher_No
       {
           get;
           set;
       }

       public decimal Discount_Percentage
       {
           get;
           set;
       }

       public decimal Discount_Amount
       {
           get;
           set;
       }

       public DateTime Payament_Date
       {
           get;
           set;
       }

       public DateTime From_Date
       {
           get;
           set;
       }

       public DateTime To_Date
       {
           get;
           set;
       }

       public DateTime Created_On
       {
           get;
           set;
       }

       public int Created_By
       {
           get;
           set;
       }

       public DateTime Updated_On
       {
           get;
           set;
       }

       public int Updated_By
       {
           get;
           set;
       }

         public string Payment_Status_Value
       {
           get;
           set;
       }


       public List<PurchaseInvoice_Details> PurchaseInvoice_Details { get; set; }

       public PurchaseInvoice_Details PurchaseInvoice_Detail { get; set; }

      
    }

    public class PurchaseInvoice_Details

    {
        public int Purchase_Credit_Note_Id
        {
            get;
            set;
        }

        public int Purchase_Invoice_Id
        {
            get;
            set;
        }

        public int Payable_Id
        {
            get;
            set;
        }

        public int Payble_Status
        {
            get;
            set;
        }

        public decimal Total_Amount
        {
            get;
            set;
        }

        public string Vendor_Name
        {
            get;
            set;
        }

        public string Purchase_Invoice_No
        {
            get;
            set;
        }

        public DateTime Purchase_Invoice_Date
        {
            get;
            set;
        }

        public decimal Paid_Amount
        {
            get;
            set;
        }

        public decimal Balance_Amount
        {
            get;
            set;
        }

        public string Credit_Note_No
        {
            get;
            set;
        }

        public DateTime Credit_Note_Date
        {
            get;
            set;
        }

        public decimal Discount_Amount
        {
            get;
            set;
        }

        public DateTime Payament_Date
        {
            get;
            set;
        }

        public int Payament_Status
        {
            get;
            set;
        }

        public string Payment_Status_Value
        {
            get;
            set;
        }

        public DateTime From_Date
        {
            get;
            set;
        }

        public DateTime To_Date
        {
            get;
            set;
        }

        public decimal Credit_Note_Amount
        {
            get;
            set;
        }
       
    }
}
