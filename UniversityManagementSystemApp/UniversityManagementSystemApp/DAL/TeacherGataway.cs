using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.DAL
{
    public class TeacherGataway
    {
        UniversitySemesterDBEntities aDbEntities = new UniversitySemesterDBEntities();
        public List<SelectListItem> GetAllDesignation()
        {
            return aDbEntities.Designations.Select(x => new SelectListItem()
            {
                Text = x.Designation1,
                Value = x.Id.ToString() 
            }).ToList();
        }

        public int Save(Teacher teacher)
        {
            aDbEntities.Teachers.Add(teacher);
            return aDbEntities.SaveChanges();
        }

        public bool IsUnique(Teacher teacher)
        {
            Teacher ateacher = aDbEntities.Teachers.FirstOrDefault(c => c.Email == teacher.Email);
            if (ateacher != null)
                return false;
            return true;
        }
    }
}