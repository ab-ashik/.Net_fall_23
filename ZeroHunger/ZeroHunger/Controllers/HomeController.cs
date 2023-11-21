using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ZeroHunger.DTOs;
using ZeroHunger.EF;

namespace ZeroHunger.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Employee()
        {
            var db = new ZH_DBEntities12();
            var data = db.Employees.ToList();

            var cofig = new MapperConfiguration(cfg => {
                cfg.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(cofig);
            var data2 = mapper.Map<List<EmployeeDTO>>(data);

            return View(data2);
        }

        [HttpGet]
        public ActionResult AddEmployees()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployees(EmployeeDTO employee)
        {
            if (ModelState.IsValid)
            {
                var db = new ZH_DBEntities12();

                var cofig = new MapperConfiguration(cfg => {
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
        public ActionResult DeleteEmployee(int id)
        {
            var db = new ZH_DBEntities12();

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
        public ActionResult UpdateEmployee(int id)
        {
            var db = new ZH_DBEntities12();
            var model = (from employee in db.Employees
                         where employee.id == id
                         select employee).SingleOrDefault();

            var cofig = new MapperConfiguration(cfg => {
                cfg.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(cofig);
            var data3 = mapper.Map<EmployeeDTO>(model);

            return View(data3);
        }

        [HttpPost]
        public ActionResult UpdateEmployee(EmployeeDTO model)
        {
            var db = new ZH_DBEntities12();
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



        public ActionResult Restaurant()
        {
            var db = new ZH_DBEntities12();
            var data = db.Restaurants.ToList();

            var cofig = new MapperConfiguration(cfg => {
                cfg.CreateMap<Restaurant, RestaurantDTO>();
            });
            var mapper = new Mapper(cofig);
            var data2 = mapper.Map<List<RestaurantDTO>>(data);

            return View(data2);
        }




        [HttpGet]
        public ActionResult AddRestaurants()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddRestaurants(RestaurantDTO restaurant)
        {
            if (ModelState.IsValid)
            {
                var db = new ZH_DBEntities12();

                var cofig = new MapperConfiguration(cfg => {
                    cfg.CreateMap<RestaurantDTO, Restaurant>();
                });
                var mapper = new Mapper(cofig);
                var data3 = mapper.Map<Restaurant>(restaurant);

                db.Restaurants.Add(data3);
                db.SaveChanges();
                return RedirectToAction("Restaurant", "Home");
            }
            return View(restaurant);
        }




        [HttpGet]
        public ActionResult UpdateRestaurant(int id)
        {
            var db = new ZH_DBEntities12();
            var model = (from restaurant in db.Restaurants
                         where restaurant.id == id
                         select restaurant).SingleOrDefault();

            var cofig = new MapperConfiguration(cfg => {
                cfg.CreateMap<Restaurant, RestaurantDTO>();
            });
            var mapper = new Mapper(cofig);
            var data3 = mapper.Map<RestaurantDTO>(model);

            return View(data3);
        }

        [HttpPost]
        public ActionResult UpdateRestaurant(RestaurantDTO model)
        {
            var db = new ZH_DBEntities12();
            var restaurant = db.Restaurants.SingleOrDefault(e => e.id == model.id);

            var cofig = new MapperConfiguration(cfg => {
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
        public ActionResult DeleteRestaurant(int id)
        {
            var db = new ZH_DBEntities12();

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

    }
}