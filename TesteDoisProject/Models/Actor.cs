﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TesteDoisProject.Models
{
    [Table("actor")]
    public class Actor
    {
        public int ActorID { get; set; }

        public String Nome { get; set; }

        public virtual ICollection<Filme> Filmes { get; set; }
    }
}