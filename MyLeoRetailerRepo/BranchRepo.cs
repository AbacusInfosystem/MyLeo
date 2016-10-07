using MyLeoRetailerInfo.Branch;
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
    public class BranchRepo
    {
        SQL_Repo sqlHelper = null;
        
        public BranchRepo()
		{
			sqlHelper = new SQL_Repo();
		}

        public List<SqlParameter> Set_Values_In_Branch(BranchInfo Branch)
         {
             List<SqlParameter> sqlParam = new List<SqlParameter>();

             if (Branch.Branch_ID != 0)
             {
                 sqlParam.Add(new SqlParameter("@Branch_ID", Branch.Branch_ID));
             }
             else
             {
                 sqlParam.Add(new SqlParameter("@Created_Date", Branch.Created_Date));

                 sqlParam.Add(new SqlParameter("@Created_By", Branch.Created_By));
             }

             sqlParam.Add(new SqlParameter("@Branch_Name", Branch.Branch_Name));
             sqlParam.Add(new SqlParameter("@Branch_Address", Branch.Branch_Address));
             sqlParam.Add(new SqlParameter("@Branch_City", Branch.Branch_City));
             sqlParam.Add(new SqlParameter("@Branch_State", Branch.Branch_State));
             sqlParam.Add(new SqlParameter("@Branch_Country", Branch.Branch_Country));
             sqlParam.Add(new SqlParameter("@Branch_Pincode", Branch.Branch_Pincode));
             sqlParam.Add(new SqlParameter("@Branch_Landline1", Branch.Branch_Landline1));
             sqlParam.Add(new SqlParameter("@Branch_Landline2", Branch.Branch_Landline2));

             //Set Is_Active Flag
             if (Branch.IsActive == 0)
             {
                 Branch.Is_Active = false;
             }
             else
             {
                 Branch.Is_Active = true;
             }
             //End

             sqlParam.Add(new SqlParameter("@Is_Active", Branch.Is_Active));

             sqlParam.Add(new SqlParameter("@Updated_Date", Branch.Updated_Date));

             sqlParam.Add(new SqlParameter("@Updated_By", Branch.Updated_By));

             return sqlParam;
         }

        private BranchInfo Get_Branch_Values(DataRow dr)
        {
            BranchInfo Branch = new BranchInfo();

            Branch.Branch_ID = Convert.ToInt32(dr["Branch_ID"]);

            if (!dr.IsNull("Branch_Name"))
            {
                Branch.Branch_Name = Convert.ToString(dr["Branch_Name"]);

                Branch.Branch_Address = Convert.ToString(dr["Branch_Address"]);
                Branch.Branch_City = Convert.ToString(dr["Branch_City"]);
                Branch.Branch_State = Convert.ToString(dr["Branch_State"]);
                Branch.Branch_Country = Convert.ToString(dr["Branch_Country"]);
                Branch.Branch_Pincode = Convert.ToInt32(dr["Branch_Pincode"]);
                Branch.Branch_Landline1 = Convert.ToString(dr["Branch_Landline1"]);
                Branch.Branch_Landline2 = Convert.ToString(dr["Branch_Landline2"]);

                Branch.Created_Date = Convert.ToDateTime(dr["Created_Date"]);
                Branch.Created_By = Convert.ToInt32(dr["Created_By"]);
                Branch.Updated_Date = Convert.ToDateTime(dr["Updated_Date"]);
                Branch.Updated_By = Convert.ToInt32(dr["Updated_By"]);

                Branch.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
                Branch.IsActive = Convert.ToInt32(dr["Is_Active"]);

                
            }

            return Branch;
        }

        public BranchInfo Get_Branch_By_Id(int Branch_Id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Branch_ID", Branch_Id));

            BranchInfo Branch = new BranchInfo();
            DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Branch_By_Id.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {
                Branch = Get_Branch_Values(dr);
            }
            return Branch;
        }

		public int Insert_Branch(BranchInfo Branch)
		{
            return Convert.ToInt32(sqlHelper.ExecuteScalerObj(Set_Values_In_Branch(Branch), Storeprocedures.sp_Insert_Branch.ToString(), CommandType.StoredProcedure));
		}

        public void Update_Branch(BranchInfo Branch)
		{
            sqlHelper.ExecuteNonQuery(Set_Values_In_Branch(Branch), Storeprocedures.sp_Update_Branch.ToString(), CommandType.StoredProcedure);
		}
       
        public DataTable Get_Branchs(QueryInfo query_Details)
		{
			return sqlHelper.Get_Table_With_Where(query_Details);
		}


        //public List<Location_Details> Get_Near_Branch_Location_By_Id(int Branch_Id)
        //{
        //    List<SqlParameter> parameters = new List<SqlParameter>();
        //    parameters.Add(new SqlParameter("@Branch_ID", Branch_Id));

        //    List<Location_Details> Branches = new List<Location_Details>();
                       
        //    DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Near_Branch_Location_By_Id.ToString(), CommandType.StoredProcedure);
        //    List<DataRow> drList = new List<DataRow>();
        //    drList = dt.AsEnumerable().ToList();
        //    foreach (DataRow dr in drList)
        //    {
        //        Location_Details Branch = new Location_Details();
                
        //        Branch.Branch_Location_ID = Convert.ToInt32(dr["Branch_Location_ID"]);

        //        Branch.Branch_Location_Flag = Convert.ToInt32(dr["Branch_Location_Flag"]);

        //        if (Branch.Branch_Location_Flag == 1)
        //        {
        //            Branch.Branch_Location_Pincode = Convert.ToInt32(dr["Branch_Location_Pincode"]);
        //        }

        //        Branches.Add(Branch);
        //    }
        //    return Branches;
        //}

        //public List<Location_Details> Get_Far_Branch_Location_By_Id(int Branch_Id)
        //{
        //    List<SqlParameter> parameters = new List<SqlParameter>();
        //    parameters.Add(new SqlParameter("@Branch_Id", Branch_Id));

        //    List<Location_Details> Branches = new List<Location_Details>();

        //    DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Far_Branch_Location_By_Id.ToString(), CommandType.StoredProcedure);
        //    List<DataRow> drList = new List<DataRow>();
        //    drList = dt.AsEnumerable().ToList();
        //    foreach (DataRow dr in drList)
        //    {
        //        Location_Details Branch = new Location_Details();

        //        Branch.Branch_Location_ID = Convert.ToInt32(dr["Branch_Location_ID"]);

        //        Branch.Branch_Location_Flag = Convert.ToInt32(dr["Branch_Location_Flag"]);

        //        if (Branch.Branch_Location_Flag == 2)
        //        {
        //            Branch.Branch_Location_Pincode = Convert.ToInt32(dr["Branch_Location_Pincode"]);
        //        }

        //        Branches.Add(Branch);
        //    }
        //    return Branches;
        //}

        //public void Insert_Near_Branch_Location(BranchInfo Branch)
        //{
        //    Branch.Branch_Location_Flag = 1;
           
        //        foreach (var item in Branch.NearLocationDetailsList)
        //        {
        //            List<SqlParameter> sqlparam = new List<SqlParameter>();

        //            sqlparam.Add(new SqlParameter("@Branch_ID", Branch.Branch_ID));
        //            sqlparam.Add(new SqlParameter("@Branch_Location_Flag", Branch.Branch_Location_Flag));
        //            sqlparam.Add(new SqlParameter("@Branch_Location_Pincode", item.Branch_Location_Pincode));
        //            sqlparam.Add(new SqlParameter("@Created_Date", Branch.Created_Date));
        //            sqlparam.Add(new SqlParameter("@Created_By", Branch.Created_By));

        //            //Set Is_Active Flag
        //            if (Branch.IsActive == 0)
        //            {
        //                Branch.Is_Active = false;
        //            }
        //            else
        //            {
        //                Branch.Is_Active = true;
        //            }
        //            //End

        //            sqlparam.Add(new SqlParameter("@Is_Active", Branch.Is_Active));
        //            sqlparam.Add(new SqlParameter("@Updated_Date", Branch.Updated_Date));
        //            sqlparam.Add(new SqlParameter("@Updated_By", Branch.Updated_By));

        //            sqlHelper.ExecuteScalerObj(sqlparam, Storeprocedures.sp_Insert_Branch_Location.ToString(), CommandType.StoredProcedure);
        //        }           
                     
        //}

        //public void Insert_Far_Branch_Location(BranchInfo Branch)
        //{
        //    Branch.Branch_Location_Flag = 2;
           
        //        foreach (var item in Branch.FarLocationDetailsList)
        //        {
        //            List<SqlParameter> sqlparam = new List<SqlParameter>();

        //            sqlparam.Add(new SqlParameter("@Branch_ID", Branch.Branch_ID));
        //            sqlparam.Add(new SqlParameter("@Branch_Location_Flag", Branch.Branch_Location_Flag));
        //            sqlparam.Add(new SqlParameter("@Branch_Location_Pincode", item.Branch_Location_Pincode));
        //            sqlparam.Add(new SqlParameter("@Created_Date", Branch.Created_Date));
        //            sqlparam.Add(new SqlParameter("@Created_By", Branch.Created_By));
                    

        //            //Set Is_Active Flag
        //            if (Branch.IsActive == 0)
        //            {
        //                Branch.Is_Active = false;
        //            }
        //            else
        //            {
        //                Branch.Is_Active = true;
        //            }
        //            //End

        //            sqlparam.Add(new SqlParameter("@Is_Active", Branch.Is_Active));
        //            sqlparam.Add(new SqlParameter("@Updated_Date", Branch.Updated_Date));
        //            sqlparam.Add(new SqlParameter("@Updated_By", Branch.Updated_By));

        //            sqlHelper.ExecuteScalerObj(sqlparam, Storeprocedures.sp_Insert_Branch_Location.ToString(), CommandType.StoredProcedure);
        //        }
            

        //}

        //public void Update_Near_Branch_Location(BranchInfo Branch)
        //{
        //    Branch.Branch_Location_Flag = 1;

        //    foreach (var item in Branch.NearLocationDetailsList)
        //    {
        //        List<SqlParameter> sqlparam = new List<SqlParameter>();

        //        sqlparam.Add(new SqlParameter("@Branch_Location_ID", item.Branch_Location_ID));
        //        sqlparam.Add(new SqlParameter("@Branch_ID", Branch.Branch_ID));
        //        sqlparam.Add(new SqlParameter("@Branch_Location_Flag", Branch.Branch_Location_Flag));
        //        sqlparam.Add(new SqlParameter("@Branch_Location_Pincode", item.Branch_Location_Pincode));
               
        //        //Set Is_Active Flag
        //        if (Branch.IsActive == 0)
        //        {
        //            Branch.Is_Active = false;
        //        }
        //        else
        //        {
        //            Branch.Is_Active = true;
        //        }
        //        //End

        //        sqlparam.Add(new SqlParameter("@Is_Active", Branch.Is_Active));
        //        sqlparam.Add(new SqlParameter("@Updated_Date", Branch.Updated_Date));
        //        sqlparam.Add(new SqlParameter("@Updated_By", Branch.Updated_By));

        //        sqlHelper.ExecuteScalerObj(sqlparam, Storeprocedures.sp_Update_Branch_Location.ToString(), CommandType.StoredProcedure);
        //    }

        //}

        //public void Update_Far_Branch_Location(BranchInfo Branch)
        //{
        //    Branch.Branch_Location_Flag = 2;

        //    foreach (var item in Branch.FarLocationDetailsList)
        //    {
        //        List<SqlParameter> sqlparam = new List<SqlParameter>();

        //        sqlparam.Add(new SqlParameter("@Branch_Location_ID", item.Branch_Location_ID));
        //        sqlparam.Add(new SqlParameter("@Branch_ID", Branch.Branch_ID));
        //        sqlparam.Add(new SqlParameter("@Branch_Location_Flag", Branch.Branch_Location_Flag));
        //        sqlparam.Add(new SqlParameter("@Branch_Location_Pincode", item.Branch_Location_Pincode));
                
        //        //Set Is_Active Flag
        //        if (Branch.IsActive == 0)
        //        {
        //            Branch.Is_Active = false;
        //        }
        //        else
        //        {
        //            Branch.Is_Active = true;
        //        }
        //        //End

        //        sqlparam.Add(new SqlParameter("@Is_Active", Branch.Is_Active));
        //        sqlparam.Add(new SqlParameter("@Updated_Date", Branch.Updated_Date));
        //        sqlparam.Add(new SqlParameter("@Updated_By", Branch.Updated_By));

        //        sqlHelper.ExecuteScalerObj(sqlparam, Storeprocedures.sp_Update_Branch_Location.ToString(), CommandType.StoredProcedure);
        //    }


        //}

        public List<Location_Details> Get_Branch_Location_By_Id(int Branch_Id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Branch_ID", Branch_Id));

            List<Location_Details> locations = new List<Location_Details>();

            DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Branch_Location_By_Id.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {
                Location_Details location = new Location_Details();

                location.Branch_Location_ID = Convert.ToInt32(dr["Branch_Location_ID"]);

                location.Branch_Id = Convert.ToInt32(dr["Branch_ID"]);

                location.Branch_Location_Flag = Convert.ToInt32(dr["Branch_Location_Flag"]);

                location.Branch_Location_Pincode = Convert.ToInt32(dr["Branch_Location_Pincode"]);

                location.Flag = true;

                locations.Add(location);
            }
            return locations;
        }

        public void Save_Branch_Location(BranchInfo Branch)
        {
            foreach (var item in Branch.LocationDetailsList)
            {
                if (item.Flag && item.Branch_Location_ID == 0)
                {
                    sqlHelper.ExecuteScalerObj(Set_Values_In_Branch_Location(item), Storeprocedures.sp_Insert_Branch_Location.ToString(), CommandType.StoredProcedure);
                }
                else if (item.Flag && item.Branch_Location_ID != 0)
                {
                    sqlHelper.ExecuteScalerObj(Set_Values_In_Branch_Location(item), Storeprocedures.sp_Update_Branch_Location.ToString(), CommandType.StoredProcedure);
                }
                else if (!item.Flag && item.Branch_Location_ID != 0)
                {
                    List<SqlParameter> sqlParams = new List<SqlParameter>();
                    sqlParams.Add(new SqlParameter("@Branch_Location_ID", item.Branch_Location_ID));

                    sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Delete_Branch_Location_By_Id.ToString(), CommandType.StoredProcedure);
                }
                
            }

        }

        public List<SqlParameter> Set_Values_In_Branch_Location(Location_Details location)
        {
            List<SqlParameter> sqlparam = new List<SqlParameter>();

            if (location.Branch_Location_ID != 0)
            {
                sqlparam.Add(new SqlParameter("@Branch_Location_ID", location.Branch_Location_ID));
            }
            sqlparam.Add(new SqlParameter("@Branch_ID", location.Branch_Id));
            sqlparam.Add(new SqlParameter("@Branch_Location_Flag", location.Branch_Location_Flag));
            sqlparam.Add(new SqlParameter("@Branch_Location_Pincode", location.Branch_Location_Pincode));

            if (location.Branch_Location_ID == 0)
            {
                sqlparam.Add(new SqlParameter("@Created_Date", location.Created_Date));
                sqlparam.Add(new SqlParameter("@Created_By", location.Created_By));
            }
            sqlparam.Add(new SqlParameter("@Updated_Date", location.Updated_Date));
            sqlparam.Add(new SqlParameter("@Updated_By", location.Updated_By));

            return sqlparam;
        }

        public List<BranchInfo> Get_Branches()
        {
            List<BranchInfo> Branches = new List<BranchInfo>();

            DataTable dt = sqlHelper.ExecuteDataTable(null, Storeprocedures.sp_Get_Branch.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in dt.Rows)
            {
                BranchInfo Branch = new BranchInfo();

                Branch.Branch_ID = Convert.ToInt32(dr["Branch_ID"]);

                Branch.Branch_Name = Convert.ToString(dr["Branch_Name"]);

                Branches.Add(Branch);
            }
            return Branches;
        }


        //Added By Vinod Mane on 27/09/2016
        public bool Check_Existing_Branch_Name(string Branch_Name)
        {
            bool check = false;

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@Branch_Name", Branch_Name));

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.sp_Check_Existing_Branch_Name.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                foreach (DataRow dr in drList)
                {
                    check = Convert.ToBoolean(dr["check_Branch_name"]);
                }
            }

            return check;
        }
        //End

	}
}
