using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    public class HomeController : Controller
    {
        [Logged]
        public ActionResult Index()
        {
            return View();
        }

        [Logged]
        public ActionResult Employee()
        {
            var db = new ZH_DBEntities16();
            var data = db.Employees.ToList();

            var cofig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(cofig);
            var data2 = mapper.Map<List<EmployeeDTO>>(data);

            return View(data2);
        }

        [HttpGet]
        [Logged]
        public ActionResult AddEmployees()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployees(EmployeeDTO employee)
        {
            if (ModelState.IsValid)
            {
                var db = new ZH_DBEntities16();

                var cofig = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<EmployeeDTO, Employee>();
                });
                var mapper = new Mapper(cofig);
                var data3 = mapper.Map<Employee>(employee);

                db.Employees.Add(data3);
                db.SaveChanges();
                return RedirectToAction("Employee", "Home");
            }
            return View(employee);
        }

        [HttpGet]
        [Logged]
        public ActionResult DeleteEmployee(int id)
        {
            var db = new ZH_DBEntities16();

            var data = (from dp in db.Employees
                        where dp.id.Equals(id)
                        select dp).SingleOrDefault();

            if (data == null)
            {
                // Employee not found
                return HttpNotFound();
            }


            // Remove the employee from the context and save changes
            db.Employees.Remove(data);
            db.SaveChanges();

            return RedirectToAction("Employee", "Home");



        }


        [HttpGet]
        [Logged]
        public ActionResult UpdateEmployee(int id)
        {
            var db = new ZH_DBEntities16();
            var model = (from employee in db.Employees
                         where employee.id == id
                         select employee).SingleOrDefault();

            var cofig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(cofig);
            var data3 = mapper.Map<EmployeeDTO>(model);

            return View(data3);
        }

        [HttpPost]
        public ActionResult UpdateEmployee(EmployeeDTO model)
        {
            var db = new ZH_DBEntities16();
            var employee = db.Employees.SingleOrDefault(e => e.id == model.id);

            if (employee != null)
            {
                employee.name = model.name;
                employee.phone = model.phone;
                employee.email = model.email;
                db.SaveChanges();
            }

            return RedirectToAction("Employee", "Home");
        }


        [Logged]
        public ActionResult Restaurant()
        {
            var db = new ZH_DBEntities16();
            var data = db.Restaurants.ToList();

            var cofig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Restaurant, RestaurantDTO>();
            });
            var mapper = new Mapper(cofig);
            var data2 = mapper.Map<List<RestaurantDTO>>(data);

            return View(data2);
        }




        [HttpGet]
        [Logged]
        public ActionResult AddRestaurants()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddRestaurants(RestaurantDTO restaurant)
        {
            if (ModelState.IsValid)
            {
                var db = new ZH_DBEntities16();

                var cofig = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<RestaurantDTO, Restaurant>();
                });
                var mapper = new Mapper(cofig);
                var data = mapper.Map<Restaurant>(restaurant);

                db.Restaurants.Add(data);
                db.SaveChanges();
                return RedirectToAction("Restaurant", "Home");
            }
            return View(restaurant);
        }




        [HttpGet]
        [Logged]
        public ActionResult UpdateRestaurant(int id)
        {
            var db = new ZH_DBEntities16();
            var model = (from restaurant in db.Restaurants
                         where restaurant.id == id
                         select restaurant).SingleOrDefault();

            var cofig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Restaurant, RestaurantDTO>();
            });
            var mapper = new Mapper(cofig);
            var data3 = mapper.Map<RestaurantDTO>(model);

            return View(data3);
        }

        [HttpPost]
        public ActionResult UpdateRestaurant(RestaurantDTO model)
        {
            var db = new ZH_DBEntities16();
            var restaurant = db.Restaurants.SingleOrDefault(e => e.id == model.id);

            var cofig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RestaurantDTO, Restaurant>();
            });
            var mapper = new Mapper(cofig);
            var data3 = mapper.Map<Restaurant>(model);

            if (data3 != null)
            {
                data3.name = model.name;
                data3.username = model.username;
                data3.password = model.password;
                data3.phone = model.phone;
                data3.location = model.location;
                db.SaveChanges();
            }

            return RedirectToAction("Restaurant", "Home");
        }


        [HttpGet]
        [Logged]
        public ActionResult DeleteRestaurant(int id)
        {
            var db = new ZH_DBEntities16();

            var data = (from dp in db.Restaurants
                        where dp.id.Equals(id)
                        select dp).SingleOrDefault();

            if (data == null)
            {
                // Employee not found
                return HttpNotFound();
            }


            // Remove the employee from the context and save changes
            db.Restaurants.Remove(data);
            db.SaveChanges();

            return RedirectToAction("Restaurant", "Home");



        }

        [HttpGet]
        [Logged]
        public ActionResult showComingRequests()
        {
            var db = new ZH_DBEntities16();

            var waitingRequests = (from request in db.collection_rqsts
                                   where request.status == "waiting"
                                   select request).ToList();

            return View(waitingRequests);

        }

        [HttpGet]
        [Logged]
        public ActionResult showRequests()
        {
            var db = new ZH_DBEntities16();

            var data = db.collection_rqsts.ToList();

            return View(data);
        }


        [HttpGet]
        [Logged]
        public ActionResult AcceptRequest(int id)
        {
            var db = new ZH_DBEntities16();

            var model = (from request in db.collection_rqsts
                         where request.id == id
                         select new DistributionDTO
                         {
                             // Map properties from request to DistributionDTO
                             // Example: Property1 = request.Property1,
                             //          Property2 = request.Property2,
                             request_id = request.id,
                             dist_date = DateTime.Now,

                         }).SingleOrDefault();



            return View(model);

        }

        [HttpPost]
        public ActionResult AcceptRequest(Distribution distribution)
        {
            var db = new ZH_DBEntities16();

            db.Distributions.Add(new Distribution
            {
                request_id = distribution.request_id,
                emp_id = distribution.emp_id,
                dist_date = distribution.dist_date,
                status = "completed",

            });
            db.SaveChanges();

            var model = (from request in db.collection_rqsts
                         where request.id == distribution.request_id
                         select request).SingleOrDefault();

            if (model != null)
            {
                db.Entry(model).Property(x => x.status).IsModified = true;
                model.status = "completed";

                // Save changes to the database
                db.SaveChanges();
            }
            

            return RedirectToAction("showRequests", "Home");

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
                if (login.Username == "admin" && login.Password == "admin")
                {
                    Session["user"] = "admin";
                    return RedirectToAction("Index", "Home");
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


    }
}