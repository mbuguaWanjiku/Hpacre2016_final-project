using NUnit.Framework;
using NUnit.Framework.Interfaces;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPCareNovaVersao.Tests.Implementation
{
    public class BaseTest
    {
        protected ExtentTest test;
        protected ExtentReports extentReport = ExtentManager.getInstance();

       
        [TearDown]
        public void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("<pre>{0}</pre>", TestContext.CurrentContext.Result.StackTrace);
            var errorMesaage = TestContext.CurrentContext.Result.Message;


            LogStatus logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = LogStatus.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = LogStatus.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = LogStatus.Skip;
                    break;
                default:
                    logstatus = LogStatus.Pass;
                    break;
            }

            test.Log(logstatus, "Test ended with " + logstatus + stacktrace + "\n \n \n" + errorMesaage);
            //     test.Log(LogStatus.Info, "screenshot -" + test.AddScreenCapture("E:\\HPcareTestReport\\images\\addInt.png"));
            extentReport.EndTest(test);
            extentReport.Flush();
        }
    }
}

