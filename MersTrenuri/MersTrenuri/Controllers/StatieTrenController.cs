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

        //public ActionResult Index()
        //{
        //    var statiiTren = db.StatiiTren.Include(s => s.Gara).Include(s => s.Tren);
        //    return View(statiiTren.ToList());
        //}


        public ViewResult Index(/*string sortOrder,*/ string searchString1, string searchString2)
        {
            //ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";    //ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            //var statiiTren = from s in db.StatiiTren            //select s;

            var statiiTren = db.StatiiTren.Include(s => s.Gara).Include(s => s.Tren);
            IQueryable<StatieTren> empty = Enumerable.Empty<StatieTren>().AsQueryable();
            var statiiTren1 = empty;
            //var statiiTren2 = statiiTren;
            var statiiTren2 = empty;
            //var gari = from g in db.Gari //select g;
            if (!String.IsNullOrEmpty(searchString1))
            {
                //gari = gari.Where(g => g.Nume == searchString1);    
                statiiTren1 = statiiTren.Where(s => s.Gara.Nume == searchString1 );
                //statiiTren = db.StatiiTren.Include(s => gari.Contains(s.Gara)).Include(s => s.Tren); //statiiTren = db.StatiiTren.Include(s => s.Gara.ID == gari.First().ID).Include(s => s.Tren);
            }

            if (!String.IsNullOrEmpty(searchString2))
            {
                statiiTren2 = statiiTren.Where(s => s.Gara.Nume == searchString2);

                //var rez = statiiTren1.Join(statiiTren2.AsEnumerable(), st1 => st1.TrenID, st2 => st2.TrenID, (st1, st2) => new { st1, st2 });
                //foreach (var obj in rez){ Console.WriteLine("{0} - {1}", obj.st1, obj.st2); }     //return View(rez.ToList());
                //Console.WriteLine("Hello World!"); //Console.Write(statiiTren);

                if (statiiTren1 == empty) { return View(statiiTren2.ToList()); }
                
                var rez = Enumerable.Empty<StatieTren>();           //var rez = Enumerable.Empty<StatieTren>().AsQueryable();

                IQueryable<StatieTren> j = Enumerable.Empty<StatieTren>().AsQueryable();
                int[] ids = new int[statiiTren1.Count()];   //va retine id-urile trenurilor care trec prin Gara 1
                //DateTime[] oraP = new DateTime[statiiTren1.Count()];
                DateTime[] oraS = new DateTime[statiiTren1.Count()];

                int i = 0;
                foreach (var st in statiiTren1)
                {
                    ids[i] = st.TrenID;
                    //oraP[i++] = st.OraPlecare;
                    oraS[i++] = st.OraSosire;
                }

                i = 0;
                foreach (var id in ids)
                {
                    j = statiiTren2.Where(s => (s.TrenID == id));   
                    //if (j.Any() && oraP[i++]<j.First().OraSosire)    //daca exista tren care trece prin Gara 2 cu id-ul trenului curent din Gara 1 si cu ora de sosire mai mare decat cea din Gara 1
                    if ( j.Any() && oraS[i++]<j.First().OraSosire )
                    {
                        rez = rez.Concat( statiiTren1.Where(s => (s.TrenID == id)) ).Concat(j);
                    }
                }

                //foreach (var i in statiiTren1)
                //{
                //    j = statiiTren2.Where(s => (s.TrenID == i.TrenID));     //IQueryable<StatieTren> j = statiiTren2.Where(s => (s.TrenID == i.TrenID));
                
                //    //var lempty = empty.ToList();  //var lj = j.ToList();
                //    //if ( ! lt.Equals(lempty) )
                //    //if (! j.Equals(empty))
                //    if (j.Any())  // if ( j.Count() > 0 )
                //    {
                //        StatieTren[] vi = { i };
                //        rez = rez.Concat(vi).Concat(j);
                //    }
                //    //foreach (var j in statiiTren2) {
                //    //    if (i.TrenID == j.TrenID) {
                //    //        StatieTren[] ij = { i, j }; rez = rez.Concat(ij);
                //    //    }
                //    //}
                //}
                //statiiTren = rez;
                statiiTren = rez.AsQueryable();
            }
            else { statiiTren = statiiTren1; }

                //switch (sortOrder)//{
                //    case "name_desc": //statiiTren = statiiTren.OrderByDescending(s => s.LastName;//        break;
                //    case "Date": //statiiTren = statiiTren.OrderBy(s => s.EnrollmentDate;//        break;
                //    case "date_desc": //statiiTren = statiiTren.OrderByDescending(s => s.EnrollmentDate);//        break;
                //    default: //statiiTren = statiiTren.OrderBy(s => s.LastName);//        break;
                //}

                return View( statiiTren.ToList() );
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
