using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibs.Utils
{
    public class ExtentReportUtils
    {

        private ExtentReports extentReports;
        private ExtentHtmlReporter htmlReporter;
        private ExtentTest extentTest;


        public ExtentReportUtils(string filename)
        {
            _ = filename.Trim();

            extentReports = new ExtentReports();
            htmlReporter = new ExtentHtmlReporter(filename);

            extentReports.AttachReporter(htmlReporter);

        }

        public void CreateATestCase(string testcasename, string description)
        {
            extentTest = extentReports.CreateTest(testcasename, description);
        }

        public void AddLogs(Status status, string message)
        {

            extentTest.Log(status, message);

        }

        public void FlushReport()
        {
            extentReports.Flush();
        }
    }
}
