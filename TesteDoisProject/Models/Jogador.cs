using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TesteDoisProject.Models
{
    [Table("tb_jogadr")]
    public class Jogador
    {

        public int JogadorID { get; set; }

     
        public String Nome { get; set; }

        public int Numero { get; set; }

        public int SelecaoID { get; set; }
        public virtual Selecao Selecao { get; set; }
    }
}