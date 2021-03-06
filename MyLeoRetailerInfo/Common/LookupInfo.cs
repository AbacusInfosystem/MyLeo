﻿using System;
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

        public static Dictionary<int, string> Get_Actions()
        {
            Dictionary<int, string> get_Actions = new Dictionary<int, string>();

            get_Actions.Add(1, Actions.Access.ToString().ToString());

            get_Actions.Add(2, Actions.Create.ToString().ToString());

            get_Actions.Add(3, Actions.Edit.ToString().ToString());

            get_Actions.Add(4, Actions.View.ToString().ToString());

            return get_Actions;

        }

        public static Dictionary<int, string> Get_Payable_Payment_Mode()
        {
            Dictionary<int, string> Get_Payable_Payment_Mode = new Dictionary<int, string>();

            Get_Payable_Payment_Mode.Add(1, PayablePaymentMode.Cash.ToString().Replace('_', ' ').ToString());

            Get_Payable_Payment_Mode.Add(2, PayablePaymentMode.Credit_Card.ToString().Replace('_', ' ').ToString());

            Get_Payable_Payment_Mode.Add(3, PayablePaymentMode.Debit_Card.ToString().Replace('_', ' ').ToString());

            Get_Payable_Payment_Mode.Add(4, PayablePaymentMode.Cheque.ToString().Replace('_', ' ').ToString());

            //Get_Payable_Payment_Mode.Add(5, PayablePaymentMode.Credit_Note.ToString().Replace('_', ' ').ToString());

            //Get_Payable_Payment_Mode.Add(6, PayablePaymentMode.Gift_Voucher.ToString().Replace('_', ' ').ToString());

            return Get_Payable_Payment_Mode;

        }

        public static Dictionary<int, string> Get_Payment_Status()
        {
            Dictionary<int, string> Get_Payment_Status = new Dictionary<int, string>();

            Get_Payment_Status.Add(1, PaymentStatus.Paid.ToString().ToString());

            Get_Payment_Status.Add(2, PaymentStatus.UnPaid.ToString().ToString());

            Get_Payment_Status.Add(3, PaymentStatus.PartiallyPaid.ToString().ToString());

            return Get_Payment_Status;

        }

        public static Dictionary<int, string> Get_Receivable_Status()
        {
            Dictionary<int, string> Get_Receivable_Status = new Dictionary<int, string>();

            Get_Receivable_Status.Add(1, ReceivableStatus.Paid.ToString().ToString());

            Get_Receivable_Status.Add(2, ReceivableStatus.UnPaid.ToString().ToString());

            Get_Receivable_Status.Add(3, ReceivableStatus.PartiallyPaid.ToString().ToString());

            return Get_Receivable_Status;

        }
    }
}
