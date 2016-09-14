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

    public enum GenderType
    {
        Male,
        Female,
        Transgender,
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

    public enum PaymentMode
    {
        Cash=1,
        Card=2,
    }

    public enum PaymentStatus
    {
        Paid = 1,
        UnPaid = 2,
        Partially_Paid=3,
    }

    public enum PayablePaymentMode
    {
        Cash = 1,
        Credit_Card = 2,
        Debit_Card=3,
        Cheque=4,
        Credit_Note=5,
        Gift_Voucher=6,
    }
}
