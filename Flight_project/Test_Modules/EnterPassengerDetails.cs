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
    class EnterPassengerDetails
    {
        public ExtentTest test;
        public IWebDriver driver;

        public EnterPassengerDetails(IWebDriver driver, ExtentTest test)
        {
            this.test = test;
            this.driver = driver;
        }

        public void PassengerDetails(string F_name, string L_name, string Food)
        {
                try
                {
                    if (driver.FindElement(By.XPath("//img[contains(@src,'book.gif')]")).Displayed)
                    {
                        Utility_Libraries.PassReporter(driver,test, "Passenger details", "Passenger details page is open", "PASS");
                    }
                }
                catch (Exception e)
                {
                    Console.Write(e.StackTrace);
                    Utility_Libraries.FailReporter(driver,test, "Passenger details", "Passenger details page is not open : ", "FAIL"+ e.StackTrace);
                }

            driver.FindElement(By.XPath("//input[@name='passFirst0']")).SendKeys(F_name);
            test.Log(LogStatus.Pass, "Passenger first name is enter");
            driver.FindElement(By.XPath("//input[@name='passLast0']")).SendKeys(L_name);
            test.Log(LogStatus.Pass, "Passenger last name is enter");
            SelectElement meal = new SelectElement(driver.FindElement(By.XPath("//select[@name='pass.0.meal']")));
            meal.SelectByText(Food);
            Utility_Libraries.PassReporter(driver,test, "Passenger details", "Food : "+ Food+" First name : "+ F_name+" Last name : "+L_name, "PASS");
        }
    }
}
