using IBLL;
using Model;
using System;
using System.Linq;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    [LoginCheckFilter(IsCheck = false)]
    public class UserInfoController : Controller
    {
       public IUserInfoService u { get; set; }
        // GET: UserInfo
        //显示详情页
        public ActionResult Index()
        {
            //throw new Exception("ddddddd");
            ViewData.Model = u.GetEntities(u=>true);
            return View();
        }

        // GET: UserInfo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult GetAll()
        {
            //jquery easyui:table {total:32,row:[{},{}]}

            //jquery：table在初始化的时候自动发送以下两个数据
            int pagesize = int.Parse(Request["rows"] ?? "10");
            int pageindex = int.Parse(Request["page"] ?? "1");
            int total = 0;

            short delflag = (short)Model.Enums.DelFlagEnum.Normal;
            //拿到当前页的数据
            var pageData = u.GetPageEntities(pagesize, pageindex, out total, u => u.DelFlag == delflag, u => u.ID, true).Select(u=>new {
                ID = u.ID,
                UserName =u.UName,
                Remark = u.Remark,
                Pwd = u.UPwd,
                SubTime = u.SubTime,
            });

            var data = new { total = total, rows = pageData.ToList()};

            //有导航属性的时候，使用微软默认序列化会有问题
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        // GET: UserInfo/Create
        public ActionResult Create(UserInfo info)
        {
            info.ModifiedOn = DateTime.Now;
            info.SubTime = DateTime.Now;

            info.DelFlag = (short)Model.Enums.DelFlagEnum.Normal;
            u.Add(info);

            return Content("ok!");
        }

        //// POST: UserInfo/Create
        //[HttpPost]
        //public ActionResult Create(UserInfo info)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: UserInfo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserInfo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserInfo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserInfo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
