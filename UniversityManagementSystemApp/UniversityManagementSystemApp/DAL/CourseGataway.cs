using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;
using UniversityManagementSystemApp.Models;
using SelectListItem = System.Web.Mvc.SelectListItem;

namespace UniversityManagementSystemApp.DAL
{
    public class CourseGataway
    {
        private UniversitySemesterDBEntities aDbEntities = new UniversitySemesterDBEntities();
        public List<SelectListItem> LoadDepartment()
        {
            return aDbEntities.Departments.Select(x => new System.Web.Mvc.SelectListItem()
            {
                Text = x.Code,
                Value = x.Id.ToString()
            }).ToList();
        }

        public List<SelectListItem> LoadSemester()
        {
            return aDbEntities.Semesters.Select(x => new System.Web.Mvc.SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
        }

        public bool IsUnique(Course aCourse)
        {
            Course euCourse = aDbEntities.Courses.FirstOrDefault(c => (c.Code == aCourse.Code) || (c.Name == aCourse.Name));
            if (euCourse != null)
                return false;
            return true;
        }

        public int Save(Course aCourse)
        {
            aDbEntities = new UniversitySemesterDBEntities();
            aDbEntities.Courses.Add(aCourse);
            return aDbEntities.SaveChanges();
        }

        public object GetTeacherByDept(int departmentId)
        {
            return aDbEntities.Teachers.Where(x => x.DepartmentId == departmentId).ToList();
        }

        public object GetCourseByDept(int departmentId)
        {
            return aDbEntities.Courses.Where(x => x.DepartmentId == departmentId).ToList();
        }

        //        update Teacher set RemainingCredit = RemainingCredit- Course.Credit
        //from 
        //CourseAssignTeacher 
        //join Course on CourseAssignTeacher.CourseId = Course.Id
        //join Teacher on CourseAssignTeacher.TeacherId = Teacher.Id

        //where CourseAssignTeacher.Id = 1

        public int CourseAssigningSave(CourseAssignTeacher assignTeacher)
        {
            CourseAssignTeacher course = aDbEntities.CourseAssignTeachers.FirstOrDefault(x => x.CourseId == assignTeacher.CourseId);
            if (course == null)
            {
                aDbEntities.CourseAssignTeachers.Add(assignTeacher);
                int rowAffected = aDbEntities.SaveChanges();
                UpdateTeacher(assignTeacher);
                return rowAffected;
            }
            else
            {
                throw new Exception("This course already Assigned ");

            }
            return 0;
        }

        public void UpdateTeacher(CourseAssignTeacher assignTeacher)
        {

            var creditResult = (from cat in aDbEntities.CourseAssignTeachers
                                join cou in aDbEntities.Courses on cat.CourseId equals cou.Id
                                where cou.Id == assignTeacher.CourseId
                                select cou.Credit).ToList();

            var teacherRemainingCredit = (from cat in aDbEntities.CourseAssignTeachers
                                          join teachers in aDbEntities.Teachers on cat.TeacherId equals teachers.Id
                                          where cat.TeacherId == assignTeacher.TeacherId
                                          select teachers.RemainingCredit).Distinct().ToList();

            var remainingCredit = (teacherRemainingCredit.Single() - creditResult.Single());
            Teacher teacher = aDbEntities.Teachers.Where(x => x.Id == assignTeacher.TeacherId).SingleOrDefault();
            teacher.RemainingCredit = remainingCredit;
            aDbEntities.SaveChanges();

        }

        public object GetTeacherInfo(int teacherId)
        {
            return aDbEntities.Teachers.Where(x => x.Id == teacherId).ToList();
        }

        public object GetCourseInfo(int courseId)
        {
            return aDbEntities.Courses.Where(x => x.Id == courseId).ToList();
        }

        public object FetchCourseDetails(int departmentId)
        {

            var courses = (from course in aDbEntities.Courses
                           join courseAssignTeacher in aDbEntities.CourseAssignTeachers on course.Id equals courseAssignTeacher.CourseId into dd
                from allcourses in dd.DefaultIfEmpty()
            
       
                           join teacher in aDbEntities.Teachers on allcourses.TeacherId equals teacher.Id into ff
                from mff in ff.DefaultIfEmpty()
            
            
                           join semester in aDbEntities.Semesters on course.Semester equals semester.Id
                           where course.DepartmentId == departmentId
                          select new
                           {
                               CourseCode = course.Code,
                               CourseName = course.Name,
                               SemesterName = semester.Name,
                               TeacherName = mff.Name == null ? "Teacher Not assign" : mff.Name

                           }).ToList();
            //.AsEnumerable().Select(c=>c.ToExpando())
            return courses;
        }

       }
}