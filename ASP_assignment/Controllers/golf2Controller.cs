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
    [Authorize]
    public class golf2Controller : Controller
    {
        private golfModel db = new golfModel();

        // GET: golf2
      //  [OverrideAuthorization]
        public ActionResult Index()
        {
            var golf2 = db.golf2.Include(g => g.golf1);
            return View(golf2.ToList());
        }

        // GET: golf2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            golf2 golf2 = db.golf2.Find(id);
            if (golf2 == null)
            {
                return HttpNotFound();
            }
            return View(golf2);
        }

        // GET: golf2/Create
        public ActionResult Create()
        {
            ViewBag.golferID = new SelectList(db.golf1, "golferID", "Name");
            return View();
        }

        // POST: golf2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,sponsor,driver,putter,golferID")] golf2 golf2)
        {
            if (ModelState.IsValid)
            {
                db.golf2.Add(golf2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.golferID = new SelectList(db.golf1, "golferID", "Name", golf2.golferID);
            return View(golf2);
        }

        // GET: golf2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            golf2 golf2 = db.golf2.Find(id);
            if (golf2 == null)
            {
                return HttpNotFound();
            }
            ViewBag.golferID = new SelectList(db.golf1, "golferID", "Name", golf2.golferID);
            return View(golf2);
        }

        // POST: golf2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,sponsor,driver,putter,golferID")] golf2 golf2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(golf2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.golferID = new SelectList(db.golf1, "golferID", "Name", golf2.golferID);
            return View(golf2);
        }

        // GET: golf2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            golf2 golf2 = db.golf2.Find(id);
            if (golf2 == null)
            {
                return HttpNotFound();
            }
            return View(golf2);
        }

        // POST: golf2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            golf2 golf2 = db.golf2.Find(id);
            db.golf2.Remove(golf2);
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
