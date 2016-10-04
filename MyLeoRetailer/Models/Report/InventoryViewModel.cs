using MyLeoRetailer.Models.Common;
using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Inventory;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerInfo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLeoRetailer.Models.Report
{
    public class InventoryViewModel:IGridInfo, IQueryInfo
	{
        public InventoryViewModel() 
		{
			Grid_Detail = new GridInfo();

			Query_Detail = new QueryInfo();

			Inventory = new InventoryInfo();

            Inventories = new List<InventoryInfo>();

			Filter = new Filter_Inventory();

			FriendlyMessages = new List<FriendlyMessage>();

			Grid_Detail.Pager.DivObject = "divInventoryPager";

            Grid_Detail.Pager.CallBackMethod = "Get_Inventories";
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

		public InventoryInfo Inventory
		{
			get;
			set;
		}

		public Filter_Inventory Filter
		{
			get;
			set;
		}

		public List<FriendlyMessage> FriendlyMessages
		{
			get;
			set;
		}

        public List<InventoryInfo> Inventories { get; set; }

	}

	
}