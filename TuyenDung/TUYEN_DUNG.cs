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
    
    public partial class TUYEN_DUNG
    {
        public int ID_TUYEN_DUNG { get; set; }
        public string MA_TUYEN_DUNG { get; set; }
        public string VI_TRI { get; set; }
        public string MUC_LUONG { get; set; }
        public string KHU_VUC { get; set; }
        public string HAN_NOP { get; set; }
        public string URL { get; set; }
        public bool LUU { get; set; }
        public System.DateTime NGAY_LAY { get; set; }
        public int ID_NGUON { get; set; }
    
        public virtual NGUON NGUON { get; set; }
    }
}