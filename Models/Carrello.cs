using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzeriaInForno.Models
{
    public class Carrello
    {
        [Key]
        public int IDCarrello { get; set; }

        public int IDUtente { get; set; }

        [ForeignKey("IDUtente")]
        public Utente Utente { get; set; }

        public decimal Totale { get; set; }

        public virtual ICollection<Ordine> Ordini { get; set; }
    }
}
