using System;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace Helpers.ExtensionMethods {

	public static class WebDriverExtensions {

		public static bool IsElementFound(this IWebDriver driver, By locator) {
			driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(0));

			try {
				driver.FindElement(locator);
				return true;
			} catch (Exception) {
				return false;
			} finally {
				driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(Configuration.ImplicitWaitTime));
			}
		}

		public static void WaitForCompletedReadyState(this IWebDriver driver) {
			try {
				var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(Configuration.ExplicitWaitTime));
				wait.Until(d => {
					var jsExecutor = d as IJavaScriptExecutor;
					return jsExecutor != null && (string)jsExecutor.ExecuteScript("return document.readyState") == "complete";
				});
			} catch (WebDriverTimeoutException) {
				Debug.WriteLine("WaitForCompletedReadyState timed out after {0} ms. Test countinued.", Configuration.ExplicitWaitTime);
			}
		}

		public static int ClickOneRandomElement(this IWebDriver driver, IList<IWebElement> elements) {
			if (elements.Count < 1) {
				throw new ArgumentOutOfRangeException("No elements to be clicked");
			}
			int selectedIndex = new Random().Next(elements.Count - 1);
			elements[selectedIndex].Click();

			return selectedIndex;
		}
	}
}
