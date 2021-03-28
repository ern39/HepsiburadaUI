using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;

namespace HepsiBurada.UITests.PageModels {
    public class StepDetails : BasePage {
        private IWebDriver webDriver;

        public StepDetails(IWebDriver webDriver) : base(webDriver) {
            this.webDriver = webDriver;
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='hermes - voltran - comments']/div[3]/div[1]/div[2]/div[2]/div[2]/div/div[2]/div/div")]
        public IList<IWebElement> txtSortCriteriaList;

        [FindsBy(How = How.ClassName, Using = "hermes-Sort-module-pGjws")]
        public IWebElement drpbSort;

        [FindsBy(How = How.ClassName, Using = "desktopOldAutosuggestTheme-input")]
        public IWebElement txtSearch;

        [FindsBy(How = How.XPath, Using = "//a[@id='productReviewsTab']")]
        public IWebElement tabReview;

        [FindsBy(How = How.XPath, Using = "//ul[@class='product-list results-container do-flex list']/li/div/a")]
        public IList<IWebElement> productList;

        [FindsBy(How = How.XPath, Using = "//div[@id='hermes-voltran-comments']/div[3]/div[3]/div/div")]
        public IList<IWebElement> reviewList;

        [FindsBy(How = How.XPath, Using = "//div[@id='hermes-voltran-comments']/div[3]/div[3]/div/div[1]/div[2]/div[4]/div[1]/div/div[1]/div[1]")]
        public IWebElement btnLikeReview;

        [FindsBy(How = How.XPath, Using = "//div[@id='hermes-voltran-comments']/div[3]/div[3]/div/div[1]/div[2]/div[4]/div[2]/span[2]")]
        public IWebElement txtReviewAlert;

        string xpathSortCriteria = "//*[@id='hermes-voltran-comments']/div[3]/div[1]/div[2]/div[2]/div[2]/div/div[2]/div/div";
        string xpathReviewTab = "//a[@id='productReviewsTab']";
        string xpathReviewAlert = "//div[@id='hermes-voltran-comments']/div[3]/div[3]/div/div[1]/div[2]/div[4]/div[2]/span[2]";

        public void ClickDropDownSort() {
            Wait(5);
            ScrollInToView(drpbSort);
            Wait(2);
            ClickElement(drpbSort);
            Wait(2);
        }

        public void CheckDropDownSortCriteria() {
            List<string> criterias = new List<string>() {
                "Varsayılan", "En yeni değerlendirme", "En faydalı değerlendirme", "Puana göre azalan", "Puana göre artan"
            };

            IList<IWebElement> element = webDriver.FindElements(By.XPath(xpathSortCriteria));

            for (int i = 0; i < element.Count; i++) {
                element[i].GetAttribute("value");
                string text = element[i].Text;
                Assert.AreEqual(text, criterias[i], "Sıralama koşulları düzgün gelmedi");
            }
        }

        public void SearchProduct(string product) {
            Wait(5);
            if (txtSearch.Displayed) {
                ClickElement(txtSearch);
                SetText(txtSearch, product);
                txtSearch.SendKeys(Keys.Enter);
            }
            else
                Assert.Fail("Ürün araması tamamlanamadı!");
        }

        public void SelectFirstProduct() {
            CheckListedProducts();
            ClickElement(productList[0]);
        }

        public void CheckListedProducts() {
            Wait(7);
            if (!productList[0].Displayed) {
                Assert.Fail("Aranan ürün/ürünler listelenmedi!");
            }
        }

        public void ClickTabReview() {
            Wait(7);
            if (tabReview.Displayed) {
                ScrollInToView(tabReview);
                ClickElement(tabReview);
            }
            else
                Assert.Fail("Değerlendirmeler tabına erişilemedi!");
        }

        public void CheckListedReviews() {
            if (!IsReviewExisting())
                Assert.Pass("İlgili ürüne ait yorum bulunamadı!");
            else {
                for (int i = 0; i < reviewList.Count; i++) {
                    Wait(7);
                    if (!reviewList[i].Displayed) {
                        Assert.Fail("Ürüne ait yorumlar bulunamadı!");
                    }
                }
            }
        }

        

        public void LikeListedReview() {
            Wait(5);
            if (btnLikeReview.Displayed) {
                ScrollInToView(btnLikeReview);
                Wait(2);
                ClickElement(btnLikeReview);
                Wait(2);
            }
            else
                Assert.Fail("İlgili ürüne ait beğenme butonuna erişilemedi!");
        }

        public void CheckAlertLikeReview(string likeReviewText) {
            Wait(5);
            if (txtReviewAlert.Displayed) {
                Wait(4);
                string txtLikeReviewAlert = txtReviewAlert.FindElement(By.XPath(xpathReviewAlert)).Text.Trim();
                Wait(4);
                Assert.AreEqual(likeReviewText, txtLikeReviewAlert, "Beğenme sonra uyarı mesajı görüntülenemedi!");
            }
            else
                Assert.Fail("Beğenme sonra uyarı mesajı görüntülenemedi!");
        }

        public bool IsReviewExisting() {
            string txtTabReview = tabReview.FindElement(By.XPath(xpathReviewTab)).Text.Trim();
            int cntReview = Int32.Parse(txtTabReview.Substring(18, txtTabReview.Length - 19));
            if (cntReview == 0)
                return false;
            return true;
        }
    }
}
