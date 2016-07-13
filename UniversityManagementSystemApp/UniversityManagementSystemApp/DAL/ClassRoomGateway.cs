using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.DAL
{
    public class ClassRoomGateway
    {
        UniversitySemesterDBEntities aDbEntities = new UniversitySemesterDBEntities();
        public List<RoomNo> RoomNo()
        {
            return aDbEntities.RoomNoes.ToList();
        }

        public List<Day> Day()
        {
            return aDbEntities.Days.ToList();
        }

        public List<AllocateClassRoom> GetAllCourse()
        {
            return aDbEntities.AllocateClassRooms.ToList();
        }

        public int Save(AllocateClassRoom allocateClassRoom)
        {
            aDbEntities.AllocateClassRooms.Add(allocateClassRoom);
            return aDbEntities.SaveChanges();
        }

        public object FetchAllocateInfo(int deptId)
        {
            object acList = (from course in aDbEntities.Courses
                join allocateClassRoom in aDbEntities.AllocateClassRooms on course.Id equals
                    allocateClassRoom.CourseId into coulist
                from clist in coulist.DefaultIfEmpty()

                join day in aDbEntities.Days on clist.DayId equals day.Id into candday

                from cd in candday.DefaultIfEmpty()

                join roomNo in aDbEntities.RoomNoes on clist.RoomId equals roomNo.Id into ff
                from rr in ff.DefaultIfEmpty()
            
            
            
                where course.DepartmentId == deptId
                //select course.Id
                select new
                {
                    Code = course.Code,
                    Name = course.Name,
                    AllocateInfo = "R. No :"+ rr.RoomNo1 +","+ cd.DayName +","+ clist.FromState +"-"+ clist.ToState
              }
        ).ToList();
            return acList;

        }
    }
}