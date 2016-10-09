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
    public interface IInstructorService
    {
        Instructor Add(Instructor instructor);
        void Update(Instructor instructor);
        void Delete(int id);
        Instructor GetById(int? id);
        IEnumerable<Instructor> GetAll();
        IEnumerable<Instructor> GetByFilterSearchSort(DateTime hireDate, string searchString, string orderSort);
    }
    public class InstructorService : IInstructorService
    {
        private IInstructorRepository _instructorRepoistory;
        private IUnitOfWork _unitOfWork;

        public InstructorService(IInstructorRepository instructorRepoistory, IUnitOfWork unitOfWork)
        {
            _instructorRepoistory = instructorRepoistory;
            _unitOfWork = unitOfWork;
        }

        public Instructor Add(Instructor instructor)
        {
            return _instructorRepoistory.Add(instructor);
        }

        public void Update(Instructor instructor)
        {
            _instructorRepoistory.Update(instructor);
        }

        public void Delete(int id)
        {
            _instructorRepoistory.Delete(id);
        }

        public Instructor GetById(int? id)
        {
            return _instructorRepoistory.GetSingleById(id);
        }

        public IEnumerable<Instructor> GetAll()
        {
            return _instructorRepoistory.GetAll();
        }

        public IEnumerable<Instructor> GetByFilterSearchSort(DateTime hireDate, string searchString, string orderSort)
        {
            var instructorList = GetAll();
            if (!string.IsNullOrEmpty(hireDate.ToString()))
            {
                instructorList = instructorList.Where(s => s.HireDate == hireDate);
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                instructorList = instructorList.Where(s => s.FirstMidName.Contains(searchString) || s.LastName.Contains(searchString));
            }
            switch (orderSort)
            {
                case "ID":
                    instructorList = instructorList.OrderByDescending(s => s.ID);
                    break;
                case "FirstName":
                    instructorList = instructorList.OrderByDescending(s => s.FirstMidName);
                    break;
                case "LastName":
                    instructorList = instructorList.OrderByDescending(s => s.LastName);
                    break;
                case "EnrollmentDate":
                    instructorList = instructorList.OrderByDescending(s => s.HireDate);
                    break;
                default:
                    instructorList = instructorList.OrderByDescending(s => s.ID);
                    break;
            }
            return instructorList;
        }
        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
