﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Post
    {
        public int Id { get; set; }
        public Profile profile { get; set; }
        public String Photo { get; set; }
        public String Title { get; set; }
        public String Text { get; set; }
        public DateTime date { get; set; }
    }
}
