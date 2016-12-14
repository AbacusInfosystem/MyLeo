using MyLeoRetailer.Common;
using MyLeoRetailer.Models;
using MyLeoRetailerHelper.Logging;
using MyLeoRetailerInfo;
using MyLeoRetailerRepo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyLeoRetailer.Controllers.PostLogin.Barcode
{
    public class BarcodeController : BaseController
    {
        //
        // GET: /Barcode/

        public BarcodeRepo _barcodeRepo;

        public BarcodeController()
        {
            _barcodeRepo = new BarcodeRepo();
        }

        public ActionResult Barcode(BarcodeViewModel bViewModel)
        {
            try
            {
                if (TempData["bViewModel"] != null)
                {
                    bViewModel = (BarcodeViewModel)TempData["bViewModel"];
                }
            }
            catch (Exception ex)
            {
                bViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("Barcode Controller - Barcode : " + ex.ToString());
            }
            return View("Barcode", bViewModel);
        }

        public JsonResult Get_Barcodes(BarcodeViewModel bViewModel)
        {
            try
            {
                bViewModel.Barcode.Barcodes = _barcodeRepo.Get_Barcodes(bViewModel.Barcode);
            }
            catch (Exception ex)
            {
                bViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error(" Barcode - Get_Barcodes : " + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(bViewModel));
        }

        public ActionResult Insert_Barcode(BarcodeViewModel bViewModel)
        {

            try
            {
                Set_Date_Session(bViewModel.Barcode);

                if (bViewModel.Barcode.Product_SKU_Barcode_Id == 0)
                {

                    _barcodeRepo.Insert_Barcode(bViewModel.Barcode);

                    bViewModel = new BarcodeViewModel();

                    bViewModel.FriendlyMessages.Add(MessageStore.Get("BAR01"));
                }
                else
                {
                    bViewModel.FriendlyMessages.Add(MessageStore.Get("SY01"));
                }

            }
            catch (Exception ex)
            {
                bViewModel = new BarcodeViewModel();

                bViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error(" Barcode - Insert_Barcode : " + ex.ToString());

            }

            TempData["bViewModel"] = (BarcodeViewModel)bViewModel;

            return RedirectToAction("Barcode", bViewModel);

        }

        public ActionResult Print_Barcode(BarcodeViewModel bViewModel)
        {
            try
            {
                foreach (var item in bViewModel.Barcode.Barcodes)
                {
                    Set_Date_Session(item);
                }

                bViewModel.PrintBarcodeData = _barcodeRepo.Get_Print_Barcodes_Data(bViewModel.Barcode.Barcodes);
            }
            catch (Exception ex)
            {
                bViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Barcode Controller - Barcode : " + ex.ToString());
            }
            return View("PrintBarcode", bViewModel);
        }

    }
}
