﻿using System;
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

        private Profile nullHandlerProfile(Profile profile)
        {
            return profile;
        }
        public IEnumerable<Profile> GetAll()
        {
            return profileRepository.GetAll();
        }

        public Profile GetProfile(int id)
        {
            Profile profile = profileRepository.GetProfile(id);
            if 
        }

        public void CreateNewProfile(Profile profile)
        {
            profileRepository.Add(profile);
        }
    }
}