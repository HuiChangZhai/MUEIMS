﻿//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace EnterpriseSystemASPX.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EMSEntities : DbContext
    {
        public EMSEntities()
            : base("name=EMSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Enterprise> Enterprise { get; set; }
        public DbSet<EnterpriseCases> EnterpriseCases { get; set; }
        public DbSet<EnterpriseDynamic> EnterpriseDynamic { get; set; }
        public DbSet<MEnterprise> MEnterprise { get; set; }
        public DbSet<MEnterpriseAdmin> MEnterpriseAdmin { get; set; }
        public DbSet<MEnterpriseAdvertising> MEnterpriseAdvertising { get; set; }
        public DbSet<MEnterpriseCases> MEnterpriseCases { get; set; }
    }
}
