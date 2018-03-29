using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASP_assignment.Models;

namespace ASP_assignment.Controllers
{
    public class golf1Controller : Controller
    {
        private golfModel db = new golfModel();

        // GET: golf1
        public ActionResult Index()
        {
            return View(db.golf1.ToList());
        }

        // GET: golf1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            golf1 golf1 = db.golf1.Find(id);
            if (golf1 == null)
            {
                return HttpNotFound();
            }
            return View(golf1);
        }

        // GET: golf1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: golf1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "golferID,Name,country,trophies")] golf1 golf1)
        {
            if (ModelState.IsValid)
            {
                db.golf1.Add(golf1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(golf1);
        }

        // GET: golf1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            golf1 golf1 = db.golf1.Find(id);
            if (golf1 == null)
            {
                return HttpNotFound();
            }
            return View(golf1);
        }

        // POST: golf1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "golferID,Name,country,trophies")] golf1 golf1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(golf1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(golf1);
        }

        // GET: golf1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            golf1 golf1 = db.golf1.Find(id);
            if (golf1 == null)
            {
                return HttpNotFound();
            }
            return View(golf1);
        }

        // POST: golf1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            golf1 golf1 = db.golf1.Find(id);
            db.golf1.Remove(golf1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
