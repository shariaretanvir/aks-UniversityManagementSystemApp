using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemApp.BLL;
using UniversityManagementSystemApp.Models;

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

        [HttpPost]
        public ActionResult Index(AllocateClassRoom allocateClassRoom)
        {
            string fromTime = convertTo24Hour(allocateClassRoom.FromState);
            string toTime = convertTo24Hour(allocateClassRoom.ToState);
            TimeSpan start = TimeSpan.Parse(fromTime);
            TimeSpan end = TimeSpan.Parse(toTime);
            TimeSpan timemy = TimeSpan.Parse("12:25");
            bool silenceAlarm = TimeBetween(timemy, start, end);
            return View();
        }

        private bool TimeBetween(TimeSpan timemy, TimeSpan time, TimeSpan time1)
        {
            if (time < time1)
                return time <= timemy && timemy <= time1;
            // start is after end, so do the inverse comparison
            return !(time1 < timemy && timemy < time);
        }

        private string convertTo24Hour(string p0)
        {
            DateTime time = DateTime.Parse(p0);
            return time.ToString("HH:mm");
        }
    }
}