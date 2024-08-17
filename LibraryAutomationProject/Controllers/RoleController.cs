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
    public class RoleController : Controller
    {
        LibraryContext context = new LibraryContext();
        RoleDAL roleDAL = new RoleDAL();
        // GET: Role
        public ActionResult Index()
        {
            var model = roleDAL.GetAll(context);
            return View(model);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Add(Role role)
        {
            if (!ModelState.IsValid)
            {
                return View(role);
            }
            roleDAL.InsertorUpdate(context, role);
            roleDAL.Save(context);
            return RedirectToAction("Index");
        }

        public ActionResult Update(int? id)
        {
            if (id == null)
                return HttpNotFound("Id değeri girilmedi.");
            var result = roleDAL.GetByFilter(context, x => x.Id == id);
            return View(result);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Update(Role role)
        {
            if (!ModelState.IsValid)
            {
                return View(role);
            }
            roleDAL.InsertorUpdate(context, role);
            roleDAL.Save(context);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            roleDAL.Delete(context, x => x.Id == id);
            roleDAL.Save(context);
            return RedirectToAction("Index", "Role");
        }
    }
}