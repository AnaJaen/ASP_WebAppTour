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
    [Authorize (Users ="Jaen")]
    public class BuchungController : Controller
    {

        private Tour_DBEntities db = new Tour_DBEntities();

        // GET: Buchung
        public ActionResult Index(int? suchkunde, int? suchtour)
        {
            
            var buchungs = db.Buchungs.Include(b => b.Fremdenfuehrer).Include(b => b.Kunde).Include(b => b.Sprache).Include(b => b.Tour).Include(b => b.Treffpunkt);
           if (suchkunde != null)
            {
                buchungs = buchungs.Where(b => b.B_K_Kunde_Id == suchkunde);
                ViewBag.suchkundenanzeige = "Buchungen nur von " + suchkunde;
            }
            if (suchtour != null)
            {
                buchungs = buchungs.Where(b => b.Tour.To_Tour_Id == suchtour);
            }
            ViewBag.suchkunde = new SelectList(db.Kundes, "K_Kunde_Id", "K_Vorname");
            ViewBag.suchtour = new SelectList(db.Tours, "To_Tour_Id", "To_Bezeichnung");
            return View(buchungs.ToList());
        }

        // GET: Buchung/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Buchung buchung = db.Buchungs.Find(id);
            if (buchung == null)
            {
                return HttpNotFound();
            }
            return View(buchung);
        }

        // GET: Buchung/Create
        public ActionResult Create()
        {
            ViewBag.B_F_Fremdenfuehrer_Id = new SelectList(db.Fremdenfuehrers, "F_Fremdenfuehrer_Id", "F_Vorname");
            ViewBag.B_K_Kunde_Id = new SelectList(db.Kundes, "K_Kunde_Id", "K_Vorname");
            ViewBag.B_S_Sprach_Id = new SelectList(db.Spraches, "S_Sprach_Id", "S_Language");
            ViewBag.B_To_Tour_Id = new SelectList(db.Tours, "To_Tour_Id", "To_Bezeichnung");
            ViewBag.B_T_Treffpunkt_Id = new SelectList(db.Treffpunkts, "T_Treffpunkt_Id", "T_Strasse");
            return View();
        }

        // POST: Buchung/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "B_Buchung_Id,B_Datum,B_Personenanzahl,B_Preis,B_K_Kunde_Id,B_To_Tour_Id,B_F_Fremdenfuehrer_Id,B_S_Sprach_Id,B_T_Treffpunkt_Id")] Buchung buchung)
        {
            if (ModelState.IsValid)
            {
                db.Buchungs.Add(buchung);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.B_F_Fremdenfuehrer_Id = new SelectList(db.Fremdenfuehrers, "F_Fremdenfuehrer_Id", "F_Vorname", buchung.B_F_Fremdenfuehrer_Id);
            ViewBag.B_K_Kunde_Id = new SelectList(db.Kundes, "K_Kunde_Id", "K_Vorname", buchung.B_K_Kunde_Id);
            ViewBag.B_S_Sprach_Id = new SelectList(db.Spraches, "S_Sprach_Id", "S_Language", buchung.B_S_Sprach_Id);
            ViewBag.B_To_Tour_Id = new SelectList(db.Tours, "To_Tour_Id", "To_Bezeichnung", buchung.B_To_Tour_Id);
            ViewBag.B_T_Treffpunkt_Id = new SelectList(db.Treffpunkts, "T_Treffpunkt_Id", "T_Strasse", buchung.B_T_Treffpunkt_Id);
            return View(buchung);
        }

        // GET: Buchung/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Buchung buchung = db.Buchungs.Find(id);
            if (buchung == null)
            {
                return HttpNotFound();
            }
            ViewBag.B_F_Fremdenfuehrer_Id = new SelectList(db.Fremdenfuehrers, "F_Fremdenfuehrer_Id", "F_Vorname", buchung.B_F_Fremdenfuehrer_Id);
            ViewBag.B_K_Kunde_Id = new SelectList(db.Kundes, "K_Kunde_Id", "K_Vorname", buchung.B_K_Kunde_Id);
            ViewBag.B_S_Sprach_Id = new SelectList(db.Spraches, "S_Sprach_Id", "S_Language", buchung.B_S_Sprach_Id);
            ViewBag.B_To_Tour_Id = new SelectList(db.Tours, "To_Tour_Id", "To_Bezeichnung", buchung.B_To_Tour_Id);
            ViewBag.B_T_Treffpunkt_Id = new SelectList(db.Treffpunkts, "T_Treffpunkt_Id", "T_Strasse", buchung.B_T_Treffpunkt_Id);
            return View(buchung);
        }

        // POST: Buchung/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "B_Buchung_Id,B_Datum,B_Personenanzahl,B_Preis,B_K_Kunde_Id,B_To_Tour_Id,B_F_Fremdenfuehrer_Id,B_S_Sprach_Id,B_T_Treffpunkt_Id")] Buchung buchung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buchung).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.B_F_Fremdenfuehrer_Id = new SelectList(db.Fremdenfuehrers, "F_Fremdenfuehrer_Id", "F_Vorname", buchung.B_F_Fremdenfuehrer_Id);
            ViewBag.B_K_Kunde_Id = new SelectList(db.Kundes, "K_Kunde_Id", "K_Vorname", buchung.B_K_Kunde_Id);
            ViewBag.B_S_Sprach_Id = new SelectList(db.Spraches, "S_Sprach_Id", "S_Language", buchung.B_S_Sprach_Id);
            ViewBag.B_To_Tour_Id = new SelectList(db.Tours, "To_Tour_Id", "To_Bezeichnung", buchung.B_To_Tour_Id);
            ViewBag.B_T_Treffpunkt_Id = new SelectList(db.Treffpunkts, "T_Treffpunkt_Id", "T_Strasse", buchung.B_T_Treffpunkt_Id);
            return View(buchung);
        }

        // GET: Buchung/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Buchung buchung = db.Buchungs.Find(id);
            if (buchung == null)
            {
                return HttpNotFound();
            }
            return View(buchung);
        }

        // POST: Buchung/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Buchung buchung = db.Buchungs.Find(id);
            db.Buchungs.Remove(buchung);
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
