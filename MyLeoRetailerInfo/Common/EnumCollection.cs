using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerInfo.Common
{
    public class EnumCollection
    {


    }

    public enum VendorType
    {
        Manufacturer = 1,
        Agent = 2,
        Distributor = 3,
        Transporter = 4,
    }

    public enum Actions
    {
        Access = 1,
        Create = 2,
        Edit = 3,
        View = 4,

    }

    public enum AppFunction
    {
        //AppFunction is AccessFunctionName_Action

        Role_Management_Access,
        Role_Management_Create,
        Role_Management_Edit,
        Role_Management_View,

        Employee_Management_Access,
        Employee_Management_Create,
        Employee_Management_Edit,
        Employee_Management_View,

        Category_Management_Access,
        Category_Management_Create,
        Category_Management_Edit,
        Category_Management_View,

        Color_Management_Access,
        Color_Management_Create,
        Color_Management_Edit,
        Color_Management_View,

        Size_Management_Access,
        Size_Management_Create,
        Size_Management_Edit,
        Size_Management_View,

        Tax_Management_Access,
        Tax_Management_Create,
        Tax_Management_Edit,
        Tax_Management_View,

        Brand_Management_Access,
        Brand_Management_Create,
        Brand_Management_Edit,
        Brand_Management_View,

        Customer_Management_Access,
        Customer_Management_Create,
        Customer_Management_Edit,
        Customer_Management_View,

        Vendor_Management_Access,
        Vendor_Management_Create,
        Vendor_Management_Edit,
        Vendor_Management_View,

        Product_Management_Access,
        Product_Management_Create,
        Product_Management_Edit,
        Product_Management_View,

        Branch_Management_Access,
        Branch_Management_Create,
        Branch_Management_Edit,
        Branch_Management_View,

        Product_Dispatch_Management_Access,
        Product_Dispatch_Management_Create,
        Product_Dispatch_Management_Edit,
        Product_Dispatch_Management_View,
        Product_Inward_Management_Access,
        Product_Inward_Management_Edit,

        Purchase_Order_Management_Access,
        Purchase_Order_Management_Create,
        Purchase_Order_Management_Edit,
        Purchase_Order_Management_View,

        Purchase_Order_Request_Management_Access,
        Purchase_Order_Request_Management_Create,
        Purchase_Order_Request_Management_Edit,
        Purchase_Order_Request_Management_View,

        Purchase_Return_Management_Access,
        Purchase_Return_Management_Create,
        Purchase_Return_Management_Edit,
        Purchase_Return_Management_View,

        Purchase_Return_Request_Management_Access,
        Purchase_Return_Request_Management_Create,
        Purchase_Return_Request_Management_Edit,
        Purchase_Return_Request_Management_View,

        Sales_Order_Management_Access,
        Sales_Order_Management_Create,
        Sales_Order_Management_Edit,
        Sales_Order_Management_View,

        Sales_Return_Management_Access,
        Sales_Return_Management_Create,
        Sales_Return_Management_Edit,
        Sales_Return_Management_View, 

        Gift_Voucher_Management_Access,
        Gift_Voucher_Management_Create,
        Gift_Voucher_Management_Edit,
        Gift_Voucher_Management_View, 

        Alteration_Management_Access,
        Alteration_Management_Create,
        Alteration_Management_Edit,
        Alteration_Management_View,

        Payable_Management_Access,
        Payable_Management_Create,
        Payable_Management_Edit,
        Payable_Management_View,

        Receivable_Management_Access,
        Receivable_Management_Create,
        Receivable_Management_Edit,
        Receivable_Management_View,
    }


}
