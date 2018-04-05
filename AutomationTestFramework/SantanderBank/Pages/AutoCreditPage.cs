using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;

namespace AutomationTestFramework.SantanderBank.Pages
{
    class AutoCreditPage
    {
        private String url = "https://www.santanderconsumer.no/billan-og-fritidslan/sok-billan/";
        private String carPriceElementXPath = "//div[@class='col-sm-4 slider-input-container'][1]//div[@class='calculator-slider ui-slider ui-slider-horizontal ui-widget ui-widget-content ui-corner-all']";
        private String carPriceSliderXPath = "//div[@class='col-sm-4 slider-input-container'][1]//div[@class='calculator-slider ui-slider ui-slider-horizontal ui-widget ui-widget-content ui-corner-all']/span";
        private static IWebDriver driver;
        private static IWebElement carPriceElement;
        private static IWebElement carPriceSlider;

        public AutoCreditPage (IWebDriver driverArg)
        {
            driver = driverArg;
        }

        public void Open()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            
            carPriceElement = driver.FindElement(By.XPath(carPriceElementXPath));
            carPriceSlider = driver.FindElement(By.XPath(carPriceSliderXPath));
        }

        public void MovePriceSlider(Double persentPosition)
        {
            int widthOfElement = carPriceElement.Size.Width;
            int dx = (int) (widthOfElement * (persentPosition / 100)) + (carPriceSlider.Location.X - carPriceElement.Location.X);
            Console.WriteLine(widthOfElement+"   asd   "+dx);
            Console.WriteLine("Slider X= "+carPriceSlider.Location.X+ "Element X ="+carPriceElement.Location.X);
            Console.WriteLine((carPriceSlider.Location.X - carPriceElement.Location.X));
            Actions builder = new Actions(driver);
            builder.MoveToElement(carPriceSlider).Click().DragAndDropToOffset(carPriceSlider, dx, 0).Build().Perform();
            Console.WriteLine(carPriceElement.FindElement(By.CssSelector("[style^=w]")).GetAttribute("style"));

        }

    }
}
