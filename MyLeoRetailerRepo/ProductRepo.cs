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

namespace MyLeoRetailerRepo
{
    public class ProductRepo
    { 
        SQL_Repo sqlHelper = null;

        public ProductRepo()
		{
			sqlHelper = new SQL_Repo();
		}

        public DataTable Get_Products(QueryInfo query_Details)
        {
            return sqlHelper.Get_Table_With_Where(query_Details);
        }

        #region--Insert--Update--Product-MRP--
        //public void Insert_Product_MRP(ProductMRPInfo Productmrp)
        //{
        //    sqlHelper.ExecuteNonQuery(Set_Values_In_Product_MRP(Productmrp), Storeprocedures.sp_Insert_Product_MRP.ToString(), CommandType.StoredProcedure);
        //}

        //public void Update_Product_MRP(ProductMRPInfo Productmrp)
        //{
        //    sqlHelper.ExecuteNonQuery(Set_Values_In_Product_MRP(Productmrp), Storeprocedures.sp_Update_Product_MRP.ToString(), CommandType.StoredProcedure);
        //}

        //private List<SqlParameter> Set_Values_In_Product_MRP(ProductMRPInfo Productmrp)
        //{
        //    List<SqlParameter> sqlParams = new List<SqlParameter>();
        //    sqlParams.Add(new SqlParameter("@Product_MRP_Id", Productmrp.Product_MRP_Id));
        //    sqlParams.Add(new SqlParameter("@Product_Id", Productmrp.Product_Id));
        //    sqlParams.Add(new SqlParameter("@Size_Id", Productmrp.Size_Id));
        //    sqlParams.Add(new SqlParameter("@Purchase_Price", Productmrp.Purchase_Price));
        //    sqlParams.Add(new SqlParameter("@MRP_Price", Productmrp.MRP_Price));
        //    sqlParams.Add(new SqlParameter("@SKU_Code", Productmrp.SKU_Code));
        //    sqlParams.Add(new SqlParameter("@Created_Date", Productmrp.Created_Date));
        //    sqlParams.Add(new SqlParameter("@Created_By", Productmrp.Created_By));
        //    sqlParams.Add(new SqlParameter("@Updated_Date", Productmrp.Updated_Date));
        //    sqlParams.Add(new SqlParameter("@Updated_By", Productmrp.Updated_By));
        //    return sqlParams;
        //}
        #endregion

        #region---Insert--Update--Product

        public int Insert_Product(ProductInfo Product)
        { 
            int ProductId = Convert.ToInt32(sqlHelper.ExecuteScalerObj(Set_Values_In_Product(Product), Storeprocedures.sp_Insert_Product.ToString(), CommandType.StoredProcedure));
            if(ProductId != 0)
            {
                List<SqlParameter> sqlparam = new List<SqlParameter>();

                sqlparam.Add(new SqlParameter("@Vendor_Id", Product.Vendor_Id));
                sqlparam.Add(new SqlParameter("@Article_No", Product.Article_No));
                sqlparam.Add(new SqlParameter("@Is_Active", true));
                sqlparam.Add(new SqlParameter("@Created_Date", Product.Created_Date));
                sqlparam.Add(new SqlParameter("@Created_By", Product.Created_By));
                sqlparam.Add(new SqlParameter("@Updated_Date", Product.Updated_Date));
                sqlparam.Add(new SqlParameter("@Updated_By", Product.Updated_By));
                sqlHelper.ExecuteNonQuery(sqlparam, Storeprocedures.sp_Insert_Vendor_Article_Mapping.ToString(), CommandType.StoredProcedure);
            }
            //sqlHelper.ExecuteScalerObj(Set_Values_In_Product(Product), Storeprocedures.sp_Insert_Product.ToString(), CommandType.StoredProcedure);
            //foreach (var item in Product.ProductMRP_N_WSR)
            //{
            //    List<SqlParameter> sqlparam = new List<SqlParameter>();

            //    sqlparam.Add(new SqlParameter("@Product_Id", ProductId));
            //    sqlparam.Add(new SqlParameter("@Purchase_Price", item.Purchase_Price));
            //    sqlparam.Add(new SqlParameter("@MRP_Price", item.MRP_Price));

            //    sqlparam.Add(new SqlParameter("@Created_On", Product.Created_Date));
            //    sqlparam.Add(new SqlParameter("@Created_By", Product.Created_By));
            //    sqlparam.Add(new SqlParameter("@Updated_On", Product.Updated_Date));
            //    sqlparam.Add(new SqlParameter("@Updated_By", Product.Updated_By));
            //    sqlHelper.ExecuteNonQuery(sqlparam, Storeprocedures.sp_Insert_Product_MRP.ToString(), CommandType.StoredProcedure);
            //}
            return ProductId;
        }

