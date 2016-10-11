using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anntgc00492University.Data;
using Anntgc00492University.Data.Infrastructure;
using Anntgc00492University.Data.Repositories;
using Anntgc00492University.Model.Models;

namespace Anntgc00492University.Service
{
    public interface ICourseService
    {
        Course Add(Course course);
        void Update(Course course);
        void Delete(int id);
        Course GetById(int? id);
        IEnumerable<Course> GetAll();
        IEnumerable<Course> GetByFilterSearchSort(int? departmentId,string searchString, string orderSort);
        void Save();
    }
    public class CourseService:ICourseService
    {
        private ICourseRepository _courseRepoistory;
        private ITeachingRepository _teachingRepository;
        private IUnitOfWork _unitOfWork;

        public CourseService(ICourseRepository courseRepoistory,ITeachingRepository teachingRepository,IUnitOfWork unitOfWork)
        {
            _courseRepoistory = courseRepoistory;
            _teachingRepository = teachingRepository;
            _unitOfWork = unitOfWork;
        }

        public Course Add(Course course)
        {
            return _courseRepoistory.Add(course);
        }

        public void Update(Course course)
        {
             _courseRepoistory.Update(course);
        }

        public void Delete(int id)
        {
            _courseRepoistory.Delete(id);
        }

        public Course GetById(int? id)
        {
            return _courseRepoistory.GetSingleById(id);
        }

        public IEnumerable<Course> GetAll()
        {
            return _courseRepoistory.GetAll();
        }


        public IEnumerable<Course> GetByFilterSearchSort(int? departmentId, string searchString, string orderSort)
        {
            var courseList = GetAll();
            if (!string.IsNullOrEmpty(departmentId.ToString()))
            {
                courseList = courseList.Where(c => c.DepartmentID == departmentId);
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                courseList = courseList.Where(c => c.Title.Contains(searchString) || c.Department.Name.Contains(searchString));
            }
            switch (orderSort)
            {
                case "CourseID":
                    courseList = courseList.OrderByDescending(c => c.CourseID);
                    break;
                case "Title":
                    courseList = courseList.OrderByDescending(c => c.Title);
                    break;
                case "Credít":
                    courseList = courseList.OrderByDescending(c => c.Credits);
                    break;
                case "Department":
                    courseList = courseList.OrderByDescending(c => c.Department.Name);
                    break;
                default:
                    courseList = courseList.OrderByDescending(c => c.CourseID);
                    break;
            }
            return courseList;
        }
        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
