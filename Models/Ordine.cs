using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PizzeriaInForno.Models
{
    public class Ordine
    {
        [Key]
        public int IDOrdine { get; set; }
        public bool SelezionePranzoCena { get; set; }
        public string Note { get; set; }
        public int IDUtente { get; set; }
        public int IDArticolo { get; set; }
        public bool Stato { get; set; }
        public DateTime Data { get; set; }
        public int Quantita { get; set; }   

   
        public Utente Utente { get; set; }

      
        public Articolo Articolo { get; set; }
        public virtual ICollection<Carrello> Carrelloes { get; set; }

    }
    
}