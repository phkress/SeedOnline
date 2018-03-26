using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repository;
using Model;
using Service;
using Microsoft.AspNet.Identity;

namespace infTeam.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult In()
        {
            ProfileService profileService = new ProfileService();
            Profile profileIn = profileService.GetProfile(User.Identity.GetUserName());

            ViewBag.ProfileIn = profileIn;
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}