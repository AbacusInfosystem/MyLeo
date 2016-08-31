using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerInfo.Color;
using MyLeoRetailerRepo.Utility;

namespace MyLeoRetailerRepo
{
    public class ColorRepo
    {
        SQL_Repo sqlHelper = null;

        public ColorRepo()
		{
			sqlHelper = new SQL_Repo();
		}

        public int Insert_Color(ColorInfo Color)
        {
            return Convert.ToInt32(sqlHelper.ExecuteScalerObj(Set_Values_In_Color(Color), Storeprocedures.sp_Insert_Color.ToString(), CommandType.StoredProcedure));
        }

        public void Update_Color(ColorInfo Color)
        {
            sqlHelper.ExecuteNonQuery(Set_Values_In_Color(Color), Storeprocedures.sp_Update_Color.ToString(), CommandType.StoredProcedure);
        }

        public List<SqlParameter> Set_Values_In_Color(ColorInfo Color)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (Color.Colour_Id != 0)
            {
                sqlParam.Add(new SqlParameter("@Color_Id", Color.Colour_Id));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@Created_Date", Color.Created_Date));

                sqlParam.Add(new SqlParameter("@Created_By", Color.Created_By));
            }

            sqlParam.Add(new SqlParameter("@Color", Color.Colour));

            sqlParam.Add(new SqlParameter("@Color_Code", Color.Colour_Code));

            sqlParam.Add(new SqlParameter("@Updated_Date", Color.Updated_Date));

            sqlParam.Add(new SqlParameter("@Updated_By", Color.Updated_By));

            return sqlParam;
        }

        public DataTable Get_Colors(QueryInfo query_Details)
        {
            return sqlHelper.Get_Table_With_Where(query_Details);
        }

        public string Get_Colors_By_Id(int Color_Id)
        {
            string Color_Code = null;
            DataTable dt = null;
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            sqlParamList.Add(new SqlParameter("@Color_Id", Color_Id));

            dt = sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.sp_Get_Colors_By_Id.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in dt.Rows)
            {
                if (!dr.IsNull("Colour_Code"))
                    Color_Code = Convert.ToString(dr["Colour_Code"]); 
            }
            return Color_Code;

        }

        public List<AutocompleteInfo> Get_Colors_By_Name_Autocomplete(string color_Name)
        {
            List<AutocompleteInfo> autoList = new List<AutocompleteInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Color_Name", color_Name));

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.Get_Colors_By_Name_Autocomplete_Sp.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {
                AutocompleteInfo autoData = new AutocompleteInfo();

                autoData.Label = Convert.ToString(dr["Colour_Name"]);
                autoData.Value = Convert.ToInt32(dr["Colour_ID"]);

                autoList.Add(autoData);
            }
            return autoList;
        }

    }
}
