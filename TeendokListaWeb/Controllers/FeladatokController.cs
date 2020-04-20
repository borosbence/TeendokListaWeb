using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TeendokListaWeb.Models;

namespace TeendokListaWeb.Controllers
{
    public class FeladatokController : Controller
    {
        private TeendokContext db = new TeendokContext();

        // GET: Feladatok
        public ActionResult Index()
        {
            var feladat = db.feladat.Include(f => f.felhasznalo);
            return View(feladat.ToList());
        }

        // GET: Feladatok/Details/5
        public ActionResult Details(int? id)
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
            return View(feladat);
        }

        // GET: Feladatok/Create
        public ActionResult Create()
        {
            ViewBag.felhasznaloId = new SelectList(db.felhasznalo, "Id", "FelhasznaloNev");
            return View();
        }

        // POST: Feladatok/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cim,Szoveg,LetrehozasDatum,Teljesitve,felhasznaloId")] feladat feladat)
        {
            if (ModelState.IsValid)
            {
                db.feladat.Add(feladat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.felhasznaloId = new SelectList(db.felhasznalo, "Id", "FelhasznaloNev", feladat.felhasznaloId);
            return View(feladat);
        }

        // GET: Feladatok/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.felhasznaloId = new SelectList(db.felhasznalo, "Id", "FelhasznaloNev", feladat.felhasznaloId);
            return View(feladat);
        }

        // POST: Feladatok/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cim,Szoveg,LetrehozasDatum,Teljesitve,felhasznaloId")] feladat feladat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feladat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.felhasznaloId = new SelectList(db.felhasznalo, "Id", "FelhasznaloNev", feladat.felhasznaloId);
            return View(feladat);
        }

        // GET: Feladatok/Delete/5
        public ActionResult Delete(int? id)
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
            return View(feladat);
        }

        // POST: Feladatok/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
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
