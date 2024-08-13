using LibraryAutomation.Entities.DAL;
using LibraryAutomation.Entities.Mapping;
using LibraryAutomation.Entities.Model;
using LibraryAutomation.Entities.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryAutomationProject.Controllers
{
    [Authorize(Roles = "Admin, Moderatör")]
    public class BookController : Controller
    {
        LibraryContext context = new LibraryContext();
        BookDAL bookDAL = new BookDAL();
        UserDAL userDAL = new UserDAL();
        BookRegistrationMovementsDAL bookRegistrationMovementsDAL = new BookRegistrationMovementsDAL();

        // Kitap kayit hareketleri tablosuna bilgi eklemek icin kullanilan metod
        public void BookRegistrationMovements(int userId, int bookId, string transaction, string explanation)
        {
            var model = new BookRegistrationMovements
            {
                UserId = userId,
                BookId = bookId,
                Transaction = transaction,
                Explanation = explanation,
                CreatedDate = DateTime.Now
            };

            bookRegistrationMovementsDAL.InsertorUpdate(context, model);
            bookRegistrationMovementsDAL.Save(context);
        }
        public ActionResult Index()
        {
            var model = bookDAL.GetAll(context, null, "BookTypes"); // Arkaplanda Kitap Turleri tablosu Kitap tablosuna include ediliyor
            return View(model);
        }

        public ActionResult Detail(int? id)
        {
            var model = bookDAL.GetByFilter(context, x => x.Id == id, "BookTypes"); // Arkaplanda Kitap Turleri tablosu Kitap tablosuna include ediliyor
            return View(model);
        }

        public ActionResult Add()
        {
            ViewBag.bookTypesList = new SelectList(context.BookTypes, "Id", "BookType"); // Kitap turlerini dropdown'da listeleme
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Book book)
        {
            if (!ModelState.IsValid) // Model dogrulanmazsa
            {
                ViewBag.bookTypesList = new SelectList(context.BookTypes, "Id", "BookType"); // Kitap turlerini dropdown'da listeleme
                return View();
            }
            bookDAL.InsertorUpdate(context, book);
            bookDAL.Save(context);

            // Kitap kayit hareketleri tablosuna yeni bir veri/bilgi ekleme (Kitap kayit hareketlerini gozlemlemek icin)
            int bookId = context.Books.Max(x => x.Id);
            var userName = User.Identity.Name;
            var modelUser = userDAL.GetByFilter(context, x => x.Email == userName);
            int userId = modelUser.Id;
            BookRegistrationMovements(userId, bookId, modelUser.UserName + " kullanıcısı yeni bir kitap ekledi.", "Kitap ekleme işlemi");

            return RedirectToAction("Index");
        }

        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            ViewBag.bookTypesList = new SelectList(context.BookTypes, "Id", "BookType"); // Kitap turlerini dropdown'da listeleme

            var model = bookDAL.GetByFilter(context, x => x.Id == id, "BookTypes");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Book book)
        {
            if (!ModelState.IsValid) // Model dogrulanmazsa
            {
                ViewBag.bookTypesList = new SelectList(context.BookTypes, "Id", "BookType"); // Kitap turlerini dropdown'da listeleme
                return View();
            }
            bookDAL.InsertorUpdate(context, book);
            bookDAL.Save(context);

            // Kitap kayit hareketleri tablosuna yeni bir veri/bilgi ekleme (Kitap kayit hareketlerini gozlemlemek icin)
            int bookId = book.Id;
            var userName = User.Identity.Name;
            var modelUser = userDAL.GetByFilter(context, x => x.Email == userName);
            int userId = modelUser.Id;
            BookRegistrationMovements(userId, bookId, modelUser.UserName + " kullanıcısı bir kitabı güncellendi.", "Kitap güncelleme işlemi");

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            bookDAL.Delete(context, x => x.Id == id);
            bookDAL.Save(context);
            return RedirectToAction("Index");
        }
    }
}