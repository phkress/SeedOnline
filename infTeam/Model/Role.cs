﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Role
    {
        public int Id { get; set; }
        public bool? Leader { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
    }
}