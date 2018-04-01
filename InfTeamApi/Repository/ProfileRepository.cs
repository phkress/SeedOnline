using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Interface;
using Repository.Persistence;
using System.Data.Entity;

namespace Repository
{
    public class ProfileRepository : Repository<Profile>, IProfile
    {
        public ProfileRepository(InfTeamApiDBContext context) :base(context)
        {
        }

        InfTeamApiDBContext dbcontext = new InfTeamApiDBContext();

        public Profile Get(String id)
        {
            var profile = dbcontext.Profiles.Include(p => p.Teams).Include(p => p.Contacts).Single(p => p.Id == id);
            return profile;
        }

        public IEnumerable<Profile> GetAll()
        {
            return dbcontext.Profiles.Include(p => p.Teams).Include(p => p.Contacts);
        }

    }
}
