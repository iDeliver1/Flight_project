using Flight_project.Libraries;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flight_project.Test_Modules
{
    class Payment
    {
        public ExtentTest test;
        public IWebDriver driver;

        public Payment(IWebDriver driver, ExtentTest test)
        {
            this.test = test;
            this.driver = driver;
        }

        public void Pay_Logout(string Card_number)
        {
                try
                {
                Thread.Sleep(3000);
                    if (driver.FindElement(By.XPath("//img[contains(@src,'book.gif')]")).Displayed)
                    {
                        Utility_Libraries.PassReporter(driver,test, "Payment details", "Payment page is open", "PASS");
                    }
                }
                catch (Exception e)
                {
                    Console.Write(e.StackTrace);
                    Utility_Libraries.FailReporter(driver,test, "Payment details", "Payment page is not open : ", "FAIL" + e.StackTrace);
                }

            driver.FindElement(By.XPath("//input[@name='creditnumber']")).SendKeys(Card_number);
                Utility_Libraries.PassReporter(driver,test, "Payment details enter", "Payment details are enter", "PASS");           
            driver.FindElement(By.XPath("//input[@name='buyFlights']")).Click();
        }
    }
}
