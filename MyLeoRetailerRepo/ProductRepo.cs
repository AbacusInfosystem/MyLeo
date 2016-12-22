using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerInfo.Product;
using MyLeoRetailerRepo.Utility;
using MyLeoRetailerInfo.Color;
using System.Reflection;
using Barcode_Generator;
using BarCode.Models;
using System.Configuration;
using System.IO;
using System.Web;
using System.Text.RegularExpressions;
using System.Transactions;
using System.Drawing;
using MyLeoRetailerInfo.Size;

namespace MyLeoRetailerRepo
{
    public class ProductRepo
    {
        SQL_Repo sqlHelper = null;
        //string folder_path = System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ProductImgPath"].ToString());
        //Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["ProductImgPath"].ToString()), Product_Image_Name);
        public ProductRepo()
        {
            sqlHelper = new SQL_Repo();
        }

        public DataTable Get_Products(QueryInfo query_Details)
        {
            //Barcode bar = new Barcode();
            //byte[] barcodeInBytes = bar.Generate_Linear_Lib_Barcode("ABCD", "E:/backup/27072016/SMS_Portal/Updated SMS/SMS/SMSPortal/UploadedFiles/ABCD22.png");
            //byte[] barcodeInBytes1 = bar.Generate_Linear_Barcode("ABACUSINFOSYSTEMNEW", "E:/backup/27072016/SMS_Portal/Updated SMS/SMS/SMSPortal/UploadedFiles/Myleo22.png");

            return sqlHelper.Get_Table_With_Where(query_Details);
        }

