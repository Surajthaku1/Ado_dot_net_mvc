﻿using System.Web;
using System.Web.Mvc;

namespace Ado_dot_net_mvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
