using MyLeoRetailerRepo.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLeoRetailerInfo.Barcode;
using System.Data.SqlClient;
using MyLeoRetailerInfo.Common;
using System.Text.RegularExpressions;
using System.IO;
using System.Configuration;
using Barcode_Generator;

namespace MyLeoRetailerRepo
{
    public class BarcodeRepo
    {
        SQL_Repo sqlHelper = null;

        public BarcodeRepo()
        {
            sqlHelper = new SQL_Repo();
        }

        public List<BarcodeInfo> Get_Barcodes(BarcodeInfo Barcode)
        {
            List<BarcodeInfo> Barcodes = new List<BarcodeInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Product_SKU", Barcode.Product_SKU));

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_Get_Barcodes.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in dt.Rows)
            {
                BarcodeInfo barcode = new BarcodeInfo();

                if (dr["Product_SKU_Barcode_Id"] != DBNull.Value)
                    barcode.Product_SKU_Barcode_Id = Convert.ToInt32(dr["Product_SKU_Barcode_Id"]);

                if (dr["Product_SKU"] != DBNull.Value)
                    barcode.Product_SKU = Convert.ToString(dr["Product_SKU"]);

                if (dr["Product_SKU_Id"] != DBNull.Value)
                    barcode.Product_SKU_Id = Convert.ToString(dr["Product_SKU_Id"]);

                if (dr["Product_Barcode_Counter"] != DBNull.Value)
                    barcode.Product_Barcode_Counter = Convert.ToInt32(dr["Product_Barcode_Counter"]);

                if (dr["Is_Barcode_Printed"] != DBNull.Value)
                    barcode.Is_Barcode_Printed = Convert.ToInt32(dr["Is_Barcode_Printed"]);

                if (dr["Product_Barcode"] != DBNull.Value)
                {
                    barcode.Barcode_Image_Url = dr["Product_Barcode"] != null ? "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["Product_Barcode"]) : "";
                    barcode.Product_Barcode = (byte[])dr["Product_Barcode"];
                }

                Barcodes.Add(barcode);
            }

            return Barcodes;
        }

