using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Flight_project.Libraries
{
    class Utility_Libraries
    {
        public static IWebDriver driver;
        //public static string Folder_path = CreateFolder().ToString()+"/";

        public static string XML_Read(string Attribute_value, string File_name)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(File_name);
            XmlNodeList xAttvalur = xdoc.GetElementsByTagName(Attribute_value);
            return xAttvalur[0].InnerText.ToString();
        }

        public static IWebDriver getBrowser(String strBrowserName)
        {
            switch (strBrowserName.ToLower())
            {
                //launch in firefox
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                //------------------------------------------------
                //launch in chrome
                case "chrome":
                    driver = new ChromeDriver();
                    break;
                //------------------------------------------------		
                //launch in internetexplore
                case "internetexplore":
                    driver = new InternetExplorerDriver();
                    break;
                case "ie":
                    driver = new InternetExplorerDriver();
                    break;
                //------------------------------------------------
                default:
                    Console.WriteLine("Driver is not found " + strBrowserName);
                    break;
            }
            return driver;
        }

        public static ExtentReports Create_reporter(ExtentReports extent)
        {
            extent = new ExtentReports(@"E:\Sourabh_CSharp\repo\Flight_project\Flight_project\TestResults\TestReporter.html");
            return extent;
        }

        public static String TakeScreenShort(IWebDriver driver)
        {          
           string fileName = @"E:\Sourabh_CSharp\repo\Flight_project\Flight_project\ScreenShot\Screen" + TimeStamp() + ".Bmp";
           Console.Write(fileName);
           Screenshot screenShot = ((ITakesScreenshot)driver).GetScreenshot();
           screenShot.SaveAsFile(fileName, ScreenshotImageFormat.Bmp);
           return fileName;
        }

        public static String TimeStamp()
        {
            return DateTime.Now.ToString().Replace(":", "").Replace("/", "").Replace(" ","");
        }

        public static void PassReporter(IWebDriver driver,ExtentTest test,string Step_Description, string Expected,string Status)
        {
            if(Expected.Length!=0)
            {
                test.Log(LogStatus.Pass, Expected);
            }
            test.Log(LogStatus.Pass, test.AddScreenCapture(TakeScreenShort(driver)));
            Excel_Libraries.CreateExcel(Step_Description, Expected, Status, DateTime.Now.ToString());
        }

        public static void FailReporter(IWebDriver driver,ExtentTest test, string Step_Description, string Expected, string Status)
        {
            if (Expected.Length != 0)
            {
                test.Log(LogStatus.Fail, Expected);
            }
            test.Log(LogStatus.Fail, test.AddScreenCapture(TakeScreenShort(driver)));
            Excel_Libraries.CreateExcel(Step_Description, Expected, Status, DateTime.Now.ToString());
        }

        public static DirectoryInfo CreateFolder()
        {
            try
            {
                return System.IO.Directory.CreateDirectory(@"E:\Sourabh_CSharp\repo\Flight_project\Flight_project\TestResults\" + "Test_"+ TimeStamp());
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return null;
            
        }

        public static void Run_Result(IWebDriver driver, ExtentTest test, ExtentReports extent)
        {
            var Status = TestContext.CurrentContext.Result.Outcome.Status;
            var Message = TestContext.CurrentContext.Result.Message;
            if (Status == TestStatus.Failed)
            {
                Utility_Libraries.PassReporter(driver, test, "Test fail", "Error message" + Message, "FAIL");
            }
            extent.EndTest(test);
            extent.Flush();
        }
    }
}
