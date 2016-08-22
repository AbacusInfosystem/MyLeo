using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerInfo
{
    public enum DataTypes
    {
        Int,
        String,
        DateTime,
        Boolean,
    }

    public enum StoredProdures
    {
        ABC_sp,
        EFG_sp,
    }

	public enum MessageType
	{
		Information = 1,
		Error = 2,
		Success = 3,
		Warning = 4,
	}
}
