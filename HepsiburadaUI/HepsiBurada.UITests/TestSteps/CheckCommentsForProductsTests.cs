using HepsiBurada.UITests.PageModels;
using HepsiBurada.UITests.Utils;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;

namespace HepsiBurada.UITests.TestSteps {
    [Binding, Scope(Feature = "CheckCommentsForProducts")]
    public class CheckCommentsForProductsTests {
        public static IWebDriver WebDriver { get; set; }
        public BasePage basePage;
        public StepDetails stepDetails;
        public BrowserUtils browser;
        string driverPath = String.Empty;

        public CheckCommentsForProductsTests() {
            browser = new BrowserUtils();
            driverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            WebDriver = browser.SetupChromeDriver(driverPath);
            basePage = new BasePage(WebDriver);
            stepDetails = new StepDetails(WebDriver);
        }

        [StepDefinition("'(.*)' sitesine gidilir")]
        public void OpenBrowserWithUrl(string url) {
            WebDriver.Navigate().GoToUrl(url);
        }

        [StepDefinition("Arama çubuğundan '(.*)' ürünü aratılır")]
        public void SearchProduct(string product) {
            stepDetails.SearchProduct(product);
        }

        [StepDefinition("Arama sonucunda gelen ürün listesinden ilk ürün seçilir")]
        public void SelectFirstProduct() {
            stepDetails.SelectFirstProduct();
        }

        [StepDefinition("Ürün detay sayfasından değerlendirmeler tabına tıklanır")]
        public void ClickTabReview() {
            stepDetails.ClickTabReview();
        }

        [StepDefinition("Yorumların geldiği izlenir aksi halde test bitirilir")]
        public void CheckListedReviews() {
            stepDetails.CheckListedReviews();
        }
        
        [StepDefinition("Sırala dropdown tıklanır")]
        public void ClickDropDownSort() {
            stepDetails.ClickDropDownSort();
        }
        
        [StepDefinition("Dropdown seçenekleri kontrol edilir")]
        public void CheckDropDownSortCriteria() {
            stepDetails.CheckDropDownSortCriteria();
        }

        [StepDefinition("Gelen yorumlar arasından ilk yorumun evet butonuna basılır")]
        public void LikeListedReview() {
            stepDetails.LikeListedReview();
        }

        [StepDefinition("'(.*)' uyarısının geldiği görülür")]
        public void CheckAlertLikeReview(string likeReviewText) {
            stepDetails.CheckAlertLikeReview(likeReviewText);
        }

        [AfterScenario]
        public void AfterScenario() {
            WebDriver.Quit();
        }
    }
}


