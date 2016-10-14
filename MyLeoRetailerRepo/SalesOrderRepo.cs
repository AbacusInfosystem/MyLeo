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

        public List<CreditNote> Get_Credit_Note_Data_By_Id(int Customer_Id) 
        {

            List<CreditNote> CreditNote = new List<CreditNote>();

            List<SqlParameter> sqlparam = new List<SqlParameter>();

            sqlparam.Add(new SqlParameter("@Customer_Id", Customer_Id));

            DataTable dt = sqlHelper.ExecuteDataTable(sqlparam, Storeprocedures.sp_Get_Credit_Note_Details_By_Customer_Id.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in dt.Rows)
            {
                CreditNote.Add(Get_Credit_Note_Values1(dr));
            }

            return CreditNote;
        }

        public List<Receivable> Get_Gift_Voucher_Details()
        {
            List<Receivable> GiftVouncherNo = new List<Receivable>();

            List<SqlParameter> sqlparam = new List<SqlParameter>();

            DataTable dt = sqlHelper.ExecuteDataTable(sqlparam, Storeprocedures.sp_Get_Gift_Voucher.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in dt.Rows)
            {
                GiftVouncherNo.Add(Get_Gift_Voucher_Values(dr));
            }

            return GiftVouncherNo;
        }

        public List<CreditNote> Get_Credit_Note_Amount_By_Id(int Sales_Credit_Note_Id)
        {

            List<CreditNote> CreditNote = new List<CreditNote>();

            List<SqlParameter> sqlparam = new List<SqlParameter>();

            sqlparam.Add(new SqlParameter("@Sales_Credit_Note_Id", Sales_Credit_Note_Id));

            DataTable dt = sqlHelper.ExecuteDataTable(sqlparam, Storeprocedures.Get_Credit_Note_Details_By_Id_Sp1.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in dt.Rows)
            {
                CreditNote.Add(Get_Credit_Note_Values1(dr));
            }
            return CreditNote;
        }

        private CreditNote Get_Credit_Note_Values1(DataRow dr) //........
        {
            CreditNote CreditNoteDetails = new CreditNote();

            CreditNoteDetails.Credit_Note_Id = Convert.ToInt32(dr["Sales_Credit_Note_Id"]);
            CreditNoteDetails.Credit_Note_No = Convert.ToString(dr["Credit_Note_No"]);
            CreditNoteDetails.Credit_Note_Amount = Convert.ToDecimal(dr["Credit_Note_Amount"]);
            CreditNoteDetails.Credit_Note_Date = Convert.ToDateTime(dr["Created_Date"]);

            return CreditNoteDetails;
        }

        private Receivable Get_Gift_Voucher_Values(DataRow dr) //........
        {
            Receivable GiftVoucherDetails = new Receivable();

            GiftVoucherDetails.Gift_Voucher_Id = Convert.ToInt32(dr["Gift_Voucher_Id"]);
            GiftVoucherDetails.Gift_Voucher_Amount = Convert.ToInt32(dr["Gift_Voucher_Amount"]);
            GiftVoucherDetails.Gift_Voucher_No = Convert.ToString(dr["Gift_Voucher_No"]);


            return GiftVoucherDetails;
        }

        public SalesInvoiceInfo Get_Gift_Voucher_Amount_By_Id(int Gift_Voucher_Id)
        {

            SalesInvoiceInfo GiftVoucherAmt = new SalesInvoiceInfo();

            List<SqlParameter> sqlparam = new List<SqlParameter>();

            sqlparam.Add(new SqlParameter("@Gift_Voucher_Id", Gift_Voucher_Id));

            DataTable dt = sqlHelper.ExecuteDataTable(sqlparam, Storeprocedures.sp_Get_Gift_Voucher_By_Id.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in dt.Rows)
            {

                GiftVoucherAmt.Gift_Voucher_Amount = Convert.ToDecimal(dr["Gift_Voucher_Amount"]);
            }
            return GiftVoucherAmt;
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

        public DataTable Get_Sales_Report(SalesOrderFilter filter)
        {

            DataTable dt = new DataTable();

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@Branch_Id", filter.Branch_Id));

            sqlParam.Add(new SqlParameter("@From_Date", filter.From_Date));

            sqlParam.Add(new SqlParameter("@To_Date", filter.To_Date));

            dt = sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.sp_Get_Sales_Report.ToString(), CommandType.StoredProcedure);

            return dt;
        }

        public SalesInvoiceInfo Get_SalesOrder_By_Id(int Sales_Invoice_Id)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Sales_Invoice_Id", Sales_Invoice_Id));

            SalesInvoiceInfo salesinvoice = new SalesInvoiceInfo();

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_Get_Sales_Invoice_Details_And_Branch_Details_By_Sales_Invoice_Id.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {

                foreach (DataRow dr in dt.Rows)
                {
                    salesinvoice = Get_SalesOrder_Values(dr);
                }
            }

            return salesinvoice;
        }

        public List<SaleOrderItems> Get_SalesOrder_Items_By_Id(int Sales_Invoice_Id)
        {
            List<SaleOrderItems> SaleOrderItemList = new List<SaleOrderItems>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Sales_Invoice_Id", Sales_Invoice_Id));

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_Get_Sales_Invoice_Items_By_Sales_Invoice_Id.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    SaleOrderItems list = new SaleOrderItems();

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
                    if (!dr.IsNull("Employee_Name"))
                        list.SalesMan = Convert.ToString(dr["Employee_Name"]);

                    SaleOrderItemList.Add(list);
                }
            }

            return SaleOrderItemList;
        }

        private SalesInvoiceInfo Get_SalesOrder_Values(DataRow dr)
        {
            SalesInvoiceInfo salesinvoice = new SalesInvoiceInfo();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            salesinvoice.Branch_Name = Convert.ToString(dr["Branch_Name"]);
            salesinvoice.Branch_Address = Convert.ToString(dr["Branch_Address"]);
            salesinvoice.Branch_City = Convert.ToString(dr["Branch_City"]);
            salesinvoice.Branch_State = Convert.ToString(dr["Branch_State"]);
            salesinvoice.Branch_Country = Convert.ToString(dr["Branch_Country"]);
            salesinvoice.Branch_Pincode = Convert.ToInt32(dr["Branch_Pincode"]);
            salesinvoice.Branch_Landline1 = Convert.ToString(dr["Branch_Landline1"]);
            salesinvoice.Branch_Landline2 = Convert.ToString(dr["Branch_Landline2"]);
            salesinvoice.Sales_Invoice_No = Convert.ToString(dr["Sales_Invoice_No"]);
            salesinvoice.Created_Date = Convert.ToDateTime(dr["Created_Date"]);
            salesinvoice.Invoice_Date = Convert.ToDateTime(dr["Invoice_Date"]);
            salesinvoice.Customer_Id = Convert.ToInt32(dr["Customer_Id"]);
            salesinvoice.Customer_Name = Convert.ToString(dr["Customer_Name"]);
            salesinvoice.Mobile = Convert.ToString(dr["Customer_Mobile1"]);
            salesinvoice.Gross_Amount = Convert.ToInt32(dr["Gross_Amount"]);
            salesinvoice.Total_MRP_Amount = Convert.ToInt32(dr["Total_MRP_Amount"]);
            salesinvoice.Total_Quantity = Convert.ToInt32(dr["Total_Quantity"]);
            salesinvoice.Tax_Percentage = Convert.ToInt32(dr["Tax_Percentage"]);

            if (salesinvoice.Round_Off_Amount == 0)
            {
                sqlParams.Add(new SqlParameter("@Round_Off_Amount", 0));
            }
            else
            {
                salesinvoice.Round_Off_Amount = Convert.ToInt32(dr["Round_Off_Amount"]);           
            }



            salesinvoice.Total_Discount_Amount = Convert.ToInt32(dr["Total_Discount_Amount"]);
            salesinvoice.Net_Amount = Convert.ToInt32(dr["Net_Amount"]);

            return salesinvoice;
        }

        public int Insert_SalesOrder(SalesInvoiceInfo salesInvoice, List<SaleOrderItems> salesOrderItems, List<Receivable> ReceivableItem)
        {

            salesInvoice.Sales_Invoice_Id = Convert.ToInt32(sqlHelper.ExecuteScalerObj(Set_Values_In_SalesOrder(salesInvoice), Storeprocedures.sp_Insert_Sales_Invoice.ToString(), CommandType.StoredProcedure));

            Insert_SalesOrder_Items(salesOrderItems, salesInvoice, salesInvoice.Sales_Invoice_Id);

            salesInvoice.Receivable_Id = Convert.ToInt32(sqlHelper.ExecuteScalerObj(Set_Values_In_Receivable(salesInvoice), Storeprocedures.Insert_Receivable_Data_Sp.ToString(), CommandType.StoredProcedure));

            Insert_Receivable_Items(ReceivableItem, salesInvoice, salesInvoice.Receivable_Id);

            return salesInvoice.Sales_Invoice_Id;

        }

        private List<SqlParameter> Set_Values_In_Receivable(SalesInvoiceInfo salesInvoice)
        {
            decimal Total_Balance_Amount = 0;

            decimal Balance_Amount = Get_Balance_Amount(salesInvoice.Sales_Invoice_Id);

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Receivable_Id", salesInvoice.Receivable_Id));

            if (salesInvoice.Branch_Id != 0)
            {
                sqlParams.Add(new SqlParameter("@Branch_ID", salesInvoice.Branch_Id));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Branch_ID", 0));
            }

            sqlParams.Add(new SqlParameter("@Sales_Invoice_Id", salesInvoice.Sales_Invoice_Id));

            //sqlParams.Add(new SqlParameter("@Payble_Status ", Receivable.Payble_Status));

            if (salesInvoice.Payament_Date != DateTime.MinValue)
            {
                sqlParams.Add(new SqlParameter("@Payament_Date ", salesInvoice.Payament_Date));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Payament_Date", DBNull.Value));
            }

            

            if (Balance_Amount > 0)
            {

                Total_Balance_Amount = Balance_Amount - salesInvoice.Paid_Amount;

            }

            else
            {

                Total_Balance_Amount = salesInvoice.Net_Amount - salesInvoice.Paid_Amount;
            }

            salesInvoice.Balance_Amount = Total_Balance_Amount;

            sqlParams.Add(new SqlParameter("@Balance_Amount", salesInvoice.Balance_Amount));

            if (salesInvoice.Balance_Amount == salesInvoice.Net_Amount)
            {
                sqlParams.Add(new SqlParameter("@Payment_Status", "2"));
            }
            else if (salesInvoice.Balance_Amount == 0)
            {
                sqlParams.Add(new SqlParameter("@Payment_Status", "1"));
            }
            else if (salesInvoice.Balance_Amount != salesInvoice.Net_Amount)
            {
                sqlParams.Add(new SqlParameter("@Payment_Status", "3"));
            }
           
            //sqlParams.Add(new SqlParameter("@Balance_Amount ", Receivable.Balance_Amount));

            sqlParams.Add(new SqlParameter("@Created_On", salesInvoice.Created_Date));

            sqlParams.Add(new SqlParameter("@Created_By", salesInvoice.Created_By));

            sqlParams.Add(new SqlParameter("@Updated_On", salesInvoice.Updated_Date));

            sqlParams.Add(new SqlParameter("@Updated_By", salesInvoice.Updated_By));

            return sqlParams;
        }

        public decimal Get_Balance_Amount(int Sales_Invoice_Id)
        {

            decimal Balance_Amount = 0;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Sales_Invoice_Id", Sales_Invoice_Id));

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.Get_Receivable_Balance_Amount_By_Id_Sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (!dr.IsNull("Balance_Amount"))

                        Balance_Amount = Convert.ToDecimal(dr["Balance_Amount"]);
                }
            }

            return Balance_Amount;
        }

        private List<SqlParameter> Set_Values_In_SalesOrder(SalesInvoiceInfo salesInvoice)
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
            if (salesInvoice.Branch_Id != 0)
            {
                sqlParams.Add(new SqlParameter("@Branch_ID", salesInvoice.Branch_Id));
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

            sqlParams.Add(new SqlParameter("@Invoice_Date", salesInvoice.Invoice_Date));
            

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

        public void Insert_Receivable_Items(List<Receivable> ReceivableItem, SalesInvoiceInfo salesInvoice, int Receivable_Id)
        {

            decimal creditnoteamount = Get_Credit_Note_Amount(salesInvoice.Sales_Credit_Note_Id);
            
                List<SqlParameter> sqlParams = new List<SqlParameter>();

                sqlParams.Add(new SqlParameter("@Receivable_Id", Receivable_Id));
                sqlParams.Add(new SqlParameter("@Sales_Credit_Note_Id", salesInvoice.Sales_Credit_Note_Id));
                sqlParams.Add(new SqlParameter("@Gift_Voucher_Id", salesInvoice.Gift_Voucher_Id));
                sqlParams.Add(new SqlParameter("@Receivable_Item_Id", salesInvoice.Receivable_Item_Id));
                sqlParams.Add(new SqlParameter("@Paid_Amount", salesInvoice.Paid_Amount));
                sqlParams.Add(new SqlParameter("@Cash_Amount", salesInvoice.Cash_Amount));
                sqlParams.Add(new SqlParameter("@Cheque_Amount", salesInvoice.Cheque_Amount));
                sqlParams.Add(new SqlParameter("@Card_Amount", salesInvoice.Card_Amount));
                //sqlParams.Add(new SqlParameter("@Credit_Note_Amount", salesInvoice.Credit_Note_Amount));
                

                if (salesInvoice.Cheque_Date == DateTime.MinValue)
                {
                    sqlParams.Add(new SqlParameter("@Cheque_Date", "01/01/1999"));
                }
                else
                {
                    sqlParams.Add(new SqlParameter("@Cheque_Date", salesInvoice.Cheque_Date));
                }

                sqlParams.Add(new SqlParameter("@CreditNote_Amount", salesInvoice.Credit_Note_Amount));

                decimal newcreditnoteamount = creditnoteamount - salesInvoice.Credit_Note_Amount;

                sqlParams.Add(new SqlParameter("@Credit_Note_Amount", newcreditnoteamount));


                sqlParams.Add(new SqlParameter("@Cheque_No", salesInvoice.Cheque_No));
                sqlParams.Add(new SqlParameter("@Bank_Name", salesInvoice.Bank_Name));
                sqlParams.Add(new SqlParameter("@Credit_Card_No", salesInvoice.Credit_Card_No));

                sqlParams.Add(new SqlParameter("@Created_By", salesInvoice.Created_By));
                sqlParams.Add(new SqlParameter("@Created_On", DateTime.Now));
                sqlParams.Add(new SqlParameter("@Updated_By", salesInvoice.Updated_By));
                sqlParams.Add(new SqlParameter("@Updated_On", DateTime.Now));
                sqlParams.Add(new SqlParameter("@Updated_Date", DateTime.Now));

                sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Insert_Receivable_Item_Data.ToString(), CommandType.StoredProcedure);
            
        }

        public decimal Get_Credit_Note_Amount(int Sales_Credit_Note_Id)
        {

            decimal creditnoteamount = 0;

            List<SqlParameter> sqlparam = new List<SqlParameter>();

            sqlparam.Add(new SqlParameter("@Sales_Credit_Note_Id", Sales_Credit_Note_Id));

            DataTable dt = sqlHelper.ExecuteDataTable(sqlparam, Storeprocedures.Get_Credit_Note_Details_By_Id_Sp1.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (!dr.IsNull("Credit_Note_Amount"))

                        creditnoteamount = Convert.ToDecimal(dr["Credit_Note_Amount"]);
                }
            }

            return creditnoteamount;
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

        public bool Check_Quantity(int Quantity,int Branch_Id, string SKU_Code)
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

        //Added by vinod mane on 10/10/2016
        public List<SalesInvoiceInfo> Get_Gift_Voucher_Details_By_Id() //......
        {

            List<SalesInvoiceInfo> GiftVoucherDetails = new List<SalesInvoiceInfo>();

            List<SqlParameter> sqlparam = new List<SqlParameter>();

            //sqlparam.Add(new SqlParameter("@Gift_Voucher_Id", Gift_Voucher_Id));

            DataTable dt = sqlHelper.ExecuteDataTable(sqlparam, Storeprocedures.Giftvoucher_Data_sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in dt.Rows)
            {
                SalesInvoiceInfo Sales = new SalesInvoiceInfo();

                Sales.Gift_Voucher_Id = Convert.ToInt32(dr["Gift_Voucher_Id"]);

                Sales.Gift_Voucher_No = Convert.ToString(dr["Gift_Voucher_No"]);

                Sales.Gift_Voucher_Amount = Convert.ToDecimal(dr["Gift_Voucher_Amount"]);

                GiftVoucherDetails.Add(Sales);

            }
            return GiftVoucherDetails;
        }
        //End
    }
}















