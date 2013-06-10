namespace VietSovPetro.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Guid(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 100),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        PasswordHashed = c.String(),
                        CreateOn = c.DateTime(nullable: false),
                        LastLoginOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ArticleID = c.Guid(nullable: false),
                        ActicleNumber = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                        Content = c.String(nullable: false),
                        Author = c.String(nullable: false),
                        ImageUrl = c.String(),
                        OrderID = c.Int(nullable: false),
                        LanguageCode = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsPublished = c.Boolean(nullable: false),
                        IsNew = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        UpdatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ArticleID);
            
            CreateTable(
                "dbo.ArticleCategories",
                c => new
                    {
                        ArticleCategoryID = c.Guid(nullable: false),
                        ArticleCategoryName = c.String(nullable: false),
                        ArticleCategoryType = c.String(nullable: false),
                        Description = c.String(),
                        LanguageCode = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsPublished = c.Boolean(nullable: false),
                        IsNew = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ArticleCategoryID);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomID = c.Guid(nullable: false),
                        RoomName = c.String(nullable: false),
                        RoomTypeName = c.String(nullable: false),
                        Description = c.String(),
                        Detail = c.String(),
                        Quantity = c.Int(nullable: false),
                        ImageUrl = c.String(),
                        OrderID = c.Int(nullable: false),
                        LanguageCode = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsPublished = c.Boolean(nullable: false),
                        IsNew = c.Boolean(nullable: false),
                        IsDeal = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        UpdatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.RoomID);
            
            CreateTable(
                "dbo.RoomTypes",
                c => new
                    {
                        RoomTypeID = c.Guid(nullable: false),
                        RoomGroup = c.String(nullable: false),
                        LanguageCode = c.String(),
                        Description = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsPublished = c.Boolean(nullable: false),
                        IsNew = c.Boolean(nullable: false),
                        IsDeal = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RoomTypeID);
            
            CreateTable(
                "dbo.RoomPropertyRooms",
                c => new
                    {
                        RoomPropertyID = c.Guid(nullable: false),
                        RoomID = c.Guid(nullable: false),
                        RoomPropertyStringValue = c.String(),
                        RoomPropertyNumberValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsDeleted = c.Boolean(nullable: false),
                        IsPublished = c.Boolean(nullable: false),
                        IsNew = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoomPropertyID, t.RoomID })
                .ForeignKey("dbo.RoomProperties", t => t.RoomPropertyID, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomID, cascadeDelete: true)
                .Index(t => t.RoomPropertyID)
                .Index(t => t.RoomID);
            
            CreateTable(
                "dbo.RoomProperties",
                c => new
                    {
                        RoomPropertyID = c.Guid(nullable: false),
                        RoomPropertyName = c.String(nullable: false),
                        RoomPropertyType = c.String(),
                        Unit = c.String(),
                        OrderID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoomPropertyID);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookID = c.Guid(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        RoomID = c.Guid(nullable: false),
                        Begin = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        Time = c.String(),
                        GuestQuantity = c.String(),
                        MeetingType = c.String(),
                        Price = c.String(),
                        Message = c.String(),
                        UserCardName = c.String(),
                        UserCardNumber = c.String(),
                        UserCardType = c.String(),
                        DueDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.BookID)
                .ForeignKey("dbo.Rooms", t => t.RoomID, cascadeDelete: true)
                .Index(t => t.RoomID);
            
            CreateTable(
                "dbo.ArticleCategoryArticles",
                c => new
                    {
                        ArticleCategory_ArticleCategoryID = c.Guid(nullable: false),
                        Article_ArticleID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ArticleCategory_ArticleCategoryID, t.Article_ArticleID })
                .ForeignKey("dbo.ArticleCategories", t => t.ArticleCategory_ArticleCategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Articles", t => t.Article_ArticleID, cascadeDelete: true)
                .Index(t => t.ArticleCategory_ArticleCategoryID)
                .Index(t => t.Article_ArticleID);
            
            CreateTable(
                "dbo.RoomTypeRooms",
                c => new
                    {
                        RoomType_RoomTypeID = c.Guid(nullable: false),
                        Room_RoomID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoomType_RoomTypeID, t.Room_RoomID })
                .ForeignKey("dbo.RoomTypes", t => t.RoomType_RoomTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.Room_RoomID, cascadeDelete: true)
                .Index(t => t.RoomType_RoomTypeID)
                .Index(t => t.Room_RoomID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.RoomTypeRooms", new[] { "Room_RoomID" });
            DropIndex("dbo.RoomTypeRooms", new[] { "RoomType_RoomTypeID" });
            DropIndex("dbo.ArticleCategoryArticles", new[] { "Article_ArticleID" });
            DropIndex("dbo.ArticleCategoryArticles", new[] { "ArticleCategory_ArticleCategoryID" });
            DropIndex("dbo.Books", new[] { "RoomID" });
            DropIndex("dbo.RoomPropertyRooms", new[] { "RoomID" });
            DropIndex("dbo.RoomPropertyRooms", new[] { "RoomPropertyID" });
            DropForeignKey("dbo.RoomTypeRooms", "Room_RoomID", "dbo.Rooms");
            DropForeignKey("dbo.RoomTypeRooms", "RoomType_RoomTypeID", "dbo.RoomTypes");
            DropForeignKey("dbo.ArticleCategoryArticles", "Article_ArticleID", "dbo.Articles");
            DropForeignKey("dbo.ArticleCategoryArticles", "ArticleCategory_ArticleCategoryID", "dbo.ArticleCategories");
            DropForeignKey("dbo.Books", "RoomID", "dbo.Rooms");
            DropForeignKey("dbo.RoomPropertyRooms", "RoomID", "dbo.Rooms");
            DropForeignKey("dbo.RoomPropertyRooms", "RoomPropertyID", "dbo.RoomProperties");
            DropTable("dbo.RoomTypeRooms");
            DropTable("dbo.ArticleCategoryArticles");
            DropTable("dbo.Books");
            DropTable("dbo.RoomProperties");
            DropTable("dbo.RoomPropertyRooms");
            DropTable("dbo.RoomTypes");
            DropTable("dbo.Rooms");
            DropTable("dbo.ArticleCategories");
            DropTable("dbo.Articles");
            DropTable("dbo.Users");
        }
    }
}
