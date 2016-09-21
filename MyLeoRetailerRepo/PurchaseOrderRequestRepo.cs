using MyLeoRetailerInfo.PurchaseOrderRequest;
using MyLeoRetailerRepo.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerInfo.Vendor;
using MyLeoRetailerInfo.Brand;
using MyLeoRetailerInfo.Category;


namespace MyLeoRetailerRepo
{
    public class PurchaseOrderRequestRepo
    {
        SQL_Repo sqlHelper = null;

        public PurchaseOrderRequestRepo()
        {
            sqlHelper = new SQL_Repo();
        }

        public List<SqlParameter> Set_Values_In_Purchase_Order_Request(PurchaseOrderRequestInfo PurchaseOrderRequest)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (PurchaseOrderRequest.Branch_Id != 0)
            {
                sqlParam.Add(new SqlParameter("@Branch_Id", PurchaseOrderRequest.Branch_Id));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@Branch_ID", 0));
            }            

            sqlParam.Add(new SqlParameter("@Vendor_Id", PurchaseOrderRequest.Vendor_Id));

            sqlParam.Add(new SqlParameter("@Status", PurchaseOrderRequest.Status));
             
            sqlParam.Add(new SqlParameter("@Total_Quantity", PurchaseOrderRequest.Total_Quantity));

            sqlParam.Add(new SqlParameter("@Net_Amount", PurchaseOrderRequest.Net_Amount));
                      
            sqlParam.Add(new SqlParameter("@Created_Date", PurchaseOrderRequest.Created_Date));

            sqlParam.Add(new SqlParameter("@Created_By", PurchaseOrderRequest.Created_By));

            sqlParam.Add(new SqlParameter("@Updated_Date", PurchaseOrderRequest.Updated_Date));

            sqlParam.Add(new SqlParameter("@Updated_By", PurchaseOrderRequest.Updated_By));

            return sqlParam;
        }
                
        public int Insert_Purchase_Order_Request(PurchaseOrderRequestInfo PurchaseOrderRequest)
        {
            PurchaseOrderRequest.Purchase_Order_Request_Id = Convert.ToInt32(sqlHelper.ExecuteScalerObj(Set_Values_In_Purchase_Order_Request(PurchaseOrderRequest), Storeprocedures.sp_Insert_Purchase_Order_Request.ToString(), CommandType.StoredProcedure));

            foreach (var item in PurchaseOrderRequest.PurchaseOrderRequests)
            {
                List<SqlParameter> sqlParam = new List<SqlParameter>();
                 
                sqlParam.Add(new SqlParameter("@Purchase_Order_Request_Id", PurchaseOrderRequest.Purchase_Order_Request_Id));

                sqlParam.Add(new SqlParameter("@Article_No", item.Article_No));

                sqlParam.Add(new SqlParameter("@Colour_Name", item.Colour_Name));

                sqlParam.Add(new SqlParameter("@Brand_Id", item.Brand_Id));

                sqlParam.Add(new SqlParameter("@Category_Id", item.Category_Id));

                sqlParam.Add(new SqlParameter("@Sub_Category_Id", item.Sub_Category_Id));

                sqlParam.Add(new SqlParameter("@Size_Group_Id", item.Size_Group_Id));

                sqlParam.Add(new SqlParameter("@Start_Size", item.Start_Size));

                sqlParam.Add(new SqlParameter("@End_Size", item.End_Size));

                sqlParam.Add(new SqlParameter("@Center_Size", item.Center_Size));

                sqlParam.Add(new SqlParameter("@Purchase_Price", item.Purchase_Price));

                sqlParam.Add(new SqlParameter("@Size_Difference", item.Size_Difference));

                sqlParam.Add(new SqlParameter("@Total_Amount", item.Total_Amount));

                PurchaseOrderRequest.Purchase_Order_Request_Item_Id = Convert.ToInt32(sqlHelper.ExecuteScalerObj(sqlParam, Storeprocedures.sp_Insert_Purchase_Order_Request_Item.ToString(), CommandType.StoredProcedure));

            }



            int i = 0;

            foreach (var item in PurchaseOrderRequest.Sizes)
            {
                i++;
                List<SqlParameter> sqlParams = new List<SqlParameter>();

                sqlParams.Add(new SqlParameter("@Purchase_Order_Request_Item_Id", PurchaseOrderRequest.Purchase_Order_Request_Item_Id));
                sqlParams.Add(new SqlParameter("@Purchase_Order_Request_Id", PurchaseOrderRequest.Purchase_Order_Request_Id));
                if (i == 1)
                {
                    sqlParams.Add(new SqlParameter("@Size_Id", item.Size_Id1));
                    sqlParams.Add(new SqlParameter("@Quantity", item.Quantity1));
                }
                else if (i == 2)
                {
                    sqlParams.Add(new SqlParameter("@Size_Id", item.Size_Id2));
                    sqlParams.Add(new SqlParameter("@Quantity", item.Quantity2));
                }
                else if (i == 3)
                {
                    sqlParams.Add(new SqlParameter("@Size_Id", item.Size_Id3));
                    sqlParams.Add(new SqlParameter("@Quantity", item.Quantity3));
                }
                else if (i == 4)
                {
                    sqlParams.Add(new SqlParameter("@Size_Id", item.Size_Id4));
                    sqlParams.Add(new SqlParameter("@Quantity", item.Quantity4));
                }
                else if (i == 5)
                {
                    sqlParams.Add(new SqlParameter("@Size_Id", item.Size_Id5));
                    sqlParams.Add(new SqlParameter("@Quantity", item.Quantity5));
                }
                else if (i == 6)
                {
                    sqlParams.Add(new SqlParameter("@Size_Id", item.Size_Id6));
                    sqlParams.Add(new SqlParameter("@Quantity", item.Quantity6));
                }
                else if (i == 7)
                {
                    sqlParams.Add(new SqlParameter("@Size_Id", item.Size_Id7));
                    sqlParams.Add(new SqlParameter("@Quantity", item.Quantity7));
                }
                else if (i == 8)
                {
                    sqlParams.Add(new SqlParameter("@Size_Id", item.Size_Id8));
                    sqlParams.Add(new SqlParameter("@Quantity", item.Quantity8));
                }
                else if (i == 9)
                {
                    sqlParams.Add(new SqlParameter("@Size_Id", item.Size_Id9));
                    sqlParams.Add(new SqlParameter("@Quantity", item.Quantity9));
                }
                else if (i == 10)
                {
                    sqlParams.Add(new SqlParameter("@Size_Id", item.Size_Id10));
                    sqlParams.Add(new SqlParameter("@Quantity", item.Quantity10));
                }
                else if (i == 11)
                {
                    sqlParams.Add(new SqlParameter("@Size_Id", item.Size_Id11));
                    sqlParams.Add(new SqlParameter("@Quantity", item.Quantity11));
                }
                else if (i == 12)
                {
                    sqlParams.Add(new SqlParameter("@Size_Id", item.Size_Id12));
                    sqlParams.Add(new SqlParameter("@Quantity", item.Quantity12));
                }
                else if (i == 13)
                {
                    sqlParams.Add(new SqlParameter("@Size_Id", item.Size_Id13));
                    sqlParams.Add(new SqlParameter("@Quantity", item.Quantity13));
                }
                else if (i == 14)
                {
                    sqlParams.Add(new SqlParameter("@Size_Id", item.Size_Id14));
                    sqlParams.Add(new SqlParameter("@Quantity", item.Quantity14));
                }
                else if (i == 15)
                {
                    sqlParams.Add(new SqlParameter("@Size_Id", item.Size_Id15));
                    sqlParams.Add(new SqlParameter("@Quantity", item.Quantity15));
                }

                sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Insert_Purchase_Order_Request_Item_Sizes.ToString(), CommandType.StoredProcedure);
            }


