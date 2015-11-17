using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TesteDoisProject.Models
{
    [Table("emprestimo")]
    public class Emprestimo
    {
        public int EmprestimoID { get; set; }

        public int UtenteID { get; set; }
        public virtual Utente Utente { get; set; }

        public int CopiaID { get; set; }
        public virtual Copia Copia { get; set; }

        public DateTime DataEmprestimo { get; set; }

        public DateTime DataDevolucao { get; set; }

        [DefaultValue(false)]
        public bool Devolvido { get; set; } 
    }
}