using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Category;
using MyLeoRetailerInfo.Common;
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
	public class SubCategoryRepo
	{
		SQL_Repo sqlHelper = null;

        public SubCategoryRepo()
		{
			sqlHelper = new SQL_Repo();
		}

		public int Insert_Sub_Category(SubCategoryInfo category)
		{
			return Convert.ToInt32(sqlHelper.ExecuteScalerObj(Set_Values_In_Sub_Category(category), Storeprocedures.sp_Insert_Sub_Category.ToString(), CommandType.StoredProcedure));
		}

		public void Update_Sub_Category(SubCategoryInfo category)
		{
			sqlHelper.ExecuteNonQuery(Set_Values_In_Sub_Category(category), Storeprocedures.sp_Update_Sub_Category.ToString(), CommandType.StoredProcedure);
		}

		public List<SqlParameter> Set_Values_In_Sub_Category(SubCategoryInfo sub_Category)
		{
			List<SqlParameter> sqlParam = new List<SqlParameter>();

			if(sub_Category.Sub_Category_Id != 0)
			{
				sqlParam.Add(new SqlParameter("@Sub_Category_Id", sub_Category.Sub_Category_Id));
			}
			else
			{
				sqlParam.Add(new SqlParameter("@Created_Date", sub_Category.Created_Date));

				sqlParam.Add(new SqlParameter("@Created_By", sub_Category.Created_By));
			}

			sqlParam.Add(new SqlParameter("@Category_Id", sub_Category.Category_Id));

			sqlParam.Add(new SqlParameter("@Sub_Category", sub_Category.Sub_Category));

            sqlParam.Add(new SqlParameter("@IsActive", sub_Category.IsActive));

			sqlParam.Add(new SqlParameter("@Updated_Date", sub_Category.Updated_Date));

			sqlParam.Add(new SqlParameter("@Updated_By", sub_Category.Updated_By));

			return sqlParam;
		}

		public DataTable Get_Sub_Categories(QueryInfo query_Details)
		{
			return sqlHelper.Get_Table_With_Where(query_Details);
		}

        public List<SubCategoryInfo> drp_Get_Sub_Categories()
        {
            List<SubCategoryInfo> subcategories = new List<SubCategoryInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_drp_Get_Sub_Categories.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    subcategories.Add(Get_SubCategory_Values(dr));
                }
            }
            return subcategories;
        }

        public SubCategoryInfo Get_SubCategory_Values(DataRow dr)
        {
            SubCategoryInfo retVal = new SubCategoryInfo();

            retVal.Sub_Category_Id = Convert.ToInt32(dr["Sub_Category_Id"]);

            retVal.Sub_Category = Convert.ToString(dr["Sub_Category"]);

            return retVal;
        }

        public SubCategoryInfo Get_Sub_Category_By_Id(int Sub_category_Id)
        {
            SubCategoryInfo subcategoryInfo = new SubCategoryInfo();

            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            sqlParamList.Add(new SqlParameter("@Sub_Category_Id", Sub_category_Id));

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.sp_Get_Sub_Category_By_Id.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in dt.Rows)
            {
                if (!dr.IsNull("Sub_Category"))
                    subcategoryInfo.Category = Convert.ToString(dr["Sub_Category"]);

                subcategoryInfo.IsActive = Convert.ToBoolean(dr["IsActive"]);
            }
            return subcategoryInfo;

        } 

	}
}
