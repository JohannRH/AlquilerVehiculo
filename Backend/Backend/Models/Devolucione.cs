//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Backend.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Devolucione
    {
        public int id_devolucion { get; set; }
        public Nullable<int> id_renta { get; set; }
        public Nullable<System.DateTime> fecha_devolucion { get; set; }
        public Nullable<int> kilometraje_final { get; set; }
        public string observaciones { get; set; }
        public Nullable<decimal> costo_final { get; set; }
    
        public virtual Renta Renta { get; set; }
    }
}
