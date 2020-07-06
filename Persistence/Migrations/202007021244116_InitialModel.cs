namespace BookstoreApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookAuthors", "BookId", "dbo.Books");
            DropForeignKey("dbo.Covers", "Id", "dbo.Books");
            DropIndex("dbo.Books", new[] { "Id" });
            DropPrimaryKey("dbo.Books");
            AlterColumn("dbo.Books", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Books", "Id");
            CreateIndex("dbo.Books", "Id");
            AddForeignKey("dbo.BookAuthors", "BookId", "dbo.Books", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Covers", "Id", "dbo.Books", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Covers", "Id", "dbo.Books");
            DropForeignKey("dbo.BookAuthors", "BookId", "dbo.Books");
            DropIndex("dbo.Books", new[] { "Id" });
            DropPrimaryKey("dbo.Books");
            AlterColumn("dbo.Books", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Books", "Id");
            CreateIndex("dbo.Books", "Id");
            AddForeignKey("dbo.Covers", "Id", "dbo.Books", "Id");
            AddForeignKey("dbo.BookAuthors", "BookId", "dbo.Books", "Id", cascadeDelete: true);
        }
    }
}
