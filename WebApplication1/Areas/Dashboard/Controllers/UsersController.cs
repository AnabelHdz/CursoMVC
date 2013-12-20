using System.Web.Mvc;

namespace WebApplication1.Areas.Dashboard.Controllers
{
    public class UsersController : Controller
    {
        //
        // GET: /Dashboard/Users/
        public ActionResult Index()
        {
            return View();
        }
	}
}