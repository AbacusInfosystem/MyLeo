using MyLeoRetailer.Common;
using MyLeoRetailerInfo.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyLeoRetailer.Filters
{
    public class AuthorizeUserAttribute : AuthorizeAttribute, IAuthorizationFilter
    {

        public readonly string _appFunction;

        public readonly string _accessFun;

        public readonly string _access;

        public LoginInfo _cookies;

        public AuthorizeUserAttribute(AppFunction appFunction)
        {
            _appFunction = appFunction.ToString();
            
            int idx = _appFunction.LastIndexOf('_');

            _accessFun = _appFunction.Substring(0, idx).Replace("_", " ");

            _access = _appFunction.Substring(idx + 1);

            _cookies = new LoginInfo();
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            _cookies = Utility.Get_Login_User("LoginInfo", "Token", "Brand_Ids");
            
         
            if (_cookies != null && _cookies.Access_Functions.Count() != 0 &&
                _cookies.Access_Functions.Any(x => x.Access_Function_Name == _accessFun && ((x.Is_Access && _access == Actions.Access.ToString()) || (x.Is_Create && _access == Actions.Create.ToString()) || (x.Is_Edit && _access == Actions.Edit.ToString()) || (x.Is_View && _access == Actions.View.ToString()))))
            {
                // Log Activity.
            }
            else
            {

                filterContext.Result = new HttpUnauthorizedResult();

                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    HttpContext.Current.Response.Clear();

                    HttpContext.Current.Response.StatusCode = Convert.ToInt32(HttpStatusCode.Unauthorized);
                }
                else
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "AuthorizationError" }));
                }
            }

        }

    }
}