        public void Update_Product(ProductInfo Product)
        {
            sqlHelper.ExecuteNonQuery(Set_Values_In_Product(Product), Storeprocedures.sp_Update_Product.ToString(), CommandType.StoredProcedure);
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

        //public ProductInfo Get_Product_By_Id(int Product_Id)
        //{
        //    List<SqlParameter> sqlParamList = new List<SqlParameter>();
        //    sqlParamList.Add(new SqlParameter("@Product_Id", Product_Id));

        //    ProductInfo Product = new ProductInfo();
        //    DataTable dt = sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.sp_Get_Products_By_Id.ToString(), CommandType.StoredProcedure);
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        Product.Product_Id = Convert.ToInt32(dr["Product_Id"]);
        //        Product.Branch_Id = Convert.ToInt32(dr["Branch_Id"]);
        //        Product.Product_Name = Convert.ToString(dr["Product_Name"]);
        //        Product.Designation_Id = Convert.ToInt32(dr["Designation_Id"]);
        //        Product.Product_DOB = Convert.ToDateTime(dr["Product_DOB"]);
        //        Product.Product_Gender = Convert.ToInt32(dr["Product_Gender"]);
        //        Product.Product_Address = Convert.ToString(dr["Product_Address"]);
        //        Product.Product_City = Convert.ToString(dr["Product_City"]);
        //        Product.Product_State = Convert.ToString(dr["Product_State"]);
        //        Product.Product_Country = Convert.ToString(dr["Product_Country"]);
        //        Product.Product_Pincode = Convert.ToInt32(dr["Product_Pincode"]);
        //        Product.Product_Native_Address = Convert.ToString(dr["Product_Native_Address"]);
        //        Product.Product_Mobile1 = Convert.ToString(dr["Product_Mobile1"]);
        //        Product.Product_Mobile2 = Convert.ToString(dr["Product_Mobile2"]);
        //        Product.Product_Home_Lindline = Convert.ToString(dr["Product_Home_Lindline"]);
        //        Product.Product_EmailId = Convert.ToString(dr["Product_EmailId"]);
        //        Product.IsActive = Convert.ToBoolean(dr["IsActive"]);
        //        Product.Created_Date = Convert.ToDateTime(dr["Created_On"]);
        //        Product.Created_By = Convert.ToInt32(dr["Created_By"]);
        //        Product.Updated_Date = Convert.ToDateTime(dr["Updated_On"]);
        //        Product.Updated_By = Convert.ToInt32(dr["Updated_By"]);
        //    }
        //    return Product;
        //}

        public List<ProductMRPInfo> Get_Sizes_By_SizeGroupId(int Product_Id)
        {
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            sqlParamList.Add(new SqlParameter("@Product_Id", Product_Id));

                List<ProductMRPInfo> ProductMRPs = new List<ProductMRPInfo>();
                DataTable dt = sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.sp_Get_Sizes_On_SizeGroupId.ToString(), CommandType.StoredProcedure);
                foreach (DataRow dr in dt.Rows)
                {
                    ProductMRPs.Add(Get_Product_MRP(dr));
                }
                return ProductMRPs;
        }

        private ProductMRPInfo Get_Product_MRP(DataRow dr)
        {
            ProductMRPInfo ProductMRP = new ProductMRPInfo();

            ProductMRP.Size_Id = Convert.ToInt32(dr["Size_Id"]);
            ProductMRP.Size_Name = Convert.ToString(dr["Size_Name"]);

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
                ProductMRP.SKU_Code = null;
           

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
                Product.Sub_Category_Id = Convert.ToInt32(dr["Sub_Category_Id"]) ;
                Product.Size_Group_Id = Convert.ToInt32(dr["Size_Group_Id"]);
                Product.Center_Size = Convert.ToString(dr["Center_Size"]);
                //Product.Purchase_Price = Convert.ToDecimal(dr["Purchase_Price"]);
                Product.Size_Difference = Convert.ToDecimal(dr["Size_Difference"]);
                Product.MRP_Difference = Convert.ToDecimal(dr["MRP_Difference"]);
                Product.MRP_Percentage = Convert.ToInt32(dr["MRP_Percentage"]);
                //Product.MRP_Price = Convert.ToDecimal(dr["MRP_Price"]);
                Product.Launch_Start_Date = Convert.ToDateTime(dr["Launch_Start_Date"]);
                Product.Launch_End_Date = Convert.ToDateTime(dr["Launch_End_Date"]);
                Product.Comment = Convert.ToString(dr["Comment"]);
            }
            return Product;
        }

        public List<ProductMRPInfo> Get_Colours_By_ColourId(int Colour_Id)
        {
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            sqlParamList.Add(new SqlParameter("@Colour_Id", Colour_Id));

            List<ProductMRPInfo> ProductMRPs = new List<ProductMRPInfo>();
            DataTable dt = sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.sp_Get_Colours_On_ColourId.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in dt.Rows)
            {
                ProductMRPs.Add(Get_Product_Colours(dr));
            }
            return ProductMRPs;
        }

        private ProductMRPInfo Get_Product_Colours(DataRow dr)
        {
            ProductMRPInfo ProductMRP = new ProductMRPInfo(); 

            ProductMRP.Colour_Id = Convert.ToInt32(dr["Colour_Id"]);
            ProductMRP.Colour = Convert.ToString(dr["Colour_Name"]);
            return ProductMRP;
        }
    }
}
