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
        public List<Member> Members { get; set; }
        public List<Post> Posts { get; set; }
        public List<Todo> Todos { get; set; }
    }
}
