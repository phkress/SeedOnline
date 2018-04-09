using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service;
using System.Web.Mvc;

namespace infTeam.Controllers
{
    public class MenssageController : Controller
    {

        ProfileService profileService = new ProfileService();

        // GET: Menssage
        public ActionResult Index()
        {
            ViewBag.ProfileIn = profileService.GetProfile(User.Identity.Name);
            return View();
        }
    }
}