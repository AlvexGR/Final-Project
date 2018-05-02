namespace Game.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sets", "User_Id", "dbo.Users");
            DropForeignKey("dbo.WordSets", "Set_Id", "dbo.Sets");
            DropForeignKey("dbo.WordSets", "Word_Id", "dbo.Vocabularies");
            DropIndex("dbo.Sets", new[] { "User_Id" });
            DropIndex("dbo.WordSets", new[] { "Set_Id" });
            DropIndex("dbo.WordSets", new[] { "Word_Id" });
            RenameColumn(table: "dbo.Sets", name: "User_Id", newName: "UserId");
            RenameColumn(table: "dbo.WordSets", name: "Set_Id", newName: "SetId");
            RenameColumn(table: "dbo.WordSets", name: "Word_Id", newName: "WordId");
            AlterColumn("dbo.Sets", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.WordSets", "SetId", c => c.Int(nullable: false));
            AlterColumn("dbo.WordSets", "WordId", c => c.Int(nullable: false));
            CreateIndex("dbo.Sets", "UserId");
            CreateIndex("dbo.WordSets", "WordId");
            CreateIndex("dbo.WordSets", "SetId");
            AddForeignKey("dbo.Sets", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WordSets", "SetId", "dbo.Sets", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WordSets", "WordId", "dbo.Vocabularies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WordSets", "WordId", "dbo.Vocabularies");
            DropForeignKey("dbo.WordSets", "SetId", "dbo.Sets");
            DropForeignKey("dbo.Sets", "UserId", "dbo.Users");
            DropIndex("dbo.WordSets", new[] { "SetId" });
            DropIndex("dbo.WordSets", new[] { "WordId" });
            DropIndex("dbo.Sets", new[] { "UserId" });
            AlterColumn("dbo.WordSets", "WordId", c => c.Int());
            AlterColumn("dbo.WordSets", "SetId", c => c.Int());
            AlterColumn("dbo.Sets", "UserId", c => c.Int());
            RenameColumn(table: "dbo.WordSets", name: "WordId", newName: "Word_Id");
            RenameColumn(table: "dbo.WordSets", name: "SetId", newName: "Set_Id");
            RenameColumn(table: "dbo.Sets", name: "UserId", newName: "User_Id");
            CreateIndex("dbo.WordSets", "Word_Id");
            CreateIndex("dbo.WordSets", "Set_Id");
            CreateIndex("dbo.Sets", "User_Id");
            AddForeignKey("dbo.WordSets", "Word_Id", "dbo.Vocabularies", "Id");
            AddForeignKey("dbo.WordSets", "Set_Id", "dbo.Sets", "Id");
            AddForeignKey("dbo.Sets", "User_Id", "dbo.Users", "Id");
        }
    }
}
