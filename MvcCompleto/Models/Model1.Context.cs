﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcCompleto.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DelegaEntities : DbContext
    {
        public DelegaEntities()
            : base("name=DelegaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Alumno> Alumno { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<Imagen> Imagen { get; set; }
        public virtual DbSet<Profesor> Profesor { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
    }
}
