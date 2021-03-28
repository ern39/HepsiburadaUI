using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HepsiBurada.UITests.Utils
{
    public class BrowserUtils
    {
        public IWebDriver webDriver;

        public IWebDriver SetupChromeDriver(string driver)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            options.AddArguments("test-type");
            options.AddArguments("disable-popup-blocking");
            options.AddArguments("ignore-certificate-errors");
            options.AddArguments("disable-translate");
            options.AddArguments("disable-automatic-password-saving");
            options.AddArguments("allow-silent-push");
            options.AddArguments("disable-infobars");
            options.AddArguments("disable-notifications");
            options.AddAdditionalCapability("useAutomationExtension", false);
            webDriver = new ChromeDriver(driver, options);
            return webDriver;
        }
    }
}
