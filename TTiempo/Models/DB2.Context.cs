﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TTiempo.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ExerciseTiempoEntitiesv2 : DbContext
    {
        public ExerciseTiempoEntitiesv2()
            : base("name=ExerciseTiempoEntitiesv2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Customer> Customer { get; set; }
    
        public virtual ObjectResult<Get_All_Customers_Result> Get_All_Customers()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Get_All_Customers_Result>("Get_All_Customers");
        }
    }
}
