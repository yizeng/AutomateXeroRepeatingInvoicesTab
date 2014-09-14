using System;
using OpenQA.Selenium;

namespace Helpers.ExtensionMethods {

	public static class WebElementExtensions {

		public static IWebElement WaitTilClickable(this IWebElement element, int timeoutMs = -1) {
			timeoutMs = timeoutMs == -1 ? Configuration.ExplicitWaitTime : timeoutMs;
			new WebElementWait(element, TimeSpan.FromMilliseconds(timeoutMs)).Until(d => element.Displayed && element.Enabled);
			return element;
		}

		public static bool IsClickable(this IWebElement element, int timeoutMs = -1, bool waitTilTimeout = true) {
			bool clickable;
			try {
				if (waitTilTimeout) {
					element = element.WaitTilClickable();
				}
				clickable = element.Displayed && element.Enabled;
			} catch (WebDriverTimeoutException) {
				clickable = false;
			}
			return clickable;
		}
	}
}
