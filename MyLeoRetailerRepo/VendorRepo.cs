using MyLeoRetailerInfo.Vendor;
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
using MyLeoRetailerInfo.PurchaseReturn;
using MyLeoRetailerInfo.PurchaseInvoice;

namespace MyLeoRetailerRepo
{
    public class VendorRepo
    {

        SQL_Repo sqlHelper = null;

        public VendorRepo()
        {
            sqlHelper = new SQL_Repo();
        }

        public int Insert_Vendor(VendorInfo vendor)
        {

            vendor.Vendor_Id = Convert.ToInt32(sqlHelper.ExecuteScalerObj(Set_Values_In_Vendor(vendor), Storeprocedures.sp_Insert_Vendor.ToString(), CommandType.StoredProcedure));

            Insert_Vendor_Bank_Details(vendor);

            Insert_Vendor_Brand_Mapping(vendor);

            Insert_Vendor_Category_Mapping(vendor);

            Insert_Vendor_SubCategory_Mapping(vendor);

            return vendor.Vendor_Id;

        }


        public void Update_Vendor(VendorInfo vendor)
        {

            List<SqlParameter> SqlParams = new List<SqlParameter>();

            SqlParams.Add(new SqlParameter("@Vendor_Id", vendor.Vendor_Id));

            sqlHelper.ExecuteNonQuery(Set_Values_In_Vendor(vendor), Storeprocedures.sp_Update_Vendor.ToString(), CommandType.StoredProcedure);

            //Bank Details

            sqlHelper.ExecuteNonQuery(SqlParams, Storeprocedures.sp_Delete_Vendor_Bank_Details_By_Vendor_Id.ToString(), CommandType.StoredProcedure);

            Insert_Vendor_Bank_Details(vendor);

            //Brand Details

            List<SqlParameter> Sqlparams = new List<SqlParameter>();

            Sqlparams.Add(new SqlParameter("@Vendor_Id", vendor.Vendor_Id));

            sqlHelper.ExecuteNonQuery(Sqlparams, Storeprocedures.sp_Delete_Vendor_Brand_Mapping_By_Vendor_Id.ToString(), CommandType.StoredProcedure);

            Insert_Vendor_Brand_Mapping(vendor);

            //Category Details

            List<SqlParameter> Sqlparamater = new List<SqlParameter>();

            Sqlparamater.Add(new SqlParameter("@Vendor_Id", vendor.Vendor_Id));

            sqlHelper.ExecuteNonQuery(Sqlparamater, Storeprocedures.sp_Delete_Vendor_Category_Mapping_By_Vendor_Id.ToString(), CommandType.StoredProcedure);

            Insert_Vendor_Category_Mapping(vendor);



            //SubCategory Details

            List<SqlParameter> Sqlparamaters = new List<SqlParameter>();

            Sqlparamaters.Add(new SqlParameter("@Vendor_Id", vendor.Vendor_Id));

            sqlHelper.ExecuteNonQuery(Sqlparamaters, Storeprocedures.sp_Delete_Vendor_SubCategory_Mapping_By_Vendor_Id.ToString(), CommandType.StoredProcedure);

            Insert_Vendor_SubCategory_Mapping(vendor);

        }

        public DataTable Get_Vendors(QueryInfo query_Details)
        {
            return sqlHelper.Get_Table_With_Where(query_Details);
        }

        private List<SqlParameter> Set_Values_In_Vendor(VendorInfo vendor)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();
            if(vendor.Vendor_Id !=0)
            {
            sqlParams.Add(new SqlParameter("@Vendor_ID", vendor.Vendor_Id));
            }
            sqlParams.Add(new SqlParameter("@Vendor_Name", vendor.Vendor_Name));
            sqlParams.Add(new SqlParameter("@Vendor_Address", vendor.Vendor_Address));
            sqlParams.Add(new SqlParameter("@Vendor_City", vendor.Vendor_City));
            sqlParams.Add(new SqlParameter("@Vendor_State", vendor.Vendor_State));
            sqlParams.Add(new SqlParameter("@Vendor_Country", vendor.Vendor_Country));
            sqlParams.Add(new SqlParameter("@Vendor_Pincode", vendor.Vendor_Pincode));
            sqlParams.Add(new SqlParameter("@Vendor_Phone1", vendor.Vendor_Phone1));
            sqlParams.Add(new SqlParameter("@Vendor_Phone2", vendor.Vendor_Phone2));
            sqlParams.Add(new SqlParameter("@Vendor_Email1", vendor.Vendor_Email1));
            sqlParams.Add(new SqlParameter("@Vendor_Email2", vendor.Vendor_Email2));

