using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Anntgc00492University.Service;

namespace anntgc00492University.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IStudentService _studentService;

        public HomeController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: Admin/Home
        public ActionResult Index()
        {
            return View(_studentService.GetAll());
        }
    }
}