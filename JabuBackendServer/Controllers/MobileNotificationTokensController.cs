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
using JabuBackendServer.Providers;
using System.Text;

namespace JabuBackendServer.Controllers
{
    public class MobileNotificationTokensController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/MobileNotificationTokens
        public IQueryable<MobileNotificationTokens> GetMobileNotificationToken()
        {
            
            PushyAPI.SendPush(new PushyPushRequest(new { message = "jabutest",title="Church" }, new string[] { "289722f8b3e6bf534cfdad" }, new { message = "jabutest" }));
            return db.MobileNotificationToken;
        }

        // GET: api/MobileNotificationTokens/5
        [ResponseType(typeof(MobileNotificationTokens))]
        public async Task<IHttpActionResult> GetMobileNotificationTokens(int id)
        {
            MobileNotificationTokens mobileNotificationTokens = await db.MobileNotificationToken.FindAsync(id);
   
            if (mobileNotificationTokens == null)
            {
                return NotFound();
            }

            return Ok(mobileNotificationTokens);
        }

        // PUT: api/MobileNotificationTokens/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMobileNotificationTokens(int id, MobileNotificationTokens mobileNotificationTokens)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mobileNotificationTokens.Id)
            {
                return BadRequest();
            }

            db.Entry(mobileNotificationTokens).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MobileNotificationTokensExists(id))
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

        // POST: api/MobileNotificationTokens
        [ResponseType(typeof(MobileNotificationTokensViewModel))]
        public async Task<IHttpActionResult> PostMobileNotificationTokens(MobileNotificationTokensViewModel mobileNotificationTokens)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MobileNotificationToken.Add(new MobileNotificationTokens() { Token = mobileNotificationTokens.Token });
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = mobileNotificationTokens }, mobileNotificationTokens);
        }
       
        // DELETE: api/MobileNotificationTokens/5
        [ResponseType(typeof(MobileNotificationTokens))]
        public async Task<IHttpActionResult> DeleteMobileNotificationTokens(int id)
        {
            MobileNotificationTokens mobileNotificationTokens = await db.MobileNotificationToken.FindAsync(id);
            if (mobileNotificationTokens == null)
            {
                return NotFound();
            }

            db.MobileNotificationToken.Remove(mobileNotificationTokens);
            await db.SaveChangesAsync();

            return Ok(mobileNotificationTokens);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MobileNotificationTokensExists(int id)
        {
            return db.MobileNotificationToken.Count(e => e.Id == id) > 0;
        }
    }
}