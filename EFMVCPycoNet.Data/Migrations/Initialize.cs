using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace EFMVCPycoNet.Data.Migrations
{
    public partial class Initialize : DbMigration
    {
        public override void Up()
        {
            CreateTable("dbo.Users",
                u => new
                {
                    UserID = u.Int(nullable: false, identity: true),
                    Email = u.String(nullable: false),
                    FirstName = u.String(nullable: false),
                    LastName = u.String(nullable: false),
                    PasswordHashed = u.String(nullable: false),
                    CreateOn = u.DateTime(nullable: false),
                    LastLoginOn = u.DateTime(),
                    IsActivated = u.Boolean(nullable: false),
                    RoleID = u.Int(nullable: false)
                }).PrimaryKey(p => p.UserID);
        }
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
