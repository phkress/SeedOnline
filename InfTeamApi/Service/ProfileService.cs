using Model;
using Repository;
using Repository.Persistence;
using System;
using System.Collections.Generic;

namespace Service
{
    public class ProfileService
    {
        ModelUOW db = new ModelUOW(new InfTeamApiDBContext());

        public IEnumerable<Profile> GetProfiles()
        {
            return db.Profiles.GetAll();
        }

        public Profile GetProfile(String id)
        {
            Profile profile = db.Profiles.Get(id);
            return profile;
        }


        public void Add(Profile profile)
        {
            db.Profiles.Add(profile);
            db.Complete();
        }

        public bool Delete(Profile profile)
        {
            if (profile == null)
            {
                return false;
            }
            db.Profiles.Remove(profile);
            db.Complete();
            return true;
        }

        public bool UpdateProfile(Profile profile)
        {
            try
            {
                db.Profiles.Update(profile);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
