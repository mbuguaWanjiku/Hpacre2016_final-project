using System;

using DataLayer.EntityFramework;
using NUnit.Framework;
using System.Collections.Generic;
using BusinessLayer.Implementation;
using System.Linq;
using DataLayer.Entities.MCDT;

namespace HPCareNovaVersao.Tests.Implementation
{
    [TestFixture]
    public class impMCDTTest : BaseTest
    {
        HPCareDBContext dbContext = MockDataContext.GetMockHPCareDBContext();
        [Test]
        public void SaveMCDT()
        {
            { //arrange
                List<string> mcdts = new List<string> { "KFT", "LFT", "WBCS" };
                ImpMCDTs impMcdt = new ImpMCDTs(dbContext);
                //assert
                test = extentReport.StartTest("Save MCDT", "Insert new lab exam");
                impMcdt.SavePrescribedMCDT(mcdts);
                int end = dbContext.MCDTs.ToList().Count;
                Assert.Greater(end, 0);
            }
        }
        [Test]
        public void SaveMCDTFail_Retest()
        {
            { //arrange
                List<string> mcdts = new List<string>();
                ImpMCDTs impMcdt = new ImpMCDTs(dbContext);
                //assert
                test = extentReport.StartTest("Save MCDT -Retest fail test", "Insert empty list lab exam");
                impMcdt.SavePrescribedMCDT(mcdts);
                int end = dbContext.MCDTs.ToList().Count;
                Assert.Greater(end, 2);
            }
        }

    }
}

