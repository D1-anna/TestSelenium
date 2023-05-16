using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

namespace TestSelenium
{
    public class Tests
    {
        IWebDriver driver;
        WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            driver = new EdgeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl("https://www.office.com/");
            wait.Until(driver => driver.FindElement(By.Id("hero-section")));
            driver.FindElement(By.Id("c-shellmenu_0")).Click();
            wait.Until(driver => driver.FindElement(By.Id("shellmenu_34")));            
            driver.FindElement(By.XPath("//a[contains(text(),'Clipchamp')]")).Click();
            wait.Until(driver => driver.FindElement(By.ClassName("h1")));

        }
    }
}