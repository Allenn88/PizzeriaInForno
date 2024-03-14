using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzeriaInForno.Models
{
    public class Utente
    {
        [Key]
        public int IDUtente { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string NomeUtente { get; set; }
        public string Password { get; set; }
        public string Citta { get; set; }
        public string Indirizzo { get; set; }
        public string Email { get; set; }
        public string NumeroCellulare { get; set; }
        public string Role { get; set; }

        public virtual ICollection<Carrello> Carrelloes { get; set; }
    }
}