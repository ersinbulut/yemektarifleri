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
    public class MesajController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Admin/Mesaj
        public ActionResult Index()
        {
            return View(db.Mesajlar.ToList());
        }

        // GET: Admin/Mesaj/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mesaj mesaj = db.Mesajlar.Find(id);
            if (mesaj == null)
            {
                return HttpNotFound();
            }
            return View(mesaj);
        }

        // GET: Admin/Mesaj/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Mesaj/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AdSoyad,Email,İcerik")] Mesaj mesaj)
        {
            if (ModelState.IsValid)
            {
                db.Mesajlar.Add(mesaj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mesaj);
        }

        // GET: Admin/Mesaj/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mesaj mesaj = db.Mesajlar.Find(id);
            if (mesaj == null)
            {
                return HttpNotFound();
            }
            return View(mesaj);
        }

        // POST: Admin/Mesaj/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AdSoyad,Email,İcerik")] Mesaj mesaj)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mesaj).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mesaj);
        }

        // GET: Admin/Mesaj/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mesaj mesaj = db.Mesajlar.Find(id);
            if (mesaj == null)
            {
                return HttpNotFound();
            }
            return View(mesaj);
        }

        // POST: Admin/Mesaj/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mesaj mesaj = db.Mesajlar.Find(id);
            db.Mesajlar.Remove(mesaj);
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
