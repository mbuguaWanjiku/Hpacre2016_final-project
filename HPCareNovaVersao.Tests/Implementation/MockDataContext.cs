using System;
using System.Collections.Generic;
using System.Linq;

using DataLayer.Entities.DiagnosisEntities;

using DataLayer.Mocking;
using DataLayer.EntityFramework;
using DataLayer.Entities.TreatmentEntities;
using DataLayer.Entities.Visitas;
using DataLayer.Entities;
using DataLayer.Entities.MCDT;
using DataLayer.Entities.PatientEntities;

namespace HPCareNovaVersao.Tests.Implementation
{
    public static class MockDataContext
    {
        public static HPCareDBContext GetMockHPCareDBContext()
        {
            var CID_categories = new List<CID_Category>
            {
                new CID_Category {Description ="category1" ,CID_CategorID = 1},
                new CID_Category {Description ="category2",CID_CategorID = 2},
                new CID_Category {Description ="category3" ,CID_CategorID = 3}
            };
            var CID_DiseaseCodes = new List<CID_DiseaseCode>
            {
                new CID_DiseaseCode {CIDCategory = CID_categories.Where(x=>x.Description == "category1").First(),DiseaseCode ="code1" },
                new CID_DiseaseCode {CIDCategory = CID_categories.Where(x=>x.Description == "category1").First(),DiseaseCode ="code2" },
                new CID_DiseaseCode {CIDCategory = CID_categories.Where(x=>x.Description == "category2").First(),DiseaseCode ="code3" }
            };
            var CID_codes = new List<CIDCode>
             {
                new CIDCode {Version = "C10",CID_DiseaseCode = CID_DiseaseCodes.First(),CIDCOD_id = 1},
                new CIDCode {Version = "C10",CID_DiseaseCode = CID_DiseaseCodes.Last(),CIDCOD_id = 2}
             };
            var diseases = new List<Disease>
            {
                new Disease { Disease_end_date = DateTime.Now, Disease_start_date = DateTime.Now, Disease_is_active = false },
              //  new Disease { Disease_end_date = DateTime.Now, Disease_start_date = DateTime.Now, Disease_is_active = false }
             };
            var diagnoses = new List<Diagnosis>
            {

            };
            var drugFrequencies = new List<DrugFrequency>
            {
                new DrugFrequency {Description = "once",Frequency_id =1},
               new DrugFrequency {Description = "twice",Frequency_id =2},
               new DrugFrequency {Description = "thrice",Frequency_id =3}
            };
            var drugDosages = new List<Dosage>
            {
                new Dosage {Description = "1",Dosage_id =1},
                new Dosage {Description = "2" ,Dosage_id =2},
                new Dosage {Description = "3",Dosage_id =3},
                new Dosage {Description = "4",Dosage_id =4}
            };

            var drugs = new List<Drug>
            {
                new Drug {Drug_name = "drug1",Drug_id =1},
                new Drug {Drug_name = "drug2",Drug_id =2},
                new Drug {Drug_name = "drug3",Drug_id =3},
                new Drug {Drug_name = "drug4",Drug_id =4}
            };
            var drugCategories = new List<DrugCategory>
            {
                new DrugCategory {description = "drugCategory1",category_id = 1},
                new DrugCategory {description = "drugCategory2",category_id =2},
                new DrugCategory {description = "drugCategory3",category_id = 3},
                new DrugCategory {description = "drugCategory4",category_id = 4}
            };
            var drugAdministrations = new List<DrugAdministration>
            {
                new DrugAdministration {Description= "oral",Administration_Id =1},
                new DrugAdministration {Description= "Intravenous" ,Administration_Id =2},
                new DrugAdministration {Description= "Opthalmic" ,Administration_Id =3},
                new DrugAdministration {Description= "Otic" ,Administration_Id =4}

            };

            var treatmentCategories = new List<TreatmentCategory>
            { new TreatmentCategory {Description ="Category1",id =1},
              new TreatmentCategory {Description ="unset",id =2}
            };
            var treatmentTypes = new List<TreatmentType>
            {
                new TreatmentType  {Description= "type1",id =1,TreatmentCategory =treatmentCategories.FirstOrDefault()},
                new TreatmentType  {Description= "type2",id =2,TreatmentCategory =treatmentCategories.FirstOrDefault()},
                new TreatmentType  {Description= "unset",id =3,TreatmentCategory =treatmentCategories.LastOrDefault()},
            };
            var interventions = new List<Intervention> {
                new Intervention()
            };
            var users = new List<Users>()
            {
                new Patient {Name= "patient",User_id = 1},new Staff {Name ="clinic",User_id =2 }
            };
            var treatmentPlans = new List<TreatmentPlan>()
            {
                new TreatmentPlan { Patient_TreatmentPlan =  new Patient {Name= "patient2",User_id = 3}}
            };
            var drugIssuances = new List<DrugIssuance> { new DrugIssuance { } };
            var drugManagers = new List<DrugManager> { new DrugManager { } };
            var clinicRegistryManagers = new List<ClinicRegistryManager>
            {
                new ClinicRegistryManager {Clinic_patient = new Patient {Name = "patient" },Staff_doctor = new Staff {Name = "medical" } }
            };
            var mcdts = new List<MCDT> { new KFT() };
            var mcdtStaffManager = new List<MCDTStaffManager> { };
            var mcdtManagers = new List<MCDTManager> { };
            var labExams = new List<LabExams> { new LabExams { } };

            var dbContext = MoqUtilities.MockDbContext(
              CID_categories: CID_categories,
              CID_DiseaseCodes: CID_DiseaseCodes,
              CID_codes: CID_codes,
              diseases: diseases,
              drugs:drugs,
              drugCategories: drugCategories,
              drugDosages: drugDosages,
              drugFrequencies: drugFrequencies,
              drugAdministrations: drugAdministrations,
              drugIssuances: drugIssuances,
              diagnoses: diagnoses,
              drugManagers: drugManagers,
              clinicRegistryManagers: clinicRegistryManagers,
              mcdts: mcdts,
              mcdtStaffManager: mcdtStaffManager,
              mcdtManagers: mcdtManagers,
              treatmentPlans: treatmentPlans,
              users: users,
              treatmentTypes: treatmentTypes,
              treatmentCategories: treatmentCategories,
              interventions: interventions
              ).DbContext.Object;
            return dbContext;
        }
    }
}