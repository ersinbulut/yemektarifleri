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
    public class TarifController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Admin/Tarif
        public ActionResult Index()
        {
            return View(db.Tarifler.ToList());
        }

        // GET: Admin/Tarif/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarif tarif = db.Tarifler.Find(id);
            if (tarif == null)
            {
                return HttpNotFound();
            }
            return View(tarif);
        }

        // GET: Admin/Tarif/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Tarif/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TarifAd,TarifMalzeme,TarifYapilis,TarifResim,TarifSahip,TarifSahipMail,TarifDurum")] Tarif tarif)
        {
            if (ModelState.IsValid)
            {
                db.Tarifler.Add(tarif);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tarif);
        }

        // GET: Admin/Tarif/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarif tarif = db.Tarifler.Find(id);
            if (tarif == null)
            {
                return HttpNotFound();
            }
            return View(tarif);
        }

        // POST: Admin/Tarif/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TarifAd,TarifMalzeme,TarifYapilis,TarifResim,TarifSahip,TarifSahipMail,TarifDurum")] Tarif tarif)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarif).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tarif);
        }

        // GET: Admin/Tarif/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarif tarif = db.Tarifler.Find(id);
            if (tarif == null)
            {
                return HttpNotFound();
            }
            return View(tarif);
        }

        // POST: Admin/Tarif/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tarif tarif = db.Tarifler.Find(id);
            db.Tarifler.Remove(tarif);
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
