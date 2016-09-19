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


    }

}
