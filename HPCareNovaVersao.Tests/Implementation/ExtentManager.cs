using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPCareNovaVersao.Tests.Implementation
{
    public class ExtentManager
    {
        //singleton to maintain a single report
        private static ExtentReports extentReport;
        public static ExtentReports getInstance()
        {
            if (extentReport == null)
            {
                extentReport = new ExtentReports(Directory.GetCurrentDirectory()+"report.html", false);
                extentReport.LoadConfig("E:\\HPcareTestReport\\extent-config.xml");
                extentReport.AddSystemInfo("Selenium Version", "2.53.1")
               .AddSystemInfo("Envioroment", "Production")
               .AddSystemInfo("Tester", "John Mbugua").AddSystemInfo("Programmers", "John and Márcia")
               .AddSystemInfo("Supervisor", "Jose sena").
                AddSystemInfo("Project Title", "PFC IPS 2016 HPCare");
            }
            return extentReport;
        }
    }
}
