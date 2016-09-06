using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerInfo.Vendor;
using MyLeoRetailerInfo.VendorContact;
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
  public class VendorContactRepo
    {
       SQL_Repo sqlHelper = null;

       public VendorContactRepo()
		{
			sqlHelper = new SQL_Repo();
		}

       public int Insert_Vendor_Contact(VendorContactInfo VendorContact)
       {
           return Convert.ToInt32(sqlHelper.ExecuteScalerObj(Set_Values_In_Vendor_Contact(VendorContact), Storeprocedures.sp_Insert_Vendor_Contact.ToString(), CommandType.StoredProcedure));
       }

       public void Update_Vendor_Contact(VendorContactInfo VendorContact)
       {
           sqlHelper.ExecuteNonQuery(Set_Values_In_Vendor_Contact(VendorContact), Storeprocedures.sp_Update_Vendor_Contact.ToString(), CommandType.StoredProcedure);
       }

       public List<SqlParameter> Set_Values_In_Vendor_Contact(VendorContactInfo VendorContact)
       {
           List<SqlParameter> sqlParam = new List<SqlParameter>();

           if (VendorContact.VendorContact_Id != 0)
           {
               sqlParam.Add(new SqlParameter("@VendorContact_Id", VendorContact.VendorContact_Id));
           }
           else
           {
               sqlParam.Add(new SqlParameter("@Created_Date", VendorContact.Created_Date));

               sqlParam.Add(new SqlParameter("@Created_By", VendorContact.Created_By));
           }

           VendorContact.Vendor_Contact_Name = VendorContact.First_Name + " " + VendorContact.Last_Name;

           sqlParam.Add(new SqlParameter("@Vendor_Contact_Name", VendorContact.Vendor_Contact_Name));

           sqlParam.Add(new SqlParameter("@Vendor_Id", VendorContact.Vendor_Id));

           //sqlParam.Add(new SqlParameter("@First_Name", VendorContact.First_Name));

           //sqlParam.Add(new SqlParameter("@Last_Name", VendorContact.Last_Name));

           sqlParam.Add(new SqlParameter("@Address", VendorContact.Address));

           sqlParam.Add(new SqlParameter("@City", VendorContact.City));

           sqlParam.Add(new SqlParameter("@State", VendorContact.State));

           sqlParam.Add(new SqlParameter("@Pincode", VendorContact.Pincode));

           sqlParam.Add(new SqlParameter("@Country", VendorContact.Country));

           sqlParam.Add(new SqlParameter("@Mobile1", VendorContact.Mobile1));

           sqlParam.Add(new SqlParameter("@Mobile2", VendorContact.Mobile2));

           sqlParam.Add(new SqlParameter("@Email_Id", VendorContact.Email_Id));

           //Set Is_Active Flag
           if (VendorContact.IsActive == 0)
           {
               VendorContact.Is_Active = false;
           }
           else
           {
               VendorContact.Is_Active = true;
           }
           //End

           sqlParam.Add(new SqlParameter("@Is_Active", VendorContact.Is_Active));

           sqlParam.Add(new SqlParameter("@Updated_Date", VendorContact.Updated_Date));

           sqlParam.Add(new SqlParameter("@Updated_By", VendorContact.Updated_By));


           return sqlParam;
       }

       public DataTable Get_Vendor_Contacts(QueryInfo query_Details)
       {
           return sqlHelper.Get_Table_With_Where(query_Details);
       }

       public VendorContactInfo Get_Vendor_Contact_By_Id(int VendorContact_Id)
       {
           List<SqlParameter> parameters = new List<SqlParameter>();
           parameters.Add(new SqlParameter("@VendorContact_Id", VendorContact_Id));

           VendorContactInfo vcInfo = new VendorContactInfo();
           DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Vendor_Contact_By_Id.ToString(), CommandType.StoredProcedure);
           List<DataRow> drList = new List<DataRow>();
           drList = dt.AsEnumerable().ToList();
           foreach (DataRow dr in drList)
           {
               vcInfo = Get_Vendor_Contact_Values(dr);
           }
           return vcInfo;
       }

       private VendorContactInfo Get_Vendor_Contact_Values(DataRow dr)
       {
           VendorContactInfo VendorContact = new VendorContactInfo();

           VendorContact.VendorContact_Id = Convert.ToInt32(dr["VendorContact_Id"]);

           if (!dr.IsNull("Vendor_Contact_Name"))
           {
               VendorContact.Vendor_Contact_Name = Convert.ToString(dr["Vendor_Contact_Name"]);
               VendorContact.Vendor_Id = Convert.ToInt32(dr["Vendor_Id"]);
               VendorContact.Address = Convert.ToString(dr["Address"]);
               VendorContact.City = Convert.ToString(dr["City"]);
               VendorContact.State = Convert.ToString(dr["State"]);
               VendorContact.Country = Convert.ToString(dr["Country"]);
               VendorContact.Pincode = Convert.ToInt32(dr["Pincode"]);
               VendorContact.Mobile1 = Convert.ToString(dr["Mobile1"]);
               VendorContact.Mobile2 = Convert.ToString(dr["Mobile2"]);
               VendorContact.Email_Id = Convert.ToString(dr["Email_Id"]);
               VendorContact.Created_Date = Convert.ToDateTime(dr["Created_Date"]);
               VendorContact.Created_By = Convert.ToInt32(dr["Created_By"]);
               VendorContact.Updated_Date = Convert.ToDateTime(dr["Updated_Date"]);
               VendorContact.Updated_By = Convert.ToInt32(dr["Updated_By"]);
               VendorContact.Is_Active = Convert.ToBoolean(dr["Is_Active"]);

               //Set IsActive Flag
               if (VendorContact.Is_Active == false)
               {
                   VendorContact.IsActive = 0;
               }
               else
               {
                   VendorContact.IsActive = 1;
               }
               //End

               //Split Customer_Name
               string[] nameParts = VendorContact.Vendor_Contact_Name.Split(' ');

               VendorContact.First_Name = nameParts[0];
               VendorContact.Last_Name = nameParts[1];
               //End
           }

           return VendorContact;
       }

       

       
       

    }
}
