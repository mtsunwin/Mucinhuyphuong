namespace Website_14042017.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClassInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Infoes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Address = c.String(unicode: false),
                        Hotline = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        Web = c.String(unicode: false),
                        InforOther = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Infoes");
        }
    }
}
