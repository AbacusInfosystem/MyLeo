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

            sqlParam.Add(new SqlParameter("@Colour_Code", Color.Color_Code));

            //sqlParam.Add(new SqlParameter("@IsActive", Color.IsActive));//Commented by vinod mane on 27/09/2016

            //Added by Vinod Mane on 27/09/2016
            //Set Is_Active Flag

            if (Color.IsActive == 0)
            {
                Color.Is_Active = false;
            }
            else
            {
                Color.Is_Active = true;
            }
            sqlParam.Add(new SqlParameter("@IsActive", Color.IsActive));
            //End

            sqlParam.Add(new SqlParameter("@Updated_Date", Color.Updated_Date));

            sqlParam.Add(new SqlParameter("@Updated_By", Color.Updated_By));

            return sqlParam;
        }

        public DataTable Get_Colors(QueryInfo query_Details)
        {
            return sqlHelper.Get_Table_With_Where(query_Details);
        }

        public ColorInfo Get_Colors_By_Id(int Color_Id)
        {
            ColorInfo colorInfo = new ColorInfo();

            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            sqlParamList.Add(new SqlParameter("@Color_Id", Color_Id));

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.sp_Get_Colors_By_Id.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in dt.Rows)
            {
                if (!dr.IsNull("Colour_Code"))
                    colorInfo.Colour_Code = Convert.ToString(dr["Colour_Code"]);

                if (!dr.IsNull("Color_Code"))
                    colorInfo.Color_Code = Convert.ToString(dr["Color_Code"]);

              //  colorInfo.IsActive = Convert.ToBoolean(dr["Is_Active"]);//Commented by Vinod mane on 27/09/2016
                //Added by Vinod Mane on 27/09/2016
                colorInfo.IsActive = Convert.ToInt32(dr["Is_Active"]);
                colorInfo.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
                //End
               

                colorInfo.Colour_Id = Convert.ToInt32(dr["Colour_ID"]);

                if (!dr.IsNull("Colour_Name"))
                    colorInfo.Colour = Convert.ToString(dr["Colour_Name"]);
            }
            return colorInfo;

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


        public List<ColorInfo> Get_Colours()
        {
            List<ColorInfo> colors = new List<ColorInfo>();
            DataTable dt = sqlHelper.ExecuteDataTable(null, Storeprocedures.sp_Get_Colors.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {
                colors.Add(Get_Color_Values(dr));
            }
            return colors;
        }

        private ColorInfo Get_Color_Values(DataRow dr)
        {
            ColorInfo Color = new ColorInfo();

            Color.Colour_Id = Convert.ToInt32(dr["Colour_Id"]);

            if (!dr.IsNull("Colour_Name"))
                Color.Colour = Convert.ToString(dr["Colour_Name"]);
            return Color;
        }

        //Added By Vinod Mane on 23/09/2016
        public bool Check_Existing_Colour_Name(string Colour_Name)
        {
            bool check = false;

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@Colour_Name", Colour_Name));

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.sp_Check_Existing_Colour_Name.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                foreach (DataRow dr in drList)
                {
                    check = Convert.ToBoolean(dr["check_colour"]);
                }
            }

            return check;
        }

        //End
    }
}
