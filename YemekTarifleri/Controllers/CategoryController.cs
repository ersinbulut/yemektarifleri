using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YemekTarifleri.Entity;
using YemekTarifleri.Models;

namespace YemekTarifleri.Controllers
{
    public class CategoryController : Controller
    {
        DataContext db = new DataContext();
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _CategoryList()
        {
            var kategoriler = db.Kategoriler.Select(x => new KategoriModel()
            //var kategoriler = db.Categories.Select(x => new Category()
            {
                Id = x.Id,
                ParentId=x.ParentId,
                KategoriAd=x.KategoriAd,
                KategoriAdet=x.KategoriAdet
            }
            ).ToList();
            return PartialView(kategoriler);

            //List<Category> all = new List<Category>();
            //all = db.Categories.OrderBy(a => a.ParentId).ToList();
            //return PartialView(all);
          
        }

        //public ActionResult YemekListesi(int id)
        //{
        //    return View(db.Yemekler.Where(i => i.Kategoriid == id).ToList());
        //}



    }
}