using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class BaseController : Controller
    {

        public bool IsCheck { get; set; }

        public UserInfo LoginUser { get; set; }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (IsCheck)
            {
                //检验用户是否登陆
                if (filterContext.HttpContext.Session["LoginUser"] == null)
                {
                    filterContext.HttpContext.Response.Redirect("/Login/Index");
                }
            }
            else
            {
                LoginUser = filterContext.HttpContext.Session["LoginUser"] as UserInfo;
            }
        }
    }
}