//public SalesInvoiceInfo Get_Receivable_Details_By_Id(int Sales_Invoice_Id) //.......
//{

//    SalesInvoiceInfo rInfo = new SalesInvoiceInfo();

//    List<SqlParameter> sqlparam = new List<SqlParameter>();

//    sqlparam.Add(new SqlParameter("@Sales_Invoice_Id", Sales_Invoice_Id));

//    DataTable dt = sqlHelper.ExecuteDataTable(sqlparam, Storeprocedures.sp_Get_Receivable_Search_Data_new.ToString(), CommandType.StoredProcedure);

//    if (dt != null && dt.Rows.Count > 0)
//    {
//        foreach (DataRow dr in dt.Rows)
//        {

//            if (!dr.IsNull("Sales_Invoice_Id"))

//                rInfo.Sales_Invoice_Id = Convert.ToInt32(dr["Sales_Invoice_Id"]);

//            if (!dr.IsNull("Receivable_Id"))

//                rInfo.Receivable_Id = Convert.ToInt32(dr["Receivable_Id"]);

//            if (!dr.IsNull("Balance_Amount"))
//            {
//                rInfo.Balance_Amount = Convert.ToDecimal(dr["Balance_Amount"]);
//            }
//            else
//            {
//                rInfo.Balance_Amount = Convert.ToDecimal(dr["Total_MRP_Amount"]);
//            }

