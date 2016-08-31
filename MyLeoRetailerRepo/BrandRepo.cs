using MyLeoRetailerInfo.Brand;
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
    public class BrandRepo
    {
        SQL_Repo sqlHelper = null;

        public BrandRepo()
		{
			sqlHelper = new SQL_Repo();
		}

		public int Insert_Brand(BrandInfo brand)
		{
            return Convert.ToInt32(sqlHelper.ExecuteScalerObj(Set_Values_In_Brand(brand), Storeprocedures.sp_Insert_Brand.ToString(), CommandType.StoredProcedure));
		}

        public void Update_Brand(BrandInfo brand)
		{
            sqlHelper.ExecuteNonQuery(Set_Values_In_Brand(brand), Storeprocedures.sp_Update_Brand.ToString(), CommandType.StoredProcedure);
		}

        public List<SqlParameter> Set_Values_In_Brand(BrandInfo brand)
		{
			List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (brand.Brand_Id != 0)
			{
                sqlParam.Add(new SqlParameter("@Brand_Id", brand.Brand_Id));
			}
			else
			{
                sqlParam.Add(new SqlParameter("@Created_Date", brand.Created_Date));

                sqlParam.Add(new SqlParameter("@Created_By", brand.Created_By));
			}
            
            sqlParam.Add(new SqlParameter("@Brand_Name", brand.Brand_Name));

            //Set Is_Active Flag
            if (brand.IsActive == 0)
            {
                brand.Is_Active = false;
            }
            else
            {
                brand.Is_Active = true;
            }
            //End

            sqlParam.Add(new SqlParameter("@Is_Active", brand.Is_Active));

            sqlParam.Add(new SqlParameter("@Updated_Date", brand.Updated_Date));

            sqlParam.Add(new SqlParameter("@Updated_By", brand.Updated_By));

			return sqlParam;
		}

		public DataTable Get_Barnds(QueryInfo query_Details)
		{
			return sqlHelper.Get_Table_With_Where(query_Details);
		}

        public int Get_Brand_By_Id(int Brand_Id)
        {            
            int isactive = 0;

            DataTable dt = null;
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            sqlParamList.Add(new SqlParameter("@Brand_Id", Brand_Id));

            dt = sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.sp_Get_Brand_By_Id.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in dt.Rows)
            {
                if (!dr.IsNull("Is_Active"))
                {
                    isactive = Convert.ToInt32(dr["Is_Active"]);                                     
                }
            }
            return isactive;


            

        }

        public List<AutocompleteInfo> Get_Brands_By_Name_Autocomplete(string brand_Name)
        {
            List<AutocompleteInfo> autoList = new List<AutocompleteInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Brand_Name", brand_Name));

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.Get_Brands_By_Name_Autocomplete_Sp.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {
                AutocompleteInfo autoData = new AutocompleteInfo();

                autoData.Label = Convert.ToString(dr["Brand_Name"]);
                autoData.Value = Convert.ToInt32(dr["Brand_Id"]);

                autoList.Add(autoData);
            }
            return autoList;
        }


	}
}
