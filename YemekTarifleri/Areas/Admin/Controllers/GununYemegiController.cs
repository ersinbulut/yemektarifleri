using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using YemekTarifleri.Entity;

namespace YemekTarifleri.Areas.Admin.Controllers
{
    public class GununYemegiController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Admin/GununYemegi
        public ActionResult Index()
        {
            return View(db.GununYemekleri.ToList());
        }

        // GET: Admin/GununYemegi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GununYemegi gununYemegi = db.GununYemekleri.Find(id);
            if (gununYemegi == null)
            {
                return HttpNotFound();
            }
            return View(gununYemegi);
        }

        // GET: Admin/Yemek/Create
        public ActionResult Create()
        {
            ViewBag.Kategoriid = new SelectList(db.Kategoriler, "Id", "KategoriAd");
            return View();
        }

        // POST: Admin/Yemek/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GununYemegi model, HttpPostedFileBase File)
        {
            string path = Path.Combine("~/Content/Images/" + File.FileName); //Resmi anadizinin altında olan content dosyasının içindeki Images klasörüne kaydet
            File.SaveAs(Server.MapPath(path));

            model.GununYemegiResim = File.FileName.ToString();
            model.GununYemegiTarih = DateTime.Now;
            db.GununYemekleri.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Admin/GununYemegi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GununYemegi gununYemegi = db.GununYemekleri.Find(id);
            if (gununYemegi == null)
            {
                return HttpNotFound();
            }
            return View(gununYemegi);
        }

        // POST: Admin/GununYemegi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GununYemegiAd,GununYemegiMalzeme,GununYemegiTarif,GununYemegiResim,GununYemegiPuan,GununYemegiTarih")] GununYemegi gununYemegi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gununYemegi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gununYemegi);
        }

        // GET: Admin/GununYemegi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GununYemegi gununYemegi = db.GununYemekleri.Find(id);
            if (gununYemegi == null)
            {
                return HttpNotFound();
            }
            return View(gununYemegi);
        }

        // POST: Admin/GununYemegi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GununYemegi gununYemegi = db.GununYemekleri.Find(id);
            db.GununYemekleri.Remove(gununYemegi);
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
