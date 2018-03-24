using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Profile
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String ProfilePhoto { get; set; }
        public DateTime Birthday { get; set; }
        public String Email { get; set; }
        public Role Role { get; set; }
        public List<Team> Teams { get; set; }
        public List<Profile> contacts { get; set; }
    }
}
