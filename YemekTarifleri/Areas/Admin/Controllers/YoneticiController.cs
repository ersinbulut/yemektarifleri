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
    public class YoneticiController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Admin/Yonetici
        public ActionResult Index()
        {
            return View(db.Yoneticiler.ToList());
        }

        // GET: Admin/Yonetici/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yonetici yonetici = db.Yoneticiler.Find(id);
            if (yonetici == null)
            {
                return HttpNotFound();
            }
            return View(yonetici);
        }

        // GET: Admin/Yonetici/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Yonetici/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,YoneticiAd,YoneticiSifre")] Yonetici yonetici)
        {
            if (ModelState.IsValid)
            {
                db.Yoneticiler.Add(yonetici);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yonetici);
        }

        // GET: Admin/Yonetici/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yonetici yonetici = db.Yoneticiler.Find(id);
            if (yonetici == null)
            {
                return HttpNotFound();
            }
            return View(yonetici);
        }

        // POST: Admin/Yonetici/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,YoneticiAd,YoneticiSifre")] Yonetici yonetici)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yonetici).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yonetici);
        }

        // GET: Admin/Yonetici/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yonetici yonetici = db.Yoneticiler.Find(id);
            if (yonetici == null)
            {
                return HttpNotFound();
            }
            return View(yonetici);
        }

        // POST: Admin/Yonetici/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Yonetici yonetici = db.Yoneticiler.Find(id);
            db.Yoneticiler.Remove(yonetici);
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
