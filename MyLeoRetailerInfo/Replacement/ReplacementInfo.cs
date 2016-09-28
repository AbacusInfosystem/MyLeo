using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerInfo.Replacement
{
    public class ReplacementInfo
    {
        public ReplacementInfo()
        {


        }

        public int Replacement_Id { get; set; }

        public string Replacement_No { get; set; }

        public DateTime Replacement_Date { get; set; }

        public int Vendor_Id { get; set; }
       
        public string Vendor_Name { get; set; }

        public string Persone_Name { get; set; }

        public string Barcode_No { get; set; }

        public int Purchase_Invoice_Id { get; set; }

        public int Purchase_Order_Id { get; set; }

        public string Purchase_Invoice_No { get; set; }

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

        public string Lr_No { get; set; }

        public string Transpoter_Name { get; set; }

        public DateTime Payment_Due_Date { get; set; }

        #region createdBy, UpdateBy

        public DateTime Created_Date { get; set; }

        public int Created_By { get; set; }

        public DateTime Updated_Date { get; set; }

        public int Updated_By { get; set; }

        #endregion



    }
}
