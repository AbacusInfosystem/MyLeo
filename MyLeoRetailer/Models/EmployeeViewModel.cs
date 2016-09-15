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
using MyLeoRetailerInfo.Branch;


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

            Branch = new BranchInfo();

            List_Branch = new List<BranchInfo>();

            Map_Branches = new List<BranchInfo>();

			FriendlyMessages = new List<FriendlyMessage>();

            Grid_Detail.Pager.DivObject = "divEmployeePager";

			Grid_Detail.Pager.CallBackMethod = "Get_Employees";

            Role_List = new List<RoleInfo>();
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

        public BranchInfo Branch
        {
            get;
            set;
        }

        public List<BranchInfo> List_Branch
        {
            get;
            set;
        }

        public List<BranchInfo> Map_Branches
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