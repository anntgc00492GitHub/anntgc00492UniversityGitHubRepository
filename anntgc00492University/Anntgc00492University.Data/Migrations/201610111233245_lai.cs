namespace Anntgc00492University.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lai : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Instructors", "FirstMidName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Instructors", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Students", "FirstMidName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Students", "LastName", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "LastName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Students", "FirstMidName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Instructors", "LastName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Instructors", "FirstMidName", c => c.String(maxLength: 50));
        }
    }
}
