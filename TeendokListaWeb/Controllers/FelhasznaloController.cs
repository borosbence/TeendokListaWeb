using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TeendokListaWeb.Models;
using TeendokListaWeb.Services;

namespace TeendokListaWeb.Controllers
{
    public class FelhasznaloController : Controller
    {
        private TeendokContext db = new TeendokContext();

        // GET: Felhasznalo
        public ActionResult Index()
        {
            return View(db.felhasznalo.ToList());
        }

        // GET: Felhasznalo/Reszletek/5
        public ActionResult Reszletek(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            felhasznalo felhasznalo = db.felhasznalo.Find(id);
            if (felhasznalo == null)
            {
                return HttpNotFound();
            }

            ViewBag.FeladatCount = felhasznalo.feladat.Count;
            return View(felhasznalo);
        }

        // GET: Felhasznalo/Letrehozas
        public ActionResult Letrehozas()
        {
            return View();
        }

        // POST: Felhasznalo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Letrehozas([Bind(Include = "id,felhasznalonev,jelszo")] felhasznalo felhasznalo)
        {
            if (ModelState.IsValid)
            {
                // Ez abban az esetben működik, ha az utolsó elem nem volt kitörölve
                var salt = db.felhasznalo.Max(x => x.id) + 1; 
                felhasznalo.jelszo = Hash.Encrypt(felhasznalo.jelszo + salt);
                db.felhasznalo.Add(felhasznalo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(felhasznalo);
        }

        // GET: Felhasznalo/Szerkesztes/5
        public ActionResult Szerkesztes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            felhasznalo felhasznalo = db.felhasznalo.Find(id);
            if (felhasznalo == null)
            {
                return HttpNotFound();
            }
            felhasznalo.jelszo = null;
            return View(felhasznalo);
        }

        // POST: Felhasznalo/Szerkesztes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Szerkesztes([Bind(Include = "id,felhasznalonev,jelszo")] felhasznalo felhasznalo)
        {
            if (ModelState.IsValid)
            {
                felhasznalo.jelszo = Hash.Encrypt(felhasznalo.jelszo + felhasznalo.id);
                db.Entry(felhasznalo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(felhasznalo);
        }

        // GET: Felhasznalo/Torles/5
        public ActionResult Torles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            felhasznalo felhasznalo = db.felhasznalo.Find(id);
            if (felhasznalo == null)
            {
                return HttpNotFound();
            }
            return View(felhasznalo);
        }

        // POST: Felhasznalo/Torles/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Torles(int id)
        {
            felhasznalo felhasznalo = db.felhasznalo.Find(id);
            db.felhasznalo.Remove(felhasznalo);
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
