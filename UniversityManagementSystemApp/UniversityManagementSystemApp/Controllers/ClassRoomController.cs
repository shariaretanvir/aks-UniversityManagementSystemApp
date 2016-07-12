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
            allocateClassRoom.FromState = fromTime;
            allocateClassRoom.ToState = toTime;
            TimeSpan timemy = TimeSpan.Parse(fromTime);
            TimeSpan timemy1 = TimeSpan.Parse(toTime);
            List<AllocateClassRoom> aloRooms = aClassRoomManager.GetAllCourse();
            
            foreach (AllocateClassRoom allocateClassRooms in aloRooms)
            {
                TimeSpan start = TimeSpan.Parse(allocateClassRooms.FromState);
                TimeSpan end = TimeSpan.Parse(allocateClassRooms.ToState);
                //TimeSpan timemy = TimeSpan.Parse(allocateClassRooms.FromState);
                //TimeSpan timemy1 = TimeSpan.Parse(allocateClassRooms.ToState);
                if ((TimeBetween(timemy, start, end) && (allocateClassRooms.RoomId == allocateClassRoom.RoomId) &&
                    (allocateClassRooms.DayId == allocateClassRoom.DayId)) || (TimeBetween(timemy1, start, end) && (allocateClassRooms.RoomId == allocateClassRoom.RoomId) &&
                    (allocateClassRooms.DayId == allocateClassRoom.DayId)))
                {
                    ViewBag.message = "This Schedule is already booked !!";
                    ViewBag.listofDepartments = aCourseManager.LoadDepartment();
                    ViewBag.RoomNo = aClassRoomManager.RoomNo();
                    ViewBag.Day = aClassRoomManager.Day();
                    return View();
                }

                else if ((TimeBetween(start, timemy, timemy1) && (allocateClassRooms.RoomId == allocateClassRoom.RoomId) &&
                    (allocateClassRooms.DayId == allocateClassRoom.DayId)) || (TimeBetween(end, timemy, timemy1) && (allocateClassRooms.RoomId == allocateClassRoom.RoomId) &&
                    (allocateClassRooms.DayId == allocateClassRoom.DayId)))
                {
                    ViewBag.message = "This Schedule is already booked !!";
                    ViewBag.listofDepartments = aCourseManager.LoadDepartment();
                    ViewBag.RoomNo = aClassRoomManager.RoomNo();
                    ViewBag.Day = aClassRoomManager.Day();
                    return View();
                }
                //else
                //{
                //    ViewBag.listofDepartments = aCourseManager.LoadDepartment();
                //    ViewBag.RoomNo = aClassRoomManager.RoomNo();
                //    ViewBag.Day = aClassRoomManager.Day();
                //    try
                //    {
                //        ViewBag.message = aClassRoomManager.Save(allocateClassRoom);
                //        return View();
                //    }
                //    catch (Exception e)
                //    {
                //        ViewBag.message = e.Message;
                //        return View();
                //    }
                //}
            }
            ViewBag.listofDepartments = aCourseManager.LoadDepartment();
            ViewBag.RoomNo = aClassRoomManager.RoomNo();
            ViewBag.Day = aClassRoomManager.Day();
            ViewBag.message = aClassRoomManager.Save(allocateClassRoom);
            //bool silenceAlarm = TimeBetween(timemy, start, end);
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