using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using YemekTarifleri.Entity;

namespace YemekTarifleri.Areas.Admin.Controllers
{
    public class HakkimizdaController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Admin/Hakkimizda
        public ActionResult Index()
        {
            return View(db.Hakkimizda.ToList());
        }

        // GET: Admin/Hakkimizda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hakkimizda hakkimizda = db.Hakkimizda.Find(id);
            if (hakkimizda == null)
            {
                return HttpNotFound();
            }
            return View(hakkimizda);
        }

        // GET: Admin/Hakkimizda/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Hakkimizda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Metin")] Hakkimizda hakkimizda)
        {
            if (ModelState.IsValid)
            {
                db.Hakkimizda.Add(hakkimizda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hakkimizda);
        }

        // GET: Admin/Hakkimizda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hakkimizda hakkimizda = db.Hakkimizda.Find(id);
            if (hakkimizda == null)
            {
                return HttpNotFound();
            }
            return View(hakkimizda);
        }

        // POST: Admin/Hakkimizda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Metin")] Hakkimizda hakkimizda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hakkimizda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hakkimizda);
        }

        // GET: Admin/Hakkimizda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hakkimizda hakkimizda = db.Hakkimizda.Find(id);
            if (hakkimizda == null)
            {
                return HttpNotFound();
            }
            return View(hakkimizda);
        }

        // POST: Admin/Hakkimizda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hakkimizda hakkimizda = db.Hakkimizda.Find(id);
            db.Hakkimizda.Remove(hakkimizda);
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
