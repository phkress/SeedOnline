using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Profile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public String Id { get; set; }
        public String Name { get; set; }
        public String ProfilePhoto { get; set; }
        public String Email { get; set; }
        public String Role { get; set; }
        public virtual ICollection<Todo> Todos { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<Profile> Contacts { get; set; }
        public virtual ICollection<Menssage> Menssages { get; set; }

        public Profile()
        {
            Teams = new HashSet<Team>();
            Contacts = new HashSet<Profile>();
            Menssages = new HashSet<Menssage>();
            Todos = new HashSet<Todo>();
        }
    }
}
