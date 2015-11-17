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
    public class SelecaoController : Controller
    {
        private DefaultContext db = new DefaultContext();

        //
        // GET: /Selecao/

        public ActionResult Index()
        {
            return View(db.selecoes.ToList());
        }

        //
        // GET: /Selecao/Details/5

        public ActionResult Details(int id = 0)
        {
            Selecao selecao = db.selecoes.Find(id);
            if (selecao == null)
            {
                return HttpNotFound();
            }
            return View(selecao);
        }

        //
        // GET: /Selecao/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Selecao/Create

        [HttpPost]
        public ActionResult Create(Selecao selecao)
        {
            if (ModelState.IsValid)
            {
                db.selecoes.Add(selecao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(selecao);
        }

        //
        // GET: /Selecao/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Selecao selecao = db.selecoes.Find(id);
            if (selecao == null)
            {
                return HttpNotFound();
            }
            return View(selecao);
        }

        //
        // POST: /Selecao/Edit/5

        [HttpPost]
        public ActionResult Edit(Selecao selecao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(selecao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(selecao);
        }

        //
        // GET: /Selecao/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Selecao selecao = db.selecoes.Find(id);
            if (selecao == null)
            {
                return HttpNotFound();
            }
            return View(selecao);
        }

        //
        // POST: /Selecao/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Selecao selecao = db.selecoes.Find(id);
            db.selecoes.Remove(selecao);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }



        //Os do angular

        public ActionResult Registar() {
            return View();
        } 

        public JsonResult RegistarM(Selecao selecao)
        {
            String mensagem = "Salvou";
            
                db.selecoes.Add(selecao);
                db.SaveChanges();
               // return RedirectToAction("Index");
            

            return Json (mensagem, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Listar()
        {

            var selecoes = db.selecoes.ToList();
            return Json (selecoes, JsonRequestBehavior.AllowGet);
        }

    }
}