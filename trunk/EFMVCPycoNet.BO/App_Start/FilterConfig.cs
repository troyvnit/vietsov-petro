﻿using System.Web;
using System.Web.Mvc;

namespace EFMVCPycoNet.BO
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}