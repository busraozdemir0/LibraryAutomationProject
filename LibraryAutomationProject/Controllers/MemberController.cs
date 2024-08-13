using LibraryAutomation.Entities.DAL;
using LibraryAutomation.Entities.Model;
using LibraryAutomation.Entities.Model.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryAutomationProject.Controllers
{
    [AllowAnonymous] // Daha sonradan bu alanlar düzenlenerek yetkilendirilecek
    public class MemberController : Controller
    {
        LibraryContext context = new LibraryContext();
        MemberDAL memberDAL = new MemberDAL();
        // GET: Member
        public ActionResult Index()
        {
            var model = memberDAL.GetAll(context);
            return View(model);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Add(Member member, HttpPostedFileBase ImagePath) // HttpPostedFileBase => resim yuklemek icin (ImagePath dememizin sebebi view'daki gorsel kismindaki degisken adi ile ayni olmasi icin)
        {
            if (ModelState.IsValid)
            {
                // Resim yukleme islemleri
                if (ImagePath != null && ImagePath.ContentLength > 0) // ImagePath null degilse ve resim gercekten varsa
                {
                    var image = Path.GetFileName(ImagePath.FileName);
                    string path = Path.Combine(Server.MapPath("~/images"), image); // resmin eklenecegi yol (images klasorune eklenecek)

                    if (System.IO.File.Exists(path) == false)
                    {
                        ImagePath.SaveAs(path);
                    }
                    member.ImagePath = "/images/" + image;
                }
                memberDAL.InsertorUpdate(context, member);
                memberDAL.Save(context);
                return RedirectToAction("Index");
            }

            return View(member);
        }

        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var model = memberDAL.GetByFilter(context, x => x.Id == id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Update(Member member, HttpPostedFileBase ImagePath) // HttpPostedFileBase => resim yuklemek icin (ImagePath dememizin sebebi view'daki gorsel kismindaki degisken adi ile ayni olmasi icin)
        {
            if (ModelState.IsValid)
            {
                var model = memberDAL.GetByFilter(context, x => x.Id == member.Id);

                member.ImagePath = model.ImagePath; // Eger resim secilmemisse db'de var olan resim tekrar aktarilsin

                // Sayet resim secilmisse Resim yukleme islemleri gerceklestiriliyor
                if (ImagePath != null && ImagePath.ContentLength > 0) // ImagePath null degilse ve resim gercekten varsa
                {
                    var image = Path.GetFileName(ImagePath.FileName);
                    string path = Path.Combine(Server.MapPath("~/images"), image); // resmin eklenecegi yol (images klasorune eklenecek)
                    if (System.IO.File.Exists(path) == false)
                    {
                        ImagePath.SaveAs(path);
                    }
                    member.ImagePath = "/images/" + image;

                }
                memberDAL.InsertorUpdate(context, member);
                memberDAL.Save(context);
                return RedirectToAction("Index");
            }

            return View(member);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            memberDAL.Delete(context, x => x.Id == id);
            memberDAL.Save(context);
            return RedirectToAction("Index");
        }
    }
}