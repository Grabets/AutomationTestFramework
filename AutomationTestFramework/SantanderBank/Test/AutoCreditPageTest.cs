using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Threading;
using AutomationTestFramework.SantanderBank.Pages;

namespace AutomationTestFramework.SantanderBank.Test
{
    
    public class AutoCreditPageTest
    {
        IWebDriver driver;
        AutoCreditPage autoPage;

        [SetUp]
        public void Initiliaze()
        {
            driver = new ChromeDriver();
            autoPage = new AutoCreditPage(driver);
            autoPage.Open();
        }

        [TearDown]
        public void EndTest()
        {
            Thread.Sleep(1000);
            driver.Close();
        }

        [Test]
        public void OpenPageTest()
        {
            AutoCreditPage autoPage = new AutoCreditPage(driver);
            autoPage.Open();
        }

        [Test]
        public void MovePriceSliderTest()
        {

            autoPage.MovePriceSlider(50);
        }



    }
}
