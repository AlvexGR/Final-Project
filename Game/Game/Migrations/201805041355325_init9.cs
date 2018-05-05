namespace Game.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WordSets", "Star", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WordSets", "Star");
        }
    }
}
