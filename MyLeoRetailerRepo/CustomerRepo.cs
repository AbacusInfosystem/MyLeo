using MyLeoRetailerInfo.Customer;
using MyLeoRetailerRepo.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Common;

namespace MyLeoRetailerRepo
{
    public class CustomerRepo
    {
        SQL_Repo sqlHelper = null;

        public CustomerRepo()
		{
			sqlHelper = new SQL_Repo();
		}

		public int Insert_Customer(CustomerInfo Customer)
		{
            return Convert.ToInt32(sqlHelper.ExecuteScalerObj(Set_Values_In_Customer(Customer), Storeprocedures.sp_Insert_Customer.ToString(), CommandType.StoredProcedure));
		}

        public void Update_Customer(CustomerInfo Customer)
		{
            sqlHelper.ExecuteNonQuery(Set_Values_In_Customer(Customer), Storeprocedures.sp_Update_Customer.ToString(), CommandType.StoredProcedure);
		}

        public List<SqlParameter> Set_Values_In_Customer(CustomerInfo Customer)
		{
			List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (Customer.Customer_Id != 0)
			{
                sqlParam.Add(new SqlParameter("@Customer_Id", Customer.Customer_Id));
			}
			else
			{
                sqlParam.Add(new SqlParameter("@Created_Date", Customer.Created_Date));

                sqlParam.Add(new SqlParameter("@Created_By", Customer.Created_By));
			}

            Customer.Customer_Name = Customer.First_Name + " " + Customer.Last_Name;

            sqlParam.Add(new SqlParameter("@Customer_Name", Customer.Customer_Name));

            sqlParam.Add(new SqlParameter("@Customer_Billing_Address", Customer.Customer_Billing_Address));
            sqlParam.Add(new SqlParameter("@Customer_Billing_City", Customer.Customer_Billing_City));
            sqlParam.Add(new SqlParameter("@Customer_Billing_State", Customer.Customer_Billing_State));
            sqlParam.Add(new SqlParameter("@Customer_Billing_Country", Customer.Customer_Billing_Country));
            sqlParam.Add(new SqlParameter("@Customer_Billing_Pincode", Customer.Customer_Billing_Pincode));

            sqlParam.Add(new SqlParameter("@Customer_Shipping_Address", Customer.Customer_Shipping_Address));
            sqlParam.Add(new SqlParameter("@Customer_Shipping_City", Customer.Customer_Shipping_City));
            sqlParam.Add(new SqlParameter("@Customer_Shipping_State", Customer.Customer_Shipping_State));
            sqlParam.Add(new SqlParameter("@Customer_Shipping_Country", Customer.Customer_Shipping_Country));
            sqlParam.Add(new SqlParameter("@Customer_Shipping_Pincode", Customer.Customer_Shipping_Pincode));

            sqlParam.Add(new SqlParameter("@Customer_Mobile1", Customer.Customer_Mobile1));
            sqlParam.Add(new SqlParameter("@Customer_Mobile2", Customer.Customer_Mobile2));
            sqlParam.Add(new SqlParameter("@Customer_Landline1", Customer.Customer_Landline1));
            sqlParam.Add(new SqlParameter("@Customer_Landline2", Customer.Customer_Landline2));

            sqlParam.Add(new SqlParameter("@Customer_Gender", Customer.Customer_Gender));

            if (Customer.Customer_DOB==DateTime.MinValue)
            {
                sqlParam.Add(new SqlParameter("@Customer_DOB", null));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@Customer_DOB", Customer.Customer_DOB));
            }           

            sqlParam.Add(new SqlParameter("@Customer_Child1_Name", Customer.Customer_Child1_Name));
            sqlParam.Add(new SqlParameter("@Customer_Child2_Name", Customer.Customer_Child2_Name));

            if (Customer.Customer_Child1_DOB == DateTime.MinValue)
            {
                sqlParam.Add(new SqlParameter("@Customer_Child1_DOB", null));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@Customer_Child1_DOB", Customer.Customer_Child1_DOB));
            }

            if (Customer.Customer_Child2_DOB == DateTime.MinValue)
            {
                sqlParam.Add(new SqlParameter("@Customer_Child2_DOB", null));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@Customer_Child2_DOB", Customer.Customer_Child2_DOB));
            }

            if (Customer.Customer_Wedding_Anniversary == DateTime.MinValue)
            {
                sqlParam.Add(new SqlParameter("@Customer_Wedding_Anniversary", null));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@Customer_Wedding_Anniversary", Customer.Customer_Wedding_Anniversary));
            }    
                       
            sqlParam.Add(new SqlParameter("@Customer_Email1", Customer.Customer_Email1));
            sqlParam.Add(new SqlParameter("@Customer_Email2", Customer.Customer_Email2));
            sqlParam.Add(new SqlParameter("@Customer_Spouse_Name", Customer.Customer_Spouse_Name));

            if (Customer.Customer_Spouse_DOB == DateTime.MinValue)
            {
                sqlParam.Add(new SqlParameter("@Customer_Spouse_DOB", null));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@Customer_Spouse_DOB", Customer.Customer_Spouse_DOB));
            }    
           

            //Set Is_Active Flag
            if (Customer.IsActive == 0 )
            {
                Customer.Is_Active = false;
            }
            else
            {
                Customer.Is_Active = true;
            }
            //End

            sqlParam.Add(new SqlParameter("@Is_Active", Customer.Is_Active));
            
            sqlParam.Add(new SqlParameter("@Updated_Date", Customer.Updated_Date));

            sqlParam.Add(new SqlParameter("@Updated_By", Customer.Updated_By));

			return sqlParam;
		}