        public List<BarcodeInfo> Get_Print_Barcodes_Data(List<BarcodeInfo> BarCode)
        {
            List<BarcodeInfo> Barcodes = new List<BarcodeInfo>();

            foreach (var item in BarCode)
            {
                if (item.Is_Barcode_Printed == 1)
                {
                    List<SqlParameter> sqlParams = new List<SqlParameter>();

                    sqlParams.Add(new SqlParameter("@Product_SKU", item.Product_SKU));

                    DataTable dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_Get_Barcode_Data_Print_Details_By_SKU_Code.ToString(), CommandType.StoredProcedure);

                    foreach (DataRow dr in dt.Rows)
                    {
                        BarcodeInfo barcode2 = new BarcodeInfo();

                        if (dr["Product_SKU"] != DBNull.Value)
                            barcode2.Product_SKU = Convert.ToString(dr["Product_SKU"]);

                        if (dr["Colour_Name"] != DBNull.Value)
                            barcode2.Color_Name = Convert.ToString(dr["Colour_Name"]);

                        if (dr["Size_Name"] != DBNull.Value)
                            barcode2.Size_Name = Convert.ToString(dr["Size_Name"]);

                        if (dr["WSR_Code"] != DBNull.Value)
                            barcode2.WSR_Code = Convert.ToString(dr["WSR_Code"]);

                        if (dr["MRP_Price"] != DBNull.Value)
                            barcode2.MRP_Price = Convert.ToString(dr["MRP_Price"]);

                        if (dr["Brand_Name"] != DBNull.Value)
                            barcode2.Brand_Name = Convert.ToString(dr["Brand_Name"]);

                        barcode2.Barcode_Image_Url = item.Barcode_Image_Url;

                        barcode2.Product_Barcode = item.Product_Barcode;

                        //if (dr["Product_Barcode"] != DBNull.Value)
                        //{
                        //    barcode2.Barcode_Image_Url = dr["Product_Barcode"] != null ? "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["Product_Barcode"]) : "";
                        //    barcode2.Product_Barcode = (byte[])dr["Product_Barcode"];
                        //}
                        Barcodes.Add(barcode2);
                    }

                    Update_Barcode(item);
                }
            }
            return Barcodes;
        }

        public int Insert_Barcode(BarcodeInfo Barcode)
        {
            int counter = 0;

            for (int i = 1; i <= Barcode.SKU_Quantity; i++)
            {
                counter = Set_Max_Product_SKU_Barcode_Id();

                counter++;

                Barcode.Product_Barcode_Counter = counter;

                Barcode.Product_SKU_Barcode_Id = Convert.ToInt32(sqlHelper.ExecuteScalerObj(Set_Values_In_Barcode(Barcode), Storeprocedures.sp_Insert_Barcode.ToString(), CommandType.StoredProcedure));

            }

            return Barcode.Product_SKU_Barcode_Id;
        }

        public void Update_Barcode(BarcodeInfo Barcode)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@Product_SKU_Barcode_Id", Barcode.Product_SKU_Barcode_Id));

            sqlParam.Add(new SqlParameter("@Is_Barcode_Printed", Barcode.Is_Barcode_Printed));

            sqlParam.Add(new SqlParameter("@Updated_Date", Barcode.Updated_Date));

            sqlParam.Add(new SqlParameter("@Updated_By", Barcode.Updated_By));

            sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.sp_Update_Barcode.ToString(), CommandType.StoredProcedure);    
        }

        public List<SqlParameter> Set_Values_In_Barcode(BarcodeInfo barcode)
        {
            Barcode bar = new Barcode();

            if (!String.IsNullOrEmpty(barcode.Product_SKU))
            {
                barcode.Product_SKU_Id = Get_SKU_Id_By_SKU_Code(barcode.Product_SKU);

                string SKU_Id = barcode.Product_SKU_Id;

                //string SKU_Code = Regex.Replace(barcode.Product_SKU, @"[^0-9a-zA-Z]+", "$");

                SKU_Id += "+" + barcode.Product_Barcode_Counter;

                string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ProductImgPath"].ToString()), barcode.Product_SKU_Id + ".png");

                barcode.Product_Barcode = bar.Generate_Linear_Barcode(SKU_Id, path);

                barcode.Barcode_Image_Url = barcode.Product_Barcode != null ? "data:image/jpg;base64," + Convert.ToBase64String((byte[])barcode.Product_Barcode) : "";
            }

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Product_SKU", barcode.Product_SKU));

            sqlParams.Add(new SqlParameter("@Product_SKU_Id", barcode.Product_SKU_Id));

            sqlParams.Add(new SqlParameter("@Product_Barcode", barcode.Product_Barcode));

            sqlParams.Add(new SqlParameter("@Product_Barcode_Counter", barcode.Product_Barcode_Counter));

            sqlParams.Add(new SqlParameter("@Is_Barcode_Printed", barcode.Is_Barcode_Printed));

            sqlParams.Add(new SqlParameter("@Created_By", barcode.Created_By));

            sqlParams.Add(new SqlParameter("@Created_Date", barcode.Created_Date));

            sqlParams.Add(new SqlParameter("@Updated_By", barcode.Updated_By));

            sqlParams.Add(new SqlParameter("@Updated_Date", barcode.Updated_Date));

            return sqlParams;
        }

        public int Set_Max_Product_SKU_Barcode_Id()
        {
            int id = 0;

            DataTable dt = sqlHelper.ExecuteDataTable(null, Storeprocedures.sp_Get_Max_Product_SKU_Barcode_Id.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in dt.Rows)
            {
                if (!dr.IsNull("Product_SKU_Barcode_Id"))
                {
                    id = Convert.ToInt32(dr["Product_SKU_Barcode_Id"]);
                }
            }

            return id;
        }

        public string Get_SKU_Id_By_SKU_Code(string Product_SKU)
        {
            string sku_id = "";

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Product_SKU", Product_SKU));

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_Get_SKU_Id_By_SKU_Code.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in dt.Rows)
            {
                if (!dr.IsNull("SKU_Id"))
                {
                    sku_id = Convert.ToString(dr["SKU_Id"]);
                }
            }

            return sku_id;
        }
    }
}
