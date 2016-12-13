using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerInfo.Barcode
{
    public class BarcodeInfo
    {

        public BarcodeInfo()
        {
            Barcodes = new List<BarcodeInfo>();
            PrintBarcodes = new List<BarcodeInfo>();
        }

        public List<BarcodeInfo> Barcodes { get; set; }
        public List<BarcodeInfo> PrintBarcodes { get; set; }


        public int Product_SKU_Barcode_Id { get; set; }

        public string Product_SKU { get; set; }
        public string Color_Name { get; set; }//
        public string Brand_Name { get; set; }//
        public string Size_Name { get; set; }//
        public string WSR_Code { get; set; }
        public string MRP_Price { get; set; }


        public int SKU_Quantity { get; set; }

        public string SKU_Barcode { get; set; }

        public int Is_Barcode_Printed { get; set; }

        public byte[] Product_Barcode { get; set; }

        public string Barcode_Image_Url { get; set; }

        public int Product_Barcode_Counter { get; set; }

        public int Created_By { get; set; }

        public int Updated_By { get; set; }

        public DateTime Created_Date { get; set; }

        public DateTime Updated_Date { get; set; }

    }
}
