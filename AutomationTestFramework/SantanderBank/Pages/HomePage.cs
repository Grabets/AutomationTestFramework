using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTestFramework.SantanderBank.Pages
{
    class HomePage
    {
        private String url = "https://www.santanderconsumer.no/";

        private static IWebDriver driver;
        private static IWebElement vehicleCreditButton;
        WebDriverWait wait;

        public HomePage(IWebDriver driverArg)
        {
            driver = driverArg;
        }

        public void OpenUrl()
        {
            driver.Navigate().GoToUrl(url);
            vehicleCreditButton = driver.FindElement(By.XPath("//a/span[text()='Søk om lån']"));
        }

        public VehicleCreditPage ClickOnVehicleCreditButton()
        {
            vehicleCreditButton.Click();
            return new VehicleCreditPage(driver);
        }
    }
}
