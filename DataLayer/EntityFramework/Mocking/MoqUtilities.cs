using System.Collections.Generic;
using Coderful.EntityFramework.Testing.Mock;
using Moq;
using DataLayer.Entities;
using DataLayer.Entities.DiagnosisEntities;
using DataLayer.EntityFramework;
using DataLayer.Entities.TreatmentEntities;
using DataLayer.Entities.Visitas;
using DataLayer.Entities.MCDT;
using DataLayer.Entities.PatientEntities;

namespace DataLayer.Mocking
{
    public static class MoqUtilities
    {
        public static MockedDbContext<HPCareDBContext> MockDbContext(
          
           /***************diagnosis Entities************/
           IList<CID_Category> CID_categories = null,
           IList<CID_DiseaseCode> CID_DiseaseCodes = null,
           IList<CIDCode> CID_codes = null,
           IList<Disease> diseases = null,
           IList<Diagnosis> diagnoses = null,
           /*************TreatmentEntities************************/
           IList<Dosage> drugDosages = null,
           IList<Drug> drugs = null,
           IList<DrugCategory> drugCategories = null,
           IList<DrugFrequency> drugFrequencies = null,
           IList<DrugAdministration> drugAdministrations = null,
           IList<DrugIssuance> drugIssuances = null,
           IList<DrugManager> drugManagers = null,

            /****************************************************/
           IList<ClinicRegistryManager> clinicRegistryManagers = null,
           IList<MCDT> mcdts = null,
           IList<MCDTStaffManager> mcdtStaffManager = null,
           IList<MCDTManager> mcdtManagers = null,
           IList<TreatmentPlan> treatmentPlans = null,
           IList<Users> users = null,
           IList<TreatmentType> treatmentTypes = null,
           IList<TreatmentCategory> treatmentCategories = null,
           IList<Intervention> interventions = null

            )
        {
            var mockContext = new Mock<HPCareDBContext>();

            // Create the DbSet objects.
            var dbSets = new object[]
            {
            mockContext.MockDbSet( CID_categories, (objects, cid_Category) => cid_Category.CID_CategorID == (int)objects[0]),
            mockContext.MockDbSet(  CID_DiseaseCodes, (objects, cid_DiseaseCode) => cid_DiseaseCode.DiseaseCID_ID == (int)objects[0]),
            mockContext.MockDbSet( CID_codes, (objects, cidCode) =>cidCode.CIDCOD_id== (int)objects[0]),
            mockContext.MockDbSet( diseases, (objects, disease) =>disease.Disease_id== (int)objects[0]),
            mockContext.MockDbSet( drugDosages, (objects, drugDosage) =>drugDosage.Dosage_id== (int)objects[0]),
            mockContext.MockDbSet( drugFrequencies, (objects, drugFrequency) =>drugFrequency.Frequency_id == (int)objects[0]),
            mockContext.MockDbSet( drugAdministrations, (objects, drugAdministration) =>drugAdministration.Administration_Id== (int)objects[0]),
            mockContext.MockDbSet( drugIssuances, (objects, drugIssuance) =>drugIssuance.DrugIssuance_id== (int)objects[0]),
            mockContext.MockDbSet( drugManagers, (objects, drugManager) =>drugManager.MedicationManager_id== (int)objects[0]),
            mockContext.MockDbSet( diagnoses, (objects, diagnosis) =>diagnosis.Diagnosis_id== (int)objects[0]),
            mockContext.MockDbSet( drugs, (objects, drug) =>drug.Drug_id== (int)objects[0]),
            mockContext.MockDbSet( drugCategories, (objects, drugCategory) =>drugCategory.category_id== (int)objects[0]),
            mockContext.MockDbSet( clinicRegistryManagers, (objects, clinicRegistryManager) =>clinicRegistryManager.ClinicRegistryManagerId== (int)objects[0]),
            mockContext.MockDbSet( mcdts, (objects, mcdt) =>mcdt.MCDT_ID== (int)objects[0]),
            mockContext.MockDbSet( mcdtStaffManager, (objects, mcdtStaff) =>mcdtStaff.MCDTStaffManager_id== (int)objects[0]),
            mockContext.MockDbSet( mcdtManagers, (objects, mcdtManager) =>mcdtManager.MCDTManager_id== (int)objects[0]),
            mockContext.MockDbSet(treatmentPlans, (objects, treatmentPlan) =>treatmentPlan.Treatment_id== (int)objects[0]),
            mockContext.MockDbSet(users, (objects, user) =>user.User_id== (int)objects[0]),
            mockContext.MockDbSet(treatmentTypes, (objects, treatmentType) =>treatmentType.id== (int)objects[0]),
            mockContext.MockDbSet(treatmentCategories, (objects, category) =>category.id== (int)objects[0]),
            mockContext.MockDbSet(interventions, (objects, intervention) =>intervention.Intervention_id== (int)objects[0])
            };

            return new MockedDbContext<HPCareDBContext>(mockContext, dbSets);
        }
    }
}