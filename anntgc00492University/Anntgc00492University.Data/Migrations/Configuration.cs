using Anntgc00492University.Model.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Anntgc00492University.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration :
        DbMigrationsConfiguration<Anntgc00492UniversityDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }



        protected override void Seed(Anntgc00492UniversityDbContext context)
        {
            CreateStudent(context);
            Createinstructors(context);
            CreateOfficeOfficeAssigments(context);
            CreateDepartments(context);
            CreateCourses(context);
            CreateTeaching(context);
            CreateEnrollments(context);
        }

        public void CreateStudent(Anntgc00492UniversityDbContext context)
        {
            if (!context.Students.Any())
            {
                var students = new List<Student>
                {
                    new Student
                    {
                        FirstMidName = "Trong An",
                        LastName = "Nguyen",
                        EnrollmentDate = DateTime.Parse("2016-01-01")
                    },
                    new Student
                    {
                        FirstMidName = "Thien Hieu",
                        LastName = "Nguyen",
                        EnrollmentDate = DateTime.Parse("2016-01-02")
                    },
                    new Student
                    {
                        FirstMidName = "Tuan Nghia",
                        LastName = "Tran",
                        EnrollmentDate = DateTime.Parse("2016-01-03")
                    },
                };
                students.ForEach(s => context.Students.Add(s));
                context.SaveChanges();
            }
        }

        public void Createinstructors(Anntgc00492UniversityDbContext context)
        {
            if (!context.Instructors.Any())
            {
                var instructors = new List<Instructor>
                {
                    new Instructor {FirstMidName = "Nga", LastName = "Pham", HireDate = DateTime.Parse("2006-01-01")},
                    new Instructor
                    {
                        FirstMidName = "Van Vung",
                        LastName = "Pham",
                        HireDate = DateTime.Parse("2006-01-02")
                    },
                    new Instructor
                    {
                        FirstMidName = "Thuy Duong",
                        LastName = "Pham",
                        HireDate = DateTime.Parse("2006-01-03")
                    },
                    new Instructor {FirstMidName = "Jaya", LastName = "Jaya", HireDate = DateTime.Parse("2006-01-04")},
                    new Instructor
                    {
                        FirstMidName = "Tung Son",
                        LastName = "Ngo",
                        HireDate = DateTime.Parse("2006-01-05")
                    },
                };
                instructors.ForEach(s => context.Instructors.Add(s));
                context.SaveChanges();
            }
            ;
        }

        public void CreateOfficeOfficeAssigments(Anntgc00492UniversityDbContext context)
        {
            if (!context.OfficeAssigments.Any())
            {
                var officeAssignments = new List<OfficeAssignment>
                {
                    new OfficeAssignment {InstructorID = 1, Location = "Office A"},
                    new OfficeAssignment {InstructorID = 2, Location = "Office B"}
                };

                officeAssignments.ForEach(o => context.OfficeAssigments.Add(o));
                context.SaveChanges();
            }
        }

        public void CreateDepartments(Anntgc00492UniversityDbContext context)
        {
            if (!context.Departments.Any())
            {
                var departments = new List<Department>
                {
                    new Department()
                    {
                        Name = "English Faculty",
                        Budget = 1000,
                        StartDate = DateTime.Parse("2010-01-01"),
                        InstructorID = 1
                    },
                    new Department()
                    {
                        Name = "Information Technology Faculty",
                        Budget = 1000,
                        StartDate = DateTime.Parse("2010-01-01"),
                        InstructorID = 2
                    }
                };
                departments.ForEach(d => context.Departments.Add(d));
                context.SaveChanges();
            }
        }

        //Thieu dien departmentn Id cung sinh ra loi, nhung khong do dinh nghia ma do Â
        public void CreateCourses(Anntgc00492UniversityDbContext context)
        {
            if (!context.Courses.Any())
            {
                var courses = new List<Course>
                {
                    new Course {CourseID = 1000, Title = "Submit 2", Credits = 10,DepartmentID = 1},
                    new Course {CourseID = 1001, Title = "Enterprice web software development", Credits = 11,DepartmentID = 2},
                    new Course {CourseID = 1002, Title = "Application development for mobile", Credits = 12,DepartmentID = 2},
                    new Course {CourseID = 1003, Title = "Interaction design", Credits = 13,DepartmentID = 2},
                    new Course {CourseID = 1004, Title = "Development framework", Credits = 14,DepartmentID = 2},
                    new Course {CourseID = 1005, Title = "Programming framework", Credits = 15,DepartmentID = 2},
                    new Course {CourseID = 1006, Title = "Database engineering", Credits = 16,DepartmentID = 2},
                };
                courses.ForEach(s => context.Courses.Add(s));
                context.SaveChanges();
            }

        }

        public void CreateTeaching(Anntgc00492UniversityDbContext context)
        {
            if (!context.Teachings.Any())
            {
                var courses = new List<Teaching>
                {
                    new Teaching {CourseID = 1000,InstructorID = 1},
                };
                courses.ForEach(t => context.Teachings.Add(t));
                context.SaveChanges();
            }

        }


        public void CreateEnrollments(Anntgc00492UniversityDbContext context)
        {
            if (!context.Enrollments.Any())
            {
                var enrollments = new List<Enrollment>
                {
                    new Enrollment {StudentID = 1, CourseID = 1000, Grade = Grade.Morning},
                    new Enrollment {StudentID = 1, CourseID = 1001, Grade = Grade.Morning},
                    new Enrollment {StudentID = 1, CourseID = 1002, Grade = Grade.Morning},
                    new Enrollment {StudentID = 2, CourseID = 1000}
                };
                enrollments.ForEach(s => context.Enrollments.Add(s));
                context.SaveChanges();
            }
        }
    }
}