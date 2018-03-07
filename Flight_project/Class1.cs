using Flight_project.Libraries;
using Flight_project.Test_Modules;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;

namespace Flight_project
{
    [TestFixture]
    public class Class1
    {
        public string Excel_file    = Utility_Libraries.XML_Read("ExcelPath", Local_Libraries.Path());
        public string XML_file      = Utility_Libraries.XML_Read("XMLPath", Local_Libraries.Path());
        DateTime Start_time         = DateTime.Now;
        public IWebDriver driver    = null;
        public ExtentTest test      = null;
        public ExtentReports extent = null;

        [OneTimeSetUp]
        public void SetUp()
        {
            string Browser = Utility_Libraries.XML_Read("browser", XML_file);

            driver = Utility_Libraries.getBrowser(Browser);
            extent = Utility_Libraries.Create_reporter(extent);
            test = extent.StartTest("SetUp");
            test.Log(LogStatus.Pass, "Setup create successfully");
        }

        [Test, Order(1)]
        public void Launch()
        {
            string URL = Utility_Libraries.XML_Read("url", XML_file);

            test = extent.StartTest("Launch");
            driver.Navigate().GoToUrl(URL);
            driver.Manage().Window.Maximize();
               
                if (driver.Url == URL.Trim())
                {
                    Utility_Libraries.PassReporter(driver,test, "Browser launch", "Browser launch successfully", "PASS");                  
                }               
                else
                {
                    Utility_Libraries.PassReporter(driver,test, "Browser launch", "Browser does not launch successfully", "FAIL");                   
                }
        }

        [Test, Order(2)]
        public void UserLogin()
        {
            string Username = Utility_Libraries.XML_Read("username", XML_file);
            string Password = Utility_Libraries.XML_Read("password", XML_file);

            test = extent.StartTest("Login");
            Login Log_obj = new Login(driver, test);
            Log_obj.UserLogin(Username, Password);
        }

        [Test, Order(3)]
        public void EnterFlightDetails()
        {
            string Passenger        = Utility_Libraries.XML_Read("Passenger", XML_file);
            string FromCity         = Utility_Libraries.XML_Read("Source", XML_file);
            string Tocity           = Utility_Libraries.XML_Read("Destination", XML_file);
            string Date             = Utility_Libraries.XML_Read("Date", XML_file);
            string Travelling_class = Utility_Libraries.XML_Read("Class", XML_file);

            test = extent.StartTest("EnterFlightDetails");
            EnterFlightDetails Fdetail_obj = new EnterFlightDetails(driver, test);
            Fdetail_obj.FlightDetails(Passenger, FromCity, Tocity, Date, Travelling_class);
        }

        [Test, Order(4)]
        public void SelectFlight()
        {
            test = extent.StartTest("SelectFlight");
            SelectFlight SFlight_obj = new SelectFlight(driver, test);
            SFlight_obj.Select_Flight();
        }

        [Test, Order(5)]
        public void EnterPassengerDetails()
        {
            string F_name = Utility_Libraries.XML_Read("Fname", XML_file);
            string L_name = Utility_Libraries.XML_Read("Lname", XML_file);
            string Food   = Utility_Libraries.XML_Read("Food", XML_file);

            test = extent.StartTest("EnterPassengerDetails");
            EnterPassengerDetails PDetails_obj = new EnterPassengerDetails(driver, test);
            PDetails_obj.PassengerDetails(F_name, L_name, Food);
        }

        [Test, Order(6)]
        public void Payment()
        {
            string Card_number = Utility_Libraries.XML_Read("Card_number", XML_file);

            test = extent.StartTest("Payment");
            Payment PayLog_obj = new Payment(driver, test);
            PayLog_obj.Pay_Logout(Card_number);
        }


        [TearDown]
        public void Result()
        {
            var Status = TestContext.CurrentContext.Result.Outcome.Status;
            var Message = TestContext.CurrentContext.Result.Message;
                if (Status == TestStatus.Failed)
                {
                    Utility_Libraries.PassReporter(driver,test, "Test fail", "Error message"+ Message, "FAIL");
                }
            extent.EndTest(test);
            extent.Flush();
        }

        [OneTimeTearDown]
        public void Close()
        {
            test = extent.StartTest("Close");
            DateTime End_time = DateTime.Now;
                Utility_Libraries.PassReporter(driver,test, "Total time taken by script", "Total time taken by script : " + End_time.Subtract(Start_time).ToString(), "PASS");
                Utility_Libraries.PassReporter(driver,test, "", "", "");
            driver.Close();
            driver.Quit();
        }
    }
}
