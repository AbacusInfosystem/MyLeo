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
    public class StateRepo
    {
        SQL_Repo sqlHelper = null;

        public StateRepo()
        {
            sqlHelper = new SQL_Repo();
        }

        //public DataTable Get_States(QueryInfo query_Details)
        //{
        //    //return sqlHelper.Get_Table_With_Where(query_Details);
           
        //}

    }
}
