using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using TeendokListaWeb.Models;

namespace TeendokListaWeb.Controllers
{
    public class FeladatController : Controller
    {
        private TeendokContext db = new TeendokContext();

        // GET: Feladat
        public ActionResult Index()
        {
            var feladatok = db.feladat.Include(f => f.felhasznalo);
            // RTF-ből szöveg kinyerése
            // A fontstílus megjelenítése így elveszik
            using (var rtfControl = new RichTextBox())
            {
                foreach (var feladat in feladatok)
                {

                    rtfControl.Rtf = feladat.szoveg;
                    feladat.szoveg = rtfControl.Text;
                }
            }
            
            return View(feladatok.ToList());
        }

        // GET: Feladat/Reszletek/5
        public ActionResult Reszletek(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            feladat feladat = db.feladat.Find(id);
            if (feladat == null)
            {
                return HttpNotFound();
            }
            using (var rtfControl = new RichTextBox())
            {
                rtfControl.Rtf = feladat.szoveg;
                feladat.szoveg = rtfControl.Text;
            }
            return View(feladat);
        }

        // GET: Feladat/Letrehozas
        public ActionResult Letrehozas()
        {
            ViewBag.felhasznalo_id = new SelectList(db.felhasznalo, "id", "felhasznalonev");
            return View();
        }

        // POST: Feladat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Letrehozas([Bind(Include = "id,cim,szoveg,teljesitve,felhasznalo_id")] feladat feladat)
        {
            feladat.letrehozas_datum = DateTime.Now;
            // RTF átalakítás
            using (var rtfControl = new RichTextBox())
            {
                rtfControl.Text = feladat.szoveg;
                feladat.szoveg = rtfControl.Rtf;
            }
            if (ModelState.IsValid)
            {
                db.feladat.Add(feladat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.felhasznalo_id = new SelectList(db.felhasznalo, "id", "felhasznalonev", feladat.felhasznalo_id);
            return View(feladat);
        }

        // GET: Feladat/Szerkesztes/5
        public ActionResult Szerkesztes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            feladat feladat = db.feladat.Find(id);
            if (feladat == null)
            {
                return HttpNotFound();
            }
            ViewBag.felhasznalo_id = new SelectList(db.felhasznalo, "id", "felhasznalonev", feladat.felhasznalo_id);
            return View(feladat);
        }

        // POST: Feladat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Szerkesztes([Bind(Include = "id,cim,szoveg,teljesitve,felhasznalo_id")] feladat feladat)
        {
            feladat.letrehozas_datum = DateTime.Now;
            using (var rtfControl = new RichTextBox())
            {
                rtfControl.Text = feladat.szoveg;
                feladat.szoveg = rtfControl.Rtf;
            }
            if (ModelState.IsValid)
            {
                db.Entry(feladat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.felhasznalo_id = new SelectList(db.felhasznalo, "id", "felhasznalonev", feladat.felhasznalo_id);
            return View(feladat);
        }

        // GET: Feladat/Torles/5
        public ActionResult Torles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            feladat feladat = db.feladat.Find(id);
            if (feladat == null)
            {
                return HttpNotFound();
            }
            using (var rtfControl = new RichTextBox())
            {
                rtfControl.Rtf = feladat.szoveg;
                feladat.szoveg = rtfControl.Text;
            }
            return View(feladat);
        }

        // POST: Feladat/Torles/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Torles(int id)
        {
            feladat feladat = db.feladat.Find(id);
            db.feladat.Remove(feladat);
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
