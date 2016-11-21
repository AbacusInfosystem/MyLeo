using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Alteration;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerInfo.SalesInvoice;
using MyLeoRetailerRepo.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLeoRetailerInfo.Employee;//Added by vinod mane on 28/09/2016

namespace MyLeoRetailerRepo
{
   public class AlterationRepo
    {
        SQL_Repo sqlHelper = null;

        public AlterationRepo()
        {
            sqlHelper = new SQL_Repo();

        }

        public List<SqlParameter> Set_Values_In_Alteration(AlterationInfo Alteration)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (Alteration.Alteration_ID != 0)
            {
                sqlParam.Add(new SqlParameter("@Alteration_ID", Alteration.Alteration_ID));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@Created_Date", Alteration.Created_Date));

                sqlParam.Add(new SqlParameter("@Created_By", Alteration.Created_By));
            }

            sqlParam.Add(new SqlParameter("@Sales_Invoice_ID", Alteration.Sales_Invoice_ID));

            sqlParam.Add(new SqlParameter("@Product_Name", Alteration.Product_Name));

            sqlParam.Add(new SqlParameter("@Alteration_Date", Alteration.Alteration_Date));

            sqlParam.Add(new SqlParameter("@Delivery_Date", Alteration.Delivery_Date));

            sqlParam.Add(new SqlParameter("@Customer_Mobile_No", Alteration.Customer_Mobile_No));

            sqlParam.Add(new SqlParameter("@Job_Assigned_To", Alteration.Employee_Id));

            sqlParam.Add(new SqlParameter("@Additional_Info", Alteration.Additional_Info));

            sqlParam.Add(new SqlParameter("@Updated_Date", Alteration.Updated_Date));

            sqlParam.Add(new SqlParameter("@Updated_By", Alteration.Updated_By));

            return sqlParam;
        }

        private AlterationInfo Get_Alteration_Values(DataRow dr)
        {
            AlterationInfo Alteration = new AlterationInfo();

            Alteration.Alteration_ID = Convert.ToInt32(dr["Alteration_ID"]);

            Alteration.Sales_Invoice_ID = Convert.ToInt32(dr["Sales_Invoice_ID"]);

            Alteration.Product_Name = Convert.ToString(dr["Product_Name"]);


            if (!dr.IsNull("Alteration_Date"))
            {
                Alteration.Alteration_Date = Convert.ToDateTime(dr["Alteration_Date"]);
            }

            //Alteration.Alteration_Date = Convert.ToDateTime(dr["Alteration_Date"]);


            if (!dr.IsNull("Delivery_Date"))
            {
                Alteration.Delivery_Date = Convert.ToDateTime(dr["Delivery_Date"]);
            }

            //Alteration.Delivery_Date = Convert.ToDateTime(dr["Delivery_Date"]);

            Alteration.Customer_Mobile_No = Convert.ToString(dr["Customer_Mobile_No"]);

            Alteration.Employee_Id = Convert.ToInt32(dr["Job_Assigned_To"]);

            Alteration.Additional_Info = Convert.ToString(dr["Additional_Info"]);

            Alteration.Created_Date = Convert.ToDateTime(dr["Created_Date"]);

            Alteration.Created_By = Convert.ToInt32(dr["Created_By"]);

            Alteration.Updated_Date = Convert.ToDateTime(dr["Updated_Date"]);

            Alteration.Updated_By = Convert.ToInt32(dr["Updated_By"]);

            return Alteration;
        }

        public int Insert_Alteration(AlterationInfo Alteration)
        {
            return Convert.ToInt32(sqlHelper.ExecuteScalerObj(Set_Values_In_Alteration(Alteration), Storeprocedures.sp_Insert_Alteration.ToString(), CommandType.StoredProcedure));
        }

        public void Update_Alteration(AlterationInfo Alteration)
        {
            sqlHelper.ExecuteNonQuery(Set_Values_In_Alteration(Alteration), Storeprocedures.sp_Update_Alteration.ToString(), CommandType.StoredProcedure);
        }

        public DataTable Get_Alterations(Filter_Alteration Alteration)
        {
            //return sqlHelper.Get_Table_With_Where(query_Details);


            DataTable dt = new DataTable();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Customer_Mobile_No", Alteration.Customer_Mobile_No));

            dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_Get_Alterations.ToString(), CommandType.StoredProcedure);

            return dt;

        }

        public AlterationInfo Get_Alteration_By_Id(int Alteration_ID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Alteration_ID", Alteration_ID));

            AlterationInfo Alteration = new AlterationInfo();
            DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Alteration_By_Id.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {
                Alteration = Get_Alteration_Values(dr);
            }
            return Alteration;
        }

        public List<SalesInvoiceInfo> Get_SalesInvoices()
        {
            List<SalesInvoiceInfo> SalesInvoices = new List<SalesInvoiceInfo>();

            DataTable dt = sqlHelper.ExecuteDataTable(null, Storeprocedures.Get_SalesInvoice_Sp.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in dt.Rows)
            {
                SalesInvoiceInfo SalesInvoice = new SalesInvoiceInfo();

                SalesInvoice.Sales_Invoice_Id = Convert.ToInt32(dr["Sales_Invoice_Id"]);

                SalesInvoice.Sales_Invoice_No = Convert.ToString(dr["Sales_Invoice_No"]);

                SalesInvoices.Add(SalesInvoice);
            }
            return SalesInvoices;
        }

       //Added by Vinod Mane on 28/09/2016
        public List<EmployeeInfo> Get_Employees()
        {
            List<EmployeeInfo> Employee = new List<EmployeeInfo>();

            DataTable dt = sqlHelper.ExecuteDataTable(null, Storeprocedures.Get_Employee_Sp.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in dt.Rows)
            {
                EmployeeInfo Emp = new EmployeeInfo();

                Emp.Employee_Id = Convert.ToInt32(dr["Employee_Id"]);

                Emp.Employee_Name = Convert.ToString(dr["Employee_Name"]);

                Employee.Add(Emp);
            }
            return Employee;
        }
       //end
    }
}
