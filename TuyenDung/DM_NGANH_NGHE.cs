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
    
    public partial class DM_NGANH_NGHE
    {
        public DM_NGANH_NGHE()
        {
            this.DM_NGANH_NGHE_NGUON = new HashSet<DM_NGANH_NGHE_NGUON>();
        }
    
        public int ID_NGANH_NGHE { get; set; }
        public int MA_NGANH_NGHE { get; set; }
        public string TEN_NGANH_NGHE { get; set; }
    
        public virtual ICollection<DM_NGANH_NGHE_NGUON> DM_NGANH_NGHE_NGUON { get; set; }
    }
}
