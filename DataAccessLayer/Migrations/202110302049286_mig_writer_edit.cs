namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_writer_edit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "About", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "About");
        }
    }
}
