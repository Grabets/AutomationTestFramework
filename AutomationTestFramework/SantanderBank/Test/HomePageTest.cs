using AutomationTestFramework.SantanderBank.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace AutomationTestFramework.SantanderBank.Test
{
    
    public class HomePageTest
    {
        IWebDriver driver;

        [SetUp]
        public void Initiliaze()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void OpenHomePageTest()
        {
            HomePage homePage = new HomePage(driver);
            homePage.OpenUrl();
            homePage.ClickOnVehicleCreditButton();
        }

        [Test]
        public void OpenVehicleCreditPageTest()
        {
            HomePage homePage = new HomePage(driver);
            homePage.OpenUrl();
            VehicleCreditPage vehicleCreditPage = homePage.ClickOnVehicleCreditButton();
            Assert.AreEqual(vehicleCreditPage.getMainLabel(), "Billån og fritidslån");
        }

        [TearDown]
        public void EndTest()
        {
            Thread.Sleep(1000);
            driver.Close();
        }
    }
}
