using MyLeoRetailer.Models.Common;
using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Branch;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerInfo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLeoRetailer.Models
{
    public class BranchViewModel : IGridInfo, IQueryInfo
    {
        public BranchViewModel() 
		{
			Grid_Detail = new GridInfo();

			Query_Detail = new QueryInfo();

			Branch = new BranchInfo();

			Filter = new Filter_Branch();

			FriendlyMessages = new List<FriendlyMessage>();

			Grid_Detail.Pager.DivObject = "divBranchPager";

			Grid_Detail.Pager.CallBackMethod = "Get_Branchs";
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

		public BranchInfo Branch
		{
			get;
			set;
		}

		public Filter_Branch Filter
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

	public class Filter_Branch
	{

        public int Branch_ID { get; set; }  //Added by Sushant on 07/10/2016
        
        public string Branch_Name
		{
			get;
			set;
		}
	}
}