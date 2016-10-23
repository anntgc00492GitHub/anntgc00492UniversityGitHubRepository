using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Anntgc00492University.Data;
using Anntgc00492University.Model.Models;
using Anntgc00492University.Service;

namespace anntgc00492University.Web.Areas.Admin.Controllers
{
    [Authorize]
    [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
    public class EnrollmentsController : Controller
    {
        private IEnrollmentService _enrollmentService;

        public EnrollmentsController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        private Anntgc00492UniversityDbContext db = new Anntgc00492UniversityDbContext();

        // GET: Admin/Enrollments
        public ActionResult Index()
        {
            var enrollments = db.Enrollments.Include(e => e.Course).Include(e => e.Student);
            return View(enrollments.ToList());
        }

        // GET: Admin/Enrollments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // GET: Admin/Enrollments/Create

       // Biến id truyển vào lấy từ bên student/detail/id sang
        public ActionResult Create(int? id)
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "Title");
            ViewBag.StudentID = new SelectList(db.Students, "ID", "FirstMidName", id);
            ViewBag.SelectedStudentId = id;///Dùng để quay về trang detail student cũ
            return View();
        }

        // POST: Admin/Enrollments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EnrollmentID,StudentID,CourseID,Grade")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                if (_enrollmentService.IsEnrolled(enrollment.StudentID,enrollment.CourseID)==false)//Cho trường hợp thiểu số vào trong ,ok thi thoát ở lõi, còn không lỗi lặt vặt thi để cái return cuối cùng
                {
                    db.Enrollments.Add(enrollment);
                    db.SaveChanges();
                    return RedirectToAction("Details","Students",new {area="Admin",id= enrollment.StudentID });//Viewbag Dùng để quay về trang detail cũ
                }
                ModelState.AddModelError("","This course has been already registered !");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "Title", enrollment.CourseID);
            ViewBag.StudentID = new SelectList(db.Students, "ID", "FirstMidName", enrollment.StudentID);
            ViewBag.SelectedStudentId = enrollment.StudentID;//Nạp lại trong trường hợp create bị lỗi ViewBag.SelectStudentId vẫn tiếp tục được truyền giá trị 
            return View(enrollment);
        }

        // GET: Admin/Enrollments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "Title", enrollment.CourseID);
            ViewBag.StudentID = new SelectList(db.Students, "ID", "FirstMidName", enrollment.StudentID);
            return View(enrollment);
        }

        // POST: Admin/Enrollments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EnrollmentID,StudentID,CourseID,Grade")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enrollment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "Title", enrollment.CourseID);
            ViewBag.StudentID = new SelectList(db.Students, "ID", "FirstMidName", enrollment.StudentID);
            return View(enrollment);
        }

        // GET: Admin/Enrollments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // POST: Admin/Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Enrollment enrollment = db.Enrollments.Find(id);
            db.Enrollments.Remove(enrollment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
