namespace PizzeriaInForno.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AggiornamentoCarrello : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ordines", "IDUtente", "dbo.Utentes");
            CreateTable(
                "dbo.Carrelloes",
                c => new
                    {
                        IDCarrello = c.Int(nullable: false, identity: true),
                        IDUtente = c.Int(nullable: false),
                        Totale = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.IDCarrello)
                .ForeignKey("dbo.Utentes", t => t.IDUtente, cascadeDelete: true)
                .Index(t => t.IDUtente);
            
            CreateTable(
                "dbo.OrdineCarrelloes",
                c => new
                    {
                        Ordine_IDOrdine = c.Int(nullable: false),
                        Carrello_IDCarrello = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ordine_IDOrdine, t.Carrello_IDCarrello })
                .ForeignKey("dbo.Ordines", t => t.Ordine_IDOrdine, cascadeDelete: true)
                .ForeignKey("dbo.Carrelloes", t => t.Carrello_IDCarrello, cascadeDelete: true)
                .Index(t => t.Ordine_IDOrdine)
                .Index(t => t.Carrello_IDCarrello);
            
            AddForeignKey("dbo.Ordines", "IDUtente", "dbo.Utentes", "IDUtente");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ordines", "IDUtente", "dbo.Utentes");
            DropForeignKey("dbo.Carrelloes", "IDUtente", "dbo.Utentes");
            DropForeignKey("dbo.OrdineCarrelloes", "Carrello_IDCarrello", "dbo.Carrelloes");
            DropForeignKey("dbo.OrdineCarrelloes", "Ordine_IDOrdine", "dbo.Ordines");
            DropIndex("dbo.OrdineCarrelloes", new[] { "Carrello_IDCarrello" });
            DropIndex("dbo.OrdineCarrelloes", new[] { "Ordine_IDOrdine" });
            DropIndex("dbo.Carrelloes", new[] { "IDUtente" });
            DropTable("dbo.OrdineCarrelloes");
            DropTable("dbo.Carrelloes");
            AddForeignKey("dbo.Ordines", "IDUtente", "dbo.Utentes", "IDUtente", cascadeDelete: true);
        }
    }
}
