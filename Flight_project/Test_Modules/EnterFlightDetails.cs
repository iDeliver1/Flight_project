using Flight_project.Libraries;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_project.Test_Modules
{
    class EnterFlightDetails
    {
        public ExtentTest test;
        public IWebDriver driver;

        public EnterFlightDetails(IWebDriver driver, ExtentTest test)
        {
            this.test = test;
            this.driver = driver;
        }

        public void FlightDetails(string Passenger, string Fromcity, string Tocity, string Date, string Travelling_class)
        {
                try
                {
                    if (driver.FindElement(By.XPath("//input[@value='oneway']")).Displayed)
                    {
                        Utility_Libraries.PassReporter(driver,test, "Login", "Login successfully", "PASS");
                    }
                }
                catch (Exception e)
                {
                    Console.Write(e.StackTrace);
                    Utility_Libraries.FailReporter(driver,test, "Login", "Login unsuccessfully : "+ e.StackTrace, "FAIL");
                }

            char[] splitchar = { '-' };
            string[] DATE;

            driver.FindElement(By.XPath("//input[@value='oneway']")).Click();
            SelectElement passenger = new SelectElement(driver.FindElement(By.XPath("//select[@name='passCount']")));
            passenger.SelectByText(Passenger);
            SelectElement FromCity = new SelectElement(driver.FindElement(By.XPath("//select[@name='fromPort']")));
            FromCity.SelectByValue(Fromcity);
            SelectElement ToCity = new SelectElement(driver.FindElement(By.XPath("//select[@name='fromPort']")));
            ToCity.SelectByValue(Tocity);
            DATE = Date.Split(splitchar);
            SelectElement Month = new SelectElement(driver.FindElement(By.XPath("//select[@name='fromMonth']")));
            Month.SelectByValue(DATE[0]);
            SelectElement Day = new SelectElement(driver.FindElement(By.XPath("//select[@name='fromDay']")));
            Day.SelectByValue(DATE[0]);
            IList<IWebElement> lst = driver.FindElements(By.XPath("//input[@type='radio'][@name='servClass']"));
                foreach (IWebElement Item in lst)
                {
                    if (Item.Equals(Travelling_class))
                    {
                        Item.Click();
                    }
                }
                Utility_Libraries.PassReporter(driver,test, "Travelling details", "Travelling details will enter", "PASS");
            driver.FindElement(By.XPath("//input[@name='findFlights']")).Click();
        }
    }
}
