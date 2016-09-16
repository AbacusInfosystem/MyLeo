using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerInfo
{
    public class Pagination_Info
    {
        // Rows fetched from datasource.
        // By default its 0.
        public int TotalRecords { get; set; }

        // Number of maximum records count which is shown on each page. 
        // By default its 10.
        public int PageSize { get; set; }

        // Number of Pager buttons in every batch.
        // By default its 5.
        public int PageLimit { get; set; }

        // Current Page button which is selected.
        // By default its 1.
        public int CurrentPage { get; set; }

        // Current Pagers Min Number.
        // By default its 0.
        public int StartPage { get; set; }

        // Current Pager Max Number.
        // By default its 0.
        public int EndPage { get; set; }

        // If set to true. Move pager to first page.
        // By default its true.
        public bool IsFirst { get; set; }

        // If set to true. Move pager to previous page.
        // By default its true.
        public bool IsPrevious { get; set; }

        // If set to true. Move pager to next page.
        // By default its false.
        public bool IsNext { get; set; }

        // If set to true. Move pager to last page.
        // By default its false.
        public bool IsLast { get; set; }

        // If set to true. Bind Pager.
        // By default its true.
        public bool IsPagingRequired { get; set; }

        // If set to true. Bind current page start and end record with total record number. 
        // By default its true.
        public bool IsPageAndRecordLabel { get; set; }

        // String that holds, Pager HTML.
        // By default its string.Empty.
        public string PageHtmlString { get; set; }

		public string DivObject
		{
			get;
			set;
		}

		public string CallBackMethod
		{
			get;
			set;
		}

        public Pagination_Info()
        {
            PageSize = 5;

            PageLimit = 3;

            CurrentPage = 1;

            IsFirst = false;

            IsPrevious = false;

            IsNext = false;

            IsLast = false;

            IsPagingRequired = true;

            IsPageAndRecordLabel = true;

            PageHtmlString = string.Empty;            
        }


    }
}
