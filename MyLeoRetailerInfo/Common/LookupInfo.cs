using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerInfo.Common
{
    public class LookupInfo
    {
        public static Dictionary<int, string> Get_Gender_Types()
        {
            Dictionary<int, string> Get_Gender_Types = new Dictionary<int, string>();

            Get_Gender_Types.Add(1, Gender.Male.ToString().Replace('_', ' ').ToString());

            Get_Gender_Types.Add(2, Gender.Female.ToString().Replace('_', ' ').ToString());

            Get_Gender_Types.Add(3, Gender.Transgender.ToString().Replace('_', ' ').ToString());

            return Get_Gender_Types;
        }

        public static Dictionary<int, string> Get_Employee_Designation()
        {
            Dictionary<int, string> Get_Employee_Designation = new Dictionary<int, string>();

            Get_Employee_Designation.Add(1, Designation.Owner.ToString().Replace('_', ' ').ToString());

            Get_Employee_Designation.Add(2, Designation.Partner.ToString().Replace('_', ' ').ToString());

            Get_Employee_Designation.Add(3, Designation.Branch_Manager.ToString().Replace('_', ' ').ToString());

            Get_Employee_Designation.Add(4, Designation.Sales_Person.ToString().Replace('_', ' ').ToString());

            return Get_Employee_Designation;
        }

        public static Dictionary<int, string> Get_Vendor_Types()
        {
            Dictionary<int, string> Get_Vendor_Types = new Dictionary<int, string>();

            Get_Vendor_Types.Add(1, VendorType.Manufacturer.ToString().Replace('_', ' ').ToString());

            Get_Vendor_Types.Add(2, VendorType.Agent.ToString().Replace('_', ' ').ToString());

            Get_Vendor_Types.Add(3, VendorType.Distributor.ToString().Replace('_', ' ').ToString());

            Get_Vendor_Types.Add(4, VendorType.Transporter.ToString().Replace('_', ' ').ToString());

            return Get_Vendor_Types;

        }

        public static Dictionary<int, string> Get_GiftVoucher_Payment_Mode()
        {
            Dictionary<int, string> Get_GiftVoucher_Payment_Mode = new Dictionary<int, string>();

            Get_GiftVoucher_Payment_Mode.Add(1, PaymentMode.Cash.ToString().Replace('_', ' ').ToString());

            Get_GiftVoucher_Payment_Mode.Add(2, PaymentMode.Card.ToString().Replace('_', ' ').ToString());

            return Get_GiftVoucher_Payment_Mode;

        }

    }
}
