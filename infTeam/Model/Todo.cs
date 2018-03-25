﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Todo
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Text { get; set; }
        public DateTime? Date { get; set; }
    }
}
