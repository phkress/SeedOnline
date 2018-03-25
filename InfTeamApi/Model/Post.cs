using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public virtual Profile Profile { get; set; }
        public String Photo { get; set; }
        public String Title { get; set; }
        public String Text { get; set; }
        public DateTime? Date { get; set; }
    }
}
