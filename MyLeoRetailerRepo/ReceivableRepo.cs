using MyLeoRetailerInfo.Common;
using MyLeoRetailerInfo.GiftVoucher;
using MyLeoRetailerInfo.Payable;
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

       public List<ReceivableInfo> Get_Receivable_Search_Details(ReceivableInfo Receivable) //.... 
       {
           List<ReceivableInfo> Receivables = new List<ReceivableInfo>();

           List<SqlParameter> sqlParams = new List<SqlParameter>();

           sqlParams.Add(new SqlParameter("@From_Date", Receivable.From_Date));
           sqlParams.Add(new SqlParameter("@To_Date", Receivable.To_Date));
           sqlParams.Add(new SqlParameter("@Sales_Invoice_No", Receivable.Sales_Invoice_No));
           sqlParams.Add(new SqlParameter("@Customer_Name", Receivable.Customer_Name));
           sqlParams.Add(new SqlParameter("@Receivable_Status", Receivable.Receivable_Status));

           DataTable dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_Get_Receivable_Search_Data.ToString(), CommandType.StoredProcedure);

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
                   if (!dr.IsNull("Receivable_Status"))
                       list.Receivable_Status = Convert.ToInt32(dr["Receivable_Status"]);
                   if (!dr.IsNull("Total_MRP_Amount"))
                       list.Total_MRP_Amount = Convert.ToDecimal(dr["Total_MRP_Amount"]);
                   if (!dr.IsNull("Paid_Amount"))
                       list.Paid_Amount = Convert.ToDecimal(dr["Paid_Amount"]);
                   if (!dr.IsNull("Balance_Amount"))
                       list.Balance_Amount = Convert.ToDecimal(dr["Balance_Amount"]);
                   if (!dr.IsNull("Credit_Note_No"))
                       list.Credit_Note_No = Convert.ToString(dr["Credit_Note_No"]);
                   if (!dr.IsNull("Credit_Note_Amount"))
                       list.Credit_Note_Amount = Convert.ToDecimal(dr["Credit_Note_Amount"]);
                   if (!dr.IsNull("Created_Date"))
                       list.Credit_Note_Date = Convert.ToDateTime(dr["Created_Date"]);
                   if (!dr.IsNull("Created_On"))
                       list.Payament_Date = Convert.ToDateTime(dr["Created_On"]);
                   


                   Receivables.Add(list);
               }
           }

           return Receivables;
       }

       public ReceivableInfo Get_Receivable_Details_By_Id(int Sales_Invoice_Id) //.......
       {

           ReceivableInfo rInfo = new ReceivableInfo();

           List<SqlParameter> sqlparam = new List<SqlParameter>();

           sqlparam.Add(new SqlParameter("@Sales_Invoice_Id", Sales_Invoice_Id));

           DataTable dt = sqlHelper.ExecuteDataTable(sqlparam, Storeprocedures.Get_Receivable_Details_By_Id_Sp.ToString(), CommandType.StoredProcedure);

           if (dt != null && dt.Rows.Count > 0)
           {
               foreach (DataRow dr in dt.Rows)
               {

                   if (!dr.IsNull("Sales_Invoice_Id"))

                       rInfo.Sales_Invoice_Id = Convert.ToInt32(dr["Sales_Invoice_Id"]);

                   if (!dr.IsNull("Receivable_Id"))

                       rInfo.Receivable_Id = Convert.ToInt32(dr["Receivable_Id"]);

                   if (!dr.IsNull("Balance_Amount"))

                       rInfo.Balance_Amount = Convert.ToDecimal(dr["Balance_Amount"]);

                   if (!dr.IsNull("Total_MRP_Amount"))

                       rInfo.Total_MRP_Amount = Convert.ToDecimal(dr["Total_MRP_Amount"]);

               }
           }

           return rInfo;
       }

       public List<ReceivableInfo> Get_Credit_Note_Details_By_Id(int Sales_Credit_Note_Id) //......
       {

           List<ReceivableInfo> Receivables = new List<ReceivableInfo>();

           List<SqlParameter> sqlparam = new List<SqlParameter>();

           sqlparam.Add(new SqlParameter("@Sales_Credit_Note_Id", Sales_Credit_Note_Id));

           DataTable dt = sqlHelper.ExecuteDataTable(sqlparam, Storeprocedures.Get_Credit_Note_Details_By_Id_Sp1.ToString(), CommandType.StoredProcedure);

           foreach (DataRow dr in dt.Rows)
           {
               Receivables.Add(Get_Credit_Note_Values(dr));
           }
           return Receivables;
       }

       private ReceivableInfo Get_Credit_Note_Values(DataRow dr) //........
       {
           ReceivableInfo Receivable = new ReceivableInfo();

           Receivable.Sales_Credit_Note_Id = Convert.ToInt32(dr["Sales_Credit_Note_Id"]);
           Receivable.Credit_Note_No = Convert.ToString(dr["Credit_Note_No"]);
           Receivable.Credit_Note_Amount = Convert.ToDecimal(dr["Credit_Note_Amount"]);
           Receivable.Credit_Note_Date = Convert.ToDateTime(dr["Created_Date"]);

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
           }
           return Receivable;
       }

       public List<ReceivableInfo> Get_Gift_Voucher_Details_By_Id() //......
       {

           List<ReceivableInfo> Receivables = new List<ReceivableInfo>();

           List<SqlParameter> sqlparam = new List<SqlParameter>();

           DataTable dt = sqlHelper.ExecuteDataTable(sqlparam, Storeprocedures.Giftvoucher_Data_sp.ToString(), CommandType.StoredProcedure);

               foreach (DataRow dr in dt.Rows)
               {
                   ReceivableInfo Receivable = new ReceivableInfo();

                   Receivable.Gift_Voucher_Id = Convert.ToInt32(dr["Gift_Voucher_Id"]);

                   Receivable.Gift_Voucher_No = Convert.ToString(dr["Gift_Voucher_No"]);

                   Receivable.Gift_Voucher_Amount = Convert.ToDecimal(dr["Gift_Voucher_Amount"]);

                   Receivables.Add(Receivable);

           }
           return Receivables;
       }

       public ReceivableInfo Get_Gift_Voucher_Amount_By_Id(string Gift_Voucher_No)
       {

           ReceivableInfo Receivable = new ReceivableInfo();

           List<SqlParameter> sqlparam = new List<SqlParameter>();

           sqlparam.Add(new SqlParameter("@Gift_Voucher_No", Gift_Voucher_No));

           DataTable dt = sqlHelper.ExecuteDataTable(sqlparam, Storeprocedures.sp_Get_Gift_Voucher_By_Id.ToString(), CommandType.StoredProcedure);

           foreach (DataRow dr in dt.Rows)
           {

               Receivable.Gift_Voucher_Amount = Convert.ToDecimal(dr["Gift_Voucher_Amount"]);
           }
           return Receivable;
       }
    

   


       
    }
}
