﻿using System.Web;
using System.Web.Mvc;

namespace ASP_WebAppTour_6AKIF_JaenV
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
