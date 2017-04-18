using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Data;
using SMS.Data.DAL;
using SMS.Data.Models;

namespace SMS.Web.Controllers
{
    public class HomeController : BaseController
    {
        //GET - Dashboard
        public ActionResult Index()
        {
            if (Session["UserId"] == null)
            {
               return RedirectToAction("Index", "Account");
            }
            return View();
        }
        //POST
        [HttpPost]
        public ActionResult Index(Trader obj)
        {
            return View();   
        }

        //GET - Vehicle
        public ViewResult AddVehicle()
        {

            return View();
        }

        //POST - Vehicle
        [HttpPost]
        public ViewResult AddVehicle()
        {

            return View();
        }

    }
}