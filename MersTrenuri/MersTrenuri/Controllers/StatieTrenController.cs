using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MersTrenuri.DAL;
using MersTrenuri.Models;

namespace MersTrenuri.Controllers
{
    public class StatieTrenController : Controller
    {
        private Context db = new Context();

        // GET: StatieTren
        public ActionResult Index()
        {
            var statiiTren = db.StatiiTren.Include(s => s.Gara).Include(s => s.Tren);
            return View(statiiTren.ToList());
        }

        // GET: StatieTren/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatieTren statieTren = db.StatiiTren.Find(id);
            if (statieTren == null)
            {
                return HttpNotFound();
            }
            return View(statieTren);
        }

        // GET: StatieTren/Create
        public ActionResult Create()
        {
            ViewBag.GaraID = new SelectList(db.Gari, "ID", "Nume");
            ViewBag.TrenID = new SelectList(db.Trenuri, "ID", "Rang");
            return View();
        }

        // POST: StatieTren/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,TrenID,GaraID,OraSosire,OraPlecare")] StatieTren statieTren)
        public ActionResult Create([Bind(Include = "TrenID,GaraID,OraSosire,OraPlecare")] StatieTren statieTren)
        {
            //try
            //{
                if (ModelState.IsValid)
                {
                    db.StatiiTren.Add(statieTren);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            //}
            //catch (DataException /* dex */)
            //{
            //    //Log the error (uncomment dex variable name and add a line here to write a log.
            //    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            //}
            ViewBag.GaraID = new SelectList(db.Gari, "ID", "Nume", statieTren.GaraID);
            ViewBag.TrenID = new SelectList(db.Trenuri, "ID", "Rang", statieTren.TrenID);
            return View(statieTren);
        }

        // GET: StatieTren/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatieTren statieTren = db.StatiiTren.Find(id);
            if (statieTren == null)
            {
                return HttpNotFound();
            }
            ViewBag.GaraID = new SelectList(db.Gari, "ID", "Nume", statieTren.GaraID);
            ViewBag.TrenID = new SelectList(db.Trenuri, "ID", "Rang", statieTren.TrenID);
            return View(statieTren);
        }

        // POST: StatieTren/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TrenID,GaraID,OraSosire,OraPlecare")] StatieTren statieTren)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statieTren).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GaraID = new SelectList(db.Gari, "ID", "Nume", statieTren.GaraID);
            ViewBag.TrenID = new SelectList(db.Trenuri, "ID", "Rang", statieTren.TrenID);
            return View(statieTren);
        }

        // GET: StatieTren/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatieTren statieTren = db.StatiiTren.Find(id);
            if (statieTren == null)
            {
                return HttpNotFound();
            }
            return View(statieTren);
        }

        // POST: StatieTren/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StatieTren statieTren = db.StatiiTren.Find(id);
            db.StatiiTren.Remove(statieTren);
            db.SaveChanges();
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
