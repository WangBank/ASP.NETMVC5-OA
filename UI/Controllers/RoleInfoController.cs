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
    [LoginCheckFilter(IsCheck = false)]
    public class RoleInfoController : Controller
    {
        public IRoleInfoService role { get; set; }
        short deflagenum = (short)Model.Enums.DelFlagEnum.Normal;
        // GET: RoleInfo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAllRoleInfo()
        {
            int pagesize = int.Parse(Request["rows"] ?? "10");
            int pageindex = int.Parse(Request["page"] ?? "1");
            int total = 0;
            var temp = role.GetPageEntities(
                pagesize, pageindex, out total, u => u.DelFlag == deflagenum, u => u.ID, true);
            var tempData = temp.Select(a => new
            {
                a.ID,
                a.RoleName,
                a.Remark,
                a.SubTime,
                a.ModifiedOn,
                a.DelFlag
            });
            var data = new { total = total, rows = tempData.ToList() };

            //有导航属性的时候，使用微软默认序列化会有问题
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create(RoleInfo ainfo)
        {
            ainfo.SubTime = DateTime.Now;
            ainfo.ModifiedOn = DateTime.Now;
            ainfo.DelFlag = deflagenum;
            role.Add(ainfo);
            return Content("ok!");
        }
    }
}