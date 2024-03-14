namespace PizzeriaInForno.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articoloes",
                c => new
                    {
                        IDArticolo = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Foto = c.String(),
                        Prezzo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TempoConsegna = c.Int(nullable: false),
                        Ingredienti = c.String(),
                    })
                .PrimaryKey(t => t.IDArticolo);
            
            CreateTable(
                "dbo.Ordines",
                c => new
                    {
                        IDOrdine = c.Int(nullable: false, identity: true),
                        SelezionePranzoCena = c.Boolean(nullable: false),
                        Note = c.String(),
                        IDUtente = c.Int(nullable: false),
                        IDArticolo = c.Int(nullable: false),
                        Stato = c.Boolean(nullable: false),
                        Data = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDOrdine)
                .ForeignKey("dbo.Articoloes", t => t.IDArticolo, cascadeDelete: true)
                .ForeignKey("dbo.Utentes", t => t.IDUtente, cascadeDelete: true)
                .Index(t => t.IDUtente)
                .Index(t => t.IDArticolo);
            
            CreateTable(
                "dbo.Utentes",
                c => new
                    {
                        IDUtente = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Cognome = c.String(),
                        NomeUtente = c.String(),
                        Password = c.String(),
                        Citta = c.String(),
                        Indirizzo = c.String(),
                        Email = c.String(),
                        NumeroCellulare = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.IDUtente);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ordines", "IDUtente", "dbo.Utentes");
            DropForeignKey("dbo.Ordines", "IDArticolo", "dbo.Articoloes");
            DropIndex("dbo.Ordines", new[] { "IDArticolo" });
            DropIndex("dbo.Ordines", new[] { "IDUtente" });
            DropTable("dbo.Utentes");
            DropTable("dbo.Ordines");
            DropTable("dbo.Articoloes");
        }
    }
}
