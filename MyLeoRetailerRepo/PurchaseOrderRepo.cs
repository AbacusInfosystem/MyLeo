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
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Transactions;
using MyLeoRetailerRepo.Common;
using MyLeoRetailerInfo.Color;
using System.Transactions;

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
           
            foreach (var item in PurchaseOrder.PurchaseOrders)
            {
                List<SqlParameter> sqlParam = new List<SqlParameter>();

                sqlParam.Add(new SqlParameter("@Purchase_Order_Id", PurchaseOrder.Purchase_Order_Id));

                sqlParam.Add(new SqlParameter("@Article_No", item.Article_No));

                sqlParam.Add(new SqlParameter("@Colour_Id", item.Colour_Id));

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


                    //CODE Added by aditya 27092016 Start

                    List<Sizes> Size = new List<Sizes>();

                    string[] Item_Ids = new string[0];

                    string[] Branch_Ids = new string[0];

                    string[] Request_Ids = new string[0];

                    string[] Request_Dates = new string[0];

                    if (item.Item_Ids.IndexOf(',') != -1)  //if condition is use so if string does not contain ',' it wont break
                    {
                        Item_Ids = item.Item_Ids.Split(',');
                    }
                    else
                    {
                        Item_Ids[0] = item.Item_Ids;
                    }

                    if (item.Branch_Ids.IndexOf(',') != -1)  //if condition is use so if string does not contain ',' it wont break
                    {
                        Branch_Ids = item.Branch_Ids.Split(',');
                    }
                    else
                    {
                        Branch_Ids[0] = item.Branch_Ids;
                    }

                    if (item.Request_Ids.IndexOf(',') != -1)  //if condition is use so if string does not contain ',' it wont break
                    {
                        Request_Ids = item.Request_Ids.Split(',');
                    }
                    else
                    {
                        Request_Ids[0] = item.Request_Ids;
                    }

                    if (item.Request_Dates.IndexOf(',') != -1)  //if condition is use so if string does not contain ',' it wont break
                    {
                        Request_Dates = item.Request_Dates.Split(',');
                    }
                    else
                    {
                        Request_Ids[0] = item.Request_Ids;
                    }



                    for (int a = 0; a < Item_Ids.Count(); a++)
                    {
                        Size = Get_Consolidate_Purchase_Order_Item_Size(Item_Ids[a]);

                        foreach (var items in Size)
                        {
                            List<SqlParameter> parameters = new List<SqlParameter>();

                            parameters.Add(new SqlParameter("@Article_No", item.Article_No));

                            parameters.Add(new SqlParameter("@Colour_Id", item.Colour_Id));

                            parameters.Add(new SqlParameter("@Size_Id", items.Size_Id1));

                            string SKU_Code = null;

                            SKU_Code = Convert.ToString(sqlHelper.ExecuteScalerObj(parameters, Storeprocedures.sp_Get_SKU_By_ArticleNo_ColorId_SizeId.ToString(), CommandType.StoredProcedure));


                            parameters = new List<SqlParameter>();

                            parameters.Add(new SqlParameter("@Request_Id", Request_Ids[a]));

                            parameters.Add(new SqlParameter("@Request_Date", Request_Dates[a]));

                            parameters.Add(new SqlParameter("@SKU_Code", SKU_Code));

                            parameters.Add(new SqlParameter("@Quantity", items.Quantity1));

                            parameters.Add(new SqlParameter("@Balance_Quantity", items.Quantity1));

                            parameters.Add(new SqlParameter("@Branch_Id", Branch_Ids[a]));

                            parameters.Add(new SqlParameter("@Dispatch_Date", DateTime.Now.ToString("MM-dd-yyyy")));

                            parameters.Add(new SqlParameter("@Status", "Pending")); //hardcoded coz during insertion status will always be  Dispatch

                            sqlHelper.ExecuteScalerObj(parameters, Storeprocedures.sp_Insert_Purchase_Order_Request_Consolidation.ToString(), CommandType.StoredProcedure);

                        }
                    }
                    //CODE Added by aditya 27092016  END

                    PurchaseOrder.Purchase_Order_Id = Convert.ToInt32(sqlHelper.ExecuteScalerObj(Set_Values_In_Purchase_Order(PurchaseOrder), Storeprocedures.sp_Insert_Purchase_Order.ToString(), CommandType.StoredProcedure));

                    int j = 0;

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
                        //sqlParam.Add(new SqlParameter("@Comment", item.Comment));
                    //End

                        sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Insert_Purchase_Order_Item_Sizes.ToString(), CommandType.StoredProcedure);
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

        private PurchaseOrderInfo Get_Purchase_Order_Value(DataRow dr)
        {
            PurchaseOrderInfo PurchaseOrder = new PurchaseOrderInfo();

            PurchaseOrder.Purchase_Order_Id = Convert.ToInt32(dr["Purchase_Order_Id"]);

            PurchaseOrder.Purchase_Order_No = Convert.ToString(dr["Purchase_Order_No"]);

            PurchaseOrder.Purchase_Order_Date = Convert.ToDateTime(dr["Purchase_Order_Date"]);

            PurchaseOrder.Shipping_Address = Convert.ToString(dr["Shipping_Address"]);

            PurchaseOrder.Vendor_Id = Convert.ToInt32(dr["Vendor_Id"]);

            PurchaseOrder.Vendor_Name = Convert.ToString(dr["Vendor_Name"]);

            PurchaseOrder.Total_Quantity = Convert.ToInt32(dr["Total_Quantity"]);

            PurchaseOrder.Net_Amount = Convert.ToDecimal(dr["Net_Amount"]);

            PurchaseOrder.Transporter_Id = Convert.ToInt32(dr["Transporter_Id"]);

            PurchaseOrder.Transporter_Name = Convert.ToString(dr["Transporter_Name"]);

            PurchaseOrder.Agent_Id = Convert.ToInt32(dr["Agent_Id"]);

            PurchaseOrder.Agent_Name = Convert.ToString(dr["Agent_Name"]);

            PurchaseOrder.Start_Supply_Date = Convert.ToDateTime(dr["Start_Supply_Date"]);

            PurchaseOrder.Stop_Supply_Date = Convert.ToDateTime(dr["Stop_Supply_Date"]);           

            return PurchaseOrder;
        }

        public List<PurchaseOrderInfo> Get_Purchase_Order(ref Pagination_Info Pager, string Purchase_Order_No)
        {
            List<PurchaseOrderInfo> PurchaseOrders = new List<PurchaseOrderInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Purchase_Order_No", Purchase_Order_No));

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_Get_Purchase_Orders_Detalis.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref Pager))
        {
                PurchaseOrders.Add(Get_Purchase_Order_Value(dr));
            }

            return PurchaseOrders;
        }

        //public DataTable Get_Purchase_Orders(QueryInfo query_Details)
        //{
        //    return sqlHelper.Get_Table_With_Where(query_Details);
        //}      

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

        public List<ColorInfo> Get_Color_By_Vendor_Id(int Vendor_Id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Vendor_Id", Vendor_Id));

            List<ColorInfo> Colors = new List<ColorInfo>();
            DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Color_By_Vendor_Id.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in dt.Rows)
            {
                ColorInfo Color = new ColorInfo();

                Color.Colour_Id = Convert.ToInt32(dr["Colour_Id"]);

                Color.Colour = Convert.ToString(dr["Colour_Name"]);

                Colors.Add(Color);
            }
            return Colors;
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

                PurchaseOrder.Colour_Id = Convert.ToInt32(dr["Colour_Id"]);

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

                PurchaseOrder.Branch_Ids = Convert.ToString(dr["Branch_Ids"]);

                PurchaseOrder.Request_Ids = Convert.ToString(dr["PORI_Ids"]);

                PurchaseOrder.Request_Dates = Convert.ToString(dr["PORI_Dates"]);

                PurchaseOrder.Sizes = Get_Consolidate_Purchase_Order_Item_Sizes(PurchaseOrder.Item_Ids);



                PurchaseOrders.Add(PurchaseOrder);

            }

            return PurchaseOrders;
        }


        //*************************************Aditya 28092016************************************

        public List<Sizes> Get_Consolidate_Purchase_Order_Item_Size(string Item_Ids)
        {
            List<Sizes> Size = new List<Sizes>();

            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Item_Ids", Item_Ids));

            DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Consolidate_Purchase_Order_Item_Sizes.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in dt.Rows)
            {
                Sizes Sizes = new Sizes();
                Sizes.Size_Id1 = Convert.ToInt32(dr["Size_Id"]);
                Sizes.Quantity1 = Convert.ToInt32(dr["Quantity"]);
                Sizes.Amount1 = Convert.ToInt32(dr["Amount"]);
                Size.Add(Sizes);
            }

            return Size;
        }

        //*******************************************************************************


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

                //if (!dr.IsNull("Colour_Name"))
                //    purchaseOrderItem.Colour_Name = Convert.ToString(dr["Colour_Name"]);

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

        
        public void SendDemoEmail(PurchaseOrderInfo PurchaseOrder, string attachmentPath)
        {
            
            SendEmailInfo emailData = new SendEmailInfo();

            emailData.ID = PurchaseOrder.Vendor_Id;
            emailData.To_Email_Id = PurchaseOrder.Vendor_Email1;
            emailData.Subject = "Purchase Order Invoice";

            StringBuilder html = new StringBuilder();
            html.Append("<table>");

            html.Append("<tr>");
            html.Append("<td>");
            html.Append("Hi " + PurchaseOrder.Vendor_Name + " ,");
            html.Append("</td>");
            html.Append("</tr>");

            html.Append("<tr>");
            html.Append("<td>");
            html.Append("Purchase Order Invoice attached here");
            html.Append("</td>");
            html.Append("</tr>");

            html.Append("</table>");

            emailData.Body = html.ToString();

            emailData.AttachmentPath = new List<string>() { attachmentPath };

            MyLeoRetailerRepo.Common.CommonMethods.SendMail(emailData);
        }

        public MemoryStream Create_Purchase_Order_Invoice_PDf(PurchaseOrderInfo PurchaseOrder)
        {
            MemoryStream ms = new MemoryStream();

            StringBuilder htmldiv = new StringBuilder();
            StringBuilder htmltbl = new StringBuilder();
            StringBuilder htmltblItem = new StringBuilder();

            htmldiv.Append("<div style='text-align:center'>");
            htmldiv.Append("<label>Company Name</label>");
            htmldiv.Append("<br />");
            htmldiv.Append("<label>Company Address1</label>");
            htmldiv.Append("<br />");
            htmldiv.Append("<label>Company Address2</label>");
            htmldiv.Append("<h5> <b>PURCHASE ORDER</b></h5>");
            htmldiv.Append("</div>");

            htmltbl.Append("<table>");
            htmltbl.Append("<tr>");
            htmltbl.Append("<td>");
            htmltbl.Append("<div>");
            htmltbl.Append("<label>" + PurchaseOrder.Vendor_Name + "</label>");
            htmltbl.Append("<br />");
            htmltbl.Append("<label>" + PurchaseOrder.Vendor_Address + "</label>");
            htmltbl.Append("<br />");
            htmltbl.Append("<label>" + PurchaseOrder.Vendor_Phone1 + "</label>");
            htmltbl.Append("<br />");
            htmltbl.Append("<label>" + PurchaseOrder.Vendor_Phone2 + "</label>");
            htmltbl.Append("<br />");
            htmltbl.Append("<label>" + PurchaseOrder.Vendor_Email1 + "</label>");
            htmltbl.Append("</div>");
            htmltbl.Append("</td>");
            htmltbl.Append("<td>");
            htmltbl.Append("<div>");
            htmltbl.Append("<table border='1' style='width:500;'>");
            htmltbl.Append("<thead>");
            htmltbl.Append("<tr>");
            htmltbl.Append("<th>Po No.</th>");
            htmltbl.Append("<td>" + PurchaseOrder.Purchase_Order_No + "</td>");
            htmltbl.Append("</tr>");//
            htmltbl.Append("<tr>");
            htmltbl.Append("<th>Date</th>");
            htmltbl.Append("<td>" + PurchaseOrder.Purchase_Order_Date.ToShortDateString() + "</td>");
            htmltbl.Append("</tr>");
            htmltbl.Append("<tr>");
            htmltbl.Append("<th>Agent</th>");
            htmltbl.Append("<td>" + PurchaseOrder.Agent_Name + "</td>");
            htmltbl.Append("</tr>");
            htmltbl.Append("<tr>");
            htmltbl.Append("<th>Transport</th>");
            htmltbl.Append("<td>" + PurchaseOrder.Transporter_Name + "</td>");
            htmltbl.Append("</tr>");
            htmltbl.Append("<tr>");
            htmltbl.Append("<th>Delivery At.</th>");
            htmltbl.Append("<td>" + PurchaseOrder.Stop_Supply_Date.ToShortDateString() + "</td>");
            htmltbl.Append("</tr>");
            htmltbl.Append("</thead>");
            htmltbl.Append("</table>");
            htmltbl.Append("</div>");
            htmltbl.Append("<br />");
            htmltbl.Append("</td>");
            htmltbl.Append("</tr>");
            htmltbl.Append("</table>");

            htmltblItem.Append("<div>");
            htmltblItem.Append("<table border='1'>");
            htmltblItem.Append("<tr>");
            htmltblItem.Append("<th>Article No.</th>");
            htmltblItem.Append("<th>1</th><th>2</th><th>3</th><th>4</th><th>5</th><th>6</th><th>7</th><th>8</th><th>9</th><th>10</th><th>11</th><th>12</th><th>13</th><th>14</th><th>15</th><th>16</th><th>17</th><th>18</th><th>19</th><th>20</th>");
            htmltblItem.Append("<th>QTY</th><th>Center Size</th><th>Size Diff</th><th>Base Rate</th><th>Total Amount</th>");
            htmltblItem.Append("</tr>");
            if (PurchaseOrder.PurchaseOrderItems.Count > 0)
            {
                foreach (var item in PurchaseOrder.PurchaseOrderItems)
                {
                    int colspan = 20;
                    if (item.sizes.Count > 0)
                    {
                        colspan = colspan - item.sizes.Count;
                        htmltblItem.Append("<tr>");
                        htmltblItem.Append("<td></td>");
                        foreach (var itm in item.sizes)
                        {
                            htmltblItem.Append("<td>" + itm.Size_Name + "</td>");
                        }
                        int sizecolspan = 25 - item.sizes.Count;
                        htmltblItem.Append("<td colspan='" + sizecolspan + "'></td>");
                        htmltblItem.Append("</tr>");
                    }

                    htmltblItem.Append("<tr>");

                    htmltblItem.Append("<td>" + item.Article_No + "</td>");
                    if (item.sizes.Count > 0)
                    {
                        foreach (var itm in item.sizes)
                        {
                            htmltblItem.Append("<td>" + itm.Quantity1 + "</td>");
                        }
                    }
                    htmltblItem.Append("<td colspan='" + colspan + "'></td>");
                    htmltblItem.Append("<td>" + item.Total_Quantity + "</td>");
                    htmltblItem.Append("<td>" + item.Center_Size + "</td>");
                    htmltblItem.Append("<td>" + item.Size_Difference + "</td>");
                    htmltblItem.Append("<td>" + item.Purchase_Price + "</td>");
                    htmltblItem.Append("<td>" + item.Total_Amount + "</td>");
                    htmltblItem.Append("</tr>");
                }
                htmltblItem.Append("<tr></tr>");
            }
            htmltblItem.Append("<tr>");
            htmltblItem.Append("<td colspan='16'>Remark : " + PurchaseOrder.Comment + "</td>");
            htmltblItem.Append("<td colspan='5'>Total : </td>");
            htmltblItem.Append("<td>" + PurchaseOrder.PurchaseOrderItems.Sum(a => a.Total_Quantity) + "</td>");
            htmltblItem.Append("<td colspan='3'></td>");
            htmltblItem.Append("<td>" + PurchaseOrder.PurchaseOrderItems.Sum(a => a.Total_Amount) + "</td>");
            htmltblItem.Append("</tr>");

            htmltblItem.Append("<tr>");
            htmltblItem.Append("<td colspan='26'>Amount(In words) : " + PurchaseOrder.Total_Amount_In_Word + "</td>");
            htmltblItem.Append("</tr>");
            htmltblItem.Append("</table>");
            htmltblItem.Append("</div>");
            htmltblItem.Append("<br />");

            using (ms = new MemoryStream())
            {
                iTextSharp.text.Font font = iTextSharp.text.FontFactory.GetFont("Courier", 1.4f, Font.NORMAL);
                iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 25, 25, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(document, ms);

                document.Open();
                iTextSharp.text.Paragraph pCompanyName = new iTextSharp.text.Paragraph("Invoice");
                pCompanyName.Alignment = iTextSharp.text.Element.ALIGN_CENTER;

                pCompanyName.Font = font;
                document.Add(pCompanyName);
                document.Add(new iTextSharp.text.Paragraph("\n"));

                iTextSharp.text.Paragraph AddLine = new iTextSharp.text.Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                document.Add(AddLine);

                document.Add(new iTextSharp.text.Paragraph("\n"));

                foreach (IElement element in iTextSharp.text.html.simpleparser.HTMLWorker.ParseToList(new StringReader(htmldiv.ToString()), null))
                {
                    document.Add(element);
                }

                document.Add(new iTextSharp.text.Paragraph("\n"));

                foreach (IElement element in iTextSharp.text.html.simpleparser.HTMLWorker.ParseToList(new StringReader(htmltbl.ToString()), null))
                {
                    document.Add(new iTextSharp.text.Paragraph("\n"));
                    document.Add(element);
                }

                foreach (IElement element in iTextSharp.text.html.simpleparser.HTMLWorker.ParseToList(new StringReader(htmltblItem.ToString()), null))
                {
                    document.Add(new iTextSharp.text.Paragraph("\n"));
                    document.Add(element);
                }
              
                document.Close();
                writer.Close();

            }

            return ms;
        }


    }
}
