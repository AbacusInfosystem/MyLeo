using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Barcode;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerInfo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLeoRetailer.Models
{
    public class BarcodeViewModel: IGridInfo, IQueryInfo
    {
        public BarcodeViewModel() 
		{
			Grid_Detail = new GridInfo();

			Query_Detail = new QueryInfo();

            Barcode = new BarcodeInfo();

			FriendlyMessages = new List<FriendlyMessage>();

			Grid_Detail.Pager.DivObject = "divBarcodePager";

            Grid_Detail.Pager.CallBackMethod = "Get_Barcodes";
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

        public BarcodeInfo Barcode
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
	
}