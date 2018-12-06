using IBLL;
using Model;
using Model.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    [LoginCheckFilter(IsCheck = false)]
    public class UserInfoController : Controller
    {
        public IUserInfoService u { get; set; }

        public IRoleInfoService role { set; get; }

        short deflagenum = (short)Model.Enums.DelFlagEnum.Normal;
        // GET: UserInfo
        //显示详情页
        public ActionResult Index()
        {
            //throw new Exception("ddddddd");
            ViewData.Model = u.GetEntities(u => true);
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

            //过滤的用户名和过滤的备注
            //{ searchName: $("#txtsName").val(), searchRemark: $("#txtSchRemark").val() };
            string schName = Request["searchName"];
            string schRemark = Request["searchRemark"];
            //short delflag = (short)Model.Enums.DelFlagEnum.Normal;

            //拿到当前页的数据
            var param = new UserQueryParam()
            {
                PageIndex = pageindex,
                PageSize = pagesize,
                SchName = schName,
                SchRemark = schRemark,
                Total = total
            };
           var pageData =  u.LoadPageData(param);

            var temp = pageData.Select(u => new
            {
                ID = u.ID,
                UserName = u.UName,
                Remark = u.Remark,
                Pwd = u.UPwd,
                SubTime = u.SubTime,
            });
            //var pageData = u.GetPageEntities(
            //    pagesize, pageindex, out total, 
            //    u => u.DelFlag == delflag, 
            //    u => u.ID, true).Select(
            //    u => new
            //{
            //    ID = u.ID,
            //    UserName = u.UName,
            //    Remark = u.Remark,
            //    Pwd = u.UPwd,
            //    SubTime = u.SubTime,
            //});

            var data = new { total = param.Total, rows = temp.ToList() };

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


        // GET: UserInfo/Edit/5 修改数据
        public ActionResult Edit(int id)
        {
            ViewData.Model = u.GetEntities(u =>u.ID==id).FirstOrDefault();
            return View();
        }

        // POST: UserInfo/Edit/5
        [HttpPost]
        public ActionResult Edit(UserInfo info)
        {
            try
            {
                // TODO: Add update logic here
                u.Edit(info);
                return Content("ok"); ;
            }
            catch
            {
                return View();
            }
        }

        // GET: UserInfo/Delete/5

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public ActionResult Delete(string ids)
        {
            if (string.IsNullOrEmpty(ids))
            {
                return Content("请选择数据");
            }
            List<int> idist = new List<int>();
            string[] idss = ids.Split(',');
            foreach (var id in idss)
            {
                idist.Add(int.Parse(id));
            }
            u.DeleteListByLogical(idist);
            return Content("ok!");
        }

        // POST: UserInfo/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        public ActionResult SetRole(int id)
        {
            int userid = id;

            UserInfo uinfo = u.GetEntities(u => u.ID == id).FirstOrDefault();

            List<RoleInfo> rolelist = new List<RoleInfo>(); 
            ViewBag.RoleList = role.GetEntities(u => u.DelFlag == deflagenum).ToList();
            return View(uinfo);
        }

        public ActionResult ProcessSetRole(int UId)
        {
            int userid = UId;
            List<int> rolelist = new List<int>();
            foreach (var item in Request.Form.AllKeys)
            {

                if (item.StartsWith("ckb_"))
                {
                    int roleid =int.Parse(item.Replace("ckb_",""));
                    rolelist.Add(roleid);
                }
            }
            u.SetRole(userid, rolelist);
            return Content("ok");

        }
    }
}