//            if (!dr.IsNull("Payment_Status"))

//                rInfo.Payment_Status = Convert.ToInt32(dr["Payment_Status"]);

//            if (!dr.IsNull("Total_MRP_Amount"))

//                rInfo.Total_MRP_Amount = Convert.ToDecimal(dr["Total_MRP_Amount"]);

//        }
//    }

//    return rInfo;
//}

//public List<Receivable> Get_Receivable_Items_By_Id(int Receivable_Id)
//{

//    List<Receivable> Receivables = new List<Receivable>();

//    List<SqlParameter> sqlParamList = new List<SqlParameter>();

//    sqlParamList.Add(new SqlParameter("@Receivable_Id", Receivable_Id));


//    //sqlParamList.Add(new SqlParameter("@Receivable_Item_Id", Receivable_Item_Id));


//    DataTable dt = sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.Get_Receivable_Data_Item_By_Id_Sp.ToString(), CommandType.StoredProcedure);

//    foreach (DataRow dr in dt.Rows)
//    {
//        Receivables.Add(Get_Receivable_Item_Values(dr));
//    }

//    return Receivables;
//}

//private SalesInvoiceInfo Get_Receivable_Item_Values(DataRow dr)
//{

//    SalesInvoiceInfo Receivable = new SalesInvoiceInfo();

