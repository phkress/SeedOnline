using System.Collections.Generic;
using Model;

namespace Repository
{
    public class TeamRepository
    {

        RepositoryComposer<Team> repositoryComposer = new RepositoryComposer<Team>("http://localhost:53480");

        public IEnumerable<Team> GetAll()
        {
            repositoryComposer.Path = "/api/teams";
            return repositoryComposer.GetAll();
        }

        public Team GetTeam(int id)
        {
            repositoryComposer.Path = "/api/teams/" + id;
            Team team = repositoryComposer.Get();
            return team;
        }

        public void UpdateTeam(int id, Team team)
        {
            repositoryComposer.Path = "/api/teams/" + id;
            repositoryComposer.Update(team);
        }

        public void Add(Team team)
        {
            repositoryComposer.Path = "/api/teams";
            repositoryComposer.Add(team);
        }

        public void Remove(Team team)
        {
            repositoryComposer.Path = "/api/teams/" + team.Id;
            repositoryComposer.Remove(team);
        }
    }
}
