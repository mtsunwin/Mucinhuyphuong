namespace Website_14042017.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Password = c.String(nullable: false, unicode: false),
                        Email = c.String(nullable: false, unicode: false),
                        Phone = c.String(unicode: false),
                        Web = c.String(unicode: false),
                        Blog = c.String(unicode: false),
                        Descrip = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Href = c.String(unicode: false),
                        Type = c.String(unicode: false),
                        Link = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.MenuLevel0",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        DisplayName = c.String(nullable: false, unicode: false),
                        Prioritize = c.Int(nullable: false, identity: true),
                        Link = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.MenuLevel1",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisplayName = c.String(nullable: false, unicode: false),
                        IdMenuLevel0 = c.String(nullable: false, unicode: false),
                        Link = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MenuLevel2",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisplayName = c.String(nullable: false, unicode: false),
                        IdMenuLevel1 = c.Int(nullable: false),
                        Link = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(unicode: false),
                        Descrip = c.String(unicode: false),
                        Content = c.String(unicode: false),
                        DatePost = c.DateTime(nullable: false, precision: 0),
                        Author = c.String(unicode: false),
                        Status = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ProductType = c.String(unicode: false),
                        Country = c.String(unicode: false),
                        Manufacturer = c.String(unicode: false),
                        Price = c.Double(nullable: false),
                        Descrip = c.String(unicode: false),
                        Image = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.ProductTypes",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Descrip = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.WebsiteInfors",
                c => new
                    {
                        CompanyName = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Address = c.String(unicode: false),
                        Hotline = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        LinkWeb = c.String(unicode: false),
                        DislayNameWeb = c.String(unicode: false),
                        InforOther = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.CompanyName);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WebsiteInfors");
            DropTable("dbo.ProductTypes");
            DropTable("dbo.Products");
            DropTable("dbo.News");
            DropTable("dbo.MenuLevel2");
            DropTable("dbo.MenuLevel1");
            DropTable("dbo.MenuLevel0");
            DropTable("dbo.Images");
            DropTable("dbo.Accounts");
        }
    }
}
