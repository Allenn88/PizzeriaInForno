namespace PizzeriaInForno.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Aggiornamento : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ordines", "Quantita", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ordines", "Quantita");
        }
    }
}
