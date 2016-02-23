using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.DAL;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.BLL
{
    public class StudentManager
    {
        private StudentGateway asStudentGateway = new StudentGateway();
        public int CheckEmail(string email)
        {
            return asStudentGateway.CheckEmail(email);
        }

        public int Save(Student student)
        {
            return asStudentGateway.Save(student);
        }

        public object ShowResult(int id)
        {
            return asStudentGateway.ShowResult(id);
        }
    }
}