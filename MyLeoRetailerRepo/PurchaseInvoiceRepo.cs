using MyLeoRetailerInfo.PurchaseInvoice;
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
using MyLeoRetailerInfo.PurchaseReturn;
using System.Transactions;
using MyLeoRetailerRepo.Common;


namespace MyLeoRetailerRepo
{
    public class PurchaseInvoiceRepo
    {
        SQL_Repo sqlHelper = null;

        public PurchaseInvoiceRepo()
        {
            sqlHelper = new SQL_Repo();
        }

        private List<SqlParameter> Set_Values_In_Purchase_Invoice(PurchaseInvoiceInfo PurchaseInvoice)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            if (PurchaseInvoice.Purchase_Invoice_Id != 0)
            {
                sqlParams.Add(new SqlParameter("@Purchase_Invoice_Id", PurchaseInvoice.Purchase_Invoice_Id));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Created_By", PurchaseInvoice.Created_By));

                sqlParams.Add(new SqlParameter("@Created_Date", PurchaseInvoice.Created_Date));
            }

            sqlParams.Add(new SqlParameter("@Purchase_Invoice_No", PurchaseInvoice.Purchase_Invoice_No));

            sqlParams.Add(new SqlParameter("@Vendor_Id", PurchaseInvoice.Vendor_Id));

            sqlParams.Add(new SqlParameter("@Payament_Status", PurchaseInvoice.Payament_Status));

            sqlParams.Add(new SqlParameter("@Against_Form", PurchaseInvoice.Against_Form));

            sqlParams.Add(new SqlParameter("@Against_Form_No", PurchaseInvoice.Against_Form_No));

            sqlParams.Add(new SqlParameter("@Purchase_Packing_No", PurchaseInvoice.Purchase_Packing_No));

            sqlParams.Add(new SqlParameter("@Challan_No", PurchaseInvoice.Challan_No));

            if (PurchaseInvoice.Purchase_Invoice_Date != DateTime.MinValue)
            {
                sqlParams.Add(new SqlParameter("@Purchase_Invoice_Date", PurchaseInvoice.Purchase_Invoice_Date));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Purchase_Invoice_Date", DateTime.MinValue));
            }

            if (PurchaseInvoice.Against_Form_Date != DateTime.MinValue)
            {
                sqlParams.Add(new SqlParameter("@Against_Form_Date", PurchaseInvoice.Against_Form_Date));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Against_Form_Date", DateTime.MinValue));
            }

            if (PurchaseInvoice.Purchase_Packing_Date != DateTime.MinValue)
            {
                sqlParams.Add(new SqlParameter("@Purchase_Packing_Date", PurchaseInvoice.Purchase_Packing_Date));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Purchase_Packing_Date", DateTime.MinValue));
            }

            if (PurchaseInvoice.Challan_Date != DateTime.MinValue)
            {
                sqlParams.Add(new SqlParameter("@Challan_Date", PurchaseInvoice.Challan_Date));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Challan_Date", DateTime.MinValue));
            }

            sqlParams.Add(new SqlParameter("@Total_Quantity", PurchaseInvoice.Total_Quantity));

            sqlParams.Add(new SqlParameter("@Total_Amount", PurchaseInvoice.Total_Amount));


            sqlParams.Add(new SqlParameter("@Discount_Percentage", PurchaseInvoice.Discount_Percentage));

            sqlParams.Add(new SqlParameter("@Discount_Amount", PurchaseInvoice.Discount_Amount));

            sqlParams.Add(new SqlParameter("@Gross_Amount", PurchaseInvoice.Gross_Amount));

            sqlParams.Add(new SqlParameter("@Tax_Percentage", PurchaseInvoice.Tax_Percentage));

            sqlParams.Add(new SqlParameter("@Round_Off_Amount", PurchaseInvoice.Round_Off_Amount));

            sqlParams.Add(new SqlParameter("@Net_Amount", PurchaseInvoice.Net_Amount));

