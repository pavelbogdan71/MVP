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
    
    public partial class Nota
    {
        public int notaID { get; set; }
        public int elevID { get; set; }
        public int materieID { get; set; }
        public double nota1 { get; set; }
    
        public virtual Elev Elev { get; set; }
        public virtual Materie Materie { get; set; }
    }
}
