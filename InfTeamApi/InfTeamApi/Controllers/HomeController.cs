using Repository;
using Repository.Persistence;
using System.Web.Mvc;

namespace InfTeamApi.Controllers
{
    public class HomeController : Controller
    {

        ModelUOW db = new ModelUOW(new InfTeamApiDBContext());

        public ActionResult Index()
        {
            return View();
        }
    }
}
