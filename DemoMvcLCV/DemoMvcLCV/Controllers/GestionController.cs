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
    public class GestionController : Controller
    {
        private LCVEntities db = new LCVEntities();

        //
        // GET: /Gestion/

        public ActionResult Index()
        {
            var gestion = db.Gestion.Include(g => g.Empresa);
            return View(gestion.ToList());
        }

        //
        // GET: /Gestion/Details/5

        public ActionResult Details(int id = 0)
        {
            Gestion gestion = db.Gestion.Find(id);
            if (gestion == null)
            {
                return HttpNotFound();
            }
            return View(gestion);
        }

        //
        // GET: /Gestion/Create

        public ActionResult Create()
        {
            ViewBag.Id_Empresa = new SelectList(db.Empresa, "Nit", "Razon_Social");
            return View();
        }

        //
        // POST: /Gestion/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Gestion gestion)
        {
            if (ModelState.IsValid)
            {
                db.Gestion.Add(gestion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Empresa = new SelectList(db.Empresa, "Nit", "Razon_Social", gestion.Id_Empresa);
            return View(gestion);
        }

        //
        // GET: /Gestion/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Gestion gestion = db.Gestion.Find(id);
            if (gestion == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Empresa = new SelectList(db.Empresa, "Nit", "Razon_Social", gestion.Id_Empresa);
            return View(gestion);
        }

        //
        // POST: /Gestion/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Gestion gestion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gestion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Empresa = new SelectList(db.Empresa, "Nit", "Razon_Social", gestion.Id_Empresa);
            return View(gestion);
        }

        //
        // GET: /Gestion/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Gestion gestion = db.Gestion.Find(id);
            if (gestion == null)
            {
                return HttpNotFound();
            }
            return View(gestion);
        }

        //
        // POST: /Gestion/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gestion gestion = db.Gestion.Find(id);
            db.Gestion.Remove(gestion);
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