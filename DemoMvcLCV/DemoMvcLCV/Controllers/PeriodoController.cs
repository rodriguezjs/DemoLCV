using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoDatosLCV;

namespace DemoMvcLCV.Controllers
{
    public class PeriodoController : Controller
    {
        private LCVEntities db = new LCVEntities();

        //
        // GET: /Periodo/

        public ActionResult Index()
        {
            var periodo = db.Periodo.Include(p => p.Gestion);
            return View(periodo.ToList());
        }

        //
        // GET: /Periodo/Details/5

        public ActionResult Details(string id = null)
        {
            Periodo periodo = db.Periodo.Find(id);
            if (periodo == null)
            {
                return HttpNotFound();
            }
            return View(periodo);
        }

        //
        // GET: /Periodo/Create

        public ActionResult Create()
        {
            ViewBag.Id_Gestion = new SelectList(db.Gestion, "Id", "UsuarioReg");
            return View();
        }

        //
        // POST: /Periodo/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Periodo periodo)
        {
            if (ModelState.IsValid)
            {
                db.Periodo.Add(periodo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Gestion = new SelectList(db.Gestion, "Id", "UsuarioReg", periodo.Id_Gestion);
            return View(periodo);
        }

        //
        // GET: /Periodo/Edit/5

        public ActionResult Edit(string id = null)
        {
            Periodo periodo = db.Periodo.Find(id);
            if (periodo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Gestion = new SelectList(db.Gestion, "Id", "UsuarioReg", periodo.Id_Gestion);
            return View(periodo);
        }

        //
        // POST: /Periodo/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Periodo periodo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(periodo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Gestion = new SelectList(db.Gestion, "Id", "UsuarioReg", periodo.Id_Gestion);
            return View(periodo);
        }

        //
        // GET: /Periodo/Delete/5

        public ActionResult Delete(string id = null)
        {
            Periodo periodo = db.Periodo.Find(id);
            if (periodo == null)
            {
                return HttpNotFound();
            }
            return View(periodo);
        }

        //
        // POST: /Periodo/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Periodo periodo = db.Periodo.Find(id);
            db.Periodo.Remove(periodo);
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