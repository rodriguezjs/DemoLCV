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
    public class VentasController : Controller
    {
        private LCVEntities db = new LCVEntities();

        //
        // GET: /Ventas/

        public ActionResult Index()
        {
            var ventas = db.Ventas.Include(v => v.Periodo);
            return View(ventas.ToList());
        }

        //
        // GET: /Ventas/Details/5

        public ActionResult Details(int id = 0)
        {
            Ventas ventas = db.Ventas.Find(id);
            if (ventas == null)
            {
                return HttpNotFound();
            }
            return View(ventas);
        }

        //
        // GET: /Ventas/Create

        public ActionResult Create()
        {
            ViewBag.Id_Periodo = new SelectList(db.Periodo, "Id_Periodo", "UsuarioReg");
            return View();
        }

        //
        // POST: /Ventas/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ventas ventas)
        {
            if (ModelState.IsValid)
            {
                db.Ventas.Add(ventas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Periodo = new SelectList(db.Periodo, "Id_Periodo", "UsuarioReg", ventas.Id_Periodo);
            return View(ventas);
        }

        //
        // GET: /Ventas/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Ventas ventas = db.Ventas.Find(id);
            if (ventas == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Periodo = new SelectList(db.Periodo, "Id_Periodo", "UsuarioReg", ventas.Id_Periodo);
            return View(ventas);
        }

        //
        // POST: /Ventas/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ventas ventas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ventas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Periodo = new SelectList(db.Periodo, "Id_Periodo", "UsuarioReg", ventas.Id_Periodo);
            return View(ventas);
        }

        //
        // GET: /Ventas/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Ventas ventas = db.Ventas.Find(id);
            if (ventas == null)
            {
                return HttpNotFound();
            }
            return View(ventas);
        }

        //
        // POST: /Ventas/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ventas ventas = db.Ventas.Find(id);
            db.Ventas.Remove(ventas);
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