﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TesteDoisProject.Models
{
    [Table("estado")]
    public class Estado
    {
        public int EstadoID { get; set; }

        public String Designacao { get; set; }

        public virtual ICollection<Copia> Copias { get; set; }
    }
}