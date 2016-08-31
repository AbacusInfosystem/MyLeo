using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerInfo.Employee;
using MyLeoRetailerRepo.Utility;

namespace MyLeoRetailerRepo
{
    public class ProductRepo
    { 
        SQL_Repo sqlHelper = null;

        public ProductRepo()
		{
			sqlHelper = new SQL_Repo();
		}

        public DataTable Get_Products(QueryInfo query_Details)
        {
            return sqlHelper.Get_Table_With_Where(query_Details);
        }
    }
}
