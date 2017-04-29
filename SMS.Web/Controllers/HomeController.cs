using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Data;
using SMS.Data.DAL;
using SMS.Data.Models;
using SMS.Data.ViewModels;
using PagedList;
using PagedList.Mvc;

namespace SMS.Web.Controllers
{
    public class HomeController : BaseController
    {
        int usr_id = 0;
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["UserId"] != null)
            {
                usr_id = Convert.ToInt32(Session["UserId"]);
                base.OnActionExecuting(filterContext);
            }
            else
            {
                filterContext.Result = new RedirectResult("~/Account/");
            }
        }
        //GET - Dashboard
        public ActionResult Index(int? page)
        {
            using (SMSContext db = new SMSContext())
            {
                try
                {
                    //var vehicleList = db.Vehicle.Include("ExtraCost").ToList();

                    var vehicleList = from v in db.Vehicle.Include("ExtraCost")
                                      where v.TraderId == usr_id
                                      select v;
                    return View(vehicleList.ToList().ToPagedList(page ?? 1, 15));
                }
                catch (NullReferenceException ex)
                {
                    ViewBag.NullMessage = "Your Stock is Empty. Go to Vehicles to add new Vehilce.";
                    return null;
                }


            }
        }
        //POST
        [HttpPost]
        public ActionResult Index(Trader obj)
        {
            return View();
        }

        //Get - Edit vehicle
        public ActionResult EditVehicle(int? Id)
        {
            if(Id == null)
            {
                return RedirectToAction("Index");
            }
            using(var db = new SMSContext())
            {
                var v = db.Vehicle.Find(Id);
                if(v == null)
                {
                    return RedirectToAction("Index");
                }
                return View(v);               
            }
        }

        //GET - Vehicle
        public ViewResult AddVehicle()
        {

            return View();
        }

        //POST - Vehicle
        [HttpPost]
        public ViewResult AddVehicle(VehicleViewModel vehicle)
        {
            if (ModelState.IsValid)
            {
                var newVehicle = new Vehicle()
                {
                    DateEntered = vehicle.DateEntered,
                    Make = vehicle.Make,
                    Model = vehicle.Model,
                    Kilometers = vehicle.Kilometers,
                    Rego = vehicle.Rego,
                    CostPrice = vehicle.CostPrice,
                    SellingPrice = vehicle.SellingPrice,
                    Status = vehicle.Status,
                    DateSold = vehicle.DateSold,
                    TraderId = Convert.ToInt32(Session["UserId"])
                };
                using (SMSContext db = new SMSContext())
                {
                    db.Vehicle.Add(newVehicle);
                    db.SaveChanges();
                }
            }

            return View();
        }

        //Extras
        public ViewResult AddExtras(int id)
        {
            var newCost = new ExtraCostViewModel();
            newCost.TraderId = Convert.ToInt32(Session["UserId"]);
            newCost.VehicleId = id;
            return View(newCost);
        }

        //Extras -POST
        [HttpPost]
        public ActionResult AddExtras(ExtraCostViewModel c)
        {
            if (ModelState.IsValid)
            {
                using (SMSContext db = new SMSContext())
                {
                    db.ExtraCost.Add(new ExtraCost
                    {
                        TraderId = c.TraderId,
                        VehicleId = c.VehicleId,
                        DateEntered = c.DateEntered,
                        Description = c.Description,
                        Cost = c.Cost
                    });
                    db.SaveChanges();

                }
            }

            return RedirectToAction("Index");

        }

        //Get - Update Extras
        public ActionResult UpdateExtras(int id)
        {
            if (id == 0)
            {
                RedirectToAction("Index");
            }
            using (SMSContext db = new SMSContext())
            {
                var data = db.ExtraCost.Find(id);
                var extraView = new ExtraCostViewModel()
                {
                    Id = data.Id,
                    TraderId = data.TraderId,
                    VehicleId = data.VehicleId,
                    DateEntered = data.DateEntered,
                    Description = data.Description,
                    Cost = data.Cost
                };
                return View(extraView);
            }
        }
        //Post - Update Extras
        [HttpPost]
        public ActionResult UpdateExtras(ExtraCostViewModel m)
        {
            if (ModelState.IsValid)
            {
                using (var db = new SMSContext())
                {
                    var data = db.ExtraCost.Find(m.Id);
                    data.TraderId = m.TraderId;
                    data.VehicleId = m.VehicleId;
                    data.DateEntered = m.DateEntered;
                    data.Description = m.Description;
                    data.Cost = m.Cost;
                    db.SaveChanges();
                };

            }
            return RedirectToAction("ExtraDetails", new { id = m.VehicleId });
        }

        //Post - Delete Extras
        //Delete -POST
        public ActionResult DeleteExtra(int e_id, int? v_id)
        {
            if (e_id != 0)
            {
                using (var db = new SMSContext())
                {
                    db.ExtraCost.Remove(db.ExtraCost.Find(e_id));
                    db.SaveChanges();
                }
            }
            return RedirectToAction("ExtraDetails", new { id = v_id});
        }


        //Get - All extras by vehicle id
        [HttpGet]
        public ViewResult ExtraDetails(int id)
        {
            if (id == 0)
            {
                return View("Index");
            }
            using (var db = new SMSContext())
            {
                var extraList = db.ExtraCost.Where(e => e.VehicleId == id && e.TraderId == usr_id).ToList();
                return View(extraList);
            }
        }

    }
}