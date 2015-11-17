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
    public class FilmeController : Controller
    {
        private DefaultContext db = new DefaultContext();

        //
        // GET: /Filme/

        public ActionResult Index()
        {
            var filmes = db.filmes.Include(f => f.Categoria).Include(f => f.Actor).Include(f => f.Autor);
            return View(filmes.ToList());
        }

        

        public ActionResult QuantidadeBoas(int id = 0)
        {
            //ViewBag.QuantidadeBoas = db.copias.Where(s => s.EstadoID == 1 && s.FilmeID==1).Count();
            @ViewBag.QuantidadeBoasViewBag = db.copias.Where(s => s.EstadoID == 1 && s.FilmeID == 1).Count();
            return View();
        }
        public ActionResult QuantidadeRazoaveis(int id = 0)
        {
 
            @ViewBag.QuantidadeRazoaveisViewBag = db.copias.Where(s => s.EstadoID == 3 && s.FilmeID == 1).Count();
            return View();
        }

        public ActionResult QuantidadeMas(int id = 0)
        {

            @ViewBag.QuantidadeMasViewBag = db.copias.Where(s => s.EstadoID == 2 && s.FilmeID == 1).Count();
            return View();
        }



        //
        // GET: /Filme/Details/5

        public ActionResult Details(int id = 0)
        {
            Filme filme = db.filmes.Find(id);
            if (filme == null)
            {
                return HttpNotFound();
            }
            return View(filme);
        }

        //
        // GET: /Filme/Create

        public ActionResult Create()
        {
            ViewBag.CategoriaID = new SelectList(db.categorias, "CategoriaID", "Designacao");
            ViewBag.ActorID = new SelectList(db.actores, "ActorID", "Nome");
            ViewBag.AutorID = new SelectList(db.autores, "AutorID", "Nome");
            return View();
        }

        //
        // POST: /Filme/Create

        [HttpPost]
        public ActionResult Create(Filme filme)
        {
            if (ModelState.IsValid)
            {
                db.filmes.Add(filme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaID = new SelectList(db.categorias, "CategoriaID", "Designacao", filme.CategoriaID);
            ViewBag.ActorID = new SelectList(db.actores, "ActorID", "Nome", filme.ActorID);
            ViewBag.AutorID = new SelectList(db.autores, "AutorID", "Nome", filme.AutorID);
            return View(filme);
        }

        //
        // GET: /Filme/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Filme filme = db.filmes.Find(id);
            if (filme == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaID = new SelectList(db.categorias, "CategoriaID", "Designacao", filme.CategoriaID);
            ViewBag.ActorID = new SelectList(db.actores, "ActorID", "Nome", filme.ActorID);
            ViewBag.AutorID = new SelectList(db.autores, "AutorID", "Nome", filme.AutorID);
            return View(filme);
        }

        //
        // POST: /Filme/Edit/5

        [HttpPost]
        public ActionResult Edit(Filme filme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(filme).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaID = new SelectList(db.categorias, "CategoriaID", "Designacao", filme.CategoriaID);
            ViewBag.ActorID = new SelectList(db.actores, "ActorID", "Nome", filme.ActorID);
            ViewBag.AutorID = new SelectList(db.autores, "AutorID", "Nome", filme.AutorID);
            return View(filme);
        }

        //
        // GET: /Filme/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Filme filme = db.filmes.Find(id);
            if (filme == null)
            {
                return HttpNotFound();
            }
            return View(filme);
        }

        //
        // POST: /Filme/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Filme filme = db.filmes.Find(id);
            db.filmes.Remove(filme);
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