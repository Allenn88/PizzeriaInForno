using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzeriaInForno.Models
{
    public class Articolo
    {
        [Key]
        public int IDArticolo { get; set; }
        public string Nome { get; set; }
        public string Foto { get; set; }
        public decimal Prezzo { get; set; }
        public int TempoConsegna { get; set; }
        public string Ingredienti { get; set; }
    }
}