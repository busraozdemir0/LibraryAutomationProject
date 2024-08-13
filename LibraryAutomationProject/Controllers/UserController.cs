using LibraryAutomation.Entities.DAL;
using LibraryAutomation.Entities.Mapping;
using LibraryAutomation.Entities.Model;
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
    //[AllowAnonymous]
    public class UserController : Controller
    {
        LibraryContext context = new LibraryContext();
        UserDAL userDAL = new UserDAL();
        UserRoleDAL userRoleDAL = new UserRoleDAL();
        RoleDAL roleDAL = new RoleDAL();
        UserMovementsDAL userMovementsDAL = new UserMovementsDAL();
        
        // Kullanici hareketleri tablosuna kayit islemi gerceklestirmek icin olusturulan metod
        public void UserMovements(int userId, int processDoId, string explanation)
        {
            var model = new UserMovements
            {
                Explanation=explanation,
                ProcessDo=processDoId, // islemi gerceklestiren kulanicinin id'si
                UserId =userId,
                CreatedDate=DateTime.Now
            };

            userMovementsDAL.InsertorUpdate(context,model);
            userMovementsDAL.Save(context);
        }

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

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            userDAL.InsertorUpdate(context, user);
            userDAL.Save(context);

            // kullanici eklenmesi esnasinda kullanici hareketleri tablosuna veri/bilgi ekleme
            int userId = context.Users.Max(x => x.Id); // En son kaydedilen kisinin id'si en buyuk olacagi icin son kullaniciyi cekiyoruz
            var userName = User.Identity.Name; // Giris yapan kisinin bilgisi
            var model = userDAL.GetByFilter(context, x => x.Email == userName); // Giris yapan kisinin tum bilgilerini db'den cekiyoruz
            var processDoId = model.Id; // islemi gerceklestiren kulanicinin id'si
            string explanation = model.UserName + " kulanıcısı yeni bir kullanıcı ekledi.";
            UserMovements(userId, processDoId,explanation);

            return RedirectToAction("Index2");
        }

        public ActionResult Update(int? id)
        {
            if(id == null)
            {
                return HttpNotFound("Id değeri girilmedi");
            }
            var model = userDAL.GetById(context, id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            userDAL.InsertorUpdate(context, user);
            userDAL.Save(context);
            return RedirectToAction("Index2");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            userDAL.Delete(context, x => x.Id == id);
            userDAL.Save(context);
            return RedirectToAction("Index2");
        }

    }
}