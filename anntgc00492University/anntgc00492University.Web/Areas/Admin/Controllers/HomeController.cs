using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Anntgc00492University.Service;
using Microsoft.AspNet.Identity;

namespace anntgc00492University.Web.Areas.Admin.Controllers
{
    [Authorize]
    [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
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
            return View();
        }

        public ActionResult Static()
        {
            return View(_studentService.GetStudentByEnrollmentDateGroup().ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            return RedirectToAction("LogOff2", "Account",new {area=""});
        }


        public ActionResult ERD()
        {
            return View();
        }

        public ActionResult DB()
        {
            return View();
        }
    }
}