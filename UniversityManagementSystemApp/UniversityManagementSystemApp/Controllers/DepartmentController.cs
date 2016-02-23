using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemApp.BLL;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Controllers
{
    public class DepartmentController : Controller
    {
        private DepartmentManager aManager;
        
        // GET: Department
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DepartmentSave()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmentSave(Department aDepartment)  
        {
            try
            {
                aManager = new DepartmentManager();
                ViewBag.Message = 
                    aManager.Save(aDepartment) > 0 ? "One Department Saved" : "Save Failed";
                return View();
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
        }

        public ActionResult ShowAllDepartment()
        {
            aManager = new DepartmentManager();
            return View(aManager.ShowAllDepartment());
        }
    }
}