using System;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Threading;
using AutomationTestFramework.SantanderBank.Pages;

namespace AutomationTestFramework.SantanderBank.Test
{
    [TestFixture]
    public class AutoCreditPageTest
    {
        IWebDriver driver;
        AutoCreditPage autoPage;

        [OneTimeSetUp]
        public void Init()
        {
            driver = new ChromeDriver();
            autoPage = new AutoCreditPage(driver);
        }

        [SetUp]
        public void Initiliaze()
        {
            autoPage.Open();
        }

        [TearDown]
        public void EndTest()
        {

        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            driver.Close();
            driver.Quit();
        }

        [Test]
        public void OpenPageTest()
        {
            AutoCreditPage autoPage = new AutoCreditPage(driver);
            autoPage.Open();
        }

        [TestCase(0, ExpectedResult =50000)]
        [TestCase(50, ExpectedResult = 1030000)]
        [TestCase(100, ExpectedResult = 2000000)]
        public int MovePriceSliderTest(int percentage)
        {
            autoPage.MovePriceLoanSlider(percentage);
            return autoPage.PriceLoan;
        }

        [Test]
        public void checkSelectedLoanTypeRadioButton()
        {
            Assert.IsTrue(autoPage.isCheckedCarRadioButton());
        }

        [TestCase(250000, 200000, ExpectedResult = 201000)]
        [TestCase(1030000, 75000, ExpectedResult = 76000)]
        [TestCase(250000, 250000, ExpectedResult = 250000)]
        public int MoveOwnCapitalSlider(int loan, int own)
        {
            autoPage.PriceLoan = loan;
            autoPage.MoveOwnCapitalSlider(own);
            return autoPage.OwnCapital;
        }

        [TestCase(0, ExpectedResult = 4.9)]
        [TestCase(19999, ExpectedResult = 4.9)]
        [TestCase(20000, ExpectedResult = 4.45)]
        [TestCase(34999, ExpectedResult = 4.45)]
        [TestCase(35000, ExpectedResult = 3.9)]
        public double CheckRate(int own)
        {
            autoPage.OwnCapital = own;
            return autoPage.NominalPersentRate;
        }



    }
}
