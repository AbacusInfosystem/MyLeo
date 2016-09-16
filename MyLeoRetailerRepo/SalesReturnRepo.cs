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

        public SalesReturnInfo Get_Sales_Order_Items_By_SKU_Code(string SKU_Code)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@SKU_Code", SKU_Code));

            SalesReturnInfo SalesReturnItems = new SalesReturnInfo();

            DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Sales_Order_Items_By_SKU_Code.ToString(), CommandType.StoredProcedure);

            List<DataRow> drList = new List<DataRow>();

            drList = dt.AsEnumerable().ToList();

            foreach (DataRow dr in drList)
            {
                SalesReturnItems = Get_Sales_Order_Items_By_SKU_Values(dr);
            }

            return SalesReturnItems;
        }

        private SalesReturnInfo Get_Sales_Order_Items_By_SKU_Values(DataRow dr)
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

            return SalesReturnItems;
        }

        public DataTable Get_SalesOrder(QueryInfo query_Details)
        {
            return sqlHelper.Get_Table_With_Where(query_Details);
        }

        public int Insert_SalesReturn(SalesReturnInfo salesReturn, List<SaleReturnItems> salesReturnItems)
        {

            salesReturn.Sales_Credit_Note_Id = Convert.ToInt32(sqlHelper.ExecuteScalerObj(Set_Values_In_SalesCreditNote(salesReturn), Storeprocedures.sp_Insert_Sales_Credit_Notes.ToString(), CommandType.StoredProcedure));

            salesReturn.Sales_Return_Id = Convert.ToInt32(sqlHelper.ExecuteScalerObj(Set_Values_In_SalesReturn(salesReturn), Storeprocedures.sp_Insert_Sales_Return.ToString(), CommandType.StoredProcedure));

            
            
            Insert_SalesReturn_Items(salesReturnItems, salesReturn, salesReturn.Sales_Return_Id);

            return salesReturn.Sales_Return_Id;

        }

        private List<SqlParameter> Set_Values_In_SalesCreditNote(SalesReturnInfo salesReturn)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            if (salesReturn.Sales_Credit_Note_Id != 0)
            {
                sqlParams.Add(new SqlParameter("@Sales_Credit_Note_Id", salesReturn.Sales_Credit_Note_Id));
            }

          
            if (salesReturn.Company_Branch_Id != 0)
            {
                sqlParams.Add(new SqlParameter("@Company_Branch_Id", salesReturn.Company_Branch_Id));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Company_Branch_Id", 0));
            }

            if (!string.IsNullOrEmpty(salesReturn.Credit_Note_No))
            {
                sqlParams.Add(new SqlParameter("@Credit_Note_No", salesReturn.Credit_Note_No));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Credit_Note_No", DBNull.Value));
            }

            if (salesReturn.Credit_Note_Type != 0)
            {
                sqlParams.Add(new SqlParameter("@Credit_Note_Type", salesReturn.Credit_Note_Type));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Credit_Note_Type", 0));
            }
      
            if (salesReturn.Total_Amount_Return_By_Credit_Note != 0)
            {
                sqlParams.Add(new SqlParameter("@Credit_Note_Amount", salesReturn.Total_Amount_Return_By_Credit_Note));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Credit_Note_Amount", 0));
            }


            if (salesReturn.Sales_Return_Id == 0)
            {
                sqlParams.Add(new SqlParameter("@Created_By", salesReturn.Created_By));

                sqlParams.Add(new SqlParameter("@Created_Date", salesReturn.Created_Date));
            }

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
            if (salesReturn.Company_Branch_Id != 0)
            {
                sqlParams.Add(new SqlParameter("@Company_Branch_Id", salesReturn.Company_Branch_Id));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Company_Branch_Id", 0));
            }
            

            if (salesReturn.Sales_Credit_Note_Id != 0)
            {
                sqlParams.Add(new SqlParameter("@Sales_Credit_Note_Id", salesReturn.Sales_Credit_Note_Id));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Sales_Credit_Note_Id", 0));
            }

            if (salesReturn.Customer_Id != 0)
            {
                sqlParams.Add(new SqlParameter("@Customer_Id", salesReturn.Customer_Id));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Customer_Id", 0));
            }
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
            

            if (salesReturn.Sales_Return_Id == 0)
            {
                sqlParams.Add(new SqlParameter("@Created_By", salesReturn.Created_By));

                sqlParams.Add(new SqlParameter("@Created_Date", salesReturn.Created_Date));
            }

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



    }
}
