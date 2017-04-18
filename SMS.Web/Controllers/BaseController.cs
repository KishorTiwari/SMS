using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Data.DAL;

namespace SMS.Web.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public BaseController()
        {
             db = new SMSContext();    
        }
        public SMSContext db { get; set; }

    }
}