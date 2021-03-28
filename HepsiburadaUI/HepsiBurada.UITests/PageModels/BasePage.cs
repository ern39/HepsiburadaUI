using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;

namespace HepsiBurada.UITests.PageModels {
    public class BasePage {
        private IWebDriver webDriver;

        public BasePage(IWebDriver webDriver) {
            this.webDriver = webDriver;
            PageFactory.InitElements(this.webDriver, this);
        }

        public string GetCurrentUrl() {
            return webDriver.Url;
        }

        public void ClickElement(IWebElement element) {
            Wait(5);
            element.Click();
        }

        public void SetText(IWebElement element, string text) {
            Wait(5);
            element.SendKeys(text);
            element.SendKeys(Keys.Tab);
        }

        public void HoverElement(IWebElement element) {
            Wait(5);
            Actions action = new Actions(this.webDriver);
            action.MoveToElement(element).Build().Perform();
        }

        public void ScrollInToView(IWebElement element) {
            Wait(5);
            IJavaScriptExecutor js = (IJavaScriptExecutor) webDriver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public void Wait(int second) {
            Thread.Sleep(TimeSpan.FromSeconds(second));
        }
    }
}
