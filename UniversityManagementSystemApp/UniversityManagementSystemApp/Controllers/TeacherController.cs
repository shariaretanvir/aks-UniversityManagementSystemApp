using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemApp.BLL;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Controllers
{
    public class TeacherController : Controller
    {
        CourseManager aManager = new CourseManager();
        TeacherManager aTeacherManager = new TeacherManager();
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SaveTeacher()
        {
            ViewBag.ListOfDesignation = aTeacherManager.GetAllDesignation();
            ViewBag.LoadDepartment = aManager.LoadDepartment();
            return View();
        }

        [HttpPost]
        public ActionResult SaveTeacher(Teacher teacher)
        {
            try
            {
                teacher.RemainingCredit = teacher.Credit_Taken;
                ViewBag.ListOfDesignation = aTeacherManager.GetAllDesignation();
                ViewBag.LoadDepartment = aManager.LoadDepartment();
                ViewBag.Message = aTeacherManager.Save(teacher) > 0 ? "One Teacher Saved" : "Save Failed";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.ListOfDesignation = aTeacherManager.GetAllDesignation();
                ViewBag.LoadDepartment = aManager.LoadDepartment();
                ViewBag.Error = ex.Message;
                return View();
            }

        }

        //private List<SelectListItem> SelectDesignations()
        //{
        //    List<SelectListItem> alist = aTeacherManager.GetAllDesignation();
        //    List<SelectListItem> desigList = new List<SelectListItem>();
        //    foreach (var t in alist)
        //    {
        //        SelectListItem s = new SelectListItem();
        //        if (desigList.Count == 0)
        //        {
        //            s.Text = "Select Designations";
        //            s.Value = "";
        //            desigList.Add(s);
        //        }
        //        else
        //        {
        //            s.Text = t.Text;
        //            s.Value = t.Value.ToString();
        //            desigList.Add(s);
        //        }
        //    }
        //    return desigList;
        //}

        //private List<SelectListItem> GetDepartment()
        //{
        //    List<SelectListItem> alistitem = aManager.LoadDepartment();
        //    List<SelectListItem> mylsItems = new List<SelectListItem>();
        //    foreach (var t in alistitem)
        //    {
        //        SelectListItem s = new SelectListItem();
        //        if (mylsItems.Count == 0)
        //        {
        //            //s.Text = "Select Departments";
        //            //s.Value = "";
        //            //mylsItems.Add(s);
        //        }
        //        else
        //        {
        //            s.Text = t.Text;
        //            s.Value = t.Value;
        //            mylsItems.Add(s);
        //        }
        //    }
        //    return alistitem;
        //}


        
    }
}