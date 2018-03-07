using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flight_project.Libraries;
using NUnit.Framework;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;

namespace Flight_project.Test_Modules
{
    class Login
    {
        public ExtentTest test;
        public IWebDriver driver;

        public Login(IWebDriver driver, ExtentTest test)
        {
            this.test = test;
            this.driver = driver;
        }

        public void UserLogin(string Username, string Password)
        {
            try
            {
               if( driver.FindElement(By.XPath("//img[@alt='Mercury Tours']")).Displayed)
                {
                    Utility_Libraries.PassReporter(driver, test, "Login", "Login page loaded", "PASS");
                }
            }
            catch(Exception e)
            {
                Utility_Libraries.PassReporter(driver, test, "Login", "Login page is not loaded", "FAIL");
            }
            driver.FindElement(By.XPath("//input[@name='userName']")).SendKeys(Username);
            driver.FindElement(By.XPath("//input[@name='password']")).SendKeys(Password);
                Utility_Libraries.PassReporter(driver,test, "Enter user credentials", "User credentials are enter. Username is : " + Username + " Password is : " + Password, "PASS");
            driver.FindElement(By.XPath("//input[@name='login']")).Click();
        }
    }
}
