using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProfileRepository
    {
        RepositoryComposer<Profile> repositoryComposer = new RepositoryComposer<Profile>("http://localhost:53480/");

        public IEnumerable<Profile> GetAll()
        {
            repositoryComposer.Path = "/api/profiles";
            return repositoryComposer.GetAll();
        }

        public Profile GetProfile(int id)
        {
            repositoryComposer.Path = "/api/profiles/" + id;
            Profile profile = repositoryComposer.Get(id);
            return profile;
        }

        public bool Add(Profile profile)
        {
            return repositoryComposer.Add(profile);
        }

    }
}
