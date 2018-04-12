using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public Team()
        {
            Profiles = new HashSet<Profile>();
            Posts = new HashSet<Post>();
        }
    }
}
