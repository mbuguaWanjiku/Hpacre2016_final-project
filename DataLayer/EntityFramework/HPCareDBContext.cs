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

namespace DataLayer.EntityFramework {
    public class HPCareDBContext : DbContext {

        public HPCareDBContext() : base("HPCareDBContextPublish") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
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

        public DbSet<Gender> Genders {
            get; set;
        }

        public DbSet<MaritalStatus> MaritalStatus {
            get; set;
        }

        public DbSet<ProfessionalsType> ProfessionalTypes {
            get; set;
        }

        public DbSet<CID_DiseaseCode> CID_DiseaseCodes {
            get; set;
        }

        public DbSet<CID_Category> CID_Categories {
            get; set;
        }

        public DbSet<CIDCode> CIDCodes {
            get; set;
        }
        /*
        public DbSet<CIDGenerator> CIDGenerators {
            get; set;
        }
        */
        public DbSet<Diagnosis> Diagnoses {
            get; set;
        }

        public DbSet<Disease> Diseases {
            get; set;
        }

        /*public DbSet<PatientDiagnosisManager> PatientDiagnosisManagers {
            get; set;
        }*/

        public DbSet<LabExams> LabExams {
            get; set;
        }

        public DbSet<RegularExam> RegularExams {
            get; set;
        }

        public DbSet<MCDT> MCDTs {
            get; set;
        }

        public DbSet<MCDTManager> MCDTManagers {
            get; set;
        }

        public DbSet<MCDTStaffManager> MCDTStaffManagers {
            get; set;
        }

        public DbSet<Admission> Admissions {
            get; set;
        }

        public DbSet<Intervention> Interventions {
            get; set;
        }

        public DbSet<NextOfKin> NextOfKins {
            get; set;
        }

        public DbSet<NextOfKinManager> NextOfKinManagers {
            get; set;
        }

        public DbSet<TreatmentPlan> TreatmentPlans {
            get; set;
        }

        public DbSet<TreatmentCategory> TreatmentCategories {
            get; set;
        }

        public DbSet<TreatmentType> TreatmentTypes {
            get; set;
        }

        public DbSet<Drug> Drugs {
            get; set;
        }

        public DbSet<DrugCategory> DrugCategories {
            get; set;
        }

        public DbSet<DrugIssuance> DrugInssuances {
            get; set;
        }

        public DbSet<DrugManager> DrugManagers {
            get; set;
        }

        public DbSet<DrugAdministration> DrugAdministrations {
            get; set;
        }

        public DbSet<DrugFrequency> DrugFrequencies {
            get; set;
        }

        public DbSet<Dosage> DrugDosages {
            get; set;
        }

        public DbSet<Therapy> Therapies {
            get; set;
        }

        public DbSet<TherapyManager> TherapyManagers {
            get; set;
        }

        public DbSet<Users> Users {
            get; set;
        }

        public DbSet<AgeGroup> AgeGroups {
            get; set;
        }

        public DbSet<Allergies> Allergies {
            get; set;
        }

        public DbSet<AllergiesManager> AllergiesManagers {
            get; set;
        }

        public DbSet<AllergyCategory> AllergyCategories {
            get; set;
        }

        public DbSet<FamilyHistory> FamilyHistories {
            get; set;
        }

        public DbSet<FamilyHistoryManager> FamilyHistoryManagers {
            get; set;
        }

        public DbSet<FamilyHistoryCategory> FamilyHistoryCategories {
            get; set;
        }

        public DbSet<RiskFactors> RiskFactors {
            get; set;
        }

        public DbSet<RiskFactorsManager> RiskFactorsManagers {
            get; set;
        }

        public DbSet<RiskFactorsCategory> RiskFactorsCategories {
            get; set;
        }

        public DbSet<ClinicRegistryManager> ClinicRegistryManagers {
            get; set;
        }

        public DbSet<Visit> Visits {
            get; set;
        }
        /*
        public DbSet<HomeVisitManager> HomeVisitManagers {
            get; set;
        }*/

        public DbSet<VisitManager> VisitManagers {
            get; set;
        }


    }
}
