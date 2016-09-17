using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerInfo.Receivable
{
   public class ReceivableInfo
    {
       public ReceivableInfo()
       {

       }

       public int Receivable_Id
       {
           get;
           set;
       }

       public int Sales_Invoice_Id
       {
           get;
           set;
       }

       public string Sales_Invoice_No
       {
           get;
           set;
       }

       public string Customer_Mobile1
       {
           get;
           set;
       }

       public int Receivable_Status
       {
           get;
           set;
       }

       public decimal Balance_Amount
       {
           get;
           set;
       }

       public int Receivable_Item_Id
       {
           get;
           set;
       }

       public int Payment_Mode
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

       public DateTime Sales_Invoice_Date
       {
           get;
           set;
       }

       public DateTime Payament_Date
       {
           get;
           set;
       }

       public decimal Total_MRP_Amount
       {
           get;
           set;
       }

       public string Cheque_No
       {
           get;
           set;
       }

       public string Customer_Name
       {
           get;
           set;
       }

       public int Sales_Credit_Note_Id
       {
           get;
           set;
       }

       public string Bank_Name
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

       public string Credit_Card_No
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
    }
}
