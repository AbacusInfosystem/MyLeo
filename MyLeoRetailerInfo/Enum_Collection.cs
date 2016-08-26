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

    public enum Gender
    {
        Male = 1,
        Female = 2,
        Transgender = 3, 
    }

    public enum Designation
    {
        Owner = 1,
        Partner = 2,
        Branch_Manager = 3,
        Sales_Person = 4,
    }
}
