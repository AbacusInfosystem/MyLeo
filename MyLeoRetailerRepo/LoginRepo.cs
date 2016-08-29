using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLeoRetailerInfo.Common;
using System.Data.SqlClient;
using System.Data;
using MyLeoRetailerInfo;
using MyLeoRetailerRepo.Utility;

namespace MyLeoRetailerRepo
{
    public class LoginRepo
    {
        SQL_Repo _sqlHelper = null;

        public LoginRepo()
        {
            _sqlHelper = new SQL_Repo();
        }

        public LoginUserInfo AuthenticateUser(string userName, string password)
        {
            LoginUserInfo user = new LoginUserInfo();
            List<SqlParameter> sqlParam = new List<SqlParameter>();
            sqlParam.Add(new SqlParameter("@User_Name", userName));
            sqlParam.Add(new SqlParameter("@Password", password));
            try
            {
                DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.Authenticate_User_sp.ToString(), CommandType.StoredProcedure);

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow dr = dt.AsEnumerable().FirstOrDefault();

                    if (dr != null)
                    {
                        user.User_Id = Convert.ToInt32(dr["User_Id"]);
                        user.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
                        user.Username = Convert.ToString(dr["User_Name"]);
                        //user.First_Name = Convert.ToString(dr["First_Name"]);
                        //user.Last_Name = Convert.ToString(dr["Last_Name"]);
                        user.Role_Id = Convert.ToInt32(dr["Role_Id"]);
                        //user.Entity_Id = Convert.ToInt32(dr["Entity_Id"]);
                        //user.Brand_Name = Get_Role_Name(user.Role_Id, user.Entity_Id);
                    }
                }
            }
            catch (Exception ex)
            {
                //Logger.Error("UserRepo - AuthenticateLoginCredentials: " + ex.ToString());
            }

            return user;
        }

        public string Set_User_Token_For_Cookies(string userName, string password)
        {
            string user_Token = "Token" + DateTime.Now.ToString("yyMMddHHmmssff");
            try
            {
                List<SqlParameter> sqlParam = new List<SqlParameter>();
                sqlParam.Add(new SqlParameter("@user_Token", user_Token));
                sqlParam.Add(new SqlParameter("@User_Name", userName));
                _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.Insert_Token_In_User_Table_Sp.ToString(), CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                //Logger.Error("UserRepo - Set_User_Token_For_Cookies: " + ex.ToString());
            }

            return user_Token;
        }
    }
}
