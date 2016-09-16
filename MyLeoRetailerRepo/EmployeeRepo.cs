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

            sqlParam.Add(new SqlParameter("@Is_Online", Employee.Is_Online));

            sqlParam.Add(new SqlParameter("@User_Name", Employee.User_Name));

            sqlParam.Add(new SqlParameter("@Password", Employee.Password));

            sqlParam.Add(new SqlParameter("@Role_Id", Employee.Role_Id));

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
                //Employee = Get_Employee_Values(dr);
                Employee.Employee_Id = Convert.ToInt32(dr["Employee_Id"]);
                Employee.Branch_Id = Convert.ToInt32(dr["Branch_Id"]);
                Employee.Employee_Name = Convert.ToString(dr["Employee_Name"]);
                Employee.Designation_Id = Convert.ToInt32(dr["Designation_Id"]);
                Employee.Employee_DOB = Convert.ToDateTime(dr["Employee_DOB"]);
                Employee.Employee_Gender = Convert.ToInt32(dr["Employee_Gender"]);
                Employee.Employee_Address = Convert.ToString(dr["Employee_Address"]);
                Employee.Employee_City = Convert.ToString(dr["Employee_City"]);
                Employee.Employee_State = Convert.ToString(dr["Employee_State"]);
                Employee.Employee_Country = Convert.ToString(dr["Employee_Country"]);
                Employee.Employee_Pincode = Convert.ToInt32(dr["Employee_Pincode"]);
                Employee.Employee_Native_Address = Convert.ToString(dr["Employee_Native_Address"]);
                Employee.Employee_Mobile1 = Convert.ToString(dr["Employee_Mobile1"]);
                Employee.Employee_Mobile2 = Convert.ToString(dr["Employee_Mobile2"]);
                Employee.Employee_Home_Lindline = Convert.ToString(dr["Employee_Home_Lindline"]);
                Employee.Employee_EmailId = Convert.ToString(dr["Employee_EmailId"]);
                Employee.IsActive = Convert.ToBoolean(dr["IsActive"]);
                Employee.Created_Date = Convert.ToDateTime(dr["Created_On"]);
                Employee.Created_By = Convert.ToInt32(dr["Created_By"]);
                Employee.Updated_Date = Convert.ToDateTime(dr["Updated_On"]);
                Employee.Updated_By = Convert.ToInt32(dr["Updated_By"]);

                Employee.Is_Online = Convert.ToBoolean(dr["Is_Online"]);
                Employee.User_Name = Convert.ToString(dr["User_Name"]);
                Employee.Password = Convert.ToString(dr["Password"]);
                Employee.Role_Id = Convert.ToInt32(dr["Role_Id"]);

            }
            return Employee;
        }

        //private EmployeeInfo Get_Employee_Values(DataRow dr)
        //{
        //    EmployeeInfo Employee = new EmployeeInfo();

        //    Employee.Employee_Id = Convert.ToInt32(dr["Employee_Id"]);
        //    Employee.Branch_Id = Convert.ToInt32(dr["Branch_Id"]);
        //    Employee.Employee_Name = Convert.ToString(dr["Employee_Name"]);
        //    Employee.Designation_Id = Convert.ToInt32(dr["Designation_Id"]);
        //    Employee.Employee_DOB = Convert.ToDateTime(dr["Employee_DOB"]);
        //    Employee.Employee_Gender = Convert.ToInt32(dr["Employee_Gender"]);
        //    Employee.Employee_Address = Convert.ToString(dr["Employee_Address"]);
        //    Employee.Employee_City = Convert.ToString(dr["Employee_City"]);
        //    Employee.Employee_State = Convert.ToString(dr["Employee_State"]);
        //    Employee.Employee_Country = Convert.ToString(dr["Employee_Country"]);
        //    Employee.Employee_Pincode = Convert.ToInt32(dr["Employee_Pincode"]);
        //    Employee.Employee_Native_Address = Convert.ToString(dr["Employee_Native_Address"]);
        //    Employee.Employee_Mobile1 = Convert.ToString(dr["Employee_Mobile1"]);
        //    Employee.Employee_Mobile2 = Convert.ToString(dr["Employee_Mobile2"]);
        //    Employee.Employee_Home_Lindline = Convert.ToString(dr["Employee_Home_Lindline"]);
        //    Employee.Employee_EmailId = Convert.ToString(dr["Employee_EmailId"]);
        //    Employee.IsActive = Convert.ToBoolean(dr["IsActive"]);
        //    Employee.Created_Date = Convert.ToDateTime(dr["Created_On"]);
        //    Employee.Created_By = Convert.ToInt32(dr["Created_By"]);
        //    Employee.Updated_Date = Convert.ToDateTime(dr["Updated_On"]);
        //    Employee.Updated_By = Convert.ToInt32(dr["Updated_By"]);
        //    return Employee;
        //}


        public bool Check_Existing_User_Name(string User_Name)
        {
            bool check = false;

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("User_Name", User_Name));

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.sp_Check_Existing_User_Name.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                foreach (DataRow dr in drList)
                {
                    check = Convert.ToBoolean(dr["check_User"]);
                }
            }

            return check;
        }

        //Addition by swapnali | Date:15/09/2016
      
        public List<EmployeeInfo> Get_Branch_By_Id(int Employee_Id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Employee_ID", Employee_Id));

            List<EmployeeInfo> Emp_Branch_List = new List<EmployeeInfo>();
            DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Branch_By_EmployeeId.ToString(), CommandType.StoredProcedure);
            //List<DataRow> drList = new List<DataRow>();
            //drList = dt.AsEnumerable().ToList();
            //foreach (DataRow dr in drList)
            //{
            //    Branch = Get_Branch_Values(dr);
            //}
            //return Branch;
            foreach (DataRow dr in dt.Rows)
            {
                EmployeeInfo Employee_Branch = new EmployeeInfo();
                Employee_Branch.Branch_Name = Convert.ToString(dr["Branch_Name"]);
                Employee_Branch.Branch_Id = Convert.ToInt32(dr["Branch_Id"]);
                Emp_Branch_List.Add(Employee_Branch);
            }
            return Emp_Branch_List;

        }


        //private List<EmployeeInfo> Get_Branch_Values(DataRow dr)
        //{
        //    List<EmployeeInfo> Employee_Branches = new List<EmployeeInfo>();
        //    EmployeeInfo Employee_Branch = new EmployeeInfo();

        //    Employee_Branch.Employee_Id = Convert.ToInt32(dr["Employee_Id"]);
        //     foreach (DataRow dr in dr.Rows)
        //    {

            
        //        Employee_Branch.Branch_Name = Convert.ToString(dr["Branch_Name"]);

        //        Employee_Branch.Branch_Id = Convert.ToInt32(dr["Branch_Id"]);

        //    }

        //    return Employee_Branch;
        //}

        public DataTable Get_Branches(QueryInfo query_Details)
        {
            return sqlHelper.Get_Table_With_Where(query_Details);
        }

        //End

    }
}
