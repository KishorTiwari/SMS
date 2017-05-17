using SMS.Data.DAL;
using SMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;

namespace SMS.Web.Controllers
{
    public class TraderController : ApiController
    {
        public IHttpActionResult Get()
        {
            using (var db = new SMSContext())
            {
                var trader = db.Trader.Select(t => new {t.Id, t.Email, t.Address }).ToList();
                return Ok(trader);
            }
        }

        // GET: api/Traders/5
        //[ResponseType(typeof(Trader))]
        public IHttpActionResult Get(int id)
        {
            using (var db = new SMSContext())
            {
                var trader = db.Trader.Where(t=>t.Id == id).Select(t => new { t.Id, t.Email, t.Address }).Single();
                return Ok(trader);
            }
        }
    }
}
