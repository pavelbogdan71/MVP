//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVP_Tema3.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Profesor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Profesor()
        {
            this.Clasa = new HashSet<Clasa>();
        }
    
        public int profesorID { get; set; }
        public string nume { get; set; }
        public string nume_utilizator { get; set; }
        public string parola { get; set; }
        public bool diriginte { get; set; }
        public int materieID { get; set; }
    
        public virtual Materie Materie { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Clasa> Clasa { get; set; }
    }
}
