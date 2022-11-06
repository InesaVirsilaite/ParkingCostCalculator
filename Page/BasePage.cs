
using OpenQA.Selenium;

namespace ManoDaktarasPageTesting.Page
{
    public class BasePage
    {
        protected static IWebDriver Driver;
        public BasePage(IWebDriver webdriver)
        {
            Driver = webdriver; 
        }
      


    }
}
