using System;
using Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using UiComponents;

namespace RepeatingInvoicesTabTests {
	[TestClass]
	public class TestsBase {

		protected static IWebDriver WebDriver { get; private set; }

		[AssemblyInitialize]
		public static void InitializeAssembly(TestContext testContext) {
			InitializeWebDriver();
			Login();
		}

		[AssemblyCleanup]
		public static void CleanupAssembly() {
			if (WebDriver != null) {
				WebDriver.Quit();
			}
		}

		private static void InitializeWebDriver() {
			switch (Configuration.BrowserType) {
				case BrowserType.Firefox:
					WebDriver = new FirefoxDriver();
					break;
				case BrowserType.InternetExplorer:
					var ieOptions = new InternetExplorerOptions {
						EnableNativeEvents = true,
						EnablePersistentHover = true,
						EnsureCleanSession = true,
						UnexpectedAlertBehavior = InternetExplorerUnexpectedAlertBehavior.Dismiss
					};

					WebDriver = new InternetExplorerDriver("./", ieOptions);
					break;
				case BrowserType.Chrome:
					var chromeOptions = new ChromeOptions();
					chromeOptions.AddArguments("test-type");

					WebDriver = new ChromeDriver("./", chromeOptions);
					break;
				default:
					throw new ArgumentException("Unknown browser type is specified!");
			}

			WebDriver.Manage().Window.Maximize();
			WebDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(Configuration.ImplicitWaitTime));
		}

		private static void Login() {
			new LoginPage(WebDriver).Login(Configuration.EmailAddress, Configuration.Password);
		}
	}
}
