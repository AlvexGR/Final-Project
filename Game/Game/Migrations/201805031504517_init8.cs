namespace Game.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sets", "ThemeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Sets", "ThemeId");
            AddForeignKey("dbo.Sets", "ThemeId", "dbo.Themes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sets", "ThemeId", "dbo.Themes");
            DropIndex("dbo.Sets", new[] { "ThemeId" });
            DropColumn("dbo.Sets", "ThemeId");
        }
    }
}
