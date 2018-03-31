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
        RepositoryComposer<Profile> repositoryComposer = new RepositoryComposer<Profile>("http://localhost:53480");

        public IEnumerable<Profile> GetAll()
        {
            repositoryComposer.Path = "/api/profiles";
            return repositoryComposer.GetAll();
        }

        public Profile GetProfile(String id)
        {
            repositoryComposer.Path = "/api/profiles/" + id;
            Profile profile = repositoryComposer.Get();
            return profile;
        }

        public void UpdateProfile(String id, Profile profile)
        {
            repositoryComposer.Path = "/api/profiles/" + id;
            repositoryComposer.Update(profile);
        }

        public void Add(Profile profile)
        {
            repositoryComposer.Path = "/api/profiles";
            repositoryComposer.Add(profile);
        }



    }
}
