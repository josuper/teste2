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
    public class JogadorController : Controller
    {
        private DefaultContext db = new DefaultContext();

        //
        // GET: /Jogador/

        public ActionResult Index()
        {
            var jogadores = db.jogadores.Include(j => j.Selecao);
            return View(jogadores.ToList());
        }

        //
        // GET: /Jogador/Details/5

        public ActionResult Details(int id = 0)
        {
            Jogador jogador = db.jogadores.Find(id);
            if (jogador == null)
            {
                return HttpNotFound();
            }
            return View(jogador);
        }

        //
        // GET: /Jogador/Create

        public ActionResult Create()
        {
            ViewBag.SelecaoID = new SelectList(db.selecoes, "SelecaoID", "Designacao");
            return View();
        }

        //
        // POST: /Jogador/Create

        [HttpPost]
        public ActionResult Create(Jogador jogador)
        {
            if (ModelState.IsValid)
            {
                db.jogadores.Add(jogador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SelecaoID = new SelectList(db.selecoes, "SelecaoID", "Designacao", jogador.SelecaoID);
            return View(jogador);
        }

        //
        // GET: /Jogador/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Jogador jogador = db.jogadores.Find(id);
            if (jogador == null)
            {
                return HttpNotFound();
            }
            ViewBag.SelecaoID = new SelectList(db.selecoes, "SelecaoID", "Designacao", jogador.SelecaoID);
            return View(jogador);
        }

        //
        // POST: /Jogador/Edit/5

        [HttpPost]
        public ActionResult Edit(Jogador jogador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jogador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SelecaoID = new SelectList(db.selecoes, "SelecaoID", "Designacao", jogador.SelecaoID);
            return View(jogador);
        }

        //
        // GET: /Jogador/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Jogador jogador = db.jogadores.Find(id);
            if (jogador == null)
            {
                return HttpNotFound();
            }
            return View(jogador);
        }

        //
        // POST: /Jogador/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Jogador jogador = db.jogadores.Find(id);
            db.jogadores.Remove(jogador);
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