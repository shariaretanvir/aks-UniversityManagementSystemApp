using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemApp.DAL;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.BLL
{
     
    public class CourseManager
    {
        private CourseGataway aGataway = new CourseGataway();
        public List<SelectListItem> LoadDepartment()
        {
            return aGataway.LoadDepartment();

        }

        public List<SelectListItem> LoadSemester()
        {
            return aGataway.LoadSemester();
        }

        public int Save(Course aCourse)
        {
            if (IsUnique(aCourse))
            {
                return aGataway.Save(aCourse);
            }
            else
            {
                throw new Exception("Duplicate contant found");
            }
        }

        private bool IsUnique(Course aCourse)
        {
            return aGataway.IsUnique(aCourse);
        }

        public object GetTeacherByDept(int departmentId)
        {
            return aGataway.GetTeacherByDept(departmentId);
        }

        public object GetCourseByDept(int departmentId)
        {
            return aGataway.GetCourseByDept(departmentId);
        }

        public int CourseAssigningSave(CourseAssignTeacher assignTeacher)
        {
            return aGataway.CourseAssigningSave(assignTeacher);
        }

        public object GetTeacherInfo(int teacherId)
        {
            return aGataway.GetTeacherInfo(teacherId);
        }

        public object GetCourseInfo(int courseId)
        {
            return aGataway.GetCourseInfo(courseId);
        }

        //public int UpdateTeacher(CourseAssignTeacher assignTeacher)
        //{
        //    return aGataway.UpdateTeacher(assignTeacher);
        //}
        public object FetchCourseDetails(int departmentId)
        {
            return aGataway.FetchCourseDetails(departmentId);
        }
    }
}