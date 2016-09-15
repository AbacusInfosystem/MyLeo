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
using MyLeoRetailerInfo.Branch;
using MyLeoRetailerInfo.Role;

namespace MyLeoRetailerRepo
{
    public class LoginRepo
    {
        SQL_Repo _sqlHelper = null;

        public LoginRepo()
        {
            _sqlHelper = new SQL_Repo();
        }

        public List<BranchInfo> Get_Branches(string User_Name)
        {

            List<BranchInfo> branchList = new List<BranchInfo>();

            List<SqlParameter> sqlParam = new List<SqlParameter>();
            sqlParam.Add(new SqlParameter("@User_Name", User_Name));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.sp_Get_Employee_Branches.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in dt.Rows)
            {
                BranchInfo branches = new BranchInfo();

                branches.Branch_ID = Convert.ToInt32(dr["Branch_ID"]);

                if (!dr.IsNull("Branch_Name"))
                    branches.Branch_Name = Convert.ToString(dr["Branch_Name"]);

                branchList.Add(branches);
            }
            return branchList;
        }

        public LoginInfo AuthenticateUser(string userName, string password)
        {
            LoginInfo user = new LoginInfo();

            List<SqlParameter> sqlParam = new List<SqlParameter>();
            sqlParam.Add(new SqlParameter("@User_Name", userName));
            sqlParam.Add(new SqlParameter("@Password", password));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.Authenticate_User_sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.AsEnumerable().FirstOrDefault();

                if (dr != null)
                {
                    user.User_Id = Convert.ToInt32(dr["Employee_Id"]);

                    user.Employee_Name = Convert.ToString(dr["Employee_Name"]);

                    user.Is_Online = Convert.ToBoolean(dr["Is_Online"]);

                    user.User_Name = Convert.ToString(dr["User_Name"]);

                    user.Password = Convert.ToString(dr["Password"]);

                }
            }

            return user;
        }

        private List<AccessFunctionInfo> Get_Access_Functions_By_Role(int Role_Id)
        {
            List<AccessFunctionInfo> accessFunList = new List<AccessFunctionInfo>();

            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            sqlParamList.Add(new SqlParameter("@Role_Id", Role_Id));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.sp_Get_Role_Access_Functions.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in dt.Rows)
            {
                AccessFunctionInfo accessfunctionInfo = new AccessFunctionInfo();

                if (!dr.IsNull("Access_Function_Name"))
                    accessfunctionInfo.Access_Function_Name = Convert.ToString(dr["Access_Function_Name"]);

                if (!dr.IsNull("Access_Function_Id"))
                    accessfunctionInfo.Access_Function_Id = Convert.ToInt32(dr["Access_Function_Id"]);

                if (!dr.IsNull("Role_Access_Function_Mapping_Id"))
                    accessfunctionInfo.Id = Convert.ToInt32(dr["Role_Access_Function_Mapping_Id"]);

                if (!dr.IsNull("Role_Id"))
                    accessfunctionInfo.Role_Id = Convert.ToInt32(dr["Role_Id"]);

                if (!dr.IsNull("Is_Access"))
                    accessfunctionInfo.Is_Access = Convert.ToBoolean(dr["Is_Access"]);

                if (!dr.IsNull("Is_Create"))
                    accessfunctionInfo.Is_Create = Convert.ToBoolean(dr["Is_Create"]);

                if (!dr.IsNull("Is_Edit"))
                    accessfunctionInfo.Is_Edit = Convert.ToBoolean(dr["Is_Edit"]);

                if (!dr.IsNull("Is_View"))
                    accessfunctionInfo.Is_View = Convert.ToBoolean(dr["Is_View"]);

                if (!dr.IsNull("Is_Active"))
                    accessfunctionInfo.Is_Active = Convert.ToBoolean(dr["Is_Active"]);

                accessFunList.Add(accessfunctionInfo);
            }

            return accessFunList;
        }

        //update token in emp tbl
        public string Set_User_Token_For_Cookies(int User_Id)
        {
            string user_Token = "Token" + DateTime.Now.ToString("yyMMddHHmmssff");

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@Token", user_Token));
            sqlParam.Add(new SqlParameter("@Employee_Id", User_Id));

            _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.Sp_Insert_Token_In_User_Table.ToString(), CommandType.StoredProcedure);

            return user_Token;
        }


        public LoginInfo Get_User_Data_By_User_Token(string token)
        {
            LoginInfo user = new LoginInfo();

            List<SqlParameter> sqlParam = new List<SqlParameter>();
            sqlParam.Add(new SqlParameter("@Token", token));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.Get_User_Data_By_Token_sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.AsEnumerable().FirstOrDefault();

                if (dr != null)
                {
                    
                    user.User_Id = Convert.ToInt32(dr["Employee_Id"]);

                    user.Employee_Name = Convert.ToString(dr["Employee_Name"]);

                    user.Is_Online = Convert.ToBoolean(dr["Is_Online"]);

                    user.User_Name = Convert.ToString(dr["User_Name"]);

                    user.Password = Convert.ToString(dr["Password"]);

                    user.Role_Id = Convert.ToInt32(dr["Role_Id"]);

                    user.Role_Name = Convert.ToString(dr["Role_Name"]);

                    user.Access_Functions = Get_Access_Functions_By_Role(user.Role_Id);

                }
            }

            return user;
        }



    }
}
