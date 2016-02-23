using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.Models;
using UniversityManagementSystemApp.ViewModel;

namespace UniversityManagementSystemApp.DAL
{
    public class StudentGateway
    {
        private UniversitySemesterDBEntities aDbEntities;
        public int CheckEmail(string email)
        {
            aDbEntities = new UniversitySemesterDBEntities();
            int a = aDbEntities.Students.Where(x => x.Email == email).Count();
            return a;
        }
        string tempo;
        private int year;
        private int sum = 0;
        public int Save(Student student)
        {
            aDbEntities = new UniversitySemesterDBEntities();
            aDbEntities.Students.Add(student);
            int rowAffected = aDbEntities.SaveChanges();
            string studentRegNo = GetRegNo(student);
            
            UpdateReg(student, studentRegNo);
            return rowAffected;
        }

        private void UpdateReg(Student student, string studentRegNo)
        {
            aDbEntities = new UniversitySemesterDBEntities();
            var updatedRow = (from stt in aDbEntities.Students 
            where stt.Id == student.Id select stt);
            foreach (Student itemRow in updatedRow)
            {
                itemRow.StudentRegNo = studentRegNo;
                //aDbEntities.Students.Attach(itemRow);
                aDbEntities.Entry(itemRow).Property(X => X.StudentRegNo).IsModified = true;    
            }
            
            aDbEntities.SaveChanges();
            //aDbEntities.SubmitChanges();
            //updatedRow = studentRegNo;
            
        }

        private string GetRegNo(Student student)
        {
            aDbEntities = new UniversitySemesterDBEntities();
            var deptCode = (from stdDept in aDbEntities.Students
                join department in aDbEntities.Departments on stdDept.DepartmentId equals department.Id
                where stdDept.DepartmentId == student.DepartmentId
                select stdDept.Department).Distinct().ToList();

            foreach (var item in deptCode)
            {
                tempo = item.Code; //here
            }
            string Code = tempo;


            var date = aDbEntities.Students.Where(x => x.Id == student.Id).Select(c => c.Date).ToList();
            foreach (DateTime dates in date)
            {
                year = dates.Year;
            }
            string onlyYear = year.ToString();


            var allYear = aDbEntities.Students.Where(c=>c.DepartmentId == student.DepartmentId).Select(x => x.Date).ToList();
            foreach (DateTime allyears in allYear)
            {
                if (allyears.Year == Convert.ToInt32(onlyYear))
                {
                    sum = sum + 1;
                }
            }
            int countYear = sum;
            int length = 3;
            string asString = countYear.ToString("D" + length);
            string StdReg = string.Concat(Code, "-", onlyYear,"-",asString);

            
            //int number = 50;
             //"0050"

            

            return StdReg;
        }

        public object ShowResult(int id)
        {
            //aDbEntities = new UniversitySemesterDBEntities();
            //var result = aDbEntities.Students.ToList();

            var result = (from student in aDbEntities.Students
                          join department in aDbEntities.Departments on student.DepartmentId equals department.Id
                          where student.Id == id
                          select new ViewStudentInfo
                          {
                              Id = student.Id,
                              StudentRegNo = student.StudentRegNo,
                              Name = student.Name,
                              Email = student.Email,
                              ContactNo = student.ContactNo,
                              Date = student.Date,
                              Address = student.Address,
                              Code = department.Code
                          }
                ).ToList();
            return result;
        }
    }}