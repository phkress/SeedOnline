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
        private void StoreUserId()
        {
            if (User.Identity.Name != null || User.Identity.Name != "")
            {
                ProfileService profileService = new ProfileService();
                ICollection<Profile> profiles = profileService.GetAll().ToList();
                Profile profile = profiles.Where(p => p.Email == User.Identity.Name).First();
                Session["User"] = profile.Id;
            }
        }

        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult In()
        {
            StoreUserId();
            ProfileService profileService = new ProfileService();
            var profileId = Convert.ToInt32(Session["User"]);
            Profile profile = profileService.GetProfile(profileId);
            ViewBag.ProfileIn = profile;
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