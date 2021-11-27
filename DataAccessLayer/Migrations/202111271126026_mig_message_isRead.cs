namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_message_isRead : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "IsReaded", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "IsReaded");
        }
    }
}
