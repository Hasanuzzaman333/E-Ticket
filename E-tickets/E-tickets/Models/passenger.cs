//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace E_tickets.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class passenger
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public passenger()
        {
            this.reserves = new HashSet<reserve>();
        }
    
        public int pid { get; set; }
        public string name { get; set; }
        public string phone_no { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int ptype { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reserve> reserves { get; set; }
    }
}