using MyLeoRetailer.Models.Common;
using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Brand;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerInfo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLeoRetailer.Models
{
    public class BrandViewModel:IGridInfo, IQueryInfo
	{
        public BrandViewModel() 
		{
			Grid_Detail = new GridInfo();

			Query_Detail = new QueryInfo();

			Brand = new BrandInfo();

            Brands = new List<BrandInfo>();

			Filter = new Filter_Brand();

			FriendlyMessages = new List<FriendlyMessage>();

			Grid_Detail.Pager.DivObject = "divBrandPager";

			Grid_Detail.Pager.CallBackMethod = "Get_Brands";
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

		public BrandInfo Brand
		{
			get;
			set;
		}

		public Filter_Brand Filter
		{
			get;
			set;
		}

		public List<FriendlyMessage> FriendlyMessages
		{
			get;
			set;
		}

        public List<BrandInfo> Brands { get; set; }

	}

	public class Filter_Brand
	{
		public string Brand_Name
		{
			get;
			set;
		}

        public string Brand_Id { get; set; }
	}
}