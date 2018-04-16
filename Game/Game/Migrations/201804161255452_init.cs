namespace Game.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlayHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Score = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Themes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vocabularies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EnglishWord = c.String(),
                        Definition = c.String(),
                        Pronunciation = c.String(),
                        Spelling = c.String(),
                        Image = c.String(),
                        IsLearned = c.Boolean(nullable: false),
                        Theme_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Themes", t => t.Theme_Id)
                .Index(t => t.Theme_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vocabularies", "Theme_Id", "dbo.Themes");
            DropIndex("dbo.Vocabularies", new[] { "Theme_Id" });
            DropTable("dbo.Vocabularies");
            DropTable("dbo.Themes");
            DropTable("dbo.PlayHistories");
        }
    }
}
