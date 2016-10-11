using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using anntgc00492University.Data.Infrastructure;
using Anntgc00492University.Data.Infrastructure;
using Anntgc00492University.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Anntgc00492University.UnitTest.RepositoryTest
{
    [TestClass]
    public class StudentRepositoryTest
    {
        IDbFactory dbFactory;
        IUnitOfWork unitOfWork;
        IStudentRepository studentRepository;

        [TestInitialize]
        public void Initialize()
        {
            dbFactory = new DbFactory();
            studentRepository = new StudentRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory);
        }

        [TestMethod]
        public void GetAll()
        {
            var list = studentRepository.GetAll().ToList();
            Assert.AreEqual(3,list.Count);
        }
    }
}
