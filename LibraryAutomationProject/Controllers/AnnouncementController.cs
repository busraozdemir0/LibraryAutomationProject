using LibraryAutomation.Entities.DAL;
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
        AnnouncementDAL announcementDAL=new AnnouncementDAL();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult AnnouncementList()
        {
            var model = announcementDAL.GetAll(context);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}