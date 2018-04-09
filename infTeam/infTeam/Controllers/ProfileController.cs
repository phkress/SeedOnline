using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using Model;

namespace infTeam.Controllers
{
    public class ProfileController : Controller
    {
        ProfileService profileService = new ProfileService();

        // GET: Profile
        public ActionResult Index()
        {
            var result = TempData["searchResult"];
            ViewBag.ProfileIn = profileService.GetProfile(User.Identity.Name);
            ViewBag.AllProfiles = profileService.GetAll();
            if (result != null)
            {
                ViewBag.AllProfiles = result;
            }
            ViewBag.Error = TempData["Error"];
            return View();
        }

        // POST: Profile
        public ActionResult SearchContact(FormCollection col)
        {
            var result = profileService.SearchContact(col["searchText"]);            
                TempData["searchResult"] = result;
                TempData["Error"] = "";
            if (result.Count() == 0)
            {
                TempData["Error"] = "Nenhum resultado.";
            }                
            return RedirectToAction("Index", "Profile");
        }

        public ActionResult MyContacts()
        {

            ViewBag.ProfileIn = profileService.GetProfile(User.Identity.Name);
            return View();
        }

        // GET: Profile/Details/5
        public ActionResult Details(String id)
        {
            ViewBag.ProfileIn = profileService.GetProfile(User.Identity.Name);
            ViewBag.ProfileDetail = profileService.GetProfile(id);
            return View();
        }

        public RedirectToRouteResult AdicionarContato(String id)
        {
            try
            {
                Profile profile = profileService.GetProfile(User.Identity.Name);
                profileService.AddContact(id, profile);
                ViewBag.ProfileIn = profileService.GetProfile(User.Identity.Name);
                ViewBag.AllProfiles = profileService.GetAll();
                return RedirectToAction("Index", "Profile");
            }
            catch
            {
                ViewBag.ProfileIn = profileService.GetProfile(User.Identity.Name);
                ViewBag.AllProfiles = profileService.GetAll();
                return RedirectToAction("Index", "Profile");
            }

        }

        public RedirectToRouteResult SendMenssage(FormCollection col)
        {
            var formId = col["id"];
            var text = col["postTextarea"];
            Profile profile = profileService.GetProfile(User.Identity.Name);
            Profile profileToSend = profileService.GetProfile(formId);
            var menssage = new Menssage()
            {
                Text = text,
                Date = DateTime.Now,
                Sender = profile.Id,
                ProfileNameStored = profile.Name,
            };
            profileToSend.Menssages.Add(menssage);
            profileService.SendMenssage(formId, profileToSend);
            return RedirectToAction("Details", "Profile", new { id = formId + "/"});
        }

        public RedirectToRouteResult RemoverContato(String id)
        {
            try
            {
                Profile profile = profileService.GetProfile(User.Identity.Name);
                profileService.RemoveContact(id, profile);
                ViewBag.ProfileIn = profileService.GetProfile(User.Identity.Name);
                ViewBag.AllProfiles = profileService.GetAll();
                return RedirectToAction("Index", "Profile");
            }
            catch
            {
                ViewBag.ProfileIn = profileService.GetProfile(User.Identity.Name);
                ViewBag.AllProfiles = profileService.GetAll();
                return RedirectToAction("Index", "Profile");
            }

        }

        // GET: Profile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profile/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Profile/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Profile/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Profile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Profile/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
