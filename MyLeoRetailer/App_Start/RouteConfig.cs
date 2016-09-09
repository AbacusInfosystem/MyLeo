using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyLeoRetailer
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            #region Autocomplete Lookup

            routes.MapRoute(
            name: "AutocompleteLookup-1",
            url: "autocomplete/autocomplete-get-lookup-data",
            defaults: new { controller = "AutocompleteLookup", action = "Load_Modal_Data", id = UrlParameter.Optional },
            namespaces: new string[] { "MyLeoRetailer.Controllers" });

            routes.MapRoute(
            name: "AutocompleteLookup-2",
            url: "autocompleteLookup/get-lookup-data-by-id",
            defaults: new { controller = "AutocompleteLookup", action = "Get_Lookup_Data_By_Id", id = UrlParameter.Optional },
            namespaces: new string[] { "MyLeoRetailer.Controllers" });

            #endregion

            #region Autocomplete

            routes.MapRoute(
            name: "brand-1",
            url: "brand/get-brand-list-by-name/{brand_Name}",
            defaults: new { controller = "Brand", action = "Get_Brands_By_Name_Autocomplete", brand_Name = UrlParameter.Optional, id = UrlParameter.Optional },
            namespaces: new string[] { "MyLeoRetailer.Controllers" });

            #endregion

            #region Product

            routes.MapRoute(
            name: "Product-1",
            url: "Product/Insert_Product",
            defaults: new { controller = "Product", action = "Insert_Product", brand_Name = UrlParameter.Optional, id = UrlParameter.Optional },
            namespaces: new string[] { "MyLeoRetailer.Controllers" });

            routes.MapRoute(
            name: "Product-2",
            url: "Product/Update_Product",
            defaults: new { controller = "Product", action = "Update_Product", brand_Name = UrlParameter.Optional, id = UrlParameter.Optional },
            namespaces: new string[] { "MyLeoRetailer.Controllers" });

            routes.MapRoute(
            name: "Product-3",
            url: "Product/Get_Product_By_Id",
            defaults: new { controller = "Product", action = "Get_Product_By_Id", brand_Name = UrlParameter.Optional, id = UrlParameter.Optional },
            namespaces: new string[] { "MyLeoRetailer.Controllers" });

            routes.MapRoute(
            name: "Product-4",
            url: "Product/Get_Products",
            defaults: new { controller = "Product", action = "Get_Products", brand_Name = UrlParameter.Optional, id = UrlParameter.Optional },
            namespaces: new string[] { "MyLeoRetailer.Controllers" });

            routes.MapRoute(
            name: "Product-5",
            url: "Product/Get_Sizes_By_SizeGroupId",
            defaults: new { controller = "Product", action = "Get_Sizes_By_SizeGroupId", brand_Name = UrlParameter.Optional, id = UrlParameter.Optional },
            namespaces: new string[] { "MyLeoRetailer.Controllers" }); 

            routes.MapRoute(
            name: "Product-6",
            url: "Product/Get_Colours_By_ColourId",
            defaults: new { controller = "Product", action = "Get_Colours_By_ColourId", brand_Name = UrlParameter.Optional, id = UrlParameter.Optional },
            namespaces: new string[] { "MyLeoRetailer.Controllers" });

            routes.MapRoute(
            name: "Product-7",
            url: "Product/serch-ProductPrizing",
            defaults: new { controller = "Product", action = "ProductPrizing", brand_Name = UrlParameter.Optional, id = UrlParameter.Optional },
            namespaces: new string[] { "MyLeoRetailer.Controllers" }); 
            

            #endregion


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Branch", action = "Search", id = UrlParameter.Optional }
            );
        }
    }
}