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
    public class YemekController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Admin/Yemek
        public ActionResult Index()
        {
            var yemekler = db.Yemekler.Include(y => y.Kategori);
            return View(yemekler.ToList());
        }

        // GET: Admin/Yemek/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yemek yemek = db.Yemekler.Find(id);
            if (yemek == null)
            {
                return HttpNotFound();
            }
            return View(yemek);
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
        public ActionResult Create(Yemek model, HttpPostedFileBase File)
        {
            string path = Path.Combine("~/Content/Images/" + File.FileName); //Resmi anadizinin altında olan content dosyasının içindeki Images klasörüne kaydet
            File.SaveAs(Server.MapPath(path));

            model.YemekResim = File.FileName.ToString();
            model.YemekTarih = DateTime.Now;
            db.Yemekler.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
   
        public ActionResult gununYemegiSec(Yemek models,int id)
        {
            GununYemegi gy = new GununYemegi();
            gy.Id = id;
            gy.GununYemegiAd = models.YemekAd;
            gy.GununYemegiMalzeme = models.YemekMalzeme;
            gy.GununYemegiPuan = models.YemekPuan;
            gy.GununYemegiResim = models.YemekResim;
            gy.GununYemegiTarif = models.YemekTarif;
            gy.GununYemegiTarih = DateTime.Now;

            db.GununYemekleri.Add(gy);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //public ActionResult Create([Bind(Include = "Id,YemekAd,YemekMalzeme,YemekTarif,YemekResim,YemekTarih,YemekPuan,Kategoriid,Durum")] Yemek yemek)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Yemekler.Add(yemek);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.Kategoriid = new SelectList(db.Kategoriler, "Id", "KategoriAd", yemek.Kategoriid);
        //    return View(yemek);
        //}

        // GET: Admin/Yemek/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yemek yemek = db.Yemekler.Find(id);
            if (yemek == null)
            {
                return HttpNotFound();
            }
            ViewBag.Kategoriid = new SelectList(db.Kategoriler, "Id", "KategoriAd", yemek.Kategoriid);
            return View(yemek);
        }

        // POST: Admin/Yemek/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,YemekAd,YemekMalzeme,YemekTarif,YemekResim,YemekTarih,YemekPuan,Kategoriid,Durum")] Yemek yemek)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yemek).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Kategoriid = new SelectList(db.Kategoriler, "Id", "KategoriAd", yemek.Kategoriid);
            return View(yemek);
        }

        // GET: Admin/Yemek/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yemek yemek = db.Yemekler.Find(id);
            if (yemek == null)
            {
                return HttpNotFound();
            }
            return View(yemek);
        }

        // POST: Admin/Yemek/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Yemek yemek = db.Yemekler.Find(id);
            db.Yemekler.Remove(yemek);
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
