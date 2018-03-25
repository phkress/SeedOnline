using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Model.Interface;
using Repository;
using Repository.Persistence;

namespace InfTeamApi.Controllers
{
    public class HomeController : Controller
    {

        ModelUOW modelUOW = new ModelUOW(new InfTeamApiDBContext());

        public ActionResult Index()
        {
            /*Profile profile1 = modelUOW.Profiles.get(1);
            List<Team> teams = new List<Team>();
            Team team = new Team();
            team.Name = "Os local";
            Member member = new Member();
            member.Profile = profile1;
            team.Members.Add(member);
            profile1.Teams = 
            Console.WriteLine(modelUOW.Profiles);
            modelUOW.Complete();
            ViewBag.Title = "Home Page";*/

            return View();
        }
    }
}
