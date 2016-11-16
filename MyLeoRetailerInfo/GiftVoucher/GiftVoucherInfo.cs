using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerInfo.GiftVoucher
{
   public class GiftVoucherInfo
    {
       public GiftVoucherInfo()
       {

       }

       public int Gift_Voucher_Id
       {
           get;
           set;
       }

       public string Gift_Voucher_No
       {
           get;
           set;
       }

       public string Person_Name
       {
           get;
           set;
       }

       public DateTime Gift_Voucher_Date
       {
           get;
           set;
       }

       public DateTime Gift_Voucher_Expiry_Date
       {
           get;
           set;
       }

       public decimal Gift_Voucher_Amount
       {
           get;
           set;
       }

       public int Status
       {
           get;
           set;
       }

       public int Payment_Mode
       {
           get;
           set;
       }

       public string Bank_Name
       {
           get;
           set;

       }

       public string Credit_Card_No
       {
           get;
           set;
       }

       public DateTime Created_Date
       {
           get;
           set;
       }

       public int Created_By
       {
           get;
           set;
       }

       public DateTime Updated_Date
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
