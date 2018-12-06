using IBLL;
using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
   //[LoginCheckFilter(IsCheck = false)]
    public class ActionInfoController : Controller
    {
        public IActionInfoService a { get; set; }

        public IRoleInfoService role { set; get; }
        short deflagenum =  (short)Model.Enums.DelFlagEnum.Normal;
        // GET: ActionInfo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(ActionInfo ainfo)
        {
            ainfo.SubTime = DateTime.Now;
            ainfo.ModifiedOn = DateTime.Now.ToString();
            ainfo.DelFlag = deflagenum;
            ainfo.IsMenu = Request["IsMenu"] =="true"? true : false;
            bool b = (bool)ainfo.IsMenu;
            if (b==true) {
                ainfo.MenuIcon = "/Content/ligerui/Source/lib/images/3DSMAX.png";
            }else
            {
                ainfo.MenuIcon = "";
            }
            a.Add(ainfo);
            return Content("ok!");
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAllActionInfo() {
            //jquery easyui:table {total:32,row:[{},{}]}
            //jquery：table在初始化的时候自动发送以下两个数据
            int pagesize = int.Parse(Request["rows"] ?? "10");
            int pageindex = int.Parse(Request["page"] ?? "1");
            int total = 0;
            var temp = a.GetPageEntities(
                pagesize, pageindex, out total, u => u.DelFlag == deflagenum, u => u.ID, true);
            var tempData = temp.Select(a => new
            {
                a.ID,
                a.IsMenu,
                a.Url,
                a.Remark,
                a.Sort,
                a.SubTime,
                a.HttpMethod,
                a.ActionInfoName,
                a.MenuIcon
            });
            var data = new { total = total, rows = tempData.ToList() };

            //有导航属性的时候，使用微软默认序列化会有问题
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(string ids)
        {
            if(string.IsNullOrEmpty(ids))
            {
                return Content("请选择要删除的数据");
            }
            List<int> idlist = new List<int>();
            string[] strid = ids.Split(',');
            foreach (var id in strid)
            {
                idlist.Add(int.Parse(id));
            }
            a.DeleteListByLogical(idlist);
            return Content("ok");
        }

        public ActionResult Edit(int id)
        {
            ViewData.Model = a.GetEntities(u => u.ID == id).FirstOrDefault();
            return View();
        }

        // POST: UserInfo/Edit/5
        [HttpPost]
        public ActionResult Edit(ActionInfo info)
        {
            try
            {
                // TODO: Add update logic here
                a.Edit(info);
                return Content("ok"); ;
            }
            catch
            {
                return View();
            }
        }

        public ActionResult SetRole(int id)
        {
            int actionid = id;

            ActionInfo ainfo = a.GetEntities(u => u.ID == id).FirstOrDefault();

            List<RoleInfo> rolelist = new List<RoleInfo>();
            ViewBag.RoleList = role.GetEntities(u => u.DelFlag == deflagenum).ToList();
            ViewBag.ExitRoles = (from r in ainfo.RoleInfo
                                 select r.ID).ToList();
            return View(ainfo);
        }

        public ActionResult ProcessSetRole(int UId)
        {
            int actionid = UId;
            List<int> rolelist = new List<int>();
            foreach (var item in Request.Form.AllKeys)
            {

                if (item.StartsWith("ckb_"))
                {
                    int roleid = int.Parse(item.Replace("ckb_", ""));
                    rolelist.Add(roleid);
                }
            }
            a.SetRole(actionid, rolelist);
            return Content("ok");

        }
    }
}