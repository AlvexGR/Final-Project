namespace Game.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WordSets", "User_Id", "dbo.Users");
            DropIndex("dbo.WordSets", new[] { "User_Id" });
            AddColumn("dbo.Sets", "User_Id", c => c.Int());
            AddColumn("dbo.Themes", "ImageUrl", c => c.String());
            CreateIndex("dbo.Sets", "User_Id");
            AddForeignKey("dbo.Sets", "User_Id", "dbo.Users", "Id");
            DropColumn("dbo.Sets", "CreatedDate");
            DropColumn("dbo.WordSets", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WordSets", "User_Id", c => c.Int());
            AddColumn("dbo.Sets", "CreatedDate", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Sets", "User_Id", "dbo.Users");
            DropIndex("dbo.Sets", new[] { "User_Id" });
            DropColumn("dbo.Themes", "ImageUrl");
            DropColumn("dbo.Sets", "User_Id");
            CreateIndex("dbo.WordSets", "User_Id");
            AddForeignKey("dbo.WordSets", "User_Id", "dbo.Users", "Id");
        }
    }
}
