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
    public class CautareController : Controller
    {
        private Context db = new Context();

        // GET: Cautare

        //public ActionResult Index() //{
        //    var statiiTren = db.StatiiTren.Include(s => s.Gara).Include(s => s.Tren);
        //    return View(statiiTren.ToList());
        //}

        public ViewResult Index(string sortOrder, string searchString1, string searchString2)
        {
            ////ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //ViewBag.OraPlecareSortParm = String.IsNullOrEmpty(sortOrder) ? "oraPlecare_desc" : "";
            ////ViewBag.OraPlecareSortParm = (sortOrder == "OraPlecare") ? "oraPlecare_desc" : "OraPlecare";

            var statiiTren = db.StatiiTren.Include(s => s.Gara).Include(s => s.Tren);
            IQueryable<StatieTren> empty = Enumerable.Empty<StatieTren>().AsQueryable();
            var statiiTren1 = empty;    var statiiTren2 = empty;       //var statiiTren2 = statiiTren;

            if ( ! String.IsNullOrEmpty(searchString1))
            {
                statiiTren1 = statiiTren.Where(s => s.Gara.Nume == searchString1);
                //statiiTren1 = statiiTren1.OrderBy(s => s.OraPlecare);

                if (String.IsNullOrEmpty(searchString2)) { return View(statiiTren1.OrderBy(s => s.OraSosire).ToList()); }

                statiiTren1 = statiiTren1.OrderBy(s => s.OraPlecare);

                //switch (sortOrder) //{
                //    case "oraPlecare_desc":
                //        statiiTren1 = statiiTren1.OrderByDescending(s => s.OraPlecare);
                //        break;
                //    case "OraPlecare":
                //        statiiTren1 = statiiTren1.OrderBy(s => s.OraPlecare);
                //        break;
                //    default:
                //        statiiTren1 = statiiTren1.OrderBy(s => s.OraPlecare);
                //        break;
                //}
            }

            if ( ! String.IsNullOrEmpty(searchString2))
            {
                statiiTren2 = statiiTren.Where(s => s.Gara.Nume == searchString2);

                if (statiiTren1 == empty) { return View(statiiTren2.OrderBy(s=>s.OraSosire).ToList()); }

                var rez = Enumerable.Empty<StatieTren>();
                
                int[] ids = new int[statiiTren1.Count()];   //va retine id-urile trenurilor care trec prin Gara 1
                int[] nrs = new int[ids.Length];

                int i = 0;
                foreach (var st in statiiTren1)
                {
                    ids[i] = st.TrenID;
                    nrs[i++] = st.NrSt;
                }

                IQueryable<StatieTren> j = Enumerable.Empty<StatieTren>().AsQueryable();
                i = 0;
                foreach (var id in ids)
                {
                    j = statiiTren2.Where(s => (s.TrenID == id));
                    if (j.Any()  &&  nrs[i++] < j.First().NrSt )
                    {
                        rez = rez.Concat(statiiTren1.Where(s => (s.TrenID == id))).Concat(j);
                    }
                }

                statiiTren = rez.AsQueryable();
            }
            else { statiiTren = statiiTren1; }

            return View(statiiTren.ToList());
        }



        // GET: Cautare/Details/5
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //public ViewResult OGara(/*string sortOrder,*/ string searchString)
        //{
        //    //var statiiTren = db.StatiiTren.Include(s => s.Gara).Include(s => s.Tren);
        //    //statiiTren = statiiTren.Where(s => s.Gara.Nume == searchString);

        //    //var statiiTren = db.StatiiTren.Include(s => s.Gara).Include(s => s.Tren).Where(s => s.Gara.Nume == searchString);
        //    //return View(statiiTren.ToList());

        //    return View(db.StatiiTren.Include(s => s.Gara).Include(s => s.Tren).Where(s => s.Gara.Nume == searchString) );
        //}
    }
} //end namespace
