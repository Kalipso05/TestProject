using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TestGenerate.Model
{
    public partial class dbModel : DbContext
    {
        public dbModel()
            : base("name=dbModel")
        {
        }

        public virtual DbSet<CodeHospitalization> CodeHospitalization { get; set; }
        public virtual DbSet<DiseaseHistory> DiseaseHistory { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Hospitalization> Hospitalization { get; set; }
        public virtual DbSet<InsuranseCompany> InsuranseCompany { get; set; }
        public virtual DbSet<InsuransePolicy> InsuransePolicy { get; set; }
        public virtual DbSet<MedicalCard> MedicalCard { get; set; }
        public virtual DbSet<Passport> Passport { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<ResultMesuares> ResultMesuares { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Speciality> Speciality { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TherapeuticDiagnosticMesuares> TherapeuticDiagnosticMesuares { get; set; }
        public virtual DbSet<TypeMesuares> TypeMesuares { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CodeHospitalization>()
                .HasMany(e => e.Hospitalization)
                .WithOptional(e => e.CodeHospitalization)
                .HasForeignKey(e => e.IDCodeHospitalization);

            modelBuilder.Entity<DiseaseHistory>()
                .HasMany(e => e.Patient)
                .WithOptional(e => e.DiseaseHistory)
                .HasForeignKey(e => e.IDDiseaseHistory);

            modelBuilder.Entity<Gender>()
                .HasMany(e => e.Patient)
                .WithOptional(e => e.Gender)
                .HasForeignKey(e => e.IDGender);

            modelBuilder.Entity<Gender>()
                .HasMany(e => e.User)
                .WithRequired(e => e.Gender)
                .HasForeignKey(e => e.IDGender)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InsuranseCompany>()
                .HasMany(e => e.Patient)
                .WithRequired(e => e.InsuranseCompany)
                .HasForeignKey(e => e.IDInsuranseCompany)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InsuransePolicy>()
                .HasMany(e => e.Patient)
                .WithRequired(e => e.InsuransePolicy)
                .HasForeignKey(e => e.IDInsuransePolicy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MedicalCard>()
                .HasMany(e => e.Patient)
                .WithRequired(e => e.MedicalCard)
                .HasForeignKey(e => e.IDMedicalCard)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Passport>()
                .HasMany(e => e.Patient)
                .WithRequired(e => e.Passport)
                .HasForeignKey(e => e.IDPassport)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Patient>()
                .HasMany(e => e.Hospitalization)
                .WithOptional(e => e.Patient)
                .HasForeignKey(e => e.IDPatient);

            modelBuilder.Entity<Patient>()
                .HasMany(e => e.TherapeuticDiagnosticMesuares)
                .WithRequired(e => e.Patient)
                .HasForeignKey(e => e.IDPatient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ResultMesuares>()
                .HasMany(e => e.TherapeuticDiagnosticMesuares)
                .WithRequired(e => e.ResultMesuares)
                .HasForeignKey(e => e.IDResultMesuares)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.User)
                .WithRequired(e => e.Role)
                .HasForeignKey(e => e.IDRole)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Speciality>()
                .HasMany(e => e.User)
                .WithRequired(e => e.Speciality)
                .HasForeignKey(e => e.IDSpeciality)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TypeMesuares>()
                .HasMany(e => e.TherapeuticDiagnosticMesuares)
                .WithRequired(e => e.TypeMesuares)
                .HasForeignKey(e => e.IDTypeMesuares)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.TherapeuticDiagnosticMesuares)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IDUser)
                .WillCascadeOnDelete(false);
        }
    }
}