//    if (!dr.IsNull("Receivable_Item_Id"))

//        Receivable.Receivable_Item_Id = Convert.ToInt32(dr["Receivable_Item_Id"]);

//    if (!dr.IsNull("Receivable_Id"))

//        Receivable.Receivable_Id = Convert.ToInt32(dr["Receivable_Id"]);

//    if (!dr.IsNull("Sales_Credit_Note_Id"))

//        Receivable.Sales_Credit_Note_Id = Convert.ToInt32(dr["Sales_Credit_Note_Id"]);

//    if (!dr.IsNull("Paid_Amount"))

//        Receivable.Paid_Amount = Convert.ToInt32(dr["Paid_Amount"]);

//    if (!dr.IsNull("Gift_Voucher_Id"))

//        Receivable.Gift_Voucher_Id = Convert.ToInt32(dr["Gift_Voucher_Id"]);

//    if (!dr.IsNull("Cash_Amount"))

//        Receivable.Cash_Amount = Convert.ToInt32(dr["Cash_Amount"]);

//    if (!dr.IsNull("Cheque_Amount"))

//        Receivable.Cheque_Amount = Convert.ToDecimal(dr["Cheque_Amount"]);

//    if (!dr.IsNull("Card_Amount"))

//        Receivable.Card_Amount = Convert.ToDecimal(dr["Card_Amount"]);

