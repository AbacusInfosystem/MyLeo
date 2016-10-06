using MyLeoRetailerInfo.Common;
using MyLeoRetailerInfo.GiftVoucher;
using MyLeoRetailerInfo.Receivable;
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
  public  class ReceivableRepo
    {
       SQL_Repo sqlHelper = null;

       public ReceivableRepo()
		{
			sqlHelper = new SQL_Repo();
		}


       public List<ReceivableInfo> Get_Receivables(ReceivableInfo Receivable) //.... 
       {
           List<ReceivableInfo> Receivables = new List<ReceivableInfo>();

           //decimal Total_Balance_Amount = 0;

           decimal Balance_Amount = Get_Balance_Amount(Receivable.Sales_Invoice_Id);
           List<SqlParameter> sqlParams = new List<SqlParameter>();
           sqlParams.Add(new SqlParameter("@From_Date", Receivable.From_Date));
           sqlParams.Add(new SqlParameter("@To_Date", Receivable.To_Date));
           sqlParams.Add(new SqlParameter("@Customer_Name", Receivable.Customer_Name));
           sqlParams.Add(new SqlParameter("@Sales_Invoice_No", Receivable.Sales_Invoice_No));
           sqlParams.Add(new SqlParameter("@Payment_Status", Receivable.Payment_Status));


           DataTable dt = sqlHelper.ExecuteDataTable(null, Storeprocedures.sp_Get_Receivables.ToString(), CommandType.StoredProcedure);

           if (dt != null && dt.Rows.Count > 0)
           {
               foreach (DataRow dr in dt.Rows)
               {
                   ReceivableInfo list = new ReceivableInfo();

                   if (!dr.IsNull("Sales_Invoice_Id"))
                       list.Sales_Invoice_Id = Convert.ToInt32(dr["Sales_Invoice_Id"]);
                   if (!dr.IsNull("Receivable_Id"))
                       list.Receivable_Id = Convert.ToInt32(dr["Receivable_Id"]);
                   if (!dr.IsNull("Sales_Credit_Note_Id"))
                       list.Sales_Credit_Note_Id = Convert.ToInt32(dr["Sales_Credit_Note_Id"]);
                   if (!dr.IsNull("Customer_Name"))
                       list.Customer_Name = Convert.ToString(dr["Customer_Name"]);
                   if (!dr.IsNull("Customer_Mobile1"))
                       list.Customer_Mobile1 = Convert.ToString(dr["Customer_Mobile1"]);
                   if (!dr.IsNull("Sales_Invoice_No"))
                       list.Sales_Invoice_No = Convert.ToString(dr["Sales_Invoice_No"]);
                   if (!dr.IsNull("Created_Date"))
                       list.Sales_Invoice_Date = Convert.ToDateTime(dr["Created_Date"]);
                   if (!dr.IsNull("Payment_Status"))
                       list.Payment_Status = Convert.ToInt32(dr["Payment_Status"]);
                   if (!dr.IsNull("Net_Amount"))
                       list.Net_Amount = Convert.ToDecimal(dr["Net_Amount"]);

                   if (list.Payment_Status == 1)
                   {
                       list.Payment_Status_Value = "Paid";
                   }
                   else if (list.Payment_Status == 2)
                   {
                       list.Payment_Status_Value = "UnPaid";
                   }
                   else
                   {
                       list.Payment_Status_Value = "PartiallyPaid";
                   }


                   if (!dr.IsNull("Balance_Amount"))
                       list.Balance_Amount = Convert.ToDecimal(dr["Balance_Amount"]);
                  
                   if (!dr.IsNull("Paid_Amount"))
                       list.Paid_Amount = Convert.ToDecimal(dr["Paid_Amount"]);
                   if (!dr.IsNull("Credit_Note_No"))
                       list.Credit_Note_No = Convert.ToString(dr["Credit_Note_No"]);
                   if (!dr.IsNull("Credit_Note_Amount"))
                       list.Credit_Note_Amount = Convert.ToDecimal(dr["Credit_Note_Amount"]);
                   if (!dr.IsNull("Created_Date"))
                       list.Credit_Note_Date = Convert.ToDateTime(dr["Created_Date"]);
                      Receivable.Credit_Note_Date.ToShortDateString();
                   if (!dr.IsNull("Created_On"))
                       list.Payament_Date = Convert.ToDateTime(dr["Created_On"]);



                   Receivables.Add(list);
               }
           }

           return Receivables;
       }

       public DataTable Get_Receivable_Search_Details(ReceivableInfo Receivable, string Branch_ID) //.... 
       {
           DataTable dt = new DataTable();

           List<ReceivableInfo> Receivables = new List<ReceivableInfo>();

           List<SqlParameter> sqlParams = new List<SqlParameter>();

           if (Receivable.From_Date == DateTime.MinValue)
           {
               DateTime? someDate = null;
               sqlParams.Add(new SqlParameter("@From_Date", someDate));
           }
           else
           {
               sqlParams.Add(new SqlParameter("@From_Date", Receivable.From_Date));
           }

           if (Receivable.To_Date == DateTime.MinValue)
           {
               DateTime? someDate = null;
               sqlParams.Add(new SqlParameter("@To_Date", someDate));
           }
           else
           {
               sqlParams.Add(new SqlParameter("@To_Date", Receivable.To_Date));
           }

           //sqlParams.Add(new SqlParameter("@From_Date", Receivable.From_Date == DateTime.MinValue ? null : Receivable.From_Date.ToString("mm-dd-yy")));
           //sqlParams.Add(new SqlParameter("@To_Date", Receivable.To_Date == DateTime.MinValue ? null : Receivable.To_Date.ToString("mm-dd-yy")));
           sqlParams.Add(new SqlParameter("@Sales_Invoice_No", Receivable.Sales_Invoice_No));
           sqlParams.Add(new SqlParameter("@Customer_Name", Receivable.Customer_Name));
           sqlParams.Add(new SqlParameter("@Payment_Status", Receivable.Payment_Status));
           sqlParams.Add(new SqlParameter("@Branch_ID", Branch_ID));

           dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_Get_Receivable_Search_Details.ToString(), CommandType.StoredProcedure);
                     
           return dt;
       }


    

       public ReceivableInfo Get_Receivable_Details_By_Id(int Sales_Invoice_Id) //.......
       {

           ReceivableInfo rInfo = new ReceivableInfo();

           List<SqlParameter> sqlparam = new List<SqlParameter>();

           sqlparam.Add(new SqlParameter("@Sales_Invoice_Id", Sales_Invoice_Id));

           DataTable dt = sqlHelper.ExecuteDataTable(sqlparam, Storeprocedures.sp_Get_Receivable_Search_Data_new.ToString(), CommandType.StoredProcedure);

           if (dt != null && dt.Rows.Count > 0)
           {
               foreach (DataRow dr in dt.Rows)
               {

                   if (!dr.IsNull("Sales_Invoice_Id"))

                       rInfo.Sales_Invoice_Id = Convert.ToInt32(dr["Sales_Invoice_Id"]);


                   if (!dr.IsNull("Branch_ID"))

                       rInfo.Branch_ID = Convert.ToInt32(dr["Branch_ID"]);

                   if (!dr.IsNull("Branch_Name"))

                       rInfo.Branch_Name = Convert.ToString(dr["Branch_Name"]);

                   if (!dr.IsNull("Receivable_Id"))

                       rInfo.Receivable_Id = Convert.ToInt32(dr["Receivable_Id"]);

                   if (!dr.IsNull("Balance_Amount"))
                   {
                       rInfo.Balance_Amount = Convert.ToDecimal(dr["Balance_Amount"]);
                   }
                   else
                   {
                       rInfo.Balance_Amount = Convert.ToDecimal(dr["Net_Amount"]);
                   }

                   if (!dr.IsNull("Payament_Date"))

                       rInfo.Payament_Date = Convert.ToDateTime(dr["Payament_Date"]);

                   rInfo.Payament_Date.ToShortDateString();

                   if (!dr.IsNull("Payment_Status"))

                       rInfo.Payment_Status = Convert.ToInt32(dr["Payment_Status"]);

                   if (!dr.IsNull("Customer_Id"))

                       rInfo.Customer_Id = Convert.ToInt32(dr["Customer_Id"]);

                   if (!dr.IsNull("Net_Amount"))

                       rInfo.Net_Amount = Convert.ToDecimal(dr["Net_Amount"]);



               }
           }

           return rInfo;
       }

       public List<ReceivableInfo> Get_Gift_Voucher_Details_By_Id() //......
       {

           List<ReceivableInfo> Receivables1 = new List<ReceivableInfo>();

           List<SqlParameter> sqlparam = new List<SqlParameter>();

           //sqlparam.Add(new SqlParameter("@Gift_Voucher_Id", Gift_Voucher_Id));

           DataTable dt = sqlHelper.ExecuteDataTable(sqlparam, Storeprocedures.Giftvoucher_Data_sp.ToString(), CommandType.StoredProcedure);

               foreach (DataRow dr in dt.Rows)
               {
                   ReceivableInfo Receivable = new ReceivableInfo();

                   Receivable.Gift_Voucher_Id = Convert.ToInt32(dr["Gift_Voucher_Id"]);

                   Receivable.Gift_Voucher_No = Convert.ToString(dr["Gift_Voucher_No"]);

                   Receivable.Gift_Voucher_Amount = Convert.ToDecimal(dr["Gift_Voucher_Amount"]);

                   Receivables1.Add(Receivable);

           }
               return Receivables1;
       }

       public ReceivableInfo Get_Gift_Voucher_Amount_By_Id(int Gift_Voucher_Id)
       {

           ReceivableInfo Receivable = new ReceivableInfo();

           List<SqlParameter> sqlparam = new List<SqlParameter>();

           sqlparam.Add(new SqlParameter("@Gift_Voucher_Id", Gift_Voucher_Id));

           DataTable dt = sqlHelper.ExecuteDataTable(sqlparam, Storeprocedures.sp_Get_Gift_Voucher_By_Id.ToString(), CommandType.StoredProcedure);

           foreach (DataRow dr in dt.Rows)
           {

               Receivable.Gift_Voucher_Amount = Convert.ToDecimal(dr["Gift_Voucher_Amount"]);
           }
           return Receivable;
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

       public decimal Get_Paid_Amount(int Receivable_Id)
       {

           decimal Paid_Amount = 0;

           List<SqlParameter> sqlParams = new List<SqlParameter>();

           sqlParams.Add(new SqlParameter("@Receivable_Id", Receivable_Id));

           DataTable dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.Get_Receivable_Data_Item_By_Id_Sp.ToString(), CommandType.StoredProcedure);

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

       public int Insert_Receivable(ReceivableInfo Receivable)
       {

           int Receivable_Id = 0;

           Receivable_Id = Convert.ToInt32(sqlHelper.ExecuteScalerObj(Set_Values_In_Receivable(Receivable), Storeprocedures.Insert_Receivable_Data_Sp.ToString(), CommandType.StoredProcedure));
           if (Receivable.Receivable_Item_Id != 0)
           {
               Receivable_Id = Receivable.Receivable_Id;
           }

           return Receivable_Id;
       }

       private List<SqlParameter> Set_Values_In_Receivable(ReceivableInfo Receivable)
       {
           decimal Total_Balance_Amount = 0;
           decimal Balance_Amount = 0;

           //decimal Balance_Amount = Get_Balance_Amount(Receivable.Sales_Invoice_Id);

           List<SqlParameter> sqlParams = new List<SqlParameter>();

           sqlParams.Add(new SqlParameter("@Receivable_Id", Receivable.Receivable_Id));

           sqlParams.Add(new SqlParameter("@Sales_Invoice_Id", Receivable.Sales_Invoice_Id));

           //sqlParams.Add(new SqlParameter("@Payble_Status ", Receivable.Payble_Status));

           sqlParams.Add(new SqlParameter("@Payament_Date ", Receivable.Payament_Date));

           if (Convert.ToInt32(Receivable.Branch_ID) != 0)
           {
               sqlParams.Add(new SqlParameter("@Branch_ID", Receivable.Branch_ID));
           }
           else
           {
               sqlParams.Add(new SqlParameter("@Branch_ID", 0));
           }

           if (Receivable.Receivable_Item_Id != 0)
           {
               decimal Balance_Amount1 = Get_Balance_Amount(Receivable.Sales_Invoice_Id);

               decimal Paid_Amount1 = Get_Paid_Amount(Receivable.Receivable_Id);

               Balance_Amount = Balance_Amount1 + Paid_Amount1;
           }
           else
           {
               Balance_Amount = Get_Balance_Amount(Receivable.Sales_Invoice_Id);
           }

           if (Balance_Amount > 0)
           {

               Total_Balance_Amount = Balance_Amount - Receivable.Paid_Amount;

           }

           else
           {

               Total_Balance_Amount = Receivable.Net_Amount - Receivable.Paid_Amount;
           }

           Receivable.Balance_Amount = Total_Balance_Amount;

           sqlParams.Add(new SqlParameter("@Balance_Amount", Receivable.Balance_Amount));

           if (Receivable.Balance_Amount != 0)
           {
               sqlParams.Add(new SqlParameter("@Payment_Status", "3"));
           }

           else
           {
               sqlParams.Add(new SqlParameter("@Payment_Status", "1"));
           }


           //sqlParams.Add(new SqlParameter("@Balance_Amount ", Receivable.Balance_Amount));

           sqlParams.Add(new SqlParameter("@Created_On", DateTime.Now));

           sqlParams.Add(new SqlParameter("@Created_By", Receivable.Created_By));

           sqlParams.Add(new SqlParameter("@Updated_On", DateTime.Now));

           sqlParams.Add(new SqlParameter("@Updated_By", Receivable.Updated_By));

           return sqlParams;
       }

       public int Insert_Receivable_Item_Data(ReceivableInfo Receivable)
       {

           return Convert.ToInt32(sqlHelper.ExecuteScalerObj(Set_Values_In_Receivable_Item(Receivable), Storeprocedures.sp_Insert_Receivable_Item_Data.ToString(), CommandType.StoredProcedure));

       }

       private List<SqlParameter> Set_Values_In_Receivable_Item(ReceivableInfo Receivable)
       {

           List<SqlParameter> sqlParams = new List<SqlParameter>();
           //if (Receivable.Receivable_Item_Id != 0)
           //{
           //sqlParams.Add(new SqlParameter("@Receivable_Item_Id", Receivable.Receivable_Item_Id));
           //}
           sqlParams.Add(new SqlParameter("@Receivable_Id", Receivable.Receivable_Id));
           sqlParams.Add(new SqlParameter("@Sales_Credit_Note_Id", Receivable.Sales_Credit_Note_Id));
           sqlParams.Add(new SqlParameter("@Gift_Voucher_Id", Receivable.Gift_Voucher_Id));
           sqlParams.Add(new SqlParameter("@Receivable_Item_Id", Receivable.Receivable_Item_Id));
           sqlParams.Add(new SqlParameter("@Paid_Amount", Receivable.Paid_Amount));
           sqlParams.Add(new SqlParameter("@Cash_Amount", Receivable.Cash_Amount));
           sqlParams.Add(new SqlParameter("@Cheque_Amount", Receivable.Cheque_Amount));
           sqlParams.Add(new SqlParameter("@Card_Amount", Receivable.Card_Amount));
           
           //sqlParams.Add(new SqlParameter("@Cheque_Date", Receivable.Cheque_Date));

           if (Receivable.Cheque_Date == DateTime.MinValue)
           {
               sqlParams.Add(new SqlParameter("@Cheque_Date", "01/01/1999"));
           }
           else
           {
               sqlParams.Add(new SqlParameter("@Cheque_Date", Receivable.Cheque_Date));
           }

           sqlParams.Add(new SqlParameter("@Cheque_No", Receivable.Cheque_No));
           sqlParams.Add(new SqlParameter("@Bank_Name", Receivable.Bank_Name));
           sqlParams.Add(new SqlParameter("@Credit_Card_No", Receivable.Credit_Card_No));

           sqlParams.Add(new SqlParameter("@Created_By", Receivable.Created_By));
           sqlParams.Add(new SqlParameter("@Created_On", DateTime.Now));
           sqlParams.Add(new SqlParameter("@Updated_By", Receivable.Updated_By));
           sqlParams.Add(new SqlParameter("@Updated_On", DateTime.Now));

           return sqlParams;
       }

       public int Update_Receivable_Items_Data(ReceivableInfo Receivable)
       {
           Receivable.Receivable_Item_Id = Convert.ToInt32(sqlHelper.ExecuteScalerObj(Update_Receivable_Item_Data(Receivable), Storeprocedures.sp_Update_Receivable_Item.ToString(), CommandType.StoredProcedure));

           return Receivable.Receivable_Item_Id;
       }

       private List<SqlParameter> Update_Receivable_Item_Data(ReceivableInfo Receivable)
       {

           List<SqlParameter> sqlParams = new List<SqlParameter>();
           if (Receivable.Receivable_Item_Id != 0)
           {
               sqlParams.Add(new SqlParameter("@Receivable_Item_Id", Receivable.Receivable_Item_Id));
           }

           sqlParams.Add(new SqlParameter("@Sales_Credit_Note_Id", Receivable.Sales_Credit_Note_Id));
           sqlParams.Add(new SqlParameter("@Gift_Voucher_Id", Receivable.Gift_Voucher_Id));
           sqlParams.Add(new SqlParameter("@Paid_Amount", Receivable.Paid_Amount));
           sqlParams.Add(new SqlParameter("@Cash_Amount", Receivable.Cash_Amount));
           sqlParams.Add(new SqlParameter("@Cheque_Amount", Receivable.Cheque_Amount));
           sqlParams.Add(new SqlParameter("@Card_Amount", Receivable.Card_Amount));
           //sqlParams.Add(new SqlParameter("@Cheque_Date", Receivable.Cheque_Date));
           if (Receivable.Cheque_Date == DateTime.MinValue)
           {
               
               sqlParams.Add(new SqlParameter("@Cheque_Date", "01/01/1999"));
           }
           else
           {
               sqlParams.Add(new SqlParameter("@Cheque_Date", Receivable.Cheque_Date));
           }
           sqlParams.Add(new SqlParameter("@Cheque_No", Receivable.Cheque_No));
           sqlParams.Add(new SqlParameter("@Bank_Name", Receivable.Bank_Name));
           
           sqlParams.Add(new SqlParameter("@Credit_Card_No", Receivable.Credit_Card_No));
           sqlParams.Add(new SqlParameter("@Updated_By", Receivable.Updated_By));
           sqlParams.Add(new SqlParameter("@Updated_On", DateTime.Now));

           return sqlParams;
       }

       public List<ReceivableInfo> Get_Receivable_Items_By_Id(int Receivable_Id)
       {

           List<ReceivableInfo> Receivables = new List<ReceivableInfo>();

           List<SqlParameter> sqlParamList = new List<SqlParameter>();

           sqlParamList.Add(new SqlParameter("@Receivable_Id", Receivable_Id));


           //sqlParamList.Add(new SqlParameter("@Receivable_Item_Id", Receivable_Item_Id));
          

           DataTable dt = sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.Get_Receivable_Data_Item_By_Id_Sp.ToString(), CommandType.StoredProcedure);

           foreach (DataRow dr in dt.Rows)
           {
               Receivables.Add(Get_Receivable_Item_Values(dr));
           }

           return Receivables;
       }

       private ReceivableInfo Get_Receivable_Item_Values(DataRow dr)
       {

           ReceivableInfo Receivable = new ReceivableInfo();

           if (!dr.IsNull("Receivable_Item_Id"))

               Receivable.Receivable_Item_Id = Convert.ToInt32(dr["Receivable_Item_Id"]);

           if (!dr.IsNull("Receivable_Id"))

               Receivable.Receivable_Id = Convert.ToInt32(dr["Receivable_Id"]);

           if (!dr.IsNull("Sales_Credit_Note_Id"))

               Receivable.Sales_Credit_Note_Id = Convert.ToInt32(dr["Sales_Credit_Note_Id"]);

           if (!dr.IsNull("Paid_Amount"))

               Receivable.Paid_Amount = Convert.ToInt32(dr["Paid_Amount"]);

           if (!dr.IsNull("Gift_Voucher_Id"))

               Receivable.Gift_Voucher_Id = Convert.ToInt32(dr["Gift_Voucher_Id"]);

           if (!dr.IsNull("Cash_Amount"))

               Receivable.Cash_Amount = Convert.ToInt32(dr["Cash_Amount"]);

           if (!dr.IsNull("Cheque_Amount"))

               Receivable.Cheque_Amount = Convert.ToDecimal(dr["Cheque_Amount"]);

           if (!dr.IsNull("Card_Amount"))

               Receivable.Card_Amount = Convert.ToDecimal(dr["Card_Amount"]);

           if (!dr.IsNull("Gift_Voucher_Amount"))

               Receivable.Gift_Voucher_Amount = Convert.ToDecimal(dr["Gift_Voucher_Amount"]);

           if (!dr.IsNull("Cheque_Date"))

               Receivable.Cheque_Date = Convert.ToDateTime(dr["Cheque_Date"]);

               Receivable.Cheque_Date.ToShortDateString();

           if (!dr.IsNull("Cheque_No"))

               Receivable.Cheque_No = Convert.ToString(dr["Cheque_No"]);

           if (!dr.IsNull("Bank_Name"))

               Receivable.Bank_Name = Convert.ToString(dr["Bank_Name"]);

           if (!dr.IsNull("Credit_Card_No"))

               Receivable.Credit_Card_No = Convert.ToString(dr["Credit_Card_No"]);

           if (!dr.IsNull("Net_Amount"))

               Receivable.Net_Amount = Convert.ToDecimal(dr["Net_Amount"]);

           if (!dr.IsNull("Created_On"))

               Receivable.Created_On = Convert.ToDateTime(dr["Created_On"]);

           if (!dr.IsNull("Created_By"))

               Receivable.Created_By = Convert.ToInt32(dr["Created_By"]);

           if (!dr.IsNull("Created_Date"))

               Receivable.Credit_Note_Date = Convert.ToDateTime(dr["Created_Date"]);

               Receivable.Credit_Note_Date.ToShortDateString();

           if (!dr.IsNull("Credit_Note_Amount"))

               Receivable.Credit_Note_Amount = Convert.ToDecimal(dr["Credit_Note_Amount"]);

           if (!dr.IsNull("Credit_Note_No"))

               Receivable.Credit_Note_No = Convert.ToString(dr["Credit_Note_No"]);

           if (!dr.IsNull("Gift_Voucher_No"))

               Receivable.Gift_Voucher_No = Convert.ToString(dr["Gift_Voucher_No"]);

           


           return Receivable;
       }

       public ReceivableInfo Get_Receivable_Data_By_Id(int Sales_Invoice_Id)
       {

           ReceivableInfo Receivable = new ReceivableInfo();

           List<SqlParameter> sqlparam = new List<SqlParameter>();

           sqlparam.Add(new SqlParameter("@Sales_Invoice_Id", Sales_Invoice_Id));

           //sqlparam.Add(new SqlParameter("@Entity_Id", entity_Id));

           DataTable dt = sqlHelper.ExecuteDataTable(sqlparam, Storeprocedures.Get_Receivable_Data_By_Id_Sp.ToString(), CommandType.StoredProcedure);

           if (dt != null && dt.Rows.Count > 0)
           {
               foreach (DataRow dr in dt.Rows)
               {

                   if (!dr.IsNull("Receivable_Id"))

                       Receivable.Receivable_Id = Convert.ToInt32(dr["Receivable_Id"]);

                   if (!dr.IsNull("Sales_Invoice_Id"))

                       Receivable.Sales_Invoice_Id = Convert.ToInt32(dr["Sales_Invoice_Id"]);

                   if (!dr.IsNull("Payment_Status"))

                       Receivable.Payment_Status = Convert.ToInt32(dr["Payment_Status"]);

                   if (!dr.IsNull("Balance_Amount"))

                       Receivable.Balance_Amount = Convert.ToDecimal(dr["Balance_Amount"]);

                   if (!dr.IsNull("Branch_ID"))

                       Receivable.Branch_ID = Convert.ToInt32(dr["Branch_ID"]);

                   if (!dr.IsNull("Payament_Date"))

                       Receivable.Payament_Date = Convert.ToDateTime(dr["Payament_Date"]);
                       Receivable.Payament_Date.ToShortDateString();
                  // Receivable.Payament_Date = Convert.ToDateTime(dr["Payament_Date"]);


               }
           }

         
           return Receivable;
       }

       public List<CreditNote> Get_Credit_Note_Details_By_Id(int Customer_Id) //......
       {

           List<CreditNote> Receivables = new List<CreditNote>();

           List<SqlParameter> sqlparam = new List<SqlParameter>();

           sqlparam.Add(new SqlParameter("@Customer_Id", Customer_Id));

           DataTable dt = sqlHelper.ExecuteDataTable(sqlparam, Storeprocedures.sp_Get_Credit_Note_Details_By_Customer_Id1.ToString(), CommandType.StoredProcedure);

           foreach (DataRow dr in dt.Rows)
           {
               Receivables.Add(Get_Credit_Note_Values1(dr));
           }
           return Receivables;
       }

       private CreditNote Get_Credit_Note_Values1(DataRow dr) //........
       {
           CreditNote Receivable = new CreditNote();

           Receivable.Credit_Note_Id = Convert.ToInt32(dr["Sales_Credit_Note_Id"]);
           Receivable.Credit_Note_No = Convert.ToString(dr["Credit_Note_No"]);
           Receivable.Credit_Note_Amount = Convert.ToDecimal(dr["Credit_Note_Amount"]);
           Receivable.Credit_Note_Date = Convert.ToDateTime(dr["Created_Date"]);
           Receivable.Credit_Note_Date.ToShortDateString();

           return Receivable;
       }

       public ReceivableInfo Get_Credit_Note_Amount_By_Id(int Sales_Credit_Note_Id)
       {

           ReceivableInfo Receivable = new ReceivableInfo();

           List<SqlParameter> sqlparam = new List<SqlParameter>();

           sqlparam.Add(new SqlParameter("@Sales_Credit_Note_Id", Sales_Credit_Note_Id));

           DataTable dt = sqlHelper.ExecuteDataTable(sqlparam, Storeprocedures.Get_Credit_Note_Details_By_Id_Sp1.ToString(), CommandType.StoredProcedure);

           foreach (DataRow dr in dt.Rows)
           {
               Receivable.Credit_Note_Amount = Convert.ToDecimal(dr["Credit_Note_Amount"]);

               Receivable.Credit_Note_Date = Convert.ToDateTime(dr["Created_Date"]);
               Receivable.Credit_Note_Date.ToShortDateString();
           }
           return Receivable;
       }

     
    }
}
