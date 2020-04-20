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
    public class FelhasznalokController : Controller
    {
        private TeendokContext db = new TeendokContext();

        // GET: Felhasznalok
        public ActionResult Index()
        {
            return View(db.felhasznalo.ToList());
        }

        // GET: Felhasznalok/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    felhasznalo felhasznalo = db.felhasznalo.Find(id);
        //    if (felhasznalo == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(felhasznalo);
        //}

        // GET: Felhasznalok/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Felhasznalok/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FelhasznaloNev,Jelszo")] felhasznalo felhasznalo)
        {
            if (ModelState.IsValid)
            {
                felhasznalo.Jelszo = Hash.Encrypt(felhasznalo.Jelszo);
                db.felhasznalo.Add(felhasznalo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(felhasznalo);
        }

        // GET: Felhasznalok/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Felhasznalok/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FelhasznaloNev,Jelszo")] felhasznalo felhasznalo)
        {
            if (ModelState.IsValid)
            {
                felhasznalo.Jelszo = Hash.Encrypt(felhasznalo.Jelszo);
                db.Entry(felhasznalo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(felhasznalo);
        }

        // GET: Felhasznalok/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Felhasznalok/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
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
