using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using webAPIAngular.DAL;
using webAPIAngular.Models;

namespace webAPIAngular.Controllers
{
    public class AcessLogController : ApiController
    {
        private SubscriberContext db = new SubscriberContext();

        /*
                [Route("api/products")]
                public IEnumerable<Product> GetAllProducts(){}

                [Route("api/products/sold")]
                public IEnumerable<Product> GetSoldProducts(){}

        */

        // GET: api/AcessLog
        public IHttpActionResult GetAcessLogs(int id)
        {
            var AcessLog = db.AcessLogs.Where(a => a.SubscriberId == id).Include(a => a.Subscriber)
                .Select(a => new { Id = a.Id ,Duration = a.Duration, AcessDate = a.AcessDate});

            var response = AcessLog.Any() ? AcessLog.ToArray() : null;

            if (response == null)
            {
                return NotFound();
            }

            return Ok(AcessLog);

            /*return Ok(db.Subscribers.Include(s => s.AcessLogs).Select(
            s => new { Id = s.Id, Email = s.Email, SubscribeDate = s.SubscribeDate }
                 ));*/


        }

        // GET: api/AcessLog/5
        /*
        [ResponseType(typeof(AcessLog))]
        public IHttpActionResult GetAcessLog(int id)
        {
            AcessLog acessLog = db.AcessLogs.Find(id);
            if (acessLog == null)
            {
                return NotFound();
            }

            return Ok(acessLog);
        }*/

        // PUT: api/AcessLog/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAcessLog(int id, AcessLog acessLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != acessLog.Id)
            {
                return BadRequest();
            }

            db.Entry(acessLog).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcessLogExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/AcessLog
        [ResponseType(typeof(AcessLog))]
        public IHttpActionResult PostAcessLog(AcessLog acessLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AcessLogs.Add(acessLog);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = acessLog.Id }, acessLog);
        }

        // DELETE: api/AcessLog/5
        [ResponseType(typeof(AcessLog))]
        public IHttpActionResult DeleteAcessLog(int id)
        {
            AcessLog acessLog = db.AcessLogs.Find(id);
            if (acessLog == null)
            {
                return NotFound();
            }

            db.AcessLogs.Remove(acessLog);
            db.SaveChanges();

            return Ok(acessLog);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AcessLogExists(int id)
        {
            return db.AcessLogs.Count(e => e.Id == id) > 0;
        }
    }
}