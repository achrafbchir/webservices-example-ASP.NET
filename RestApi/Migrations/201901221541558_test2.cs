namespace RestApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.CartId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Guid(nullable: false),
                        Cart_CartId = c.Guid(),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.Carts", t => t.Cart_CartId)
                .Index(t => t.Cart_CartId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        _Id = c.Guid(nullable: false),
                        name = c.String(unicode: false),
                        description = c.String(unicode: false),
                        price = c.Long(nullable: false),
                        quantity = c.Int(nullable: false),
                        User_Id = c.Guid(),
                    })
                .PrimaryKey(t => t._Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(unicode: false),
                        Password = c.String(unicode: false),
                        Cart_CartId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carts", t => t.Cart_CartId)
                .Index(t => t.Cart_CartId);
            
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Cart_CartId", "dbo.Carts");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Items", "Cart_CartId", "dbo.Carts");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Users", new[] { "Cart_CartId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Products", new[] { "User_Id" });
            DropIndex("dbo.Items", new[] { "Cart_CartId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Users");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Products");
            DropTable("dbo.Items");
            DropTable("dbo.Carts");
        }
    }
}
