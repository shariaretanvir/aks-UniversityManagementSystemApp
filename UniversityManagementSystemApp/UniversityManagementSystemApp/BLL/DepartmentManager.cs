using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.DAL;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.BLL
{
    public class DepartmentManager
    {
        private DepartmentGateway aGateway = new DepartmentGateway();

        public int Save(Department aDepartment)
        {

            if (IsUnique(aDepartment))
            {
                return aGateway.Save(aDepartment);
            }
            else
            {
                throw new Exception("Duplicate contant found");
            }
        }

        private bool IsUnique(Department aDepartment)
        {
            return aGateway.IsUnique(aDepartment);
        }

        public List<Department> ShowAllDepartment()
        {
            return aGateway.ShowAllDepartment();
        }

       
    }
}