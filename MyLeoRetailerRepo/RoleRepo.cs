using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerInfo.Role;
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
    public class RoleRepo
    {
        SQL_Repo _sqlRepo = null;

        public RoleRepo()
        {
            _sqlRepo = new SQL_Repo();
        }

        public int Insert_Role(RoleInfo role)
        {
            return Convert.ToInt32(_sqlRepo.ExecuteScalerObj(Set_Values_In_Role(role), Storeprocedures.sp_Insert_Role.ToString(), CommandType.StoredProcedure));
        }

        public void Update_Role(RoleInfo role)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Role(role), Storeprocedures.sp_Update_Role.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> Set_Values_In_Role(RoleInfo role)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            if (role.Role_Id != 0)
            {
                sqlParams.Add(new SqlParameter("@Role_Id", role.Role_Id));
            }
            sqlParams.Add(new SqlParameter("@Role_Name", role.Role_Name));
            sqlParams.Add(new SqlParameter("@Is_Active", role.Is_Active));
            if (role.Role_Id == 0)
            {
                sqlParams.Add(new SqlParameter("@Created_By", role.Created_By));
                sqlParams.Add(new SqlParameter("@Created_Date", role.Created_Date));
            }
            sqlParams.Add(new SqlParameter("@Updated_By", role.Updated_By));
            sqlParams.Add(new SqlParameter("@Updated_Date", role.Updated_Date));

            return sqlParams;
        }

        public DataTable Get_Roles(QueryInfo query_Details)
        {
            return _sqlRepo.Get_Table_With_Where(query_Details);
        }

        public RoleInfo Get_Role_By_Id(int role_Id)
        {
            RoleInfo roleInfo = new RoleInfo();

            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            sqlParamList.Add(new SqlParameter("@Role_Id", role_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParamList, Storeprocedures.sp_Get_Role_By_Id.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in dt.Rows)
            {
                roleInfo.Role_Id = Convert.ToInt32(dr["Role_Id"]);

                roleInfo.Role_Name = Convert.ToString(dr["Role_Name"]);

                roleInfo.Is_Active = Convert.ToBoolean(dr["Is_Active"]);


            }
            return roleInfo;

        }

        public List<AccessFunctionInfo> Get_Role_Access_Functions(int role_Id)
        {
            List<AccessFunctionInfo> accessfunctionList = new List<AccessFunctionInfo>();

            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            sqlParamList.Add(new SqlParameter("@Role_Id", role_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParamList, Storeprocedures.sp_Get_Role_Access_Functions.ToString(), CommandType.StoredProcedure);

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

                accessfunctionList.Add(accessfunctionInfo);
            }

            return accessfunctionList;

        }

        public void Save_Role_Access_Function(List<AccessFunctionInfo> accessFunctions, int Role_Id)
        {
            foreach (var item in accessFunctions)
            {
                if (item.Id == 0)
                {
                    _sqlRepo.ExecuteNonQuery(Set_Values_In_Role_Access_Function(item, Role_Id), Storeprocedures.sp_Insert_Role_Access_Function.ToString(), CommandType.StoredProcedure);
                }
                else
                {
                    _sqlRepo.ExecuteNonQuery(Set_Values_In_Role_Access_Function(item, Role_Id), Storeprocedures.sp_Update_Role_Access_Function.ToString(), CommandType.StoredProcedure);
                }

            }
        }

        private List<SqlParameter> Set_Values_In_Role_Access_Function(AccessFunctionInfo role_Access_Function, int Role_Id)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            if (role_Access_Function.Id != 0)
            {
                sqlParams.Add(new SqlParameter("@Role_Access_Function_Mapping_Id", role_Access_Function.Id));
            }
            sqlParams.Add(new SqlParameter("@Role_Id", Role_Id));
            sqlParams.Add(new SqlParameter("@Access_Function_Id", role_Access_Function.Access_Function_Id));
            sqlParams.Add(new SqlParameter("@Is_Access", role_Access_Function.Is_Access));
            sqlParams.Add(new SqlParameter("@Is_Create", role_Access_Function.Is_Create));
            sqlParams.Add(new SqlParameter("@Is_Edit", role_Access_Function.Is_Edit));
            sqlParams.Add(new SqlParameter("@Is_View", role_Access_Function.Is_View));
            sqlParams.Add(new SqlParameter("@Is_Active", role_Access_Function.Is_Active));

            if (role_Access_Function.Id == 0)
            {
                sqlParams.Add(new SqlParameter("@Created_By", role_Access_Function.Created_By));
                sqlParams.Add(new SqlParameter("@Created_Date", role_Access_Function.Created_Date));
            }
            sqlParams.Add(new SqlParameter("@Updated_By", role_Access_Function.Updated_By));
            sqlParams.Add(new SqlParameter("@Updated_Date", role_Access_Function.Updated_Date));

            return sqlParams;
        }

        public bool Check_Existing_Role_Name(string role_Name)
        {
            bool check = false;

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@Role_Name", role_Name));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParam, Storeprocedures.sp_Check_Existing_Role_Name.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                foreach (DataRow dr in drList)
                {
                    check = Convert.ToBoolean(dr["check_Role"]);
                }
            }

            return check;
        }

        public List<RoleInfo> Get_Role_List()
        {
            List<RoleInfo> roleList = new List<RoleInfo>();

            DataTable dt = _sqlRepo.ExecuteDataTable(null, Storeprocedures.sp_Get_Roles.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in dt.Rows)
            {
                RoleInfo role = new RoleInfo();

                if (!dr.IsNull("Role_Id"))
                    role.Role_Id = Convert.ToInt32(dr["Role_Id"]);

                if (!dr.IsNull("Role_Name"))
                    role.Role_Name = Convert.ToString(dr["Role_Name"]);

                roleList.Add(role);
            }

            return roleList;

        }


    }
}
