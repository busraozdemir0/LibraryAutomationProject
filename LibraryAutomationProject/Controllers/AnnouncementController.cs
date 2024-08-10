using LibraryAutomation.Entities.DAL;
using LibraryAutomation.Entities.Model;
using LibraryAutomation.Entities.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryAutomationProject.Controllers
{
    public class AnnouncementController : Controller
    {
        LibraryContext context = new LibraryContext();
        AnnouncementDAL announcementDAL = new AnnouncementDAL();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult AnnouncementList()
        {
            var model = announcementDAL.GetAll(context);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AnnouncementAdd(Announcement announcement)
        {
            if (ModelState.IsValid)
            {
                announcementDAL.InsertorUpdate(context, announcement);
                announcementDAL.Save(context);
                return Json(new { success = true, message = "İşlem başarıyla gerçekleşti." });
            }
            var errors = ModelState.ToDictionary(x => x.Key,
                x => x.Value.Errors.Select(a => a.ErrorMessage).ToArray()
            );
            return Json(new { success = false, errors }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AnnouncementGet(int? id)
        {
            var model = announcementDAL.GetByFilter(context, x => x.Id == id);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AnnouncementDelete(int? id)
        {
            announcementDAL.Delete(context, x => x.Id == id);
            announcementDAL.Save(context);
            return Json(new { success = true });
        }
    }
}