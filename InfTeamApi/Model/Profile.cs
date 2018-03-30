using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<Profile> Contacts { get; set; }

        public Profile()
        {
            Teams = new HashSet<Team>();
            Contacts = new HashSet<Profile>();
        }
    }
}
