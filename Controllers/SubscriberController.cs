using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using webAPIAngular.DAL;
using webAPIAngular.Models;

namespace webAPIAngular.Controllers
{
    public class SubscriberController : ApiController
    {
        private SubscriberContext db = new SubscriberContext();

        // GET: api/Subscriber
        public IHttpActionResult GetSubscribers()
        {           
            return Ok(db.Subscribers.Include(s => s.AcessLogs).Select(
                        s => new {Id = s.Id, Email = s.Email, SubscribeDate = s.SubscribeDate}
                    ));            
        }

        // GET: api/Subscriber/5
        [ResponseType(typeof(Subscriber))]
        public IHttpActionResult GetSubscriber(int id)
        {
            Subscriber subscriber = db.Subscribers.Find(id);
            if (subscriber == null)
            {
                return NotFound();
            }

            return Ok(subscriber);
        }

        // PUT: api/Subscriber/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSubscriber(int id, Subscriber subscriber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subscriber.Id)
            {
                return BadRequest();
            }

            db.Entry(subscriber).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscriberExists(id))
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

        // POST: api/Subscriber
        [ResponseType(typeof(Subscriber))]
        public IHttpActionResult PostSubscriber(Subscriber subscriber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Subscribers.Add(subscriber);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = subscriber.Id }, subscriber);
        }

        // DELETE: api/Subscriber/5
        [ResponseType(typeof(Subscriber))]
        public IHttpActionResult DeleteSubscriber(int id)
        {
            Subscriber subscriber = db.Subscribers.Find(id);
            if (subscriber == null)
            {
                return NotFound();
            }

            db.Subscribers.Remove(subscriber);
            db.SaveChanges();

            return Ok(subscriber);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubscriberExists(int id)
        {
            return db.Subscribers.Count(e => e.Id == id) > 0;
        }
    }
}