            return PurchaseOrderRequest.Purchase_Order_Request_Id;
        }

        public DataTable Get_Purchase_Order_Requests(QueryInfo query_Details)
        {
            return sqlHelper.Get_Table_With_Where(query_Details);
        }               

        //public List<VendorInfo> Get_Article_No_By_Vendor_Id(int Vendor_Id)
        //{
        //    List<SqlParameter> parameters = new List<SqlParameter>();
        //    parameters.Add(new SqlParameter("@Vendor_Id", Vendor_Id));

        //    List<VendorInfo> Vendors = new List<VendorInfo>();
        //    DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Article_No_By_Vendor_Id.ToString(), CommandType.StoredProcedure);
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        VendorInfo Vendor = new VendorInfo();

        //        Vendor.Article_No = Convert.ToString(dr["Article_No"]);

        //        Vendors.Add(Vendor);
        //    }
        //    return Vendors;
        //}

        //public List<BrandInfo> Get_Brand_By_Vendor_Id(int Vendor_Id)
        //{
        //    List<SqlParameter> parameters = new List<SqlParameter>();
        //    parameters.Add(new SqlParameter("@Vendor_Id", Vendor_Id));

        //    List<BrandInfo> Brands = new List<BrandInfo>();
        //    DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Brand_By_Vendor_Id.ToString(), CommandType.StoredProcedure);
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        BrandInfo Brand = new BrandInfo();

        //        Brand.Brand_Id = Convert.ToInt32(dr["Brand_Id"]);

        //        Brand.Brand_Name = Convert.ToString(dr["Brand_Name"]);

        //        Brands.Add(Brand);
        //    }
        //    return Brands;
        //}

        //public List<CategoryInfo> Get_Category_By_Vendor_Id(int Vendor_Id)
        //{
        //    List<SqlParameter> parameters = new List<SqlParameter>();
        //    parameters.Add(new SqlParameter("@Vendor_Id", Vendor_Id));

        //    List<CategoryInfo> Categories = new List<CategoryInfo>();
        //    DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Category_By_Vendor_Id.ToString(), CommandType.StoredProcedure);
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        CategoryInfo Category = new CategoryInfo();

        //        Category.Category_Id = Convert.ToInt32(dr["Category_Id"]);

        //        Category.Category = Convert.ToString(dr["Category"]);

        //        Categories.Add(Category);
        //    }
        //    return Categories;
        //}
         
        //public List<SubCategoryInfo> Get_Sub_Category_By_Vendor_Id(int Vendor_Id, int Category_Id)
        //{
        //    List<SqlParameter> parameters = new List<SqlParameter>();
        //    parameters.Add(new SqlParameter("@Vendor_Id", Vendor_Id));

        //    parameters.Add(new SqlParameter("@Category_Id", Category_Id));

        //    List<SubCategoryInfo> SubCategories = new List<SubCategoryInfo>();
        //    DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Sub_Category_By_Vendor_Id.ToString(), CommandType.StoredProcedure);
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        SubCategoryInfo SubCategory = new SubCategoryInfo();

        //        SubCategory.Sub_Category_Id = Convert.ToInt32(dr["SubCategory_Id"]);

        //        SubCategory.Sub_Category = Convert.ToString(dr["Sub_Category"]);

        //        SubCategories.Add(SubCategory);
        //    }
        //    return SubCategories;
        //}

               
    }
}