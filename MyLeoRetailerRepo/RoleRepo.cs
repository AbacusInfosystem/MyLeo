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


    }
}
