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

        public Profile Get(String id)
        {
            InfTeamApiDBContext context = new InfTeamApiDBContext();
            var profile = context.Profiles.Include(p => p.Teams).Where(p => p.Id == id).FirstOrDefault();
            return profile;
        }

    }
}
