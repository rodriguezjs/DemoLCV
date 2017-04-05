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
    public class EmpresaController : Controller
    {
        private LCVEntities db = new LCVEntities();

        //
        // GET: /Empresa/

        public ActionResult Index()
        {
            return View(db.Empresa.ToList());
        }

        //
        // GET: /Empresa/Details/5

        public ActionResult Details(string id = null)
        {
            Empresa empresa = db.Empresa.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        //
        // GET: /Empresa/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Empresa/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                db.Empresa.Add(empresa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empresa);
        }

        //
        // GET: /Empresa/Edit/5

        public ActionResult Edit(string id = null)
        {
            Empresa empresa = db.Empresa.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        //
        // POST: /Empresa/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empresa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empresa);
        }

        //
        // GET: /Empresa/Delete/5

        public ActionResult Delete(string id = null)
        {
            Empresa empresa = db.Empresa.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        //
        // POST: /Empresa/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Empresa empresa = db.Empresa.Find(id);
            db.Empresa.Remove(empresa);
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