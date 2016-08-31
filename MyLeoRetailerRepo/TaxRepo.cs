using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerInfo.Tax;
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
   public class TaxRepo
    {
       SQL_Repo sqlHelper = null;

       public TaxInfo tax;

        public TaxRepo()
		{
			sqlHelper = new SQL_Repo();

            tax = new TaxInfo();
		}

		public int Insert_Tax(TaxInfo Tax)
		{
			return Convert.ToInt32(sqlHelper.ExecuteScalerObj(Set_Values_In_Tax(Tax), Storeprocedures.sp_Insert_Tax.ToString(), CommandType.StoredProcedure));
		}

		public void Update_Tax(TaxInfo Tax)
		{
			sqlHelper.ExecuteNonQuery(Set_Values_In_Tax(Tax), Storeprocedures.sp_Update_Tax.ToString(), CommandType.StoredProcedure);
		}

		public List<SqlParameter> Set_Values_In_Tax(TaxInfo Tax)
		{
			List<SqlParameter> sqlParam = new List<SqlParameter>();

			if(Tax.Tax_Id != 0)
			{
				sqlParam.Add(new SqlParameter("@Tax_Id", Tax.Tax_Id));
			}
			else
			{
				sqlParam.Add(new SqlParameter("@Created_Date", Tax.Created_Date));

				sqlParam.Add(new SqlParameter("@Created_By", Tax.Created_By));
			}

            sqlParam.Add(new SqlParameter("@Tax_Name", Tax.Tax_Name));

            sqlParam.Add(new SqlParameter("@Tax_Value", Tax.Tax_Value));


            //Set Is_Active Flag
            if (Tax.IsActive == 0)
            {
                Tax.Is_Active = false;
            }
            else
            {
                Tax.Is_Active = true;
            }
            //End

            sqlParam.Add(new SqlParameter("@Is_Active", Tax.Is_Active));

			sqlParam.Add(new SqlParameter("@Updated_Date",Tax.Updated_Date));

			sqlParam.Add(new SqlParameter("@Updated_By",Tax.Updated_By));

			return sqlParam;
		}

        public TaxInfo Get_Tax_By_Id(int Tax_Id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Tax_Id", Tax_Id));
            DataTable dt = null;
            dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Tax_By_Id.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {
                tax.Tax_Value = Convert.ToDecimal(dr["Tax_Value"]);
                tax.IsActive = Convert.ToInt32(dr["Is_Active"]);
            }
            return tax;
        }

        //public string Get_Colors_By_Id(int Color_Id)
        //{
        //    string Color_Code = null;
        //    DataTable dt = null;
        //    List<SqlParameter> sqlParamList = new List<SqlParameter>();
        //    sqlParamList.Add(new SqlParameter("@Color_Id", Color_Id));

        //    dt = sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.sp_Get_Colors_By_Id.ToString(), CommandType.StoredProcedure);

        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        if (!dr.IsNull("Colour_Code"))
        //            Color_Code = Convert.ToString(dr["Colour_Code"]);
        //    }
        //    return Color_Code;

        //} 

		public DataTable Get_Taxes(QueryInfo query_Details)
		{
			return sqlHelper.Get_Table_With_Where(query_Details);
		}

        //public decimal Get_Tax_By_Id(int Tax_Id)
        //{
        //    decimal Tax_Value = 0;
        //    DataTable dt = null;
        //    List<SqlParameter> sqlParamList = new List<SqlParameter>();
        //    sqlParamList.Add(new SqlParameter("@Tax_Id", Tax_Id));

        //    dt = sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.sp_Get_Tax_By_Id.ToString(), CommandType.StoredProcedure);

        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        if (!dr.IsNull("Tax_Value"))
        //            Tax_Value = Convert.ToDecimal(dr["Tax_Value"]);

        //    }
        //    return Tax_Value;

        //}
    }
}
