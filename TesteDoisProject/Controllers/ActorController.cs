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
    public class ActorController : Controller
    {
        private DefaultContext db = new DefaultContext();

        //
        // GET: /Actor/

        public ActionResult Index()
        {
            return View(db.actores.ToList());
        }

        //
        // GET: /Actor/Details/5

        public ActionResult Details(int id = 0)
        {
            Actor actor = db.actores.Find(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        //
        // GET: /Actor/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Actor/Create

        [HttpPost]
        public ActionResult Create(Actor actor)
        {
            if (ModelState.IsValid)
            {
                db.actores.Add(actor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(actor);
        }

        //
        // GET: /Actor/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Actor actor = db.actores.Find(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        //
        // POST: /Actor/Edit/5

        [HttpPost]
        public ActionResult Edit(Actor actor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(actor);
        }

        //
        // GET: /Actor/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Actor actor = db.actores.Find(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        //
        // POST: /Actor/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Actor actor = db.actores.Find(id);
            db.actores.Remove(actor);
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