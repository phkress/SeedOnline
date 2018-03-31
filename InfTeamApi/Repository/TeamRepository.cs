using Model;
using Model.Interface;
using Repository.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace Repository
{
    public class TeamRepository : Repository<Team>, ITeam
    {
        InfTeamApiDBContext dbcontext = new InfTeamApiDBContext();

        public TeamRepository(InfTeamApiDBContext context) :base(context)
        {
        }

        override
        public Team Get(int id)
        {
            var team = Context.Set<Team>().Include(t => t.Profiles).Where(t => t.Id == id).FirstOrDefault();
            return team;
        }

        public IEnumerable<Team> GetAll()
        {
            return dbcontext.Teams.Include(t => t.Profiles);
        }

        public void Update(Team team)
        {


            var teamToUpdate = dbcontext.Teams.Include(t => t.Profiles).Single(t => t.Id == team.Id);
            teamToUpdate.Name = team.Name;
            teamToUpdate.Description = team.Name;


            var profiles = dbcontext.Profiles.ToList();
            var collectionOfProfileToUpdateTo = profiles.Where(p => team.Profiles.Any(prl => prl.Id == p.Id));
            teamToUpdate.Profiles.Clear();
            foreach (var newProfile in collectionOfProfileToUpdateTo)
            {
                teamToUpdate.Profiles.Add(newProfile);
            }

            dbcontext.SaveChanges();
        }


    }
}
