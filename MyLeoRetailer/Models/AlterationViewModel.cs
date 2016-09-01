using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Alteration;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerInfo.Employee;
using MyLeoRetailerInfo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLeoRetailer.Models
{
    public class AlterationViewModel : IGridInfo, IQueryInfo
    {
        public AlterationViewModel()
        {
            Grid_Detail = new GridInfo();

            Query_Detail = new QueryInfo();

            Alteration = new AlterationInfo();

            Employee = new EmployeeInfo();

            Employees = new List<EmployeeInfo>();

            SalesInvoice = new SalesInvoiceInfo();

            SalesInvoices = new List<SalesInvoiceInfo>();

            Filter = new Filter_Alteration();

            FriendlyMessages = new List<FriendlyMessage>();

            Grid_Detail.Pager.DivObject = "divAlterationPager";

            Grid_Detail.Pager.CallBackMethod = "Get_Alterations";
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

        public AlterationInfo Alteration
        {
            get;
            set;
        }

        public SalesInvoiceInfo SalesInvoice
        {
            get;
            set;
        }

        public List<SalesInvoiceInfo> SalesInvoices
        {
            get;
            set;
        }

        public EmployeeInfo Employee
        {
            get;
            set;
        }

        public List<EmployeeInfo> Employees
        {
            get;
            set;
        }

        public Filter_Alteration Filter
        {
            get;
            set;
        }

        public List<FriendlyMessage> FriendlyMessages
        {
            get;
            set;
        }

    }

    public class Filter_Alteration
    {
        //public string Invoice_No
        //{
        //    get;
        //    set;
        //}

        public string Customer_Mobile_No
        {
            get;
            set;
        }
    }
}