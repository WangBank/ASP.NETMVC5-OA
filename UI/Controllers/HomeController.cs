using Common.Cache;
using IBLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
//[LoginCheckFilter(IsCheck = false)] 
    public class HomeController : Controller
    {
        public IActionInfoService ias { set; get; }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult LoadUserMenu()
        {
            //拿到当前用户
            string key = Request.Cookies["userid"].Value.ToString();
            UserInfo user =(UserInfo)CacheHelper.GetCache(key);
            int userid = user.ID;
            //拿到当前用户的权限【必须是菜单项的权限】
            var allrole = user.RoleInfo;
           var allroelaction = (from r in allrole
                               from a in r.ActionInfo
                               select a.ID).ToList();

            //特殊权限
            var alldenyactionids = (from r in user.R_UserInfo_ActionInfo
                                   where r.IsPass == false
                                   select r.ActionInfoID).ToList();

            //从角色对应的权限中剔除特殊权限中被禁用的，得到剩下的权限id
            var allactionids = allroelaction.Where(u=> !alldenyactionids.Contains(u));

            //找出为菜单项的权限
            var actionmenu = ias.GetEntities(u=>allactionids.Contains(u.ID)&& u.IsMenu==true&&u.DelFlag==(short)Model.Enums.DelFlagEnum.Normal).ToList();

            //{ icon: '/Content/ligerui/Source/lib/images/3DSMAX.png', title: '角色管理', url: '/RoleInfo/Index' }

            var data =  from a in actionmenu
                         select new { icon = a.MenuIcon, title = a.ActionInfoName, url = a.Url };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}