namespace BookstoreApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false, maxLength: 2000),
                        Price = c.Single(nullable: false),
                        PublishingHouseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Id)
                .ForeignKey("dbo.PublishingHouses", t => t.PublishingHouseId)
                .Index(t => t.Id)
                .Index(t => t.PublishingHouseId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Covers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.PublishingHouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookAuthors",
                c => new
                    {
                        BookId = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookId, t.AuthorId })
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.AuthorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "PublishingHouseId", "dbo.PublishingHouses");
            DropForeignKey("dbo.Covers", "Id", "dbo.Books");
            DropForeignKey("dbo.Books", "Id", "dbo.Categories");
            DropForeignKey("dbo.BookAuthors", "AuthorId", "dbo.Authors");
            DropForeignKey("dbo.BookAuthors", "BookId", "dbo.Books");
            DropIndex("dbo.BookAuthors", new[] { "AuthorId" });
            DropIndex("dbo.BookAuthors", new[] { "BookId" });
            DropIndex("dbo.Covers", new[] { "Id" });
            DropIndex("dbo.Books", new[] { "PublishingHouseId" });
            DropIndex("dbo.Books", new[] { "Id" });
            DropTable("dbo.BookAuthors");
            DropTable("dbo.PublishingHouses");
            DropTable("dbo.Covers");
            DropTable("dbo.Categories");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
