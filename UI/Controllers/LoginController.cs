using Common;
using Common.Cache;
using IBLL;
using Model.Enums;
using System;
using System.Linq;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{

    //打上特性标签
    [LoginCheckFilter(IsCheck =false)]
    public class LoginController : Controller
    {
        public IUserInfoService UserInfoService{get;set;}
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 处理登录的表单
        /// </summary>
        /// <returns></returns>
        public ActionResult ProcessLogin()
        {
            
            //第一步，处理验证码
            string strCode = Request["vCode"];
            string sessionCode = Session["validateCode"] as string;
            Session["validateCode"] = null;
            if (string.IsNullOrEmpty(sessionCode))
            {
                
                return Content("验证码错误！");
            }
            if(strCode != sessionCode)
            {

                return Content("验证码错误！");
            }
            //处理登录名和密码
            string name = Request["LoginCode"];
            string pwd = Request["LoginPwd"];
            short delNormal = (short)DelFlagEnum.Normal;
            var userinfo = UserInfoService.GetEntities(u => u.UName == name && u.UPwd == pwd && u.DelFlag == delNormal).FirstOrDefault();
            if(userinfo == null)
            {
                
                return Content("用户名或者密码错误！");
            }
            //生成随机key
            string userid = Guid.NewGuid().ToString();
            Response.Cookies["userid"].Value = userid;
            //将用户信息存储到memcached中，var s 测试用
            CacheHelper.AddCache(userid, userinfo, DateTime.Now.AddMinutes(20));
            //将key存到cookies中

            // Session["LoginUser"] = userinfo;
            //跳转到首页
            return Content("ok");
        }

            /// <summary>
            /// 生成验证码
            /// </summary>
            /// <returns></returns>
        public ActionResult ShowVCode()
        {
            ValidateCode vliateCode = new ValidateCode();
            string code = vliateCode.CreateValidateCode(4);//产生验证码
            Session["validateCode"] = code;
            byte[] buffer = vliateCode.CreateValidateGraphic(code);//将验证码画到画布上.
            return File(buffer, "image/jpeg");
        }
    }
}