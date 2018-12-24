using IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{

    
    public class WFTempController : Controller
    {
        public IWF_TempService wftemp { get; set; }
        short deflagenum = (short)Model.Enums.DelFlagEnum.Normal;
        // 显示所有流程模板
        public ActionResult Index()
        {
            return View();
        }
        #region 加载页面
        public ActionResult GetAllTempInfos()
        {
            int pagesize = int.Parse(Request["rows"] ?? "10");
            int pageindex = int.Parse(Request["page"] ?? "1");
            int total = 0;
            var temp = wftemp.GetPageEntities(
                pagesize, pageindex, out total, u => u.Delflag == deflagenum, u => u.ID, true);
            var tempData = temp.Select(a => new
            {
                a.ID,
                a.TempName,
                a.Remark,
                a.SubTime,
                a.ActityType,
                a.Delflag
            });
            var data = new { total = total, rows = tempData.ToList() };

            //有导航属性的时候，使用微软默认序列化会有问题
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 添加页面
        public ActionResult Add()
        {
            return View();
        } 
        #endregion
    }
}