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
using System.Transactions;
using MyLeoRetailerRepo.Common;


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

        private PurchaseOrderRequestInfo Get_Purchase_Order_Requests_Values(DataRow dr)
        {
            PurchaseOrderRequestInfo PurchaseOrderRequest = new PurchaseOrderRequestInfo();

            PurchaseOrderRequest.Purchase_Order_Request_Id = Convert.ToInt32(dr["Purchase_Order_Request_Id"]);

            PurchaseOrderRequest.Branch_Name = Convert.ToString(dr["Branch_Name"]);

            PurchaseOrderRequest.Vendor_Id = Convert.ToInt32(dr["Vendor_Id"]);
                     
            PurchaseOrderRequest.Total_Quantity = Convert.ToInt32(dr["Total_Quantity"]);

            PurchaseOrderRequest.Net_Amount = Convert.ToDecimal(dr["Net_Amount"]);

            PurchaseOrderRequest.Status = Convert.ToInt32(dr["Status"]);

            if (PurchaseOrderRequest.Status == 0)
            {
                PurchaseOrderRequest.Status_Flag = "Pending";
            }
            else
            {
                PurchaseOrderRequest.Status_Flag = "Approved";
            }

               
            PurchaseOrderRequest.Vendor_Name = Convert.ToString(dr["Vendor_Name"]);
           
            return PurchaseOrderRequest;
        }

        public int Insert_Purchase_Order_Request(PurchaseOrderRequestInfo PurchaseOrderRequest)
        {

            using (TransactionScope scope = new TransactionScope())
            {
                PurchaseOrderRequest.Purchase_Order_Request_Id = Convert.ToInt32(sqlHelper.ExecuteScalerObj(Set_Values_In_Purchase_Order_Request(PurchaseOrderRequest), Storeprocedures.sp_Insert_Purchase_Order_Request.ToString(), CommandType.StoredProcedure));

                int j = 0;

                foreach (var item in PurchaseOrderRequest.PurchaseOrderRequests)
                {
                    List<SqlParameter> sqlParam = new List<SqlParameter>();

                    sqlParam.Add(new SqlParameter("@Purchase_Order_Request_Id", PurchaseOrderRequest.Purchase_Order_Request_Id));

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

                    sqlParam.Add(new SqlParameter("@Total_Quantity", item.Item_Quantity));

                    sqlParam.Add(new SqlParameter("@Comment", item.Comment));

                    sqlParam.Add(new SqlParameter("@Status", PurchaseOrderRequest.Status));

                    PurchaseOrderRequest.PurchaseOrderRequests[j].Purchase_Order_Request_Item_Id = Convert.ToInt32(sqlHelper.ExecuteScalerObj(sqlParam, Storeprocedures.sp_Insert_Purchase_Order_Request_Item.ToString(), CommandType.StoredProcedure));

                    int i = 0;

                    i++;
                    if (i == 1 && PurchaseOrderRequest.Sizes[j].Quantity1 != 0)
                    {
                        List<SqlParameter> sqlParams = new List<SqlParameter>();

                        sqlParams.Add(new SqlParameter("@Purchase_Order_Request_Item_Id", PurchaseOrderRequest.PurchaseOrderRequests[j].Purchase_Order_Request_Item_Id));
                        sqlParams.Add(new SqlParameter("@Purchase_Order_Request_Id", PurchaseOrderRequest.Purchase_Order_Request_Id));

                        sqlParams.Add(new SqlParameter("@Size_Id", PurchaseOrderRequest.Sizes[j].Size_Id1));
                        sqlParams.Add(new SqlParameter("@Quantity", PurchaseOrderRequest.Sizes[j].Quantity1));
                        sqlParams.Add(new SqlParameter("@Amount", PurchaseOrderRequest.Sizes[j].Amount1));

                        sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Insert_Purchase_Order_Request_Item_Sizes.ToString(), CommandType.StoredProcedure);
                    }

                    i++;
                    if (i == 2 && PurchaseOrderRequest.Sizes[j].Quantity2 != 0)
                    {
                        List<SqlParameter> sqlParams = new List<SqlParameter>();

                        sqlParams.Add(new SqlParameter("@Purchase_Order_Request_Item_Id", PurchaseOrderRequest.PurchaseOrderRequests[j].Purchase_Order_Request_Item_Id));
                        sqlParams.Add(new SqlParameter("@Purchase_Order_Request_Id", PurchaseOrderRequest.Purchase_Order_Request_Id));

                        sqlParams.Add(new SqlParameter("@Size_Id", PurchaseOrderRequest.Sizes[j].Size_Id2));
                        sqlParams.Add(new SqlParameter("@Quantity", PurchaseOrderRequest.Sizes[j].Quantity2));
                        sqlParams.Add(new SqlParameter("@Amount", PurchaseOrderRequest.Sizes[j].Amount2));

                        sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Insert_Purchase_Order_Request_Item_Sizes.ToString(), CommandType.StoredProcedure);
                    }

                    i++;
                    if (i == 3 && PurchaseOrderRequest.Sizes[j].Quantity3 != 0)
                    {
                        List<SqlParameter> sqlParams = new List<SqlParameter>();

                        sqlParams.Add(new SqlParameter("@Purchase_Order_Request_Item_Id", PurchaseOrderRequest.PurchaseOrderRequests[j].Purchase_Order_Request_Item_Id));
                        sqlParams.Add(new SqlParameter("@Purchase_Order_Request_Id", PurchaseOrderRequest.Purchase_Order_Request_Id));

                        sqlParams.Add(new SqlParameter("@Size_Id", PurchaseOrderRequest.Sizes[j].Size_Id3));
                        sqlParams.Add(new SqlParameter("@Quantity", PurchaseOrderRequest.Sizes[j].Quantity3));
                        sqlParams.Add(new SqlParameter("@Amount", PurchaseOrderRequest.Sizes[j].Amount3));

                        sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Insert_Purchase_Order_Request_Item_Sizes.ToString(), CommandType.StoredProcedure);
                    }

                    i++;
                    if (i == 4 && PurchaseOrderRequest.Sizes[j].Quantity4 != 0)
                    {
                        List<SqlParameter> sqlParams = new List<SqlParameter>();

                        sqlParams.Add(new SqlParameter("@Purchase_Order_Request_Item_Id", PurchaseOrderRequest.PurchaseOrderRequests[j].Purchase_Order_Request_Item_Id));
                        sqlParams.Add(new SqlParameter("@Purchase_Order_Request_Id", PurchaseOrderRequest.Purchase_Order_Request_Id));

                        sqlParams.Add(new SqlParameter("@Size_Id", PurchaseOrderRequest.Sizes[j].Size_Id4));
                        sqlParams.Add(new SqlParameter("@Quantity", PurchaseOrderRequest.Sizes[j].Quantity4));
                        sqlParams.Add(new SqlParameter("@Amount", PurchaseOrderRequest.Sizes[j].Amount4));

                        sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Insert_Purchase_Order_Request_Item_Sizes.ToString(), CommandType.StoredProcedure);
                    }

                    i++;
                    if (i == 5 && PurchaseOrderRequest.Sizes[j].Quantity5 != 0)
                    {
                        List<SqlParameter> sqlParams = new List<SqlParameter>();

                        sqlParams.Add(new SqlParameter("@Purchase_Order_Request_Item_Id", PurchaseOrderRequest.PurchaseOrderRequests[j].Purchase_Order_Request_Item_Id));
                        sqlParams.Add(new SqlParameter("@Purchase_Order_Request_Id", PurchaseOrderRequest.Purchase_Order_Request_Id));

                        sqlParams.Add(new SqlParameter("@Size_Id", PurchaseOrderRequest.Sizes[j].Size_Id5));
                        sqlParams.Add(new SqlParameter("@Quantity", PurchaseOrderRequest.Sizes[j].Quantity5));
                        sqlParams.Add(new SqlParameter("@Amount", PurchaseOrderRequest.Sizes[j].Amount5));

                        sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Insert_Purchase_Order_Request_Item_Sizes.ToString(), CommandType.StoredProcedure);
                    }

                    i++;
                    if (i == 6 && PurchaseOrderRequest.Sizes[j].Quantity6 != 0)
                    {
                        List<SqlParameter> sqlParams = new List<SqlParameter>();

                        sqlParams.Add(new SqlParameter("@Purchase_Order_Request_Item_Id", PurchaseOrderRequest.PurchaseOrderRequests[j].Purchase_Order_Request_Item_Id));
                        sqlParams.Add(new SqlParameter("@Purchase_Order_Request_Id", PurchaseOrderRequest.Purchase_Order_Request_Id));

                        sqlParams.Add(new SqlParameter("@Size_Id", PurchaseOrderRequest.Sizes[j].Size_Id6));
                        sqlParams.Add(new SqlParameter("@Quantity", PurchaseOrderRequest.Sizes[j].Quantity6));
                        sqlParams.Add(new SqlParameter("@Amount", PurchaseOrderRequest.Sizes[j].Amount6));

                        sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Insert_Purchase_Order_Request_Item_Sizes.ToString(), CommandType.StoredProcedure);
                    }

                    i++;
                    if (i == 7 && PurchaseOrderRequest.Sizes[j].Quantity7 != 0)
                    {
                        List<SqlParameter> sqlParams = new List<SqlParameter>();

                        sqlParams.Add(new SqlParameter("@Purchase_Order_Request_Item_Id", PurchaseOrderRequest.PurchaseOrderRequests[j].Purchase_Order_Request_Item_Id));
                        sqlParams.Add(new SqlParameter("@Purchase_Order_Request_Id", PurchaseOrderRequest.Purchase_Order_Request_Id));

                        sqlParams.Add(new SqlParameter("@Size_Id", PurchaseOrderRequest.Sizes[j].Size_Id7));
                        sqlParams.Add(new SqlParameter("@Quantity", PurchaseOrderRequest.Sizes[j].Quantity7));
                        sqlParams.Add(new SqlParameter("@Amount", PurchaseOrderRequest.Sizes[j].Amount7));

                        sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Insert_Purchase_Order_Request_Item_Sizes.ToString(), CommandType.StoredProcedure);
                    }

                    i++;
                    if (i == 8 && PurchaseOrderRequest.Sizes[j].Quantity8 != 0)
                    {
                        List<SqlParameter> sqlParams = new List<SqlParameter>();

                        sqlParams.Add(new SqlParameter("@Purchase_Order_Request_Item_Id", PurchaseOrderRequest.PurchaseOrderRequests[j].Purchase_Order_Request_Item_Id));
                        sqlParams.Add(new SqlParameter("@Purchase_Order_Request_Id", PurchaseOrderRequest.Purchase_Order_Request_Id));

                        sqlParams.Add(new SqlParameter("@Size_Id", PurchaseOrderRequest.Sizes[j].Size_Id8));
                        sqlParams.Add(new SqlParameter("@Quantity", PurchaseOrderRequest.Sizes[j].Quantity8));
                        sqlParams.Add(new SqlParameter("@Amount", PurchaseOrderRequest.Sizes[j].Amount8));

                        sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Insert_Purchase_Order_Request_Item_Sizes.ToString(), CommandType.StoredProcedure);
                    }

                    i++;
                    if (i == 9 && PurchaseOrderRequest.Sizes[j].Quantity9 != 0)
                    {
                        List<SqlParameter> sqlParams = new List<SqlParameter>();

                        sqlParams.Add(new SqlParameter("@Purchase_Order_Request_Item_Id", PurchaseOrderRequest.PurchaseOrderRequests[j].Purchase_Order_Request_Item_Id));
                        sqlParams.Add(new SqlParameter("@Purchase_Order_Request_Id", PurchaseOrderRequest.Purchase_Order_Request_Id));

                        sqlParams.Add(new SqlParameter("@Size_Id", PurchaseOrderRequest.Sizes[j].Size_Id9));
                        sqlParams.Add(new SqlParameter("@Quantity", PurchaseOrderRequest.Sizes[j].Quantity9));
                        sqlParams.Add(new SqlParameter("@Amount", PurchaseOrderRequest.Sizes[j].Amount9));

                        sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Insert_Purchase_Order_Request_Item_Sizes.ToString(), CommandType.StoredProcedure);
                    }

                    i++;
                    if (i == 10 && PurchaseOrderRequest.Sizes[j].Quantity10 != 0)
                    {
                        List<SqlParameter> sqlParams = new List<SqlParameter>();

                        sqlParams.Add(new SqlParameter("@Purchase_Order_Request_Item_Id", PurchaseOrderRequest.PurchaseOrderRequests[j].Purchase_Order_Request_Item_Id));
                        sqlParams.Add(new SqlParameter("@Purchase_Order_Request_Id", PurchaseOrderRequest.Purchase_Order_Request_Id));

                        sqlParams.Add(new SqlParameter("@Size_Id", PurchaseOrderRequest.Sizes[j].Size_Id10));
                        sqlParams.Add(new SqlParameter("@Quantity", PurchaseOrderRequest.Sizes[j].Quantity10));
                        sqlParams.Add(new SqlParameter("@Amount", PurchaseOrderRequest.Sizes[j].Amount10));

                        sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Insert_Purchase_Order_Request_Item_Sizes.ToString(), CommandType.StoredProcedure);
                    }

                    i++;
                    if (i == 11 && PurchaseOrderRequest.Sizes[j].Quantity11 != 0)
                    {
                        List<SqlParameter> sqlParams = new List<SqlParameter>();

                        sqlParams.Add(new SqlParameter("@Purchase_Order_Request_Item_Id", PurchaseOrderRequest.PurchaseOrderRequests[j].Purchase_Order_Request_Item_Id));
                        sqlParams.Add(new SqlParameter("@Purchase_Order_Request_Id", PurchaseOrderRequest.Purchase_Order_Request_Id));

                        sqlParams.Add(new SqlParameter("@Size_Id", PurchaseOrderRequest.Sizes[j].Size_Id11));
                        sqlParams.Add(new SqlParameter("@Quantity", PurchaseOrderRequest.Sizes[j].Quantity11));
                        sqlParams.Add(new SqlParameter("@Amount", PurchaseOrderRequest.Sizes[j].Amount11));

                        sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Insert_Purchase_Order_Request_Item_Sizes.ToString(), CommandType.StoredProcedure);
                    }

                    i++;
                    if (i == 12 && PurchaseOrderRequest.Sizes[j].Quantity12 != 0)
                    {
                        List<SqlParameter> sqlParams = new List<SqlParameter>();

                        sqlParams.Add(new SqlParameter("@Purchase_Order_Request_Item_Id", PurchaseOrderRequest.PurchaseOrderRequests[j].Purchase_Order_Request_Item_Id));
                        sqlParams.Add(new SqlParameter("@Purchase_Order_Request_Id", PurchaseOrderRequest.Purchase_Order_Request_Id));

                        sqlParams.Add(new SqlParameter("@Size_Id", PurchaseOrderRequest.Sizes[j].Size_Id12));
                        sqlParams.Add(new SqlParameter("@Quantity", PurchaseOrderRequest.Sizes[j].Quantity12));
                        sqlParams.Add(new SqlParameter("@Amount", PurchaseOrderRequest.Sizes[j].Amount12));

                        sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Insert_Purchase_Order_Request_Item_Sizes.ToString(), CommandType.StoredProcedure);
                    }

                    i++;
                    if (i == 13 && PurchaseOrderRequest.Sizes[j].Quantity13 != 0)
                    {
                        List<SqlParameter> sqlParams = new List<SqlParameter>();

                        sqlParams.Add(new SqlParameter("@Purchase_Order_Request_Item_Id", PurchaseOrderRequest.PurchaseOrderRequests[j].Purchase_Order_Request_Item_Id));
                        sqlParams.Add(new SqlParameter("@Purchase_Order_Request_Id", PurchaseOrderRequest.Purchase_Order_Request_Id));

                        sqlParams.Add(new SqlParameter("@Size_Id", PurchaseOrderRequest.Sizes[j].Size_Id13));
                        sqlParams.Add(new SqlParameter("@Quantity", PurchaseOrderRequest.Sizes[j].Quantity13));
                        sqlParams.Add(new SqlParameter("@Amount", PurchaseOrderRequest.Sizes[j].Amount13));

                        sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Insert_Purchase_Order_Request_Item_Sizes.ToString(), CommandType.StoredProcedure);
                    }

                    i++;
                    if (i == 14 && PurchaseOrderRequest.Sizes[j].Quantity14 != 0)
                    {
                        List<SqlParameter> sqlParams = new List<SqlParameter>();

                        sqlParams.Add(new SqlParameter("@Purchase_Order_Request_Item_Id", PurchaseOrderRequest.PurchaseOrderRequests[j].Purchase_Order_Request_Item_Id));
                        sqlParams.Add(new SqlParameter("@Purchase_Order_Request_Id", PurchaseOrderRequest.Purchase_Order_Request_Id));

                        sqlParams.Add(new SqlParameter("@Size_Id", PurchaseOrderRequest.Sizes[j].Size_Id14));
                        sqlParams.Add(new SqlParameter("@Quantity", PurchaseOrderRequest.Sizes[j].Quantity14));
                        sqlParams.Add(new SqlParameter("@Amount", PurchaseOrderRequest.Sizes[j].Amount14));

                        sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Insert_Purchase_Order_Request_Item_Sizes.ToString(), CommandType.StoredProcedure);
                    }

                    i++;
                    if (i == 15 && PurchaseOrderRequest.Sizes[j].Quantity15 != 0)
                    {
                        List<SqlParameter> sqlParams = new List<SqlParameter>();

                        sqlParams.Add(new SqlParameter("@Purchase_Order_Request_Item_Id", PurchaseOrderRequest.PurchaseOrderRequests[j].Purchase_Order_Request_Item_Id));
                        sqlParams.Add(new SqlParameter("@Purchase_Order_Request_Id", PurchaseOrderRequest.Purchase_Order_Request_Id));

                        sqlParams.Add(new SqlParameter("@Size_Id", PurchaseOrderRequest.Sizes[j].Size_Id15));
                        sqlParams.Add(new SqlParameter("@Quantity", PurchaseOrderRequest.Sizes[j].Quantity15));
                        sqlParams.Add(new SqlParameter("@Amount", PurchaseOrderRequest.Sizes[j].Amount15));

                        sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Insert_Purchase_Order_Request_Item_Sizes.ToString(), CommandType.StoredProcedure);
                    }

                    j++;
                }

                scope.Complete();

            }

            
            
            return PurchaseOrderRequest.Purchase_Order_Request_Id;
        }

        public DataTable Get_Purchase_Order_Requests(Filter_Purchase_Order_Request filter, string Branch_Id)
        {

            DataTable dt = new DataTable();

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@Vendor_Id", filter.Vendor_Id));

            sqlParam.Add(new SqlParameter("@Branch_Id", Branch_Id));

            dt = sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.sp_Get_Purchase_Order_Requests.ToString(), CommandType.StoredProcedure);

            return dt;
        }

        public List<PurchaseOrderRequestInfo> Get_Purchase_Order_Request_List(ref Pagination_Info Pager, string Branch_Id, int Vendor_Id)
        {
            List<PurchaseOrderRequestInfo> PurchaseOrderRequest = new List<PurchaseOrderRequestInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Vendor_Id", Vendor_Id));

            sqlParams.Add(new SqlParameter("@Branch_Id", Branch_Id));

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_Get_Purchase_Order_Requests.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref Pager))
            {
                PurchaseOrderRequest.Add(Get_Purchase_Order_Requests_Values(dr));
            }

            return PurchaseOrderRequest;
        }

        //**********************************************************************///

        public PurchaseOrderRequestInfo Get_Purchase_Order_Request_Details_By_Id(int Purchase_Order_Request_Id)
        {
            PurchaseOrderRequestInfo purchaseOrderRequest = new PurchaseOrderRequestInfo();

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Purchase_Order_Request_Id", Purchase_Order_Request_Id));

            DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Purchase_Order_Request_Details_By_Id.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in dt.Rows)
            {
                purchaseOrderRequest.Purchase_Order_Request_Id = Convert.ToInt32(dr["Purchase_Order_Request_Id"]);


                if (!dr.IsNull("Branch_Id"))
                    purchaseOrderRequest.Branch_Id = Convert.ToInt32(dr["Branch_Id"]);

                if (!dr.IsNull("Vendor_Id"))
                    purchaseOrderRequest.Vendor_Id = Convert.ToInt32(dr["Vendor_Id"]);

                if (!dr.IsNull("Vendor_Name"))
                    purchaseOrderRequest.Vendor_Name = Convert.ToString(dr["Vendor_Name"]);

                if (!dr.IsNull("Branch_Name"))
                    purchaseOrderRequest.Branch_Name = Convert.ToString(dr["Branch_Name"]);

                if (!dr.IsNull("Total_Quantity"))
                    purchaseOrderRequest.Total_Quantity = Convert.ToInt32(dr["Total_Quantity"]);

                if (!dr.IsNull("Net_Amount"))
                    purchaseOrderRequest.Net_Amount = Convert.ToDecimal(dr["Net_Amount"]);

            }

            return purchaseOrderRequest;
        }

        public List<PurchaseOrderRequestItemInfo> Get_Purchase_Order_Request_Items(int Purchase_Order_Request_Id)
        {
            List<PurchaseOrderRequestItemInfo> purchaseOrderRequestItems = new List<PurchaseOrderRequestItemInfo>();

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Purchase_Order_Request_Id", Purchase_Order_Request_Id));

            DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Purchase_Order_Request_Items.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in dt.Rows)
            {
                PurchaseOrderRequestItemInfo purchaseOrderRequestItem = new PurchaseOrderRequestItemInfo();

                purchaseOrderRequestItem.Purchase_Order_Request_Item_Id = Convert.ToInt32(dr["Purchase_Order_Request_Item_Id"]);

                purchaseOrderRequestItem.Purchase_Order_Request_Id = Convert.ToInt32(dr["Purchase_Order_Request_Id"]);

                if (!dr.IsNull("Article_No"))
                    purchaseOrderRequestItem.Article_No = Convert.ToString(dr["Article_No"]);

                if (!dr.IsNull("Colour_Name"))
                    purchaseOrderRequestItem.Colour_Name = Convert.ToString(dr["Colour_Name"]);

                if (!dr.IsNull("Start_Size"))
                    purchaseOrderRequestItem.Start_Size = Convert.ToString(dr["Start_Size"]);

                if (!dr.IsNull("End_Size"))
                    purchaseOrderRequestItem.End_Size = Convert.ToString(dr["End_Size"]);

                if (!dr.IsNull("Center_Size"))
                    purchaseOrderRequestItem.Center_Size = Convert.ToString(dr["Center_Size"]);

                if (!dr.IsNull("Purchase_Price"))
                    purchaseOrderRequestItem.Purchase_Price = Convert.ToDecimal(dr["Purchase_Price"]);

                if (!dr.IsNull("Size_Difference"))
                    purchaseOrderRequestItem.Size_Difference = Convert.ToDecimal(dr["Size_Difference"]);

                if (!dr.IsNull("Total_Amount"))
                    purchaseOrderRequestItem.Total_Amount = Convert.ToDecimal(dr["Total_Amount"]);

                if (!dr.IsNull("Comment"))
                    purchaseOrderRequestItem.Comment = Convert.ToString(dr["Comment"]);

                if (!dr.IsNull("Brand_Id"))
                    purchaseOrderRequestItem.Brand_Id = Convert.ToInt32(dr["Brand_Id"]);

                if (!dr.IsNull("Brand_Name"))
                    purchaseOrderRequestItem.Brand_Name = Convert.ToString(dr["Brand_Name"]);

                if (!dr.IsNull("Category_Id"))
                    purchaseOrderRequestItem.Category_Id = Convert.ToInt32(dr["Category_Id"]);

                if (!dr.IsNull("Category"))
                    purchaseOrderRequestItem.Category = Convert.ToString(dr["Category"]);

                if (!dr.IsNull("Sub_Category_Id"))
                    purchaseOrderRequestItem.Sub_Category_Id = Convert.ToInt32(dr["Sub_Category_Id"]);

                if (!dr.IsNull("Sub_Category"))
                    purchaseOrderRequestItem.Sub_Category = Convert.ToString(dr["Sub_Category"]);

                if (!dr.IsNull("Size_Group_Id"))
                    purchaseOrderRequestItem.Size_Group_Id = Convert.ToInt32(dr["Size_Group_Id"]);

                if (!dr.IsNull("Size_Group_Name"))
                    purchaseOrderRequestItem.Size_Group_Name = Convert.ToString(dr["Size_Group_Name"]);

                purchaseOrderRequestItem.sizes = Get_Purchase_Order_Request_Item_Sizes(purchaseOrderRequestItem.Purchase_Order_Request_Item_Id);

                purchaseOrderRequestItem.Total_Quantity = purchaseOrderRequestItem.sizes.Sum(a => a.Quantity1);

                purchaseOrderRequestItems.Add(purchaseOrderRequestItem);
            }

            return purchaseOrderRequestItems;
        }

        private List<Sizes> Get_Purchase_Order_Request_Item_Sizes(int Purchase_Order_Request_Item_Id)
        {
            List<Sizes> sizes = new List<Sizes>();

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Purchase_Order_Request_Item_Id", Purchase_Order_Request_Item_Id));

            DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Purchase_Order_Request_Item_Sizes.ToString(), CommandType.StoredProcedure);

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

        //public DataTable Get_Purchase_Order_Requests(QueryInfo query_Details)
        //{
        //    return sqlHelper.Get_Table_With_Where(query_Details);
        //}               

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