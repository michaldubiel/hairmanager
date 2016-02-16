namespace Hairdresser.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymentCol : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HairServices", "Payment", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HairServices", "Payment");
        }
    }
}
