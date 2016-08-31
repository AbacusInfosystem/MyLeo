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
    public class EmployeeRepo
    {
        SQL_Repo sqlHelper = null;

        public EmployeeRepo()
		{
			sqlHelper = new SQL_Repo();
		}

        public DataTable Get_Employees(QueryInfo query_Details)
        {
            return sqlHelper.Get_Table_With_Where(query_Details);
        }

        public int Insert_Employee(EmployeeInfo Employee)
        {
            return Convert.ToInt32(sqlHelper.ExecuteScalerObj(Set_Values_In_Employee(Employee), Storeprocedures.sp_Insert_Employee.ToString(), CommandType.StoredProcedure));
        }

        public void Update_Employee(EmployeeInfo Employee)
        {
            sqlHelper.ExecuteNonQuery(Set_Values_In_Employee(Employee), Storeprocedures.sp_Update_Employee.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> Set_Values_In_Employee(EmployeeInfo Employee)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (Employee.Employee_Id != 0)
            {
                sqlParam.Add(new SqlParameter("@Employee_Id", Employee.Employee_Id));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@Created_On", Employee.Created_Date));

                sqlParam.Add(new SqlParameter("@Created_By", Employee.Created_By));
            }
            sqlParam.Add(new SqlParameter("@Branch_Id", Employee.Branch_Id));

            sqlParam.Add(new SqlParameter("@Designation_Id", Employee.Designation_Id));

            sqlParam.Add(new SqlParameter("@Employee_Name", Employee.Employee_Name));

            sqlParam.Add(new SqlParameter("@Employee_DOB", Employee.Employee_DOB));

            sqlParam.Add(new SqlParameter("@Employee_Gender", Employee.Employee_Gender));

            sqlParam.Add(new SqlParameter("@Employee_Address", Employee.Employee_Address));

            sqlParam.Add(new SqlParameter("@Employee_City", Employee.Employee_City));

            sqlParam.Add(new SqlParameter("@Employee_State", Employee.Employee_State));

            sqlParam.Add(new SqlParameter("@Employee_Country", Employee.Employee_Country));

            sqlParam.Add(new SqlParameter("@Employee_Pincode", Employee.Employee_Pincode));

            sqlParam.Add(new SqlParameter("@Employee_Native_Address", Employee.Employee_Native_Address));

            sqlParam.Add(new SqlParameter("@Employee_Mobile1", Employee.Employee_Mobile1));

            sqlParam.Add(new SqlParameter("@Employee_Mobile2", Employee.Employee_Mobile2));

            sqlParam.Add(new SqlParameter("@Employee_Home_Lindline", Employee.Employee_Home_Lindline)); 
            
            sqlParam.Add(new SqlParameter("@Employee_EmailId", Employee.Employee_EmailId));

            sqlParam.Add(new SqlParameter("@IsActive", Employee.IsActive)); 

            sqlParam.Add(new SqlParameter("@Updated_On", Employee.Updated_Date));

            sqlParam.Add(new SqlParameter("@Updated_By", Employee.Updated_By)); 

            return sqlParam;
        }

        public EmployeeInfo Get_Employee_By_Id(int Employee_Id)
        {
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            sqlParamList.Add(new SqlParameter("@Employee_Id", Employee_Id));

            EmployeeInfo Employee = new EmployeeInfo();
            DataTable dt = sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.sp_Get_Employees_By_Id.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in dt.Rows)
            {
                Employee = Get_Employee_Values(dr);
            }
            return Employee;
        }

        private EmployeeInfo Get_Employee_Values(DataRow dr)
        {
            EmployeeInfo employee = new EmployeeInfo();

            employee.Employee_Id = Convert.ToInt32(dr["Employee_Id"]);
            employee.Branch_Id = Convert.ToInt32(dr["Branch_Id"]);
            employee.Employee_Name = Convert.ToString(dr["Employee_Name"]);
            employee.Designation_Id = Convert.ToInt32(dr["Designation_Id"]);
            employee.Employee_DOB = Convert.ToDateTime(dr["Employee_DOB"]);
            employee.Employee_Gender = Convert.ToInt32(dr["Employee_Gender"]);
            employee.Employee_Address = Convert.ToString(dr["Employee_Address"]);
            employee.Employee_City = Convert.ToString(dr["Employee_City"]);
            employee.Employee_State = Convert.ToString(dr["Employee_State"]);
            employee.Employee_Country = Convert.ToString(dr["Employee_Country"]);
            employee.Employee_Pincode = Convert.ToInt32(dr["Employee_Pincode"]);
            employee.Employee_Native_Address = Convert.ToString(dr["Employee_Native_Address"]);
            employee.Employee_Mobile1 = Convert.ToString(dr["Employee_Mobile1"]);
            employee.Employee_Mobile2 = Convert.ToString(dr["Employee_Mobile2"]);
            employee.Employee_Home_Lindline = Convert.ToString(dr["Employee_Home_Lindline"]);
            employee.Employee_EmailId = Convert.ToString(dr["Employee_EmailId"]);
            employee.IsActive = Convert.ToBoolean(dr["IsActive"]);
            employee.Created_Date = Convert.ToDateTime(dr["Created_On"]);
            employee.Created_By = Convert.ToInt32(dr["Created_By"]);
            employee.Updated_Date = Convert.ToDateTime(dr["Updated_On"]);
            employee.Updated_By = Convert.ToInt32(dr["Updated_By"]);
            return employee;
        }

        public List<EmployeeInfo> Get_Employees()
        {
            List<EmployeeInfo> Employees = new List<EmployeeInfo>();

            DataTable dt = sqlHelper.ExecuteDataTable(null, Storeprocedures.Get_Employee_Sp.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in dt.Rows)
            {
                EmployeeInfo Employee = new EmployeeInfo();

                Employee.Employee_Id = Convert.ToInt32(dr["Employee_Id"]);

                Employee.Employee_Name = Convert.ToString(dr["Employee_Name"]);

                Employees.Add(Employee);
            }
            return Employees;
        }
    }
}
