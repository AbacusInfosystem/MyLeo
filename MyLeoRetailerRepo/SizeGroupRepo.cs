using MyLeoRetailerInfo.Size;
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
    public class SizeGroupRepo
    {
        SQL_Repo sqlHelper = null;

        public SizeGroupRepo()
        {
            sqlHelper = new SQL_Repo();
        }

        public int Insert_Size_Group(SizeGroupInfo sizegroup)
        {
            return Convert.ToInt32(sqlHelper.ExecuteScalerObj(Set_Values_In_SizeGroup(sizegroup), Storeprocedures.sp_Insert_SizeGroup.ToString(), CommandType.StoredProcedure));
        }

        public void Update_Size_Group(SizeGroupInfo sizegroup)
        {
            sqlHelper.ExecuteNonQuery(Set_Values_In_SizeGroup(sizegroup), Storeprocedures.sp_Update_Size_Group.ToString(), CommandType.StoredProcedure);
        }

        public List<SqlParameter> Set_Values_In_SizeGroup(SizeGroupInfo sizegroup)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (sizegroup.Size_Group_Id != 0)
            {
                sqlParam.Add(new SqlParameter("@Size_Group_Id", sizegroup.Size_Group_Id));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@Created_Date", sizegroup.Created_Date));

                sqlParam.Add(new SqlParameter("@Created_By", sizegroup.Created_By));
            }

            sqlParam.Add(new SqlParameter("@Size_Group_Name", sizegroup.Size_Group_Name));

            //Set Is_Active Flag

            if (sizegroup.IsActive == 0)
            {
                sizegroup.Is_Active = false;
            }
            else
            {
                sizegroup.Is_Active = true;
            }

            //End

            sqlParam.Add(new SqlParameter("@Is_Active", sizegroup.Is_Active));

            sqlParam.Add(new SqlParameter("@Updated_Date", sizegroup.Updated_Date));

            sqlParam.Add(new SqlParameter("@Updated_By", sizegroup.Updated_By));

            return sqlParam;
        }

        public DataTable Get_SizeGroups(QueryInfo query_Details)
        {
            return sqlHelper.Get_Table_With_Where(query_Details);
        }

        public int Get_SizeGroup_By_Id(int size_group_Id)
        {
            int isactive = 0;

            DataTable dt = null;

            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@Size_Group_Id", size_group_Id));

            dt = sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.sp_Get_SizeGroup_By_Id.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in dt.Rows)
            {
                if (!dr.IsNull("Is_Active"))
                {
                    isactive = Convert.ToInt32(dr["Is_Active"]);
                }
            }
            return isactive;

        }


        //Size

        public void Insert_Size(List<SizeGroupInfo> sizeList, SizeGroupInfo sizegroup)
        {
            foreach (var item in sizeList)
            {
                item.Size_Id = Convert.ToInt32(sqlHelper.ExecuteScalerObj(Set_Values_In_Size(item, sizegroup), Storeprocedures.sp_Insert_Size.ToString(), CommandType.StoredProcedure)); 
            }
        }

        public void Update_Size(List<SizeGroupInfo> sizeList, SizeGroupInfo sizegroup)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Size_Group_Id", sizegroup.Size_Group_Id));

            sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.Sp_Delete_Size_By_Id.ToString(), CommandType.StoredProcedure);


            foreach (var item in sizeList)
            {

                item.Size_Id = Convert.ToInt32(sqlHelper.ExecuteScalerObj(Set_Values_In_Size(item, sizegroup), Storeprocedures.sp_Insert_Size.ToString(), CommandType.StoredProcedure)); 
                
                //sqlHelper.ExecuteNonQuery(Set_Values_In_Size(item, sizegroup), Storeprocedures.sp_Update_Size.ToString(), CommandType.StoredProcedure); 
            }
        }

        //public void Delete_Size_By_Id(int size_Id)
        //{
        //    List<SqlParameter> sqlParams = new List<SqlParameter>();

        //    sqlParams.Add(new SqlParameter("@Size_Id", size_Id));

        //    sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.Sp_Delete_Size_By_Id.ToString(), CommandType.StoredProcedure);
        //}


        public List<SqlParameter> Set_Values_In_Size(SizeGroupInfo sizeitem, SizeGroupInfo sizegroup)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            //if (sizeitem.Size_Id != 0)
            //{
            //    sqlParam.Add(new SqlParameter("@Size_Id", sizeitem.Size_Id));
            //}
           
            sqlParam.Add(new SqlParameter("@Created_Date", sizegroup.Created_Date));

            sqlParam.Add(new SqlParameter("@Created_By", sizegroup.Created_By));
            
            sqlParam.Add(new SqlParameter("@Size_Group_Id", sizeitem.Size_Group_Id));

            sqlParam.Add(new SqlParameter("@Size_Name", sizeitem.Size_Name));

            sqlParam.Add(new SqlParameter("@Updated_Date", sizegroup.Updated_Date));

            sqlParam.Add(new SqlParameter("@Updated_By", sizegroup.Updated_By));

            return sqlParam;
        }

        public List<SizeGroupInfo> Get_Sizes(int Size_Group_Id)
        {

            List<SizeGroupInfo> Sizes = new List<SizeGroupInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Size_Group_Id", Size_Group_Id));

            //sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Get_Sizes_By_Size_Group_Id.ToString(), CommandType.StoredProcedure);
            
            DataTable dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_Get_Sizes_By_Size_Group_Id.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Sizes.Add(Get_Sizes_Values(dr));
                }
            }
            
            return Sizes;
        
        }

        public SizeGroupInfo Get_Sizes_Values(DataRow dr)
        {
            SizeGroupInfo retVal = new SizeGroupInfo();

            retVal.Size_Id = Convert.ToInt32(dr["Size_Id"]);

            retVal.Size_Name = Convert.ToString(dr["Size_Name"]);          

            return retVal;
        }



        public List<SizeGroupInfo> Get_All_SizeGroups()
        {
            List<SizeGroupInfo> SizeGroups = new List<SizeGroupInfo>();
            DataTable dt = sqlHelper.ExecuteDataTable(null, Storeprocedures.sp_Get_SizeGroup.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {
                SizeGroups.Add(Get_SizeGroups_Values(dr));
            }
            return SizeGroups;
        }

        private SizeGroupInfo Get_SizeGroups_Values(DataRow dr)
        {
            SizeGroupInfo SizeGroup = new SizeGroupInfo();

            SizeGroup.Size_Group_Id = Convert.ToInt32(dr["Size_Group_Id"]);

            if (!dr.IsNull("Size_Group_Name"))

            SizeGroup.Size_Group_Name = Convert.ToString(dr["Size_Group_Name"]);

            SizeGroup.IsActive = Convert.ToInt32(dr["Is_Active"]);

            SizeGroup.Is_Active = Convert.ToBoolean(dr["Is_Active"]);

            return SizeGroup;
        }
    }
}