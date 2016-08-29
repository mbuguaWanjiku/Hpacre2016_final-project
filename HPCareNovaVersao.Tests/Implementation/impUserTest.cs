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
    public class impUserTest : BaseTest
    {
        HPCareDBContext dbContext = MockDataContext.GetMockHPCareDBContext();

        [Test]
        public void UserExist()
        { //arrange
            ImpTreatmentPlan plan = new ImpTreatmentPlan(dbContext);
            //act             
            //assert
            test = extentReport.StartTest("Search User-fail test Retest", "searching a non existing user");
            Assert.IsTrue(plan.existPlan());

        }
        [Test]
        public void AddUser()
        { //arrange
            ImpTreatmentPlan plan = new ImpTreatmentPlan(dbContext);
            //act             
            //assert
            test = extentReport.StartTest("Add new User", "adds a new User");
            int start = dbContext.Interventions.ToList().Count;
            plan.AddIntervention();
            int end = dbContext.Interventions.ToList().Count;
            Assert.Greater(end, start);

        }
        [Test]
        public void DeleteUser()
        { //arrange
            ImpTreatmentPlan plan = new ImpTreatmentPlan(dbContext);
            //act             
            //assert
            test = extentReport.StartTest("Delete User", "deleting an existing user");
            int start = dbContext.Interventions.ToList().Count;
            plan.AddIntervention();
            dbContext.Interventions.FirstOrDefault().Intervention_id = 1;
            plan.DeleteIntervention(1);
            int end = dbContext.Interventions.ToList().Count;
            Assert.GreaterOrEqual(end, start);

        }
        [Test]
        public void DeleteUser_FailTest()
        { //arrange
            ImpTreatmentPlan plan = new ImpTreatmentPlan(dbContext);
            //act             
            //assert
            test = extentReport.StartTest("Delete User -Fail test", "Test fails because the user don´t exist");
            int start = dbContext.Interventions.ToList().Count;

            dbContext.Interventions.FirstOrDefault().Intervention_id = 1;
            plan.DeleteIntervention(1);
            int end = dbContext.Interventions.ToList().Count;
            Assert.GreaterOrEqual(end, start);

        }
    }
}

