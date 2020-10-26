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
    public class YorumController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Admin/Yorum
        public ActionResult Index()
        {
            var yorumlar = db.Yorumlar.Include(y => y.Yemek);
            return View(yorumlar.ToList());
        }

        // GET: Admin/Yorum/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yorum yorum = db.Yorumlar.Find(id);
            if (yorum == null)
            {
                return HttpNotFound();
            }
            return View(yorum);
        }

        // GET: Admin/Yorum/Create
        public ActionResult Create()
        {
            ViewBag.Yemekid = new SelectList(db.Yemekler, "Id", "YemekAd");
            return View();
        }

        // POST: Admin/Yorum/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,YorumAdSoyad,YorumTarih,YorumOnay,Yorumicerik,Yemekid,YemekAd")] Yorum yorum)
        {
            if (ModelState.IsValid)
            {
                db.Yorumlar.Add(yorum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Yemekid = new SelectList(db.Yemekler, "Id", "YemekAd", yorum.Yemekid);
            return View(yorum);
        }

        // GET: Admin/Yorum/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yorum yorum = db.Yorumlar.Find(id);
            if (yorum == null)
            {
                return HttpNotFound();
            }
            ViewBag.Yemekid = new SelectList(db.Yemekler, "Id", "YemekAd", yorum.Yemekid);
            return View(yorum);
        }

        // POST: Admin/Yorum/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,YorumAdSoyad,YorumTarih,YorumOnay,Yorumicerik,Yemekid,YemekAd")] Yorum yorum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yorum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Yemekid = new SelectList(db.Yemekler, "Id", "YemekAd", yorum.Yemekid);
            return View(yorum);
        }

        // GET: Admin/Yorum/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yorum yorum = db.Yorumlar.Find(id);
            if (yorum == null)
            {
                return HttpNotFound();
            }
            return View(yorum);
        }

        // POST: Admin/Yorum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Yorum yorum = db.Yorumlar.Find(id);
            db.Yorumlar.Remove(yorum);
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
