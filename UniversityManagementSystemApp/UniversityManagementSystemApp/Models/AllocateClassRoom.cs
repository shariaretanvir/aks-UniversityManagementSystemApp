//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UniversityManagementSystemApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AllocateClassRoom
    {
        public int Id { get; set; }
        public Nullable<int> DepartmentId { get; set; }
        public Nullable<int> CourseId { get; set; }
        public Nullable<int> RoomId { get; set; }
        public Nullable<int> DayId { get; set; }
        public Nullable<decimal> From { get; set; }
        public string FromState { get; set; }
        public Nullable<decimal> To { get; set; }
        public string ToState { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual Day Day { get; set; }
        public virtual Department Department { get; set; }
        public virtual RoomNo RoomNo { get; set; }
    }
}