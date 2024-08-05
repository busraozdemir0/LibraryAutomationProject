using LibraryAutomation.Entities.DAL;
using LibraryAutomation.Entities.Model;
using LibraryAutomation.Entities.Model.Context;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryAutomationProject.Controllers
{
    public class BookTypesController : Controller
    {
        // GET: BookTypes
        LibraryContext context = new LibraryContext();
        BookTypesDAL bookTypesDAL = new BookTypesDAL();

        // Action adini Index2 yaparak ilgili View'daki arama sorununun onune gecmis oluyoruz.
        //(Adi Index iken arama kutusu/filtreleme sonucunda hata veriyor)
        public ActionResult Index2(string search, int? page)
        {
            // Arama kutusuna hicbir sey yazmazsak yani bos gecersek tum kayitlari getirir,
            // eger bir ifade yazarsak o ifadeyi iceren kitap turlerini filtreleyerek getirir.

            var model = bookTypesDAL.GetAll(context).ToPagedList(page ?? 1, 3); // page ifadesi bos ise 1 ata (Yani sayfa numarasi bos ise 1. sayfadan baslat)
            if (search != null)
            {
                model = bookTypesDAL.GetAll(context, x => x.BookType.Contains(search)).ToPagedList(page ?? 1, 3); // 1. sayfadan baslat ve her sayfada en fazla 3 veri olsun.
            }
            return View("Index",model);
        }

        public ActionResult Add()
        {
            return View();
        }

        [ValidateAntiForgeryToken] // Dogrulama islemleri icin (Fluent Validation)
        [HttpPost]
        public ActionResult Add(BookTypes bookTypes)
        {
            if (ModelState.IsValid)
            {
                bookTypesDAL.InsertorUpdate(context, bookTypes);
                bookTypesDAL.Save(context);
                return RedirectToAction("Index");
            }
            return View(bookTypes);
        }

        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var result = bookTypesDAL.GetById(context, id);
            return View(result);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Update(BookTypes bookTypes)
        {
            if (ModelState.IsValid)
            {
                bookTypesDAL.InsertorUpdate(context, bookTypes);
                bookTypesDAL.Save(context);
                return RedirectToAction("Index");
            }
            return View(bookTypes);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            bookTypesDAL.Delete(context, x => x.Id == id);
            bookTypesDAL.Save(context);
            return RedirectToAction("Index");
        }
    }
}