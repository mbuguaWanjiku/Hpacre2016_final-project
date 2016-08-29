using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using BusinessLayer.Implementation;

using DataLayer.Entities.DiagnosisEntities;

using DataLayer.Mocking;
using NUnit.Framework;
using HPCareNovaVersao.Tests.Implementation;
using RelevantCodes.ExtentReports;
using DataLayer.EntityFramework;
//using PresentationLayer.Controllers;

namespace HPCareNovaVersao.Tests.Controllers
{
    [TestFixture]
    [Parallelizable]
    public class impDiagnosisTesting : BaseTest
    {
        HPCareDBContext dbContext = MockDataContext.GetMockHPCareDBContext();

        [Test]
        public void SaveDiagnosis()
        { //arrange
            impDiagnosis diagnosis = new impDiagnosis(dbContext);
            //act
            int start = dbContext.Diagnoses.ToList().Count;
            List<CID_DiseaseCode> classification = dbContext.CID_DiseaseCodes.ToList();
            diagnosis.SaveDiagnosis(classification);
            int end = dbContext.Diagnoses.ToList().Count;
            //assert
            test = extentReport.StartTest("Save Diagnosis", "Insert three new CID CODES, diagnosi size increased by three end > start");
            Assert.Greater(end, start);
            Console.WriteLine("Save diagnosis");
        }
        [Test]
        public void ShouldReturnDeactivated()
        {
            //HPCareDBContext dbContext = MockDataContext.GetMockHPCareDBContext();
            impDiagnosis diagnosis = new impDiagnosis(dbContext);
            Disease disease = dbContext.Diseases.FirstOrDefault();

            string results = diagnosis.DeactivateDisease(disease);
            string expected = "Disease Deactivated";

            //assert
            test = extentReport.StartTest("Deactivate Diagnosis ", "Assert true diagnosis size reduced by one ");
            Assert.AreEqual(expected, results);
            Console.WriteLine("should return deactivated");

        }
        [Test]
        public void ShouldReturnDeactivatedFail()
        {
            //HPCareDBContext dbContext = MockDataContext.GetMockHPCareDBContext();
            impDiagnosis diagnosis = new impDiagnosis(dbContext);
            Disease disease = dbContext.Diseases.FirstOrDefault();

            string results = diagnosis.DeactivateDisease(disease);
            string expected = "null";

            //assert
            test = extentReport.StartTest("Save Diagnosis-failTest", "expect null");
            Assert.AreEqual(expected, results);



        }
        [Test]
        public void SaveEmptyListOfCID()
        { //arrange
            impDiagnosis diagnosis = new impDiagnosis(dbContext);
            //act
            int start = dbContext.Diagnoses.ToList().Count;
            List<CID_DiseaseCode> classification = new List<CID_DiseaseCode>();
            diagnosis.SaveDiagnosis(classification);
            int end = dbContext.Diagnoses.ToList().Count;
            //assert
            test = extentReport.StartTest("Save empty Diagnosis", "should fail because the list is empty end == start");
            Assert.Greater(end, start);

            Console.WriteLine("testing null instance");
        }

        [Test]
        public void ShouldReturnInvalidData()
        { //arrange
            impDiagnosis diagnosis = new impDiagnosis(dbContext);
            //act
            Disease disease = null;
            string results = diagnosis.DeactivateDisease(disease);
            string expected = "Invalid data";
            //assert
            test = extentReport.StartTest("Save Diagnosis null instance", "Test empty instance ");
            Assert.AreEqual(expected, results);
            Console.WriteLine("test invalid data");
        }


    }
}
