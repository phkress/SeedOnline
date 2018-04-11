using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service;
using System.Web.Mvc;
using Model;
using System.Threading.Tasks;

namespace infTeam.Controllers
{
    [OutputCache(NoStore = true, Duration = 0)]
    public class TeamController : Controller
    {
        TeamService teamService = new TeamService();
        ProfileService profileService = new ProfileService();
        ImageService imageService = new ImageService();

        // GET: Team
        public ActionResult Index()
        {
            var result = TempData["searchResult"];
            ViewBag.ProfileIn = profileService.GetProfile(User.Identity.Name);
            ViewBag.AllTeams = teamService.GetAll();
            if (result != null)
            {
                ViewBag.AllTeams = result;
            }
            ViewBag.Error = TempData["Error"];
            return View();
        }

        // POST: Team
        public ActionResult SearchContact(FormCollection col)
        {
            var result = teamService.SearchContact(col["searchText"]);
            TempData["searchResult"] = result;
            TempData["Error"] = "";
            if (result.Count() == 0)
            {
                TempData["Error"] = "Nenhum resultado.";
            }
            return RedirectToAction("Index", "Team");
        }

        public ActionResult MyTeams()
        {
            Profile profile = profileService.GetProfile(User.Identity.Name);
            ViewBag.ProfileIn = profile;
            return View();
        }

        public ActionResult In(int id)
        {
            Profile profile = profileService.GetProfile(User.Identity.Name);
            if (!profile.Teams.Any(t => t.Id == id))
            {
                return RedirectToAction("Index", "Team");
            }

            ViewBag.SelectedTeam = teamService.GetTeam(id);
            ViewBag.ProfileIn = profile;
            return View();
        }

        
        [HttpPost]
        public async Task<ActionResult> In(int id, HttpPostedFileBase photo, FormCollection collection)
        {


            Profile profile = profileService.GetProfile(User.Identity.Name);
            if (!profile.Teams.Any(t => t.Id == id))
            {
                return RedirectToAction("Index", "Team");
            }


            var imageUrl = await imageService.UploadImageAsync(photo);

            Team team = teamService.GetTeam(id);

            var foto = "";

            if (imageUrl != null && imageUrl != "")
            {
                foto = imageUrl;
            }
            Post post = new Post()
            {
                Photo = foto,
                Text = collection["postTextarea"],
                Date = DateTime.Now,
                Profile = profile,
                ProfileNameStored = profile.Name
            };
            team.Posts.Add(post);
            teamService.UpdateTeam(id, team);
            
            ViewBag.SelectedTeam = teamService.GetTeam(id);
            ViewBag.ProfileIn = profile;

            return RedirectToAction("In", "Team", new { id = id });
        }

        // GET: Team/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.ProfileIn = profileService.GetProfile(User.Identity.Name);
            ViewBag.SelectedTeam = teamService.GetTeam(id);
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



        // POST: Team/Enter/1
        public ActionResult Enter(int id)
        {
            try
            {
                Team team = teamService.GetTeam(id);
                Profile profile = profileService.GetProfile(User.Identity.Name);
                team.Profiles.Add(profile);
                teamService.UpdateTeam(id, team);
                ViewBag.ProfileIn = profileService.GetProfile(User.Identity.Name);
                ViewBag.SelectedTeam = teamService.GetTeam(id);
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.ProfileIn = profileService.GetProfile(User.Identity.Name);
                ViewBag.SelectedTeam = teamService.GetTeam(id);
                return RedirectToAction("Index");
            }
        }

        // POST: Team/leave/1
        public ActionResult Leave(int id)
        {
            try
            {
                Team team = teamService.GetTeam(id);
                Profile profile = profileService.GetProfile(User.Identity.Name);
                team.Profiles = team.Profiles.Where(t => t.Id != profile.Id).ToList();
                teamService.UpdateTeam(id, team);
                ViewBag.ProfileIn = profileService.GetProfile(User.Identity.Name);
                ViewBag.SelectedTeam = teamService.GetTeam(id);
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.ProfileIn = profileService.GetProfile(User.Identity.Name);
                ViewBag.SelectedTeam = teamService.GetTeam(id);
                return RedirectToAction("Index");
            }
        }

        // GET: Team/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.ProfileIn = profileService.GetProfile(User.Identity.Name);
            ViewBag.SelectedTeam = teamService.GetTeam(id);
            return View();
        }

        // POST: Team/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Team team = teamService.GetTeam(id);
                team.Name = collection["Name"];
                team.Description = collection["Description"];
                teamService.UpdateTeam(id, team);
                ViewBag.ProfileIn = profileService.GetProfile(User.Identity.Name);
                ViewBag.SelectedTeam = teamService.GetTeam(id);
                return RedirectToAction("In", "Team", new { id = id});
            }
            catch
            {
                ViewBag.ProfileIn = profileService.GetProfile(User.Identity.Name);
                ViewBag.SelectedTeam = teamService.GetTeam(id);
                return View();
            }
        }

        // GET: Team/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.ProfileIn = profileService.GetProfile(User.Identity.Name);
            ViewBag.SelectedTeam = teamService.GetTeam(id);
            return View();
        }

        // POST: Team/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection c)
        {
            try
            {
                var team = teamService.GetTeam(id);
                teamService.Remove(team);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
