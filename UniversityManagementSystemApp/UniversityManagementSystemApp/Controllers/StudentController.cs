using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemApp.BLL;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        private CourseManager aCourseManager = new CourseManager();
        private StudentManager aStudentManager = new StudentManager();
        public ActionResult StudentSave()
        {
            ViewBag.listofDepartments = aCourseManager.LoadDepartment();
            return View();
        }

        [HttpPost]
        public ActionResult StudentSave(Student student)
        {
            try
            {
                ViewBag.listofDepartments = aCourseManager.LoadDepartment();
                ViewBag.Message = aStudentManager.Save(student);
                 //> 0 ? "One Student Saved" : "Save Failed";
                ViewBag.Result = aStudentManager.ShowResult(student.Id);
                return View();
            }
            catch (Exception e)
            {
                ViewBag.listofDepartments = aCourseManager.LoadDepartment();
                ViewBag.Message = e.Message;
                return View();
            }
            
        }

        public JsonResult CheckEmail(string Email)
        {
             int ifMailExist = aStudentManager.CheckEmail(Email);
            return Json(ifMailExist, JsonRequestBehavior.AllowGet);
        }

    }
}