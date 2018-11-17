namespace Randomizer.DBAdapter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                {
                    Guid = c.Guid(nullable: false),
                    FirstName = c.String(nullable: false),
                    LastName = c.String(nullable: false),
                    Email = c.String(nullable: false),
                    Login = c.String(nullable: false),
                    Password = c.String(nullable: false),
                    LastLoginDate = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Guid);


            CreateTable(
                    "dbo.Query",
                    c => new
                    {
                        Guid = c.Guid(nullable: false),
                        FromNumber = c.Int(nullable: false),
                        ToNumber = c.Int(nullable: false),
                        GeneratedElementsNumber = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        UserGuid = c.Guid(nullable: false),
                })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("dbo.Users", t => t.UserGuid, cascadeDelete: true)
                .Index(t => t.UserGuid);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Query", "UserGuid", "dbo.Users");
            DropIndex("dbo.Query", new[] { "UserGuid" });
            DropTable("dbo.Query");
            DropTable("dbo.Users");
        }
    }
}
