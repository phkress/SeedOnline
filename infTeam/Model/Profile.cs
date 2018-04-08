using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        public bool HasTeam(int id)
        {
           return this.Teams.ToList().Any(t => t.Id == id);
        }
        public bool HasContact(String id)
        {
            return this.Contacts.ToList().Any(c => c.Id == id);
        }

        public IEnumerable<Profile> TakeNContacts(int n)
        {
            return Contacts.Take(n);
        }

        public IEnumerable<Team> TakeNTeams(int n)
        {
            return Teams.Take(n);
        }

    }

}
