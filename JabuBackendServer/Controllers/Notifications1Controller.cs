using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JabuBackendServer.Models;
using LuthKemp;
using JabuBackendServer.Providers;

namespace JabuBackendServer.Controllers
{
    public class Notifications1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Notifications1
        public async Task<ActionResult> Index()
        {
            return View(await db.Notifications.ToListAsync());
        }

        // GET: Notifications1/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notification notification = await db.Notifications.FindAsync(id);
            if (notification == null)
            {
                return HttpNotFound();
            }
            return View(notification);
        }

        // GET: Notifications1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Notifications1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Title,Message")] Notification notification)
        {
            if (ModelState.IsValid)
            {
                db.Notifications.Add(notification);
                await db.SaveChangesAsync();
        var tokens = await db.MobileNotificationToken.ToListAsync();
        sendMobileNotification(tokens, notification);
        return RedirectToAction("Index");
            }

            return View(notification);
        }
        
        private void sendMobileNotification(List<MobileNotificationTokens> tokens, Notification notification)
    {
      
      List<string> Stringtokens = new List<string>();
      tokens.ForEach(delegate (MobileNotificationTokens n)
      {
        Stringtokens.Add(n.Token);
      });
      PushyAPI.SendPush(new PushyPushRequest(new { message = notification.Message, title = notification.Title }, Stringtokens.ToArray(), new { message = notification.Message }));
    }
        // GET: Notifications1/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notification notification = await db.Notifications.FindAsync(id);
            if (notification == null)
            {
                return HttpNotFound();
            }
            return View(notification);
        }

        // POST: Notifications1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,Message")] Notification notification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notification).State = EntityState.Modified;
                await db.SaveChangesAsync();
        var tokens = await db.MobileNotificationToken.ToListAsync();
        sendMobileNotification(tokens, notification);
        return RedirectToAction("Index");
            }
            return View(notification);
        }

        // GET: Notifications1/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notification notification = await db.Notifications.FindAsync(id);
            if (notification == null)
            {
                return HttpNotFound();
            }
            return View(notification);
        }

        // POST: Notifications1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Notification notification = await db.Notifications.FindAsync(id);
            db.Notifications.Remove(notification);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
