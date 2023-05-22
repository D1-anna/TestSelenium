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
            EdgeOptions options = new EdgeOptions();
            options.AddArgument("start-maximized");
            driver = new EdgeDriver(options);

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

            // display all cookies that created from session start
            foreach (var cookie in driver.Manage().Cookies.AllCookies)
            {
                Console.WriteLine($" driver coolies: {cookie}");
            }
           

            wait.Until(driver => driver.FindElement(By.Id("hero-section")));
            driver.FindElement(By.Id("c-shellmenu_0")).Click();
            wait.Until(driver => driver.FindElement(By.Id("shellmenu_34")));            
            driver.FindElement(By.XPath("//a[contains(text(),'Clipchamp')]")).Click();
            wait.Until(driver => driver.FindElement(By.ClassName("h1")));
            
            // delete all stored cookies during session
            driver.Manage().Cookies.DeleteAllCookies();
            

        }
    }
}