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
    public class ComprasController : Controller
    {
        private LCVEntities db = new LCVEntities();

        //
        // GET: /Compras/

        public ActionResult Index()
        {
            var compras = db.Compras.Include(c => c.Periodo);
            return View(compras.ToList());
        }

        //
        // GET: /Compras/Details/5

        public ActionResult Details(int id = 0)
        {
            Compras compras = db.Compras.Find(id);
            if (compras == null)
            {
                return HttpNotFound();
            }
            return View(compras);
        }

        //
        // GET: /Compras/Create

        public ActionResult Create()
        {
            ViewBag.Id_Periodo = new SelectList(db.Periodo, "Id_Periodo", "UsuarioReg");
            return View();
        }

        //
        // POST: /Compras/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Compras compras)
        {
            if (ModelState.IsValid)
            {
                db.Compras.Add(compras);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Periodo = new SelectList(db.Periodo, "Id_Periodo", "UsuarioReg", compras.Id_Periodo);
            return View(compras);
        }

        //
        // GET: /Compras/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Compras compras = db.Compras.Find(id);
            if (compras == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Periodo = new SelectList(db.Periodo, "Id_Periodo", "UsuarioReg", compras.Id_Periodo);
            return View(compras);
        }

        //
        // POST: /Compras/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Compras compras)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compras).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Periodo = new SelectList(db.Periodo, "Id_Periodo", "UsuarioReg", compras.Id_Periodo);
            return View(compras);
        }

        //
        // GET: /Compras/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Compras compras = db.Compras.Find(id);
            if (compras == null)
            {
                return HttpNotFound();
            }
            return View(compras);
        }

        //
        // POST: /Compras/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Compras compras = db.Compras.Find(id);
            db.Compras.Remove(compras);
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