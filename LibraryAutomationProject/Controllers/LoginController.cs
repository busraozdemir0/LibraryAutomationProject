using LibraryAutomation.Entities.DAL;
using LibraryAutomation.Entities.Model;
using LibraryAutomation.Entities.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LibraryAutomationProject.Controllers
{
    public class LoginController : Controller
    {
        LibraryContext context = new LibraryContext();
        UserDAL userDAL = new UserDAL();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut(); // Eger oturum aciksa kapatilsin
            }
            
            var model = userDAL.GetByFilter(context, x => x.Email == user.Email && x.Password == user.Password);
            if(model != null)
            {
                FormsAuthentication.SetAuthCookie(model.UserName, false); // Oturum acilmasi islemi icin cookiye userName kaydediliyor (hatirlansin mi bilgisi false)
                return RedirectToAction("Index2","BookTypes");
            }
            ViewBag.error = "Kullanıcı adı veya şifre yanlış.";
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // confirmPassword degiskeni girilen sifre alani ile uyusup uyusmadigi kontrolu icin | toAccept ise Kullanim sartlari checkbox'ini isaretleyip isaretlemedigi alani icin
        public ActionResult Register(User user, string confirmPassword, bool toAccept) 
        {
            if (!ModelState.IsValid) // Model dogrulanmazsa
            {
                return View(user);
            }
            else // Model dogrulanirsa
            {
                if(user.Password != confirmPassword) // Sifreler uyusmazsa
                {
                    ViewBag.passwordError = "Şifreler uyuşmuyor!";
                    return View();
                }
                else // Sifreler uyusursa
                {
                    if (!toAccept) // Kullanim sartlari kabul edilmemisse
                    {
                        ViewBag.toAcceptError = "Lütfen kullanım şartlarını kabul ettiğinizi onaylayın!";
                        return View();
                    }
                    else // Kullanim sartlari kabul edilmisse
                    {
                        user.CreatedDate = DateTime.Now;
                        userDAL.InsertorUpdate(context, user);
                        userDAL.Save(context);
                        return RedirectToAction("Login");
                    }
                }
            }
        }
    }
}