﻿using LibraryAutomation.Entities.DAL;
using LibraryAutomation.Entities.Model;
using LibraryAutomation.Entities.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LibraryAutomationProject.Controllers
{
    [AllowAnonymous] // Herkesin bu controller'a erisebilecegini belirttik
    public class LoginController : Controller
    {
        LibraryContext context = new LibraryContext();
        UserDAL userDAL = new UserDAL();
        UserMovementsDAL userMovementsDAL = new UserMovementsDAL();
        public void UserMovements(int userId, int processDoId, string explanation)
        {
            var model = new UserMovements
            {
                Explanation = explanation,
                ProcessDo = processDoId, // islemi gerceklestiren kulanicinin id'si
                UserId = userId,
                CreatedDate = DateTime.Now
            };

            userMovementsDAL.InsertorUpdate(context, model);
            userMovementsDAL.Save(context);
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
            if (model != null)
            {
                FormsAuthentication.SetAuthCookie(user.Email, false); // Oturum acilmasi islemi icin cookiye email kaydediliyor (hatirlansin mi bilgisi false)

                // Giris yapma esnasinda kullanici hareketleri tablosuna veri/bilgi ekleme
                int processDoId = model.Id; // islemi gerceklestiren kulanicinin id'si
                string explanation = model.UserName + " kulanıcısı sisteme giriş yaptı.";
                UserMovements(processDoId, processDoId, explanation);

                return RedirectToAction("Index2", "BookTypes");
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
                if (user.Password != confirmPassword) // Sifreler uyusmazsa
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

                        // Kayit olma esnasinda kullanici hareketleri tablosuna veri/bilgi ekleme
                        var userId = context.Users.Max(x => x.Id); // En son kaydedilen kisinin id'si en buyuk olacagi icin son kullaniciyi cekiyoruz
                        string explanation = " Yeni bir kulanıcı oluşturuldu.";
                        UserMovements(userId, userId, explanation);

                        return RedirectToAction("Login");
                    }
                }
            }
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [ValidateAntiForgeryToken, HttpPost]
        public ActionResult ForgotPassword(User user)
        {
            var model = userDAL.GetByFilter(context, x => x.Email == user.Email);
            if (model != null)
            {
                // İnput'a girilen mail adresine yeni bir sifre gonderme

                Guid randomPassword = Guid.NewGuid(); // rastgele bir sifre olusturulacak
                model.Password = randomPassword.ToString().Substring(0, 8); // olusturulan sifrenin ilk 8 karakteri alinacak
                userDAL.Save(context);
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("uiswagger@gmail.com", "Şifre sıfırlama");
                mail.To.Add(model.Email); // Sifreyi gonderecegimiz mail
                mail.IsBodyHtml = true;
                mail.Subject = "Şifre Değiştirme İsteği";
                mail.Body += "Merhaba " + model.NameSurname + "<br/> Kullanıcı Adınız= " + model.UserName + "<br/> Şifreniz= " + model.Password;
                NetworkCredential net = new NetworkCredential("uiswagger@gmail.com", "kaawcqgyzqdqxffh");
                client.Credentials = net;
                client.Send(mail);
                return RedirectToAction("Login");
            }
            else if (model == null && user.Email != null)
            {
                ViewBag.error = "Böyle bir e-mail adresi bulunamadı.";
                return View();
            }
            return View();
        }
    }
}