using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerInfo.Common
{
	

		public enum Storeprocedures
		{
            //Category
			sp_Insert_Category,
			sp_Update_Category,

            //SubCategory
			sp_Insert_Sub_Category,
			sp_Update_Sub_Category,

            //brand
            sp_Insert_Brand,
            sp_Update_Brand,

            //tax
            sp_Insert_Tax,
            sp_Update_Tax,
            sp_Get_Tax_By_Id,

            //Vendor Contact
            sp_Insert_Vendor_Contact,
            sp_Update_Vendor_Contact,
            sp_Get_Vendor_Contact_By_Id,
            Get_Vendor_Sp,
            Get_Vendor_By_Id_Sp,
            //Customer
            sp_Insert_Customer,
            sp_Update_Customer,
            sp_Get_Customer_By_Id,
            sp_Get_Customer_By_Mobile,
		}
	
}
