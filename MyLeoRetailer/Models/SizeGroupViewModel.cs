using MyLeoRetailer.Models.Common;
using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Size;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerInfo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLeoRetailer.Models
{
    public class SizeGroupViewModel:IQueryInfo, IGridInfo
    {
        public SizeGroupViewModel()
        {
            Grid_Detail = new GridInfo();

            Query_Detail = new QueryInfo();

            SizeGroup = new SizeGroupInfo();

            Filter = new Filter_SizeGroupInfo();

            FriendlyMessages = new List<FriendlyMessage>();

            SizeList = new List<SizeGroupInfo>();

            Grid_Detail.Pager.DivObject = "divSizeGroupPager";

            Grid_Detail.Pager.CallBackMethod = "Get_SizeGroups";
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

        public SizeGroupInfo SizeGroup
        {
            get;
            set;
        }

        public Filter_SizeGroupInfo Filter
        {
            get;
            set;
        }

        public List<FriendlyMessage> FriendlyMessages
        {
            get;
            set;
        }

        public List<SizeGroupInfo> SizeList { get; set; }

    }

    public class Filter_SizeGroupInfo
    {
        public string Size_Group_Name
        {
            get;
            set;
        }

        //public string Size_Name
        //{
        //    get;
        //    set;
        //}

        public int Size_Group_Id
        {
            get;
            set;
        }
    }
}