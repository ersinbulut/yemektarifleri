using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using YemekTarifleri.Entity;
using YemekTarifleri.Identity;
using YemekTarifleri.Models;
using YemekTarifleri.ViewModels;

namespace YemekTarifleri.Controllers
{
    public class AccountController : Controller
    {
        DataContext db = new DataContext();
        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;
        private IdentityDataContext identityDb = new IdentityDataContext();
        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(identityDb);
            UserManager = new UserManager<ApplicationUser>(userStore);
            var roleStore = new RoleStore<ApplicationRole>(identityDb);
            RoleManager = new RoleManager<ApplicationRole>(roleStore);
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser();
                //user.Name = model.Name;
                //user.Surname = model.Surname;
                user.Email = model.Email;
                user.UserName = model.Username;
               // user.DateOfBirth = model.DateOfBirth;
                //user.Gender = model.Gender;
                //user.ActivationCode = StringHelpers.GetCode();

                var result = UserManager.Create(user, model.Password);

                if (result.Succeeded)
                {
                    //string SiteUrl = Request.Url.Scheme + System.Uri.SchemeDelimiter + Request.Url.Host +
                    //    (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port);

                    ////mail gönder
                    //var emailService = new EmailService();
                    //var body = $"Merhaba <b>{user.Name}  {user.Surname}</b> <br/> Hesabınızı aktif etmek için aşağıdaki linke tıklayınız" +
                    //    $"<br/><a href='{SiteUrl}/Account/Activation?code={user.ActivationCode}'>Aktivasyon Linki</a>";
                    //await emailService.SendAsync(new IdentityMessage() { Body = body, Subject = "Sitemize Hoşgeldiniz" }, user.Email);

                    if (RoleManager.RoleExists("user"))
                    {
                        UserManager.AddToRole(user.Id, "user");
                    }

                    return RedirectToAction("Login", "Account");

                }
                else
                {
                    ModelState.AddModelError("RegisterUserError", "Kullanıcı Oluşturma Hatası...");
                }
            }
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.Find(model.Username, model.Password);//modelden alınan kullanıcıadı ve şifreye göre kullanıcı arar
                if (user != null)//kullanıcı sistemde var ise
                {
                    var autManager = HttpContext.GetOwinContext().Authentication;
                    var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememberMe;//sisteme beni dahil et
                    autManager.SignIn(authProperties, identityclaims);
                    if (!String.IsNullOrEmpty(ReturnUrl))//bilgiler doğru değilse 
                    {
                        return Redirect(ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "Böyle bir kullanıcı yok..");
                }
            }
            return View();
        }
        public ActionResult LogOut()
        {
            var autManager = HttpContext.GetOwinContext().Authentication;
            autManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize]
        public ActionResult UserProfile()
        {
            var id = HttpContext.GetOwinContext().Authentication.User.Identity.GetUserId();
            var user = UserManager.FindById(id);
            var data = new ProfilePasswordViewModel()
            {
                UserProfileViewModel = new UserProfileViewModel()
                {
                    Email = user.Email,
                    Id = user.Id,
                    Name = user.Name,
                    /**/
                    DateOfBirth = user.DateOfBirth,
                    Gender = user.Gender,
                    Adres = user.Adres,
                    AdresBasligi = user.AdresBasligi,
                    Il = user.Il,
                    Ilce = user.Ilce,
                    Mahalle = user.Mahalle,
                    PostaKodu = user.PostaKodu,
                    //CartNumber = user.CartNumber,
                    //SecurityNumber = user.SecurityNumber,
                    //CartHasName = user.CartHasName,
                    //ExpYear = user.ExpYear,
                    //ExpMonth = user.ExpMonth,
                    /**/
                    ProfileImageName=user.Image,
                    PhoneNumber = user.PhoneNumber,
                    Surname = user.Surname,
                    Username = user.UserName
                    
                }
            };
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> UpdateProfile(ProfilePasswordViewModel model)
        {
            if (!ModelState.IsValid)//boş ise
            {
                return View("UserProfile", model);
            }
            else
            {
                var userManager = UserManager;

                var user = await UserManager.FindByIdAsync(model.UserProfileViewModel.Id);

                user.Name = model.UserProfileViewModel.Name;
                user.Surname = model.UserProfileViewModel.Surname;
                user.PhoneNumber = model.UserProfileViewModel.PhoneNumber;
                user.Email = model.UserProfileViewModel.Email;
                /**/
                user.DateOfBirth = model.UserProfileViewModel.DateOfBirth;
                user.Gender = model.UserProfileViewModel.Gender;


                await userManager.UpdateAsync(user);
                TempData["mesaj"] = "Bilgileriniz kaydedildi";
                return RedirectToAction("UserProfile");
            }
          
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> UpdateProfileImage( HttpPostedFileBase File)
        {
            if (!ModelState.IsValid)//boş ise
            {
                return View("UserProfile");
            }
            else
            {
                var userManager = UserManager;

                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());


                string path = Path.Combine("~/Content/Images/" + File.FileName); //Resmi anadizinin altında olan content dosyasının içindeki Images klasörüne kaydet
                File.SaveAs(Server.MapPath(path));

                user.Image = File.FileName.ToString();

                await userManager.UpdateAsync(user);
                TempData["mesaj"] = "Bilgileriniz kaydedildi";
                return RedirectToAction("UserProfile");
            }
         
        }

    }
}