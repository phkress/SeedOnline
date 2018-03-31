using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service;
using System.Web.Mvc;
using Model;

namespace infTeam.Controllers
{
    public class TeamController : Controller
    {
        TeamService teamService = new TeamService();
        ProfileService profileService = new ProfileService();
        // GET: Team
        public ActionResult Index()
        {
            IEnumerable<Team> teams = teamService.GetAll();
            Profile profile = profileService.GetProfile(User.Identity.Name);
            ViewBag.ProfileIn = profile;
            ViewBag.MyTeams = teams.Where(t => profile.Teams.Contains(t));
            ViewBag.AllTeams = teams.Where(t => !profile.Teams.Contains(t));

            return View();
        }

        // GET: Team/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.ProfileIn = profileService.GetProfile(User.Identity.Name);
            var team = teamService.GetTeam(id);
            ViewBag.SelectedTeam = team;
            return View();
        }

        // GET: Team/Create
        public ActionResult Create()
        {
            Profile profile = profileService.GetProfile(User.Identity.Name);
            ViewBag.ProfileIn = profile;
            return View();
        }

        // POST: Team/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Team team = new Team()
                {
                    Name = collection["Name"],
                    Description = collection["Description"]
                };

                teamService.CreateNewTeam(team);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        // POST: Team/Enter
        public ActionResult Enter(int id)
        {
            try
            {
                Team team = teamService.GetTeam(id);
                Profile profile = profileService.GetProfile(User.Identity.Name);
                team.Profiles.Add(profile);
                teamService.UpdateTeam(id, team);
                return RedirectToAction("In", "Home");
            }
            catch
            {
                return RedirectToAction("Details/" + id);
            }
        }

        // GET: Team/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Team/Edit/5
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

        // GET: Team/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Team/Delete/5
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
