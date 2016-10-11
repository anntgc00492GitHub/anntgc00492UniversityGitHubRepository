using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using anntgc00492University.Data.Infrastructure;
using Anntgc00492University.Data.Infrastructure;
using Anntgc00492University.Model.Models;
using Anntgc00492University.Model.ViewModels;

namespace Anntgc00492University.Data.Repositories
{
    public interface IStudentRepository : IRepository<Student>
    {
        IEnumerable<Student> GetStudentHavingEnrollment();
        IEnumerable<Student> GetStudentNotHavingEnrollment();

        IEnumerable<EnrollmentDateGroup> GetStudentByEnrollmentDateGroup();
    }
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public IEnumerable<Student> GetStudentHavingEnrollment()
        {
            var studentList = (from sl in DbContext.Students
                               join el in DbContext.Enrollments
                               on sl.ID equals el.StudentID
                               select sl).Distinct();
            return studentList;
        }

        public IEnumerable<Student> GetStudentNotHavingEnrollment()
        {
            return 
            (from sl
             in DbContext.Students
             .Except(
                 from sl in DbContext.Students
                 join el in DbContext.Enrollments
                 on sl.ID equals el.StudentID
                 select sl
              ).Distinct()
             select sl).Distinct();
        }

        public IEnumerable<EnrollmentDateGroup> GetStudentByEnrollmentDateGroup()
        {
            IEnumerable<EnrollmentDateGroup> studentList = (
                from sl in DbContext.Students
                group sl by sl.EnrollmentDate
                into dateGroup
                select new EnrollmentDateGroup()
                    {
                        EnrollmentDate = dateGroup.Key,
                        StudentCount = dateGroup.Count()
                    }
                ) ;
            return studentList;
        }
    }
}