            if (!string.IsNullOrEmpty(vendor.Vendor_Product))
            {
                sqlParams.Add(new SqlParameter("@Vendor_Product", vendor.Vendor_Product));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Vendor_Product", DBNull.Value));
            }

            if (vendor.Vendor_PaymentTerms != 0)
            {
                sqlParams.Add(new SqlParameter("@Vendor_PaymentTerms", vendor.Vendor_PaymentTerms));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Vendor_PaymentTerms", 0));
            }

            sqlParams.Add(new SqlParameter("@Vendor_Vat_Rate", vendor.Vendor_Vat_Rate));
            sqlParams.Add(new SqlParameter("@Vendor_Vat_No", vendor.Vendor_Vat_No));
            sqlParams.Add(new SqlParameter("@Vat_Effective_Date", vendor.Vendor_Vat_Effective_Date));
            sqlParams.Add(new SqlParameter("@CST_Rate", vendor.Vendor_CST_Rate));
            sqlParams.Add(new SqlParameter("@CST_No", vendor.Vendor_CST_No));
            sqlParams.Add(new SqlParameter("@CST_Effective_Date", vendor.Vendor_CST_Effective_Date));
            sqlParams.Add(new SqlParameter("@Vendor_Type", vendor.Vendor_Type));

            //sqlParams.Add(new SqlParameter("@Brand_Id", vendor.Brand_Id));
            //sqlParams.Add(new SqlParameter("@Category_Id", vendor.Category_Id));
            //sqlParams.Add(new SqlParameter("@Sub_Category_Id", vendor.SubCategory_Id));

            //Set Is_Active Flag

            if (vendor.IsActive == 0)
            {
                vendor.Is_Active = false;
            }
            else
            {
                vendor.Is_Active = true;
            }

            //End

            sqlParams.Add(new SqlParameter("@Is_Active", vendor.Is_Active));

            if (vendor.Vendor_Id == 0)
            {
                sqlParams.Add(new SqlParameter("@Created_By", vendor.Created_By));
                sqlParams.Add(new SqlParameter("@Created_Date", vendor.Created_Date));
            }
            sqlParams.Add(new SqlParameter("@Updated_By", vendor.Updated_By));
            sqlParams.Add(new SqlParameter("@Updated_Date", vendor.Updated_Date));

            return sqlParams;
        }

