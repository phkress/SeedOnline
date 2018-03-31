using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Model;
using Repository.Persistence;
using Repository;
using Service;
using System.Collections.Generic;

namespace InfTeamApi.Controllers
{
    public class TeamsController : ApiController
    {
        TeamService teamService = new TeamService();

        public IEnumerable<Team> GetTeams()
        {
            return teamService.GetTeams();
        }

        [ResponseType(typeof(Profile))]
        public IHttpActionResult GetTeams(int id)
        {
            Team team = teamService.GetTeam(id);

            if (team == null)
            {
                return NotFound();
            }

            return Ok(team);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PutTeam(int id, Team team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != team.Id)
            {
                return BadRequest();
            }


            var result = teamService.UpdateTeam(team);

            if (result)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                return NotFound();
            }
        }

        [ResponseType(typeof(Profile))]
        public IHttpActionResult PostTeam(Team team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            teamService.Add(team);

            return CreatedAtRoute("DefaultApi", new { id = team.Id }, team);
        }

        [ResponseType(typeof(Profile))]
        public IHttpActionResult DeleteTeam(int id)
        {
            Team team = teamService.GetTeam(id);

            if (team == null)
            {
                return NotFound();
            }

            teamService.Delete(team);
            return Ok(team);
        }
    }
}