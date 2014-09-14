using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Helpers {
	public class WebElementWait : DefaultWait<IWebElement> {

		public WebElementWait(IWebElement element, TimeSpan timeout)
			: this(new SystemClock(), element, timeout) {
		}

		public WebElementWait(IClock clock, IWebElement element, TimeSpan timeout)
			: base(element, clock) {
			Timeout = timeout;
			IgnoreExceptionTypes(typeof(NotFoundException));
		}
	}
}
