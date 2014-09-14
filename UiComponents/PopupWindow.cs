using OpenQA.Selenium;

namespace UiComponents {

	public class PopupWindow {

		private IWebDriver driver;

		public PopupWindow(IWebDriver driver) {
			this.driver = driver;
		}

		public IWebElement Body {
			get { return driver.FindElement(By.CssSelector(".x-window[style*='visibility: visible']")); }
		}

		public string HeaderText {
			get { return Body.FindElement(By.ClassName("x-window-header-text")).Text; }
		}

		public string BodyText {
			get { return Body.FindElement(By.ClassName("x-window-body")).Text; }
		}

		public IWebElement BtnOk {
			get { return Body.FindElement(By.XPath(".//button[text()='OK']")); }
		}

		public IWebElement BtnClose {
			get { return Body.FindElement(By.ClassName("x-tool-close")); }
		}
	}
}
