namespace CleanArchitecture.DataAccess.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 255),
                        LastName = c.String(nullable: false, maxLength: 255),
                        DepId = c.Int(nullable: false),
                        Salary = c.Double(nullable: false),
                        HireDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Departments", t => t.DepId, cascadeDelete: true)
                .Index(t => t.DepId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "DepId", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "DepId" });
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
