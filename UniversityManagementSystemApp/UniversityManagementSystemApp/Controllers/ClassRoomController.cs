using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemApp.BLL;

namespace UniversityManagementSystemApp.Controllers
{
    public class ClassRoomController : Controller
    {
        ClassRoomManager aClassRoomManager = new ClassRoomManager();
        CourseManager aCourseManager = new CourseManager();
        // GET: ClassRoom
        public ActionResult Index()
        {
            ViewBag.listofDepartments = aCourseManager.LoadDepartment();
            ViewBag.RoomNo = aClassRoomManager.RoomNo();
            ViewBag.Day = aClassRoomManager.Day();
            return View();
        }
    }
}