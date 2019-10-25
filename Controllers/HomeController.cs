using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_Api_Demo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }
    }

    public class WorldA
    {
        public int id { get; set; }
        public string wewe { get; set; }
    }
    public class WorldB
    {
        public int id { get; set; }
        public string wewe { get; set; }
    }
}
