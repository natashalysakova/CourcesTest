using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestCources.Models;

namespace TestCources.Controllers
{
    public class CourcesController : Controller
    {
        private databaseEntities _db = new databaseEntities();

        //
        // GET: /Default1/

        public ActionResult Index()
        {
            ViewBag.DayOfWeekId = new SelectList(_db.DayOfWeek.ToList(), "Id", "DayOfWeekTitle");
            return View(_db.Cources.ToList());
        }


        //
        // GET: /Default1/Create

        public ActionResult Create()
        {
            ViewBag.DayOfWeekId = new SelectList(_db.DayOfWeek.ToList(), "Id", "DayOfWeekTitle");
            return View();
        }

        //
        // POST: /Default1/Create

        [HttpPost]
        public ActionResult Create(Cources cource)
        {
            if (ModelState.IsValid)
            {
                _db.Cources.Add(cource);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cource);
        }

        //
        // GET: /Default1/Edit/5

        public ActionResult Edit(int id)
        {
            ViewBag.DayOfWeekId = new SelectList(_db.DayOfWeek.ToList(), "Id", "DayOfWeekTitle");

            var cource = _db.Cources.Find(id);
            if (cource != null)
                return View(cource);

            return HttpNotFound();
        }

        //
        // POST: /Default1/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Cources cource)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(cource).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cource);
        }

        //
        // GET: /Default1/Delete/5

        public ActionResult Delete(int id)
        {
            Cources cource = _db.Cources.Find(id);
            if (cource == null)
            {
                return HttpNotFound();
            }

            return View(cource);
        }

        //
        // POST: /Default1/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Cources cource)
        {
            try
            {
                Cources c = _db.Cources.Find(id);
                _db.Cources.Remove(c);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
