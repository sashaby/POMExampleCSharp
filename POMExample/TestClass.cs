using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using POMExample.PageObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMExample
{
    public class TestClass
    {

        const string FFPATH = @"C:\\Program Files\\Mozilla Firefox\\firefox.exe";
        private IWebDriver driver;

        public TestClass()
        {
            //FirefoxOptions ffoptions = new FirefoxOptions();
            //ffoptions.BrowserExecutableLocation = FFPATH;
            //driver = new FirefoxDriver(ffoptions);
        }

        [SetUp]
        public void SetUp()
        {
            FirefoxOptions ffoptions = new FirefoxOptions();
            ffoptions.BrowserExecutableLocation = FFPATH;
            driver = new FirefoxDriver(ffoptions);
            driver.Manage().Window.Maximize();
        }
   
        [Test]
        public void SearchTextFromAboutPage()
        {
            HomePage home = new HomePage(driver);
            home.goToPage();
            AboutPage about = home.goToAboutPage();
            Assert.IsTrue(about.verifyAboutPageLoaded());
            //ResultPage result = about.search("selenium c#");
            //result.clickOnFirstArticle();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
  
    }
}
