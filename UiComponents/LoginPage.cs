using System;
using Helpers;
using Helpers.ExtensionMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace UiComponents {

	public class LoginPage {

		private readonly IWebDriver driver;

		public LoginPage(IWebDriver driver) {
			this.driver = driver;

			driver.Navigate().GoToUrl(Configuration.LoginUrl);
			driver.WaitForCompletedReadyState();

			PageFactory.InitElements(driver, this);
		}

		[FindsBy(How = How.Id, Using = "email")]
		public IWebElement InputEmail { get; private set; }

		[FindsBy(How = How.Id, Using = "password")]
		public IWebElement InputPassword { get; private set; }

		[FindsBy(How = How.Id, Using = "submitButton")]
		public IWebElement BtnLogin { get; private set; }

		public void Login(string email, string password) {
			InputEmail.SendKeys(email);
			InputPassword.SendKeys(password);
			BtnLogin.WaitTilClickable().Click();

			// Wait for signing in and check if page has been redirected to Dashboard page
			var waitTime = TimeSpan.FromMilliseconds(Configuration.ExplicitWaitTime);
			try {
				var wait = new WebDriverWait(driver, waitTime);
				wait.Until(d => d.Url.Contains(Configuration.ApplicationUrl + "Dashboard"));
			} catch (WebDriverTimeoutException ex) {
				throw new WebDriverTimeoutException(string.Format("Dashboard was not loaded within {0} after login", waitTime.Milliseconds), ex);
			}
		}
	}
}
