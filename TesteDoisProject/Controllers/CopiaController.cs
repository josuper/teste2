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
    public class CopiaController : Controller
    {
        private DefaultContext db = new DefaultContext();

        //
        // GET: /Copia/

        public ActionResult Index()
        {
            var copias = db.copias.Include(c => c.Filme).Include(c => c.Estado);

            

            return View(copias.ToList());
        }

        public ActionResult QuantidadeBoas(int id=0) 
        {
            //ViewBag.QuantidadeBoas = db.copias.Where(s => s.EstadoID == 1 && s.FilmeID==1).Count();

            return View(db.copias.Where(s => s.EstadoID == 1 && s.FilmeID == 1).Count());
        }

        //
        // GET: /Copia/Details/5

        public ActionResult Details(int id = 0)
        {
            Copia copia = db.copias.Find(id);
            if (copia == null)
            {
                return HttpNotFound();
            }
            return View(copia);
        }

        //
        // GET: /Copia/Create

        public ActionResult Create()
        {
            ViewBag.FilmeID = new SelectList(db.filmes, "FilmeID", "Titulo");
            ViewBag.EstadoID = new SelectList(db.estados, "EstadoID", "Designacao");
            return View();
        }

        //
        // POST: /Copia/Create

        [HttpPost]
        public ActionResult Create(Copia copia)
        {
            if (ModelState.IsValid)
            {
                db.copias.Add(copia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FilmeID = new SelectList(db.filmes, "FilmeID", "Titulo", copia.FilmeID);
            ViewBag.EstadoID = new SelectList(db.estados, "EstadoID", "Designacao", copia.EstadoID);
            return View(copia);
        }

        //
        // GET: /Copia/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Copia copia = db.copias.Find(id);
            if (copia == null)
            {
                return HttpNotFound();
            }
            ViewBag.FilmeID = new SelectList(db.filmes, "FilmeID", "Titulo", copia.FilmeID);
            ViewBag.EstadoID = new SelectList(db.estados, "EstadoID", "Designacao", copia.EstadoID);
            return View(copia);
        }

        //
        // POST: /Copia/Edit/5

        [HttpPost]
        public ActionResult Edit(Copia copia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(copia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FilmeID = new SelectList(db.filmes, "FilmeID", "Titulo", copia.FilmeID);
            ViewBag.EstadoID = new SelectList(db.estados, "EstadoID", "Designacao", copia.EstadoID);
            return View(copia);
        }

        public ActionResult EditEstado(int id = 0)
        {
            Copia copia = db.copias.Find(id);
            if (copia == null)
            {
                return HttpNotFound();
            }
            ViewBag.FilmeID = new SelectList(db.filmes, "FilmeID", "Titulo", copia.FilmeID);
            ViewBag.EstadoID = new SelectList(db.estados, "EstadoID", "Designacao", copia.EstadoID);
            return View(copia);
        }

        
        [HttpPost]
        public ActionResult EditEstado(Copia copia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(copia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Emprestimo");
            }
            ViewBag.FilmeID = new SelectList(db.filmes, "FilmeID", "Titulo", copia.FilmeID);
            ViewBag.EstadoID = new SelectList(db.estados, "EstadoID", "Designacao", copia.EstadoID);
            return View(copia);
        }
        //
        // GET: /Copia/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Copia copia = db.copias.Find(id);
            if (copia == null)
            {
                return HttpNotFound();
            }
            return View(copia);
        }

        //
        // POST: /Copia/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Copia copia = db.copias.Find(id);
            db.copias.Remove(copia);
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