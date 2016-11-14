using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Study.SSO.Passport.Class;
using Study.SSO.Util;

namespace Study.SSO.Passport.Controllers
{
    public class PassportController : Controller
    {
        private PassportService passportservice = null;
        public PassportController()
        {
            passportservice = new PassportService();
        }

        public ActionResult PassportCenter()
        {
            //没有授权Token非法访问
            if (string.IsNullOrEmpty(Request["Token"]))
            {
                Response.Write("没有授权Token，非法访问");
                Response.End();
            }
            return View();
        }

        /// <summary>
        /// 授权登陆验证
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PassportVertify()
        {
            var cookie=Request.Cookies[ConstantHelper.USER_COOKIE_KEY];
            if (cookie == null ||string.IsNullOrEmpty(cookie.ToString()))
            {
                return RedirectToAction("Login", new { ReturnUrl = Request["ReturnUrl"] ,Token= Request["Token"] });
            }
            string userinfo = cookie.ToString();
            var success= passportservice.AuthernVertify(Request["Token"], Convert.ToDateTime(Request["TimeStamp"]));
            if (!success)
            {
                return RedirectToAction("Login", new { ReturnUrl = Request["ReturnUrl"], Token = Request["Token"] });
            }
            return Redirect(passportservice.GetReturnUrl(userinfo, Request["Token"],Request["ReturnUrl"]));
        }

        /// <summary>
        /// 统一登录
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            ViewBag.ReturnUrl = Request["ReturnUrl"];
            ViewBag.Token= Request["Token"];
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var result=passportservice.Login(username, password);
            if (result.IsSuccess)
            {
                HttpCookie userCookie = new HttpCookie(ConstantHelper.USER_COOKIE_KEY);
                userCookie.HttpOnly = true;
                userCookie.Value = result.UserInfo.UserId.ToString();
                userCookie.Expires = DateTime.Now.AddHours(2);
                Response.Cookies.Add(userCookie);
                var redirectUrl = passportservice.GetReturnUrl(result.UserInfo.UserId.ToString(),Request["Token"],Request["ReturnUrl"]);
                return Redirect(redirectUrl);
            }
            return View();
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        public ActionResult LoginOut()
        {
            Response.Cookies[ConstantHelper.USER_COOKIE_KEY].Expires = DateTime.Now.AddDays(-1);
            Response.Write("退出成功");
            Response.End();
            return new EmptyResult();
        }
    }
}