using System;

namespace Model
{
    public class Menssage
    {
        public int Id { get; set; }
        public String ProfileNameStored { get; set; }
        public String Sender { get; set; }
        public String Text { get; set; }
        public DateTime? Date { get; set; }        
    }
}
