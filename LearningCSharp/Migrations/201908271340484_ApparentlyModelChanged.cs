namespace LearningCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApparentlyModelChanged : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Blog", newName: "Blogs");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Blogs", newName: "Blog");
        }
    }
}
