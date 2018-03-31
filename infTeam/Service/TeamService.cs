using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Model;

namespace Service
{
    public class TeamService
    {
        TeamRepository teamRepository = new TeamRepository();

        public IEnumerable<Team> GetAll()
        {
            return teamRepository.GetAll();
        }

        public Team GetTeam(int id)
        {
            Team team = teamRepository.GetTeam(id);
            return team;
        }

        public void UpdateTeam(int id, Team team)
        {
            teamRepository.UpdateTeam(id, team);
        }

        public void CreateNewTeam(Team team)
        {
            teamRepository.Add(team);
        }

        public void Remove(Team team)
        {
            teamRepository.Remove(team);
        }
    }
}
