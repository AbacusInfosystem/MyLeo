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

            sqlParam.Add(new SqlParameter("@Updated_Date", brand.Updated_Date));

            sqlParam.Add(new SqlParameter("@Updated_By", brand.Updated_By));

			return sqlParam;
		}

		public DataTable Get_Barnds(QueryInfo query_Details)
		{
			return sqlHelper.Get_Table_With_Where(query_Details);
		}
		
	}
}
