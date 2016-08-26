using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerInfo.Common
{
	

		public enum Storeprocedures
		{
			sp_Insert_Category,
			sp_Update_Category,

			sp_Insert_Sub_Category,
			sp_Update_Sub_Category,

            //SizeGroup

            sp_Insert_SizeGroup,
            sp_Update_Size_Group,

            //Size

            sp_Insert_Size,
            sp_Update_Size,
            sp_Get_Sizes_By_Size_Group_Id,
            Sp_Delete_Size_By_Id,

		}
	
}
