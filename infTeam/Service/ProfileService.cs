using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Model;

namespace Service
{
    public class ProfileService
    {
        ProfileRepository profileRepository = new ProfileRepository();

        public IEnumerable<Profile> GetAll()
        {
            return profileRepository.GetAll();
        }

        public Profile GetProfile(String id)
        {
            Profile profile = profileRepository.GetProfile(id);
            return profile;
        }

        public void AddContact(String id, Profile profile)
        {
            Profile profileToAdd = GetProfile(id);
            profile.Contacts.Add(profileToAdd);
            profileRepository.UpdateProfile(profile.Id, profile);
        }

        public void RemoveContact(String id, Profile profile)
        {
            profile.Contacts = profile.Contacts.Where(c => c.Id != id).ToList();
            profileRepository.UpdateProfile(profile.Id, profile);
        }

        public void CreateNewProfile(Profile profile)
        {
            profileRepository.Add(profile);
        }
    }
}
