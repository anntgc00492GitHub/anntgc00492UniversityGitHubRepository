namespace Anntgc00492University.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChinhSuaCourseVaInstructor : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.OfficeAssigments", newName: "OfficeAssignments");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.OfficeAssignments", newName: "OfficeAssigments");
        }
    }
}
