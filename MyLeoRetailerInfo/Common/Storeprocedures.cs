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

            sp_Insert_Tax,
            sp_Update_Tax,
            sp_Get_Tax_By_Id,
		}
	
}