        public void Insert_Vendor_Bank_Details(VendorInfo vendor)
        {
            foreach (var item in vendor.BankDetailsList)
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();

                sqlParams.Add(new SqlParameter("@Vendor_Id", vendor.Vendor_Id));
                sqlParams.Add(new SqlParameter("@Bank_Name", item.Bank_Name));
                sqlParams.Add(new SqlParameter("@Account_No", item.Account_No));
                sqlParams.Add(new SqlParameter("@Branch_Name", item.Branch_Name));
                sqlParams.Add(new SqlParameter("@Ifsc_Code", item.Ifsc_Code));
                sqlParams.Add(new SqlParameter("@Is_Active", item.Status));

                sqlParams.Add(new SqlParameter("@Created_By", vendor.Created_By));
                sqlParams.Add(new SqlParameter("@Created_Date", vendor.Created_Date));
                sqlParams.Add(new SqlParameter("@Updated_By", vendor.Updated_By));
                sqlParams.Add(new SqlParameter("@Updated_Date", vendor.Updated_Date));

                sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Insert_Vendor_Bank_Details.ToString(), CommandType.StoredProcedure);
            }
        }

        public void Insert_Vendor_Brand_Mapping(VendorInfo vendor)
        {
            foreach (var item in vendor.BrandDetailsList)
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();

                sqlParams.Add(new SqlParameter("@Vendor_Id", vendor.Vendor_Id));
                sqlParams.Add(new SqlParameter("@Brand_Id", item.Brand_Detail_Id));

                sqlParams.Add(new SqlParameter("@Created_By", vendor.Created_By));
                sqlParams.Add(new SqlParameter("@Created_Date", vendor.Created_Date));
                sqlParams.Add(new SqlParameter("@Updated_By", vendor.Updated_By));
                sqlParams.Add(new SqlParameter("@Updated_Date", vendor.Updated_Date));

                sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Insert_Vendor_Brand_Mapping.ToString(), CommandType.StoredProcedure);
            }
        }

        public void Insert_Vendor_Category_Mapping(VendorInfo vendor)
        {
            foreach (var item in vendor.CategoryDetailsList)
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();

                sqlParams.Add(new SqlParameter("@Vendor_Id", vendor.Vendor_Id));
                sqlParams.Add(new SqlParameter("@Category_Id", item.Category_Detail_Id));

                sqlParams.Add(new SqlParameter("@Created_By", vendor.Created_By));
                sqlParams.Add(new SqlParameter("@Created_Date", vendor.Created_Date));
                sqlParams.Add(new SqlParameter("@Updated_By", vendor.Updated_By));
                sqlParams.Add(new SqlParameter("@Updated_Date", vendor.Updated_Date));

                sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Insert_Vendor_Category_Mapping.ToString(), CommandType.StoredProcedure);
            }
        }

        public void Insert_Vendor_SubCategory_Mapping(VendorInfo vendor)
        {
            foreach (var item in vendor.SubCategoryDetailsList)
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();

                sqlParams.Add(new SqlParameter("@Vendor_Id", vendor.Vendor_Id));
                sqlParams.Add(new SqlParameter("@SubCategory_Id", item.SubCategory_Id));

                sqlParams.Add(new SqlParameter("@Created_By", vendor.Created_By));
                sqlParams.Add(new SqlParameter("@Created_Date", vendor.Created_Date));
                sqlParams.Add(new SqlParameter("@Updated_By", vendor.Updated_By));
                sqlParams.Add(new SqlParameter("@Updated_Date", vendor.Updated_Date));

                sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Insert_Vendor_SubCategory_Mapping.ToString(), CommandType.StoredProcedure);
            }
        }

        public VendorInfo Get_Vendor_By_Id(int vendor_Id)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Vendor_Id", vendor_Id));

            VendorInfo Vendor = new VendorInfo();

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_Get_Vendor_By_Id.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {

                foreach (DataRow dr in dt.Rows)
                {
                    Vendor = Get_Vendor_Values(dr);
                }
            }

            return Vendor;
        }

        private VendorInfo Get_Vendor_Values(DataRow dr)
        {
            VendorInfo Vendor = new VendorInfo();

            Vendor.Vendor_Id = Convert.ToInt32(dr["Vendor_Id"]);
            Vendor.Vendor_Name = Convert.ToString(dr["Vendor_Name"]);
            Vendor.Vendor_Address = Convert.ToString(dr["Vendor_Address"]);
            Vendor.Vendor_City = Convert.ToString(dr["Vendor_City"]);
            Vendor.Vendor_State = Convert.ToString(dr["Vendor_State"]);
            Vendor.Vendor_Country = Convert.ToString(dr["Vendor_Country"]);
            Vendor.Vendor_Pincode = Convert.ToInt32(dr["Vendor_Pincode"]);
            Vendor.Vendor_Phone1 = Convert.ToString(dr["Vendor_Phone1"]);
            Vendor.Vendor_Phone2 = Convert.ToString(dr["Vendor_Phone2"]);
            Vendor.Vendor_Email1 = Convert.ToString(dr["Vendor_Email1"]);
            Vendor.Vendor_Email2 = Convert.ToString(dr["Vendor_Email2"]);
            Vendor.Vendor_Email1 = Convert.ToString(dr["Vendor_Email1"]);

            if (!string.IsNullOrEmpty(Vendor.Vendor_Product))
            {
                Vendor.Vendor_Product = Convert.ToString(dr["Vendor_Product"]);
            }
            if (Vendor.Vendor_PaymentTerms != 0)
            {
                Vendor.Vendor_PaymentTerms = Convert.ToInt32(dr["Vendor_PaymentTerms"]);
            }
            Vendor.Vendor_Vat_Rate = Convert.ToString(dr["Vendor_Vat_Rate"]);
            Vendor.Vendor_Vat_No = Convert.ToString(dr["Vendor_Vat_No"]);
            Vendor.Vendor_Vat_Effective_Date = Convert.ToDateTime(dr["Vat_Effective_Date"]);
            Vendor.Vendor_CST_Rate = Convert.ToString(dr["CST_Rate"]);
            Vendor.Vendor_CST_No = Convert.ToString(dr["CST_No"]);
            Vendor.Vendor_CST_Effective_Date = Convert.ToDateTime(dr["CST_Effective_Date"]);
            Vendor.Vendor_Type = Convert.ToInt32(dr["Vendor_Type"]);

            //Vendor.IsActive = Convert.ToInt32(dr["Is_Active"]);
            //Vendor.Is_Active = Convert.ToBoolean(dr["Is_Active"]);

            Vendor.Created_By = Convert.ToInt32(dr["Created_By"]);
            Vendor.Created_Date = Convert.ToDateTime(dr["Created_Date"]);
            Vendor.Updated_By = Convert.ToInt32(dr["Updated_By"]);
            Vendor.Updated_Date = Convert.ToDateTime(dr["Updated_Date"]);

            return Vendor;
        }

        public List<Bank_Details> Get_Vendor_Bank_Details(int vendor_Id)
        {
            List<Bank_Details> bankdetailslist = new List<Bank_Details>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Vendor_Id", vendor_Id));

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_Get_Vendor_Bank_Details_By_Id.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Bank_Details list = new Bank_Details();

                    if (!dr.IsNull("Bank_Name"))
                        list.Bank_Name = Convert.ToString(dr["Bank_Name"]);
                    if (!dr.IsNull("Account_No"))
                        list.Account_No = Convert.ToString(dr["Account_No"]);
                    if (!dr.IsNull("Branch_Name"))
                        list.Branch_Name = Convert.ToString(dr["Branch_Name"]);
                    if (!dr.IsNull("IFSC_Code"))
                        list.Ifsc_Code = Convert.ToString(dr["IFSC_Code"]);
                    if (!dr.IsNull("Is_Active"))
                        list.Status = Convert.ToBoolean(dr["Is_Active"]);

                    bankdetailslist.Add(list);
                }
            }

            return bankdetailslist;
        }

        public List<Brand_Details> Get_Vendor_Brand_Details(int vendor_Id)
        {
            List<Brand_Details> branddetailslist = new List<Brand_Details>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Vendor_Id", vendor_Id));

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_Get_Vendor_Brand_Mapping_By_Id.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {

                    Brand_Details list = new Brand_Details();

                    if (!dr.IsNull("Brand_Id"))
                        list.Brand_Detail_Id = Convert.ToInt32(dr["Brand_Id"]);
                    if (!dr.IsNull("Brand_Name"))
                        list.Brand = Convert.ToString(dr["Brand_Name"]);
                  
                    branddetailslist.Add(list);
                }
            }

            return branddetailslist;
        }

        public List<Category_Details> Get_Vendor_Category_Details(int vendor_Id)
        {
            List<Category_Details> categorydetailslist = new List<Category_Details>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Vendor_Id", vendor_Id));

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_Get_Vendor_Category_Mapping_By_Id.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {

                    Category_Details list = new Category_Details();

                    if (!dr.IsNull("Category_Id"))
                        list.Category_Detail_Id = Convert.ToInt32(dr["Category_Id"]);
                    if (!dr.IsNull("Category"))
                        list.Category = Convert.ToString(dr["Category"]);
                    

                    categorydetailslist.Add(list);
                }
            }

            return categorydetailslist;
        }

        public List<SubCategory_Details> Get_Vendor_SubCategory_Details(int vendor_Id)
        {
            List<SubCategory_Details> subcategorydetailslist = new List<SubCategory_Details>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Vendor_Id", vendor_Id));

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_Get_Vendor_SubCategory_Mapping_By_Id.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {

                    SubCategory_Details list = new SubCategory_Details();

                    if (!dr.IsNull("SubCategory_Id"))
                        list.SubCategory_Id = Convert.ToInt32(dr["SubCategory_Id"]);
                    if (!dr.IsNull("Sub_Category"))
                        list.SubCategory = Convert.ToString(dr["Sub_Category"]);
                    

                    subcategorydetailslist.Add(list);
                }
            }

            return subcategorydetailslist;
        }

        //public List<VendorInfo> Get_Vendors()
        //{
        //    List<VendorInfo> Vendors = new List<VendorInfo>();
        //    DataTable dt = sqlHelper.ExecuteDataTable(null, Storeprocedures.Get_Vendor_Sp.ToString(), CommandType.StoredProcedure);
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        Vendors.Add(Get_Vendor_Values(dr));
        //    }
        //    return Vendors;
        //}

        //Gauravi 7-9-2016
        public List<VendorInfo> Get_Vendors()
        {
            List<VendorInfo> Vendors = new List<VendorInfo>();
            DataTable dt = sqlHelper.ExecuteDataTable(null, Storeprocedures.sp_Get_Vendor.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in dt.Rows)
            {
                VendorInfo Vendor = new VendorInfo();

                Vendor.Vendor_Id = Convert.ToInt32(dr["Vendor_Id"]);

                Vendor.Vendor_Name = Convert.ToString(dr["Vendor_Name"]);

                Vendors.Add(Vendor);
            }
            return Vendors;
        }

        public List<VendorInfo> Get_Agents()
        {
            List<VendorInfo> Vendors = new List<VendorInfo>();
            DataTable dt = sqlHelper.ExecuteDataTable(null, Storeprocedures.sp_Get_Agent.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in dt.Rows)
            {
                VendorInfo Agent = new VendorInfo();

                Agent.Vendor_Id = Convert.ToInt32(dr["Vendor_Id"]);

                Agent.Vendor_Name = Convert.ToString(dr["Vendor_Name"]);

                Vendors.Add(Agent);
            }
            return Vendors;
        }

        public List<VendorInfo> Get_Transporters()
        {
            List<VendorInfo> Vendors = new List<VendorInfo>();
            DataTable dt = sqlHelper.ExecuteDataTable(null, Storeprocedures.sp_Get_Transporter.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in dt.Rows)
            {
                VendorInfo Transpoter = new VendorInfo();

                Transpoter.Vendor_Id = Convert.ToInt32(dr["Vendor_Id"]);

                Transpoter.Vendor_Name = Convert.ToString(dr["Vendor_Name"]);

                Vendors.Add(Transpoter);
            }
            return Vendors;
        }

        //End

        //Gauravi 17-9-2016

        public PurchaseInvoiceInfo Get_Vendor_Detalis_By_Id(int vendor_Id)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Vendor_ID", vendor_Id));

            PurchaseInvoiceInfo Vendor = new PurchaseInvoiceInfo();

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_Get_Vendor_Details_By_Id.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {

                foreach (DataRow dr in dt.Rows)
                {
                    Vendor.Vendor_Id = Convert.ToInt32(dr["Vendor_ID"]);

                    Vendor.Vendor_Address = Convert.ToString(dr["Vendor_Address"]);
                   
                    Vendor.Vendor_Vat_No = Convert.ToString(dr["Vendor_Vat_No"]);

                    Vendor.Tax_Percentage = Convert.ToDecimal(dr["Vendor_Vat_Rate"]);
                }
            }

            return Vendor;
        }

        public PurchaseReturnInfo Get_Vendor_Details_By_Id(int vendor_Id)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Vendor_ID", vendor_Id));

            PurchaseReturnInfo Vendor = new PurchaseReturnInfo();

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_Get_Vendor_Details_By_Id.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {

                foreach (DataRow dr in dt.Rows)
                {
                    Vendor.Vendor_Id = Convert.ToInt32(dr["Vendor_ID"]);

                    Vendor.Tax_Percentage = Convert.ToDecimal(dr["Vendor_Vat_Rate"]);
                }
            }

            return Vendor;
        }

        //End


    }
}
