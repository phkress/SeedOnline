using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class Profile
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public String ProfilePhoto { get; set; }
        public String Email { get; set; }
        public String Role { get; set; }
        public ICollection<Team> Teams { get; set; }
        public ICollection<Profile> Contacts { get; set; }
        public virtual ICollection<Menssage> Menssages { get; set; }
        public virtual ICollection<Todo> Todos { get; set; }


        public bool HasTeam(int id)
        {
           return Teams.ToList().Any(t => t.Id == id);
        }

        public bool HasContact(String id)
        {
            return Contacts.ToList().Any(c => c.Id == id);
        }

        public IEnumerable<Profile> TakeNContacts(int n)
        {
            return Contacts.Take(n);
        }

        public IEnumerable<Team> TakeNTeams(int n)
        {
            return Teams.Take(n);
        }

        public IEnumerable<Menssage> MsgOrderByDate()
        {
            return Menssages.OrderByDescending(m => m.Date);
        }

        public IEnumerable<Todo> TodoOrderByDate()
        {
            return Todos.OrderByDescending(t => t.Date);
        }

    }

}
