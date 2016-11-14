using System;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Study.SSO.B.Models;
using Study.SSO.Util;

namespace Study.SSO.B.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult LoginOut()
        {
            //删除本地缓存Token
            Cache cache = System.Web.HttpContext.Current.Cache;
            cache.Remove(ConstantHelper.TOKEN_KEY);
            //删除登陆状态
            HttpContext.Session[ConstantHelper.USER_SESSION_KEY] = null;
            var autherUrl = ConfigurationManager.AppSettings["PassportCenterUrl"];
            return Redirect(string.Format(autherUrl+"/Passport/LoginOut"));
        }
    }
}