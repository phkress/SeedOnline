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
            var profile = dbcontext.Profiles.Include(p => p.Contacts).Include(p => p.Teams).Include(p => p.Menssages).Single(p => p.Id == id);
            return profile;
        }

        public IEnumerable<Profile> GetAll()
        {
            return dbcontext.Profiles.Include(p => p.Contacts).Include(p => p.Teams).Include(p => p.Menssages);
        }

        public void Update(Profile profile)
        {
            var ProfileToUpdate = dbcontext.Profiles.Include(p => p.Contacts).Include(p => p.Teams).Include(p => p.Menssages).Single(p => p.Id == profile.Id);
            ProfileToUpdate.Name = profile.Name;
            ProfileToUpdate.Role = profile.Role;

            var profiles = dbcontext.Profiles.Include(p => p.Contacts).Include(p => p.Teams).ToList();
            var collectionOfContactsToUpdateTo = profiles.Where(p => profile.Contacts.Any(prl => prl.Id == p.Id));
            ProfileToUpdate.Contacts.Clear();
            foreach (var newProfile in collectionOfContactsToUpdateTo)
            {
                ProfileToUpdate.Contacts.Add(newProfile);
            }

            foreach (var menssag in profile.Menssages)
            {
                if (menssag.Id == 0)
                {
                    menssag.Profile = dbcontext.Profiles.Single(p => p.Id == menssag.Profile.Id);
                    dbcontext.Menssages.Add(menssag);
                }
            }

            dbcontext.SaveChanges();

            var menssages = dbcontext.Menssages.Include(m => m.Profile).ToList();
            var collectionOfMenssagesToUpdateTo = menssages.Where(m => profile.Menssages.Any(pm => pm.Id == m.Id));
            ProfileToUpdate.Menssages.Clear();
            foreach (var menssage in collectionOfMenssagesToUpdateTo)
            {
                ProfileToUpdate.Menssages.Add(menssage);
            }

            dbcontext.SaveChanges();
        }
    }
}
