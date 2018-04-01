using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Team
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public ICollection<Profile> Profiles { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}