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
    public class FremdenfuehrerController : Controller
    {
        
        private Tour_DBEntities db = new Tour_DBEntities();

        // GET: Fremdenfuehrer
        public ActionResult Index(string suchsprache) //(Datentyp namen des Parameters von Index View)
        {
            var fremdenfuehrers = db.Fremdenfuehrers.Include(f => f.Sprache);
            //Suche nach 1 Filter
            if (! String.IsNullOrEmpty (suchsprache))   /*anders geschrieben:if ( suchsprache !=null && suchsprache != "")*/
            fremdenfuehrers = fremdenfuehrers.Where(f => f.Sprache.S_Language.Contains(suchsprache));

            //Bsp. der Struktur der Suche nach 2 Filtern (Sprache und Nachname). In diesem Fall macht kein Sinn.
            //fremdenfuehrers = fremdenfuehrers.Where(f => f.Sprache.S_Language.Contains(suchsprache) ||
                                                         //f.F_Nachname.Contains(suchsprache));
            return View(fremdenfuehrers.ToList());

        }

        // GET: Fremdenfuehrer/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fremdenfuehrer fremdenfuehrer = db.Fremdenfuehrers.Find(id);
            if (fremdenfuehrer == null)
            {
                return HttpNotFound();
            }
            return View(fremdenfuehrer);
        }

        // GET: Fremdenfuehrer/Create
        [Authorize(Users = "Jaen")]
        public ActionResult Create()
        {
            ViewBag.F_S_Sprach_Id = new SelectList(db.Spraches, "S_Sprach_Id", "S_Language");
            return View();
        }

        // POST: Fremdenfuehrer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "F_Fremdenfuehrer_Id,F_Vorname,F_Nachname,F_S_Sprach_Id")] Fremdenfuehrer fremdenfuehrer)
        {
            if (ModelState.IsValid)
            {
                db.Fremdenfuehrers.Add(fremdenfuehrer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.F_S_Sprach_Id = new SelectList(db.Spraches, "S_Sprach_Id", "S_Language", fremdenfuehrer.F_S_Sprach_Id);
            return View(fremdenfuehrer);
        }

        // GET: Fremdenfuehrer/Edit/5
        [Authorize(Users = "Jaen")]
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fremdenfuehrer fremdenfuehrer = db.Fremdenfuehrers.Find(id);
            if (fremdenfuehrer == null)
            {
                return HttpNotFound();
            }
            ViewBag.F_S_Sprach_Id = new SelectList(db.Spraches, "S_Sprach_Id", "S_Language", fremdenfuehrer.F_S_Sprach_Id);
            return View(fremdenfuehrer);
        }

        // POST: Fremdenfuehrer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "F_Fremdenfuehrer_Id,F_Vorname,F_Nachname,F_S_Sprach_Id")] Fremdenfuehrer fremdenfuehrer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fremdenfuehrer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.F_S_Sprach_Id = new SelectList(db.Spraches, "S_Sprach_Id", "S_Language", fremdenfuehrer.F_S_Sprach_Id);
            return View(fremdenfuehrer);
        }

        // GET: Fremdenfuehrer/Delete/5
        [Authorize(Users = "Jaen")]
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fremdenfuehrer fremdenfuehrer = db.Fremdenfuehrers.Find(id);
            if (fremdenfuehrer == null)
            {
                return HttpNotFound();
            }
            return View(fremdenfuehrer);
        }

        // POST: Fremdenfuehrer/Delete/5
      
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            Fremdenfuehrer fremdenfuehrer = db.Fremdenfuehrers.Find(id);
            db.Fremdenfuehrers.Remove(fremdenfuehrer);
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
