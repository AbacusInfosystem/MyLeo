using MyLeoRetailerInfo;
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
    public class AutoGenerateNumberRepo
    {
        SQL_Repo sqlHelper = null;

        public AutoGenerateNumberRepo()
        {
            sqlHelper = new SQL_Repo();
        }

        public string Generate_Ref_No(string initialCharacter, string columnName, string substringStartIndex, string substringEndIndex, string tableName)
        {
            string RefNo = "";
            List<SqlParameter> sqp = new List<SqlParameter>();
            string strQry = "Select '" + initialCharacter + "' + CAST(ISNULL(max(CAST(substring(" + columnName + "," + substringStartIndex + "," + substringEndIndex + ") AS int))+1, 1) as nvarchar) as " + columnName + " from " + tableName;
            strQry += " where " + columnName + " like '" + initialCharacter + "' + '%'";

            DataTable dt = sqlHelper.ExecuteDataTable(sqp, strQry, CommandType.Text);
            foreach (DataRow dr in dt.Rows)
            {
                RefNo = Convert.ToString(dr[0]);
            }

            if (RefNo == "0")
            {
                RefNo = "1";
            }
            return RefNo;
        }

    }
}
