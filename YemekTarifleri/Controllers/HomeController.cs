using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YemekTarifleri.Entity;
using YemekTarifleri.Identity;
using YemekTarifleri.Models;
using YemekTarifleri.ViewModels;

namespace YemekTarifleri.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;
        private IdentityDataContext identityDb = new IdentityDataContext();
        public HomeController()
        {
            var userStore = new UserStore<ApplicationUser>(identityDb);
            UserManager = new UserManager<ApplicationUser>(userStore);
            var roleStore = new RoleStore<ApplicationRole>(identityDb);
            RoleManager = new RoleManager<ApplicationRole>(roleStore);
        }
        // GET: Home
        public ActionResult Index()
        {
            var yemek = db.Yemekler.Where(i => i.Durum).Select(i => new YemekModel()
            {
                Id = i.Id,
                YemekAd = i.YemekAd,
                YemekTarif = i.YemekTarif.Length > 25 ? i.YemekTarif.Substring(0, 120) + "..." : i.YemekTarif,//eğer description 25 karakterden büyükse 20. karakterin sonuna 3 nokta koy
                YemekMalzeme = i.YemekMalzeme,
                YemekPuan = i.YemekPuan,
                YemekResim = i.YemekResim,
                Kategoriid = i.Kategoriid
            }
           ).ToList();
            return View(yemek);
        }

        //public ActionResult Yemekler()
        //{
        //    var yemek = db.Yemekler.Where(i => i.Durum).Select(i => new YemekModel()
        //    {
        //        Id = i.Id,
        //        YemekAd = i.YemekAd,
        //        YemekTarif = i.YemekTarif.Length > 25 ? i.YemekTarif.Substring(0, 20) + "..." : i.YemekTarif,//eğer description 25 karakterden büyükse 20. karakterin sonuna 3 nokta koy
        //        YemekMalzeme = i.YemekMalzeme,
        //        YemekResim = i.YemekResim,
        //        YemekPuan = i.YemekPuan,
        //        YemekTarih = i.YemekTarih
        //    }
        //   ).ToList();
        //    return View(yemek);
        //}

        public PartialViewResult _Slider()
        {
            return PartialView();
        }


        public PartialViewResult _Menu()
        {
            return PartialView();
        }

        public ActionResult YemekDetay(int id)
        {
            return View(db.Yemekler.Where(i => i.Id == id).FirstOrDefault());
        }
        public ActionResult Hakkimizda()
        {
            return View(db.Hakkimizda.ToList());
        }
        public ActionResult Iletisim()
        {
            return View();
        }
        public ActionResult Menu()
        {
            return View(db.Kategoriler.ToList());
        }

        [HttpPost]
        public ActionResult Iletisim(Mesaj mesaj)
        {
            if (ModelState.IsValid)
            {
                db.Mesajlar.Add(mesaj);
                db.SaveChanges();
                TempData["Mesaj"] = "Mesajınız gönderildi!";
                return RedirectToAction("Iletisim");
            }
            return View();
        }

        public ActionResult Search(string q)//Arama işlemi
        {
            var p = db.Yemekler.Where(i => i.Durum == true);
            if (!string.IsNullOrEmpty(q))//eger q nun içerisi boş değilse
            {
                p = p.Where(i => i.YemekAd.Contains(q) || i.YemekTarif.Contains(q));//name veya description kısmında arama kriteri varsa filtreler
            }
            return View(p.ToList());
        }

        public ActionResult YemekListesi(int categoryId, int subCategoryId)
        {
            var query = db.Yemekler.AsQueryable();

            if (categoryId > 0)
                query = query.Where(i => i.Kategoriid == subCategoryId);
            else
                query = query.Where(i => i.Kategori.ParentId == subCategoryId || i.Kategoriid == subCategoryId);
            return View(query.ToList());
        }

        //public ActionResult Comment()
        //{
        //    Comments yorum = new Comments();
        //    return View(yorum);
        //}
        [HttpPost]
        public ActionResult Yorum(Yorum yorum)
        {
            var id = HttpContext.GetOwinContext().Authentication.User.Identity.GetUserId();
            var user = UserManager.FindById(id);

            if (ModelState.IsValid)
            {
                yorum.YorumTarih = DateTime.Now;
                yorum.YorumOnay = false;
                yorum.ProfileImageName = user.Image;
                db.Yorumlar.Add(yorum);
                db.SaveChanges();
                TempData["Mesaj"] = "Yorumunuz yöneticinin onayına gönderildi en kısa zamanda yayınlanacak..!";
                return RedirectToAction("YemekDetay/" + yorum.Yemekid);
            }
            return View();
        }
        public JavaScriptResult MesajGoster()
        {
            string msg = "<script> alert('Yorumunuz yöneticinin onayına gönderildi en kısa zamanda yayınlanacak..'); </script>";
            return JavaScript(msg);
        }



    }
}