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
    public class EmprestimoController : Controller
    {
        private DefaultContext db = new DefaultContext();

        //
        // GET: /Emprestimo/

        public ActionResult Index()
        {
            

            var emprestimos = db.emprestimos.Include(e => e.Utente).Include(e => e.Copia);

            return View(emprestimos.ToList());
        }

        //
        // GET: /Emprestimo/Details/5

        public ActionResult Details(int id = 0)
        {
            Emprestimo emprestimo = db.emprestimos.Find(id);
            if (emprestimo == null)
            {
                return HttpNotFound();
            }
            return View(emprestimo);
        }

        public ActionResult FilmesPorDevolverData(DateTime data)
        {

           

            var filmes = db.emprestimos.Include(f => f.Utente).Include(f => f.Copia)
                .Where(s => s.Copia.Ocupada == true && s.DataDevolucao.Equals(data));
            return View(filmes.ToList());
        }

        //
        // GET: /Emprestimo/Create

        public ActionResult Create()
        {
            ViewBag.UtenteID = new SelectList(db.utentes, "UtenteID", "Nome");
            ViewBag.CopiaID = new SelectList(db.copias.Where(s => (s.EstadoID != 2) && (s.Ocupada != true)), "CopiaID", "CopiaID");
            return View();
        }

        //
        // POST: /Emprestimo/Create

        [HttpPost]
        public ActionResult Create(Emprestimo emprestimo)
        {
            if (ModelState.IsValid)
            {
                Copia copia = db.copias.Find(emprestimo.CopiaID);
                copia.Ocupada = true;
                db.Entry(copia).State = EntityState.Modified;

                db.emprestimos.Add(emprestimo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UtenteID = new SelectList(db.utentes, "UtenteID", "Nome", emprestimo.UtenteID);
            ViewBag.CopiaID = new SelectList(db.copias, "CopiaID", "CopiaID", emprestimo.CopiaID);
            return View(emprestimo);
        }

        //
        // GET: /Emprestimo/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Emprestimo emprestimo = db.emprestimos.Find(id);
            if (emprestimo == null)
            {
                return HttpNotFound();
            }
            ViewBag.UtenteID = new SelectList(db.utentes, "UtenteID", "Nome", emprestimo.UtenteID);
            ViewBag.CopiaID = new SelectList(db.copias, "CopiaID", "CopiaID", emprestimo.CopiaID);
            return View(emprestimo);
        }

        //
        // POST: /Emprestimo/Edit/5

        [HttpPost]
        public ActionResult Edit(Emprestimo emprestimo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emprestimo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UtenteID = new SelectList(db.utentes, "UtenteID", "Nome", emprestimo.UtenteID);
            ViewBag.CopiaID = new SelectList(db.copias, "CopiaID", "CopiaID", emprestimo.CopiaID);
            return View(emprestimo);
        }

        public ActionResult Devolver(int id=0) 
        {
            Emprestimo emprestimo = db.emprestimos.Find(id);

            Copia copia = db.copias.Find(emprestimo.CopiaID);
            copia.Ocupada = false;
            db.Entry(copia).State = EntityState.Modified;

            emprestimo.Devolvido = true;

            db.SaveChanges();


            return RedirectToAction("EditEstado/"+emprestimo.CopiaID,"Copia");
        }

        //
        // GET: /Emprestimo/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Emprestimo emprestimo = db.emprestimos.Find(id);
            if (emprestimo == null)
            {
                return HttpNotFound();
            }
            return View(emprestimo);
        }

        //
        // POST: /Emprestimo/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Emprestimo emprestimo = db.emprestimos.Find(id);
            db.emprestimos.Remove(emprestimo);
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