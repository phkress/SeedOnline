using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Menssage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String ProfileNameStored { get; set; }
        public String Sender { get; set; }
        public String Text { get; set; }
        public DateTime? Date { get; set; }
    }
}
