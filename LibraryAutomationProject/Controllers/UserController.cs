﻿using LibraryAutomation.Entities.DAL;
using LibraryAutomation.Entities.Model.Context;
using LibraryAutomation.Entities.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryAutomationProject.Controllers
{
    [Authorize(Roles = "Admin,Moderatör")]
    public class UserController : Controller
    {
        LibraryContext context = new LibraryContext();
        UserDAL userDAL = new UserDAL();
        UserRoleDAL userRoleDAL = new UserRoleDAL();
        RoleDAL roleDAL = new RoleDAL();

        // GET: User
        public ActionResult Index()
        {
            var model = userDAL.GetAll(context);
            return View(model);
        }

        public ActionResult Index2()
        {
            var users = userDAL.GetAll(context,table: "UserRoles");
            var roles = roleDAL.GetAll(context);
            return View(new UserRoleViewModel { Users = users, Roles = roles });
        }

        // Kullanici rollerini listeleme islemi
        public ActionResult UserRoles(int id)
        {
            // Gelen kullanici id'si ile eslesen rolleri userRole tablosundan getirtiyoruz (Role tablosunu dahil ederek)
            var model = userRoleDAL.GetAll(context, x => x.UserId == id, "Role");
            if (model != null)
            {
                return View(model);
            }
            return HttpNotFound();
        }


    }
}