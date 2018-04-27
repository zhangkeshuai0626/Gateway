using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Filters
{
    /// <summary>
    /// 过滤器配置
    /// </summary>
    public class FilterConfig
    {
        private FilterConfig() { }
        /// <summary>
        /// 注册全局的过滤器
        /// </summary>
        /// <param name="filters"></param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new CheckUrl());
            //filters.Add(new CheckLogin());
            //filters.Add(new CheckApp());
        }
    }
}