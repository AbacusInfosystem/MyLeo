using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerInfo.PurchaseReturnRequest;
using MyLeoRetailerRepo.Common;
using MyLeoRetailerRepo.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MyLeoRetailerRepo
{
    public class PurchaseReturnRequestRepo
    {

        SQL_Repo _sqlRepo;

        public PurchaseReturnRequestRepo()
        {
            _sqlRepo = new SQL_Repo();
        }

        public void Insert_Purchase_Return_Request(PurchaseReturnRequestInfo purchasereturnrequest)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                int ID = Convert.ToInt32(_sqlRepo.ExecuteScalerObj(Set_Values_In_Purchase_Return_Request(purchasereturnrequest), Storeprocedures.sp_Insert_Purchase_Return_Request.ToString(), CommandType.StoredProcedure));

                foreach (var item in purchasereturnrequest.PurchaseReturnRequestItems)
                {
                    item.Purchase_Return_Request_Id = ID;
                    _sqlRepo.ExecuteNonQuery(Set_Values_In_Purchase_Return_Request_Item(item), Storeprocedures.sp_Insert_Purchase_Return_Request_Item.ToString(), CommandType.StoredProcedure);
                }

                scope.Complete();

            }
            
        }

        //public void Update_Purchase_Return_Request(PurchaseReturnRequestInfo purchasereturnrequest)
        //{
        //    _sqlRepo.ExecuteNonQuery(Set_Values_In_Purchase_Return_Request(purchasereturnrequest), Storeprocedures.sp_Update_Purchase_Return_Request.ToString(), CommandType.StoredProcedure);
        //}

        private List<SqlParameter> Set_Values_In_Purchase_Return_Request(PurchaseReturnRequestInfo purchasereturnrequest)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            if (purchasereturnrequest.Purchase_Return_Request_Id != 0)
            {
                sqlParams.Add(new SqlParameter("@Purchase_Return_Request_Id", purchasereturnrequest.Purchase_Return_Request_Id));
            }
            
            sqlParams.Add(new SqlParameter("@Purchase_Invoice_Id", purchasereturnrequest.Purchase_Invoice_Id));
            sqlParams.Add(new SqlParameter("@Vendor_Id", purchasereturnrequest.Vendor_Id));
            sqlParams.Add(new SqlParameter("@Branch_Id", purchasereturnrequest.Branch_Id));
            sqlParams.Add(new SqlParameter("@Total_Quantity", purchasereturnrequest.Total_Quantity));
            sqlParams.Add(new SqlParameter("@Total_Amount", purchasereturnrequest.Total_Amount));
            sqlParams.Add(new SqlParameter("@Discount_Percentage", purchasereturnrequest.Discount_Percentage));
            sqlParams.Add(new SqlParameter("@Discount_Amount", purchasereturnrequest.Discount_Amount));
            sqlParams.Add(new SqlParameter("@Gross_Amount", purchasereturnrequest.Gross_Amount));
            sqlParams.Add(new SqlParameter("@Tax_Percentage", purchasereturnrequest.Tax_Percentage));
            sqlParams.Add(new SqlParameter("@Round_Off_Amount", purchasereturnrequest.Round_Off_Amount));
            sqlParams.Add(new SqlParameter("@Net_Amount", purchasereturnrequest.Net_Amount));
            sqlParams.Add(new SqlParameter("@Status", true));
            sqlParams.Add(new SqlParameter("@Is_Active", true));

            if (purchasereturnrequest.Purchase_Return_Request_Id == 0)
            {
                sqlParams.Add(new SqlParameter("@Created_By", purchasereturnrequest.Created_By));
                sqlParams.Add(new SqlParameter("@Created_Date", purchasereturnrequest.Created_Date));
            }

            sqlParams.Add(new SqlParameter("@Updated_By", purchasereturnrequest.Updated_By));
            sqlParams.Add(new SqlParameter("@Updated_Date", purchasereturnrequest.Updated_Date));

            return sqlParams;
        }

        private List<SqlParameter> Set_Values_In_Purchase_Return_Request_Item(PurchaseReturnRequestItemInfo purchasereturnrequestitem)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            //sqlParams.Add(new SqlParameter("@Purchase_Return_Request_Item_Id", purchasereturnrequestitem.Purchase_Return_Request_Item_Id));
            sqlParams.Add(new SqlParameter("@Purchase_Return_Request_Id", purchasereturnrequestitem.Purchase_Return_Request_Id));
            //sqlParams.Add(new SqlParameter("@Purchase_Invoice_Id", purchasereturnrequestitem.Purchase_Invoice_Id));
            //sqlParams.Add(new SqlParameter("@Purchase_Order_Id", purchasereturnrequestitem.Purchase_Order_Id));
            sqlParams.Add(new SqlParameter("@SKU_Code", purchasereturnrequestitem.SKU_Code));
            sqlParams.Add(new SqlParameter("@Size_Group_Id", purchasereturnrequestitem.Size_Group_Id));
            sqlParams.Add(new SqlParameter("@Size_Id", purchasereturnrequestitem.Size_Id));
            sqlParams.Add(new SqlParameter("@Quantity", purchasereturnrequestitem.Quantity));
            sqlParams.Add(new SqlParameter("@Total_Amount", purchasereturnrequestitem.Amount));
            sqlParams.Add(new SqlParameter("@Created_Date", purchasereturnrequestitem.Created_Date));
            sqlParams.Add(new SqlParameter("@Created_By", purchasereturnrequestitem.Created_By));
            sqlParams.Add(new SqlParameter("@Updated_Date", purchasereturnrequestitem.Updated_Date));
            sqlParams.Add(new SqlParameter("@Updated_By", purchasereturnrequestitem.Updated_By));

            return sqlParams;
        }
    
        private PurchaseReturnRequestItemInfo Get_Purchase_Return_Items_By_SKU_Values(DataRow dr)
        {
            PurchaseReturnRequestItemInfo PurchaseReturnRequestItem = new PurchaseReturnRequestItemInfo();

            if (!dr.IsNull("Article_No"))
            {
                PurchaseReturnRequestItem.Article_No = Convert.ToString(dr["Article_No"]);
            }

            if (!dr.IsNull("Brand_Id"))
            {
                PurchaseReturnRequestItem.Brand_Id = Convert.ToInt32(dr["Brand_Id"]);
            }

            if (!dr.IsNull("Brand_Name"))
            {
                PurchaseReturnRequestItem.Brand = Convert.ToString(dr["Brand_Name"]);
            }

            if (!dr.IsNull("Colour_Id"))
            {
                PurchaseReturnRequestItem.Color_Id = Convert.ToInt32(dr["Colour_Id"]);
            }

            if (!dr.IsNull("Colour_Name"))
            {
                PurchaseReturnRequestItem.Color = Convert.ToString(dr["Colour_Name"]);
            }

            if (!dr.IsNull("Category_Id"))
            {
                PurchaseReturnRequestItem.Category_Id = Convert.ToInt32(dr["Category_Id"]);
            }

            if (!dr.IsNull("Category"))
            {
                PurchaseReturnRequestItem.Category = Convert.ToString(dr["Category"]);
            }

            if (!dr.IsNull("Sub_Category_Id"))
            {
                PurchaseReturnRequestItem.SubCategory_Id = Convert.ToInt32(dr["Sub_Category_Id"]);
            }

            if (!dr.IsNull("Sub_Category"))
            {
                PurchaseReturnRequestItem.SubCategory = Convert.ToString(dr["Sub_Category"]);
            }

            if (!dr.IsNull("Size_Group_Id"))
            {
                PurchaseReturnRequestItem.Size_Group_Id = Convert.ToInt32(dr["Size_Group_Id"]);
            }

            if (!dr.IsNull("Size_Group_Name"))
            {
                PurchaseReturnRequestItem.Size_Group_Name = Convert.ToString(dr["Size_Group_Name"]);
            }

            if (!dr.IsNull("Size_Id"))
            {
                PurchaseReturnRequestItem.Size_Id = Convert.ToInt32(dr["Size_Id"]);
            }

            if (!dr.IsNull("Size_Name"))
            {
                PurchaseReturnRequestItem.Size_Name = Convert.ToString(dr["Size_Name"]);
            }

            if (!dr.IsNull("Purchase_Price"))
            {
                PurchaseReturnRequestItem.WSR_Price = Convert.ToInt32(dr["Purchase_Price"]);
            }

            return PurchaseReturnRequestItem;
        }

        public PurchaseReturnRequestItemInfo Get_Purchase_Return_Item_By_SKU_Code(string SKU_Code)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@SKU_Code", SKU_Code));

            PurchaseReturnRequestItemInfo PurchaseReturnRequestItem = new PurchaseReturnRequestItemInfo();

            DataTable dt = _sqlRepo.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Purchase_Invoice_Items_By_SKU_Code.ToString(), CommandType.StoredProcedure);

            List<DataRow> drList = new List<DataRow>();

            drList = dt.AsEnumerable().ToList();

            foreach (DataRow dr in drList)
            {
                PurchaseReturnRequestItem = Get_Purchase_Return_Items_By_SKU_Values(dr);
            }

            return PurchaseReturnRequestItem;
        }


        public List<PurchaseReturnRequestInfo> Get_Purchase_Return_Requests(ref Pagination_Info Pager, string Branch_Ids, int Vendor_Id)
        {
            List<PurchaseReturnRequestInfo> PurchaseReturnRequests = new List<PurchaseReturnRequestInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Branch_Ids", Branch_Ids));
            sqlParams.Add(new SqlParameter("@Vendor_Id", Vendor_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, Storeprocedures.sp_Get_Purchase_Return_Requests.ToString(), CommandType.StoredProcedure);
            
            //foreach (DataRow dr in dt.Rows)
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref Pager))
            {
                PurchaseReturnRequests.Add(Get_Purchase_Return_Request_Values(dr));
            }

            return PurchaseReturnRequests;
        }

        private PurchaseReturnRequestInfo Get_Purchase_Return_Request_Values(DataRow dr)
        {
            PurchaseReturnRequestInfo purchasereturnrequest = new PurchaseReturnRequestInfo();

            purchasereturnrequest.Purchase_Return_Request_Id = Convert.ToInt32(dr["Purchase_Return_Request_Id"]);
            purchasereturnrequest.Purchase_Invoice_Id = Convert.ToInt32(dr["Purchase_Invoice_Id"]);
            purchasereturnrequest.Vendor_Id = Convert.ToInt32(dr["Vendor_Id"]);
            purchasereturnrequest.Branch_Id = Convert.ToInt32(dr["Branch_Id"]);
            purchasereturnrequest.Total_Quantity = Convert.ToInt32(dr["Total_Quantity"]);
            purchasereturnrequest.Total_Amount = Convert.ToDecimal(dr["Total_Amount"]);
            purchasereturnrequest.Status = Convert.ToBoolean(dr["Status"]);
            purchasereturnrequest.Created_Date = Convert.ToDateTime(dr["Created_Date"]);
            //
            if (!dr.IsNull("Vendor_Name"))
                purchasereturnrequest.Vendor_Name = Convert.ToString(dr["Vendor_Name"]);
            if (!dr.IsNull("Purchase_Invoice_No"))
                purchasereturnrequest.Purchase_Invoice_No = Convert.ToString(dr["Purchase_Invoice_No"]);
            if (!dr.IsNull("Branch_Name"))
                purchasereturnrequest.Branch_Name = Convert.ToString(dr["Branch_Name"]);
            
            return purchasereturnrequest;
        }



    }
}
