using MyLeoRetailerInfo.PurchaseReturn;
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
using System.Transactions;
using MyLeoRetailerRepo.Common;

namespace MyLeoRetailerRepo
{
    public class PurchaseReturnRepo
    {
         SQL_Repo sqlHelper = null;

         public PurchaseReturnRepo()
        {
            sqlHelper = new SQL_Repo();
        }

        private List<SqlParameter> Set_Values_In_Purchase_Return(PurchaseReturnInfo PurchaseReturn)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            if (PurchaseReturn.Purchase_Return_Id != 0)
            {
                sqlParams.Add(new SqlParameter("@Purchase_Return_Id", PurchaseReturn.Purchase_Return_Id));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Created_By", PurchaseReturn.Created_By));

                sqlParams.Add(new SqlParameter("@Created_Date", PurchaseReturn.Created_Date));
            }

            sqlParams.Add(new SqlParameter("@Debit_Note_No", PurchaseReturn.Debit_Note_No));

            sqlParams.Add(new SqlParameter("@GR_No", PurchaseReturn.GR_No));

            sqlParams.Add(new SqlParameter("@Vendor_Id", PurchaseReturn.Vendor_Id));

            sqlParams.Add(new SqlParameter("@Purchase_Invoice_Id", PurchaseReturn.Purchase_Invoice_Id));

            sqlParams.Add(new SqlParameter("@Purchase_Return_Date", PurchaseReturn.Purchase_Return_Date));
                       
            sqlParams.Add(new SqlParameter("@Total_Quantity", PurchaseReturn.Total_Quantity));

            sqlParams.Add(new SqlParameter("@Total_Amount", PurchaseReturn.Total_Amount));
            
            sqlParams.Add(new SqlParameter("@Discount_Percentage", PurchaseReturn.Discount_Percentage));

            sqlParams.Add(new SqlParameter("@Discount_Amount", PurchaseReturn.Discount_Amount));

            sqlParams.Add(new SqlParameter("@Gross_Amount", PurchaseReturn.Gross_Amount));

            sqlParams.Add(new SqlParameter("@Tax_Percentage", PurchaseReturn.Tax_Percentage));

            sqlParams.Add(new SqlParameter("@Round_Off_Amount", PurchaseReturn.Round_Off_Amount));

            sqlParams.Add(new SqlParameter("@Net_Amount", PurchaseReturn.Net_Amount));

            sqlParams.Add(new SqlParameter("@Logistics_Person_Name", PurchaseReturn.Logistics_Person_Name));
           
            sqlParams.Add(new SqlParameter("@Transporter_Id", PurchaseReturn.Transporter_Id));

            sqlParams.Add(new SqlParameter("@Lr_No", PurchaseReturn.Lr_No));

            if (PurchaseReturn.Lr_Date != DateTime.MinValue)
            {
                sqlParams.Add(new SqlParameter("@Lr_Date", PurchaseReturn.Lr_Date));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Lr_Date", DateTime.MinValue));
            }

            sqlParams.Add(new SqlParameter("@Updated_By", PurchaseReturn.Updated_By));

            sqlParams.Add(new SqlParameter("@Updated_Date", PurchaseReturn.Updated_Date));

            return sqlParams;
        }

        private List<SqlParameter> Set_Values_In_Purchase_Return_Item(PurchaseReturnInfo item)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Purchase_Return_Id", item.Purchase_Return_Id));

            sqlParams.Add(new SqlParameter("@Purchase_Invoice_Id", item.Purchase_Invoice_Id));

            sqlParams.Add(new SqlParameter("@Purchase_Order_Id", item.Purchase_Order_Id));

            sqlParams.Add(new SqlParameter("@SKU_Code", item.SKU_Code));

            sqlParams.Add(new SqlParameter("@Size_Group_Id", item.Size_Group_Id));

            sqlParams.Add(new SqlParameter("@Size_Id", item.Size_Id));

