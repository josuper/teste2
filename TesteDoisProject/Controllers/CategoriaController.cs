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
    public class CategoriaController : Controller
    {
        private DefaultContext db = new DefaultContext();

        //
        // GET: /Categoria/

        public ActionResult Index()
        {
            return View(db.categorias.ToList());
        }

        //
        // GET: /Categoria/Details/5

        public ActionResult Details(int id = 0)
        {
            Categoria categoria = db.categorias.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        //
        // GET: /Categoria/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Categoria/Create

        [HttpPost]
        public ActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                db.categorias.Add(categoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        //
        // GET: /Categoria/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Categoria categoria = db.categorias.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        //
        // POST: /Categoria/Edit/5

        [HttpPost]
        public ActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        //
        // GET: /Categoria/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Categoria categoria = db.categorias.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        //
        // POST: /Categoria/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Categoria categoria = db.categorias.Find(id);
            db.categorias.Remove(categoria);
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