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

namespace JabuBackendServer.Controllers
{
    public class Prayers1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Prayers1
        public async Task<ActionResult> Index()
        {
            return View(await db.Prayers.ToListAsync());
        }

        // GET: Prayers1/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prayer prayer = await db.Prayers.FindAsync(id);
            if (prayer == null)
            {
                return HttpNotFound();
            }
            return View(prayer);
        }

        // GET: Prayers1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prayers1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FirstName,Surname,Email,PhoneNumber,Description")] Prayer prayer)
        {
            if (ModelState.IsValid)
            {
                db.Prayers.Add(prayer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(prayer);
        }

        // GET: Prayers1/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prayer prayer = await db.Prayers.FindAsync(id);
            if (prayer == null)
            {
                return HttpNotFound();
            }
            return View(prayer);
        }

        // POST: Prayers1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FirstName,Surname,Email,PhoneNumber,Description")] Prayer prayer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prayer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(prayer);
        }

        // GET: Prayers1/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prayer prayer = await db.Prayers.FindAsync(id);
            if (prayer == null)
            {
                return HttpNotFound();
            }
            return View(prayer);
        }

        // POST: Prayers1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Prayer prayer = await db.Prayers.FindAsync(id);
            db.Prayers.Remove(prayer);
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
