using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemApp.ViewModel
{
    public class ViewStudentInfo
    {
        public int Id { get; set; }
        public string StudentRegNo { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Address { get; set; }
        public string Code { get; set; }

    }
}