            if (PurchaseInvoice.Payment_Due_Date != DateTime.MinValue)
            {
                sqlParams.Add(new SqlParameter("@Payment_Due_Date", PurchaseInvoice.Payment_Due_Date));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Payment_Due_Date", DateTime.MinValue));
            }

            sqlParams.Add(new SqlParameter("@Discount_Percentage_Before_Due_Date", PurchaseInvoice.Discount_Percentage_Before_Due_Date));
           
            sqlParams.Add(new SqlParameter("@Transporter_Id", PurchaseInvoice.Transporter_Id));

            sqlParams.Add(new SqlParameter("@Lr_No", PurchaseInvoice.Lr_No));

            if (PurchaseInvoice.Lr_Date != DateTime.MinValue)
            {
                sqlParams.Add(new SqlParameter("@Lr_Date", PurchaseInvoice.Lr_Date));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Lr_Date", DateTime.MinValue));
            }

            sqlParams.Add(new SqlParameter("@Updated_By", PurchaseInvoice.Updated_By));

            sqlParams.Add(new SqlParameter("@Updated_Date", PurchaseInvoice.Updated_Date));

            return sqlParams;
        }

        private List<SqlParameter> Set_Values_In_Purchase_Invoice_Item(PurchaseInvoiceInfo item)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

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

        private PurchaseInvoiceInfo Get_Purchase_Invoice_Items_By_SKU_Values(DataRow dr)
        {
            PurchaseInvoiceInfo PurchaseInvoice = new PurchaseInvoiceInfo();

            if (!dr.IsNull("Article_No"))
            {
                PurchaseInvoice.Article_No = Convert.ToString(dr["Article_No"]);
            }

            if (!dr.IsNull("Brand_Id"))
            {
                PurchaseInvoice.Brand_Id = Convert.ToInt32(dr["Brand_Id"]);
            }

            if (!dr.IsNull("Brand_Name"))
            {
                PurchaseInvoice.Brand = Convert.ToString(dr["Brand_Name"]);
            }

            if (!dr.IsNull("Colour_Id"))
            {
                PurchaseInvoice.Color_Id = Convert.ToInt32(dr["Colour_Id"]);
            }

            if (!dr.IsNull("Colour_Name"))
            {
                PurchaseInvoice.Color = Convert.ToString(dr["Colour_Name"]);
            }

            if (!dr.IsNull("Category_Id"))
            {
                PurchaseInvoice.Category_Id = Convert.ToInt32(dr["Category_Id"]);
            }

            if (!dr.IsNull("Category"))
            {
                PurchaseInvoice.Category = Convert.ToString(dr["Category"]);
            }

            if (!dr.IsNull("Sub_Category_Id"))
            {
                PurchaseInvoice.SubCategory_Id = Convert.ToInt32(dr["Sub_Category_Id"]);
            }

            if (!dr.IsNull("Sub_Category"))
            {
                PurchaseInvoice.SubCategory = Convert.ToString(dr["Sub_Category"]);
            }

            if (!dr.IsNull("Size_Group_Id"))
            {
                PurchaseInvoice.Size_Group_Id = Convert.ToInt32(dr["Size_Group_Id"]);
            }

            if (!dr.IsNull("Size_Group_Name"))
            {
                PurchaseInvoice.Size_Group_Name = Convert.ToString(dr["Size_Group_Name"]);
            }

            if (!dr.IsNull("Size_Id"))
            {
                PurchaseInvoice.Size_Id = Convert.ToInt32(dr["Size_Id"]);
            }

            if (!dr.IsNull("Size_Name"))
            {
                PurchaseInvoice.Size_Name = Convert.ToString(dr["Size_Name"]);
            }

            if (!dr.IsNull("Purchase_Price"))
            {
                PurchaseInvoice.WSR_Price = Convert.ToInt32(dr["Purchase_Price"]);
            }

            return PurchaseInvoice;
        }
       
