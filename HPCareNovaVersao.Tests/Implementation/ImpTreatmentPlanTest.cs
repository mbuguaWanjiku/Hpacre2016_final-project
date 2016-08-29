using BusinessLayer.Implementation;
using DataLayer.EntityFramework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPCareNovaVersao.Tests.Implementation
{
    [TestFixture]
    public class ImpTreatmentPlanTest : BaseTest
    {

        HPCareDBContext dbContext = MockDataContext.GetMockHPCareDBContext();

        [Test]
        public void ExistTreatmentPlan_False()
        { //arrange
            ImpTreatmentPlan plan = new ImpTreatmentPlan(dbContext);
            //act             
            //assert
            test = extentReport.StartTest("Exist TreatmentPlan", "returns true if the patients is associated to a treatmentplan");
            Assert.IsFalse(plan.existPlan());

        }
        [Test]
        public void ExistTreatmentPlan()
        { //arrange
            ImpTreatmentPlan plan = new ImpTreatmentPlan(dbContext);
            //act             
            //assert
            test = extentReport.StartTest("Exist TreatmentPlan Retest", "returns true if the patients is associated to a treatmentplan");
            Assert.IsTrue(plan.existPlan());

        }
        [Test]
        public void AddIntervention()
        { //arrange
            ImpTreatmentPlan plan = new ImpTreatmentPlan(dbContext);
            //act             
            //assert
            test = extentReport.StartTest("Add new Intervention", "adds a new intervention to the existing treatmentplan");
            int start = dbContext.Interventions.ToList().Count;
            plan.AddIntervention();
            int end = dbContext.Interventions.ToList().Count;
            Assert.Greater(end, start);

        }
        [Test]
        public void DeleteIntervention()
        { //arrange
            ImpTreatmentPlan plan = new ImpTreatmentPlan(dbContext);
            //act             
            //assert
            test = extentReport.StartTest("Delete Intervention", "Assert true for successful delete");
            int start = dbContext.Interventions.ToList().Count;
            plan.AddIntervention();
            dbContext.Interventions.FirstOrDefault().Intervention_id = 1;
            plan.DeleteIntervention(1);
            int end = dbContext.Interventions.ToList().Count;
            Assert.GreaterOrEqual(end, start);

        }
        [Test]
        public void DeleteIntervention_FailTest()
        { //arrange
            ImpTreatmentPlan plan = new ImpTreatmentPlan(dbContext);
            //act             
            //assert
            test = extentReport.StartTest("Delete intervention -Fail test", "Test fails because the list of interventions  is empty");
            int start = dbContext.Interventions.ToList().Count;

            dbContext.Interventions.FirstOrDefault().Intervention_id = 1;
            plan.DeleteIntervention(1);
            int end = dbContext.Interventions.ToList().Count;
            Assert.GreaterOrEqual(end, start);

        }
    }
}