        #region--Insert--Update--Product-MRP--
        public void Insert_Product_MRP(List<ColorInfo> Colors)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (var item in Colors)
                {
                    foreach (var prodDesc in item.ProductDescription)
                    {
                        string ProductDescription = prodDesc.Description;
                        bool MRP_Status = prodDesc.Status;
                        foreach (var itm in prodDesc.ProductMRPs)
                        {
                            Set_Date_Session(itm);
                            if (itm.Product_MRP_Id == 0)
                            {
                                if (itm.Product_SKU_Map_Id == 0)
                                {
                                    itm.WSR_Code = Generate_WSR_Code(itm.Purchase_Price);

                                    int Product_SKU_Map_Id = Convert.ToInt32(sqlHelper.ExecuteScalerObj(Set_Values_In_Product_SKU(itm, ProductDescription), Storeprocedures.sp_Insert_Update_Product_SKU_Map.ToString(), CommandType.StoredProcedure));
                                    if (Product_SKU_Map_Id != 0)
                                    {
                                        sqlHelper.ExecuteNonQuery(Set_Product_MRP_Values(ProductDescription, MRP_Status, itm, Product_SKU_Map_Id), Storeprocedures.sp_Insert_Product_MRP.ToString(), CommandType.StoredProcedure);
                                    }
                                }
                                else
                                {
                                    sqlHelper.ExecuteNonQuery(Set_Product_MRP_Values(ProductDescription, MRP_Status, itm, itm.Product_SKU_Map_Id), Storeprocedures.sp_Insert_Product_MRP.ToString(), CommandType.StoredProcedure);
                                }
                            }
                            else
                            {
                                itm.WSR_Code = Generate_WSR_Code(itm.Purchase_Price);

                                sqlHelper.ExecuteNonQuery(Set_Values_In_Update_Product_MRP(itm, ProductDescription, MRP_Status), Storeprocedures.sp_Insert_Update_Product_MRP.ToString(), CommandType.StoredProcedure);
                            }
                        }
                    }
                }
                scope.Complete();
            }
        }

        private List<SqlParameter> Set_Product_MRP_Values(string ProductDescription, bool MRP_Status, ProductMRPInfo itm, int Product_SKU_Map_Id)
        {
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            sqlParamList.Add(new SqlParameter("@Product_SKU_Map_Id", Product_SKU_Map_Id));
            sqlParamList.Add(new SqlParameter("@MRP_Price", itm.MRP_Price));
            sqlParamList.Add(new SqlParameter("@ProductDescription", ProductDescription));
            sqlParamList.Add(new SqlParameter("@Status", MRP_Status));
            sqlParamList.Add(new SqlParameter("@Created_Date", itm.Created_Date));
            sqlParamList.Add(new SqlParameter("@Created_By", itm.Created_By));
            sqlParamList.Add(new SqlParameter("@Updated_Date", itm.Updated_Date));
            sqlParamList.Add(new SqlParameter("@Updated_By", itm.Updated_By));
            return sqlParamList;
        }

        private List<SqlParameter> Set_Values_In_Update_Product_MRP(ProductMRPInfo Productmrp, string ProductDescription, bool Mrp_Status)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Product_Id", Productmrp.Product_Id));
            sqlParams.Add(new SqlParameter("@Product_SKU_Map_Id", Productmrp.Product_SKU_Map_Id));
            sqlParams.Add(new SqlParameter("@Product_MRP_Id", Productmrp.Product_MRP_Id));
            sqlParams.Add(new SqlParameter("@Size_Id", Productmrp.Size_Id));
            sqlParams.Add(new SqlParameter("@Colour_Id", Productmrp.Colour_Id));
            sqlParams.Add(new SqlParameter("@Purchase_Price", Productmrp.Purchase_Price));
            sqlParams.Add(new SqlParameter("@Status", Mrp_Status));
            sqlParams.Add(new SqlParameter("@MRP_Price", Productmrp.MRP_Price));
            sqlParams.Add(new SqlParameter("@WSR_Code", Productmrp.WSR_Code));
            sqlParams.Add(new SqlParameter("@Vendor_Color_Code", Productmrp.Vendor_Color_Code));
            sqlParams.Add(new SqlParameter("@Description", ProductDescription));
            sqlParams.Add(new SqlParameter("@Created_Date", Productmrp.Created_Date));
            sqlParams.Add(new SqlParameter("@Created_By", Productmrp.Created_By));
            sqlParams.Add(new SqlParameter("@Updated_Date", Productmrp.Updated_Date));
            sqlParams.Add(new SqlParameter("@Updated_By", Productmrp.Updated_By));
            return sqlParams;
        }

        private string Generate_SKU_Code(ProductMRPInfo itm)
        {
            string SKU_Code = string.Empty;
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            sqlParamList.Add(new SqlParameter("@Size_Id", itm.Size_Id));
            sqlParamList.Add(new SqlParameter("@Colour_Id", itm.Colour_Id));
            sqlParamList.Add(new SqlParameter("@Product_Id", itm.Product_Id));
            SKU_Code = sqlHelper.ExecuteScalerObj(sqlParamList, Storeprocedures.sp_Generate_SKU_Code.ToString(), CommandType.StoredProcedure).ToString();
            return SKU_Code;
        }

        public void Set_Date_Session(object obj)
        {
            PropertyInfo prop = obj.GetType().GetProperty("Created_Date");

            prop.SetValue(obj, DateTime.Now);

            prop = obj.GetType().GetProperty("Updated_Date");

            prop.SetValue(obj, DateTime.Now);

            prop = obj.GetType().GetProperty("Created_By");

            prop.SetValue(obj, 1);

            prop = obj.GetType().GetProperty("Updated_By");

            prop.SetValue(obj, 1);
        }

        private List<SqlParameter> Set_Values_In_Product_SKU(ProductMRPInfo Productmrp, string ProductDescription)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Product_Id", Productmrp.Product_Id));
            sqlParams.Add(new SqlParameter("@Product_SKU_Map_Id", Productmrp.Product_SKU_Map_Id));
            sqlParams.Add(new SqlParameter("@Size_Id", Productmrp.Size_Id));
            sqlParams.Add(new SqlParameter("@Colour_Id", Productmrp.Colour_Id));
            sqlParams.Add(new SqlParameter("@Purchase_Price", Productmrp.Purchase_Price == null ? Productmrp.Purchase_Price.GetValueOrDefault(0m) : Productmrp.Purchase_Price));
            sqlParams.Add(new SqlParameter("@WSR_Code", Productmrp.WSR_Code));
            sqlParams.Add(new SqlParameter("@SKU_Code", Productmrp.SKU_Code));
            sqlParams.Add(new SqlParameter("@Vendor_Color_Code", Productmrp.Vendor_Color_Code));
            sqlParams.Add(new SqlParameter("@Created_Date", Productmrp.Created_Date));
            sqlParams.Add(new SqlParameter("@Created_By", Productmrp.Created_By));
            sqlParams.Add(new SqlParameter("@Updated_Date", Productmrp.Updated_Date));
            sqlParams.Add(new SqlParameter("@Updated_By", Productmrp.Updated_By));
            sqlParams.Add(new SqlParameter("@SKU_Id", sp_Get_Max_Product_SKU_Id()));                
           
            return sqlParams;
        }

        private string sp_Get_Max_Product_SKU_Id()
        {
            string id = "00000000";

            DataTable dt = sqlHelper.ExecuteDataTable(null, Storeprocedures.sp_Get_Max_Product_SKU_Id.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in dt.Rows)
            {
                if (!dr.IsNull("SKU_Id"))
                {
                    id = Convert.ToString(dr["SKU_Id"]);
                }  
            }

            int i = int.Parse(id);

            i = i + 1;

            string new_id = string.Format("{0:00}", i);

            if (new_id.Length != 8)
            {
                int count = new_id.Length;

                string zeros = "";

                for (int j = count; j < 8; j++)
                {
                    zeros = zeros + "0";
                }

                new_id = zeros + new_id;

            }

            return new_id;
        }
        #endregion

        #region---Insert--Update--Product

        public int Insert_Product(ProductInfo Product, ProductImagesInfo ProductImage)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                List<SqlParameter> sqlparam1 = new List<SqlParameter>();
                int ProductId = Convert.ToInt32(sqlHelper.ExecuteScalerObj(Set_Values_In_Product(Product), Storeprocedures.sp_Insert_Product.ToString(), CommandType.StoredProcedure));
                if (ProductId != 0)
                {
                    for (var i = 0; i < Product.ProductImage.Product_Image.Length; i++)
                    {
                        List<SqlParameter> sqlparam = new List<SqlParameter>();
                        if (Product.ProductImage.Product_Image[i] != "" && Product.ProductImage.Product_Image[i] != null)
                        {
                            sqlparam.Add(new SqlParameter("@Product_Id", ProductId));
                            sqlparam.Add(new SqlParameter("@Product_Image", Product.ProductImage.Product_Image[i]));
                            sqlparam.Add(new SqlParameter("@Is_Default", Product.ProductImage.Is_Default[i]));
                            sqlparam.Add(new SqlParameter("@Created_Date", Product.Created_Date));
                            sqlparam.Add(new SqlParameter("@Created_By", Product.Created_By));
                            sqlparam.Add(new SqlParameter("@Updated_Date", Product.Updated_Date));
                            sqlparam.Add(new SqlParameter("@Updated_By", Product.Updated_By));
                            sqlHelper.ExecuteNonQuery(sqlparam, Storeprocedures.sp_Insert_Product_Images.ToString(), CommandType.StoredProcedure);
                        }
                    }
                    sqlparam1.Add(new SqlParameter("@Vendor_Id", Product.Vendor_Id));
                    sqlparam1.Add(new SqlParameter("@Article_No", Product.Article_No));
                    sqlparam1.Add(new SqlParameter("@Created_Date", Product.Created_Date));
                    sqlparam1.Add(new SqlParameter("@Created_By", Product.Created_By));
                    sqlparam1.Add(new SqlParameter("@Updated_Date", Product.Updated_Date));
                    sqlparam1.Add(new SqlParameter("@Updated_By", Product.Updated_By));
                    sqlHelper.ExecuteNonQuery(sqlparam1, Storeprocedures.sp_Insert_Vendor_Article_Mapping.ToString(), CommandType.StoredProcedure);
                }
                scope.Complete();
                return ProductId;
            }
        }

        public int Update_Product(ProductInfo Product)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                int ProductId = Convert.ToInt32(sqlHelper.ExecuteScalerObj(Set_Values_In_Product(Product), Storeprocedures.sp_Update_Product.ToString(), CommandType.StoredProcedure));

                for (var i = 0; i < Product.ProductImage.Product_Image.Length; i++)
                {
                    List<SqlParameter> sqlParams = new List<SqlParameter>();
                    if (Product.ProductImage.Product_Image[i] != "" && Product.ProductImage.Product_Image[i] != null)
                    {
                        if (Product.ProductImage.Product_Image_Id[i] != 0)
                        {
                            sqlParams.Add(new SqlParameter("@Product_Image_Id", Product.ProductImage.Product_Image_Id[i]));
                        }
                        else
                        {
                            sqlParams.Add(new SqlParameter("@Product_Image_Id", 0));
                        }

                        sqlParams.Add(new SqlParameter("@Product_Id", Product.Product_Id));
                        sqlParams.Add(new SqlParameter("@Product_Image", Product.ProductImage.Product_Image[i]));

                        if (Product.ProductImage.Is_Default[i] != null && Product.ProductImage.Is_Default[i] != "")
                        {
                            sqlParams.Add(new SqlParameter("@Is_Default", Product.ProductImage.Is_Default[i]));
                        }
                        else
                        {
                            sqlParams.Add(new SqlParameter("@Is_Default", false));
                        }

                        sqlParams.Add(new SqlParameter("@Created_Date", Product.Created_Date));
                        sqlParams.Add(new SqlParameter("@Created_By", Product.Created_By));
                        sqlParams.Add(new SqlParameter("@Updated_Date", Product.Updated_Date));
                        sqlParams.Add(new SqlParameter("@Updated_By", Product.Updated_By));
                        sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Update_Product_Images.ToString(), CommandType.StoredProcedure);
                    }
                }
                scope.Complete();
                return ProductId;
            }
        }

        private List<SqlParameter> Set_Values_In_Product_Images(ProductInfo Product)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            for (var i = 0; i < Product.ProductImage.Product_Image.Length; i++)
            {
                if (Product.ProductImage.Product_Image_Id[i] != 0)
                {
                    sqlParams.Add(new SqlParameter("@Product_Image_Id", Product.ProductImage.Product_Image_Id[i]));
                }
                else
                {
                    sqlParams.Add(new SqlParameter("@Created_Date", Product.Created_Date));
                    sqlParams.Add(new SqlParameter("@Created_By", Product.Created_By));
                }
                sqlParams.Add(new SqlParameter("@Product_Image", Product.ProductImage.Product_Image[i]));
                sqlParams.Add(new SqlParameter("@Is_Default", Product.ProductImage.Is_Default[i]));
                sqlParams.Add(new SqlParameter("@Updated_Date", Product.Updated_Date));
                sqlParams.Add(new SqlParameter("@Updated_By", Product.Updated_By));
            }
            return sqlParams;
        }

        private List<SqlParameter> Set_Values_In_Product(ProductInfo Product)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            if (Product.Product_Id != 0)
            {
                sqlParams.Add(new SqlParameter("@Product_Id", Product.Product_Id));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Article_No", Product.Article_No));
                sqlParams.Add(new SqlParameter("@Created_Date", Product.Created_Date));
                sqlParams.Add(new SqlParameter("@Created_By", Product.Created_By));
            }
            sqlParams.Add(new SqlParameter("@Vendor_Id", Product.Vendor_Id));
            sqlParams.Add(new SqlParameter("@Brand_Id", Product.Brand_Id));
            sqlParams.Add(new SqlParameter("@Category_Id", Product.Category_Id));
            sqlParams.Add(new SqlParameter("@Sub_Category_Id", Product.Sub_Category_Id));
            sqlParams.Add(new SqlParameter("@Size_Group_Id", Product.Size_Group_Id));
            sqlParams.Add(new SqlParameter("@Center_Size", Product.Center_Size));
            sqlParams.Add(new SqlParameter("@WSR", Product.WSR));
            // sqlParams.Add(new SqlParameter("@Purchase_Price", Product.Purchase_Price));
            sqlParams.Add(new SqlParameter("@Size_Difference", Product.Size_Difference));
            sqlParams.Add(new SqlParameter("@MRP_Difference", Product.MRP_Difference));
            sqlParams.Add(new SqlParameter("@MRP_Percentage", Product.MRP_Percentage));
            //sqlParams.Add(new SqlParameter("@MRP_Price", Product.MRP_Price));
            sqlParams.Add(new SqlParameter("@Launch_Start_Date", Product.Launch_Start_Date));
            sqlParams.Add(new SqlParameter("@Launch_End_Date", Product.Launch_End_Date));
            sqlParams.Add(new SqlParameter("@Comment", Product.Comment));
            sqlParams.Add(new SqlParameter("@Updated_Date", Product.Updated_Date));
            sqlParams.Add(new SqlParameter("@Updated_By", Product.Updated_By));
            return sqlParams;
        }

        #endregion


        public List<ProductDescription> Get_Sizes_By_SizeGroupId(int Product_Id, int Colour_Id)
        {
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            //List<ProductMRPInfo> ProductMRPs = new List<ProductMRPInfo>();
            sqlParamList.Add(new SqlParameter("@Product_Id", Product_Id));
            sqlParamList.Add(new SqlParameter("@Colour_Id", Colour_Id));

            List<ProductDescription> ProductDescription = new List<ProductDescription>();
            DataTable dt = sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.sp_Get_Product_Description_By_ProductId.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in dt.Rows)
            {
                ProductDescription.Add(Get_Product_Descriptions(dr));
            }

            for (int i = 0; i < ProductDescription.Count; i++)
            {
                List<SqlParameter> sqlParamList1 = new List<SqlParameter>();
                sqlParamList1.Add(new SqlParameter("@Product_Id", Product_Id));
                sqlParamList1.Add(new SqlParameter("@Colour_Id", Colour_Id));
                sqlParamList1.Add(new SqlParameter("@Description", ProductDescription[i].Description));

                List<ProductMRPInfo> ProductMRPs = new List<ProductMRPInfo>();
                DataTable dt1 = sqlHelper.ExecuteDataTable(sqlParamList1, Storeprocedures.sp_Get_Sizes_On_SizeGroupId.ToString(), CommandType.StoredProcedure);
                foreach (DataRow dr1 in dt1.Rows)
                {
                    //ProductMRPs.Add(Get_Product_MRP(dr1));
                    ProductDescription[i].ProductMRPs.Add(Get_Product_MRP(dr1, Colour_Id));
                }

                List<ProductMRPInfo> Product_MRP_List = new List<ProductMRPInfo>();

                Product_MRP_List = Calculate_WSR_MRP(Product_Id);

                for (int j = 0; j < ProductDescription[i].ProductMRPs.Count; j++)
                {
                    if (ProductDescription[i].ProductMRPs[j].Purchase_Price == 0 || ProductDescription[i].ProductMRPs[j].Purchase_Price == null)
                    {   
                        ProductDescription[i].ProductMRPs[j].Purchase_Price = Product_MRP_List[j].Purchase_Price;

                        ProductDescription[i].ProductMRPs[j].MRP_Price = Product_MRP_List[j].MRP_Price;
                    }
                }

            }
            return ProductDescription;
        }

        private ProductDescription Get_Product_Descriptions(DataRow dr)
        {
            ProductDescription ProductDescription = new ProductDescription();
            ProductDescription.Description = Convert.ToString(dr["Product_Description"]);
            if (dr["Status"] != DBNull.Value)
                ProductDescription.Status = Convert.ToBoolean(dr["Status"]);
            else
                ProductDescription.Status = false;
            return ProductDescription;
        }

        private ProductMRPInfo Get_Product_MRP(DataRow dr, int Colour_Id)
        {
            Barcode bar = new Barcode();

            ProductMRPInfo ProductMRP = new ProductMRPInfo();
            if (dr["Product_Id"] != DBNull.Value)
                ProductMRP.Product_Id = Convert.ToInt32(dr["Product_Id"]);
            else
                ProductMRP.Product_Id = 0;
            if (dr["Product_Mrp_Id"] != DBNull.Value)
                ProductMRP.Product_MRP_Id = Convert.ToInt32(dr["Product_Mrp_Id"]);
            else
                ProductMRP.Product_MRP_Id = 0;
            if (dr["Product_SKU_Map_Id"] != DBNull.Value)
                ProductMRP.Product_SKU_Map_Id = Convert.ToInt32(dr["Product_SKU_Map_Id"]);
            else
                ProductMRP.Product_SKU_Map_Id = 0;
            if (dr["Size_Id"] != DBNull.Value)
                ProductMRP.Size_Id = Convert.ToInt32(dr["Size_Id"]);
            else
                ProductMRP.Size_Id = 0;
            if (dr["Size_Name"] != DBNull.Value)
                ProductMRP.Size_Name = Convert.ToString(dr["Size_Name"]);
            else
                ProductMRP.Size_Name = null;
            if (Colour_Id != 0)
                ProductMRP.Colour_Id = Colour_Id;
            else
                ProductMRP.Colour_Id = 0;

            if (dr["Purchase_Price"] != DBNull.Value)
                ProductMRP.Purchase_Price = Convert.ToDecimal(dr["Purchase_Price"]);
            else
                ProductMRP.Purchase_Price = null;

            if (dr["MRP_Price"] != DBNull.Value)
                ProductMRP.MRP_Price = Convert.ToDecimal(dr["MRP_Price"]);
            else
                ProductMRP.MRP_Price = null;

            if (dr["SKU_Code"] != DBNull.Value)
                ProductMRP.SKU_Code = Convert.ToString(dr["SKU_Code"]);
            else
                ProductMRP.SKU_Code = Generate_SKU_Code(ProductMRP);

            //if (dr["Product_Barcode"] != DBNull.Value)
            //{
            //    ProductMRP.Barcode_Image_Url = dr["Product_Barcode"] != null ? "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["Product_Barcode"]) : "";
            //    //string arr = ProductMRP.Barcode_Image_Url.Split('[^\\w-]+')[0];
            //    ProductMRP.Product_Barcode = (byte[])dr["Product_Barcode"];
            //}
            //else
            //{
            //    if (!String.IsNullOrEmpty(ProductMRP.SKU_Code))
            //    {
            //        string SKU_Code = Regex.Replace(ProductMRP.SKU_Code, @"[^0-9a-zA-Z]+", "$");
            //        string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ProductImgPath"].ToString()), ProductMRP.SKU_Code + ".png");
            //        ProductMRP.Product_Barcode = bar.Generate_Linear_Barcode(SKU_Code, path);//NK_TSHR_TSRN_b_RD
            //        ProductMRP.Barcode_Image_Url = ProductMRP.Product_Barcode != null ? "data:image/jpg;base64," + Convert.ToBase64String((byte[])ProductMRP.Product_Barcode) : "";

            //    }
            //}
            return ProductMRP;
        }

        public ProductInfo Get_Product_By_Id(int Product_Id)
        {
            ProductInfo Product = new ProductInfo();

            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            sqlParamList.Add(new SqlParameter("@Product_Id", Product_Id));

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.sp_Get_Product_On_ProductId.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in dt.Rows)
            {
                Product.Product_Id = Convert.ToInt32(dr["Product_Id"]);
                Product.Vendor_Id = Convert.ToInt32(dr["Vendor_Id"]);
                Product.Article_No = Convert.ToString(dr["Article_No"]);
                Product.Brand_Id = Convert.ToInt32(dr["Brand_Id"]);
                Product.Category_Id = Convert.ToInt32(dr["Category_Id"]);
                Product.Sub_Category_Id = Convert.ToInt32(dr["Sub_Category_Id"]);
                Product.Size_Group_Id = Convert.ToInt32(dr["Size_Group_Id"]);
                Product.Vendor_Name = Convert.ToString(dr["Vendor_Name"]);
                Product.Brand_Name = Convert.ToString(dr["Brand_Name"]);
                Product.Category = Convert.ToString(dr["Category"]);
                Product.Sub_Category = Convert.ToString(dr["Sub_Category"]);
                Product.Size_Group_Name = Convert.ToString(dr["Size_Group_Name"]);
                Product.Center_Size = Convert.ToString(dr["Center_Size"]);
                Product.Size_Name = Convert.ToString(dr["Size_Name"]);
                Product.WSR = Convert.ToDecimal(dr["WSR"]);
                Product.Size_Difference = Convert.ToDecimal(dr["Size_Difference"]);
                Product.MRP_Difference = Convert.ToDecimal(dr["MRP_Difference"]);
                Product.MRP_Percentage = Convert.ToInt32(dr["MRP_Percentage"]);
                Product.Launch_Start_Date = Convert.ToDateTime(dr["Launch_Start_Date"]);
                Product.Launch_End_Date = Convert.ToDateTime(dr["Launch_End_Date"]);
                Product.Comment = Convert.ToString(dr["Comment"]);
            }

            Get_Product_Images_On_Product_Id(Product_Id, Product);

            return Product;
        }

        private void Get_Product_Images_On_Product_Id(int Product_Id, ProductInfo Product)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();
            sqlParam.Add(new SqlParameter("@Product_Id", Product_Id));
            DataTable dt1 = sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.sp_Get_Product_Images_On_ProductId.ToString(), CommandType.StoredProcedure);

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                //if (Product.ProductImage.Product_Image[i])
                //{
                Product.ProductImage.Product_Image[i] = Convert.ToString(dt1.Rows[i]["Image_Code"]);
                Product.ProductImage.Product_Image_Id[i] = Convert.ToInt32(dt1.Rows[i]["Product_Image_Id"]);
                Product.ProductImage.Is_Default[i] = Convert.ToString(dt1.Rows[i]["Is_Default"]);
                //}
            }
        }

        public List<ProductMRPInfo> Get_Colours_By_ColourId(int Colour_Id)
        {
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            sqlParamList.Add(new SqlParameter("@Colour_Id", Colour_Id));

            List<ProductMRPInfo> ProductMRPs = new List<ProductMRPInfo>();
            DataTable dt = sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.sp_Get_Colours_On_ColourId.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in dt.Rows)
            {
                ProductMRPs.Add(Get_Product_MRP_Values(dr));
            }
            return ProductMRPs;
        }

        private ProductMRPInfo Get_Product_MRP_Values(DataRow dr)
        {
            ProductMRPInfo ProductMRP = new ProductMRPInfo();

            ProductMRP.Colour_Id = Convert.ToInt32(dr["Colour_Id"]);
            ProductMRP.Colour = Convert.ToString(dr["Colour_Name"]);
            if (dr["Vendor_Color_code"] != null)
                ProductMRP.Vendor_Color_Code = Convert.ToString(dr["Vendor_Color_code"]);
            if (dr["Description"] != null)
                ProductMRP.Description = Convert.ToString(dr["Description"]);
            return ProductMRP;
        }

        public ProductInfo Get_Product_Images(int Product_Id)
        {
            ProductInfo Product = new ProductInfo();

            Get_Product_Images_On_Product_Id(Product_Id, Product);

            return Product;
        }

        public void Delete_Product_Image(int Product_Image_Id)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Product_Image_Id", Product_Image_Id));
            sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Delete_Product_Image.ToString(), CommandType.StoredProcedure);
        }

        public List<ColorInfo> Get_ProductMRP_By_ProductId(int Product_Id)
        {
            List<ColorInfo> Colors = new List<ColorInfo>();
            List<ProductMRPInfo> ProductMrps = new List<ProductMRPInfo>();
            List<ProductDescription> ProductDescription = new List<ProductDescription>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Product_Id", Product_Id));
            DataTable dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_Get_Product_Color_Exist_By_ProductId.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in dt.Rows)
            {
                Colors.Add(Get_Product_Colors(dr));
            }
            return Colors;
        }

        private ColorInfo Get_Product_Colors(DataRow dr)
        {
            ColorInfo color = new ColorInfo();
            color.Colour_Id = Convert.ToInt32(dr["Colour_Id"]);
            color.Colour = Convert.ToString(dr["Colour_Name"]);
            if (dr["Vendor_Color_code"] != null)
                color.Vendor_Color_Code = Convert.ToString(dr["Vendor_Color_code"]);
            return color;
        }

        public bool Check_Existing_Article_No(string Article_No)
        {
            bool check = false;

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@Article_No", Article_No));

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.sp_Check_Existing_Article_No.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                foreach (DataRow dr in drList)
                {
                    check = Convert.ToBoolean(dr["check_article"]);
                }
            }

            return check;
        }


        public string Generate_WSR_Code(decimal? Purchase_Price)
        {
            int num = Convert.ToInt32(Purchase_Price);
            int nextdigit;
            int numdigits;
            int[] n = new int[20];

            string wsr_code = "";

            string[] digits = { "A", "B", "C", 
                        "D", "E", "F", 
                        "G", "H", "I", 
                        "J" };
         
            nextdigit = 0;
            numdigits = 0;
            do
            {
                nextdigit = num % 10;
                n[numdigits] = nextdigit;
                numdigits++;
                num = num / 10;
            } while (num > 0);
            numdigits--;
            for (; numdigits >= 0; numdigits--)
                wsr_code += digits[n[numdigits]];
            
            return wsr_code;
        }

        public List<ProductMRPInfo> Calculate_WSR_MRP(int Product_Id)
        {
            #region Product

            /* Product Information to get WSR, MRP Diff, Size Diff, MRP % */

            ProductInfo Product = new ProductInfo();

            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@Product_Id", Product_Id));

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.sp_Get_Product_On_ProductId.ToString(), CommandType.StoredProcedure);
           
            foreach (DataRow dr in dt.Rows)
            {
                Product.Product_Id = Convert.ToInt32(dr["Product_Id"]);
               
                Product.Size_Group_Id = Convert.ToInt32(dr["Size_Group_Id"]);
               
                Product.Size_Group_Name = Convert.ToString(dr["Size_Group_Name"]);

                Product.Center_Size = Convert.ToString(dr["Center_Size"]);

                Product.Size_Name = Convert.ToString(dr["Size_Name"]);

                Product.WSR = Convert.ToDecimal(dr["WSR"]);

                if (dr["Size_Difference"] != DBNull.Value)
                    Product.Size_Difference = Convert.ToDecimal(dr["Size_Difference"]);
                else
                    Product.Size_Difference = 0;

                if (dr["MRP_Difference"] != DBNull.Value)
                    Product.MRP_Difference = Convert.ToDecimal(dr["MRP_Difference"]);
                else
                    Product.MRP_Difference = 0;

                if (dr["MRP_Percentage"] != DBNull.Value)
                    Product.MRP_Percentage = Convert.ToInt32(dr["MRP_Percentage"]);   
                else
                    Product.MRP_Percentage = 0;         
            }

            /* END Product */

            #endregion

            #region Size

            /* Get Size for Center Size */

            List<SizeGroupInfo> Sizes = new List<SizeGroupInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Size_Group_Id", Product.Size_Group_Id));

            DataTable Size_dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_Get_Sizes_By_Size_Group_Id.ToString(), CommandType.StoredProcedure);

            if (Size_dt != null && Size_dt.Rows.Count > 0)
            {
                foreach (DataRow dr in Size_dt.Rows)
                {
                    SizeGroupInfo retVal = new SizeGroupInfo();

                    retVal.Size_Id = Convert.ToInt32(dr["Size_Id"]);

                    retVal.Size_Name = Convert.ToString(dr["Size_Name"]);

                    Sizes.Add(retVal);
                }
            }

            /* END Size */

            #endregion

            #region Calculations

            /* Product MRP & WSR Calculations */

            int size_id = Convert.ToInt32(Product.Center_Size);

            string center_size = Product.Center_Size;

            decimal purchase_price = Convert.ToDecimal(Product.WSR);

            decimal size_difference = Convert.ToDecimal(Product.Size_Difference);

            decimal mrp_diffrence = Convert.ToDecimal(Product.MRP_Difference);
                       
            decimal mrp_percentage = Convert.ToDecimal(Product.MRP_Percentage);
           
            int index = Sizes.IndexOf(Sizes.Single(i => i.Size_Id == size_id));

            int count = Sizes.Count;

            List<ProductMRPInfo> Product_MRP_List = new List<ProductMRPInfo>();

            for (int i = 0; i < count; i++)
            {
                ProductMRPInfo PMRP = new ProductMRPInfo();

                PMRP.WSR_Code = null;

                Product_MRP_List.Add(PMRP);
            }

            index = index + 1;  

            //////////////////////////////////////////////////////////////////////////////////////

            decimal size_difference_temp = 0;

            decimal size_diff_count = size_difference;
                      
            for (int j = index; j > 0; j--)
            {
                if (j == index)
                {
                    Product_MRP_List[j-1].Purchase_Price = purchase_price;

                    if (mrp_diffrence != 0 && mrp_percentage != 0)
                    {
                        var percentage = (purchase_price * mrp_percentage) / 100;

                        Product_MRP_List[j - 1].MRP_Price = purchase_price + mrp_diffrence + percentage;                        
                    }
                    else if(mrp_percentage!=0)
                    {
                        var percentage = (purchase_price * mrp_percentage) / 100;

                        Product_MRP_List[j - 1].MRP_Price = purchase_price + percentage;
                    }
                    else if (mrp_diffrence != 0)
                    {
                        Product_MRP_List[j - 1].MRP_Price = purchase_price + mrp_diffrence;
                    }
                    else
                    {
                        Product_MRP_List[j - 1].MRP_Price = purchase_price;
                    }

                }
                else
                {
                    var computation = purchase_price - size_difference_temp;

                    Product_MRP_List[j-1].Purchase_Price = computation;

                    if ( mrp_diffrence != 0 && mrp_percentage != 0)
                    {
                        var percentage = (computation * mrp_percentage) / 100;

                        Product_MRP_List[j - 1].MRP_Price = computation + mrp_diffrence + percentage;
                    }
                    else if (mrp_percentage != 0)
                    {
                        var percentage = (computation * mrp_percentage) / 100;

                        Product_MRP_List[j - 1].MRP_Price = computation + percentage;
                    }
                    else if (mrp_diffrence != 0)
                    {
                        Product_MRP_List[j - 1].MRP_Price = computation + mrp_diffrence;
                    }
                    else
                    {
                        Product_MRP_List[j - 1].MRP_Price = computation;
                    }
                }

                size_difference_temp = size_difference_temp + size_diff_count;
            }

            //////////////////////////////////////////////////////////////////////////////////////

            size_difference_temp = 0;

            size_diff_count = size_difference;

            for (int j = index + 1; j <= count; j++)
            {
                size_difference_temp = size_difference_temp + size_diff_count;

                var computation = purchase_price + size_difference_temp;

                Product_MRP_List[j-1].Purchase_Price = computation;

                if (mrp_diffrence != 0 && mrp_percentage != 0)
                {
                    var percentage = (computation * mrp_percentage) / 100;

                    Product_MRP_List[j - 1].MRP_Price = computation + mrp_diffrence + percentage;
                }
                else if (mrp_percentage != 0)
                {
                    var percentage = (computation * mrp_percentage) / 100;

                    Product_MRP_List[j - 1].MRP_Price = computation + percentage;
                }
                else if (mrp_diffrence != 0)
                {
                    Product_MRP_List[j - 1].MRP_Price = computation + mrp_diffrence;
                }
                else
                {
                    Product_MRP_List[j - 1].MRP_Price = computation;
                }
            }

            /* END Calculations */

            #endregion

            return Product_MRP_List;
        }

        //public List<ProductMRPInfo> Get_All_Barcodes_toPrint(int Product_Id, int Colour_Id)
        //{
        //    List<SqlParameter> sqlParamList1 = new List<SqlParameter>();
        //    List<ProductMRPInfo> ProductMRPs = new List<ProductMRPInfo>();

        //    sqlParamList1.Add(new SqlParameter("@Product_Id", Product_Id));
        //    sqlParamList1.Add(new SqlParameter("@Colour_Id", Colour_Id));
        //    DataTable dt = sqlHelper.ExecuteDataTable(sqlParamList1, Storeprocedures.sp_Get_Barcodes_On_Product_Id.ToString(), CommandType.StoredProcedure);
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        ProductMRPs.Add(Get_Product_Barcodes(dr));
        //    }
        //    return ProductMRPs;
        //}

        //private ProductMRPInfo Get_Product_Barcodes(DataRow dr)
        //{
        //    ProductMRPInfo ProductMRP = new ProductMRPInfo();
        //    //MemoryStream streamBitmap = new MemoryStream();
        //    string path = "", SKU_Code = "";

        //    if (dr["SKU_Code"] != DBNull.Value)
        //    {
        //        ProductMRP.SKU_Code = Convert.ToString(dr["SKU_Code"]);
        //        SKU_Code = Regex.Replace(ProductMRP.SKU_Code, @"[^0-9a-zA-Z]+", "");
        //        path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ProductImgPath"].ToString()), ProductMRP.SKU_Code + "_Mrp.png");
        //    }
        //    if (dr["Product_Barcode"] != DBNull.Value && dr["MRP_Price"] != DBNull.Value)
        //    {
        //        ProductMRP.Product_Barcode = (byte[])dr["Product_Barcode"];
        //        ProductMRP.MRP_Price = Convert.ToDecimal(dr["MRP_Price"]);
        //        ////Code added by aditya START[19102016]  // Bind footer to barcode
        //        //string product_Barcode = Convert.ToBase64String(ProductMRP.Product_Barcode);

        //        using (var streamBitmap = new MemoryStream(ProductMRP.Product_Barcode))
        //        {
        //            using (var img = Image.FromStream(streamBitmap))
        //            {
        //                int footerHeight = 30;
        //                Bitmap bitmapImg = new Bitmap(img);// Original Image
        //                Bitmap bitmapComment = new Bitmap(img.Width, footerHeight);// Footer
        //                Bitmap bitmapNewImage = new Bitmap(img.Width, img.Height + footerHeight);//New Image
        //                Graphics graphicImage = Graphics.FromImage(bitmapNewImage);
        //                graphicImage.Clear(Color.White);
        //                graphicImage.DrawImage(bitmapImg, new Point(0, 0));
        //                graphicImage.DrawImage(bitmapComment, new Point(bitmapComment.Width, 0));
        //                graphicImage.DrawString("M.R.P. " + ProductMRP.MRP_Price, new Font("Arial", 10), new SolidBrush(Color.Black), 10, bitmapImg.Height + footerHeight / 6);
        //                bitmapNewImage.Save(path);
                        
        //                //byte[] BitMapImg =  graphicImage;
        //                //ProductMRP.Barcode_Image_Url = "data:image/jpg;base64," + Convert.ToBase64String(bitmapNewImage.ToArray(), 0, bitmapNewImage.ToArray().Length);
        //                ProductMRP.Barcode_Image_Url = ProductMRP.SKU_Code + "_Mrp.png";
        //                bitmapImg.Dispose();
        //                bitmapComment.Dispose();
        //                bitmapNewImage.Dispose();
        //            }
        //            //ProductMRP.Barcode_Image_Url = "data:image/jpg;base64," + Convert.ToBase64String(streamBitmap.ToArray(), 0, streamBitmap.ToArray().Length);
        //        }
        //        ////Code added by aditya END [19102016] 
        //       // ProductMRP.Barcode_Image_Url = ProductMRP.Product_Barcode != null ? "data:image/jpg;base64," + Convert.ToBase64String((byte[])ProductMRP.Product_Barcode) : "";
        //        //ProductMRP.Barcode_Image_Url = "data:image/jpg;base64," + Convert.ToBase64String(img.ToArray(), 0, img.ToArray().Length);
        //    }
        //    return ProductMRP;
        //}
    }
}
