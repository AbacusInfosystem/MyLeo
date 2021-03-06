﻿using MyLeoRetailer.Models.Common;
using MyLeoRetailerInfo;
using MyLeoRetailerInfo.PurchaseInvoice;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerInfo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLeoRetailer.Models
{
    public class PurchaseInvoiceViewModel: IGridInfo, IQueryInfo
	{
        public PurchaseInvoiceViewModel() 
		{
			Grid_Detail = new GridInfo();

			Query_Detail = new QueryInfo();

			PurchaseInvoice = new  PurchaseInvoiceInfo();

			Filter = new Filter_Purchase_Invoice();

			FriendlyMessages = new List<FriendlyMessage>();

            Pager = new Pagination_Info();

            Cookies = new LoginInfo();

			Grid_Detail.Pager.DivObject = "divPurchaseInvoicePager";

            Grid_Detail.Pager.CallBackMethod = "Get_Purchase_Invoices";
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

		public  PurchaseInvoiceInfo PurchaseInvoice
		{
			get;
			set;
		}

		public Filter_Purchase_Invoice Filter
		{
			get;
			set;
		}

		public List<FriendlyMessage> FriendlyMessages
		{
			get;
			set;
		}

        public Pagination_Info Pager
        {
            get;
            set;
        }

        public LoginInfo Cookies
        {
            get;
            set;
        }
	}
	
}