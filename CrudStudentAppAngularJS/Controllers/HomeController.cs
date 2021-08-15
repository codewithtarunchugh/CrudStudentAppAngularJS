using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrudStudentAppAngularJS.Models;

namespace CrudStudentAppAngularJS.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public string InsertStudentRecord(student std)
        {
            using (CRUD_SampleEntities db = new CRUD_SampleEntities())
            {
                db.students.Add(std);
                db.SaveChanges();
                return "Student Added Successfully!";
            }
        }
        public JsonResult GetAllStudent()
        {
            CRUD_SampleEntities db = new CRUD_SampleEntities();
            var AllRecord = db.students.ToList();
            return Json(AllRecord, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public string UpdateStudentRecord(student std)
        {
            using (CRUD_SampleEntities db = new CRUD_SampleEntities())
            {
                var record = db.students.Where(x => x.ID == std.ID).FirstOrDefault();
                record.Name = std.Name;
                record.Department = std.Department;
                record.Age = std.Age;              
                db.SaveChanges();
                return "Student Record Updated Successfully!";
            }
        }
        public string DeleteStudent(student std)
        {
            using (CRUD_SampleEntities db = new CRUD_SampleEntities())
            {
                var record = db.students.Where(x => x.ID == std.ID).FirstOrDefault();
                db.students.Remove(record);
                db.SaveChanges();
                return "Student Record Updated Successfully!";
            }
        }
    }
}