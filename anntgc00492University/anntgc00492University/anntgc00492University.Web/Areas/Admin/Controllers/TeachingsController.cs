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

namespace anntgc00492University.Web.Areas.Admin.Controllers
{
    [Authorize]
    [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
    public class TeachingsController : Controller
    {
        private Anntgc00492UniversityDbContext db = new Anntgc00492UniversityDbContext();

        // GET: Admin/Teachings
        public ActionResult Index()
        {
            var teachings = db.Teachings.Include(t => t.Course).Include(t => t.Instructor);
            return View(teachings.ToList());
        }

        // GET: Admin/Teachings/Details/5
        public ActionResult Details(int? Id, int? CourseId)
        {
            if (Id == null || CourseId==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teaching teaching = db.Teachings.Find(Id,CourseId);
            if (teaching == null)
            {
                return HttpNotFound();
            }
            return View(teaching);
        }

        // GET: Admin/Teachings/Create
        public ActionResult Create(int? id)
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "Title");
            ViewBag.InstructorID = new SelectList(db.Instructors, "ID", "FirstMidName",id);
            ViewBag.SelectInstructorId = id;//truyên sang kia để lấy đại chỉ student detail quay về
            return View();
        }

        // POST: Admin/Teachings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InstructorID,CourseID")] Teaching teaching)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Teachings.Add(teaching);
                    db.SaveChanges();
                    return RedirectToAction("Details","Instructors",new {area="Admin",id=ViewBag.SelectInstructorId});
                }
                catch
                {
                    ModelState.AddModelError("", "Already assigned");
                }
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "Title", teaching.CourseID);
            ViewBag.InstructorID = new SelectList(db.Instructors, "ID", "FirstMidName", teaching.InstructorID);
            ViewBag.SelectInstructorId = teaching.InstructorID;
            return View(teaching);
        }

        // GET: Admin/Teachings/Edit/5
        public ActionResult Edit(int? Id,int? CourseId)
        {
            if (Id == null || CourseId==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teaching teaching = db.Teachings.Find(Id,CourseId);
            if (teaching == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "Title", teaching.CourseID);
            ViewBag.InstructorID = new SelectList(db.Instructors, "ID", "FirstMidName", teaching.InstructorID);
            return View(teaching);
        }

        // POST: Admin/Teachings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InstructorID,CourseID")] Teaching teaching)
        {
            if (ModelState.IsValid)
            {
                //Vì không có cơ chế sửa cho composite key nên phảu dùng kiểu add, mà không lưu gì thi sẽ add trùng ,nhừng vì là sửa nên không xuất lỗi nên tự xóa, add lại
                var teachingList =
                    db.Teachings.Where(t => t.InstructorID == teaching.InstructorID)
                        .Where(t => t.CourseID == teaching.CourseID);
                foreach (var t in teachingList)
                {
                    db.Teachings.Remove(t);
                }
                //Thật ra cũng không cần try catch vì xóa luôn rồi nên chắc không add trùng nữa
                try
                {
                    db.Teachings.Add(teaching);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    ModelState.AddModelError("","Error");
                }
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "Title", teaching.CourseID);
            ViewBag.InstructorID = new SelectList(db.Instructors, "ID", "FirstMidName", teaching.InstructorID);
            return View(teaching);
        }

        // GET: Admin/Teachings/Delete/5
        public ActionResult Delete(int? Id,int? CourseId)
        {
            if (Id == null || CourseId==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teaching teaching = db.Teachings.Find(Id,CourseId);
            if (teaching == null)
            {
                return HttpNotFound();
            }
            return View(teaching);
        }

        // POST: Admin/Teachings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int Id,int CourseId)
        {
            Teaching teaching = db.Teachings.Find(Id,CourseId);
            db.Teachings.Remove(teaching);
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
