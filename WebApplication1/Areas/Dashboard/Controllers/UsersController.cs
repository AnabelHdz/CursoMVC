using System.Web.Mvc;
using Logic.Services;
using WebApplication1.Areas.Dashboard.Models;

namespace WebApplication1.Areas.Dashboard.Controllers
{
    using System.Collections.Generic;
    using System.Runtime.Remoting.Messaging;
    using System.Web.ApplicationServices;

    public class UsersController : Controller
    {
        private UserService userService;

        public UsersController()
        {
            userService = new UserService();
        }

        #region Views
        public ActionResult Index()
        {
            var model = new UserPageModel();
            model.Users = userService.Get().ConvertAll(x => x.ToViewModel());

            return View(model);
        }

        public ActionResult Create()
        {
            var model = new UserModel();

            var roles = new Logic.Services.RoleService().Get().ConvertAll(x => x.ToViewModel());

            foreach (var role in roles)
            {
                model.Roles.Add(new SelectListItem { Text = role.Name, Value = role.Id.ToString() });
            }

            return View("Edit", model);
        }

        public ActionResult Edit(int id)
        {
            var model = userService.Find(id).ToViewModel();
            
            var roles = new Logic.Services.RoleService().Get().ConvertAll(x => x.ToViewModel());
            foreach (var role in roles)
            {
                model.Roles.Add(new SelectListItem { Text = role.Name, Value = role.Id.ToString(), Selected = role.Id==model.RoleId});
            }

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var model = userService.Find(id).ToViewModel();

            return View(model);
        }
        #endregion

        #region Actions
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Save(UserModel model)
        {
            if (ModelState.IsValid)
            {
                var success = userService.Save(model.ToDomainModel());

                if (success)
                {
                    return RedirectToAction("Index");
                }
            }

            return View("Edit", model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete(UserModel model)
        {
            var success = userService.Delete(model.Id);

            if (success)
            {
                return RedirectToAction("Index");
            }

            return View("Delete", model);
        }
        #endregion
    }
}