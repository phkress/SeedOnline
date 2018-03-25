using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public virtual ICollection<Profile> Profiles { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Todo> Todos { get; set; }

        public Team()
        {
            Profiles = new HashSet<Profile>();
            Posts = new HashSet<Post>();
            Todos = new HashSet<Todo>();
        }
    }
}
