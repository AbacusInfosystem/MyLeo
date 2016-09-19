using MyLeoRetailerInfo.SalesInvoice;
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
    public class SalesOrderRepo
    {
        SQL_Repo sqlHelper = null;

        public SalesOrderRepo()
        {
            sqlHelper = new SQL_Repo();
        }

        public SalesInvoiceInfo Get_Customer_Name_By_Mobile_No(string Mobile)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Mobile", Mobile));

            SalesInvoiceInfo Customer = new SalesInvoiceInfo();

            DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Customer_Name_By_Mobile_No.ToString(), CommandType.StoredProcedure);
            
            List<DataRow> drList = new List<DataRow>();
            
            drList = dt.AsEnumerable().ToList();
            
            foreach (DataRow dr in drList)
            {
                Customer = Get_Customer_Values(dr);
            }

            return Customer;
        }

        private SalesInvoiceInfo Get_Customer_Values(DataRow dr)
        {
            SalesInvoiceInfo Customer = new SalesInvoiceInfo();

            Customer.Customer_Id = Convert.ToInt32(dr["Customer_Id"]);

            if (!dr.IsNull("Customer_Name"))

            {
                Customer.Customer_Name = Convert.ToString(dr["Customer_Name"]);
            }

            return Customer;
        }

        public SalesInvoiceInfo Get_Sales_Order_Items_By_SKU_Code(string SKU_Code)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@SKU_Code", SKU_Code));

            SalesInvoiceInfo SalesOrderItems = new SalesInvoiceInfo();

            DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Sales_Order_Items_By_SKU_Code.ToString(), CommandType.StoredProcedure);

            List<DataRow> drList = new List<DataRow>();

            drList = dt.AsEnumerable().ToList();

            foreach (DataRow dr in drList)
            {
                SalesOrderItems = Get_Sales_Order_Items_By_SKU_Values(dr);
            }

            return SalesOrderItems;
        }

        private SalesInvoiceInfo Get_Sales_Order_Items_By_SKU_Values(DataRow dr)
        {
            SalesInvoiceInfo SalesOrderItems = new SalesInvoiceInfo();

            if (!dr.IsNull("Article_No"))
            {
                SalesOrderItems.Article_No = Convert.ToString(dr["Article_No"]);
            }

            if (!dr.IsNull("Brand_Id"))
            {
                SalesOrderItems.Brand_Id = Convert.ToInt32(dr["Brand_Id"]);
            }

            if (!dr.IsNull("Brand_Name"))
            {
                SalesOrderItems.Brand = Convert.ToString(dr["Brand_Name"]);
            }

            if (!dr.IsNull("Category_Id"))
            {
                SalesOrderItems.Category_Id = Convert.ToInt32(dr["Category_Id"]);
            }

            if (!dr.IsNull("Category"))
            {
                SalesOrderItems.Category = Convert.ToString(dr["Category"]);
            }

            if (!dr.IsNull("Sub_Category_Id"))
            {
                SalesOrderItems.SubCategory_Id = Convert.ToInt32(dr["Sub_Category_Id"]);
            }

            if (!dr.IsNull("Sub_Category"))
            {
                SalesOrderItems.SubCategory = Convert.ToString(dr["Sub_Category"]);
            }

            if (!dr.IsNull("Size_Id"))
            {
                SalesOrderItems.Size_Id = Convert.ToInt32(dr["Size_Id"]);
            }

            if (!dr.IsNull("Size_Name"))
            {
                SalesOrderItems.Size_Name = Convert.ToString(dr["Size_Name"]);
            }

            if (!dr.IsNull("Colour_Id"))
            {
                SalesOrderItems.Colour_Id = Convert.ToInt32(dr["Colour_Id"]);
            }

            if (!dr.IsNull("Colour_Name"))
            {
                SalesOrderItems.Colour_Name = Convert.ToString(dr["Colour_Name"]);
            }

            if (!dr.IsNull("MRP_Price"))
            {
                SalesOrderItems.MRP_Price = Convert.ToInt32(dr["MRP_Price"]);
            }

            return SalesOrderItems;
        }

        public DataTable Get_SalesOrder(QueryInfo query_Details)
        {
            return sqlHelper.Get_Table_With_Where(query_Details);
        }

        public int Insert_SalesOrder(SalesInvoiceInfo salesInvoice, List<SaleOrderItems> salesOrderItems,string Branch_Id)
        {

            salesInvoice.Sales_Invoice_Id = Convert.ToInt32(sqlHelper.ExecuteScalerObj(Set_Values_In_SalesOrder(salesInvoice, Branch_Id), Storeprocedures.sp_Insert_Sales_Invoice.ToString(), CommandType.StoredProcedure));

            Insert_SalesOrder_Items(salesOrderItems, salesInvoice, salesInvoice.Sales_Invoice_Id);

            return salesInvoice.Sales_Invoice_Id;

        }

        private List<SqlParameter> Set_Values_In_SalesOrder(SalesInvoiceInfo salesInvoice, string Branch_Id)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            if (salesInvoice.Sales_Invoice_Id != 0)
            {
                sqlParams.Add(new SqlParameter("@Sales_Invoice_Id", salesInvoice.Sales_Invoice_Id));
            }

            if (!string.IsNullOrEmpty(salesInvoice.Sales_Invoice_No))
            {
                sqlParams.Add(new SqlParameter("@Sales_Invoice_No", salesInvoice.Sales_Invoice_No));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Sales_Invoice_No", DBNull.Value));
            }
            if (Convert.ToInt32(Branch_Id) != 0)
            {
                sqlParams.Add(new SqlParameter("@Branch_ID", Branch_Id));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Branch_ID", 0));
            }
            if (salesInvoice.Customer_Id != 0)
            {
                sqlParams.Add(new SqlParameter("@Customer_Id", salesInvoice.Customer_Id));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Customer_Id", 0));
            }
            if (salesInvoice.Total_Quantity != 0)
            {
                sqlParams.Add(new SqlParameter("@Total_Quantity", salesInvoice.Total_Quantity));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Total_Quantity", 0));
            }
            if (salesInvoice.Total_MRP_Amount != 0)
            {
                sqlParams.Add(new SqlParameter("@Total_MRP_Amount", salesInvoice.Total_MRP_Amount));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Total_MRP_Amount", 0));
            }
            if(salesInvoice.Total_Discount_Amount != 0)
            {
                sqlParams.Add(new SqlParameter("@Total_Discount_Amount", salesInvoice.Total_Discount_Amount));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Total_Discount_Amount", 0));
            }
            if (salesInvoice.Gross_Amount != 0)
            {
                sqlParams.Add(new SqlParameter("@Gross_Amount", salesInvoice.Gross_Amount));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Gross_Amount", 0));
            }
            if (salesInvoice.Tax_Percentage != 0)
            {
                sqlParams.Add(new SqlParameter("@Tax_Percentage", salesInvoice.Tax_Percentage));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Tax_Percentage", 0));
            }
            if (salesInvoice.Round_Off_Amount != 0)
            {
                sqlParams.Add(new SqlParameter("@Round_Off_Amount", salesInvoice.Round_Off_Amount));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Round_Off_Amount", 0));
            }
            if (salesInvoice.Net_Amount != 0)
            {
                sqlParams.Add(new SqlParameter("@Net_Amount", salesInvoice.Net_Amount));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Net_Amount", 0));
            }

            
                sqlParams.Add(new SqlParameter("@Created_By", salesInvoice.Created_By));

                sqlParams.Add(new SqlParameter("@Created_Date", salesInvoice.Created_Date));
            
                sqlParams.Add(new SqlParameter("@Updated_By", salesInvoice.Updated_By));

                sqlParams.Add(new SqlParameter("@Updated_Date", salesInvoice.Updated_Date));

            return sqlParams;
        }

        public void Insert_SalesOrder_Items(List<SaleOrderItems> salesOrderItems, SalesInvoiceInfo salesInvoice, int Sales_Invoice_Id)
        {
            foreach (var item in salesOrderItems)
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();

                sqlParams.Add(new SqlParameter("@Sales_Invoice_Id", Sales_Invoice_Id));
                sqlParams.Add(new SqlParameter("@SKU_Code", item.SKU_Code));
                sqlParams.Add(new SqlParameter("@Quantity", item.Quantity));
                sqlParams.Add(new SqlParameter("@MRP_Amount", item.MRP_Price));
                sqlParams.Add(new SqlParameter("@Discount_Percentage", item.Discount_Percentage));
                sqlParams.Add(new SqlParameter("@Total_Amount", item.Amount));
                sqlParams.Add(new SqlParameter("@Salesman_Id", item.SalesMan_Id));

                sqlParams.Add(new SqlParameter("@Created_By", salesInvoice.Created_By));
                sqlParams.Add(new SqlParameter("@Created_Date", salesInvoice.Created_Date));
                sqlParams.Add(new SqlParameter("@Updated_By", salesInvoice.Updated_By));
                sqlParams.Add(new SqlParameter("@Updated_Date", salesInvoice.Updated_Date));

                sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Insert_Sales_Invoice_Item.ToString(), CommandType.StoredProcedure);
            }
        } 
    }
}
