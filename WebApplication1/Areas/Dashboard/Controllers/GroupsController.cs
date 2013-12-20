using System.Web.Mvc;
using Logic.Services;
using WebApplication1.Areas.Dashboard.Models;

namespace WebApplication1.Areas.Dashboard.Controllers
{
    public class GroupsController : Controller
    {
        public GroupService groupService;

        public GroupsController()
        {
            groupService = new GroupService();
        }

        #region Views
        public ActionResult Index()
        {
            var model = new GroupPageModel();

            model.Groups = groupService.Get().ConvertAll(x => x.ToViewModel());

            return View(model);
        }

        public ActionResult Create()
        {
            var model = new GroupModel();

            return View("Edit", model);
        }

        public ActionResult Edit(int id)
        {
            var model = groupService.Find(id).ToViewModel();

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var model = groupService.Find(id).ToViewModel();

            return View(model);
        }
        #endregion

        #region Actions
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Save(GroupModel model)
        {
            if (ModelState.IsValid)
            {
                var success = groupService.Save(model.ToDomainModel());

                if (success)
                {
                    return RedirectToAction("Index");
                }
            }

            return View("Edit", model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete(GroupModel model)
        {
            var success = groupService.Delete(model.Id);

            if (success)
            {
                return RedirectToAction("Index");
            }
            
            return View("Delete", model);
        }
        #endregion
	}
}