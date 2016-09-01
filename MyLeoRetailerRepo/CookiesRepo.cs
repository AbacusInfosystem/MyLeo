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

        public LoginUserInfo Get_User_Data_By_User_Token(string token)
        {
            LoginUserInfo cookie = null;
            //List<AccessFunctionInfo> AccessFunctions = new List<AccessFunctionInfo>();

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
                        cookie = new LoginUserInfo();
                        cookie.User_Id = Convert.ToInt32(dr["User_Id"]);
                        cookie.Role_Id = Convert.ToInt32(dr["Role_Id"]);
                        cookie.Role_Name = Convert.ToString(dr["Role_Name"]);
                        cookie.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
                        //cookie.User_Name = Convert.ToString(dr["User_Name"]);
                        //cookie.First_Name = Convert.ToString(dr["First_Name"]);
                        //cookie.Last_Name = Convert.ToString(dr["Last_Name"]);
                        //cookie.User_Email = Convert.ToString(dr["Email_Id"]);
                        //if (dr["Entity_Id"] != DBNull.Value)
                        //    cookie.Entity_Id = Convert.ToInt32(dr["Entity_Id"]);
                        //cookie.Brand_Name = Convert.ToString(dr["Brand_Name"]); 

                    }
                }

                //DataTable dtAccess = _sqlHelper.ExecuteDataTable(sqlParamAccess, StoreProcedures.Get_Access_Function_Data_By_Token_sp.ToString(), CommandType.StoredProcedure);
                //if (dtAccess != null && dtAccess.Rows.Count > 0)
                //{
                //    List<DataRow> drList = new List<DataRow>();
                //    drList = dtAccess.AsEnumerable().ToList();
                //    foreach (DataRow dr in drList)
                //    {
                //        AccessFunctionInfo info = new AccessFunctionInfo();
                //        info.Access_Fuction_Id = Convert.ToInt32(dr["Access_Fuction_Id"]);
                //        info.Access_Function_Name = Convert.ToString(dr["Access_Function_Name"]);
                //        cookie.Access_Functions.Add(info);
                //    }
                //}
            }
            catch (Exception ex)
            {
                //Logger.Error("CookiesRepo - Get_User_Data_By_User_Token: " + ex.ToString());
            }
            return cookie;
        }
    }
}
