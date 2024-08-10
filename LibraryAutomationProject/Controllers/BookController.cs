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
    public class BookController : Controller
    {
        LibraryContext context = new LibraryContext();
        BookDAL bookDAL = new BookDAL();

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