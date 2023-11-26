using ProductBuy.EntityF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductBuy.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new DB_TableEntities3();
            var data = db.Products.ToList();


            return View(data);
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