            sqlParams.Add(new SqlParameter("@Quantity", item.Quantity));

            sqlParams.Add(new SqlParameter("@Total_Amount", item.Amount));

            sqlParams.Add(new SqlParameter("@Created_By", item.Created_By));

            sqlParams.Add(new SqlParameter("@Created_Date", item.Created_Date));

            sqlParams.Add(new SqlParameter("@Updated_By", item.Updated_By));

            sqlParams.Add(new SqlParameter("@Updated_Date", item.Updated_Date));

            return sqlParams;
        }

        private List<SqlParameter> Set_Values_In_Purchase_Credit_Note(PurchaseReturnInfo PurchaseReturn)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Purchase_Return_Id", PurchaseReturn.Purchase_Return_Id));

            sqlParams.Add(new SqlParameter("@Status", 1));

            sqlParams.Add(new SqlParameter("@Credit_Note_No", PurchaseReturn.Credit_Note_No));

            sqlParams.Add(new SqlParameter("@Credit_Note_Type", 1));

            sqlParams.Add(new SqlParameter("@Credit_Note_Amount", PurchaseReturn.Net_Amount));

            sqlParams.Add(new SqlParameter("@Created_By", PurchaseReturn.Created_By));

            sqlParams.Add(new SqlParameter("@Created_Date", PurchaseReturn.Created_Date));

            sqlParams.Add(new SqlParameter("@Updated_By", PurchaseReturn.Updated_By));

            sqlParams.Add(new SqlParameter("@Updated_Date", PurchaseReturn.Updated_Date));

            return sqlParams;
        }

        private PurchaseReturnInfo Get_Purchase_Return_Items_By_SKU_Values(DataRow dr)
        {
            PurchaseReturnInfo PurchaseReturn = new PurchaseReturnInfo();

            if (!dr.IsNull("Article_No"))
            {
                PurchaseReturn.Article_No = Convert.ToString(dr["Article_No"]);
            }

            if (!dr.IsNull("Brand_Id"))
            {
                PurchaseReturn.Brand_Id = Convert.ToInt32(dr["Brand_Id"]);
            }

            if (!dr.IsNull("Brand_Name"))
            {
                PurchaseReturn.Brand = Convert.ToString(dr["Brand_Name"]);
            }

            if (!dr.IsNull("Colour_Id"))
            {
                PurchaseReturn.Color_Id = Convert.ToInt32(dr["Colour_Id"]);
            }

            if (!dr.IsNull("Colour_Name"))
            {
                PurchaseReturn.Color = Convert.ToString(dr["Colour_Name"]);
            }

            if (!dr.IsNull("Category_Id"))
            {
                PurchaseReturn.Category_Id = Convert.ToInt32(dr["Category_Id"]);
            }

            if (!dr.IsNull("Category"))
            {
                PurchaseReturn.Category = Convert.ToString(dr["Category"]);
            }

            if (!dr.IsNull("Sub_Category_Id"))
            {
                PurchaseReturn.SubCategory_Id = Convert.ToInt32(dr["Sub_Category_Id"]);
            }

            if (!dr.IsNull("Sub_Category"))
            {
                PurchaseReturn.SubCategory = Convert.ToString(dr["Sub_Category"]);
            }

            if (!dr.IsNull("Size_Group_Id"))
            {
                PurchaseReturn.Size_Group_Id = Convert.ToInt32(dr["Size_Group_Id"]);
            }

            if (!dr.IsNull("Size_Group_Name"))
            {
                PurchaseReturn.Size_Group_Name = Convert.ToString(dr["Size_Group_Name"]);
            }

            if (!dr.IsNull("Size_Id"))
            {
                PurchaseReturn.Size_Id = Convert.ToInt32(dr["Size_Id"]);
            }

            if (!dr.IsNull("Size_Name"))
            {
                PurchaseReturn.Size_Name = Convert.ToString(dr["Size_Name"]);
            }

            if (!dr.IsNull("Purchase_Price"))
            {
                PurchaseReturn.WSR_Price = Convert.ToInt32(dr["Purchase_Price"]);
            }

            return PurchaseReturn;
        }
       
        public PurchaseReturnInfo Get_Purchase_Return_Items_By_SKU_Code(string SKU_Code)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@SKU_Code", SKU_Code));

            PurchaseReturnInfo PurchaseReturn = new PurchaseReturnInfo();

            DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Purchase_Invoice_Items_By_SKU_Code.ToString(), CommandType.StoredProcedure);

            List<DataRow> drList = new List<DataRow>();

            drList = dt.AsEnumerable().ToList();

            foreach (DataRow dr in drList)
            {
                PurchaseReturn = Get_Purchase_Return_Items_By_SKU_Values(dr);
            }

            return PurchaseReturn;
        }

        private PurchaseReturnInfo Get_Purchase_Return_Values(DataRow dr)
        {
            PurchaseReturnInfo PurchaseReturn = new PurchaseReturnInfo();

            PurchaseReturn.Purchase_Return_Id = Convert.ToInt32(dr["Purchase_Return_Id"]);

            PurchaseReturn.Debit_Note_No = Convert.ToString(dr["Debit_Note_No"]);

            PurchaseReturn.GR_No = Convert.ToString(dr["GR_No"]);

            PurchaseReturn.Purchase_Invoice_Id = Convert.ToInt32(dr["Purchase_Invoice_Id"]);

            PurchaseReturn.Vendor_Id = Convert.ToInt32(dr["Vendor_Id"]);

            PurchaseReturn.Total_Quantity = Convert.ToInt32(dr["Total_Quantity"]);

            PurchaseReturn.Total_Amount = Convert.ToDecimal(dr["Net_Amount"]);

            PurchaseReturn.Transporter_Id = Convert.ToInt32(dr["Transporter_Id"]);

            PurchaseReturn.Transporter_Name = Convert.ToString(dr["Transporter_Name"]);

            PurchaseReturn.Logistics_Person_Name = Convert.ToString(dr["Logistics_Person_Name"]);

            PurchaseReturn.Lr_No = Convert.ToString(dr["Lr_No"]);

            PurchaseReturn.Purchase_Return_Date = Convert.ToDateTime(dr["Purchase_Return_Date"]);
           
            if (!dr.IsNull("Vendor_Name"))
            {
                PurchaseReturn.Vendor_Name = Convert.ToString(dr["Vendor_Name"]);
            }

            if (!dr.IsNull("Purchase_Invoice_No"))
            {
                PurchaseReturn.Purchase_Invoice_No = Convert.ToString(dr["Purchase_Invoice_No"]);
            }

            return PurchaseReturn;
        }
               
        public int Insert_Purchase_Return(PurchaseReturnInfo PurchaseReturn)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                PurchaseReturn.Purchase_Return_Id = Convert.ToInt32(sqlHelper.ExecuteScalerObj(Set_Values_In_Purchase_Return(PurchaseReturn), Storeprocedures.sp_Insert_Purchase_Return.ToString(), CommandType.StoredProcedure));

                foreach (var item in PurchaseReturn.PurchaseReturns)
                {
                    item.Purchase_Return_Id = PurchaseReturn.Purchase_Return_Id;

                    item.Purchase_Invoice_Id = PurchaseReturn.Purchase_Invoice_Id;

                    sqlHelper.ExecuteNonQuery(Set_Values_In_Purchase_Return_Item(item), Storeprocedures.sp_Insert_Purchase_Return_Item.ToString(), CommandType.StoredProcedure);
                }

                sqlHelper.ExecuteScalerObj(Set_Values_In_Purchase_Credit_Note(PurchaseReturn), Storeprocedures.sp_Insert_Purchase_Credit_Note.ToString(), CommandType.StoredProcedure);
               
                scope.Complete();

            }
            
            return PurchaseReturn.Purchase_Return_Id;

        }

        public DataTable Get_Purchase_Returns(Filter_Purchase_Return filter)
        {

            DataTable dt = new DataTable();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Debit_Note_No", filter.Debit_Note_No));

            dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_Get_Purchase_Returns.ToString(), CommandType.StoredProcedure);

            return dt;
        }


        public List<PurchaseReturnInfo> Get_Purchase_Return_List(ref Pagination_Info Pager, string Debit_Note_No)
        {
            List<PurchaseReturnInfo> PurchaseReturns = new List<PurchaseReturnInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Debit_Note_No", Debit_Note_No));

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_Get_Purchase_Returns.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref Pager))
            {
                PurchaseReturns.Add(Get_Purchase_Return_Values(dr));
            }

            return PurchaseReturns;
        }

        //public DataTable Get_Purchase_Returns(QueryInfo query_Details)
        //{
        //    return sqlHelper.Get_Table_With_Where(query_Details);
        //}

        public PurchaseReturnInfo Get_Vendor_Details_By_Id(int vendor_Id)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Vendor_ID", vendor_Id));

            PurchaseReturnInfo Vendor = new PurchaseReturnInfo();

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_Get_Vendor_Details_By_Id.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {

                foreach (DataRow dr in dt.Rows)
                {
                    Vendor.Vendor_Id = Convert.ToInt32(dr["Vendor_ID"]);

                    Vendor.Tax_Percentage = Convert.ToDecimal(dr["Vendor_Vat_Rate"]);
                }
            }

            return Vendor;
        }

        public List<PurchaseReturnInfo> Get_Purchase_Return_Items_By_Vendor_And_PO(int vendor_Id, int Purchase_Invoice_Id)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Vendor_Id", vendor_Id));
            sqlParams.Add(new SqlParameter("@Purchase_Invoice_Id", Purchase_Invoice_Id));

            List<PurchaseReturnInfo> purchaseReturnItems = new List<PurchaseReturnInfo>();

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_Get_Purchase_Return_Items_By_Vendor_And_PI.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    purchaseReturnItems.Add(Get_Purchase_Return_Item_Values(dr));
                }
            }

            return purchaseReturnItems;
        }

        private PurchaseReturnInfo Get_Purchase_Return_Item_Values(DataRow dr)
        {
            PurchaseReturnInfo purchaseReturnItem = new PurchaseReturnInfo();

            if (!dr.IsNull("SKU_Code"))
                purchaseReturnItem.SKU_Code = Convert.ToString(dr["SKU_Code"]);

            if (!dr.IsNull("Quantity"))
                purchaseReturnItem.Quantity = Convert.ToInt32(dr["Quantity"]);

            if (!dr.IsNull("Amount"))
                purchaseReturnItem.Amount = Convert.ToDecimal(dr["Amount"]);

            if (!dr.IsNull("Vendor_Id"))
                purchaseReturnItem.Vendor_Id = Convert.ToInt32(dr["Vendor_Id"]);

            if (!dr.IsNull("Purchase_Invoice_Id"))
                purchaseReturnItem.Purchase_Invoice_Id = Convert.ToInt32(dr["Purchase_Invoice_Id"]);

            if (!dr.IsNull("Colour_Id"))
                purchaseReturnItem.Color_Id = Convert.ToInt32(dr["Colour_Id"]);

            if (!dr.IsNull("Colour_Name"))
                purchaseReturnItem.Color = Convert.ToString(dr["Colour_Name"]);

            if (!dr.IsNull("Size_Id"))
                purchaseReturnItem.Size_Id = Convert.ToInt32(dr["Size_Id"]);

            if (!dr.IsNull("Size_Name"))
                purchaseReturnItem.Size_Name = Convert.ToString(dr["Size_Name"]);

            //if (!dr.IsNull("Product_Id"))
            //    purchaseReturnItem.Product_Id = Convert.ToInt32(dr["Product_Id"]);

            if (!dr.IsNull("Article_No"))
                purchaseReturnItem.Article_No = Convert.ToString(dr["Article_No"]);

            if (!dr.IsNull("Category_Id"))
                purchaseReturnItem.Category_Id = Convert.ToInt32(dr["Category_Id"]);

            if (!dr.IsNull("Category"))
                purchaseReturnItem.Category = Convert.ToString(dr["Category"]);

            if (!dr.IsNull("Sub_Category_Id"))
                purchaseReturnItem.SubCategory_Id = Convert.ToInt32(dr["Sub_Category_Id"]);

            if (!dr.IsNull("Sub_Category"))
                purchaseReturnItem.SubCategory = Convert.ToString(dr["Sub_Category"]);

            if (!dr.IsNull("Size_Group_Id"))
                purchaseReturnItem.Size_Group_Id = Convert.ToInt32(dr["Size_Group_Id"]);

            if (!dr.IsNull("Size_Group_Name"))
                purchaseReturnItem.Size_Group_Name = Convert.ToString(dr["Size_Group_Name"]);

            if (!dr.IsNull("Purchase_Price"))
                purchaseReturnItem.WSR_Price = Convert.ToDecimal(dr["Purchase_Price"]);

            if (!dr.IsNull("Brand_Id"))
                purchaseReturnItem.Brand_Id = Convert.ToInt32(dr["Brand_Id"]);

            if (!dr.IsNull("Brand_Name"))
                purchaseReturnItem.Brand = Convert.ToString(dr["Brand_Name"]);

            return purchaseReturnItem;
        }


        public List<PurchaseReturnInfo> Get_Purchase_Return_Details_By_Id(int Purchase_Return_Id)
        {
            List<PurchaseReturnInfo> PurchaseReturnList = new List<PurchaseReturnInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Purchase_Return_Id", Purchase_Return_Id));

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_Get_Purchase_Return_Item_by_Purchase_Return_Id.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    PurchaseReturnInfo list = new PurchaseReturnInfo();

                    if (!dr.IsNull("SKU_Code"))
                        list.SKU_Code = Convert.ToString(dr["SKU_Code"]);
                    if (!dr.IsNull("Vendor_Name"))
                        list.Vendor_Name = Convert.ToString(dr["Vendor_Name"]);
                    //if (!dr.IsNull("Quantity"))
                    //    list.Quantity = Convert.ToInt32(dr["Quantity"]);
                    //if (!dr.IsNull("Brand_Name"))
                    //    list.Brand = Convert.ToString(dr["Brand_Name"]);
                    //if (!dr.IsNull("Category"))
                    //    list.Category = Convert.ToString(dr["Category"]);
                    //if (!dr.IsNull("Sub_Category"))
                    //    list.SubCategory = Convert.ToString(dr["Sub_Category"]);
                    //if (!dr.IsNull("Size_Name"))
                    //    list.Size_Name = Convert.ToString(dr["Size_Name"]);
                    //if (!dr.IsNull("Colour_Name"))
                    //    list.Colour_Name = Convert.ToString(dr["Colour_Name"]);
                    //if (!dr.IsNull("MRP_Amount"))
                    //    list.MRP_Price = Convert.ToInt32(dr["MRP_Amount"]);
                    //if (!dr.IsNull("Total_Amount"))
                    //    list.Amount = Convert.ToInt32(dr["Total_Amount"]);
                    //if (!dr.IsNull("Discount_Percentage"))
                    //    list.Discount_Percentage = Convert.ToInt32(dr["Discount_Percentage"]);
                    //if (!dr.IsNull("Employee_Name"))
                    //    list.SalesMan = Convert.ToString(dr["Employee_Name"]);

                    PurchaseReturnList.Add(list);
                }
            }

            return PurchaseReturnList;
        }

    }
}

