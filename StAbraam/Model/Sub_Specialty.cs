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
    
    public partial class Sub_Specialty
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sub_Specialty()
        {
            this.Doctor_Sub_Specialty = new HashSet<Doctor_Sub_Specialty>();
        }
    
        public int Sub_SpecialtyID { get; set; }
        public string Sub_SpecialtyName { get; set; }
        public int SpecialtyID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Doctor_Sub_Specialty> Doctor_Sub_Specialty { get; set; }
        public virtual Specialty Specialty { get; set; }
    }
}