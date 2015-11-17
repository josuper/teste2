using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TesteDoisProject.Models
{
    [Table("tb_selecao")]
    public class Selecao
    {
        public int SelecaoID { get; set; }

        public String Designacao { get; set; }

        public virtual ICollection<Jogador> Jogadores { get; set; }
    }
}