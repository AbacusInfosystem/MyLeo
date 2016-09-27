using MyLeoRetailerInfo.Brand;
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
    public class BrandRepo
    {
        SQL_Repo sqlHelper = null;

        public BrandRepo()
		{
			sqlHelper = new SQL_Repo();
		}

		public int Insert_Brand(BrandInfo brand)
		{
            return Convert.ToInt32(sqlHelper.ExecuteScalerObj(Set_Values_In_Brand(brand), Storeprocedures.sp_Insert_Brand.ToString(), CommandType.StoredProcedure));
		}

        public void Update_Brand(BrandInfo brand)
		{
            sqlHelper.ExecuteNonQuery(Set_Values_In_Brand(brand), Storeprocedures.sp_Update_Brand.ToString(), CommandType.StoredProcedure);
		}

        public List<SqlParameter> Set_Values_In_Brand(BrandInfo brand)
		{
			List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (brand.Brand_Id != 0)
			{
                sqlParam.Add(new SqlParameter("@Brand_Id", brand.Brand_Id));
			}
			else
			{
                sqlParam.Add(new SqlParameter("@Created_Date", brand.Created_Date));

                sqlParam.Add(new SqlParameter("@Created_By", brand.Created_By));
			}

            sqlParam.Add(new SqlParameter("@Brand_Name", brand.Brand_Name));

            sqlParam.Add(new SqlParameter("@Brand_Code", brand.Brand_Code));

            //Set Is_Active Flag
            if (brand.IsActive == 0)
            {
                brand.Is_Active = false;
            }
            else
            {
                brand.Is_Active = true;
            }
            //End

            sqlParam.Add(new SqlParameter("@Is_Active", brand.Is_Active));

            sqlParam.Add(new SqlParameter("@Updated_Date", brand.Updated_Date));

            sqlParam.Add(new SqlParameter("@Updated_By", brand.Updated_By));

			return sqlParam;
		}

		public DataTable Get_Barnds(QueryInfo query_Details)
		{
			return sqlHelper.Get_Table_With_Where(query_Details);
		}
		
        //Added By Sushant 29/8/2016

        public List<BrandInfo> drp_Get_Brands()
        {
            List<BrandInfo> brands = new List<BrandInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_drp_Get_Brands.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    brands.Add(Get_Brand_Values(dr));
                }
            }
            return brands;
        }

        public BrandInfo Get_Brand_Values(DataRow dr)
        {
            BrandInfo retVal = new BrandInfo();

            retVal.Brand_Id = Convert.ToInt32(dr["Brand_Id"]);

            retVal.Brand_Name = Convert.ToString(dr["Brand_Name"]);

            return retVal;
        }
		
        public BrandInfo Get_Brand_By_Id(int Brand_Id)
        {
            BrandInfo Brand = new BrandInfo();
            //int isactive = 0;

            DataTable dt = null;
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            sqlParamList.Add(new SqlParameter("@Brand_Id", Brand_Id));

            dt = sqlHelper.ExecuteDataTable(sqlParamList, Storeprocedures.sp_Get_Brand_By_Id.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in dt.Rows)
            {
                if (!dr.IsNull("Is_Active"))
                {
                    Brand.IsActive = Convert.ToInt32(dr["Is_Active"]);  
                }                
                if (!dr.IsNull("Brand_Code"))
                {
                    Brand.Brand_Code = Convert.ToString(dr["Brand_Code"]);
                }
                //Added by Vinod Mane on 26/09/2016
                if (!dr.IsNull("Brand_Name"))
                {
                    Brand.Brand_Name = Convert.ToString(dr["Brand_Name"]);
                }
                //End
            }
            return Brand;    
        }

        public List<BrandInfo> Get_All_Barnds()
        {
            List<BrandInfo> Brands = new List<BrandInfo>();
            DataTable dt = sqlHelper.ExecuteDataTable(null, Storeprocedures.sp_Get_Brands.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {
                Brands.Add(Get_Brands_Values(dr));
            }
            return Brands;
        }

        private BrandInfo Get_Brands_Values(DataRow dr)
        {
            BrandInfo Brand = new BrandInfo();

            Brand.Brand_Id = Convert.ToInt32(dr["Brand_Id"]);

            if (!dr.IsNull("Brand_Name"))
                Brand.Brand_Name = Convert.ToString(dr["Brand_Name"]);
            return Brand;
        }

        //Added By Vinod Mane on 26/09/2016
        public bool Check_Existing_Brand_Name(string Brand_Name)
        {
            bool check = false;

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@Brand_Name", Brand_Name));

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.sp_Check_Existing_Brand_Name.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                foreach (DataRow dr in drList)
                {
                    check = Convert.ToBoolean(dr["check_brand"]);
                }
            }

            return check;
        }
        //End

	}
}
