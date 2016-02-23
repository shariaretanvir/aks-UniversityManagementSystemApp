using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemApp.DAL;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.BLL
{
    public class TeacherManager
    {
        TeacherGataway aTeacherGataway = new TeacherGataway();
        public List<SelectListItem> GetAllDesignation()
        {
            return aTeacherGataway.GetAllDesignation();
            
        }

        public int Save(Teacher teacher)
        {
            if (IsUnique(teacher))
            {
                return aTeacherGataway.Save(teacher);
            }
            else
            {
                throw new Exception("Duplicate contant found");
            }
        }

        private bool IsUnique(Teacher teacher)
        {
            return aTeacherGataway.IsUnique(teacher);
        }
    }
}