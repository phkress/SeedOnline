﻿using System;
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
    [OutputCache(NoStore = true, Duration = 0)]
    public class HomeController : Controller
    {
        ProfileService profileService = new ProfileService();

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
            return RedirectToAction("In");
        }

        [Authorize]
        public ActionResult In()
        {
            
            Profile profile = profileService.GetProfile(User.Identity.Name);
            ViewBag.ProfileIn = profile;
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult AddTodo(FormCollection col)
        {
            var text = col["todoTextInput"];

            if (text == null || text == "")
            {
                return RedirectToAction("In");
            }

            Profile profile = profileService.GetProfile(User.Identity.Name);
            profileService.AddTodo(text, profile);
            return RedirectToAction("In");
        }

        public ActionResult RemoveTodo(int id)
        {
            Profile profile = profileService.GetProfile(User.Identity.Name);
            profileService.RemoveTodo(id, profile);
            return RedirectToAction("In");
        }
    }
}