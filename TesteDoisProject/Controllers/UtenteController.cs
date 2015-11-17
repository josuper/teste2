using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteDoisProject.Models;

namespace TesteDoisProject.Controllers
{
    public class UtenteController : Controller
    {
        private DefaultContext db = new DefaultContext();

        //
        // GET: /Utente/

        public ActionResult Index()
        {
            return View(db.utentes.ToList());
        }

        //
        // GET: /Utente/Details/5

        public ActionResult Details(int id = 0)
        {
            Utente utente = db.utentes.Find(id);
            if (utente == null)
            {
                return HttpNotFound();
            }
            return View(utente);
        }

        //
        // GET: /Utente/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Utente/Create

        [HttpPost]
        public ActionResult Create(Utente utente)
        {
            if (ModelState.IsValid)
            {
                db.utentes.Add(utente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(utente);
        }

        //
        // GET: /Utente/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Utente utente = db.utentes.Find(id);
            if (utente == null)
            {
                return HttpNotFound();
            }
            return View(utente);
        }

        //
        // POST: /Utente/Edit/5

        [HttpPost]
        public ActionResult Edit(Utente utente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(utente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(utente);
        }

        //
        // GET: /Utente/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Utente utente = db.utentes.Find(id);
            if (utente == null)
            {
                return HttpNotFound();
            }
            return View(utente);
        }

        //
        // POST: /Utente/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Utente utente = db.utentes.Find(id);
            db.utentes.Remove(utente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}