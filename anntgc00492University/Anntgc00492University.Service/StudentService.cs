using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anntgc00492University.Data.Infrastructure;
using Anntgc00492University.Data.Repositories;
using Anntgc00492University.Model.Models;

namespace Anntgc00492University.Service
{
    public interface IStudentService
    {
        Student Add(Student student);
        void Update(Student student);
        void Delete(int id);
        Student GetById(int? id);
        IEnumerable<Student> GetAll();
        IEnumerable<Student> GetByFilterSearchSort(DateTime enrollmentDate, string searchString, string orderSort);
    }
    public class StudentService:IStudentService
    {
        private IStudentRepository _studentRepoistory;
        private IUnitOfWork _unitOfWork;

        public StudentService(IStudentRepository studentRepoistory, IUnitOfWork unitOfWork)
        {
            _studentRepoistory = studentRepoistory;
            _unitOfWork = unitOfWork;
        }

        public Student Add(Student student)
        {
            return _studentRepoistory.Add(student);
        }

        public void Update(Student student)
        {
             _studentRepoistory.Update(student);
        }

        public void Delete(int id)
        {
            _studentRepoistory.Delete(id);
        }

        public Student GetById(int? id)
        {
            return _studentRepoistory.GetSingleById(id);
        }

        public IEnumerable<Student> GetAll()
        {
            return _studentRepoistory.GetAll();
        }

        public IEnumerable<Student> GetByFilterSearchSort(DateTime enrollmentDate, string searchString, string orderSort)
        {
            var studentList = GetAll();
            if (!string.IsNullOrEmpty(enrollmentDate.ToString()))
            {
                studentList = studentList.Where(s =>s.EnrollmentDate==enrollmentDate);
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                studentList = studentList.Where(s => s.FirstMidName.Contains(searchString) || s.LastName.Contains(searchString));
            }
            switch (orderSort)
            {
                case "FirstName":
                    studentList = studentList.OrderByDescending(s => s.FirstMidName);
                    break;
                case "LastName":
                    studentList = studentList.OrderByDescending(s => s.LastName);
                    break;
                case "EnrollmentDate":
                    studentList = studentList.OrderByDescending(s => s.EnrollmentDate);
                    break;
                default:
                    studentList = studentList.OrderByDescending(s => s.ID);
                    break;
            }
            return studentList;
        }
        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
