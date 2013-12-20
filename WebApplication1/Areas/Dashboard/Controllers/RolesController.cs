using System.Data.Entity.Core.Objects;
using System.Web.Mvc;
using Antlr.Runtime.Misc;
using Logic.Model;
using Logic.Services;
using WebApplication1.Areas.Dashboard.Models;

namespace WebApplication1.Areas.Dashboard.Controllers
{
    public class RolesController : Controller
    {
        public RoleService roleService;

        public RolesController()
        {
            roleService = new RoleService();
        }

        #region Views
        public ActionResult Index()
        {
            var model = new RolePageModel();

            model.Roles = roleService.Get().ConvertAll(x => x.ToViewModel());

            return View(model);
        }

        public ActionResult Create()
        {
            var model = new RoleModel();

            return View("Edit", model);
        }

        public ActionResult Edit(int id)
        {
            var model = roleService.Find(id).ToViewModel();

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var model = roleService.Find(id).ToViewModel();

            return View(model);
        }
        #endregion

        #region Actions
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Save(RoleModel model)
        {
            if (ModelState.IsValid)
            {
                var success = roleService.Save(model.ToDomainModel());

                if (success)
                {
                    return RedirectToAction("Index");
                }
            }

            return View("Edit", model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete(RoleModel model)
        {
            var success = roleService.Delete(model.Id);

            if (success)
            {
                return RedirectToAction("Index");
            }

            return View("Delete", model);
        }
        #endregion
    }
}