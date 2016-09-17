using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;


namespace MyLeoRetailer.Filters
{
	public class SessionExpireAttribute:ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			HttpContext ctx = HttpContext.Current;

            if (filterContext.HttpContext.Request.Cookies["LoginInfo"] == null)
			{
                filterContext.Result = new RedirectResult("~/Home/System_Error");

				return;
			}

            //base.OnActionExecuting(filterContext);
		}
	}
}