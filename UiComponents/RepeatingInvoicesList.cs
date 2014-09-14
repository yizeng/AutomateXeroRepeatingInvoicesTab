using System.Collections.Generic;
using OpenQA.Selenium;

namespace UiComponents {

	public class RepeatingInvoicesList {

		private readonly IWebDriver driver;

		public RepeatingInvoicesList(IWebDriver driver) {
			this.driver = driver;

			Table = driver.FindElement(By.CssSelector("table.standard"));
		}

		public IWebElement Table { get; private set; }

		#region Column Headers
		public IWebElement ColHeaderName {
			get { return Table.FindElement(By.XPath(".//thead//td[normalize-space(text())='Name']")); }
		}

		public IWebElement ColHeaderReference {
			get { return Table.FindElement(By.XPath(".//thead//td[normalize-space(text())='Reference']")); }
		}

		public IWebElement ColHeaderAmount {
			get { return Table.FindElement(By.XPath(".//thead//td[normalize-space(text())='Amount']")); }
		}

		public IWebElement ColHeaderRepeats {
			get { return Table.FindElement(By.XPath(".//thead//td[normalize-space(text())='Repeats']")); }
		}
		#endregion

		public IWebElement ChkAll {
			get { return Table.FindElement(By.XPath(".//thead//input[@type='checkbox']")); }
		}

		public IList<IWebElement> ChkInvoices {
			get { return Table.FindElements(By.XPath(".//tbody//input[@name='selectedInvoices']")); }
		}

		public IList<IWebElement> Names {
			get { return Table.FindElements(By.CssSelector("tr a.nav[href*='RepeatTransactions/Edit.aspx']")); }
		}

		public IList<IWebElement> Rows {
			get { return Table.FindElements(By.XPath(".//tbody//tr")); }
		}

	}
}
