namespace Game.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sets", "IsCreatedByTheme", c => c.Boolean(nullable: false));
            DropColumn("dbo.Sets", "TypeSetCollection");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sets", "TypeSetCollection", c => c.Int(nullable: false));
            DropColumn("dbo.Sets", "IsCreatedByTheme");
        }
    }
}
