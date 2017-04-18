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
        public ActionResult Index()
        {
            var newTrader = new Trader();
            newTrader.IsActive = false;
            return View(newTrader);
        }
        //POST
        [HttpPost]
        public ActionResult Index(Trader obj)
        {
            if (ModelState.IsValid)
            {
                db.Trader.Add(new Trader
                {
                    Name = obj.Name,
                    Address = obj.Address,
                    Email = obj.Email,
                    PhoneNumber = obj.PhoneNumber,
                    CurrentPassword = obj.CurrentPassword

                });
                db.SaveChanges();
                return View();
            }
            
            else{
                return View();
            }
            
        }

    }
}