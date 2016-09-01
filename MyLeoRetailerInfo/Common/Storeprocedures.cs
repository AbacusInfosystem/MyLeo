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
            sp_Get_Category,
			sp_Insert_Category,
			sp_Update_Category,

            //SubCategory
            sp_drp_Get_Sub_Categories,
			sp_Insert_Sub_Category,
			sp_Update_Sub_Category,

            #region brand

            //brand
            sp_drp_Get_Brands,
            sp_Insert_Brand,
            sp_Update_Brand,
            sp_Get_Brand_By_Id,
            Get_Brands_By_Name_Autocomplete_Sp,

            #endregion

            //tax
            sp_Insert_Tax,
            sp_Update_Tax,
            sp_Get_Tax_By_Id,
            sp_drp_Get_VAT,
            sp_drp_Get_CST,

            //Vendor Contact
            sp_Insert_Vendor_Contact,
            sp_Update_Vendor_Contact,
            sp_Get_Vendor_Contact_By_Id,
            Get_Vendor_Sp,
            Get_Vendor_By_Id_Sp,

            #region Color

            Get_Colors_Sp,
            sp_Insert_Color,
            sp_Update_Color,
            sp_Get_Colors_By_Id,
            Get_Colors_By_Name_Autocomplete_Sp,

            #endregion

            //SizeGroup
            Get_SizeGroup_Sp,
            sp_Insert_SizeGroup,
            sp_Update_Size_Group,

            //Size

            sp_Insert_Size,
            sp_Update_Size,
            sp_Get_Sizes_By_Size_Group_Id,
            Sp_Delete_Size_By_Id,

            //Employee
            sp_Insert_Employee,
            sp_Update_Employee,
            sp_Get_Employees_By_Id,

            //Customer
            sp_Insert_Customer,
            sp_Update_Customer,
            sp_Get_Customer_By_Id,
            sp_Get_Customer_By_Mobile,
            Get_Employee_Sp,

            //GiftVoucher
            sp_Insert_Gift_Voucher,
            sp_Update_Gift_Voucher,
            sp_Get_Gift_Voucher_By_Id,

            //Branch
            sp_Insert_Branch,
            sp_Update_Branch,
            sp_Get_Branch_By_Id,
            sp_Insert_Branch_Location,
            sp_Get_Far_Branch_Location_By_Id,
            sp_Get_Near_Branch_Location_By_Id,
            sp_Update_Branch_Location,

            //Login
            Get_User_Data_By_Token_sp,
            Authenticate_User_sp,
            Insert_Token_In_User_Table_Sp,

            //Alteration
            sp_Insert_Alteration,
            sp_Update_Alteration,
            sp_Get_Alteration_By_Id,

            //SalesInvoice
            Get_SalesInvoice_Sp,

           
            //Vendor

            sp_Insert_Vendor,
            sp_Update_Vendor,
            sp_Get_Vendor_By_Id,
            sp_Insert_Vendor_Bank_Details,
            sp_Update_Vendor_Bank_Details,
            sp_Delete_Vendor_Bank_Details_By_Vendor_Id,
            sp_Get_Vendor_Bank_Details_By_Id,
            sp_Insert_Vendor_Brand_Mapping,
            sp_Update_Vendor_Brand_Mapping,
            sp_Delete_Vendor_Brand_Mapping_By_Vendor_Id,
            sp_Get_Vendor_Brand_Mapping_By_Id,
            sp_Insert_Vendor_Category_Mapping,
            sp_Update_Vendor_Category_Mapping,
            sp_Delete_Vendor_Category_Mapping_By_Vendor_Id,
            sp_Get_Vendor_Category_Mapping_By_Id,
            sp_Insert_Vendor_SubCategory_Mapping,
            sp_Update_Vendor_SubCategory_Mapping,
            sp_Delete_Vendor_SubCategory_Mapping_By_Vendor_Id,
            sp_Get_Vendor_SubCategory_Mapping_By_Id,
           

		}
	
}
