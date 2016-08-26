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


        //Employee
        sp_Insert_Employee,
        sp_Update_Employee,
        sp_Get_Employees_By_Id,
		}
	
}
