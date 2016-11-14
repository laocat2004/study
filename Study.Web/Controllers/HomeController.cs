using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using HiQPdf;
using Study.Autofac.ThreeIOCType;

namespace Study.Web.Controllers
{
    public class HomeController : Controller
    {
        public IProductService ProductService { get; set; }

        public ActionResult Index()
        {
            var rsp=ProductService.GetProductReso();
            return Content(rsp);
           
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
            string wordContent = string.Empty;
            IView view = ViewEngines.Engines.FindPartialView(ControllerContext, "Index").View;
            using (var writer = new StringWriter())
            {
                var viewContext = new ViewContext(ControllerContext, view, ViewData, TempData, writer);
                viewContext.View.Render(viewContext, writer);
                wordContent = writer.ToString();
                writer.Close();
                writer.Dispose();
            }
            HtmlToPdf htmlToPdfConverter = new HtmlToPdf();
            byte[] pdfBuffer = htmlToPdfConverter.ConvertHtmlToMemory(wordContent, null);
            FileResult fileResult = new FileContentResult(pdfBuffer, "application/pdf");
            fileResult.FileDownloadName = "index.pdf";
            return fileResult;
            return View();
        }
    }
}