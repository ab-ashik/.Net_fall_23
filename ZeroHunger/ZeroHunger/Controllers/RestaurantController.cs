using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using ZeroHunger.Auth;
using ZeroHunger.DTOs;
using ZeroHunger.EF;
using ZeroHunger.Models;

namespace ZeroHunger.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: Restaurant
        [Logged]
        public ActionResult Index()
        {
            var db = new ZH_DBEntities16();

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
                var db = new ZH_DBEntities16();
                var user = (from u in db.Restaurants
                            where u.username.Equals(login.Username)
                            && u.password.Equals(login.Password)
                            select u).SingleOrDefault();
                if (user != null)
                {
                    Session["user"] = user.username;
                    Session["id"] = user.id;
                    return RedirectToAction("Index", "Restaurant");
                }
                TempData["Msg"] = "Username Password Invalid";
            }
            return View(login);

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login");
        }


        [HttpGet]
        [Logged]
        public ActionResult MakeRequest()
        {
            var db = new ZH_DBEntities16();

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
            var db = new ZH_DBEntities16();

           // var id = Session["id"];

            db.collection_rqsts.Add(new collection_rqsts
            {
                restaurant_id = (int)Session["id"],
                expiry_date = model.expiry_date,
                status = "waiting",
                description = model.description
            });
            db.SaveChanges();

            return RedirectToAction("Index", "Restaurant");   

        }


        [HttpGet]
        [Logged]
        public ActionResult showRequests()
        {
            var db = new ZH_DBEntities16();

            int idd = (int)Session["id"];

            var requests = (from request in db.collection_rqsts
                                   where request.restaurant_id == idd
                                   select request).ToList();

            return View(requests);

        }
    }
}