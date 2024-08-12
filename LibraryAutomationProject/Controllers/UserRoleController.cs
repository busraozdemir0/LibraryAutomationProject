using LibraryAutomation.Entities.DAL;
using LibraryAutomation.Entities.Model;
using LibraryAutomation.Entities.Model.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryAutomationProject.Controllers
{
    [AllowAnonymous]
    public class UserRoleController : Controller
    {
        LibraryContext context = new LibraryContext();
        UserRoleDAL userRoleDAL = new UserRoleDAL();
        // GET: UserRole
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add(int? id)
        {
            if (id == null)
            {
                return HttpNotFound("Kullanıcı Id değeri girilmedi.");
            }
            var model = userRoleDAL.GetByFilter(context, x => x.UserId == id, "User");
            ViewBag.userId = id;
            ViewBag.userName = model.User.UserName;
            ViewBag.rolesList = new SelectList(context.Roles, "Id", "RoleName");
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Add(UserRole entity)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.rolesList = new SelectList(context.Roles, "Id", "RoleName");

                var model = userRoleDAL.GetByFilter(context, x => x.UserId == entity.UserId, "User");
                ViewBag.userId = entity.UserId;
                ViewBag.userName = model.User.UserName;
                return View(entity);
            }

            entity.Id = 0;
            userRoleDAL.InsertorUpdate(context, entity);
            userRoleDAL.Save(context);
            return RedirectToAction("Index2", "User");
        }

        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return HttpNotFound("Kullanıcı Id değeri girilmedi.");
            }
            var model = userRoleDAL.GetByFilter(context, x => x.Id == id, "User");
            ViewBag.userName = model.User.UserName;
            ViewBag.rolesList = new SelectList(context.Roles, "Id", "RoleName");
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Update(UserRole entity)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.rolesList = new SelectList(context.Roles, "Id", "RoleName");
                var model = userRoleDAL.GetByFilter(context, x => x.Id == entity.Id, "User");
                ViewBag.userName = model.User.UserName;
                return View(entity);
            }

            userRoleDAL.InsertorUpdate(context, entity);
            userRoleDAL.Save(context);
            return RedirectToAction("Index2", "User");
        }

        public ActionResult Delete(int? id)
        {
            userRoleDAL.Delete(context, x => x.Id == id);
            userRoleDAL.Save(context);
            return RedirectToAction("Index2", "User");
        }
    }
}