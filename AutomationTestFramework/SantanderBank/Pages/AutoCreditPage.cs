using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutomationTestFramework.SantanderBank.Pages
{
    class AutoCreditPage
    {
        private String url = "https://www.santanderconsumer.no/billan-og-fritidslan/sok-billan/";
        private String carPriceElementXPath = "//div[@class='col-sm-4 slider-input-container'][1]//div[@class='calculator-slider ui-slider ui-slider-horizontal ui-widget ui-widget-content ui-corner-all']";
        private String ownCapitalElementXPath = "//div[@class='col-sm-4 slider-input-container'][2]//div[@class='calculator-slider ui-slider ui-slider-horizontal ui-widget ui-widget-content ui-corner-all']";
        private static IWebDriver driver;
        private static IWebElement carPriceLoanElement;
        private static IWebElement carPriceLoanSlider;
        private static IWebElement ownCapitalElement;
        private static IWebElement ownCapitalSlider;
        private static IWebElement resultCredit;


        public AutoCreditPage (IWebDriver driverArg)
        {
            driver = driverArg;
        }

        public void Open()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            
            carPriceLoanElement = driver.FindElement(By.XPath(carPriceElementXPath));
            carPriceLoanSlider = driver.FindElement(By.XPath(carPriceElementXPath+"/span"));
            ownCapitalElement = driver.FindElement(By.XPath(ownCapitalElementXPath));
            ownCapitalSlider = driver.FindElement(By.XPath(ownCapitalElementXPath + "/span"));
            //resultCredit = driver.FindElement(By.XPath("//p/strong/font"));


        }

        public void MovePriceLoanSlider(Double persentPosition)
        {
            int widthOfRow = driver.FindElement(By.XPath(carPriceElementXPath+"/div")).Size.Width;
            int widthOfElement = carPriceLoanElement.Size.Width;
            int dx = (int) (widthOfElement * (persentPosition / 100)) - widthOfRow-1;
            Actions builder = new Actions(driver);
            builder.MoveToElement(carPriceLoanSlider).Click().DragAndDropToOffset(carPriceLoanSlider, dx, 0).Build().Perform();
        }

        public void MoveOwnCapitalSlider(int ownCapital)
        {
            Double persentOfPriceLoan = (ownCapital*1.0 / PriceLoan)*100;
            int widthOfRow = driver.FindElement(By.XPath(ownCapitalElementXPath + "/div")).Size.Width;
            int widthOfElement = ownCapitalElement.Size.Width;
            int dx = (int)( widthOfElement * (persentOfPriceLoan / 100) - widthOfRow );
            Console.WriteLine("PriceLoan= {0} ownCapital={1} pers= {2}", PriceLoan, ownCapital, persentOfPriceLoan);
            Console.WriteLine("widthofrow= {0} widthofElement= {1} dx= {2}", widthOfRow, widthOfElement,dx);
            Actions builder = new Actions(driver);
            builder.MoveToElement(ownCapitalSlider).Click().DragAndDropToOffset(ownCapitalSlider, dx, 0).Build().Perform();
                Console.WriteLine(OwnCapital);
        }

        public double NominalPersentRate
        {
            get
            {
                List<IWebElement> nomRentList = driver.FindElements(By.XPath("//li[@class='form-field input-wrapper']")).ToList();
                foreach (IWebElement x in nomRentList)
                {
                    String isChecked = x.FindElement(By.ClassName("form-radio")).GetAttribute("checked");
                    if (isChecked.Equals("true"))
                        return Double.Parse(x.FindElement(By.ClassName("form-radio")).GetAttribute("value"));      
                }
                return 0.0;
            }
        }

        public int PriceLoan
        {
            get
            {
                IWebElement priceLoanInputForm = driver.FindElement(By.XPath("//div/div[1]/div/div/input[@type='tel']"));
                return Int32.Parse(priceLoanInputForm.GetAttribute("value").Replace(" ", ""));
            }
            set
            {
                IWebElement priceLoanInputForm = driver.FindElement(By.XPath("//div/div[1]/div/div/input[@type='tel']"));
                priceLoanInputForm.Click();
                int sizeOfInputedValue = priceLoanInputForm.GetAttribute("value").Length;
                for (int i = 0; i < sizeOfInputedValue; i++)
                    priceLoanInputForm.SendKeys(Keys.Backspace);
                priceLoanInputForm.SendKeys("" + value);
                carPriceLoanSlider.Click();
            }
        }

        public int OwnCapital
        {
            get
            {
                IWebElement ownCapitalInputForm = driver.FindElement(By.XPath("//div/div[2]/div/div/input[@type='tel']"));
                return Int32.Parse(ownCapitalInputForm.GetAttribute("value").Replace(" ", ""));
            }
            set
            {
                IWebElement ownCapitalInputForm = driver.FindElement(By.XPath("//div/div[2]/div/div/input[@type='tel']"));
                ownCapitalInputForm.Click();
                int sizeOfInputedValue = ownCapitalInputForm.GetAttribute("value").Length;
                for (int i = 0; i < sizeOfInputedValue; i++)
                    ownCapitalInputForm.SendKeys(Keys.Backspace);
                ownCapitalInputForm.SendKeys("" + value);
            }
        }

        public bool isCheckedCarRadioButton()
        {
            IWebElement carRadioButton = driver.FindElement(By.XPath("//input[@data-name='bil']"));
            return carRadioButton.Selected;
        }





    }
}
