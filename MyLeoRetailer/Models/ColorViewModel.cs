using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyLeoRetailer.Models.Common;
using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Color;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerInfo.Interface;

namespace MyLeoRetailer.Models
{
    public class ColorViewModel : IGridInfo, IQueryInfo
    {
        public ColorViewModel() 
		{
			Grid_Detail = new GridInfo();

			Query_Detail = new QueryInfo();

			Color = new ColorInfo();

            Filter = new Filter_Color();

			FriendlyMessages = new List<FriendlyMessage>();

            Grid_Detail.Pager.DivObject = "divColorPager";

			Grid_Detail.Pager.CallBackMethod = "Get_Colors";
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

        public ColorInfo Color
        {
            get;
            set;
        }

        public Filter_Color Filter
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

    public class Filter_Color
    {
        public string Color
        {
            get;
            set;
        }
    }
}