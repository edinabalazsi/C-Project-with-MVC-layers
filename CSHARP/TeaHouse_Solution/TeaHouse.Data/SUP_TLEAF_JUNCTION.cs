//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TeaHouse.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class SUP_TLEAF_JUNCTION
    {
        public int STL_ID { get; set; }
        public Nullable<int> SUP_ID { get; set; }
        public Nullable<int> TL_ID { get; set; }
    
        public virtual SUPPLIER SUPPLIER { get; set; }
        public virtual TEALEAF TEALEAF { get; set; }
    }
}
