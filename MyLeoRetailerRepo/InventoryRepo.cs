﻿using MyLeoRetailerInfo.Common;
using MyLeoRetailerInfo.Inventory;
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
    public class InventoryRepo
    {
        SQL_Repo sqlHelper = null;

        public InventoryRepo()
        {
            sqlHelper = new SQL_Repo();
        }


        public DataTable Get_Inventories(Filter_Inventory filter, string Branch_Ids)
        {

            DataTable dt = new DataTable();

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@Branch_Ids", Branch_Ids));

            sqlParam.Add(new SqlParameter("@Branch_Id", filter.Branch_Id));

            sqlParam.Add(new SqlParameter("@Product_SKU", filter.Product_SKU));

            sqlParam.Add(new SqlParameter("@Brand_Code", filter.Brand_Code));

            sqlParam.Add(new SqlParameter("@Category_Code", filter.Category_Code));

            dt = sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.sp_Get_Inventories.ToString(), CommandType.StoredProcedure);

            return dt;
        }
    }
}
