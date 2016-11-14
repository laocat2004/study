using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Converters;
using Study.SSO.A.Filter;
using Study.SSO.A.Service;

namespace Study.SSO.A.Controllers
{
    public class HomeController : Controller
    {
        [Auth(Code = AuthCodeEnum.Login)]
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

    }
}