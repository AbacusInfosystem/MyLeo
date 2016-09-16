using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyLeoRetailer.Models.Common;
using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Employee;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerInfo.Interface;
using MyLeoRetailerInfo.Role;


namespace MyLeoRetailer.Models
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel() 
		{
			Grid_Detail = new GridInfo();

			Query_Detail = new QueryInfo();

			Employee = new EmployeeInfo();

            Filter = new Filter_Employee();

            //Branches = new List<BranchInfo>();

			FriendlyMessages = new List<FriendlyMessage>();

            Grid_Detail.Pager.DivObject = "divEmployeePager";

			Grid_Detail.Pager.CallBackMethod = "Get_Employees";

            Role_List = new List<RoleInfo>();

            //Addition by swapnali | Date:15/09/2016
            //Branches = new List<MyLeoRetailerInfo.Branch.BranchInfo>();
            Employee_Branch_List = new List<EmployeeInfo>();
            //End


		}

        public GridInfo Grid_Detail
        {
            get;
            set;
        }

        public QueryInfo Query_Detail
        {
            get;
            set;
        }

        public EmployeeInfo Employee
        {
            get;
            set;
        }

        public Filter_Employee Filter
        {
            get;
            set;
        }

        public List<FriendlyMessage> FriendlyMessages
        {
            get;
            set;
        }

        public List<RoleInfo> Role_List { get; set; }

        //Addition by swapnali | Date:15/09/2016
        //public List<MyLeoRetailerInfo.Branch.BranchInfo> Branches { get; set; }
        public List<EmployeeInfo> Employee_Branch_List { get; set; }
        //End

    }

    public class Filter_Employee
    {
        public string Employee
        {
            get;
            set;
        }
    }
}