using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public void SendMenssage(String id, Profile profile)
        {
            profileRepository.UpdateProfile(id, profile);
        }

        public void UpdateMyProfile(String id, Profile profile)
        {
            profileRepository.UpdateProfile(id, profile);
        }

        public IEnumerable<Profile> SearchContact(String text)
        {
            IEnumerable<Profile> profiles = profileRepository.GetAll();
            return  profiles.Where(p => p.Name.ToLower().Contains(text.ToLower()));
        }

        public void AddTodo(String text, Profile profile)
        {
            Todo todo = new Todo()
            {
                Text = text,
                Date = DateTime.Now
            };
            profile.Todos.Add(todo);
            profileRepository.UpdateProfile(profile.Id, profile);
        }        

        public void RemoveTodo(int id, Profile profile)
        {
            var todo = profile.Todos.ToList().SingleOrDefault(t => t.Id == id);
            if (todo != null)
                profile.Todos.Remove(todo);

            profileRepository.UpdateProfile(profile.Id, profile);
        }

        public void CreateNewProfile(Profile profile)
        {
            profileRepository.Add(profile);
        }
    }
}
