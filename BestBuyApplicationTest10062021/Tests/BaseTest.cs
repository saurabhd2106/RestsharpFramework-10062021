using AventStack.ExtentReports;
using BestBuyApplicationTest.Request.Product;
using BestBuyApplicationTest.Utils;
using CommonLibs.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BestBuyApplicationTest.Tests
{
    [TestClass]
    public class BaseTest
    {


        private string baseUrl;

        private int portNumber;

        static string solutionDirectory;

        static string currentProjectDirectory;

        static IConfiguration Configuration;

        internal static ExtentReportUtils Reporter;

        static string executionStartTime;

        private string endpointUrl;

        internal RequestFactory productRequestFactory;

        public TestContext TestContext { get; set; }

        [AssemblyInitialize]
        public static void Presetup(TestContext TestContext)
        {
            initializeTestExecutionStartTime();

            getDirectoryInfo();

            initializeConfiguration();

            initializeReports();

        }


        [TestInitialize]
        public void Setup()
        {
            Reporter.CreateATestCase("Setup" , "The setup is done before every testcase");

            settingUpEndointpointUrl();

            initializeRequestFactory();
            

        }

       

        [TestCleanup]
        public void PostTextExecution()
        {
            var testOutcome = TestContext.CurrentTestOutcome;

            if ((testOutcome == UnitTestOutcome.Failed) || (testOutcome == UnitTestOutcome.Aborted))
            {
                Reporter.AddLogs(Status.Fail, "One or more steps failed");
            } else if(TestContext.CurrentTestOutcome == UnitTestOutcome.NotRunnable)
            {
                Reporter.AddLogs(Status.Skip, "One or more steps are not runnable");
            }
        }

        [AssemblyCleanup]
        public static void PostCleanup()
        {
            endReporter();

            
        }

        private static void endReporter()
        {
            Reporter.FlushReport();
        }

        private static void initializeTestExecutionStartTime()
        {
            executionStartTime = DateTime.Now.ToString("MM-dd-yyyy-HH-mm-ss");
        }


        private static void initializeReports()
        {
            string reportFilename = $"{currentProjectDirectory}/Reports/{executionStartTime}/report.html";

            Reporter = new ExtentReportUtils(reportFilename);
        }

        private static void initializeConfiguration()
        {
            string configFilePath = $"{currentProjectDirectory}/Config/appSettings.json";

            Configuration = new ConfigurationBuilder().AddJsonFile(configFilePath).Build();
        }

        private static void getDirectoryInfo()
        {
            string currentWorkingDirectory = Environment.CurrentDirectory;

            currentProjectDirectory = Directory.GetParent(currentWorkingDirectory).Parent.Parent.FullName;

            solutionDirectory = Directory.GetParent(currentProjectDirectory).FullName;
        }

        private void initializeRequestFactory()
        {
            productRequestFactory = new RequestFactory(endpointUrl);
        }

        private void settingUpEndointpointUrl()
        {
            baseUrl = Configuration["environment:baseUrl"];

            Reporter.AddLogs(Status.Info, "Base URL " + baseUrl);

            portNumber = int.Parse(Configuration["environment:portNumber"]);

            Reporter.AddLogs(Status.Info, "Port Number " + portNumber);

            endpointUrl = $"{baseUrl}:{portNumber}{Routes.PRODUCT}";

            Reporter.AddLogs(Status.Info, "Endpoint URL " + endpointUrl);
        }
    }
}
