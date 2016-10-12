using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anntgc00492University.Data.Infrastructure;
using Anntgc00492University.Data.Repositories;
using Anntgc00492University.Model.Models;
using Anntgc00492University.Model.ViewModels;

namespace Anntgc00492University.Service
{
    public interface ITeachingService
    {
        Teaching Add(Teaching teaching);
        void Update(Teaching teaching);
        void Delete(int id);
        Teaching GetById(int? id);
        IEnumerable<Teaching> GetAll();
        IEnumerable<Teaching> GetByFilterSearchSort(int? filter1,int? filter2, string searchString, string orderSort);
        void Save();
    }
    public class TeachingService:ITeachingService
    {
        private ITeachingRepository _teachingRepoistory;
        private IUnitOfWork _unitOfWork;

        public TeachingService(ITeachingRepository teachingRepoistory, IUnitOfWork unitOfWork)
        {
            _teachingRepoistory = teachingRepoistory;
            _unitOfWork = unitOfWork;
        }

        public Teaching Add(Teaching teaching)
        {
            return _teachingRepoistory.Add(teaching);
        }

        public void Update(Teaching teaching)
        {
             _teachingRepoistory.Update(teaching);
        }

        public void Delete(int id)
        {
            _teachingRepoistory.Delete(id);
        }

        public Teaching GetById(int? id)
        {
            return _teachingRepoistory.GetSingleById(id);
        }

        public IEnumerable<Teaching> GetAll()
        {
            return _teachingRepoistory.GetAll();
        }


        public IEnumerable<Teaching> GetByFilterSearchSort(int? filter1,int? filter2,string searchString, string orderSort)
        {
            var teachingList = GetAll();
            if (!string.IsNullOrEmpty(filter1.ToString()))
            {
                teachingList = teachingList.Where(t => t.InstructorID == filter1);
            }
            if (!string.IsNullOrEmpty(filter2.ToString()))
            {
                teachingList = teachingList.Where(t => t.CourseID == filter2);
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                teachingList = teachingList.Where(t => t.Course.Title.Contains(searchString) || t.Instructor.FullName.Contains(searchString));
            }
            switch (orderSort)
            {
                case "CourseId":
                    teachingList = teachingList.OrderByDescending(t => t.Course.CourseID);
                    break;
                case "CourseTitle":
                    teachingList = teachingList.OrderByDescending(t => t.Course.Title);
                    break;
                case "InstructorName":
                    teachingList = teachingList.OrderByDescending(t => t.Instructor.FirstMidName);
                    break;
            }
            return teachingList;
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
