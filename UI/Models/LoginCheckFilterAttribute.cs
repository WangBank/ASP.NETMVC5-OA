using Common;
using Common.Cache;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Models
{
    public class LoginCheckFilterAttribute: ActionFilterAttribute
    {

        public bool IsCheck { get; set; }

        public UserInfo LoginUser { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            //if (IsCheck)
            //{
            //    //检验用户是否登陆   
            //    if (filterContext.HttpContext.Session["LoginUser"] == null)
            //    {
            //        filterContext.HttpContext.Response.Redirect("/Login/Index");
            //    }
            //}
            //else
            //{
            //    LoginUser = filterContext.HttpContext.Session["LoginUser"] as UserInfo;
            //}
            if (IsCheck) {
                string userid = filterContext.HttpContext.Request.Cookies["userid"].Value.ToString();
                var s = CacheHelper.GetCache("userid");
                if (CacheHelper.GetCache(userid) != null)
                {
                    LoginUser =(UserInfo) CacheHelper.GetCache(filterContext.HttpContext.Request.Cookies["userid"].Value);
                    //滑动窗口
                    CacheHelper.SetCache(userid,LoginUser,DateTime.Now.AddMinutes(20));
                }else
                {
                    filterContext.HttpContext.Response.Redirect("/Login/Index");
                }
            }
        }
    }
}