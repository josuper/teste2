using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TesteDoisProject.Models
{
    [Table("filme")]
    public class Filme
    {
        public int FilmeID { get; set; }

        public String Titulo { get; set; }

        public String Sinopse { get; set; }

        public int CategoriaID { get; set; }
        public virtual Categoria Categoria { get; set; }

        public int ActorID { get; set; }
        public virtual Actor Actor { get; set; }

        public int AutorID { get; set; }
        public virtual Autor Autor { get; set; }

        public virtual ICollection<Copia> Copias { get; set; }
    }
}