﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String ProfileNameStored { get; set; }
        public virtual Profile Profile { get; set; }
        public String Photo { get; set; }
        public String Text { get; set; }
        public DateTime? Date { get; set; }
    }
}
