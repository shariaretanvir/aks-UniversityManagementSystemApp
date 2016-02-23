using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.DAL
{
    public class DepartmentGateway
    {
        private UniversitySemesterDBEntities aDbEntities = new UniversitySemesterDBEntities();
        public int Save(Department aDepartment)
        {
            aDbEntities = new UniversitySemesterDBEntities();
            aDbEntities.Departments.Add(aDepartment);
            return aDbEntities.SaveChanges();
        }

        public List<Department> ShowAllDepartment()
        {
            aDbEntities = new UniversitySemesterDBEntities();
            return aDbEntities.Departments.ToList();
        }


        public bool IsUnique(Department aDepartment)
        {
            Department euDepartment = aDbEntities.Departments.FirstOrDefault(c => (c.Name == aDepartment.Name) || (c.Code == aDepartment.Code));
            if (euDepartment != null)
                return false;
            return true;
        }
    }
}