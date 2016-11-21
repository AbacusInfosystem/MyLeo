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
    public class BarcodeViewModel
    {
        public BarcodeViewModel() 
		{	
            Barcode = new BarcodeInfo();

			FriendlyMessages = new List<FriendlyMessage>();
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