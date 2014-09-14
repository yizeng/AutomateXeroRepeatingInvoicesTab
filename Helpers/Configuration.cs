using System;
using System.Configuration;

namespace Helpers {

	public class Configuration {

		public static string LoginUrl {
			get { return ConfigurationManager.AppSettings["LoginUrl"]; }
		}

		public static string ApplicationUrl {
			get { return ConfigurationManager.AppSettings["ApplicationUrl"]; }
		}

		public static string EmailAddress {
			get { return ConfigurationManager.AppSettings["EmailAddress"]; }
		}

		public static string Password {
			get { return ConfigurationManager.AppSettings["Password"]; }
		}

		public static int ImplicitWaitTime {
			get { return Convert.ToInt32(ConfigurationManager.AppSettings["ImplicitWaitTime"]); }
		}

		public static int ExplicitWaitTime {
			get { return Convert.ToInt32(ConfigurationManager.AppSettings["ExplicitWaitTime"]); }
		}

		public static BrowserType BrowserType {
			get {
				switch (ConfigurationManager.AppSettings["BrowserType"].Trim().ToLower()) {
					case "chrome":
						return BrowserType.Chrome;
					case "firefox":
						return BrowserType.Firefox;
					case "ie":
						return BrowserType.InternetExplorer;
					case "internetexplorer":
						return BrowserType.InternetExplorer;
					default:
						return BrowserType.Unknown;
				}
			}
		}

	}
}
