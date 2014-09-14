using Helpers.ExtensionMethods;
using OpenQA.Selenium;

namespace UiComponents {

	public class TabRepeatingInvoices {

		private readonly IWebDriver driver;

		public TabRepeatingInvoices(IWebDriver driver) {
			this.driver = driver;
		}

		public bool IsEmpty {
			get {
				By locator = By.XPath(".//div[contains(@class, 'document')]//div[text()='There are no items to display.']");
				return driver.IsElementFound(locator);
			}
		}

		#region Task Buttons
		public IWebElement BtnNewRepeatingInvoice {
			get { return driver.FindElement(By.CssSelector(".tasks a[href*='RepeatTransactions/Edit.aspx']")); }
		}

		public IWebElement BtnNewCreditNote {
			get { return driver.FindElement(By.CssSelector(".tasks a[href*='AccountsReceivable/EditCreditNote.aspx']")); }
		}

		public IWebElement BtnSendStatements {
			get { return driver.FindElement(By.CssSelector(".tasks a[href*='AccountsReceivable/Statements.aspx']")); }
		}

		public IWebElement BtnImport {
			get { return driver.FindElement(By.CssSelector(".tasks a[href*='Import/Import.aspx']")); }
		}
		#endregion

		#region Action Bar
		public IWebElement BtnSaveAsDraft {
			get { return driver.FindElement(By.CssSelector(".action-bar a[onclick*='save as draft']")); }
		}

		public IWebElement BtnApprove {
			get { return driver.FindElement(By.CssSelector(".action-bar a[onclick*='approve']")); }
		}

		public IWebElement BtnApproveForSending {
			get { return driver.FindElement(By.CssSelector(".action-bar a[onclick*='repeating']")); }
		}

		public IWebElement BtnDelete {
			get { return driver.FindElement(By.CssSelector(".action-bar a[onclick*='delete']")); }
		}

		public IWebElement LblCount {
			get { return driver.FindElement(By.CssSelector(".action-bar .count")); }
		}

		public IWebElement BtnSearch {
			get { return driver.FindElement(By.CssSelector(".action-bar a[onclick*='searchbutton']")); }
		}
		#endregion

		public IWebElement LblItemsSelected {
			get { return driver.FindElement(By.ClassName("count")); }
		}

		public string LblNoItemsSelected {
			get { return "No items selected"; }
		}

		public RepeatingInvoicesList List {
			get { return new RepeatingInvoicesList(driver); }
		}
	}
}
