using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using JabuBackendServer.Models;
using LuthKemp;

namespace JabuBackendServer.Controllers
{
    public class PrayersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Prayers
        public IQueryable<Prayer> GetPrayers()
        {
            return db.Prayers;
        }

        // GET: api/Prayers/5
        [ResponseType(typeof(Prayer))]
        public async Task<IHttpActionResult> GetPrayer(int id)
        {
            Prayer prayer = await db.Prayers.FindAsync(id);
            if (prayer == null)
            {
                return NotFound();
            }

            return Ok(prayer);
        }

        // PUT: api/Prayers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPrayer(int id, Prayer prayer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prayer.Id)
            {
                return BadRequest();
            }

            db.Entry(prayer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrayerExists(id))
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

        // POST: api/Prayers
        [ResponseType(typeof(Prayer))]
        public async Task<IHttpActionResult> PostPrayer(Prayer prayer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Prayers.Add(prayer);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = prayer.Id }, prayer);
        }

        // DELETE: api/Prayers/5
        [ResponseType(typeof(Prayer))]
        public async Task<IHttpActionResult> DeletePrayer(int id)
        {
            Prayer prayer = await db.Prayers.FindAsync(id);
            if (prayer == null)
            {
                return NotFound();
            }

            db.Prayers.Remove(prayer);
            await db.SaveChangesAsync();

            return Ok(prayer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PrayerExists(int id)
        {
            return db.Prayers.Count(e => e.Id == id) > 0;
        }
    }
}