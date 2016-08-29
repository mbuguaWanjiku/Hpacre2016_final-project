using System;

using NUnit.Framework;
using DataLayer.EntityFramework;
using BusinessLayer.Implementation;
using DataLayer.Entities.TreatmentEntities;
using System.Linq;
using System.Collections.Generic;

namespace HPCareNovaVersao.Tests.Implementation
{
    [TestFixture]
    public class impMedicationTest : BaseTest
    {
        HPCareDBContext dbContext = MockDataContext.GetMockHPCareDBContext();

        [Test]
        public void SaveMedication()
        { //arrange
            ImpMedication medication = new ImpMedication(dbContext);
            //act

            DrugIssuance issuance = new DrugIssuance
            {
                IssuedDrug = dbContext.Drugs.ToList().FirstOrDefault()
                ,
                Medication_administration = dbContext.DrugAdministrations.FirstOrDefault(),
                Medication_dosage = dbContext.DrugDosages.FirstOrDefault(),
                Medication_end_date = DateTime.Now,
                Medication_start_date = DateTime.Now,
                Medication_frequency = dbContext.DrugFrequencies.ToList().FirstOrDefault(),
                Medication_manager = new DrugManager { }
            };
            test = extentReport.StartTest("Save Medication", "Insert a new prescription to the Drug manager end > start");
            int start = dbContext.DrugInssuances.ToList().Count;
            medication.savePrescribedMedication(new List<DrugIssuance> { issuance });
            int end = dbContext.DrugInssuances.ToList().Count;

            Assert.Greater(end, start);

            //assert

        }
        [Test]
        public void SaveMedicationFail()
        { //arrange
            ImpMedication medication = new ImpMedication(dbContext);
            //act

            DrugIssuance issuance = new DrugIssuance
            {
                IssuedDrug = dbContext.Drugs.ToList().FirstOrDefault()
                ,
                Medication_administration = dbContext.DrugAdministrations.FirstOrDefault(),
                Medication_dosage = dbContext.DrugDosages.FirstOrDefault(),
                Medication_end_date = DateTime.Now,
                Medication_start_date = DateTime.Now,
                Medication_frequency = dbContext.DrugFrequencies.ToList().FirstOrDefault(),
                Medication_manager = new DrugManager { }
            };
            test = extentReport.StartTest("Save Medication Fail test", "Insert a new prescription to the Drug manager end > start");
            int start = dbContext.DrugInssuances.ToList().Count;
            medication.savePrescribedMedication(new List<DrugIssuance> { issuance });
            int end = dbContext.DrugInssuances.ToList().Count;

            Assert.Greater(start, end);

            //assert

        }
    }
}
