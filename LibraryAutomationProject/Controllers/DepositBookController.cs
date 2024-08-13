using LibraryAutomation.Entities.DAL;
using LibraryAutomation.Entities.Mapping;
using LibraryAutomation.Entities.Model;
using LibraryAutomation.Entities.Model.Context;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryAutomationProject.Controllers
{
    [AllowAnonymous]
    public class DepositBookController : Controller
    {
        // Emanet Kitaplar ile ilgili islemler
        LibraryContext context = new LibraryContext();
        DepositBookDAL depositBookDAL = new DepositBookDAL();
        BookDAL bookDAL = new BookDAL();
        public ActionResult Index()
        {
            // Kitap iade tarihi null olan Book ve Member tablosu dahil edilmis bir sekilde olan DepositBook(Emanet kitap) tablosundaki bilgileri listele
            var model = depositBookDAL.GetAll(context, x => x.DeliveryDateBook == null, "Book", "Member");
            return View(model);
        }
        public ActionResult GiveABook() // Emanet kitap verme action'ı
        {
            ViewBag.memberList = new SelectList(context.Members, "Id", "NameSurname"); // Uyeleri dropdown'da listeleme
            ViewBag.bookList = new SelectList(context.Books, "Id", "BookName"); // Kitaplari dropdown'da listeleme

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult GiveABook(DepositBook entity) // Emanet kitap verme action'ı
        {
            if (!ModelState.IsValid) // Model dogrulanmazsa
            {
                ViewBag.memberList = new SelectList(context.Members, "Id", "NameSurname"); // Uyeleri dropdown'da listeleme
                ViewBag.bookList = new SelectList(context.Books, "Id", "BookName"); // Kitaplari dropdown'da listeleme
                return View();
            }

            depositBookDAL.InsertorUpdate(context, entity);
            depositBookDAL.Save(context);

            return RedirectToAction("Index");
        }

        public ActionResult UpdateGiveABook(int? id) // Emanet kitap düzenleme action'ı
        {
            if (id == null)
                return HttpNotFound();

            ViewBag.memberList = new SelectList(context.Members, "Id", "NameSurname"); // Uyeleri dropdown'da listeleme
            ViewBag.bookList = new SelectList(context.Books, "Id", "BookName"); // Kitaplari dropdown'da listeleme

            var model = depositBookDAL.GetByFilter(context, x => x.Id == id, "Member", "Book"); // Gelen id'ye gore Member ve Book tablosunu da include ederek DepositBook tablosundan ilgili kaydi cekiyoruz. 
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult UpdateGiveABook(DepositBook entity) // Emanet kitap düzenleme action'ı
        {
            if (!ModelState.IsValid) // Model dogrulanmazsa
            {
                ViewBag.memberList = new SelectList(context.Members, "Id", "NameSurname"); // Uyeleri dropdown'da listeleme
                ViewBag.bookList = new SelectList(context.Books, "Id", "BookName"); // Kitaplari dropdown'da listeleme
                return View();
            }

            depositBookDAL.InsertorUpdate(context, entity);
            depositBookDAL.Save(context);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return HttpNotFound();

            depositBookDAL.Delete(context, x => x.Id == id);
            depositBookDAL.Save(context);

            return RedirectToAction("Index");
        }
    }
}