//    if (!dr.IsNull("Gift_Voucher_Amount"))

//        Receivable.Gift_Voucher_Amount = Convert.ToDecimal(dr["Gift_Voucher_Amount"]);

//    if (!dr.IsNull("Cheque_Date"))

//        Receivable.Cheque_Date = Convert.ToDateTime(dr["Cheque_Date"]);

//    Receivable.Cheque_Date.ToShortDateString();

//    if (!dr.IsNull("Cheque_No"))

//        Receivable.Cheque_No = Convert.ToString(dr["Cheque_No"]);

//    if (!dr.IsNull("Bank_Name"))

//        Receivable.Bank_Name = Convert.ToString(dr["Bank_Name"]);

//    if (!dr.IsNull("Credit_Card_No"))

//        Receivable.Credit_Card_No = Convert.ToString(dr["Credit_Card_No"]);

//    if (!dr.IsNull("Total_MRP_Amount"))

//        Receivable.Total_MRP_Amount = Convert.ToDecimal(dr["Total_MRP_Amount"]);

//    if (!dr.IsNull("Created_On"))

//        Receivable.Created_Date = Convert.ToDateTime(dr["Created_Date"]);

//    if (!dr.IsNull("Created_By"))

//        Receivable.Created_By = Convert.ToInt32(dr["Created_By"]);

