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

            //Brand
            sp_Insert_Brand,
            sp_Update_Brand,

            //Customer
            sp_Insert_Customer,
            sp_Update_Customer,
            sp_Get_Customer_By_Id,
            sp_Get_Customer_By_Mobile,
		}
	
}
