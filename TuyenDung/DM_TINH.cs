//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TuyenDung
{
    using System;
    using System.Collections.Generic;
    
    public partial class DM_TINH
    {
        public DM_TINH()
        {
            this.DM_TINH_NGUON = new HashSet<DM_TINH_NGUON>();
        }
    
        public int ID_TINH { get; set; }
        public string MA_TINH { get; set; }
        public string TEN_TINH { get; set; }
    
        public virtual ICollection<DM_TINH_NGUON> DM_TINH_NGUON { get; set; }
    }
}
