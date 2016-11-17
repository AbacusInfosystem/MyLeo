using MyLeoRetailerInfo.Common;
using MyLeoRetailerInfo.Payable;
using MyLeoRetailerRepo.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerRepo
{
   public class PayableRepo
    {
        SQL_Repo sqlHelper = null;

        public PayableRepo()
		{
			sqlHelper = new SQL_Repo();
		}

        public int Insert_Payable_Item_Data(PayableInfo Payable)
        {

            return Convert.ToInt32(sqlHelper.ExecuteScalerObj(Set_Values_In_Payable_Item(Payable), Storeprocedures.sp_Insert_Payable_Item_Data.ToString(), CommandType.StoredProcedure));

        }

        private List<SqlParameter> Set_Values_In_Payable_Item(PayableInfo Payable)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Payable_Id", Payable.Payable_Id));
            sqlParams.Add(new SqlParameter("@Purchase_Credit_Note_Id", Payable.Purchase_Credit_Note_Id));
            sqlParams.Add(new SqlParameter("@Payable_Item_Id", Payable.Payable_Item_Id));
            sqlParams.Add(new SqlParameter("@Payment_Mode", Payable.Payment_Mode));
            sqlParams.Add(new SqlParameter("@Discount_Amount", Payable.Discount_Amount));
            sqlParams.Add(new SqlParameter("@Discount_Percentage", Payable.Discount_Percentage));
            sqlParams.Add(new SqlParameter("@Payament_Date", Payable.Payament_Date));

            
            sqlParams.Add(new SqlParameter("@Remark", Payable.Remark));
            sqlParams.Add(new SqlParameter("@Credit_Note_No", Payable.Credit_Note_No));
            sqlParams.Add(new SqlParameter("@Credit_Note_Amount", Payable.Credit_Note_Amount)); 

            if (Payable.Payment_Mode == 1)
            {
                sqlParams.Add(new SqlParameter("@Paid_Amount", Payable.Paid_Amount));
                sqlParams.Add(new SqlParameter("@Vendor_Employee_Name", Payable.Vendor_Employee_Name));
                sqlParams.Add(new SqlParameter("@Credit_Card_No", "NA"));
                sqlParams.Add(new SqlParameter("@Debit_Card_No", "NA"));
                sqlParams.Add(new SqlParameter("@Cheque_No", "NA"));
                sqlParams.Add(new SqlParameter("@Cheque_Date", "01/01/1999"));
                sqlParams.Add(new SqlParameter("@Bank_Name", "NA"));
            }
            else if (Payable.Payment_Mode == 2)
            {
                sqlParams.Add(new SqlParameter("@Paid_Amount", Payable.Paid_Amount));
                sqlParams.Add(new SqlParameter("@Credit_Card_No", Payable.Credit_Card_No));
                sqlParams.Add(new SqlParameter("@Vendor_Employee_Name", "NA"));
                sqlParams.Add(new SqlParameter("@Debit_Card_No", "NA"));
                sqlParams.Add(new SqlParameter("@Cheque_No", "NA"));
                sqlParams.Add(new SqlParameter("@Cheque_Date", "01/01/1999"));
                sqlParams.Add(new SqlParameter("@Bank_Name", "NA"));
            }
            else if (Payable.Payment_Mode == 3)
            {
                sqlParams.Add(new SqlParameter("@Paid_Amount", Payable.Paid_Amount));
                sqlParams.Add(new SqlParameter("@Vendor_Employee_Name", "NA"));
                sqlParams.Add(new SqlParameter("@Credit_Card_No", "NA"));
                sqlParams.Add(new SqlParameter("@Debit_Card_No", Payable.Debit_Card_No));
                sqlParams.Add(new SqlParameter("@Cheque_No", "NA"));
                sqlParams.Add(new SqlParameter("@Cheque_Date", "01/01/1999"));
                sqlParams.Add(new SqlParameter("@Bank_Name", "NA"));
            }
            else if(Payable.Payment_Mode == 4)
            {
                sqlParams.Add(new SqlParameter("@Paid_Amount", Payable.Paid_Amount));
                sqlParams.Add(new SqlParameter("@Vendor_Employee_Name", "NA"));
                sqlParams.Add(new SqlParameter("@Credit_Card_No", "NA"));
                sqlParams.Add(new SqlParameter("@Debit_Card_No", "NA"));
                sqlParams.Add(new SqlParameter("@Cheque_No", Payable.Cheque_No));
                sqlParams.Add(new SqlParameter("@Cheque_Date", Payable.Cheque_Date));
                sqlParams.Add(new SqlParameter("@Bank_Name", Payable.Bank_Name));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Paid_Amount", "0"));
                sqlParams.Add(new SqlParameter("@Vendor_Employee_Name", "NA"));
                sqlParams.Add(new SqlParameter("@Credit_Card_No", "NA"));
                sqlParams.Add(new SqlParameter("@Debit_Card_No", "NA"));
                sqlParams.Add(new SqlParameter("@Cheque_No", "NA"));
                sqlParams.Add(new SqlParameter("@Cheque_Date", "01/01/1999"));
                sqlParams.Add(new SqlParameter("@Bank_Name", "NA"));
            }

            sqlParams.Add(new SqlParameter("@Created_By", Payable.Created_By));
            sqlParams.Add(new SqlParameter("@Created_On", Payable.Created_Date));
            sqlParams.Add(new SqlParameter("@Updated_By", Payable.Updated_By));
            sqlParams.Add(new SqlParameter("@Updated_On", Payable.Updated_Date));

            return sqlParams;
        }

        public int Update_Payable_Items_Data(PayableInfo Payable)
        {
            Payable.Payable_Item_Id = Convert.ToInt32(sqlHelper.ExecuteScalerObj(Update_Payable_Item_Data(Payable), Storeprocedures.sp_Update_Payable_Item.ToString(), CommandType.StoredProcedure));

            return Payable.Payable_Item_Id;
        }

        private List<SqlParameter> Update_Payable_Item_Data(PayableInfo Payable)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();
            if (Payable.Payable_Item_Id != 0)
            {
                sqlParams.Add(new SqlParameter("@Payable_Item_Id", Payable.Payable_Item_Id));
            }

            sqlParams.Add(new SqlParameter("@Purchase_Credit_Note_Id ", Payable.Purchase_Credit_Note_Id));
            sqlParams.Add(new SqlParameter("@Payment_Mode", Payable.Payment_Mode));
            sqlParams.Add(new SqlParameter("@Discount_Amount", Payable.Discount_Amount));
            sqlParams.Add(new SqlParameter("@Discount_Percentage", Payable.Discount_Percentage));
            sqlParams.Add(new SqlParameter("@Payament_Date", Payable.Payament_Date));
            sqlParams.Add(new SqlParameter("@Employee_Id", Payable.Employee_Id));
            sqlParams.Add(new SqlParameter("@Remark", Payable.Remark));
            sqlParams.Add(new SqlParameter("@Credit_Note_No", Payable.Credit_Note_No));
            sqlParams.Add(new SqlParameter("@Credit_Note_Amount", Payable.Credit_Note_Amount));

            if (Payable.Payment_Mode == 1)
            {
                sqlParams.Add(new SqlParameter("@Paid_Amount", Payable.Paid_Amount));
                sqlParams.Add(new SqlParameter("@Credit_Card_No", "NA"));
                sqlParams.Add(new SqlParameter("@Debit_Card_No", "NA"));
                sqlParams.Add(new SqlParameter("@Cheque_No", "NA"));
                sqlParams.Add(new SqlParameter("@Cheque_Date", "01/01/1999"));
                sqlParams.Add(new SqlParameter("@Bank_Name", "NA"));
            }
            else if (Payable.Payment_Mode == 2)
            {
                sqlParams.Add(new SqlParameter("@Paid_Amount", Payable.Paid_Amount));
                sqlParams.Add(new SqlParameter("@Credit_Card_No", Payable.Credit_Card_No));
                sqlParams.Add(new SqlParameter("@Debit_Card_No", "NA"));
                sqlParams.Add(new SqlParameter("@Cheque_No", "NA"));
                sqlParams.Add(new SqlParameter("@Cheque_Date", "01/01/1999"));
                sqlParams.Add(new SqlParameter("@Bank_Name", "NA"));
            }
            else if (Payable.Payment_Mode == 3)
            {
                sqlParams.Add(new SqlParameter("@Paid_Amount", Payable.Paid_Amount));
                sqlParams.Add(new SqlParameter("@Credit_Card_No", "NA"));
                sqlParams.Add(new SqlParameter("@Debit_Card_No", Payable.Debit_Card_No));
                sqlParams.Add(new SqlParameter("@Cheque_No", "NA"));
                sqlParams.Add(new SqlParameter("@Cheque_Date", "01/01/1999"));
                sqlParams.Add(new SqlParameter("@Bank_Name", "NA"));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Paid_Amount", Payable.Paid_Amount));
                sqlParams.Add(new SqlParameter("@Credit_Card_No", "NA"));
                sqlParams.Add(new SqlParameter("@Debit_Card_No", "NA"));
                sqlParams.Add(new SqlParameter("@Cheque_No", Payable.Cheque_No));
                sqlParams.Add(new SqlParameter("@Cheque_Date", Payable.Cheque_Date));
                sqlParams.Add(new SqlParameter("@Bank_Name", Payable.Bank_Name));
            }

            sqlParams.Add(new SqlParameter("@Updated_By", Payable.Updated_By));
            sqlParams.Add(new SqlParameter("@Updated_On", DateTime.Now));

            return sqlParams;
        }

        public decimal Get_Balance_Amount(int Purchase_Invoice_Id)
        {

            decimal Balance_Amount = 0;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Purchase_Invoice_Id", Purchase_Invoice_Id));

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.Get_Payable_Balance_Amount_By_Id_Sp.ToString(), CommandType.StoredProcedure);

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

        public decimal Get_Paid_Amount(int payable_Id)
        {

            decimal Paid_Amount = 0;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@payable_Id", payable_Id));

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.Get_Payable_Data_Item_By_Id_Sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (!dr.IsNull("Paid_Amount"))

                        Paid_Amount = Convert.ToDecimal(dr["Paid_Amount"]);
                }
            }

            return Paid_Amount;
        }

        public int Insert_Payable(PayableInfo Payable)
        {

            int Payable_Id = 0;

            Payable_Id = Convert.ToInt32(sqlHelper.ExecuteScalerObj(Set_Values_In_Payable(Payable), Storeprocedures.Insert_Payable_Data_Sp.ToString(), CommandType.StoredProcedure));
            if (Payable.Payable_Item_Id != 0)
            {
                Payable_Id = Payable.Payable_Id;
            }

            return Payable_Id;
        }

        private List<SqlParameter> Set_Values_In_Payable(PayableInfo Payable)
        {
            decimal Total_Balance_Amount = 0;

            decimal Balance_Amount = 0;
            

            //decimal Balance_Amount = Get_Balance_Amount(Payable.Purchase_Invoice_Id);

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Payable_Id", Payable.Payable_Id));           

            sqlParams.Add(new SqlParameter("@Purchase_Invoice_Id", Payable.Purchase_Invoice_Id));

            sqlParams.Add(new SqlParameter("@Payament_Date ", Payable.Payament_Date));

            sqlParams.Add(new SqlParameter("@Total_Amount ", Payable.Total_Amount));

            //if (Payable.Payable_Item_Id != 0)
            //{
            //    decimal Balance_Amount1 = Get_Balance_Amount(Payable.Purchase_Invoice_Id);

            //    decimal Paid_Amount1 = Get_Paid_Amount(Payable.Payable_Id);

            //    Balance_Amount = Balance_Amount1 + Paid_Amount1;
            //}
            //else
            //{
            //    Balance_Amount = Get_Balance_Amount(Payable.Purchase_Invoice_Id);
            //}

            //if (Balance_Amount > 0)
            //{

            //    Total_Balance_Amount = Balance_Amount - Payable.Paid_Amount;

            //}
            //else
            //{

            //    Total_Balance_Amount = Payable.Total_Amount - Payable.Paid_Amount;
            //}


            //Payable.Balance_Amount = Total_Balance_Amount;

            sqlParams.Add(new SqlParameter("@Balance_Amount", Payable.Final_Amount));

            if (Payable.Final_Amount != 0 && Payable.Final_Amount != Payable.Total_Amount)
            {
                sqlParams.Add(new SqlParameter("@Payble_Status", "3"));
            }
            else if (Payable.Final_Amount == Payable.Total_Amount && Payable.Final_Amount != 0)
            {
                sqlParams.Add(new SqlParameter("@Payble_Status", "2"));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Payble_Status", "1"));
            }

            sqlParams.Add(new SqlParameter("@Created_On", Payable.Created_Date));

            sqlParams.Add(new SqlParameter("@Created_By", Payable.Created_By));

            sqlParams.Add(new SqlParameter("@Updated_On", Payable.Updated_Date));

            sqlParams.Add(new SqlParameter("@Updated_By", Payable.Updated_By));

            return sqlParams;
        }

        public PayableInfo Get_Payable_Data_By_Id(int Purchase_Invoice_Id)
        {

            PayableInfo payable = new PayableInfo();

            List<SqlParameter> sqlparam = new List<SqlParameter>();

            sqlparam.Add(new SqlParameter("@Purchase_Invoice_Id", Purchase_Invoice_Id));

            //sqlparam.Add(new SqlParameter("@Entity_Id", entity_Id));

            DataTable dt = sqlHelper.ExecuteDataTable(sqlparam, Storeprocedures.Get_Payable_Data_By_Id_Sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {

                    if (!dr.IsNull("Payable_Id"))

                        payable.Payable_Id = Convert.ToInt32(dr["Payable_Id"]);


                    if (!dr.IsNull("Purchase_Invoice_Id"))

                        payable.Purchase_Invoice_Id = Convert.ToInt32(dr["Purchase_Invoice_Id"]);

                    if (!dr.IsNull("Payble_Status"))

                        payable.Payble_Status = Convert.ToInt32(dr["Payble_Status"]);

                    if (!dr.IsNull("Total_Amount"))

                        payable.Total_Amount = Convert.ToDecimal(dr["Total_Amount"]);

                    if (!dr.IsNull("Balance_Amount"))

                        payable.Balance_Amount = Convert.ToDecimal(dr["Balance_Amount"]);

                    if (!dr.IsNull("Payament_Date"))

                        payable.Payament_Date = Convert.ToDateTime(dr["Payament_Date"]);

                    payable.Payament_Date.ToShortDateString();


                }
            }

            return payable;
        }

        public List<PayableInfo> Get_Payable_Items_By_Id(int payable_Id)
        {

            List<PayableInfo> Payables = new List<PayableInfo>();

            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@Payable_Id", payable_Id));

           

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.Get_Payable_Data_Item_By_Id_Sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in dt.Rows)
            {
                Payables.Add(Get_Payble_Item_Values(dr));
            }

            return Payables;
        }

        private PayableInfo Get_Payble_Item_Values(DataRow dr)
        {

            PayableInfo payable = new PayableInfo();

            if (!dr.IsNull("Payable_Item_Id"))

                payable.Payable_Item_Id = Convert.ToInt32(dr["Payable_Item_Id"]);

            if (!dr.IsNull("Payable_Id"))

                payable.Payable_Id = Convert.ToInt32(dr["Payable_Id"]);

            if (!dr.IsNull("Purchase_Credit_Note_Id"))

                payable.Purchase_Credit_Note_Id = Convert.ToInt32(dr["Purchase_Credit_Note_Id"]);

            if (!dr.IsNull("Payment_Mode"))

                payable.Payment_Mode = Convert.ToInt32(dr["Payment_Mode"]);

            if (payable.Payment_Mode == 1)
            {
                payable.Payment_Mode1 = "Cash";
            }
            else if (payable.Payment_Mode == 2)
            {
                payable.Payment_Mode1 = "Credit Card";
            }
            else if (payable.Payment_Mode == 3)
            {
                payable.Payment_Mode1 = "Debit Card";
            }
            else
            {
                payable.Payment_Mode1 = "Cheque";
            }

            if (!dr.IsNull("Paid_Amount"))

                payable.Paid_Amount = Convert.ToInt32(dr["Paid_Amount"]);

            if (!dr.IsNull("Discount_Amount"))

                payable.Discount_Amount = Convert.ToDecimal(dr["Discount_Amount"]);

            if (!dr.IsNull("Discount_Percentage"))

                payable.Discount_Percentage = Convert.ToDecimal(dr["Discount_Percentage"]);

            if (!dr.IsNull("Cheque_Date"))

                payable.Cheque_Date = Convert.ToDateTime(dr["Cheque_Date"]);

                payable.Cheque_Date.ToShortDateString();

            if (!dr.IsNull("Cheque_No"))

                payable.Cheque_No = Convert.ToString(dr["Cheque_No"]);

            if (!dr.IsNull("Bank_Name"))

                payable.Bank_Name = Convert.ToString(dr["Bank_Name"]);

            //if (!dr.IsNull("Employee_Id"))

            //    payable.Employee_Id = Convert.ToInt32(dr["Employee_Id"]);

            if (!dr.IsNull("Vendor_Employee_Name"))

                payable.Vendor_Employee_Name = Convert.ToString(dr["Vendor_Employee_Name"]);

            if (!dr.IsNull("Remark"))

                payable.Remark = Convert.ToString(dr["Remark"]);

            if (!dr.IsNull("Credit_Card_No"))

                payable.Credit_Card_No = Convert.ToString(dr["Credit_Card_No"]);

            if (!dr.IsNull("Debit_Card_No"))

                payable.Debit_Card_No = Convert.ToString(dr["Debit_Card_No"]);

            if (!dr.IsNull("Payament_Date"))

                payable.Payament_Date = Convert.ToDateTime(dr["Payament_Date"]);

            if (!dr.IsNull("CreditNoteNo"))

                payable.Credit_Note_No = Convert.ToString(dr["CreditNoteNo"]);

            if (!dr.IsNull("Credit_Note_Amount"))

                payable.Credit_Note_Amount = Convert.ToInt32(dr["Credit_Note_Amount"]);


            if (!dr.IsNull("Created_On"))

                payable.Created_Date = Convert.ToDateTime(dr["Created_On"]);

            if (!dr.IsNull("Created_By"))

                payable.Created_By = Convert.ToInt32(dr["Created_By"]);

          

            return payable;
        }

        public DataTable Get_PurchaseInvoice(PayableInfo Payable)
        {

            DataTable dt = new DataTable();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            if (Payable.From_Date == DateTime.MinValue)
            {
                DateTime? someDate = null;
                sqlParams.Add(new SqlParameter("@From_Date", someDate));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@From_Date", Payable.From_Date));
            }

            if (Payable.To_Date == DateTime.MinValue)
            {
                DateTime? someDate = null;
                sqlParams.Add(new SqlParameter("@To_Date", someDate));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@To_Date", Payable.To_Date));
            }


            sqlParams.Add(new SqlParameter("@Vendor_Name", Payable.Vendor_Name));
            sqlParams.Add(new SqlParameter("@Payament_Status", Payable.Payament_Status));

            dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_Get_Payable_Search_Details.ToString(), CommandType.StoredProcedure);

            return dt;
        }

        public PayableInfo Get_Payable_Details_By_Id(int Purchase_Invoice_Id) //.......
        {

            PayableInfo pInfo = new PayableInfo();

            List<SqlParameter> sqlparam = new List<SqlParameter>();

            sqlparam.Add(new SqlParameter("@Purchase_Invoice_Id", Purchase_Invoice_Id));

            DataTable dt = sqlHelper.ExecuteDataTable(sqlparam, Storeprocedures.Get_Payable_Details_By_Id_Sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {

                    if (!dr.IsNull("Purchase_Invoice_Id"))

                        pInfo.Purchase_Invoice_Id = Convert.ToInt32(dr["Purchase_Invoice_Id"]);

                    if (!dr.IsNull("Payable_Id"))

                        pInfo.Payable_Id = Convert.ToInt32(dr["Payable_Id"]);

                    if (!dr.IsNull("Net_Amount"))

                        pInfo.Total_Amount = Convert.ToDecimal(dr["Net_Amount"]);

                    if (!dr.IsNull("Balance_Amount"))
                    {
                        pInfo.Balance_Amount = Convert.ToDecimal(dr["Balance_Amount"]);
                    }
                    else
                    {
                        pInfo.Balance_Amount = Convert.ToDecimal(dr["Net_Amount"]);
                    }

                    if (!dr.IsNull("Payble_Status"))

                        pInfo.Payament_Status = Convert.ToInt32(dr["Payble_Status"]);

                }
            }

            return pInfo;
        }

        public List<PayableInfo> Get_Credit_Note_Details_By_Id(int Purchase_Invoice_Id) //......
        {

            List<PayableInfo> Payables = new List<PayableInfo>();

            List<SqlParameter> sqlparam = new List<SqlParameter>();

            sqlparam.Add(new SqlParameter("@Purchase_Invoice_Id", Purchase_Invoice_Id));

            DataTable dt = sqlHelper.ExecuteDataTable(sqlparam, Storeprocedures.Get_Credit_Note_Details_By_Id_Sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in dt.Rows)
            {
                Payables.Add(Get_Credit_Note_Values(dr));
            }
            return Payables;
        }

        private PayableInfo Get_Credit_Note_Values(DataRow dr) //........
        {
            PayableInfo Payable = new PayableInfo();

            Payable.Purchase_Invoice_Id = Convert.ToInt32(dr["Purchase_Invoice_Id"]);
            Payable.Purchase_Credit_Note_Id = Convert.ToInt32(dr["Purchase_Credit_Note_Id"]);
            Payable.Credit_Note_No = Convert.ToString(dr["Credit_Note_No"]);
            Payable.Credit_Note_Amount = Convert.ToDecimal(dr["Credit_Note_Amount"]);

            return Payable;
        }

        public PayableInfo Get_Credit_Note_Amount_By_Id(int Purchase_Credit_Note_Id)
        { 

            PayableInfo Payable = new PayableInfo();

            List<SqlParameter> sqlparam = new List<SqlParameter>();

            sqlparam.Add(new SqlParameter("@Purchase_Credit_Note_Id", Purchase_Credit_Note_Id));

            //sqlparam.Add(new SqlParameter("@Purchase_Invoice_Id", Purchase_Invoice_Id));

            DataTable dt = sqlHelper.ExecuteDataTable(sqlparam, Storeprocedures.Get_Credit_Note_Amount_By_Id_Sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in dt.Rows)
            {
                 Payable.Credit_Note_Amount = Convert.ToDecimal(dr["Credit_Note_Amount"]);
            }
            return Payable;
        }

        //public PayableInfo Get_Payable_Details_By_Id(int Payable_Id, int Purchase_Invoice_Id)
        //{
        //    List<SqlParameter> parameters = new List<SqlParameter>();
        //    parameters.Add(new SqlParameter("@Payable_Id", Payable_Id));
        //    parameters.Add(new SqlParameter("@Purchase_Invoice_Id", Purchase_Invoice_Id));

        //    PayableInfo pInfo = new PayableInfo();
        //    DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Payable_Details_By_Id.ToString(), CommandType.StoredProcedure);
        //    List<DataRow> drList = new List<DataRow>();
        //    drList = dt.AsEnumerable().ToList();
        //    foreach (DataRow dr in drList)
        //    {
        //        pInfo = Get_Payable_Values(dr);
        //    }
        //    return pInfo;
        //}

        //private PayableInfo Get_Payable_Values(DataRow dr)
        //{
        //    PayableInfo pInfo = new PayableInfo();


        //    pInfo.Payable_Id = Convert.ToInt32(dr["Payable_Id"]);
        //    pInfo.Purchase_Invoice_Id = Convert.ToInt32(dr["Purchase_Invoice_Id"]);

        //    if (!dr.IsNull("Balance_Amount"))
        //    {
        //        pInfo.Balance_Amount = Convert.ToDecimal(dr["Balance_Amount"]);

        //        pInfo.Created_On = Convert.ToDateTime(dr["Created_On"]);
        //        pInfo.Created_By = Convert.ToInt32(dr["Created_By"]);
        //        pInfo.Updated_On = Convert.ToDateTime(dr["Updated_On"]);
        //        pInfo.Updated_By = Convert.ToInt32(dr["Updated_By"]);
        //    }

        //    return pInfo;
        //}

        //public List<PurchaseInvoice_Details> Get_PurchaseInvoice(PayableInfo Payable) //.... 
        //{
        //    List<PurchaseInvoice_Details> PurchaseInvoice_Details = new List<PurchaseInvoice_Details>();

        //    List<SqlParameter> sqlParams = new List<SqlParameter>();

        //    if (Payable.From_Date == DateTime.MinValue)
        //    {
        //        DateTime? someDate = null;
        //        sqlParams.Add(new SqlParameter("@From_Date", someDate));
        //    }
        //    else
        //    {
        //        sqlParams.Add(new SqlParameter("@From_Date", Payable.From_Date));
        //    }

        //    if (Payable.To_Date == DateTime.MinValue)
        //    {
        //        DateTime? someDate = null;
        //        sqlParams.Add(new SqlParameter("@To_Date", someDate));
        //    }
        //    else
        //    {
        //        sqlParams.Add(new SqlParameter("@To_Date", Payable.To_Date));
        //    }


        //    sqlParams.Add(new SqlParameter("@Vendor_Name", Payable.Vendor_Name));
        //    sqlParams.Add(new SqlParameter("@Payament_Status", Payable.Payament_Status));

        //    DataTable dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_Get_Payable_Search_Details.ToString(), CommandType.StoredProcedure);

        //    if (dt != null && dt.Rows.Count > 0)
        //    {
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            PurchaseInvoice_Details list = new PurchaseInvoice_Details();

        //            if (!dr.IsNull("Purchase_Invoice_Id"))
        //                list.Purchase_Invoice_Id = Convert.ToInt32(dr["Purchase_Invoice_Id"]);
        //            if (!dr.IsNull("Payable_Id"))
        //                list.Payable_Id = Convert.ToInt32(dr["Payable_Id"]);                 
        //            if (!dr.IsNull("Vendor_Id"))
        //                list.Vendor_Name = Convert.ToString(dr["Vendor_Id"]);
        //            if (!dr.IsNull("Purchase_Invoice_No"))
        //                list.Purchase_Invoice_No = Convert.ToString(dr["Purchase_Invoice_No"]);
        //            if (!dr.IsNull("Purchase_Invoice_Date"))
        //                list.Purchase_Invoice_Date = Convert.ToDateTime(dr["Purchase_Invoice_Date"]);
        //            if (!dr.IsNull("Total_Amount"))
        //                list.Total_Amount = Convert.ToDecimal(dr["Total_Amount"]);                
        //            if (!dr.IsNull("Balance_Amount"))
        //                list.Balance_Amount = Convert.ToDecimal(dr["Balance_Amount"]);
        //            else
        //                list.Payment_Status_Value = "UnPaid";

        //            if (!dr.IsNull("Payament_Date"))
        //                list.Payament_Date = Convert.ToDateTime(dr["Payament_Date"]);
        //            if (!dr.IsNull("Payble_Status"))
        //                list.Payament_Status = Convert.ToInt32(dr["Payble_Status"]);
        //            else
        //                list.Payament_Status = 2;
        //            if (!dr.IsNull("Vendor_Name"))
        //                list.Vendor_Name = Convert.ToString(dr["Vendor_Name"]);

        //            if (list.Payament_Status == 1)
        //            {
        //                list.Payment_Status_Value = "Paid";
        //            }
        //            else if (list.Payament_Status == 2)
        //            {
        //                list.Payment_Status_Value = "UnPaid";
        //            }
        //            else
        //            {
        //                list.Payment_Status_Value = "PartiallyPaid";
        //            }

        //            PurchaseInvoice_Details.Add(list);
        //        }
        //    }

        //    return PurchaseInvoice_Details;
        //}
    }

}
