using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemApp.BLL;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Controllers
{
    public class CourseController : Controller
    {
        CourseManager aManager = new CourseManager();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SaveCourse()
        {
            ViewBag.ListOfSemester = aManager.LoadSemester();
            ViewBag.listofDepartments = aManager.LoadDepartment();
            return View();
        }

        [HttpPost]
        public ActionResult SaveCourse(Course aCourse)
        {
            try
            {
                ViewBag.Message = aManager.Save(aCourse) > 0 ? "One Department Saved" : "Save Failed";
                ViewBag.ListOfSemester = aManager.LoadSemester();
                ViewBag.listofDepartments = aManager.LoadDepartment();
                return View();
            }
            catch (Exception e)
            {
                ViewBag.ListOfSemester = aManager.LoadSemester();
                ViewBag.listofDepartments = aManager.LoadDepartment();
                ViewBag.Error = e.Message;
                return View();
            }
        }
        [HttpPost]
        public ActionResult CourseAssigning(CourseAssignTeacher assignTeacher)
        {
            

            try
            {
                ViewBag.listofDepartments = aManager.LoadDepartment();
                ViewBag.Message = aManager.CourseAssigningSave(assignTeacher) > 0 ? "One Course Assigning Saved" : "Save Failed";
                //aManager.UpdateTeacher(assignTeacher);
                return View();
            }
            catch (Exception e)
            {
                ViewBag.listofDepartments = aManager.LoadDepartment();
                ViewBag.Error = e.Message;
                return View();
            }
        }

        public ActionResult CourseAssigning()
        {
            ViewBag.listofDepartments = aManager.LoadDepartment();
            return View();
        }

        public JsonResult GetTeacherByDept(int departmentId)
        {
            var teacherList = aManager.GetTeacherByDept(departmentId);
            var a = new List<KeyValuePair<int, string>>();
            foreach (var proval in (List<Teacher>)teacherList)
            {
                //int keyObj = proval.Id;
                //string valueObj = (string)proval.Name;

                a.Add(new KeyValuePair<int, string>(proval.Id, proval.Name));


            }
            return Json(a, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetCourseByDept(int departmentId)
        {
            var courseList = aManager.GetCourseByDept(departmentId);
            var a = new List<KeyValuePair<int, string>>();
            foreach (var proval in (List<Course>)courseList)
            {
                //int keyObj = proval.Id;
                //string valueObj = (string)proval.Name;

                a.Add(new KeyValuePair<int, string>(proval.Id, proval.Code));


            }
            return Json(a, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTeacherInfo(int TeacherId)
        {
            var teacherList = aManager.GetTeacherInfo(TeacherId);
            var a = new List<KeyValuePair<decimal?, decimal?>>();
            foreach (var proval in (List<Teacher>)teacherList)
            {
                //int keyObj = proval.Id;
                //string valueObj = (string)proval.Name;

                a.Add(new KeyValuePair<decimal?, decimal?>(proval.Credit_Taken, proval.RemainingCredit));


            }
            return Json(a, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourseInfo(int CourseId)
        {
            var courseList = aManager.GetCourseInfo(CourseId);
            var b = new List<KeyValuePair<string, decimal?>>();
            foreach (var proval1 in (List<Course>)courseList)
            {
                //int keyObj = proval.Id;
                //string valueObj = (string)proval.Name;

                b.Add(new KeyValuePair<string, decimal?>(proval1.Name, proval1.Credit));


            }
            return Json(b, JsonRequestBehavior.AllowGet);
        }


        public ActionResult ViewCourse()
        {
            ViewBag.listofDepartments = aManager.LoadDepartment();
            return View();
        }
       [HttpPost]
        public JsonResult ViewCourse(int departmentId)
        {
            var a = aManager.FetchCourseDetails(departmentId);
            ViewBag.listofDepartments = aManager.LoadDepartment();
            return Json(a,JsonRequestBehavior.AllowGet);
        }



        //public JsonResult GetTeacherCourseByDept(int departmentId)
        //{
        //    var teacherList = aManager.GetTeacherCourseByDept(departmentId);
        //    //var a = new List<KeyValuePair<int, string>>();
        //    //foreach (var proval in (List<Teacher>)teacherList)
        //    //{
        //    //    //int keyObj = proval.Id;
        //    //    //string valueObj = (string)proval.Name;

        //    //    a.Add(new KeyValuePair<int, string>(proval.Id, proval.Name));


        //    //}
        //    return Json(teacherList, JsonRequestBehavior.AllowGet);
        //}
    }
}