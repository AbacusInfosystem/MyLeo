using MyLeoRetailer.Models.Common;
using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Category;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerInfo.Interface;
using MyLeoRetailerInfo.Tax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLeoRetailer.Models
{
    public class TaxViewModel : IGridInfo, IQueryInfo
    {
        public TaxViewModel() 
		{
			Grid_Detail = new GridInfo();

			Query_Detail = new QueryInfo();

            Tax = new TaxInfo();

			Filter = new Filter_Tax();

			FriendlyMessages = new List<FriendlyMessage>();

			Grid_Detail.Pager.DivObject = "divTaxPager";

			Grid_Detail.Pager.CallBackMethod = "Get_Taxes";
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

		public TaxInfo Tax
		{
			get;
			set;
		}

        public Filter_Tax Filter
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

	public class Filter_Tax
	{
		public string Tax_Name
		{
			get;
			set;
		}
	}
}