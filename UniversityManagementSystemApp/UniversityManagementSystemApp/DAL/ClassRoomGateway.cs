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
    }
}