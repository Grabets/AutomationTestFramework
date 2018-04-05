using OpenQA.Selenium;


namespace AutomationTestFramework.SantanderBank.Pages
{
    class VehicleCreditPage
    {
        private static IWebDriver driver;
        private static IWebElement mainLabel;

        public VehicleCreditPage (IWebDriver driverArg)
        {
            driver = driverArg;
            MainLabel = driver.FindElement(By.XPath("//div[@class='col-sm-12']/h1"));
        }

        public static IWebElement MainLabel
        {
            get
            {
                return mainLabel;
            }

            set
            {
                mainLabel = value;
            }
        }

        public string getMainLabel()
        {
            return MainLabel.Text;
        }

    }
}
