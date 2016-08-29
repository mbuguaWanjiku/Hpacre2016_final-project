using DataLayer.Entities;
using DataLayer.Entities.DiagnosisEntities;
using DataLayer.Entities.MCDT;
using DataLayer.Entities.MCDTEntities;
using DataLayer.Entities.PatientEntities;
using DataLayer.Entities.TreatmentEntities;
using DataLayer.Entities.UserEntities;
using DataLayer.Entities.Visitas;
using DataLayer.Entities.Visits;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.EntityFramework
{
    public class HPCareDBContext : DbContext
    {

        public HPCareDBContext() : base("HPCareDBContext") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KFT>().ToTable("KFT");
            modelBuilder.Entity<LFT>().ToTable("LFT");
            modelBuilder.Entity<LymphocytesSubsets>().ToTable("LymphocytesSubsets");
            modelBuilder.Entity<PlateletsCount>().ToTable("PlateletsCount");
            modelBuilder.Entity<RBCIndices>().ToTable("RBCIndices");
            modelBuilder.Entity<RBCS>().ToTable("RBCS");
            modelBuilder.Entity<ViralLoad>().ToTable("ViralLoad");
            modelBuilder.Entity<WBCS>().ToTable("WBCS");
            modelBuilder.Entity<PhysicalExam>().ToTable("PhysicalExam");
            modelBuilder.Entity<PsychiatricExam>().ToTable("PsychiatricExam");
            modelBuilder.Entity<RegularExam>().ToTable("RegularExam");
            modelBuilder.Entity<Staff>().ToTable("Staff");
            modelBuilder.Entity<Patient>().ToTable("Patient");
            modelBuilder.Entity<FirstVisit>().ToTable("FirstVisit");
            modelBuilder.Entity<SubsequentVisit>().ToTable("SubsequentVisit");
        }

        public virtual DbSet<Gender> Genders
        {
            get; set;
        }

        public virtual DbSet<MaritalStatus> MaritalStatus
        {
            get; set;
        }

        public virtual DbSet<ProfessionalsType> ProfessionalTypes
        {
            get; set;
        }

        public virtual DbSet<CID_DiseaseCode> CID_DiseaseCodes
        {
            get; set;
        }

        public virtual DbSet<CID_Category> CID_Categories
        {
            get; set;
        }

        public virtual DbSet<CIDCode> CIDCodes
        {
            get; set;
        }
        /*
        public DbSet<CIDGenerator> CIDGenerators {
            get; set;
        }
        */
        public virtual DbSet<Diagnosis> Diagnoses
        {
            get; set;
        }

        public virtual DbSet<Disease> Diseases
        {
            get; set;
        }

        /*public DbSet<PatientDiagnosisManager> PatientDiagnosisManagers {
            get; set;
        }*/

        public virtual DbSet<LabExams> LabExams
        {
            get; set;
        }

        public virtual DbSet<RegularExam> RegularExams
        {
            get; set;
        }

        public DbSet<MCDT> MCDTs
        {
            get; set;
        }

        public virtual DbSet<MCDTManager> MCDTManagers
        {
            get; set;
        }

        public virtual DbSet<MCDTStaffManager> MCDTStaffManagers
        {
            get; set;
        }

        public virtual DbSet<Admission> Admissions
        {
            get; set;
        }

        public virtual DbSet<Intervention> Interventions
        {
            get; set;
        }

        public DbSet<NextOfKin> NextOfKins
        {
            get; set;
        }

        public DbSet<NextOfKinManager> NextOfKinManagers
        {
            get; set;
        }

        public DbSet<TreatmentPlan> TreatmentPlans
        {
            get; set;
        }

        public DbSet<TreatmentCategory> TreatmentCategories
        {
            get; set;
        }

        public DbSet<TreatmentType> TreatmentTypes
        {
            get; set;
        }

        public virtual DbSet<Drug> Drugs
        {
            get; set;
        }

        public virtual DbSet<DrugCategory> DrugCategories
        {
            get; set;
        }

        public virtual DbSet<DrugIssuance> DrugInssuances
        {
            get; set;
        }

        public virtual DbSet<DrugManager> DrugManagers
        {
            get; set;
        }

        public virtual DbSet<DrugAdministration> DrugAdministrations
        {
            get; set;
        }

        public virtual DbSet<DrugFrequency> DrugFrequencies
        {
            get; set;
        }

        public virtual DbSet<Dosage> DrugDosages
        {
            get; set;
        }

        public virtual DbSet<Therapy> Therapies
        {
            get; set;
        }

        public virtual DbSet<TherapyManager> TherapyManagers
        {
            get; set;
        }

        public virtual DbSet<Users> Users
        {
            get; set;
        }

        public virtual DbSet<AgeGroup> AgeGroups
        {
            get; set;
        }

        public virtual DbSet<Allergies> Allergies
        {
            get; set;
        }

        public virtual DbSet<AllergiesManager> AllergiesManagers
        {
            get; set;
        }

        public virtual DbSet<AllergyCategory> AllergyCategories
        {
            get; set;
        }

        public virtual DbSet<FamilyHistory> FamilyHistories
        {
            get; set;
        }

        public virtual DbSet<FamilyHistoryManager> FamilyHistoryManagers
        {
            get; set;
        }

        public virtual DbSet<FamilyHistoryCategory> FamilyHistoryCategories
        {
            get; set;
        }

        public virtual DbSet<RiskFactors> RiskFactors
        {
            get; set;
        }

        public virtual DbSet<RiskFactorsManager> RiskFactorsManagers
        {
            get; set;
        }

        public virtual DbSet<RiskFactorsCategory> RiskFactorsCategories
        {
            get; set;
        }

        public virtual DbSet<ClinicRegistryManager> ClinicRegistryManagers
        {
            get; set;
        }

        public DbSet<Visit> Visits
        {
            get; set;
        }
        /*
        public DbSet<HomeVisitManager> HomeVisitManagers {
            get; set;
        }*/

        public virtual DbSet<VisitManager> VisitManagers
        {
            get; set;
        }


    }
}
