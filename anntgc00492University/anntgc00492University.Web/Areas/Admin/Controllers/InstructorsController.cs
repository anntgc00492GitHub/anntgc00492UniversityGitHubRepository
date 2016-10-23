using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Anntgc00492University.Data;
using Anntgc00492University.Data.Migrations;
using Anntgc00492University.Model.Models;
using Anntgc00492University.Service;

namespace anntgc00492University.Web.Areas.Admin.Controllers
{
    [Authorize]
    [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
    public class InstructorsController : Controller
    {
        private IInstructorService _instructorService;

        public InstructorsController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        // GET: Admin/Instructors
        public ActionResult Index()
        {
            //var instructors = db.Instructors.Include(i => i.OfficeAssignment);
            //return View(instructors.ToList());
            return View(_instructorService.GetAll().ToList());
        }

        // GET: Admin/Instructors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = _instructorService.GetById(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }

        // GET: Admin/Instructors/Create
        public ActionResult Create()
        {
            //ViewBag.ID = new SelectList(db.OfficeAssigments, "InstructorID", "Location");
            return View();
        }

        // POST: Admin/Instructors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,HireDate,FirstMidName,LastName")] Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                //db.Instructors.Add(instructor);
                //db.SaveChanges();
                _instructorService.Add(instructor);
                _instructorService.Save();
                return RedirectToAction("Index");
            }

            //ViewBag.ID = new SelectList(db.OfficeAssigments, "InstructorID", "Location", instructor.ID);
            return View(instructor);
        }

        // GET: Admin/Instructors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = _instructorService.GetById(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            //ViewBag.ID = new SelectList(db.OfficeAssigments, "InstructorID", "Location", instructor.ID);
            return View(instructor);
        }

        // POST: Admin/Instructors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,HireDate,FirstMidName,LastName")] Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                _instructorService.Save();
                _instructorService.Save();;
                return RedirectToAction("Index");
            }
            //ViewBag.ID = new SelectList(db.OfficeAssigments, "InstructorID", "Location", instructor.ID);
            return View(instructor);
        }

        // GET: Admin/Instructors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = _instructorService.GetById(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }

        // POST: Admin/Instructors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _instructorService.Delete(id);
            _instructorService.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
