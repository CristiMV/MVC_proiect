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

            ViewBag.SearchString1Parm = searchString1;
            ViewBag.SearchString2Parm = searchString2;

            var statiiTren = db.StatiiTren.Include(s => s.Gara).Include(s => s.Tren);

            //IQueryable<StatieTren> empty = Enumerable.Empty<StatieTren>() .AsQueryable();
            var emptyIE = Enumerable.Empty<StatieTren>();
            

            if (String.IsNullOrEmpty(searchString1))    //daca NU s-a introdus prima gara
            {
                return View(emptyIE);    //return View(Enumerable.Empty<StatieTren>());
                //return View(new List<StatieTren>());

                //return View(statiiTren2.OrderBy(s => s.OraSosire).ToList());
            }

            //else          //avem PRIMA GARA

            var statiiTren1 = statiiTren.Where(s => s.Gara.Nume == searchString1);

            if (String.IsNullOrEmpty(searchString2))    //daca NU avem gara 2
            {
                //return View(statiiTren1.OrderBy(s => s.OraSosire).ToList());    //returneaza trenurile pt gara 1 (ord dupa Ora Sosirii)
                return View(statiiTren1.OrderBy(s => sortOrder== "OraPlecare" ? s.OraPlecare : s.OraSosire).ToList());
            }

            //else          //avem AMBELE gari
            
            var statiiTren2 = statiiTren.Where(s => s.Gara.Nume == searchString2);

            if (sortOrder == "OraSosire")
            {
                statiiTren2 = statiiTren2.OrderBy(s => s.OraSosire);
            }
            else
            {
                statiiTren1 = statiiTren1.OrderBy(s => s.OraPlecare).AsQueryable();     //ordonare dupa Ora Plecarii
            }
            IEnumerable<StatieTren> statiiT1 = statiiTren1.Where(s1 => statiiTren2.Where(s2 => s2.TrenID == s1.TrenID && s1.NrSt < s2.NrSt).Any());
            IEnumerable<StatieTren> statiiT2 = statiiTren2.Where(s2 => statiiT1.Where(s1 => s1.TrenID == s2.TrenID).Any());

            int len = statiiT1.Count();

            StatieTren[] rez = new StatieTren[2*len];               //var rez = emptyIE;
            int i = 0;


            if (sortOrder == "OraSosire")
            {
                for (i = 0; i < len; ++i)
                {
                    rez[2 * i + 1] = statiiT2.ElementAt(i);
                    rez[2 * i] = statiiT1.Where(s => s.TrenID == rez[2 * i + 1].TrenID).First();
                }
                return View(rez);
            }
            //else          //ord dupa OraPlecare

            for (i = 0; i < len; ++i)
            {
                rez[2 * i] = statiiT1.ElementAt(i);
                rez[2 * i + 1] = statiiT2.Where(s => s.TrenID == rez[2 * i].TrenID).First();
                ////rez[2 * i + 1] = statiiT2.ElementAt(i);
                ////rez[2 * i + 1] = statiiTren2.Where(s => s.TrenID == rez[2*i].TrenID).First();
            }


            //foreach (var t1 in statiiT1)
            //{
            //    //rez[2 * i] = t1;
            //    //rez[2 * i + 1] = statiiT2.ElementAt(i);
            //    //++i;
            //    rez[i++] = t1;    //debuging
            //}

            //statiiTren = rez.AsQueryable();     return View(statiiTren.ToList());
            return View(rez);       //return View(rez.AsQueryable().ToList());
            //if (!String.IsNullOrEmpty(searchString2))   //daca s-a introdus a 2-a gara
            //{
            //    statiiTren2 = statiiTren.Where(s => s.Gara.Nume == searchString2);

            //    if (statiiTren1 == empty) { return View(statiiTren2.OrderBy(s => s.OraSosire).ToList()); }

            //    var rez = Enumerable.Empty<StatieTren>();

            //    int[] ids = new int[statiiTren1.Count()];   //va retine id-urile trenurilor care trec prin Gara 1
            //    int[] nrs = new int[ids.Length];

            //    int i = 0;
            //    foreach (var st in statiiTren1)
            //    {
            //        ids[i] = st.TrenID;
            //        nrs[i++] = st.NrSt;
            //    }

            //    IQueryable<StatieTren> j = Enumerable.Empty<StatieTren>().AsQueryable();
            //    i = 0;
            //    foreach (var id in ids)
            //    {
            //        j = statiiTren2.Where(s => (s.TrenID == id));
            //        if (j.Any() && nrs[i++] < j.First().NrSt)
            //        {
            //            rez = rez.Concat(statiiTren1.Where(s => (s.TrenID == id))).Concat(j);
            //        }
            //    }

            //    statiiTren = rez.AsQueryable();
            //}
            //else { statiiTren = statiiTren1; }  //daca nu s-a introdus a doua gara (si nici prima (statiiTren1 este empty))

            //return View(statiiTren.ToList());
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
