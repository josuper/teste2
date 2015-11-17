using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TesteDoisProject.Models
{
    [Table("utente")]
    public class Utente
    {
        public int UtenteID { get; set; }

        public String Nome { get; set; }

        public int Idade { get; set; }

        public String Sexo { get; set; }

        public String Bairro { get; set; }

        public String Distrito { get; set; }

        public String Identificacao { get; set; } //Bi ou Nuit
    }
}