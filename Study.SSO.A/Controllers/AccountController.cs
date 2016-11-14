using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using Study.SSO.Util;

namespace Study.SSO.A.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// 注销登陆
        /// </summary>
        /// <returns></returns>
        public ActionResult LoginOut()
        {
            //删除本地缓存Token
            Cache cache = System.Web.HttpContext.Current.Cache;
            cache.Remove(ConstantHelper.TOKEN_KEY);
            //删除登陆状态
            HttpContext.Session[ConstantHelper.USER_SESSION_KEY] = null;
            var autherUrl = ConfigurationManager.AppSettings["PassportCenterUrl"];
            return Redirect(string.Format(autherUrl + "/Passport/LoginOut"));
        }
    }
}