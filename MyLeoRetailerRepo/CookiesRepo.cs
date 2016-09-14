using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerInfo;
using MyLeoRetailerRepo.Utility;
namespace MyLeoRetailerRepo
{
    public class CookiesRepo
    {
        SQL_Repo _sqlHelper = null;

        public CookiesRepo()
        {
            _sqlHelper = new SQL_Repo();
        }

        public LoginInfo Get_User_Data_By_User_Token(string token)
        {
            LoginInfo cookie = null;
            
            List<SqlParameter> sqlParam = new List<SqlParameter>();
            sqlParam.Add(new SqlParameter("@Token", token));

            List<SqlParameter> sqlParamAccess = new List<SqlParameter>();
            sqlParamAccess.Add(new SqlParameter("@Token", token));

            try
            {
                DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.Get_User_Data_By_Token_sp.ToString(), CommandType.StoredProcedure);
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow dr = dt.AsEnumerable().FirstOrDefault();
                    if (dr != null)
                    {
                        cookie = new LoginInfo();
                        cookie.User_Id = Convert.ToInt32(dr["User_Id"]);
                        cookie.Role_Id = Convert.ToInt32(dr["Role_Id"]);
                        cookie.Role_Name = Convert.ToString(dr["Role_Name"]);
                        //cookie.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
                        

                    }
                }

            }
            catch (Exception ex)
            {
                //Logger.Error("CookiesRepo - Get_User_Data_By_User_Token: " + ex.ToString());
            }
            return cookie;
        }
    }
}
