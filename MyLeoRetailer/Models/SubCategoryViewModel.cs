using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Category;
using MyLeoRetailerInfo.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLeoRetailer.Models
{
	public class SubCategoryViewModel
	{
        public SubCategoryViewModel()
		{
			Grid_Detail = new GridInfo();

			Query_Detail = new QueryInfo();

			SubCategory = new SubCategoryInfo();

			Filter = new Filter_Sub_Category();

			FriendlyMessages = new List<FriendlyMessage>();

			Grid_Detail.Pager.DivObject = "divSubCategoryPager";

			Grid_Detail.Pager.CallBackMethod = "Get_Sub_Categories";
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

		public SubCategoryInfo SubCategory
		{
			get;
			set;
		}

		public Filter_Sub_Category Filter
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

	public class Filter_Sub_Category
	{
		public string Sub_Category
		{
			get;
			set;
		}

		public int Category_Id
		{
			get;
			set;
		}
	}
}