﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Threading;
using System.Web.UI.HtmlControls;
using System.Web.Helpers;
using System.Text;

namespace VietSovPetro.Core.Common
{
    public static class SwitchLanguageHelper
    {
        public class Language
        {
            public string Url { get; set; }
            public string ActionName { get; set; }
            public string ControllerName { get; set; }
            public RouteValueDictionary RouteValues { get; set; }
            public bool IsSelected { get; set; }

            public MvcHtmlString HtmlSafeUrl
            {
                get
                {
                    return MvcHtmlString.Create(Url);
                }
            }
        }

        public static Language LanguageUrl(this HtmlHelper helper, string cultureName,
            string languageRouteName = "lang", bool strictSelected = false)
        {
            // set the input language to lower
            cultureName = cultureName.ToLower();
            // retrieve the route values from the view context
            var routeValues = new RouteValueDictionary(helper.ViewContext.RouteData.Values);
            // copy the query strings into the route values to generate the link
            var queryString = helper.ViewContext.HttpContext.Request.QueryString;
            foreach (string key in queryString)
            {
                if (queryString[key] != null && !string.IsNullOrWhiteSpace(key))
                {
                    if (routeValues.ContainsKey(key))
                    {
                        routeValues[key] = queryString[key];
                    }
                    else
                    {
                        routeValues.Add(key, queryString[key]);
                    }
                }
            }
            var actionName = routeValues["action"].ToString();
            var controllerName = routeValues["controller"].ToString();
            // set the language into route values
            routeValues[languageRouteName] = cultureName;
            // generate the language specify url
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext, helper.RouteCollection);
            var url = urlHelper.RouteUrl("Localization", routeValues);
            // check whether the current thread ui culture is this language
            var current_lang_name = Thread.CurrentThread.CurrentUICulture.Name.ToLower();
            var isSelected = strictSelected ?
                current_lang_name == cultureName :
                current_lang_name.StartsWith(cultureName);
            return new Language()
            {
                Url = url,
                ActionName = actionName,
                ControllerName = controllerName,
                RouteValues = routeValues,
                IsSelected = isSelected
            };
        }

        public static MvcHtmlString LanguageSelectorLink(this HtmlHelper helper,
            string cultureName, string imageUrl,
            IDictionary<string, object> htmlAttributes, string languageRouteName = "lang", bool strictSelected = false)
        {
            var language = helper.LanguageUrl(cultureName, languageRouteName, strictSelected);
            TagBuilder tagBuilder = new TagBuilder("img");
            UrlHelper urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            String url = language.Url;
            String imgUrl = urlHelper.Content(imageUrl);
            String image = "";
            StringBuilder html = new StringBuilder();

            // build the image tag.
            tagBuilder.MergeAttribute("src", imgUrl);
            image = tagBuilder.ToString(TagRenderMode.SelfClosing);

            html.Append("<a href=\"");
            html.Append(url);
            html.Append("\">");
            html.Append(image);
            html.Append("</a>");

            return MvcHtmlString.Create(html.ToString());
        }

    }
}
