namespace Autobots.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Services", new[] { "ParentServiceId" });
            AlterColumn("dbo.Services", "ParentServiceId", c => c.Int());
            CreateIndex("dbo.Services", "ParentServiceId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Services", new[] { "ParentServiceId" });
            AlterColumn("dbo.Services", "ParentServiceId", c => c.Int(nullable: false));
            CreateIndex("dbo.Services", "ParentServiceId");
        }
    }
}
