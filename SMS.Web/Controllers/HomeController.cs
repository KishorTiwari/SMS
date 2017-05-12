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
        // GET - Dashboard
        public ActionResult Index(int? page, int? status)
        {
            using (SMSContext db = new SMSContext())
            {
                try
                {
                    //var vehicleList = db.Vehicle.Include("ExtraCost").ToList();

                    var vehicleList = from v in db.Vehicle.Include("ExtraCost").Include("Dealer")
                                      where v.TraderId == usr_id
                                      select v;
                    if (status != null)
                    {
                        vehicleList = vehicleList.Where(v => v.Status == status);
                    }
                    return View(vehicleList.ToList().ToPagedList(page ?? 1, 20));
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
            if (Id == null)
            {
                return RedirectToAction("Index");
            }
            using (var db = new SMSContext())
            {
                var v = db.Vehicle.Find(Id);
                if (v == null)
                {
                    return RedirectToAction("Index");
                }
                var vm = new VehicleViewModel()
                {
                    Id = v.Id,
                    TraderId = v.TraderId,
                    DateEntered = v.DateEntered,
                    Make = v.Make,
                    Model = v.Model,
                    Kilometers = v.Kilometers,
                    Rego = v.Rego,
                    CostPrice = v.CostPrice,
                    SellingPrice = v.SellingPrice,
                    Status = v.Status,
                    DateSold = v.DateSold,
                    DealerId = v.DealerId
                };
                vm.Dealers =  db.Dealer.Where(d => d.TraderId == usr_id).ToList();
                return View(vm);
            }
        }

        //POST - Edit vehicle
        [HttpPost]
        public ActionResult EditVehicle(VehicleViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                var vehicleViewModel = new VehicleViewModel();
                vehicleViewModel.Dealers = db.Dealer.Where(d => d.TraderId == usr_id).ToList();
                return View(vehicleViewModel);
            }
            using (var db = new SMSContext())
            {
                var v = db.Vehicle.Find(vm.Id);
                v.Make = vm.Make;
                v.Model = vm.Model;
                v.Kilometers = vm.Kilometers;
                v.Rego = vm.Rego;
                v.CostPrice = vm.CostPrice;
                v.SellingPrice = vm.SellingPrice;
                v.Status = vm.Status;
                v.DateSold = vm.DateSold;
                v.DealerId = vm.DealerId;
                db.SaveChanges();

                ModelState.Clear();
                ViewBag.Message = "Vehicle Edited !";

                return RedirectToAction("Index", "Home");
            }
        }

        //Get - Delete Vehicle
        public ActionResult DeleteVehicle(int id)
        {
            using (var db = new SMSContext())
            {
                var vdel = db.Vehicle.Find(id);
                db.Vehicle.Remove(vdel);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        //GET - Vehicle
        public ViewResult AddVehicle()
        {
            var vehicleViewModel = new VehicleViewModel();
            vehicleViewModel.Dealers = db.Dealer.Where(d => d.TraderId == usr_id).ToList();
            return View(vehicleViewModel);
        }

        //POST - Vehicle
        [HttpPost]
        public ViewResult AddVehicle(VehicleViewModel vehicle)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }          
            using (SMSContext db = new SMSContext())
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
                    TraderId = Convert.ToInt32(Session["UserId"]),
                    DealerId = vehicle.DealerId
                };
                db.Vehicle.Add(newVehicle);
                db.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.Message = "Vehicle Added !";

            var vehicleViewModel = new VehicleViewModel();
            vehicleViewModel.Dealers = db.Dealer.Where(d => d.TraderId == usr_id).ToList();
            return View(vehicleViewModel);
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
            return RedirectToAction("ExtraDetails", new { id = v_id });
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
        [HttpGet]
        public ViewResult GetDealers()
        {
            var dealers = db.Dealer.Where(d => d.TraderId == usr_id).ToList();
            if(dealers != null)
            {
                return View(dealers);
            }
            else
            {
                ModelState.AddModelError("nullError","You don't have any dealers.");
                return View();
            }
        }
        [HttpGet]
        public ViewResult AddDealer()
        {
            var dealer = new DealerViewModel();           
            return View(dealer);
        }
        [HttpPost]
        public ActionResult AddDealer(DealerViewModel dealer)
        {
            if (ModelState.IsValid)
            {
                db.Dealer.Add(new Dealer
                {
                    Name = dealer.Name,
                    TraderId = usr_id
                });
                db.SaveChanges();
                return RedirectToAction("GetDealers");
            }
            else
            {
                return RedirectToAction("GetDealers");
            }
        }

        [HttpGet]
        public ViewResult UpdateDealer(int Id)
        {
            var dealer = db.Dealer.Single(d => d.TraderId == usr_id && d.Id == Id);
            var newDealer = new DealerViewModel
            {
                Name = dealer.Name,
                TraderId = dealer.TraderId,
                Id = dealer.Id
            };
            return View(newDealer);
        }
        [HttpPost]
        public ActionResult UpdateDealer(DealerViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var dealer = db.Dealer.Find(vm.Id);
                dealer.Name = vm.Name;
                dealer.TraderId = usr_id;
                db.SaveChanges();
                return RedirectToAction("GetDealers");
            }
            else
            {
                return RedirectToAction("GetDealers");
            }
        }

        [HttpGet]
        public ActionResult DeleteDealer(int Id)
        {
            if (Id >= 1)
            {
                var dealer = db.Dealer.Find(Id);
                db.Dealer.Remove(dealer);
                db.SaveChanges();
                return RedirectToAction("GetDealers");
            }
            else
            {
                return RedirectToAction("GetDealers");
            }
        }


    }
}