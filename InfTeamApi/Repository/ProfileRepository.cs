﻿using Model;
using Model.Interface;
using Repository.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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
            var profile = dbcontext.Profiles.Include(p => p.Todos).Include(p => p.Contacts).Include(p => p.Teams).Include(p => p.Menssages).Single(p => p.Id == id);
            return profile;
        }

        public IEnumerable<Profile> GetAll()
        {
            return dbcontext.Profiles.Include(p => p.Todos).Include(p => p.Contacts).Include(p => p.Teams).Include(p => p.Menssages);
        }

        public void Update(Profile profile)
        {
            var ProfileToUpdate = dbcontext.Profiles.Include(p => p.Todos).Include(p => p.Contacts).Include(p => p.Teams).Include(p => p.Menssages).Single(p => p.Id == profile.Id);
            ProfileToUpdate.Name = profile.Name;
            ProfileToUpdate.Role = profile.Role;
            ProfileToUpdate.ProfilePhoto = profile.ProfilePhoto;

            var profiles = dbcontext.Profiles.Include(p => p.Todos).Include(p => p.Contacts).Include(p => p.Teams).ToList();
            var collectionOfContactsToUpdateTo = profiles.Where(p => profile.Contacts.Any(prl => prl.Id == p.Id));
            ProfileToUpdate.Contacts.Clear();
            foreach (var newProfile in collectionOfContactsToUpdateTo)
            {
                ProfileToUpdate.Contacts.Add(newProfile);
            }
            
            ProfileToUpdate.Todos.Clear();
            foreach (var todo in profile.Todos)
            {
                ProfileToUpdate.Todos.Add(todo);
            }

            foreach (var menssag in profile.Menssages)
            {
                if (menssag.Id == 0)
                {
                    ProfileToUpdate.Menssages.Add(menssag);
                }
            }

            dbcontext.SaveChanges();
        }
    }
}
