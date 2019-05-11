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
    public class GaraController : Controller
    {
        private Context db = new Context();

        // GET: Gara
        public ActionResult Index()
        {
            return View(db.Gari.ToList());
        }

        // GET: Gara/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gara gara = db.Gari.Find(id);
            if (gara == null)
            {
                return HttpNotFound();
            }
            return View(gara);
        }

        // GET: Gara/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gara/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,Nume")] Gara gara)
        public ActionResult Create([Bind(Include = "Nume")] Gara gara)
        {
            //try
            //{
            if (ModelState.IsValid)
                {
                    db.Gari.Add(gara);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            //}
            //catch (DataException /* dex */)
            //{
            //    //Log the error (uncomment dex variable name and add a line here to write a log.
            //    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            //}
            return View(gara);
        }

        // GET: Gara/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gara gara = db.Gari.Find(id);
            if (gara == null)
            {
                return HttpNotFound();
            }
            return View(gara);
        }

        // POST: Gara/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nume")] Gara gara)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gara).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gara);
        }

        // GET: Gara/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gara gara = db.Gari.Find(id);
            if (gara == null)
            {
                return HttpNotFound();
            }
            return View(gara);
        }

        // POST: Gara/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gara gara = db.Gari.Find(id);
            db.Gari.Remove(gara);
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
