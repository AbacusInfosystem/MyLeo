using MyLeoRetailer.Models.Common;
using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Category;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerInfo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLeoRetailer.Models
{
	public class CategoryViewModel:IGridInfo, IQueryInfo
	{
        public CategoryViewModel() 
		{
			Grid_Detail = new GridInfo();

			Query_Detail = new QueryInfo();

			Category = new CategoryInfo();

            Categories = new List<CategoryInfo>();

			Filter = new Filter_Category();

			FriendlyMessages = new List<FriendlyMessage>();

			Grid_Detail.Pager.DivObject = "divCategoryPager";

			Grid_Detail.Pager.CallBackMethod = "Get_Categories";
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

		public CategoryInfo Category
		{
			get;
			set;
		}

		public Filter_Category Filter
		{
			get;
			set;
		}

		public List<FriendlyMessage> FriendlyMessages
		{
			get;
			set;
		}

        public List<CategoryInfo> Categories { get; set; }

	}

	public class Filter_Category
	{
		public string Category
		{
			get;
			set;
		}
	}
}