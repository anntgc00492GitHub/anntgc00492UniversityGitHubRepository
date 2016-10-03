namespace Anntgc00492University.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InstructorCourses", "Instructor_ID", "dbo.Instructors");
            DropForeignKey("dbo.InstructorCourses", "Course_CourseID", "dbo.Courses");
            DropIndex("dbo.InstructorCourses", new[] { "Instructor_ID" });
            DropIndex("dbo.InstructorCourses", new[] { "Course_CourseID" });
            CreateTable(
                "dbo.Teachings",
                c => new
                    {
                        InstructorID = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.InstructorID, t.CourseID })
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Instructors", t => t.InstructorID, cascadeDelete: true)
                .Index(t => t.InstructorID)
                .Index(t => t.CourseID);
            
            DropTable("dbo.InstructorCourses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.InstructorCourses",
                c => new
                    {
                        Instructor_ID = c.Int(nullable: false),
                        Course_CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Instructor_ID, t.Course_CourseID });
            
            DropForeignKey("dbo.Teachings", "InstructorID", "dbo.Instructors");
            DropForeignKey("dbo.Teachings", "CourseID", "dbo.Courses");
            DropIndex("dbo.Teachings", new[] { "CourseID" });
            DropIndex("dbo.Teachings", new[] { "InstructorID" });
            DropTable("dbo.Teachings");
            CreateIndex("dbo.InstructorCourses", "Course_CourseID");
            CreateIndex("dbo.InstructorCourses", "Instructor_ID");
            AddForeignKey("dbo.InstructorCourses", "Course_CourseID", "dbo.Courses", "CourseID", cascadeDelete: true);
            AddForeignKey("dbo.InstructorCourses", "Instructor_ID", "dbo.Instructors", "ID", cascadeDelete: true);
        }
    }
}
