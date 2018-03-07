using Flight_project.Libraries;
using Flight_project.Test_Modules;
using NUnit.Framework;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;

namespace Flight_project
{
    //[TestFixture]
    internal class Class2
    {

    //    public string Excel_file           = Utility_Libraries.XML_Read("ExcelPath", Local_Libraries.Path());
    //    public string XML_file             = Utility_Libraries.XML_Read("XMLPath", Local_Libraries.Path());
    //    DateTime Start_time                = DateTime.Now;
    //    public IWebDriver driver           = null;
    //    public ExtentTest test             = null;
    //    public ExtentReports extent        = null;

    //    [TestCase(1)]
    //    [TestCase(2)]
    //    public void Multiple_iteration_FlightRun(int Number)
    //    { 

    //        string Browser          = Excel_Libraries.CollectExcelSheet(Excel_file, "Browser", Number);
    //        string URL              = Excel_Libraries.CollectExcelSheet(Excel_file, "URL", Number);
    //        string Username         = Excel_Libraries.CollectExcelSheet(Excel_file, "Username", Number);
    //        string Password         = Excel_Libraries.CollectExcelSheet(Excel_file, "Password", Number);
    //        string Passenger        = Excel_Libraries.CollectExcelSheet(Excel_file, "Passenger", Number);
    //        string FromCity         = Excel_Libraries.CollectExcelSheet(Excel_file, "Source", Number);
    //        string Tocity           = Excel_Libraries.CollectExcelSheet(Excel_file, "Destination", Number);
    //        string Date             = Excel_Libraries.CollectExcelSheet(Excel_file, "Date", Number);
    //        string Travelling_class = Excel_Libraries.CollectExcelSheet(Excel_file, "Class", Number);
    //        string F_name           = Excel_Libraries.CollectExcelSheet(Excel_file, "Fname", Number);
    //        string L_name           = Excel_Libraries.CollectExcelSheet(Excel_file, "Lname", Number);
    //        string Food             = Excel_Libraries.CollectExcelSheet(Excel_file, "Food", Number);
    //        string Card_number      = Excel_Libraries.CollectExcelSheet(Excel_file, "Card_number", Number);

    //        //Launch the browser
    //        driver = Utility_Libraries.getBrowser(Browser);
    //        extent = Utility_Libraries.Create_reporter(extent);
    //        test = extent.StartTest("SetUp");
    //        test.Log(LogStatus.Pass, "Setup create successfully");

    //        //Launch the URL
    //        test = extent.StartTest("Launch");
    //        driver.Navigate().GoToUrl(URL);
    //        driver.Manage().Window.Maximize();

    //            if (driver.Url == URL.Trim()){
    //                Utility_Libraries.PassReporter(driver, test, "Browser launch", "Browser launch successfully", "PASS");
    //            }
    //            else {
    //                Utility_Libraries.PassReporter(driver, test, "Browser launch", "Browser does not launch successfully", "FAIL");
    //            }

    //        //Login
    //        test = extent.StartTest("Login");
    //        Login Log_obj = new Login(driver, test);
    //        Log_obj.UserLogin(Username, Password);
    //        Utility_Libraries.Run_Result(driver, test, extent);

    //        //Enter Flight details
    //        test = extent.StartTest("EnterFlightDetails");
    //        EnterFlightDetails Fdetail_obj = new EnterFlightDetails(driver, test);
    //        Fdetail_obj.FlightDetails(Passenger, FromCity, Tocity, Date, Travelling_class);
    //        Utility_Libraries.Run_Result(driver, test, extent);

    //        //Select flight
    //        test = extent.StartTest("SelectFlight");
    //        SelectFlight SFlight_obj = new SelectFlight(driver, test);
    //        SFlight_obj.Select_Flight();
    //        Utility_Libraries.Run_Result(driver, test, extent);

    //        //Enter Passenger details
    //        test = extent.StartTest("EnterPassengerDetails");
    //        EnterPassengerDetails PDetails_obj = new EnterPassengerDetails(driver, test);
    //        PDetails_obj.PassengerDetails(F_name, L_name, Food);
    //        Utility_Libraries.Run_Result(driver, test, extent);

    //        //Payment
    //        test = extent.StartTest("Payment");
    //        Payment PayLog_obj = new Payment(driver, test);
    //        PayLog_obj.Pay_Logout(Card_number);
    //        Utility_Libraries.Run_Result(driver, test, extent);

    //        test = extent.StartTest("Close");
    //        DateTime End_time = DateTime.Now;
    //        Utility_Libraries.PassReporter(driver, test, "Total time taken by script", "Total time taken by script : " + End_time.Subtract(Start_time).ToString(), "PASS");
    //        Utility_Libraries.PassReporter(driver, test, "", "", "");
    //    }

    //    [TearDown]
    //    public void Close()
    //    {            
    //        driver.Close();
    //        driver.Quit();
    //    }
    }
}
