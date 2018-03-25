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

        ModelUOW db = new ModelUOW(new InfTeamApiDBContext());

        public ActionResult Index()
        {
            return View();
        }
    }
}
