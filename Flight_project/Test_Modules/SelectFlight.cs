using Flight_project.Libraries;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_project.Test_Modules
{
    class SelectFlight
    {
        public ExtentTest test;
        public IWebDriver driver;

        public SelectFlight(IWebDriver driver, ExtentTest test)
        {
            this.test = test;
            this.driver = driver;
        }

        public void Select_Flight()
        {
                try
                {
                    if (driver.FindElement(By.XPath("//img[contains(@src,'selectflight.gif')]")).Displayed)
                    {
                        Utility_Libraries.PassReporter(driver,test, "Flight select", "Flight select page is open", "PASS");
                    }
                }
                catch (Exception e)
                {
                    Console.Write(e.StackTrace);
                    Utility_Libraries.FailReporter(driver,test, "Travelling details", "Flight select page is not open: " + e.StackTrace, "FAIL");
                }
            test.Log(LogStatus.Pass, "Oneway Flight is selected");
            driver.FindElement(By.XPath("//input[@name='reserveFlights']")).Click();
        }
    }
}