//    if (!dr.IsNull("Created_Date"))

//        Receivable.Credit_Note_Date = Convert.ToDateTime(dr["Created_Date"]);

//    Receivable.Credit_Note_Date.ToShortDateString();

//    if (!dr.IsNull("Credit_Note_Amount"))

//        Receivable.Credit_Note_Amount = Convert.ToDecimal(dr["Credit_Note_Amount"]);

//    if (!dr.IsNull("Credit_Note_No"))

//        Receivable.Credit_Note_No = Convert.ToString(dr["Credit_Note_No"]);

//    if (!dr.IsNull("Gift_Voucher_No"))

//        Receivable.Gift_Voucher_No = Convert.ToString(dr["Gift_Voucher_No"]);

//    return Receivable;
//}


//public List<Receivable> Get_Gift_Voucher_Details_By_Id() //......
//{

//    List<Receivable> Receivables = new List<Receivable>();

//    List<SqlParameter> sqlparam = new List<SqlParameter>();

//    //sqlparam.Add(new SqlParameter("@Gift_Voucher_Id", Gift_Voucher_Id));

//    DataTable dt = sqlHelper.ExecuteDataTable(sqlparam, Storeprocedures.Giftvoucher_Data_sp.ToString(), CommandType.StoredProcedure);

//    foreach (DataRow dr in dt.Rows)
//    {
//        Receivable Receivable = new Receivable();

//        Receivable.Gift_Voucher_Id = Convert.ToInt32(dr["Gift_Voucher_Id"]);

//        Receivable.Gift_Voucher_No = Convert.ToString(dr["Gift_Voucher_No"]);

//        Receivable.Gift_Voucher_Amount = Convert.ToDecimal(dr["Gift_Voucher_Amount"]);

//        Receivables.Add(Receivable);

//    }
//    return Receivables;
//}
