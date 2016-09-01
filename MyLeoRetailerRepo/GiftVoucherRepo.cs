using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerInfo.GiftVoucher;
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
   public class GiftVoucherRepo
    {
        SQL_Repo sqlHelper = null;

        public GiftVoucherRepo()
		{
			sqlHelper = new SQL_Repo();
		}

       public int Insert_Gift_Voucher(GiftVoucherInfo GiftVoucher)
       {
           return Convert.ToInt32(sqlHelper.ExecuteScalerObj(Set_Values_In_Gift_Voucher(GiftVoucher), Storeprocedures.sp_Insert_Gift_Voucher.ToString(), CommandType.StoredProcedure));
       }

       public void Update_Gift_Voucher(GiftVoucherInfo GiftVoucher)
       {
           sqlHelper.ExecuteNonQuery(Set_Values_In_Gift_Voucher(GiftVoucher), Storeprocedures.sp_Update_Gift_Voucher.ToString(), CommandType.StoredProcedure);
       }

       public List<SqlParameter> Set_Values_In_Gift_Voucher(GiftVoucherInfo GiftVoucher)
       {
           List<SqlParameter> sqlParam = new List<SqlParameter>();

           if (GiftVoucher.Gift_Voucher_Id != 0)
           {
               sqlParam.Add(new SqlParameter("@Gift_Voucher_Id", GiftVoucher.Gift_Voucher_Id));
           }
           else
           {
               sqlParam.Add(new SqlParameter("@Created_Date", GiftVoucher.Created_Date));

               sqlParam.Add(new SqlParameter("@Created_By", GiftVoucher.Created_By));
           }

           sqlParam.Add(new SqlParameter("@Gift_Voucher_No", GiftVoucher.Gift_Voucher_No));

           sqlParam.Add(new SqlParameter("@Person_Name", GiftVoucher.Person_Name));
   
           sqlParam.Add(new SqlParameter("@Gift_Voucher_Date", GiftVoucher.Gift_Voucher_Date));

           sqlParam.Add(new SqlParameter("@Gift_Voucher_Expiry_Date", GiftVoucher.Gift_Voucher_Expiry_Date));

           sqlParam.Add(new SqlParameter("@Gift_Voucher_Amount", GiftVoucher.Gift_Voucher_Amount));

           sqlParam.Add(new SqlParameter("@Payment_Mode", GiftVoucher.Payment_Mode));

           sqlParam.Add(new SqlParameter("@Bank_Name", GiftVoucher.Bank_Name));

           sqlParam.Add(new SqlParameter("@Credit_Card_No", GiftVoucher.Credit_Card_No));

           //Set Is_Active Flag
           if (GiftVoucher.IsActive == 0)
           {
               GiftVoucher.Is_Active = false;
           }
           else
           {
               GiftVoucher.Is_Active = true;
           }
           //End

           sqlParam.Add(new SqlParameter("@Is_Active", GiftVoucher.Is_Active));

           sqlParam.Add(new SqlParameter("@Updated_Date", GiftVoucher.Updated_Date));

           sqlParam.Add(new SqlParameter("@Updated_By", GiftVoucher.Updated_By));


           return sqlParam;
       }

       public DataTable Get_Gift_Vouchers(QueryInfo query_Details)
       {
           return sqlHelper.Get_Table_With_Where(query_Details);
       }

       public GiftVoucherInfo Get_Gift_Voucher_By_Id(int Gift_Voucher_Id)
       {
           List<SqlParameter> parameters = new List<SqlParameter>();
           parameters.Add(new SqlParameter("@Gift_Voucher_Id", Gift_Voucher_Id));

           GiftVoucherInfo vcInfo = new GiftVoucherInfo();
           DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Gift_Voucher_By_Id.ToString(), CommandType.StoredProcedure);
           List<DataRow> drList = new List<DataRow>();
           drList = dt.AsEnumerable().ToList();
           foreach (DataRow dr in drList)
           {
               vcInfo = Get_Gift_Voucher_Values(dr);
           }
           return vcInfo;
       }

       private GiftVoucherInfo Get_Gift_Voucher_Values(DataRow dr)
       {
           GiftVoucherInfo GiftVoucher = new GiftVoucherInfo();

           GiftVoucher.Gift_Voucher_Id = Convert.ToInt32(dr["Gift_Voucher_Id"]);

           if (!dr.IsNull("Gift_Voucher_No"))
           {
               GiftVoucher.Gift_Voucher_No = Convert.ToString(dr["Gift_Voucher_No"]);
               GiftVoucher.Person_Name = Convert.ToString(dr["Person_Name"]);
               GiftVoucher.Gift_Voucher_Date = Convert.ToDateTime(dr["Gift_Voucher_Date"]);
               GiftVoucher.Gift_Voucher_Expiry_Date = Convert.ToDateTime(dr["Gift_Voucher_Expiry_Date"]);
               GiftVoucher.Gift_Voucher_Amount = Convert.ToDecimal(dr["Gift_Voucher_Amount"]);
               GiftVoucher.Payment_Mode = Convert.ToInt32(dr["Payment_Mode"]);
               GiftVoucher.Bank_Name = Convert.ToString(dr["Bank_Name"]);
               GiftVoucher.Credit_Card_No = Convert.ToString(dr["Credit_Card_No"]);
               GiftVoucher.Created_Date = Convert.ToDateTime(dr["Created_Date"]);
               GiftVoucher.Created_By = Convert.ToInt32(dr["Created_By"]);
               GiftVoucher.Updated_Date = Convert.ToDateTime(dr["Updated_Date"]);
               GiftVoucher.Updated_By = Convert.ToInt32(dr["Updated_By"]);
               GiftVoucher.Is_Active = Convert.ToBoolean(dr["Is_Active"]);

               //Set IsActive Flag
               if (GiftVoucher.Is_Active == false)
               {
                   GiftVoucher.IsActive = 0;
               }
               else
               {
                   GiftVoucher.IsActive = 1;
               }
               //End

              
           }

           return GiftVoucher;
       }

       

    }
}