using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace VietSovPetro.BO.Controllers
{
    public abstract class BaseController : Controller
    {
        protected override void Initialize(RequestContext rc)
        {
            if (rc.RouteData.Values["lang"] != null &&
                !string.IsNullOrWhiteSpace(rc.RouteData.Values["lang"].ToString()))
            {
                // set the culture from the route data (url)
                var lang = rc.RouteData.Values["lang"].ToString();
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(lang);
            }
            else
            {
                // load the culture info from the cookie
                var cookie = rc.HttpContext.Request.Cookies["VietSovPetro.CurrentUICulture"];
                var langHeader = string.Empty;
                if (cookie != null)
                {
                    // set the culture by the cookie content
                    langHeader = cookie.Value;
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(langHeader);
                }
                else
                {
                    // set the culture by the location if not speicified
                    langHeader = rc.HttpContext.Request.UserLanguages[0];
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(langHeader);
                }
                // set the lang value into route data
                rc.RouteData.Values["lang"] = langHeader;
            }

            // save the location into cookie
            HttpCookie _cookie = new HttpCookie("VietSovPetro.CurrentUICulture", Thread.CurrentThread.CurrentUICulture.Name);
            _cookie.Expires = DateTime.Now.AddYears(1);
            rc.HttpContext.Response.SetCookie(_cookie);
            base.Initialize(rc);
        }

    }
}