        public DataTable Get_Customers(QueryInfo query_Details)
		{
			return sqlHelper.Get_Table_With_Where(query_Details);
		}

        public CustomerInfo Get_Customer_By_Id(int Customer_Id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Customer_Id", Customer_Id));

            CustomerInfo Customer = new CustomerInfo();
            DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Customer_By_Id.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {
                Customer = Get_Customer_Values(dr);
            }
            return Customer;
        }

        public CustomerInfo Get_Customer_By_Mobile(string Mobile)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Mobile", Mobile));

            CustomerInfo Customer = new CustomerInfo();
            DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Customer_By_Mobile.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {
                Customer = Get_Customer_Values(dr);
            }
            return Customer;
        }

        private CustomerInfo Get_Customer_Values(DataRow dr)
        {
            CustomerInfo Customer = new CustomerInfo();

            Customer.Customer_Id = Convert.ToInt32(dr["Customer_Id"]);

            if (!dr.IsNull("Customer_Name"))
            {
                Customer.Customer_Name = Convert.ToString(dr["Customer_Name"]);

                Customer.Customer_Billing_Address = Convert.ToString(dr["Customer_Billing_Address"]);
                Customer.Customer_Billing_City = Convert.ToString(dr["Customer_Billing_City"]);
                Customer.Customer_Billing_State = Convert.ToString(dr["Customer_Billing_State"]);
                Customer.Customer_Billing_Country = Convert.ToString(dr["Customer_Billing_Country"]);
                Customer.Customer_Billing_Pincode = Convert.ToInt32(dr["Customer_Billing_Pincode"]);

                Customer.Customer_Shipping_Address = Convert.ToString(dr["Customer_Shipping_Address"]);
                Customer.Customer_Shipping_City = Convert.ToString(dr["Customer_Shipping_City"]);
                Customer.Customer_Shipping_State = Convert.ToString(dr["Customer_Shipping_State"]);
                Customer.Customer_Shipping_Country = Convert.ToString(dr["Customer_Shipping_Country"]);
                Customer.Customer_Shipping_Pincode = Convert.ToInt32(dr["Customer_Shipping_Pincode"]);

                Customer.Customer_Mobile1 = Convert.ToString(dr["Customer_Mobile1"]);
                Customer.Customer_Mobile2 = Convert.ToString(dr["Customer_Mobile2"]);
                Customer.Customer_Landline1 = Convert.ToString(dr["Customer_Landline1"]);
                Customer.Customer_Landline2 = Convert.ToString(dr["Customer_Landline2"]);
                Customer.Customer_Email1 = Convert.ToString(dr["Customer_Email1"]);
                Customer.Customer_Email2 = Convert.ToString(dr["Customer_Email2"]);

                Customer.Customer_Gender = Convert.ToInt32(dr["Customer_Gender"]);

                if (dr.IsNull("Customer_DOB"))
                {
                    Customer.Customer_DOB = DateTime.MinValue;
                }
                else
                {
                    Customer.Customer_DOB = Convert.ToDateTime(dr["Customer_DOB"]);                  
                }
               
                Customer.Customer_Child1_Name = Convert.ToString(dr["Customer_Child1_Name"]);
                Customer.Customer_Child2_Name = Convert.ToString(dr["Customer_Child2_Name"]);
                Customer.Customer_Spouse_Name = Convert.ToString(dr["Customer_Spouse_Name"]);

                if (dr.IsNull("Customer_Child1_DOB"))
                {
                    Customer.Customer_Child1_DOB = DateTime.MinValue;
                }
                else
                {
                    Customer.Customer_Child1_DOB = Convert.ToDateTime(dr["Customer_Child1_DOB"]);
                }

                if (dr.IsNull("Customer_Child2_DOB"))
                {
                    Customer.Customer_Child2_DOB = DateTime.MinValue;
                }
                else
                {
                    Customer.Customer_Child2_DOB = Convert.ToDateTime(dr["Customer_Child2_DOB"]);
                }

                if (dr.IsNull("Customer_Spouse_DOB"))
                {
                    Customer.Customer_Spouse_DOB = DateTime.MinValue;
                }
                else
                {
                    Customer.Customer_Spouse_DOB = Convert.ToDateTime(dr["Customer_Spouse_DOB"]);
                }

                if (dr.IsNull("Customer_Spouse_DOB"))
                {
                    Customer.Customer_Wedding_Anniversary = DateTime.MinValue;
                }
                else
                {
                    Customer.Customer_Wedding_Anniversary = Convert.ToDateTime(dr["Customer_Wedding_Anniversary"]);
                }
               
                Customer.Created_Date = Convert.ToDateTime(dr["Created_Date"]);
                Customer.Created_By = Convert.ToInt32(dr["Created_By"]);
                Customer.Updated_Date = Convert.ToDateTime(dr["Updated_Date"]);
                Customer.Updated_By = Convert.ToInt32(dr["Updated_By"]);
                
                Customer.IsActive = Convert.ToInt32(dr["Is_Active"]);
                Customer.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
                                
                //Split Customer_Name
                string[] nameParts = Customer.Customer_Name.Split(' ');

                Customer.First_Name = nameParts[0];
                Customer.Last_Name = nameParts[1];
                //End
                                
            }

            return Customer;
        }

        //Added By Vinod Mane on 28/09/2016
        public bool Check_Existing_Customer_Name(string customer_name)
        {
            bool check = false;

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@Customer_Name", customer_name));

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.sp_Check_Existing_Customer_Name.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                foreach (DataRow dr in drList)
                {
                    check = Convert.ToBoolean(dr["check_Customer_name"]);
                }
            }

            return check;
        }
        //End

	}
}
