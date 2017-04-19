using SMS.Data.Models;
using SMS.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Data.DAL;

namespace SMS.Web.Controllers
{
    public class AccountController : BaseController
    {
        //Login
        public ActionResult Index()
        {           
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
               using(SMSContext db = new SMSContext())
                {
                    try
                    {
                        var usr = db.Trader.Single(x => x.Email == login.Email && x.Password == login.Password);
                        if (usr != null)
                        {
                            Session["UserId"] = usr.Id;
                            Session["UserName"] = usr.Name;
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    catch(Exception e)
                    {
                        ViewBag.Message = "Inavlid Login. Please try again.";
                    }
                    
                }
            }
            return View();
        }

        //Sign Up
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(TraderViewModel trader)
        {
            if (ModelState.IsValid)
            {
                using(SMSContext db = new SMSContext())
                {
                    AutoMapper.Mapper.Initialize(c =>
                    {
                        c.CreateMap<TraderViewModel, Trader>();
                    });
                    var newTrader = AutoMapper.Mapper.Map<TraderViewModel, Trader>(trader);
                    db.Trader.Add(newTrader);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = "Thank You !" + trader.Name + " has been successfully registered.";
            }
            return View();
        }
    }
}