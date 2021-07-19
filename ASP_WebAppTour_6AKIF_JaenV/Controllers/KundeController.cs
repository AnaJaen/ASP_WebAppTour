using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASP_WebAppTour_6AKIF_JaenV.Models;

namespace ASP_WebAppTour_6AKIF_JaenV.Controllers
{
    [Authorize]
    public class KundeController : Controller
    {
        private Tour_DBEntities db = new Tour_DBEntities();

        // GET: Kunde
        public ActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.CitySortParm = String.IsNullOrEmpty(sortOrder) ? "city_desc" : "";
            var kundens = from k in db.Kundes
                          select k;
            switch (sortOrder)
            {
                case "name desc":
                    kundens = kundens.OrderByDescending(to => to.K_Vorname);
                    break;
                case "Date":
                    kundens = kundens.OrderByDescending(k => k.K_GebDatum);
                    break;
                case "date_desc":
                    kundens = kundens.OrderByDescending(k => k.K_GebDatum);
                    break;
                case "city_desc":
                    kundens = kundens.OrderByDescending(to => to.K_Ort);
                    break;
                default:
                    kundens = kundens.OrderBy(k => k.K_Vorname);
                    break;
            }
            return View(kundens.ToList());
        }

        // GET: Kunde/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kunde kunde = db.Kundes.Find(id);
            if (kunde == null)
            {
                return HttpNotFound();
            }
            return View(kunde);
        }

        // GET: Kunde/Create
        [Authorize (Users = "Jaen")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kunde/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "K_Kunde_Id,K_Vorname,K_Nachname,K_GebDatum,K_Strasse,K_Hausnr,K_Ort,K_Land,K_PLZ,K_Email")] Kunde kunde)
        {
            if (ModelState.IsValid)
            {
                db.Kundes.Add(kunde);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(kunde);
        }

        // GET: Kunde/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kunde kunde = db.Kundes.Find(id);
            if (kunde == null)
            {
                return HttpNotFound();
            }
            Session["lastkundeid"] = kunde.K_Kunde_Id;
            return View(kunde);
        }

        // POST: Kunde/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "K_Kunde_Id,K_Vorname,K_Nachname,K_GebDatum,K_Strasse,K_Hausnr,K_Ort,K_Land,K_PLZ,K_Email")] Kunde kunde)
        {
            kunde.K_Kunde_Id = (int)Session["lastkundeid"];
            if (ModelState.IsValid)
            {
                db.Entry(kunde).State = EntityState.Modified;
                db.SaveChanges();
                Session["lastkundeid"] = null;
                return RedirectToAction("Index");
            }
            return View(kunde);
        }

        // GET: Kunde/Delete/5
        [Authorize(Users = "Jaen")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kunde kunde = db.Kundes.Find(id);
            if (kunde == null)
            {
                return HttpNotFound();
            }
            return View(kunde);
        }

        // POST: Kunde/Delete/5
     
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kunde kunde = db.Kundes.Find(id);
            db.Kundes.Remove(kunde);
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
