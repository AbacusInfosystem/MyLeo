﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerInfo.Common
{
		public enum Storeprocedures
		{
            //Category
            sp_Get_Categorys,
			sp_Insert_Category,
			sp_Update_Category,
            sp_Get_Category_By_Id,

            sp_Get_Category,
            sp_drp_Get_Brands,

            //#endregion

            #region SubCategory

            //SubCategory
            sp_drp_Get_Sub_Categories,
			sp_Insert_Sub_Category,
			sp_Update_Sub_Category,
            sp_Get_Sub_Category_By_Id,

            #endregion

            #region brand

            //brand
            sp_Get_Brands,
            sp_Insert_Brand,
            sp_Update_Brand,
            sp_Get_Brand_By_Id,
            Get_Brands_By_Name_Autocomplete_Sp,
            Get_Brands_Sp,

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

            //Color
            sp_Get_Colors,
            sp_Insert_Color,
            sp_Update_Color,
            sp_Get_Colors_By_Id,
            Get_Colors_By_Name_Autocomplete_Sp,

            //#endregion

            //SizeGroup
            sp_Get_SizeGroup,
            sp_Insert_SizeGroup,
            sp_Update_Size_Group,

            //Size
            sp_Insert_Size,
            sp_Update_Size,
            sp_Get_Sizes_By_Size_Group_Id,
            Sp_Delete_Size_By_Id,
            sp_Get_SizeGroup_By_Id,

            #region Employee

            sp_Insert_Employee,
            sp_Update_Employee,
            sp_Get_Employees_By_Id,
            sp_Check_Existing_User_Name,

            #endregion

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

            #region Branch

            sp_Insert_Branch,
            sp_Update_Branch,
            sp_Get_Branch_By_Id,
            sp_Insert_Branch_Location,
            //sp_Get_Far_Branch_Location_By_Id,
            //sp_Get_Near_Branch_Location_By_Id,
            sp_Update_Branch_Location,
            sp_Get_Branch_Location_By_Id,
            sp_Delete_Branch_Location_By_Id,
            sp_Get_Employee_Branches,

            #endregion

            #region Logion

            Get_User_Data_By_Token_sp,
            Authenticate_User_sp,
            Sp_Insert_Token_In_User_Table,

            #endregion

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
                  
            #region Role

            sp_Insert_Role,
            sp_Update_Role,
            sp_Get_Role_By_Id,
            sp_Get_Role_Access_Functions,
            sp_Insert_Role_Access_Function,
            sp_Update_Role_Access_Function,
            sp_Check_Existing_Role_Name,
            sp_Get_Roles,

            #endregion


            //Product
            sp_Insert_Product_MRP,
            sp_Update_Product_MRP,
            sp_Insert_Product,
            sp_Update_Product,
            sp_Get_Sizes_On_SizeGroupId,
            sp_Insert_Vendor_Article_Mapping,
            sp_Get_Product_On_ProductId,
            sp_Get_Colours_On_ColourId,
        Get_Credit_Note_Details_By_Id_Sp,
        Get_Payable_Balance_Amount_By_Id_Sp,
        Get_Payable_Data_By_Id_Sp,
        Get_Payable_Data_Item_By_Id_Sp,
        Get_Payable_Details_By_Id_Sp,
        Insert_Payable_Data_Sp,
        sp_Insert_Payable_Item_Data,
        sp_Temp_Get_Payable_Detail_By_Id1,
		}
	
}
