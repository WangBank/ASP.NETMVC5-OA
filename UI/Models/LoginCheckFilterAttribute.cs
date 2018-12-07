using Common;
using Common.Cache;
using IBLL;
using Model;
using Spring.Context;
using Spring.Context.Support;
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
            filterContext.HttpContext.Response.AppendHeader("P3P", "CP=CAO PSA OUR");
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
                if (filterContext.HttpContext.Request.Cookies["userid"] == null) {
                    filterContext.HttpContext.Response.Redirect("/Login/Index");
                }
                else
                {
                    string userid = filterContext.HttpContext.Request.Cookies["userid"].Value.ToString();
                    var s = CacheHelper.GetCache("userid");
                    if (CacheHelper.GetCache(userid) != null)
                    {
                        LoginUser = (UserInfo)CacheHelper.GetCache(filterContext.HttpContext.Request.Cookies["userid"].Value);
                        //滑动窗口
                        CacheHelper.SetCache(userid, LoginUser, DateTime.Now.AddMinutes(20));
                    }
                    else
                    {
                        filterContext.HttpContext.Response.Redirect("/Login/Index");
                    }
                }
                if (LoginUser.UName == "wangzhen")
                {
                    return;
                }
                else
                {
                    string url = filterContext.HttpContext.Request.Url.AbsolutePath;
                    string httpmethod = filterContext.HttpContext.Request.HttpMethod.ToLower();

                    //与当前登录的用户的权限进行对比
                    IApplicationContext ctx = ContextRegistry.GetContext();
                    IActionInfoService ActionInfoService = ctx.GetObject("ActionInfoService") as IActionInfoService;
                    IR_UserInfo_ActionInfoService UAInfoService = ctx.GetObject("R_UserInfo_ActionInfoService") as IR_UserInfo_ActionInfoService;
                    var action = ActionInfoService.GetEntities(a => a.Url.ToLower() == url && a.HttpMethod.ToLower() == httpmethod).FirstOrDefault();
                    if (action == null)
                    {
                        filterContext.HttpContext.Response.Redirect("/Error.html");
                    }

                    //特殊权限校验
                    var rUAs = UAInfoService.GetEntities(u=>u.UserInfoID==LoginUser.ID);
                    var item = (from a in rUAs
                                where a.ActionInfoID == action.ID
                                select a).FirstOrDefault();
                    if (item != null)
                    {
                        if(item.IsPass == true)
                        {
                            return;
                        }
                        else
                        {
                            filterContext.HttpContext.Response.Redirect("/Error.html");
                        }
                    }
                }
                
            }
        }
    }
}