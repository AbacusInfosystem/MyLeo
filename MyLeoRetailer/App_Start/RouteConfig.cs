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

            #region Brand

            routes.MapRoute(
            name: "brand-1",
            url: "brand/get-brand-list-by-name/{brand_Name}",
            defaults: new { controller = "Brand", action = "Get_Brands_By_Name_Autocomplete", brand_Name = UrlParameter.Optional, id = UrlParameter.Optional },
            namespaces: new string[] { "MyLeoRetailer.Controllers" });

            #endregion

            #region Colour

            routes.MapRoute(
            name: "color-1",
            url: "colour/get-color-list-by-name/{color_Name}",
            defaults: new { controller = "Color", action = "Get_Colors_By_Name_Autocomplete", color_Name = UrlParameter.Optional, id = UrlParameter.Optional },
            namespaces: new string[] { "MyLeoRetailer.Controllers" });

            #endregion

            #region Category

            routes.MapRoute(
            name: "category-1",
            url: "category/get-category-by-id/{Category_Id}",
            defaults: new { controller = "Category", action = "Get_Category_By_Id", Category_Id = UrlParameter.Optional, id = UrlParameter.Optional },
            namespaces: new string[] { "MyLeoRetailer.Controllers" });

            routes.MapRoute(
            name: "category-2",
            url: "category/get-sub-category-by-id/{Sub_category_Id}",
            defaults: new { controller = "Category", action = "Get_Sub_Category_By_Id", Sub_category_Id = UrlParameter.Optional, id = UrlParameter.Optional },
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