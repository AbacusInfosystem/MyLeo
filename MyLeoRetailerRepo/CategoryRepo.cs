﻿using MyLeoRetailerInfo.Category;
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
	public class CategoryRepo
	{
		SQL_Repo sqlHelper = null;

		public CategoryRepo()
		{
			sqlHelper = new SQL_Repo();
		}

		public int Insert_Category(CategoryInfo category)
		{
			return Convert.ToInt32(sqlHelper.ExecuteScalerObj(Set_Values_In_Category(category), Storeprocedures.sp_Insert_Category.ToString(), CommandType.StoredProcedure));
		}

		public void Update_Category(CategoryInfo category)
		{
			sqlHelper.ExecuteNonQuery(Set_Values_In_Category(category), Storeprocedures.sp_Update_Category.ToString(), CommandType.StoredProcedure);
		}

		public List<SqlParameter> Set_Values_In_Category(CategoryInfo category)
		{
			List<SqlParameter> sqlParam = new List<SqlParameter>();

			if(category.Category_Id != 0)
			{
				sqlParam.Add(new SqlParameter("@Category_Id", category.Category_Id));
			}
			else
			{
				sqlParam.Add(new SqlParameter("@Created_Date", category.Created_Date));

				sqlParam.Add(new SqlParameter("@Created_By", category.Created_By));
			}

			sqlParam.Add(new SqlParameter("@Category",category.Category));

			sqlParam.Add(new SqlParameter("@Updated_Date",category.Updated_Date));

			sqlParam.Add(new SqlParameter("@Updated_By",category.Updated_By));

			return sqlParam;
		}

		public DataTable Get_Categories(QueryInfo query_Details)
		{
			return sqlHelper.Get_Table_With_Where(query_Details);
		}
		
	}
}
