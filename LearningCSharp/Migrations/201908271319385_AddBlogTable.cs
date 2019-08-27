namespace LearningCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBlogTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blog",
                c => new
                {
                    PostID = c.Int(nullable: false, identity: true),
                    PostTitle = c.String(maxLength: 100),
                    PostBody = c.String(maxLength: 255),
                    Author = c.String(),
                    CreatedOn = c.DateTime(),
                    EditedOn = c.DateTime(),
                }).PrimaryKey(t => t.PostID);
        }

        public override void Down()
        {
            DropTable("dbo.Blog");
        }

    }
}
