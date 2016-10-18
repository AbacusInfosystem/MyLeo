using MyLeoRetailerInfo.SalesReturn;
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

namespace MyLeoRetailerRepo
{
    public class SalesReturnRepo
    {

        SQL_Repo sqlHelper = null;

        public SalesReturnRepo()
        {
            sqlHelper = new SQL_Repo();
        }

        public SalesReturnInfo Get_Customer_Name_By_Mobile_No(string Mobile)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Mobile", Mobile));

            SalesReturnInfo Customer = new SalesReturnInfo();

            DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Customer_Name_By_Mobile_No.ToString(), CommandType.StoredProcedure);
            
            List<DataRow> drList = new List<DataRow>();
            
            drList = dt.AsEnumerable().ToList();
            
            foreach (DataRow dr in drList)
            {
                Customer = Get_Customer_Values(dr);
            }

            return Customer;
        }

        private SalesReturnInfo Get_Customer_Values(DataRow dr)
        {
            SalesReturnInfo Customer = new SalesReturnInfo();

            Customer.Customer_Id = Convert.ToInt32(dr["Customer_Id"]);

            if (!dr.IsNull("Customer_Name"))

            {
                Customer.Customer_Name = Convert.ToString(dr["Customer_Name"]);
            }

            return Customer;
        }

        public SalesReturnInfo Get_Sales_Return_Items_By_SKU_Code(int Sales_Invoice_Id, string SKU_Code)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@SKU_Code", SKU_Code));

            parameters.Add(new SqlParameter("@Sales_Invoice_Id", Sales_Invoice_Id));

            SalesReturnInfo SalesReturnItems = new SalesReturnInfo();

            DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Sales_Return_Items_By_SKU_Code.ToString(), CommandType.StoredProcedure);

            List<DataRow> drList = new List<DataRow>();

            drList = dt.AsEnumerable().ToList();

            foreach (DataRow dr in drList)
            {
                SalesReturnItems = Get_Sales_Return_Items_By_SKU_Values(dr);
            }

            return SalesReturnItems;
        }

        private SalesReturnInfo Get_Sales_Return_Items_By_SKU_Values(DataRow dr)
        {
            SalesReturnInfo SalesReturnItems = new SalesReturnInfo();

            if (!dr.IsNull("Article_No"))
            {
                SalesReturnItems.Article_No = Convert.ToString(dr["Article_No"]);
            }

            if (!dr.IsNull("Brand_Id"))
            {
                SalesReturnItems.Brand_Id = Convert.ToInt32(dr["Brand_Id"]);
            }

            if (!dr.IsNull("Brand_Name"))
            {
                SalesReturnItems.Brand = Convert.ToString(dr["Brand_Name"]);
            }

            if (!dr.IsNull("Category_Id"))
            {
                SalesReturnItems.Category_Id = Convert.ToInt32(dr["Category_Id"]);
            }

            if (!dr.IsNull("Category"))
            {
                SalesReturnItems.Category = Convert.ToString(dr["Category"]);
            }

            if (!dr.IsNull("Sub_Category_Id"))
            {
                SalesReturnItems.SubCategory_Id = Convert.ToInt32(dr["Sub_Category_Id"]);
            }

            if (!dr.IsNull("Sub_Category"))
            {
                SalesReturnItems.SubCategory = Convert.ToString(dr["Sub_Category"]);
            }

            if (!dr.IsNull("Size_Id"))
            {
                SalesReturnItems.Size_Id = Convert.ToInt32(dr["Size_Id"]);
            }

            if (!dr.IsNull("Size_Name"))
            {
                SalesReturnItems.Size_Name = Convert.ToString(dr["Size_Name"]);
            }

            if (!dr.IsNull("Colour_Id"))
            {
                SalesReturnItems.Colour_Id = Convert.ToInt32(dr["Colour_Id"]);
            }

            if (!dr.IsNull("Colour_Name"))
            {
                SalesReturnItems.Colour_Name = Convert.ToString(dr["Colour_Name"]);
            }

            if (!dr.IsNull("MRP_Price"))
            {
                SalesReturnItems.MRP_Price = Convert.ToInt32(dr["MRP_Price"]);
            }

            if (!dr.IsNull("Quantity"))
            {
                SalesReturnItems.Quantity = Convert.ToInt32(dr["Quantity"]);
            }

            if (!dr.IsNull("Discount_Percentage"))
            {
                SalesReturnItems.Discount_Percentage = Convert.ToInt32(dr["Discount_Percentage"]);
            }



            return SalesReturnItems;
        }

        public DataTable Get_SalesOrder(QueryInfo query_Details)
        {
            return sqlHelper.Get_Table_With_Where(query_Details);
        }

        public DataTable Get_Sales_Return_Search_Details(SalesReturnInfo salesReturn, string Branch_ID, string Sales_Return_No) //.... 
        {
            DataTable dt = new DataTable();

            List<SalesReturnInfo> salesReturns = new List<SalesReturnInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Branch_ID", Branch_ID));

            sqlParams.Add(new SqlParameter("@Sales_Return_No", Sales_Return_No));

            dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.Get_Sales_Return_Search_Details.ToString(), CommandType.StoredProcedure);

            return dt;
        }


        public int Insert_SalesReturn(SalesReturnInfo salesReturn, List<SaleReturnItems> salesReturnItems)
        {

            salesReturn.Sales_Return_Id = Convert.ToInt32(sqlHelper.ExecuteScalerObj(Set_Values_In_SalesReturn(salesReturn), Storeprocedures.sp_Insert_Sales_Return.ToString(), CommandType.StoredProcedure));

            Insert_SalesReturn_Items(salesReturnItems, salesReturn, salesReturn.Sales_Return_Id);

            salesReturn.Sales_Credit_Note_Id = Convert.ToInt32(sqlHelper.ExecuteScalerObj(Set_Values_In_SalesCreditNote(salesReturn), Storeprocedures.sp_Insert_Sales_Credit_Notes.ToString(), CommandType.StoredProcedure));

            return salesReturn.Sales_Return_Id;

        }

        private List<SqlParameter> Set_Values_In_SalesCreditNote(SalesReturnInfo salesReturn)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            if (salesReturn.Sales_Credit_Note_Id != 0)
            {
                sqlParams.Add(new SqlParameter("@Sales_Credit_Note_Id", salesReturn.Sales_Credit_Note_Id));
            }

            if (salesReturn.Sales_Return_Id != 0)
            {
                sqlParams.Add(new SqlParameter("@Sales_Return_Id", salesReturn.Sales_Return_Id));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Sales_Return_Id", 0));
            }

            if (salesReturn.Branch_Id != 0)
            {
                sqlParams.Add(new SqlParameter("@Branch_ID", salesReturn.Branch_Id));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Branch_ID", 0));
            }

            sqlParams.Add(new SqlParameter("@Status", 1));

            if (!string.IsNullOrEmpty(salesReturn.Sales_Return_No))
            {
                sqlParams.Add(new SqlParameter("@Credit_Note_No", salesReturn.Sales_Return_No));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Credit_Note_No", DBNull.Value));
            }

            sqlParams.Add(new SqlParameter("@Credit_Note_Type", 1));

      
            if (salesReturn.Total_Amount_Return_By_Credit_Note != 0)
            {
                sqlParams.Add(new SqlParameter("@Credit_Note_Amount", salesReturn.Total_Amount_Return_By_Credit_Note));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Credit_Note_Amount", 0));
            }


            //if (salesReturn.Sales_Return_Id == 0)
            //{
                sqlParams.Add(new SqlParameter("@Created_By", salesReturn.Created_By));

                sqlParams.Add(new SqlParameter("@Created_Date", salesReturn.Created_Date));
            //}

            sqlParams.Add(new SqlParameter("@Updated_By", salesReturn.Updated_By));

            sqlParams.Add(new SqlParameter("@Updated_Date", salesReturn.Updated_Date));

            return sqlParams;
        }

        private List<SqlParameter> Set_Values_In_SalesReturn(SalesReturnInfo salesReturn)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            if (salesReturn.Sales_Return_Id != 0)
            {
                sqlParams.Add(new SqlParameter("@Sales_Return_Id", salesReturn.Sales_Return_Id));
            }

            if (!string.IsNullOrEmpty(salesReturn.Sales_Return_No))
            {
                sqlParams.Add(new SqlParameter("@Sales_Return_No", salesReturn.Sales_Return_No));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Sales_Return_No", DBNull.Value));
            }
            if (salesReturn.Branch_Id != 0)
            {
                sqlParams.Add(new SqlParameter("@Branch_ID", salesReturn.Branch_Id));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Branch_ID", 0));
            }

            if (salesReturn.Customer_Id != 0)
            {
                sqlParams.Add(new SqlParameter("@Customer_Id", salesReturn.Customer_Id));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Customer_Id", 0));
            }

            sqlParams.Add(new SqlParameter("@Sales_Return_Date", salesReturn.Sales_Return_Date));

            if (salesReturn.Total_Quantity != 0)
            {
                sqlParams.Add(new SqlParameter("@Total_Quantity", salesReturn.Total_Quantity));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Total_Quantity", 0));
            }
            if (salesReturn.Gross_Amount != 0)
            {
                sqlParams.Add(new SqlParameter("@Gross_Amount", salesReturn.Gross_Amount));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Gross_Amount", 0));
            }
            if(salesReturn.Total_Amount_Return_By_Cash != 0)
            {
                sqlParams.Add(new SqlParameter("@Total_Amount_Return_By_Cash", salesReturn.Total_Amount_Return_By_Cash));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Total_Amount_Return_By_Cash", 0));
            }
            if (salesReturn.Total_Amount_Return_By_Credit_Note != 0)
            {
                sqlParams.Add(new SqlParameter("@Total_Amount_Return_By_Credit_Note", salesReturn.Total_Amount_Return_By_Credit_Note));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Total_Amount_Return_By_Credit_Note", 0));
            }
            

          
                sqlParams.Add(new SqlParameter("@Created_By", salesReturn.Created_By));

                sqlParams.Add(new SqlParameter("@Created_Date", salesReturn.Created_Date));
            

                sqlParams.Add(new SqlParameter("@Updated_By", salesReturn.Updated_By));

                sqlParams.Add(new SqlParameter("@Updated_Date", salesReturn.Updated_Date));

            return sqlParams;
        }

        public void Insert_SalesReturn_Items(List<SaleReturnItems> salesReturnItems, SalesReturnInfo salesReturn, int Sales_Return_Id)
        {
            foreach (var item in salesReturnItems)
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();

                sqlParams.Add(new SqlParameter("@Sales_Return_Id", Sales_Return_Id));
                sqlParams.Add(new SqlParameter("@SKU_Code", item.SKU_Code));
                sqlParams.Add(new SqlParameter("@Sales_Invoice_Id", item.Sales_Invoice_Id));
                sqlParams.Add(new SqlParameter("@Quantity", item.Quantity));
                sqlParams.Add(new SqlParameter("@MRP_Amount", item.MRP_Price));
                sqlParams.Add(new SqlParameter("@Discount_Percentage", item.Discount_Percentage));
                sqlParams.Add(new SqlParameter("@Total_Amount", item.Amount));
                sqlParams.Add(new SqlParameter("@Return_Reason", item.Return_Reason));

                sqlParams.Add(new SqlParameter("@Created_By", salesReturn.Created_By));
                sqlParams.Add(new SqlParameter("@Created_Date", salesReturn.Created_Date));
                sqlParams.Add(new SqlParameter("@Updated_By", salesReturn.Updated_By));
                sqlParams.Add(new SqlParameter("@Updated_Date", salesReturn.Updated_Date));

                sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Insert_Sales_Return_Item.ToString(), CommandType.StoredProcedure);
            }
        }

        public bool Check_Mobile_No(string MobileNo)
        {
            bool check = false;

            try
            {
                string ProcedureName = string.Empty;

                List<SqlParameter> sqlParams = new List<SqlParameter>();

                sqlParams.Add(new SqlParameter("@Customer_Mobile1", MobileNo));

                DataTable dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_Check_Mobile_No.ToString(), CommandType.StoredProcedure);

                if (dt != null && dt.Rows.Count > 0)
                {
                    int count = dt.Rows.Count;

                    List<DataRow> drList = new List<DataRow>();

                    drList = dt.AsEnumerable().ToList();

                    foreach (DataRow dr in drList)
                    {
                        check = Convert.ToBoolean(dr["MobileCount"]);
                    }

                }
            }
            catch (Exception ex)
            {
            }

            return check;
        }

        public bool Check_Quantity(int Quantity, int Branch_Id, string SKU_Code)
        {
            bool check = false;

            try
            {
                string ProcedureName = string.Empty;

                List<SqlParameter> sqlParams = new List<SqlParameter>();

                sqlParams.Add(new SqlParameter("@Quantity", Quantity));

                sqlParams.Add(new SqlParameter("@Branch_ID", Branch_Id));

                sqlParams.Add(new SqlParameter("@Product_SKU", SKU_Code));

                DataTable dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_Check_Quantity.ToString(), CommandType.StoredProcedure);

                if (dt != null && dt.Rows.Count > 0)
                {
                    int count = dt.Rows.Count;

                    List<DataRow> drList = new List<DataRow>();

                    drList = dt.AsEnumerable().ToList();

                    foreach (DataRow dr in drList)
                    {
                        check = Convert.ToBoolean(dr["Quantity"]);
                    }

                }

            }
            catch (Exception ex)
            {
            }

            return check;
        }

        public SalesReturnInfo Get_Sales_Return_By_Id(int Sales_Return_Id)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Sales_Return_Id", Sales_Return_Id));

            SalesReturnInfo salesreturn = new SalesReturnInfo();

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_Get_Sales_Return_Details_By_Sales_Return_Id.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {

                foreach (DataRow dr in dt.Rows)
                {
                    salesreturn = Get_Sales_Return_Values(dr);
                }
            }

            return salesreturn;
        }

        private SalesReturnInfo Get_Sales_Return_Values(DataRow dr)
        {
            SalesReturnInfo salesreturn = new SalesReturnInfo();

            List<SqlParameter> sqlParams = new List<SqlParameter>();


            salesreturn.Sales_Return_No = Convert.ToString(dr["Sales_Return_No"]);
            salesreturn.Created_Date = Convert.ToDateTime(dr["Created_Date"]);
            salesreturn.Sales_Return_Date = Convert.ToDateTime(dr["Sales_Return_Date"]);
            salesreturn.Customer_Id = Convert.ToInt32(dr["Customer_Id"]);
            salesreturn.Customer_Name = Convert.ToString(dr["Customer_Name"]);
            salesreturn.Mobile = Convert.ToString(dr["Customer_Mobile1"]);
            salesreturn.Gross_Amount = Convert.ToInt32(dr["Gross_Amount"]);
            salesreturn.Total_Amount_Return_By_Cash = Convert.ToInt32(dr["Total_Amount_Return_By_Cash"]);
            salesreturn.Total_Quantity = Convert.ToInt32(dr["Total_Quantity"]);
            salesreturn.Total_Amount_Return_By_Credit_Note = Convert.ToInt32(dr["Total_Amount_Return_By_Credit_Note"]);

            return salesreturn;
        }

        public List<SaleReturnItems> Get_Sales_Return_Items_By_Id(int Sales_Return_Id)
        {
            List<SaleReturnItems> SaleReturnItemList = new List<SaleReturnItems>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Sales_Return_Id", Sales_Return_Id));

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_Get_Sales_Return_Items_By_Sales_Return_Id.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    SaleReturnItems list = new SaleReturnItems();

                    if (!dr.IsNull("Sales_Invoice_No"))
                        list.Sales_Invoice_No = Convert.ToString(dr["Sales_Invoice_No"]);
                    if (!dr.IsNull("SKU_Code"))
                        list.SKU_Code = Convert.ToString(dr["SKU_Code"]);
                    if (!dr.IsNull("Article_No"))
                        list.Article_No = Convert.ToString(dr["Article_No"]);
                    if (!dr.IsNull("Quantity"))
                        list.Quantity = Convert.ToInt32(dr["Quantity"]);
                    if (!dr.IsNull("Brand_Name"))
                        list.Brand = Convert.ToString(dr["Brand_Name"]);
                    if (!dr.IsNull("Category"))
                        list.Category = Convert.ToString(dr["Category"]);
                    if (!dr.IsNull("Sub_Category"))
                        list.SubCategory = Convert.ToString(dr["Sub_Category"]);
                    if (!dr.IsNull("Size_Name"))
                        list.Size_Name = Convert.ToString(dr["Size_Name"]);
                    if (!dr.IsNull("Colour_Name"))
                        list.Colour_Name = Convert.ToString(dr["Colour_Name"]);
                    if (!dr.IsNull("MRP_Amount"))
                        list.MRP_Price = Convert.ToInt32(dr["MRP_Amount"]);
                    if (!dr.IsNull("Total_Amount"))
                        list.Amount = Convert.ToInt32(dr["Total_Amount"]);
                    if (!dr.IsNull("Discount_Percentage"))
                        list.Discount_Percentage = Convert.ToInt32(dr["Discount_Percentage"]);
                    if (!dr.IsNull("Return_Reason"))
                        list.Return_Reason = Convert.ToString(dr["Return_Reason"]);

                    SaleReturnItemList.Add(list);
                }
            }

            return SaleReturnItemList;
        }

    }
}
