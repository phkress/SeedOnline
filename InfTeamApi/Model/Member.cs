using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Member
    {
        public int Id { get; set; }
        public Profile profile { get; set; }
        public DateTime EnterDate { get; set; }
    }
}
