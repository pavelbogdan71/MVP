﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ScoalaDBEntities1 : DbContext
    {
        public ScoalaDBEntities1()
            : base("name=ScoalaDBEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Absenta> Absentas { get; set; }
        public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<Clasa> Clasas { get; set; }
        public virtual DbSet<Elev> Elevs { get; set; }
        public virtual DbSet<Materie> Materies { get; set; }
        public virtual DbSet<Nota> Notas { get; set; }
        public virtual DbSet<Profesor> Profesors { get; set; }
    
        public virtual int AddAbsence(Nullable<int> absentaID, string data, Nullable<bool> motivata, Nullable<int> elevID, Nullable<int> materieID)
        {
            var absentaIDParameter = absentaID.HasValue ?
                new ObjectParameter("absentaID", absentaID) :
                new ObjectParameter("absentaID", typeof(int));
    
            var dataParameter = data != null ?
                new ObjectParameter("data", data) :
                new ObjectParameter("data", typeof(string));
    
            var motivataParameter = motivata.HasValue ?
                new ObjectParameter("motivata", motivata) :
                new ObjectParameter("motivata", typeof(bool));
    
            var elevIDParameter = elevID.HasValue ?
                new ObjectParameter("elevID", elevID) :
                new ObjectParameter("elevID", typeof(int));
    
            var materieIDParameter = materieID.HasValue ?
                new ObjectParameter("materieID", materieID) :
                new ObjectParameter("materieID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddAbsence", absentaIDParameter, dataParameter, motivataParameter, elevIDParameter, materieIDParameter);
        }
    
        public virtual int AddGrade(Nullable<int> notaID, Nullable<int> elevID, Nullable<int> materieID, Nullable<int> nota)
        {
            var notaIDParameter = notaID.HasValue ?
                new ObjectParameter("notaID", notaID) :
                new ObjectParameter("notaID", typeof(int));
    
            var elevIDParameter = elevID.HasValue ?
                new ObjectParameter("elevID", elevID) :
                new ObjectParameter("elevID", typeof(int));
    
            var materieIDParameter = materieID.HasValue ?
                new ObjectParameter("materieID", materieID) :
                new ObjectParameter("materieID", typeof(int));
    
            var notaParameter = nota.HasValue ?
                new ObjectParameter("nota", nota) :
                new ObjectParameter("nota", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddGrade", notaIDParameter, elevIDParameter, materieIDParameter, notaParameter);
        }
    
        public virtual ObjectResult<Nullable<double>> AverageGrade(Nullable<int> elevID, Nullable<int> materieID)
        {
            var elevIDParameter = elevID.HasValue ?
                new ObjectParameter("elevID", elevID) :
                new ObjectParameter("elevID", typeof(int));
    
            var materieIDParameter = materieID.HasValue ?
                new ObjectParameter("materieID", materieID) :
                new ObjectParameter("materieID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<double>>("AverageGrade", elevIDParameter, materieIDParameter);
        }
    
        public virtual int DeleteGrade(Nullable<int> notaID)
        {
            var notaIDParameter = notaID.HasValue ?
                new ObjectParameter("notaID", notaID) :
                new ObjectParameter("notaID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteGrade", notaIDParameter);
        }
    
        public virtual ObjectResult<GetAllAbsence_Result> GetAllAbsence(Nullable<int> elevID, Nullable<int> materieID)
        {
            var elevIDParameter = elevID.HasValue ?
                new ObjectParameter("elevID", elevID) :
                new ObjectParameter("elevID", typeof(int));
    
            var materieIDParameter = materieID.HasValue ?
                new ObjectParameter("materieID", materieID) :
                new ObjectParameter("materieID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllAbsence_Result>("GetAllAbsence", elevIDParameter, materieIDParameter);
        }
    
        public virtual ObjectResult<GetAllGrades_Result> GetAllGrades(Nullable<int> elevID, Nullable<int> materieID)
        {
            var elevIDParameter = elevID.HasValue ?
                new ObjectParameter("elevID", elevID) :
                new ObjectParameter("elevID", typeof(int));
    
            var materieIDParameter = materieID.HasValue ?
                new ObjectParameter("materieID", materieID) :
                new ObjectParameter("materieID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllGrades_Result>("GetAllGrades", elevIDParameter, materieIDParameter);
        }
    
        public virtual ObjectResult<GetStudentAbsence_Result> GetStudentAbsence(Nullable<int> elevID)
        {
            var elevIDParameter = elevID.HasValue ?
                new ObjectParameter("elevID", elevID) :
                new ObjectParameter("elevID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetStudentAbsence_Result>("GetStudentAbsence", elevIDParameter);
        }
    
        public virtual ObjectResult<GetStudentAverageGrades_Result> GetStudentAverageGrades(Nullable<int> elevID)
        {
            var elevIDParameter = elevID.HasValue ?
                new ObjectParameter("elevID", elevID) :
                new ObjectParameter("elevID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetStudentAverageGrades_Result>("GetStudentAverageGrades", elevIDParameter);
        }
    
        public virtual ObjectResult<Nullable<double>> GetStudentGeneralAverage(Nullable<int> elevID)
        {
            var elevIDParameter = elevID.HasValue ?
                new ObjectParameter("elevID", elevID) :
                new ObjectParameter("elevID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<double>>("GetStudentGeneralAverage", elevIDParameter);
        }
    
        public virtual ObjectResult<GetStudentGrades_Result> GetStudentGrades(Nullable<int> elevID)
        {
            var elevIDParameter = elevID.HasValue ?
                new ObjectParameter("elevID", elevID) :
                new ObjectParameter("elevID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetStudentGrades_Result>("GetStudentGrades", elevIDParameter);
        }
    
        public virtual int ModifyAbsence(Nullable<int> absentaID)
        {
            var absentaIDParameter = absentaID.HasValue ?
                new ObjectParameter("absentaID", absentaID) :
                new ObjectParameter("absentaID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ModifyAbsence", absentaIDParameter);
        }
    }
}
