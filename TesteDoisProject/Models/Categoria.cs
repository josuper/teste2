using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TesteDoisProject.Models
{
    [Table("categoria")]
    public class Categoria
    {
        public int CategoriaID { get; set; }

        public String Designacao { get; set; }

        public virtual ICollection<Filme> Filmes { get; set; }
    }
}