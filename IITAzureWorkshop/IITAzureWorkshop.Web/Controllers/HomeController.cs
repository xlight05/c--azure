using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IITAzureWorkshop.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var appTitle = ConfigurationManager.AppSettings["AppTitle"];
            ViewBag.AppTitle = appTitle;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "IIT Azure Workshop 2017";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Kasun Kodagoda";

            return View();
        }
    }
}