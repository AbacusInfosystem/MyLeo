using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerInfo.Product
{
    public class ProductInfo
    {
        public ProductInfo()
		{

		}

        public int Product_Id { get; set; }

        public int Vendor_Article_Mapping_Id { get; set; }

        public int Colour_Id { get; set; }

        public int Brand_Id { get; set; }

        public int Category_Id { get; set; }

        public int Sub_Category_Id { get; set; }

        public int Size_Group_Id { get; set; }

        public string Center_Size { get; set; }

        public decimal Purchase_Price { get; set; }

        public decimal Size_Difference { get; set; }

        public decimal MRP_Difference { get; set; }

        public int MRP_Percentage { get; set; }

        public decimal MRP_Price { get; set; }

        public DateTime Launch_Start_Date { get; set; }

        public DateTime Launch_End_Date { get; set; }

        public string Comment { get; set; }

        public DateTime Created_Date { get; set; }

        public int Created_By { get; set; }

        public DateTime Updated_Date { get; set; }

        public int Updated_By { get; set; }
    }

    public class ProductMRPInfo
    {
        public int Product_MRP_Id { get; set; }

        public int Product_Id { get; set; }

        public int Size_Id { get; set; }

        public decimal Purchase_Price { get; set; }

        public decimal MRP_Price { get; set; }

        public string SKU_Code { get; set; }

        public DateTime Created_Date { get; set; }

        public int Created_By { get; set; }

        public DateTime Updated_Date { get; set; }

        public int Updated_By { get; set; }

    }

    public class ProductImagesInfo
    {
        public int Product_Image_Id { get; set; }

        public int Product_Id { get; set; }

        public int Image_Id { get; set; }

        public bool Is_Primary { get; set; }

        public DateTime Created_Date { get; set; }

        public int Created_By { get; set; }

        public DateTime Updated_Date { get; set; }

        public int Updated_By { get; set; }

    }
}
