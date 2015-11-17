using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TesteDoisProject.Models
{
    [Table("copia")]
    public class Copia
    {
        public int CopiaID { get; set; }

        public String Designacao { get; set; }

        public int FilmeID { get; set; }
        public virtual Filme Filme { get; set; }

        public int EstadoID { get; set; }
        public virtual Estado Estado { get; set; }

        public bool Ocupada { get; set; }
    }
}