﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TuyenDungContext : DbContext
    {
        public TuyenDungContext()
            : base("name=TuyenDungContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DM_NGANH_NGHE> DM_NGANH_NGHE { get; set; }
        public virtual DbSet<DM_NGANH_NGHE_NGUON> DM_NGANH_NGHE_NGUON { get; set; }
        public virtual DbSet<DM_TINH> DM_TINH { get; set; }
        public virtual DbSet<DM_TINH_NGUON> DM_TINH_NGUON { get; set; }
        public virtual DbSet<NGUON> NGUONs { get; set; }
        public virtual DbSet<TUYEN_DUNG> TUYEN_DUNG { get; set; }
    }
}
