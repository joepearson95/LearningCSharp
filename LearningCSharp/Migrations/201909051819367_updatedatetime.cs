namespace LearningCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatetime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blogs", "CreatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Blogs", "EditedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blogs", "EditedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Blogs", "CreatedOn", c => c.DateTime(nullable: false));
        }
    }
}
