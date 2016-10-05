using Barcode_Generator;
using MyLeoRetailer.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyLeoRetailer.Controllers.PostLogin.Dashboard
{
    [SessionExpireAttribute]
    public class DashboardController : Controller
    {
        //
        // GET: /Dashboard/

        public ActionResult Index()
        {
            Barcode bar = new Barcode();
            byte[] barcodeInBytes = bar.Generate_Linear_Lib_Barcode("ABCD", "E:/backup/27072016/SMS_Portal/Updated SMS/SMS/SMSPortal/UploadedFiles/ABCD22.png");
            byte[] barcodeInBytes1 = bar.Generate_Linear_Barcode("ABACUSINFOSYSTEMNEW", "E:/backup/27072016/SMS_Portal/Updated SMS/SMS/SMSPortal/UploadedFiles/Myleo22.png");
            return View();
        }

        

    }
}
