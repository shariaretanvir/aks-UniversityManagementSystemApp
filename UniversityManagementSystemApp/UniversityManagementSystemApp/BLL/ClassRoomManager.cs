using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemApp.DAL;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.BLL
{
    
    public class ClassRoomManager
    {
        ClassRoomGateway aClassRoomGateway = new ClassRoomGateway();

        public List<RoomNo> RoomNo()
        {
            return aClassRoomGateway.RoomNo();
        }

        public List<Day> Day()
        {
            return aClassRoomGateway.Day();
        }
    }
}