        public PurchaseInvoiceInfo Get_Purchase_Invoice_Items_By_SKU_Code(string SKU_Code)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@SKU_Code", SKU_Code));

            PurchaseInvoiceInfo PurchaseInvoice = new PurchaseInvoiceInfo();

            DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Purchase_Invoice_Items_By_SKU_Code.ToString(), CommandType.StoredProcedure);

            List<DataRow> drList = new List<DataRow>();

            drList = dt.AsEnumerable().ToList();

            foreach (DataRow dr in drList)
            {
                PurchaseInvoice = Get_Purchase_Invoice_Items_By_SKU_Values(dr);
            }

            return PurchaseInvoice;
        }

        public int Insert_Purchase_Invoice(PurchaseInvoiceInfo PurchaseInvoice)
        {
            using (TransactionScope scope = new TransactionScope())
            {
            PurchaseInvoice.Purchase_Invoice_Id = Convert.ToInt32(sqlHelper.ExecuteScalerObj(Set_Values_In_Purchase_Invoice(PurchaseInvoice), Storeprocedures.sp_Insert_Purchase_Invoice.ToString(), CommandType.StoredProcedure));

            foreach (var item in PurchaseInvoice.PurchaseInvoices)
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();

                    item.Purchase_Invoice_Id = PurchaseInvoice.Purchase_Invoice_Id;                    

                    sqlHelper.ExecuteNonQuery(Set_Values_In_Purchase_Invoice_Item(item), Storeprocedures.sp_Insert_Purchase_Invoice_Item.ToString(), CommandType.StoredProcedure);
                }
                scope.Complete();

            }

            return PurchaseInvoice.Purchase_Invoice_Id;
        }

        private PurchaseInvoiceInfo Get_Purchase_Invoice_Value(DataRow dr)
        {
            PurchaseInvoiceInfo PurchaseInvoice = new PurchaseInvoiceInfo();

            PurchaseInvoice.Purchase_Invoice_Id = Convert.ToInt32(dr["Purchase_Invoice_Id"]);

            PurchaseInvoice.Purchase_Invoice_No = Convert.ToString(dr["Purchase_Invoice_No"]);

            PurchaseInvoice.Purchase_Invoice_Date = Convert.ToDateTime(dr["Purchase_Invoice_Date"]);

            PurchaseInvoice.Vendor_Id = Convert.ToInt32(dr["Vendor_Id"]);

            PurchaseInvoice.Vendor_Name = Convert.ToString(dr["Vendor_Name"]);

            PurchaseInvoice.Total_Quantity = Convert.ToInt32(dr["Total_Quantity"]);

            PurchaseInvoice.Net_Amount = Convert.ToDecimal(dr["Net_Amount"]);

            PurchaseInvoice.Transporter_Id = Convert.ToInt32(dr["Transporter_Id"]);

            PurchaseInvoice.Transporter_Name = Convert.ToString(dr["Transporter_Name"]);

            PurchaseInvoice.Challan_No = Convert.ToString(dr["Challan_No"]);

            PurchaseInvoice.Lr_No = Convert.ToString(dr["Lr_No"]);

            return PurchaseInvoice;

        }
        
        public List<PurchaseInvoiceInfo> Get_Purchase_Invoices(ref Pagination_Info Pager, string Purchase_Invoice_No)
        {
            List<PurchaseInvoiceInfo> PurchaseInvoices = new List<PurchaseInvoiceInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Purchase_Invoice_No", Purchase_Invoice_No));

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_Get_Purchase_Invoices.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref Pager))
            {
                PurchaseInvoices.Add(Get_Purchase_Invoice_Value(dr));
            }

            return PurchaseInvoices;
        }

        //public DataTable Get_Purchase_Invoices(QueryInfo query_Details)
        //{
        //    return sqlHelper.Get_Table_With_Where(query_Details);
        //}

        public List<PurchaseInvoiceInfo> Get_Purchase_Invoice_No_By_Id(int Vendor_Id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Vendor_Id", Vendor_Id));

            List<PurchaseInvoiceInfo> PurchaseInvoices = new List<PurchaseInvoiceInfo>();
            DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Purchase_Invoice_By_Id.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in dt.Rows)
            {
                PurchaseInvoiceInfo PurchaseInvoice = new PurchaseInvoiceInfo();

                PurchaseInvoice.Purchase_Invoice_Id = Convert.ToInt32(dr["Purchase_Invoice_Id"]);

                PurchaseInvoice.Purchase_Invoice_No = Convert.ToString(dr["Purchase_Invoice_No"]);

                PurchaseInvoices.Add(PurchaseInvoice);
            }
            return PurchaseInvoices;
        }


        public PurchaseInvoiceInfo Get_Vendor_Detalis_By_Id(int vendor_Id)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Vendor_ID", vendor_Id));

            PurchaseInvoiceInfo Vendor = new PurchaseInvoiceInfo();

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_Get_Vendor_Details_By_Id.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {

                foreach (DataRow dr in dt.Rows)
                {
                    Vendor.Vendor_Id = Convert.ToInt32(dr["Vendor_ID"]);

                    Vendor.Vendor_Address = Convert.ToString(dr["Vendor_Address"]);

                    Vendor.Vendor_Vat_No = Convert.ToString(dr["Vendor_Vat_No"]);

                    Vendor.Tax_Percentage = Convert.ToDecimal(dr["Vendor_Vat_Rate"]);
                }
            }

            return Vendor;
        }

        public List<PurchaseInvoiceInfo> Get_Purchase_Invoice_Details_By_Id(int Purchase_Invoice_Id)
        {

            List<PurchaseInvoiceInfo> PurchaseInvoices = new List<PurchaseInvoiceInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Purchase_Invoice_Id", Purchase_Invoice_Id));

            //sqlParams.Add(new SqlParameter("@SKU_Code", SKU_Code));

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.Get_Purchase_Invoice_Data_By_Id_Sp1.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {

                foreach (DataRow dr in dt.Rows)
                {
                   PurchaseInvoiceInfo pInfo = new PurchaseInvoiceInfo();

                    pInfo.Purchase_Invoice_Id = Convert.ToInt32(dr["Purchase_Invoice_Id"]);

                    pInfo.Purchase_Invoice_No = Convert.ToString(dr["Purchase_Invoice_No"]);

                    pInfo.Vendor_Id = Convert.ToInt32(dr["Vendor_Id"]);

                    pInfo.Payament_Status = Convert.ToInt32(dr["Payament_Status"]);

                    pInfo.Against_Form = Convert.ToInt32(dr["Against_Form"]);

                    pInfo.Against_Form_No = Convert.ToString(dr["Against_Form_No"]);

                    pInfo.Purchase_Packing_No = Convert.ToString(dr["Purchase_Packing_No"]);

                    pInfo.Purchase_Invoice_Date = Convert.ToDateTime(dr["Purchase_Invoice_Date"]);

                    pInfo.Against_Form_Date = Convert.ToDateTime(dr["Against_Form_Date"]);

                    pInfo.Purchase_Packing_Date = Convert.ToDateTime(dr["Purchase_Packing_Date"]);

                    pInfo.Challan_Date = Convert.ToDateTime(dr["Challan_Date"]);

                    pInfo.Total_Quantity = Convert.ToInt32(dr["Total_Quantity"]);

                    pInfo.Total_Amount = Convert.ToInt32(dr["Total_Amount"]);

                    pInfo.Discount_Percentage = Convert.ToInt32(dr["Discount_Percentage"]);

                    pInfo.Discount_Amount = Convert.ToInt32(dr["Discount_Amount"]);

                    pInfo.Gross_Amount = Convert.ToInt32(dr["Gross_Amount"]);

                    pInfo.Tax_Percentage = Convert.ToInt32(dr["Tax_Percentage"]);

                    pInfo.Round_Off_Amount = Convert.ToInt32(dr["Round_Off_Amount"]);

                    pInfo.Net_Amount = Convert.ToInt32(dr["Net_Amount"]);

                    pInfo.Payment_Due_Date = Convert.ToDateTime(dr["Payment_Due_Date"]);

                    pInfo.Discount_Percentage_Before_Due_Date = Convert.ToInt32(dr["Discount_Percentage_Before_Due_Date"]);

                    pInfo.Transporter_Id = Convert.ToInt32(dr["Transporter_Id"]);

                    pInfo.Lr_No = Convert.ToString(dr["Lr_No"]);

                    pInfo.Lr_Date = Convert.ToDateTime(dr["Lr_Date"]);

                    pInfo.Created_Date = Convert.ToDateTime(dr["Created_Date"]);

                    pInfo.Created_By = Convert.ToInt32(dr["Created_By"]);

                    pInfo.Updated_Date = Convert.ToDateTime(dr["Updated_Date"]);

                    pInfo.Updated_By = Convert.ToInt32(dr["Updated_By"]);

                    pInfo.Purchase_Invoice_Id = Convert.ToInt32(dr["Purchase_Invoice_Id"]);

                    pInfo.Purchase_Invoice_Item_Id = Convert.ToInt32(dr["Purchase_Invoice_Item_Id"]);

                    pInfo.Purchase_Order_Id = Convert.ToInt32(dr["Purchase_Order_Id"]);

                    pInfo.SKU_Code = Convert.ToString(dr["SKU_Code"]);

                    pInfo.Size_Group_Id = Convert.ToInt32(dr["Size_Group_Id"]);

                    pInfo.Size_Group_Name = Convert.ToString(dr["Size_Group_Name"]);

                    pInfo.Size_Id = Convert.ToInt32(dr["Size_Id"]);

                    pInfo.Quantity = Convert.ToInt32(dr["Quantity"]);

                    pInfo.Total_Amount = Convert.ToInt32(dr["Total_Amount"]);

                    pInfo.Vendor_Name = Convert.ToString(dr["Vendor_Name"]);

                    pInfo.Article_No = Convert.ToString(dr["Article_No"]);

                    pInfo.Brand_Id = Convert.ToInt32(dr["Brand_Id"]);

                    pInfo.Brand = Convert.ToString(dr["Brand_Name"]);

                    pInfo.Category_Id = Convert.ToInt32(dr["Category_Id"]);

                    pInfo.Category = Convert.ToString(dr["Category"]);

                    pInfo.SubCategory = Convert.ToString(dr["Sub_Category"]);

                    pInfo.SubCategory_Id = Convert.ToInt32(dr["Sub_Category_Id"]);

                    pInfo.Color_Id = Convert.ToInt32(dr["Colour_Id"]);

                    pInfo.Color = Convert.ToString(dr["Colour_Name"]);

                    pInfo.Size_Name = Convert.ToString(dr["Size_Name"]);

                    pInfo.Size_Id = Convert.ToInt32(dr["Size_Id"]);

                    pInfo.Transporter_Name = Convert.ToString(dr["Transporter_Name"]);

                    pInfo.Vendor_Name = Convert.ToString(dr["Vendor_Name"]);

                    pInfo.Purchase_Order_No = Convert.ToString(dr["Purchase_Order_No"]);

                    pInfo.WSR_Price = Convert.ToDecimal(dr["Purchase_Price"]);

                    PurchaseInvoices.Add(pInfo);

                }
            }

            return PurchaseInvoices;
        }

        public void Update_Purchase_Invoice(PurchaseInvoiceInfo PurchaseInvoice)
        {
            sqlHelper.ExecuteNonQuery(Set_Values_In_Purchase_Invoice(PurchaseInvoice), Storeprocedures.sp_Update_Purchase_Invoice.ToString(), CommandType.StoredProcedure);

            foreach (var item in PurchaseInvoice.PurchaseInvoices)
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();

                if (item.Purchase_Invoice_Item_Id != 0)
                {
                    sqlParams.Add(new SqlParameter("@Purchase_Invoice_Item_Id", item.Purchase_Invoice_Item_Id));
                }
                else
                {
                    sqlParams.Add(new SqlParameter("@Created_By", PurchaseInvoice.Created_By));

                    sqlParams.Add(new SqlParameter("@Created_Date", PurchaseInvoice.Created_Date));
                }

                sqlParams.Add(new SqlParameter("@Purchase_Invoice_Id", PurchaseInvoice.Purchase_Invoice_Id));

                sqlParams.Add(new SqlParameter("@Purchase_Order_Id", item.Purchase_Order_Id));

                sqlParams.Add(new SqlParameter("@SKU_Code", item.SKU_Code));

                sqlParams.Add(new SqlParameter("@Size_Group_Id", item.Size_Group_Id));

                sqlParams.Add(new SqlParameter("@Size_Id", item.Size_Id));

                sqlParams.Add(new SqlParameter("@Quantity", item.Quantity));

                sqlParams.Add(new SqlParameter("@Total_Amount", item.Amount));

                sqlParams.Add(new SqlParameter("@Updated_By", PurchaseInvoice.Updated_By));

                sqlParams.Add(new SqlParameter("@Updated_Date", PurchaseInvoice.Updated_Date));

                sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Update_Purchase_Invoice_Item.ToString(), CommandType.StoredProcedure);
            }


        }

        private PurchaseInvoiceInfo Get_Purchase_Invoice_Values(DataRow dr)
        {
            PurchaseInvoiceInfo PurchaseInvoice = new PurchaseInvoiceInfo();

            PurchaseInvoice.Purchase_Invoice_Id = Convert.ToInt32(dr["Purchase_Invoice_Id"]);

            PurchaseInvoice.Purchase_Order_Id = Convert.ToInt32(dr["Purchase_Order_Id"]);

            PurchaseInvoice.Vendor_Id = Convert.ToInt32(dr["Vendor_Id"]);

            //PurchaseInvoice.Purchase_Order_Date = Convert.ToDateTime(dr["Purchase_Order_Date"]);

            PurchaseInvoice.Payament_Status = Convert.ToInt32(dr["Payament_Status"]);

            PurchaseInvoice.Against_Form = Convert.ToInt32(dr["Against_Form"]);

            PurchaseInvoice.Against_Form_No = Convert.ToString(dr["Against_Form_No"]);

            PurchaseInvoice.Purchase_Packing_No = Convert.ToString(dr["Purchase_Packing_No"]);

            PurchaseInvoice.Challan_No = Convert.ToString(dr["Challan_No"]);


            if (dr.IsNull("Purchase_Invoice_Date"))
            {
                PurchaseInvoice.Purchase_Invoice_Date = DateTime.MinValue;
            }
            else
            {
                PurchaseInvoice.Purchase_Invoice_Date = Convert.ToDateTime(dr["Purchase_Invoice_Date"]);
            }

            if (dr.IsNull("Against_Form_Date"))
            {
                PurchaseInvoice.Against_Form_Date = DateTime.MinValue;
            }
            else
            {
                PurchaseInvoice.Against_Form_Date = Convert.ToDateTime(dr["Against_Form_Date"]);
            }

            if (dr.IsNull("Purchase_Packing_Date"))
            {
                PurchaseInvoice.Purchase_Packing_Date = DateTime.MinValue;
            }
            else
            {
                PurchaseInvoice.Purchase_Packing_Date = Convert.ToDateTime(dr["Purchase_Packing_Date"]);
            }

            if (dr.IsNull("Challan_Date"))
            {
                PurchaseInvoice.Challan_Date = DateTime.MinValue;
            }
            else
            {
                PurchaseInvoice.Challan_Date = Convert.ToDateTime(dr["Challan_Date"]);
            }

            PurchaseInvoice.Total_Quantity = Convert.ToInt32(dr["Total_Quantity"]);

            PurchaseInvoice.Total_Amount = Convert.ToDecimal(dr["Total_Amount"]);

            PurchaseInvoice.Discount_Percentage = Convert.ToDecimal(dr["Discount_Percentage"]);

            PurchaseInvoice.Discount_Amount = Convert.ToDecimal(dr["Discount_Amount"]);

            PurchaseInvoice.Gross_Amount = Convert.ToDecimal(dr["Gross_Amount"]);

            PurchaseInvoice.Round_Off_Amount = Convert.ToDecimal(dr["Round_Off_Amount"]);

            PurchaseInvoice.Net_Amount = Convert.ToDecimal(dr["Net_Amount"]);

            if (dr.IsNull("Payment_Due_Date"))
            {
                PurchaseInvoice.Payment_Due_Date = DateTime.MinValue;
            }
            else
            {
                PurchaseInvoice.Payment_Due_Date = Convert.ToDateTime(dr["Payment_Due_Date"]);
            }

            PurchaseInvoice.Discount_Percentage_Before_Due_Date = Convert.ToDecimal(dr["Discount_Percentage_Before_Due_Date"]);

            PurchaseInvoice.Transporter_Id = Convert.ToInt32(dr["Transporter_Id"]);

            PurchaseInvoice.Lr_No = Convert.ToString(dr["Lr_No"]);

            if (dr.IsNull("Lr_Date"))
            {
                PurchaseInvoice.Lr_Date = DateTime.MinValue;
            }
            else
            {
                PurchaseInvoice.Lr_Date = Convert.ToDateTime(dr["Lr_Date"]);
            }

            PurchaseInvoice.Created_Date = Convert.ToDateTime(dr["Created_Date"]);

            PurchaseInvoice.Created_By = Convert.ToInt32(dr["Created_By"]);

            PurchaseInvoice.Updated_Date = Convert.ToDateTime(dr["Updated_Date"]);

            PurchaseInvoice.Updated_By = Convert.ToInt32(dr["Updated_By"]);


            return PurchaseInvoice;
        }       

        public PurchaseInvoiceInfo Get_Purchase_Invoice_By_Id(int Purchase_Invoice_Id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Purchase_Invoice_Id", Purchase_Invoice_Id));

            PurchaseInvoiceInfo PurchaseInvoice = new PurchaseInvoiceInfo();
            DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Purchase_Invoice_By_Id.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {               
                PurchaseInvoice = Get_Purchase_Invoice_Values(dr);
            }
            return PurchaseInvoice;
        }       

        public List<PurchaseInvoiceInfo> Get_Purchase_Invoices()
        {
            List<PurchaseInvoiceInfo> PurchaseInvoices = new List<PurchaseInvoiceInfo>();
            DataTable dt = sqlHelper.ExecuteDataTable(null, Storeprocedures.sp_Get_Purchase_Invoice.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in dt.Rows)
            {
                PurchaseInvoiceInfo PurchaseInvoice = new PurchaseInvoiceInfo();

                PurchaseInvoice.Purchase_Invoice_Id = Convert.ToInt32(dr["Purchase_Invoice_Id"]);

                PurchaseInvoice.Purchase_Invoice_No = Convert.ToString(dr["Purchase_Invoice_No"]);

                PurchaseInvoices.Add(PurchaseInvoice);
            }
            return PurchaseInvoices;
        }


        //

        //Product warehouse
        public DataTable Get_WarehouseProducts(QueryInfo query_Details)
        {
            return sqlHelper.Get_Table_With_Where(query_Details);
        }
        //

    }
}

