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
    public class RezervareController : Controller
    {
        private Context db = new Context();

        // GET: Rezervari
        public ActionResult Index()
        {
            return View(db.Rezervari.ToList());
        }

        // GET: Rezervare/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezervare rezervare = db.Rezervari.Find(id);
            if (rezervare == null)
            {
                return HttpNotFound();
            }
            return View(rezervare);
        }

        // GET: Rezervare/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rezervare/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,Nume")] Gara gara)
        public ActionResult Create([Bind(Include = "FirstName")] Rezervare rezervare)
        {
            //try
            //{
            if (ModelState.IsValid)
                {
                    db.Rezervari.Add(rezervare);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            //}
            //catch (DataException /* dex */)
            //{
            //    //Log the error (uncomment dex variable name and add a line here to write a log.
            //    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            //}
            return View(rezervare);
        }

        // GET: Rezervare/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezervare rezervare = db.Rezervari.Find(id);
            if (rezervare == null)
            {
                return HttpNotFound();
            }
            return View(rezervare);
        }

        // POST: Rezervare/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName")] Rezervare rezervare)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rezervare).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rezervare);
        }

        // GET: Rezervare/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezervare rezervare = db.Rezervari.Find(id);
            if (rezervare == null)
            {
                return HttpNotFound();
            }
            return View(rezervare);
        }

        // POST: Rezervare/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rezervare rezervare = db.Rezervari.Find(id);
            db.Rezervari.Remove(rezervare);
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
