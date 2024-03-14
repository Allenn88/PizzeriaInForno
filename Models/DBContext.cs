using System;
using System.Data.Entity;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml;

namespace PizzeriaInForno.Models
{
    public class DBContext : DbContext
    {
        // Il contesto è stato configurato per utilizzare una stringa di connessione 'DBContext' dal file di configurazione 
        // dell'applicazione (App.config o Web.config). Per impostazione predefinita, la stringa di connessione è destinata al 
        // database 'PizzeriaInForno.Models.DBContext' nell'istanza di LocalDb. 
        // 
        // Per destinarla a un database o un provider di database differente, modificare la stringa di connessione 'DBContext' 
        // nel file di configurazione dell'applicazione.
        public DBContext()
            : base("name=DBContext")
        {
        }

        // Aggiungere DbSet per ogni tipo di entità che si desidera includere nel modello. Per ulteriori informazioni 
        // sulla configurazione e sull'utilizzo di un modello Code, vedere http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Articolo> Articolos { get; set; }
        public virtual DbSet<Ordine> Ordines { get; set; }
        public virtual DbSet<Utente> Utentes { get; set; }
        public virtual DbSet<Carrello> Carrelloes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ordine>()
                .HasRequired(o => o.Utente)
                .WithMany(u => (System.Collections.Generic.ICollection<Ordine>)u.Carrelloes)
                .HasForeignKey(o => o.IDUtente)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}