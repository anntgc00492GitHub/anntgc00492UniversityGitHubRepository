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
    public interface IOfficeAssignmentService
    {
        OfficeAssignment Add(OfficeAssignment instructor);
        void Update(OfficeAssignment instructor);
        void Delete(int id);
        OfficeAssignment GetById(int id);
        IEnumerable<OfficeAssignment> GetAll();
        IEnumerable<OfficeAssignment> GetBySearchSort(string searchString, string orderSort);
    }
    public class OfficeAssignmentService : IOfficeAssignmentService
    {
        private IOfficeAssignmentRepository _instructorRepoistory;
        private IUnitOfWork _unitOfWork;

        public OfficeAssignmentService(IOfficeAssignmentRepository instructorRepoistory, IUnitOfWork unitOfWork)
        {
            _instructorRepoistory = instructorRepoistory;
            _unitOfWork = unitOfWork;
        }

        public OfficeAssignment Add(OfficeAssignment instructor)
        {
            return _instructorRepoistory.Add(instructor);
        }

        public void Update(OfficeAssignment instructor)
        {
            _instructorRepoistory.Update(instructor);
        }

        public void Delete(int id)
        {
            _instructorRepoistory.Delete(id);
        }

        public OfficeAssignment GetById(int id)
        {
            return _instructorRepoistory.GetSingleById(id);
        }

        public IEnumerable<OfficeAssignment> GetAll()
        {
            return _instructorRepoistory.GetAll();
        }



        public IEnumerable<OfficeAssignment> GetBySearchSort(string searchString, string orderSort)
        {
            var officeAssginmentList = GetAll();
            if (!string.IsNullOrEmpty(searchString))
            {
                officeAssginmentList = officeAssginmentList.Where(s => s.Location.Contains(searchString));
            }
            switch (orderSort)
            {
                case "Location":
                    officeAssginmentList = officeAssginmentList.OrderByDescending(o=>o.Location);
                    break;
                default:
                    officeAssginmentList = officeAssginmentList.OrderByDescending(o=>o.InstructorID);
                    break;
            }
            return officeAssginmentList;
        }
        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
