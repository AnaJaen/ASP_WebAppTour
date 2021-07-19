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
    
    public class TreffpunktController : Controller
    {
        private Tour_DBEntities db = new Tour_DBEntities();

        // GET: Treffpunkt
       
        public ActionResult Index(string suchtour)
        {
            var treffpunkts = db.Treffpunkts.Include(t => t.Buchung).Include(t => t.Tour);
            if (!String.IsNullOrEmpty(suchtour))
            {
                treffpunkts = treffpunkts.Where(t => t.T_To_Tour_Id.ToString() == suchtour);
                ViewBag.suchtouranzeige = "Treffpunkt nur von " + suchtour;
            }
            ViewBag.suchtour = new SelectList(db.Tours, "To_Tour_Id", "To_Bezeichnung");
            return View(treffpunkts.ToList());
        }


        // GET: Treffpunkt/Details/5
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treffpunkt treffpunkt = db.Treffpunkts.Find(id);
            if (treffpunkt == null)
            {
                return HttpNotFound();
            }
            return View(treffpunkt);
        }

        // GET: Treffpunkt/Create
        [Authorize(Users = "Jaen")]
        public ActionResult Create()
        {
            ViewBag.T_B_Buchung_Id = new SelectList(db.Buchungs, "B_Buchung_Id", "B_Preis");
            ViewBag.T_To_Tour_Id = new SelectList(db.Tours, "To_Tour_Id", "To_Bezeichnung");
            return View();
        }

        // POST: Treffpunkt/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "T_Treffpunkt_Id,T_Strasse,T_Hausnr,T_Ort,T_PLZ,T_B_Buchung_Id,T_To_Tour_Id")] Treffpunkt treffpunkt)
        {
            if (ModelState.IsValid)
            {
                db.Treffpunkts.Add(treffpunkt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.T_B_Buchung_Id = new SelectList(db.Buchungs, "B_Buchung_Id", "B_Preis", treffpunkt.T_B_Buchung_Id);
            ViewBag.T_To_Tour_Id = new SelectList(db.Tours, "To_Tour_Id", "To_Bezeichnung", treffpunkt.T_To_Tour_Id);
            return View(treffpunkt);
        }

        // GET: Treffpunkt/Edit/5
        [Authorize(Users = "Jaen")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treffpunkt treffpunkt = db.Treffpunkts.Find(id);
            if (treffpunkt == null)
            {
                return HttpNotFound();
            }
            ViewBag.T_B_Buchung_Id = new SelectList(db.Buchungs, "B_Buchung_Id", "B_Preis", treffpunkt.T_B_Buchung_Id);
            ViewBag.T_To_Tour_Id = new SelectList(db.Tours, "To_Tour_Id", "To_Bezeichnung", treffpunkt.T_To_Tour_Id);
            return View(treffpunkt);
        }

        // POST: Treffpunkt/Edit/5
      
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "T_Treffpunkt_Id,T_Strasse,T_Hausnr,T_Ort,T_PLZ,T_B_Buchung_Id,T_To_Tour_Id")] Treffpunkt treffpunkt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(treffpunkt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.T_B_Buchung_Id = new SelectList(db.Buchungs, "B_Buchung_Id", "B_Preis", treffpunkt.T_B_Buchung_Id);
            ViewBag.T_To_Tour_Id = new SelectList(db.Tours, "To_Tour_Id", "To_Bezeichnung", treffpunkt.T_To_Tour_Id);
            return View(treffpunkt);
        }

        // GET: Treffpunkt/Delete/5
        [Authorize(Users = "Jaen")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treffpunkt treffpunkt = db.Treffpunkts.Find(id);
            if (treffpunkt == null)
            {
                return HttpNotFound();
            }
            return View(treffpunkt);
        }

        // POST: Treffpunkt/Delete/5
       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Treffpunkt treffpunkt = db.Treffpunkts.Find(id);
            db.Treffpunkts.Remove(treffpunkt);
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
