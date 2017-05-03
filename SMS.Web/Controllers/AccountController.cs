using SMS.Data.Models;
using SMS.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Data.DAL;
using SMS.Data.Validations;

namespace SMS.Web.Controllers
{
    public class AccountController : BaseController
    {
        int usr_id = 0;
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
                            usr_id = usr.Id;
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
        public ActionResult Register(TraderViewModel m)
        {
            if (ModelState.IsValid)
            {
                using(SMSContext db = new SMSContext())
                {
                    var newTrader = new Trader
                    {
                        DateCreated = m.DateCreated,
                        Name = m.Name,
                        Address = m.Address,
                        PhoneNumber = m.PhoneNumber,
                        Email = m.Email,
                        Password = Encryption.SHA1(m.Password + Salt.V2)   //using salt
                    };
                    db.Trader.Add(newTrader);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = "Thank You !" + m.Name + " has been successfully registered.";
            }
            return View();
        }       
    }
}