namespace WebDev.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Models : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AspNetUsers", newName: "Users");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.Users", "UserNameIndex");
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropPrimaryKey("dbo.Users");
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        TopicId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TopicId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Words",
                c => new
                    {
                        WordId = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        User_UserId = c.Int(),
                        Topic_TopicId = c.Int(),
                    })
                .PrimaryKey(t => t.WordId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .ForeignKey("dbo.Topics", t => t.Topic_TopicId)
                .Index(t => t.User_UserId)
                .Index(t => t.Topic_TopicId);
            
            AddColumn("dbo.Users", "UserId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Users", "IsAdmin", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "AuthKey", c => c.String());
            AlterColumn("dbo.Users", "UserName", c => c.String());
            AddPrimaryKey("dbo.Users", "UserId");
            DropColumn("dbo.Users", "Id");
            DropColumn("dbo.Users", "EmailConfirmed");
            DropColumn("dbo.Users", "SecurityStamp");
            DropColumn("dbo.Users", "PhoneNumber");
            DropColumn("dbo.Users", "PhoneNumberConfirmed");
            DropColumn("dbo.Users", "TwoFactorEnabled");
            DropColumn("dbo.Users", "LockoutEndDateUtc");
            DropColumn("dbo.Users", "LockoutEnabled");
            DropColumn("dbo.Users", "AccessFailedCount");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUserLogins");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId });
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId });
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "AccessFailedCount", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "LockoutEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "LockoutEndDateUtc", c => c.DateTime());
            AddColumn("dbo.Users", "TwoFactorEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "PhoneNumberConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "PhoneNumber", c => c.String());
            AddColumn("dbo.Users", "SecurityStamp", c => c.String());
            AddColumn("dbo.Users", "EmailConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "Id", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.Words", "Topic_TopicId", "dbo.Topics");
            DropForeignKey("dbo.Topics", "UserId", "dbo.Users");
            DropForeignKey("dbo.Words", "User_UserId", "dbo.Users");
            DropIndex("dbo.Words", new[] { "Topic_TopicId" });
            DropIndex("dbo.Words", new[] { "User_UserId" });
            DropIndex("dbo.Topics", new[] { "UserId" });
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false, maxLength: 256));
            DropColumn("dbo.Users", "AuthKey");
            DropColumn("dbo.Users", "IsAdmin");
            DropColumn("dbo.Users", "UserId");
            DropTable("dbo.Words");
            DropTable("dbo.Topics");
            AddPrimaryKey("dbo.Users", "Id");
            CreateIndex("dbo.AspNetUserLogins", "UserId");
            CreateIndex("dbo.AspNetUserClaims", "UserId");
            CreateIndex("dbo.Users", "UserName", unique: true, name: "UserNameIndex");
            CreateIndex("dbo.AspNetUserRoles", "RoleId");
            CreateIndex("dbo.AspNetUserRoles", "UserId");
            CreateIndex("dbo.AspNetRoles", "Name", unique: true, name: "RoleNameIndex");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id");
            RenameTable(name: "dbo.Users", newName: "AspNetUsers");
        }
    }
}
