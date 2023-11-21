using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ZeroHunger.DTOs;
using ZeroHunger.EF;
using ZeroHunger.Models;

namespace ZeroHunger.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: Restaurant
        public ActionResult Index()
        {
            var db = new ZH_DBEntities12();

            var id = Session["id"];

            var data = db.Restaurants.Find(id);

            var data2 =(from s in db.Restaurants
                             where s.id == data.id
                             select s).ToList();

            return View(data2);
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Login(login login)
        {
            if (ModelState.IsValid)
            {
                var db = new ZH_DBEntities12();
                var user = (from u in db.Restaurants
                            where u.username.Equals(login.Username)
                            && u.password.Equals(login.Password)
                            select u).SingleOrDefault();
                if (user != null)
                {
                    Session["user"] = user;
                    Session["id"] = user.id;
                    //var returnUrl = Request["ReturnUrl"];
                    //if (returnUrl != null)
                    //{
                    //    return Redirect(returnUrl);
                    //}
                    return RedirectToAction("Index", "Restaurant");
                }
                TempData["Msg"] = "Username Password Invalid";
            }
            return View(login);

        }


        [HttpGet]
        public ActionResult MakeRequest()
        {
            var db = new ZH_DBEntities12();

            var id = Session["id"];
            var data = db.Restaurants.Find(id);

            var data2 = (from s in db.Restaurants
                         where s.id == data.id
                         select s).ToList();

            return View(data2);

        }

        [HttpPost]
        public ActionResult MakeRequest(collection_rqsts model)
        {
            var db = new ZH_DBEntities12();

           // var id = Session["id"];

            db.collection_rqsts.Add(new collection_rqsts
            {
                restaurant_id = (int)Session["id"],
                expiry_date = model.expiry_date,
                status = "waiting"
            });
            db.SaveChanges();

            return RedirectToAction("Index", "Restaurant");

        }
    }
}