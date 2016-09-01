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

            //brand
            sp_drp_Get_Brands,
            sp_Insert_Brand,
            sp_Update_Brand,

            //tax
            sp_Insert_Tax,
            sp_Update_Tax,
            sp_Get_Tax_By_Id,
            sp_drp_Get_VAT,
            sp_drp_Get_CST,

            //Vendor Contact
            sp_Insert_Vendor_Contact,
            sp_Update_Vendor_Contact,

            //Color
            sp_Insert_Color,
            sp_Update_Color,
            sp_Get_Colors_By_Id,

            //SizeGroup

            sp_Insert_SizeGroup,
            sp_Update_Size_Group,

            //Size

            sp_Insert_Size,
            sp_Update_Size,
            sp_Get_Sizes_By_Size_Group_Id,
            Sp_Delete_Size_By_Id,

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
