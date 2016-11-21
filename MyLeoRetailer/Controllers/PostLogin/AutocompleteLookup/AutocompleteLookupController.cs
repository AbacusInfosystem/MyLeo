using MyLeoRetailer.Models;
using MyLeoRetailerHelper.Logging;
using MyLeoRetailerInfo;
using MyLeoRetailerRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyLeoRetailer.Controllers
{
    public class AutocompleteLookupController : Controller
    {
        AutocompleteLookupRepo _autoLookupRepo;

        public AutocompleteLookupController()
        {
            _autoLookupRepo = new AutocompleteLookupRepo();
        }

        public PartialViewResult Load_Modal_Data(string table_Name, string columns, string headerNames, string page, string editValue, string fieldValue, string fieldName)
        {
            LookupViewModel LookupVM = new LookupViewModel();

            Pagination_Info pager = new Pagination_Info();

            //LookupVM.Cookies = Utility.Get_Login_User("UserInfo", "Token");

            string[] cols;

            string[] headerNamesArr;

            cols = columns.Split(',');

            if (headerNames != null)
            {
                headerNamesArr = headerNames.Split(',');

                LookupVM.HeaderNames = headerNamesArr;
            }

            try
            {

                //LookupVM.PartialDt = _autoLookupRepo.Get_Lookup_Data(table_Name, cols, ref pager, fieldValue, fieldName, LookupVM.Cookies.Entity_Id);
                LookupVM.PartialDt = _autoLookupRepo.Get_Lookup_Data(table_Name, cols, ref pager, fieldValue, fieldName, 1);

                LookupVM.EditLookupValue = editValue;

            }
            catch (Exception ex)
            {
                Logger.Error("LookupController - Load_Modal_Data" + ex.Message);
            }

            return PartialView("_Lookup", LookupVM);
        }

        public JsonResult Get_Lookup_Data_By_Id(string field_Value, string table_Name, string columns, string headerNames)
        {
            LookupViewModel LookupVM = new LookupViewModel();

            try
            {

                string[] cols;

                string[] headerNamesArr;

                cols = columns.Split(',');

                if (headerNames != null)
                {
                    headerNamesArr = headerNames.Split(',');

                    LookupVM.HeaderNames = headerNamesArr;
                }

                if (table_Name == "Assign_Branches")
                {
                    table_Name = "Branch";
                    
                    if (field_Value != null)
                    {
                        LookupVM.Value = _autoLookupRepo.Get_Lookup_Data_Add_Single_Branch(field_Value, table_Name, cols);
                    }
                }

                else if (table_Name == "Purchase_Invoice_Item")
                {
                    if (field_Value != null)
                    {
                        LookupVM.Value = _autoLookupRepo.Get_Lookup_Data_Add_Purchase_Return_SKU(field_Value, table_Name, cols);
                    }
                }
                else if (table_Name == "Product_SKU_Mapping")
                {
                    if (field_Value != null)
                    {
                        LookupVM.Value = _autoLookupRepo.Get_Lookup_Data_Add_Purchase_Invoice_SKU(field_Value, table_Name, cols);
                    }
                }

                else if (table_Name == "Alteration_Employee")
                {
                    if (field_Value != null)
                    {
                        LookupVM.Value = _autoLookupRepo.Get_Lookup_Data_Add_Employee(field_Value, table_Name, cols);
                    }
                }
               
            }
            catch (Exception ex)
            {
                //Logger.Error("LookupController - Get_Lookup_Data_By_Id" + ex.Message);
            }

            return Json(LookupVM.Value, JsonRequestBehavior.AllowGet);
        }

    }
}
