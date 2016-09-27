using MyLeoRetailerInfo.PurchaseOrder;
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
    public class PurchaseOrderRepo
    {
        SQL_Repo sqlHelper = null;

        public PurchaseOrderRepo()
        {
            sqlHelper = new SQL_Repo();
        }


        public List<SqlParameter> Set_Values_In_Purchase_Order(PurchaseOrderInfo PurchaseOrder)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (PurchaseOrder.Purchase_Order_Id != 0)
            {
                sqlParam.Add(new SqlParameter("@Purchase_Order_Id", PurchaseOrder.Purchase_Order_Id));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@Created_Date", PurchaseOrder.Created_Date));

                sqlParam.Add(new SqlParameter("@Created_By", PurchaseOrder.Created_By));
            }

            sqlParam.Add(new SqlParameter("@Purchase_Order_No", PurchaseOrder.Purchase_Order_No));

            //sqlParam.Add(new SqlParameter("@Purchase_Order_Date", PurchaseOrder.Purchase_Order_Date));

            sqlParam.Add(new SqlParameter("@Branch_Id", PurchaseOrder.Branch_Id));

            sqlParam.Add(new SqlParameter("@Vendor_Id", PurchaseOrder.Vendor_Id));

            sqlParam.Add(new SqlParameter("@Agent_Id", PurchaseOrder.Agent_Id));

            sqlParam.Add(new SqlParameter("@Shipping_Address", PurchaseOrder.Shipping_Address));

            sqlParam.Add(new SqlParameter("@Transporter_Id", PurchaseOrder.Transporter_Id));

            //sqlParam.Add(new SqlParameter("@Start_Supply_Date", PurchaseOrder.Start_Supply_Date));

            //sqlParam.Add(new SqlParameter("@Stop_Supply_Date", PurchaseOrder.Stop_Supply_Date));

            sqlParam.Add(new SqlParameter("@Total_Quantity", PurchaseOrder.Total_Quantity));

            sqlParam.Add(new SqlParameter("@Net_Amount", PurchaseOrder.Net_Amount));

            if (PurchaseOrder.Purchase_Order_Date == DateTime.MinValue)
            {
                sqlParam.Add(new SqlParameter("@Purchase_Order_Date", DateTime.MinValue));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@Purchase_Order_Date", PurchaseOrder.Purchase_Order_Date));
            }

            if (PurchaseOrder.Start_Supply_Date == DateTime.MinValue)
            {
                sqlParam.Add(new SqlParameter("@Start_Supply_Date", DateTime.MinValue));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@Start_Supply_Date", PurchaseOrder.Start_Supply_Date));
            }

            if (PurchaseOrder.Stop_Supply_Date == DateTime.MinValue)
            {
                sqlParam.Add(new SqlParameter("@Stop_Supply_Date", DateTime.MinValue));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@Stop_Supply_Date", PurchaseOrder.Stop_Supply_Date));
            }


            sqlParam.Add(new SqlParameter("@Updated_Date", PurchaseOrder.Updated_Date));

            sqlParam.Add(new SqlParameter("@Updated_By", PurchaseOrder.Updated_By));

            return sqlParam;
        }

        public void Insert_Purchase_Order(PurchaseOrderInfo PurchaseOrder)
        {
            PurchaseOrder.Purchase_Order_Id = Convert.ToInt32(sqlHelper.ExecuteScalerObj(Set_Values_In_Purchase_Order(PurchaseOrder), Storeprocedures.sp_Insert_Purchase_Order.ToString(), CommandType.StoredProcedure));

            int j = 0;

            foreach (var item in PurchaseOrder.PurchaseOrders)
            {
                List<SqlParameter> sqlParam = new List<SqlParameter>();

                sqlParam.Add(new SqlParameter("@Purchase_Order_Id", PurchaseOrder.Purchase_Order_Id));

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

                sqlParam.Add(new SqlParameter("@Comment", item.Comment));

                sqlParam.Add(new SqlParameter("@Item_Ids", item.Item_Ids));

                PurchaseOrder.PurchaseOrders[j].Purchase_Order_Item_Id = Convert.ToInt32(sqlHelper.ExecuteScalerObj(sqlParam, Storeprocedures.sp_Insert_Purchase_Order_Item.ToString(), CommandType.StoredProcedure));


                int i = 0;

                i++;

                if (i == 1 && PurchaseOrder.Sizes[j].Quantity1 != 0)
                {
                    List<SqlParameter> sqlParams = new List<SqlParameter>();

                    sqlParams.Add(new SqlParameter("@Purchase_Order_Item_Id", PurchaseOrder.PurchaseOrders[j].Purchase_Order_Item_Id));
                    sqlParams.Add(new SqlParameter("@Purchase_Order_Id", PurchaseOrder.Purchase_Order_Id));

                    sqlParams.Add(new SqlParameter("@Size_Id", PurchaseOrder.Sizes[j].Size_Id1));
                    sqlParams.Add(new SqlParameter("@Quantity", PurchaseOrder.Sizes[j].Quantity1));

                    sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Insert_Purchase_Order_Item_Sizes.ToString(), CommandType.StoredProcedure);
                }

                i++;
                if (i == 2 && PurchaseOrder.Sizes[j].Quantity2 != 0)
                {
                    List<SqlParameter> sqlParams = new List<SqlParameter>();

                    sqlParams.Add(new SqlParameter("@Purchase_Order_Item_Id", PurchaseOrder.PurchaseOrders[j].Purchase_Order_Item_Id));
                    sqlParams.Add(new SqlParameter("@Purchase_Order_Id", PurchaseOrder.Purchase_Order_Id));

                    sqlParams.Add(new SqlParameter("@Size_Id", PurchaseOrder.Sizes[j].Size_Id2));
                    sqlParams.Add(new SqlParameter("@Quantity", PurchaseOrder.Sizes[j].Quantity2));

                    sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Insert_Purchase_Order_Item_Sizes.ToString(), CommandType.StoredProcedure);
                }

                i++;
                if (i == 3 && PurchaseOrder.Sizes[j].Quantity3 != 0)
                {
                    List<SqlParameter> sqlParams = new List<SqlParameter>();

                    sqlParams.Add(new SqlParameter("@Purchase_Order_Item_Id", PurchaseOrder.PurchaseOrders[j].Purchase_Order_Item_Id));
                    sqlParams.Add(new SqlParameter("@Purchase_Order_Id", PurchaseOrder.Purchase_Order_Id));

                    sqlParams.Add(new SqlParameter("@Size_Id", PurchaseOrder.Sizes[j].Size_Id3));
                    sqlParams.Add(new SqlParameter("@Quantity", PurchaseOrder.Sizes[j].Quantity3));

                    sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Insert_Purchase_Order_Item_Sizes.ToString(), CommandType.StoredProcedure);
                }

                i++;
                if (i == 4 && PurchaseOrder.Sizes[j].Quantity4 != 0)
                {
                    List<SqlParameter> sqlParams = new List<SqlParameter>();

                    sqlParams.Add(new SqlParameter("@Purchase_Order_Item_Id", PurchaseOrder.PurchaseOrders[j].Purchase_Order_Item_Id));
                    sqlParams.Add(new SqlParameter("@Purchase_Order_Id", PurchaseOrder.Purchase_Order_Id));

                    sqlParams.Add(new SqlParameter("@Size_Id", PurchaseOrder.Sizes[j].Size_Id4));
                    sqlParams.Add(new SqlParameter("@Quantity", PurchaseOrder.Sizes[j].Quantity4));

                    sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Insert_Purchase_Order_Item_Sizes.ToString(), CommandType.StoredProcedure);
                }

                i++;
                if (i == 5 && PurchaseOrder.Sizes[j].Quantity5 != 0)
                {
                    List<SqlParameter> sqlParams = new List<SqlParameter>();

                    sqlParams.Add(new SqlParameter("@Purchase_Order_Item_Id", PurchaseOrder.PurchaseOrders[j].Purchase_Order_Item_Id));
                    sqlParams.Add(new SqlParameter("@Purchase_Order_Id", PurchaseOrder.Purchase_Order_Id));

                    sqlParams.Add(new SqlParameter("@Size_Id", PurchaseOrder.Sizes[j].Size_Id5));
                    sqlParams.Add(new SqlParameter("@Quantity", PurchaseOrder.Sizes[j].Quantity5));

                    sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Insert_Purchase_Order_Item_Sizes.ToString(), CommandType.StoredProcedure);
                }

                i++;
                if (i == 6 && PurchaseOrder.Sizes[j].Quantity6 != 0)
                {
                    List<SqlParameter> sqlParams = new List<SqlParameter>();

                    sqlParams.Add(new SqlParameter("@Purchase_Order_Item_Id", PurchaseOrder.PurchaseOrders[j].Purchase_Order_Item_Id));
                    sqlParams.Add(new SqlParameter("@Purchase_Order_Id", PurchaseOrder.Purchase_Order_Id));

                    sqlParams.Add(new SqlParameter("@Size_Id", PurchaseOrder.Sizes[j].Size_Id6));
                    sqlParams.Add(new SqlParameter("@Quantity", PurchaseOrder.Sizes[j].Quantity6));

                    sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Insert_Purchase_Order_Item_Sizes.ToString(), CommandType.StoredProcedure);
                }

                i++;
                if (i == 7 && PurchaseOrder.Sizes[j].Quantity7 != 0)
                {
                    List<SqlParameter> sqlParams = new List<SqlParameter>();

                    sqlParams.Add(new SqlParameter("@Purchase_Order_Item_Id", PurchaseOrder.PurchaseOrders[j].Purchase_Order_Item_Id));
                    sqlParams.Add(new SqlParameter("@Purchase_Order_Id", PurchaseOrder.Purchase_Order_Id));

                    sqlParams.Add(new SqlParameter("@Size_Id", PurchaseOrder.Sizes[j].Size_Id7));
                    sqlParams.Add(new SqlParameter("@Quantity", PurchaseOrder.Sizes[j].Quantity7));

                    //Addition
                    sqlParam.Add(new SqlParameter("@Comment", item.Comment));
                    //End


                    PurchaseOrder.Purchase_Order_Item_Id = Convert.ToInt32(sqlHelper.ExecuteScalerObj(sqlParam, Storeprocedures.sp_Insert_Purchase_Order_Item.ToString(), CommandType.StoredProcedure));

                }

                i++;
                if (i == 8 && PurchaseOrder.Sizes[j].Quantity8 != 0)
                {
                    List<SqlParameter> sqlParams = new List<SqlParameter>();

                    sqlParams.Add(new SqlParameter("@Purchase_Order_Item_Id", PurchaseOrder.PurchaseOrders[j].Purchase_Order_Item_Id));
                    sqlParams.Add(new SqlParameter("@Purchase_Order_Id", PurchaseOrder.Purchase_Order_Id));

                    sqlParams.Add(new SqlParameter("@Size_Id", PurchaseOrder.Sizes[j].Size_Id8));
                    sqlParams.Add(new SqlParameter("@Quantity", PurchaseOrder.Sizes[j].Quantity8));

                    sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Insert_Purchase_Order_Item_Sizes.ToString(), CommandType.StoredProcedure);
                }

                i++;
                if (i == 9 && PurchaseOrder.Sizes[j].Quantity9 != 0)
                {
                    List<SqlParameter> sqlParams = new List<SqlParameter>();

                    sqlParams.Add(new SqlParameter("@Purchase_Order_Item_Id", PurchaseOrder.PurchaseOrders[j].Purchase_Order_Item_Id));
                    sqlParams.Add(new SqlParameter("@Purchase_Order_Id", PurchaseOrder.Purchase_Order_Id));

                    sqlParams.Add(new SqlParameter("@Size_Id", PurchaseOrder.Sizes[j].Size_Id9));
                    sqlParams.Add(new SqlParameter("@Quantity", PurchaseOrder.Sizes[j].Quantity9));

                    sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Insert_Purchase_Order_Item_Sizes.ToString(), CommandType.StoredProcedure);
                }

                i++;
                if (i == 10 && PurchaseOrder.Sizes[j].Quantity10 != 0)
                {
                    List<SqlParameter> sqlParams = new List<SqlParameter>();

                    sqlParams.Add(new SqlParameter("@Purchase_Order_Item_Id", PurchaseOrder.PurchaseOrders[j].Purchase_Order_Item_Id));
                    sqlParams.Add(new SqlParameter("@Purchase_Order_Id", PurchaseOrder.Purchase_Order_Id));

                    sqlParams.Add(new SqlParameter("@Size_Id", PurchaseOrder.Sizes[j].Size_Id10));
                    sqlParams.Add(new SqlParameter("@Quantity", PurchaseOrder.Sizes[j].Quantity10));

                    sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Insert_Purchase_Order_Item_Sizes.ToString(), CommandType.StoredProcedure);
                }

                i++;
                if (i == 11 && PurchaseOrder.Sizes[j].Quantity11 != 0)
                {
                    List<SqlParameter> sqlParams = new List<SqlParameter>();

                    sqlParams.Add(new SqlParameter("@Purchase_Order_Item_Id", PurchaseOrder.PurchaseOrders[j].Purchase_Order_Item_Id));
                    sqlParams.Add(new SqlParameter("@Purchase_Order_Id", PurchaseOrder.Purchase_Order_Id));

                    sqlParams.Add(new SqlParameter("@Size_Id", PurchaseOrder.Sizes[j].Size_Id11));
                    sqlParams.Add(new SqlParameter("@Quantity", PurchaseOrder.Sizes[j].Quantity11));

                    sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Insert_Purchase_Order_Item_Sizes.ToString(), CommandType.StoredProcedure);
                }

                i++;
                if (i == 12 && PurchaseOrder.Sizes[j].Quantity12 != 0)
                {
                    List<SqlParameter> sqlParams = new List<SqlParameter>();

                    sqlParams.Add(new SqlParameter("@Purchase_Order_Item_Id", PurchaseOrder.PurchaseOrders[j].Purchase_Order_Item_Id));
                    sqlParams.Add(new SqlParameter("@Purchase_Order_Id", PurchaseOrder.Purchase_Order_Id));

                    sqlParams.Add(new SqlParameter("@Size_Id", PurchaseOrder.Sizes[j].Size_Id12));
                    sqlParams.Add(new SqlParameter("@Quantity", PurchaseOrder.Sizes[j].Quantity12));

                    sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Insert_Purchase_Order_Item_Sizes.ToString(), CommandType.StoredProcedure);
                }

                i++;
                if (i == 13 && PurchaseOrder.Sizes[j].Quantity13 != 0)
                {
                    List<SqlParameter> sqlParams = new List<SqlParameter>();

                    sqlParams.Add(new SqlParameter("@Purchase_Order_Item_Id", PurchaseOrder.PurchaseOrders[j].Purchase_Order_Item_Id));
                    sqlParams.Add(new SqlParameter("@Purchase_Order_Id", PurchaseOrder.Purchase_Order_Id));

                    sqlParams.Add(new SqlParameter("@Size_Id", PurchaseOrder.Sizes[j].Size_Id13));
                    sqlParams.Add(new SqlParameter("@Quantity", PurchaseOrder.Sizes[j].Quantity13));

                    sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Insert_Purchase_Order_Item_Sizes.ToString(), CommandType.StoredProcedure);
                }

                i++;
                if (i == 14 && PurchaseOrder.Sizes[j].Quantity14 != 0)
                {
                    List<SqlParameter> sqlParams = new List<SqlParameter>();

                    sqlParams.Add(new SqlParameter("@Purchase_Order_Item_Id", PurchaseOrder.PurchaseOrders[j].Purchase_Order_Item_Id));
                    sqlParams.Add(new SqlParameter("@Purchase_Order_Id", PurchaseOrder.Purchase_Order_Id));

                    sqlParams.Add(new SqlParameter("@Size_Id", PurchaseOrder.Sizes[j].Size_Id14));
                    sqlParams.Add(new SqlParameter("@Quantity", PurchaseOrder.Sizes[j].Quantity14));

                    sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Insert_Purchase_Order_Item_Sizes.ToString(), CommandType.StoredProcedure);
                }

                i++;
                if (i == 15 && PurchaseOrder.Sizes[j].Quantity15 != 0)
                {
                    List<SqlParameter> sqlParams = new List<SqlParameter>();

                    sqlParams.Add(new SqlParameter("@Purchase_Order_Item_Id", PurchaseOrder.PurchaseOrders[j].Purchase_Order_Item_Id));
                    sqlParams.Add(new SqlParameter("@Purchase_Order_Id", PurchaseOrder.Purchase_Order_Id));

                    sqlParams.Add(new SqlParameter("@Size_Id", PurchaseOrder.Sizes[j].Size_Id15));
                    sqlParams.Add(new SqlParameter("@Quantity", PurchaseOrder.Sizes[j].Quantity15));

                    sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Insert_Purchase_Order_Item_Sizes.ToString(), CommandType.StoredProcedure);
                }

                j++;

            }

        }


        public DataTable Get_Purchase_Orders(QueryInfo query_Details)
        {
            return sqlHelper.Get_Table_With_Where(query_Details);
        }

        public List<VendorInfo> Get_Article_No_By_Vendor_Id(int Vendor_Id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Vendor_Id", Vendor_Id));

            List<VendorInfo> Vendors = new List<VendorInfo>();
            DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Article_No_By_Vendor_Id.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in dt.Rows)
            {
                VendorInfo Vendor = new VendorInfo();

                Vendor.Article_No = Convert.ToString(dr["Article_No"]);

                Vendors.Add(Vendor);
            }
            return Vendors;
        }

        public List<BrandInfo> Get_Brand_By_Vendor_Id(int Vendor_Id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Vendor_Id", Vendor_Id));

            List<BrandInfo> Brands = new List<BrandInfo>();
            DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Brand_By_Vendor_Id.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in dt.Rows)
            {
                BrandInfo Brand = new BrandInfo();

                Brand.Brand_Id = Convert.ToInt32(dr["Brand_Id"]);

                Brand.Brand_Name = Convert.ToString(dr["Brand_Name"]);

                Brands.Add(Brand);
            }
            return Brands;
        }

        public List<CategoryInfo> Get_Category_By_Vendor_Id(int Vendor_Id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Vendor_Id", Vendor_Id));

            List<CategoryInfo> Categories = new List<CategoryInfo>();
            DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Category_By_Vendor_Id.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in dt.Rows)
            {
                CategoryInfo Category = new CategoryInfo();

                Category.Category_Id = Convert.ToInt32(dr["Category_Id"]);

                Category.Category = Convert.ToString(dr["Category"]);

                Categories.Add(Category);
            }
            return Categories;
        }

        public List<SubCategoryInfo> Get_Sub_Category_By_Vendor_Id(int Vendor_Id, int Category_Id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Vendor_Id", Vendor_Id));

            parameters.Add(new SqlParameter("@Category_Id", Category_Id));

            List<SubCategoryInfo> SubCategories = new List<SubCategoryInfo>();
            DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Sub_Category_By_Vendor_Id.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in dt.Rows)
            {
                SubCategoryInfo SubCategory = new SubCategoryInfo();

                SubCategory.Sub_Category_Id = Convert.ToInt32(dr["SubCategory_Id"]);

                SubCategory.Sub_Category = Convert.ToString(dr["Sub_Category"]);

                SubCategories.Add(SubCategory);
            }
            return SubCategories;
        }


        public List<PurchaseOrderInfo> Get_Consolidate_Purchase_Order_Item(int Vendor_Id)
        {

            List<PurchaseOrderInfo> PurchaseOrders = new List<PurchaseOrderInfo>();

            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Vendor_Id", Vendor_Id));

            DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Consolidate_Purchase_Order_Item.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in dt.Rows)
            {
                PurchaseOrderInfo PurchaseOrder = new PurchaseOrderInfo();

                PurchaseOrder.Article_No = Convert.ToString(dr["Article_No"]);

                PurchaseOrder.Colour_Name = Convert.ToString(dr["Colour_Name"]);

                PurchaseOrder.Brand_Id = Convert.ToInt32(dr["Brand_Id"]);

                PurchaseOrder.Brand_Name = Convert.ToString(dr["Brand_Name"]);

                PurchaseOrder.Category_Id = Convert.ToInt32(dr["Category_Id"]);

                PurchaseOrder.Category_Name = Convert.ToString(dr["Category"]);

                PurchaseOrder.Sub_Category_Id = Convert.ToInt32(dr["Sub_Category_Id"]);

                PurchaseOrder.Sub_Category_Name = Convert.ToString(dr["Sub_Category"]);

                PurchaseOrder.Size_Group_Id = Convert.ToInt32(dr["Size_Group_Id"]);

                PurchaseOrder.Size_Group_Name = Convert.ToString(dr["Size_Group_Name"]);

                PurchaseOrder.Start_Size = Convert.ToString(dr["Start_Size"]);

                PurchaseOrder.End_Size = Convert.ToString(dr["End_Size"]);

                PurchaseOrder.Center_Size = Convert.ToString(dr["Center_Size"]);

                PurchaseOrder.Purchase_Price = Convert.ToDecimal(dr["Purchase_Price"]);

                PurchaseOrder.Size_Difference = Convert.ToDecimal(dr["Size_Difference"]);

                PurchaseOrder.Total_Amount = Convert.ToDecimal(dr["Amount"]);

                PurchaseOrder.Item_Quantity = Convert.ToInt32(dr["Quantity"]);

                PurchaseOrder.Comment = Convert.ToString(dr["Comment"]);

                PurchaseOrder.Item_Ids = Convert.ToString(dr["Item_Ids"]);

                PurchaseOrder.Sizes = Get_Consolidate_Purchase_Order_Item_Sizes(PurchaseOrder.Item_Ids);

                PurchaseOrders.Add(PurchaseOrder);

            }

            return PurchaseOrders;
        }

        public List<Sizes> Get_Consolidate_Purchase_Order_Item_Sizes(string Item_Ids)
        {
            List<Sizes> Size = new List<Sizes>();

            var k = 0;



            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Item_Ids", Item_Ids));

            k++;

            DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Consolidate_Purchase_Order_Item_Sizes.ToString(), CommandType.StoredProcedure);

            int i = 1;

            foreach (DataRow item in dt.Rows)
            {
                Sizes Sizes = new Sizes();

                if (i == 1 && Convert.ToInt32(item["Size_Id"]) != 0)
                {
                    Sizes.Size_Id1 = Convert.ToInt32(item["Size_Id"]);
                    Sizes.Quantity1 = Convert.ToInt32(item["Quantity"]);
                    Sizes.Amount1 = Convert.ToInt32(item["Amount"]);
                }
                else if (i == 2 && Convert.ToInt32(item["Size_Id"]) != 0)
                {
                    Sizes.Size_Id2 = Convert.ToInt32(item["Size_Id"]);
                    Sizes.Quantity2 = Convert.ToInt32(item["Quantity"]);
                    Sizes.Amount2 = Convert.ToInt32(item["Amount"]);
                }
                else if (i == 3 && Convert.ToInt32(item["Size_Id"]) != 0)
                {
                    Sizes.Size_Id3 = Convert.ToInt32(item["Size_Id"]);
                    Sizes.Quantity3 = Convert.ToInt32(item["Quantity"]);
                    Sizes.Amount3 = Convert.ToInt32(item["Amount"]);
                }
                else if (i == 4 && Convert.ToInt32(item["Size_Id"]) != 0)
                {
                    Sizes.Size_Id4 = Convert.ToInt32(item["Size_Id"]);
                    Sizes.Quantity4 = Convert.ToInt32(item["Quantity"]);
                    Sizes.Amount4 = Convert.ToInt32(item["Amount"]);
                }
                else if (i == 5 && Convert.ToInt32(item["Size_Id"]) != 0)
                {
                    Sizes.Size_Id5 = Convert.ToInt32(item["Size_Id"]);
                    Sizes.Quantity5 = Convert.ToInt32(item["Quantity"]);
                    Sizes.Amount5 = Convert.ToInt32(item["Amount"]);
                }
                else if (i == 6 && Convert.ToInt32(item["Size_Id"]) != 0)
                {
                    Sizes.Size_Id6 = Convert.ToInt32(item["Size_Id"]);
                    Sizes.Quantity6 = Convert.ToInt32(item["Quantity"]);
                    Sizes.Amount6 = Convert.ToInt32(item["Amount"]);
                }
                else if (i == 7 && Convert.ToInt32(item["Size_Id"]) != 0)
                {
                    Sizes.Size_Id7 = Convert.ToInt32(item["Size_Id"]);
                    Sizes.Quantity7 = Convert.ToInt32(item["Quantity"]);
                    Sizes.Amount7 = Convert.ToInt32(item["Amount"]);
                }
                else if (i == 8 && Convert.ToInt32(item["Size_Id"]) != 0)
                {
                    Sizes.Size_Id8 = Convert.ToInt32(item["Size_Id"]);
                    Sizes.Quantity8 = Convert.ToInt32(item["Quantity"]);
                    Sizes.Amount8 = Convert.ToInt32(item["Amount"]);
                }
                else if (i == 9 && Convert.ToInt32(item["Size_Id"]) != 0)
                {
                    Sizes.Size_Id9 = Convert.ToInt32(item["Size_Id"]);
                    Sizes.Quantity9 = Convert.ToInt32(item["Quantity"]);
                    Sizes.Amount9 = Convert.ToInt32(item["Amount"]);
                }
                else if (i == 10 && Convert.ToInt32(item["Size_Id"]) != 0)
                {
                    Sizes.Size_Id10 = Convert.ToInt32(item["Size_Id"]);
                    Sizes.Quantity10 = Convert.ToInt32(item["Quantity"]);
                    Sizes.Amount10 = Convert.ToInt32(item["Amount"]);
                }
                else if (i == 11 && Convert.ToInt32(item["Size_Id"]) != 0)
                {
                    Sizes.Size_Id11 = Convert.ToInt32(item["Size_Id"]);
                    Sizes.Quantity11 = Convert.ToInt32(item["Quantity"]);
                    Sizes.Amount11 = Convert.ToInt32(item["Amount"]);
                }
                else if (i == 12 && Convert.ToInt32(item["Size_Id"]) != 0)
                {
                    Sizes.Size_Id12 = Convert.ToInt32(item["Size_Id"]);
                    Sizes.Quantity12 = Convert.ToInt32(item["Quantity"]);
                    Sizes.Amount12 = Convert.ToInt32(item["Amount"]);
                }
                else if (i == 13 && Convert.ToInt32(item["Size_Id"]) != 0)
                {
                    Sizes.Size_Id13 = Convert.ToInt32(item["Size_Id"]);
                    Sizes.Quantity13 = Convert.ToInt32(item["Quantity"]);
                    Sizes.Amount13 = Convert.ToInt32(item["Amount"]);
                }
                else if (i == 14 && Convert.ToInt32(item["Size_Id"]) != 0)
                {
                    Sizes.Size_Id14 = Convert.ToInt32(item["Size_Id"]);
                    Sizes.Quantity14 = Convert.ToInt32(item["Quantity"]);
                    Sizes.Amount14 = Convert.ToInt32(item["Amount"]);
                }
                else if (i == 15 && Convert.ToInt32(item["Size_Id"]) != 0)
                {
                    Sizes.Size_Id15 = Convert.ToInt32(item["Size_Id"]);
                    Sizes.Quantity15 = Convert.ToInt32(item["Quantity"]);
                    Sizes.Amount15 = Convert.ToInt32(item["Amount"]);
                }

                Size.Add(Sizes);

                i++;

            }

            return Size;
        }

        ////***************************************************************************////

        public List<PurchaseOrderInfo> Get_Purchase_Orders()
        {
            List<PurchaseOrderInfo> PurchaseOrders = new List<PurchaseOrderInfo>();
            DataTable dt = sqlHelper.ExecuteDataTable(null, Storeprocedures.sp_Get_Purchase_Orders.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in dt.Rows)
            {
                PurchaseOrderInfo PurchaseOrder = new PurchaseOrderInfo();

                PurchaseOrder.Purchase_Order_Id = Convert.ToInt32(dr["Purchase_Order_Id"]);

                PurchaseOrder.Purchase_Order_No = Convert.ToString(dr["Purchase_Order_No"]);

                PurchaseOrders.Add(PurchaseOrder);
            }
            return PurchaseOrders;
        }

        private PurchaseOrderInfo Get_Purchase_Order_Values(DataRow dr)
        {
            PurchaseOrderInfo PurchaseOrder = new PurchaseOrderInfo();

            PurchaseOrder.Purchase_Order_Id = Convert.ToInt32(dr["Purchase_Order_Id"]);

            PurchaseOrder.Purchase_Order_No = Convert.ToString(dr["Purchase_Order_No"]);

            //PurchaseOrder.Purchase_Order_Date = Convert.ToDateTime(dr["Purchase_Order_Date"]);

            PurchaseOrder.Branch_Id = Convert.ToInt32(dr["Branch_Id"]);

            PurchaseOrder.Vendor_Id = Convert.ToInt32(dr["Vendor_Id"]);

            PurchaseOrder.Agent_Id = Convert.ToInt32(dr["Agent_Id"]);

            PurchaseOrder.Shipping_Address = Convert.ToString(dr["Shipping_Address"]);

            PurchaseOrder.Transporter_Id = Convert.ToInt32(dr["Transporter_Id"]);

            //PurchaseOrder.Start_Supply_Date = Convert.ToDateTime(dr["Start_Supply_Date"]);

            //PurchaseOrder.Stop_Supply_Date = Convert.ToDateTime(dr["Stop_Supply_Date"]);

            PurchaseOrder.Total_Quantity = Convert.ToInt32(dr["Total_Quantity"]);

            PurchaseOrder.Net_Amount = Convert.ToDecimal(dr["Net_Amount"]);

            if (dr.IsNull("Purchase_Order_Date"))
            {
                PurchaseOrder.Purchase_Order_Date = DateTime.MinValue;
            }
            else
            {
                PurchaseOrder.Purchase_Order_Date = Convert.ToDateTime(dr["Purchase_Order_Date"]);
            }

            if (dr.IsNull("Start_Supply_Date"))
            {
                PurchaseOrder.Start_Supply_Date = DateTime.MinValue;
            }
            else
            {
                PurchaseOrder.Start_Supply_Date = Convert.ToDateTime(dr["Start_Supply_Date"]);
            }

            if (dr.IsNull("Stop_Supply_Date"))
            {
                PurchaseOrder.Stop_Supply_Date = DateTime.MinValue;
            }
            else
            {
                PurchaseOrder.Stop_Supply_Date = Convert.ToDateTime(dr["Stop_Supply_Date"]);
            }

            PurchaseOrder.Created_Date = Convert.ToDateTime(dr["Created_Date"]);

            PurchaseOrder.Created_By = Convert.ToInt32(dr["Created_By"]);

            PurchaseOrder.Updated_Date = Convert.ToDateTime(dr["Updated_Date"]);

            PurchaseOrder.Updated_By = Convert.ToInt32(dr["Updated_By"]);



            PurchaseOrder.Purchase_Order_Item_Id = Convert.ToInt32(dr["Purchase_Order_Item_Id"]);

            PurchaseOrder.Article_No = Convert.ToString(dr["Article_No"]);

            PurchaseOrder.Colour_Name = Convert.ToString(dr["Colour_Name"]);

            PurchaseOrder.Brand_Id = Convert.ToInt32(dr["Brand_Id"]);

            PurchaseOrder.Category_Id = Convert.ToInt32(dr["Category_Id"]);

            PurchaseOrder.Sub_Category_Id = Convert.ToInt32(dr["Sub_Category_Id"]);

            PurchaseOrder.Size_Group_Id = Convert.ToInt32(dr["Size_Group_Id"]);

            PurchaseOrder.Start_Size = Convert.ToString(dr["Start_Size"]);

            PurchaseOrder.End_Size = Convert.ToString(dr["End_Size"]);

            PurchaseOrder.Center_Size = Convert.ToString(dr["Center_Size"]);

            PurchaseOrder.Purchase_Price = Convert.ToDecimal(dr["Purchase_Price"]);

            PurchaseOrder.Size_Difference = Convert.ToDecimal(dr["Size_Difference"]);

            PurchaseOrder.Total_Amount = Convert.ToDecimal(dr["Total_Amount"]);

            return PurchaseOrder;
        }

        public void Update_Purchase_Order(PurchaseOrderInfo PurchaseOrder)
        {
            sqlHelper.ExecuteNonQuery(Set_Values_In_Purchase_Order(PurchaseOrder), Storeprocedures.sp_Update_Purchase_Order.ToString(), CommandType.StoredProcedure);

            sqlHelper.ExecuteNonQuery(Set_Values_In_Purchase_Order_Item(PurchaseOrder), Storeprocedures.sp_Update_Purchase_Order_Item.ToString(), CommandType.StoredProcedure);
        }

        public List<SqlParameter> Set_Values_In_Purchase_Order_Item(PurchaseOrderInfo PurchaseOrder)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (PurchaseOrder.Purchase_Order_Item_Id != 0)
            {
                sqlParam.Add(new SqlParameter("@Purchase_Order_Item_Id", PurchaseOrder.Purchase_Order_Item_Id));
            }

            sqlParam.Add(new SqlParameter("@Purchase_Order_Id", PurchaseOrder.Purchase_Order_Id));

            sqlParam.Add(new SqlParameter("@Article_No", PurchaseOrder.Article_No));

            sqlParam.Add(new SqlParameter("@Colour_Name", PurchaseOrder.Colour_Name));

            sqlParam.Add(new SqlParameter("@Brand_Id", PurchaseOrder.Brand_Id));

            sqlParam.Add(new SqlParameter("@Category_Id", PurchaseOrder.Category_Id));

            sqlParam.Add(new SqlParameter("@Sub_Category_Id", PurchaseOrder.Sub_Category_Id));

            sqlParam.Add(new SqlParameter("@Size_Group_Id", PurchaseOrder.Size_Group_Id));

            sqlParam.Add(new SqlParameter("@Start_Size", PurchaseOrder.Start_Size));

            sqlParam.Add(new SqlParameter("@End_Size", PurchaseOrder.End_Size));

            sqlParam.Add(new SqlParameter("@Center_Size", PurchaseOrder.Center_Size));

            sqlParam.Add(new SqlParameter("@Purchase_Price", PurchaseOrder.Purchase_Price));

            sqlParam.Add(new SqlParameter("@Size_Difference", PurchaseOrder.Size_Difference));

            sqlParam.Add(new SqlParameter("@Total_Amount", PurchaseOrder.Total_Amount));


            return sqlParam;
        }

        public PurchaseOrderInfo Get_Purchase_Order_By_Id(int Purchase_Order_Id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Purchase_Order_Id", Purchase_Order_Id));

            PurchaseOrderInfo PurchaseOrder = new PurchaseOrderInfo();
            DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Purchase_Order_By_Id.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {
                PurchaseOrder = Get_Purchase_Order_Values(dr);
            }
            return PurchaseOrder;
        }

        public int Get_Purchase_Order_Invoice_By_Id(int Purchase_Invoice_Id, string SKU_Code)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Purchase_Invoice_Id", Purchase_Invoice_Id));

            parameters.Add(new SqlParameter("@SKU_Code", SKU_Code));

            int Purchase_Order_Id = 0;

            DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_PurchaseOrderId_By_SKU_POI.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {
                Purchase_Order_Id = Convert.ToInt32(dr["Purchase_Order_Id"]);
            }
            return Purchase_Order_Id;
        }

        ////***************************************************************************////

        public PurchaseOrderInfo Get_Purchase_Order_Details_By_Id(int Purchase_Order_Id)
        {
            PurchaseOrderInfo purchaseOrder = new PurchaseOrderInfo();

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Purchase_Order_Id", Purchase_Order_Id));

            DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Purchase_Order_Details_By_Id.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in dt.Rows)
            {
                purchaseOrder.Purchase_Order_Id = Convert.ToInt32(dr["Purchase_Order_Id"]);

                if (!dr.IsNull("Purchase_Order_No"))
                    purchaseOrder.Purchase_Order_No = Convert.ToString(dr["Purchase_Order_No"]);

                if (!dr.IsNull("Purchase_Order_Date"))
                    purchaseOrder.Purchase_Order_Date = Convert.ToDateTime(dr["Purchase_Order_Date"]);

                if (!dr.IsNull("Vendor_Id"))
                    purchaseOrder.Vendor_Id = Convert.ToInt32(dr["Vendor_Id"]);

                if (!dr.IsNull("Agent_Id"))
                    purchaseOrder.Agent_Id = Convert.ToInt32(dr["Agent_Id"]);

                if (!dr.IsNull("Agent_Name"))
                    purchaseOrder.Agent_Name = Convert.ToString(dr["Agent_Name"]);

                if (!dr.IsNull("Shipping_Address"))
                    purchaseOrder.Shipping_Address = Convert.ToString(dr["Shipping_Address"]);

                if (!dr.IsNull("Transporter_Id"))
                    purchaseOrder.Transporter_Id = Convert.ToInt32(dr["Transporter_Id"]);

                if (!dr.IsNull("Transporter_Name"))
                    purchaseOrder.Transporter_Name = Convert.ToString(dr["Transporter_Name"]);

                if (!dr.IsNull("Start_Supply_Date"))
                    purchaseOrder.Start_Supply_Date = Convert.ToDateTime(dr["Start_Supply_Date"]);

                if (!dr.IsNull("Stop_Supply_Date"))
                    purchaseOrder.Stop_Supply_Date = Convert.ToDateTime(dr["Stop_Supply_Date"]);

                if (!dr.IsNull("Total_Quantity"))
                    purchaseOrder.Total_Quantity = Convert.ToInt32(dr["Total_Quantity"]);

                if (!dr.IsNull("Net_Amount"))
                    purchaseOrder.Net_Amount = Convert.ToDecimal(dr["Net_Amount"]);

                if (!dr.IsNull("Vendor_Name"))
                    purchaseOrder.Vendor_Name = Convert.ToString(dr["Vendor_Name"]);

                if (!dr.IsNull("Vendor_Address"))
                    purchaseOrder.Vendor_Address = Convert.ToString(dr["Vendor_Address"]);

                if (!dr.IsNull("Vendor_Email1"))
                    purchaseOrder.Vendor_Email1 = Convert.ToString(dr["Vendor_Email1"]);

                if (!dr.IsNull("Vendor_Phone1"))
                    purchaseOrder.Vendor_Phone1 = Convert.ToString(dr["Vendor_Phone1"]);

                if (!dr.IsNull("Vendor_Phone2"))
                    purchaseOrder.Vendor_Phone2 = Convert.ToString(dr["Vendor_Phone2"]);

            }

            return purchaseOrder;
        }


        public List<PurchaseOrderItemInfo> Get_Purchase_Order_Items(int Purchase_Order_Id)
        {
            List<PurchaseOrderItemInfo> purchaseOrderItems = new List<PurchaseOrderItemInfo>();

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Purchase_Order_Id", Purchase_Order_Id));

            DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Purchase_Order_Items.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in dt.Rows)
            {
                PurchaseOrderItemInfo purchaseOrderItem = new PurchaseOrderItemInfo();

                purchaseOrderItem.Purchase_Order_Item_Id = Convert.ToInt32(dr["Purchase_Order_Item_Id"]);

                purchaseOrderItem.Purchase_Order_Id = Convert.ToInt32(dr["Purchase_Order_Id"]);

                if (!dr.IsNull("Article_No"))
                    purchaseOrderItem.Article_No = Convert.ToString(dr["Article_No"]);

                if (!dr.IsNull("Colour_Name"))
                    purchaseOrderItem.Colour_Name = Convert.ToString(dr["Colour_Name"]);

                if (!dr.IsNull("Start_Size"))
                    purchaseOrderItem.Start_Size = Convert.ToString(dr["Start_Size"]);

                if (!dr.IsNull("End_Size"))
                    purchaseOrderItem.End_Size = Convert.ToString(dr["End_Size"]);

                if (!dr.IsNull("Center_Size"))
                    purchaseOrderItem.Center_Size = Convert.ToString(dr["Center_Size"]);

                if (!dr.IsNull("Purchase_Price"))
                    purchaseOrderItem.Purchase_Price = Convert.ToDecimal(dr["Purchase_Price"]);

                if (!dr.IsNull("Size_Difference"))
                    purchaseOrderItem.Size_Difference = Convert.ToDecimal(dr["Size_Difference"]);

                if (!dr.IsNull("Total_Amount"))
                    purchaseOrderItem.Total_Amount = Convert.ToDecimal(dr["Total_Amount"]);

                if (!dr.IsNull("Comment"))
                    purchaseOrderItem.Comment = Convert.ToString(dr["Comment"]);

                if (!dr.IsNull("Brand_Id"))
                    purchaseOrderItem.Brand_Id = Convert.ToInt32(dr["Brand_Id"]);

                if (!dr.IsNull("Brand_Name"))
                    purchaseOrderItem.Brand_Name = Convert.ToString(dr["Brand_Name"]);

                if (!dr.IsNull("Category_Id"))
                    purchaseOrderItem.Category_Id = Convert.ToInt32(dr["Category_Id"]);

                if (!dr.IsNull("Category"))
                    purchaseOrderItem.Category = Convert.ToString(dr["Category"]);

                if (!dr.IsNull("Sub_Category_Id"))
                    purchaseOrderItem.Sub_Category_Id = Convert.ToInt32(dr["Sub_Category_Id"]);

                if (!dr.IsNull("Sub_Category"))
                    purchaseOrderItem.Sub_Category = Convert.ToString(dr["Sub_Category"]);

                if (!dr.IsNull("Size_Group_Id"))
                    purchaseOrderItem.Size_Group_Id = Convert.ToInt32(dr["Size_Group_Id"]);

                if (!dr.IsNull("Size_Group_Name"))
                    purchaseOrderItem.Size_Group_Name = Convert.ToString(dr["Size_Group_Name"]);

                purchaseOrderItem.sizes = Get_Purchase_Order_Item_Sizes(purchaseOrderItem.Purchase_Order_Item_Id);

                purchaseOrderItem.Total_Quantity = purchaseOrderItem.sizes.Sum(a => a.Quantity1);

                purchaseOrderItems.Add(purchaseOrderItem);
            }

            return purchaseOrderItems;
        }

        private List<Sizes> Get_Purchase_Order_Item_Sizes(int Purchase_Order_Item_Id)
        {
            List<Sizes> sizes = new List<Sizes>();

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Purchase_Order_Item_Id", Purchase_Order_Item_Id));

            DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Purchase_Order_Item_Sizes.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in dt.Rows)
            {
                Sizes size = new Sizes();

                size.Size_Id1 = Convert.ToInt32(dr["Size_Id"]);
                size.Quantity1 = Convert.ToInt32(dr["Quantity"]);
                size.Size_Name = Convert.ToString(dr["Size_Name"]);

                sizes.Add(size);
            }

            return sizes;
        }

        //demo
        public void SendDemoEmail()
        {
            SendEmailInfo emailData = new SendEmailInfo();

            emailData.ID = 1;
            emailData.To_Email_Id = "sanchitasawant1493@gmail.com";
            emailData.Subject = "Myleo Demo Email";
            emailData.Body = "Hi Sanchita, These demo email from MyLeo of Purchase Order.";

            MyLeoRetailerRepo.Common.CommonMethods.SendMail(emailData);
        }

    }
}
