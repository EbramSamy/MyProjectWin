//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StAbraam.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Doctor_Sub_Specialty
    {
        public int Id { get; set; }
        public int DoctorID { get; set; }
        public int Sub_SpecialtyID { get; set; }
    
        public virtual Doctor Doctor { get; set; }
        public virtual Sub_Specialty Sub_Specialty { get; set; }
    }
}
