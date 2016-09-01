using MyLeoRetailerInfo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MyLeoRetailer.Models
{
    public class LookupViewModel
    {
        public LookupViewModel()
        {
            Pager = new Pagination_Info();

            PartialDt = new DataTable();

            HeaderNames = new string[0];

            //Cookies = new CookiesInfo();

        }

        public Pagination_Info Pager { get; set; }

        public DataTable PartialDt { get; set; }

        public string[] HeaderNames { get; set; }

        public string Value { get; set; }

        public string EditLookupValue { get; set; }

        //public CookiesInfo Cookies { get; set; }


    }
}