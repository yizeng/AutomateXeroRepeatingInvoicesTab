using System;
using Helpers;
using Helpers.CustomExceptions;
using Helpers.ExtensionMethods;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using UiComponents;

namespace RepeatingInvoicesTabTests {
	[TestClass]
	public class TabRepeatingTests : TestsBase {

		private static readonly string tabUrl = Configuration.ApplicationUrl + "/AccountsReceivable/SearchRepeating.aspx";
		private TabRepeatingInvoices tab;

		[TestInitialize]
		public void InitializeTests() {
			// As user has been logged in, tests will navigate to test target directly, instead of click through UI
			WebDriver.Navigate().GoToUrl(tabUrl);

			tab = new TabRepeatingInvoices(WebDriver);
			if (tab.IsEmpty) {
				throw new PreconditionNotMetException("Precondition Not Met: Tests assume there are existing repeating invoices.");
			}
		}

		[TestMethod]
		[Description("Test ticking and unticking any repeating invoices")]
		public void TickRepeatingInvoicesTest() {
			// Check label text when none selected
			Assert.AreEqual(tab.LblNoItemsSelected, tab.LblItemsSelected.Text);

			// Click one random repeating invoice
			int itemIndex = WebDriver.ClickOneRandomElement(tab.List.ChkInvoices);
			IWebElement rowClicked = tab.List.Rows[itemIndex];

			// Check label text has been changed, row selected and background colour has been higlighted
			Assert.AreEqual("1 item selected", tab.LblItemsSelected.Text);
			Assert.IsTrue(rowClicked.GetAttribute("class").Contains("selected"));
			Assert.IsTrue(rowClicked.GetCssValue("background-color").Contains("rgba(225, 255, 194, 1)"));

			// Untick the same invoice
			// Check label text has been changed back, row deselected and background colour has not been higlighted
			tab.List.ChkInvoices[itemIndex].Click();
			Assert.AreEqual(tab.LblNoItemsSelected, tab.LblItemsSelected.Text);
			Assert.IsFalse(rowClicked.GetAttribute("class").Contains("selected"));
			Assert.IsFalse(rowClicked.GetCssValue("background-color").Contains("rgba(225, 255, 194, 1)"));
		}

		[TestMethod]
		[Description("Test ticking and unticking all repeating invoices")]
		public void TickAllRepeatingInvoicesTest() {
			// Check label text when none selected
			Assert.AreEqual(tab.LblNoItemsSelected, tab.LblItemsSelected.Text);

			// Tick all repeating invoices
			tab.List.ChkAll.Click();

			// Check label text has been changed, row selected and background colour has been higlighted
			int totalCount = tab.List.Rows.Count;
			Assert.AreEqual(totalCount + (totalCount > 1 ? " items" : " item") + " selected", tab.LblItemsSelected.Text);
			foreach (IWebElement row in tab.List.Rows) {
				Assert.IsTrue(row.GetAttribute("class").Contains("selected"));
				Assert.IsTrue(row.GetCssValue("background-color").Contains("rgba(225, 255, 194, 1)"));
			}

			// Untick all repeating invoices and check expected results
			tab.List.ChkAll.Click();
			Assert.AreEqual(tab.LblNoItemsSelected, tab.LblItemsSelected.Text);
			foreach (IWebElement row in tab.List.Rows) {
				Assert.IsFalse(row.GetAttribute("class").Contains("selected"));
				Assert.IsFalse(row.GetCssValue("background-color").Contains("rgba(225, 255, 194, 1)"));
			}
		}

		[TestMethod]
		[Description("Test clicking the name of one repeating invoice")]
		public void ClickRepeatingInvoiceTest() {
			// Click one random invoice name
			WebDriver.ClickOneRandomElement(tab.List.Names);

			// Assert page has been redirected to "Edit Repeating Invoice"
			Assert.IsTrue(WebDriver.Title.Contains("Edit Repeating Invoice"));

			// If "Edit Repeating Invoice" page has been implemented,
			// should also perform checks for data poplutated.
			// Omitted here
		}

		#region Test performing actions without selecting any
		[TestMethod]
		[Description("Test clicking 'Save as draft' button when no invoices have been selected")]
		public void SaveAsDraftWithoutSelectingTest() {
			// Click "Save as draft" button
			tab.BtnSaveAsDraft.Click();

			// Check popup window has been displayed properly
			var popupWindow = new PopupWindow(WebDriver);
			Assert.IsTrue(popupWindow.Body.Displayed);
			Assert.AreEqual(tab.LblNoItemsSelected, popupWindow.HeaderText);
			Assert.AreEqual("You have not selected any items to save as draft.", popupWindow.BodyText);
			Assert.IsTrue(popupWindow.BtnClose.IsClickable());
			Assert.IsTrue(popupWindow.BtnOk.IsClickable());
		}

		[Ignore]
		[TestMethod]
		[Description("Test clicking 'Approve' button when no invoices have been selected")]
		public void ApproveWithoutSelectingTest() {
			throw new NotImplementedException();

			// Test Case Defined:
			// Click "Approve" button
			// Check popup window has been displayed properly
		}

		[Ignore]
		[TestMethod]
		[Description("Test clicking 'Approve for Sending' button when no invoices have been selected")]
		public void ApproveForSendingWithoutSelectingTest() {
			throw new NotImplementedException();

			// Test Case Defined:
			// Click "Approve for Sending" button
			// Check popup window has been displayed properly
		}

		[Ignore]
		[TestMethod]
		[Description("Test clicking 'Delete' button when no invoices have been selected")]
		public void DeleteWithoutSelectingTest() {
			throw new NotImplementedException();

			// Test Case Defined:
			// Click "Delete" button
			// Check popup window has been displayed properly
		}
		#endregion

		#region Test searching repeating invoices
		[Ignore]
		[TestMethod]
		public void SearchRepeatingInvoicesTest() {
			throw new NotImplementedException();

			// Test Case Defined:
			// Click "Search" button
			// Check the search panel has been displayed correctly
			// Perform a search
			// Check expected results are shown in the list
		}

		[Ignore]
		[TestMethod]
		public void ClearSearchTest() {
			throw new NotImplementedException();

			// Test Case Defined:
			// Click "Search" button
			// Check the search panel has been displayed correctly
			// Perform a search
			// Check expected results are shown in the list

			// Click 'Clear' button
			// Check list has been restored to the original
		}
		#endregion
		
		[Ignore]
		[TestMethod]
		public void SaveAsDraftTest() {
			throw new NotImplementedException();

			// Test Case Defined:
			// Select one or more repeating invoices
			// Click 'Save as Draft' button
			// Click 'OK' button
			// Check 'Invoice will be' column has been updated
		}

		[Ignore]
		[TestMethod]
		public void SaveAsDraftThenCancelTest() {
			throw new NotImplementedException();

			// Test Case Defined:
			// Select one or more repeating invoices
			// Click 'Save as Draft' button
			// Click 'Cancel' button
			// Check 'Invoice will be' column has not been updated
		}

		[Ignore]
		[TestMethod]
		public void ApproveTest() {
			throw new NotImplementedException();

			// Test Case Defined:
			// Select one or more repeating invoices
			// Click 'Approve' button
			// Click 'OK' button
			// Check 'Invoice will be' column has been updated
		}

		[Ignore]
		[TestMethod]
		public void ApproveThenCancelTest() {
			throw new NotImplementedException();

			// Test Case Defined:
			// Select one or more repeating invoices
			// Click 'Approve' button
			// Click 'Cancel' button
			// Check 'Invoice will be' column has not been updated
		}

		[Ignore]
		[TestMethod]
		public void ApproveForSendingTest() {
			throw new NotImplementedException();

			// Test Case Defined:
			// Select one or more repeating invoices
			// Click 'Approve for sending' button
			// Check new dialog has been populated with correct data
			// Click 'OK' button
		}

		[Ignore]
		[TestMethod]
		public void ApproveForSendingThenCancelTest() {
			throw new NotImplementedException();

			// Test Case Defined:
			// Select one or more repeating invoices
			// Click 'Approve for sending' button
			// Check new dialog has been populated with correct data
			// Click 'Cancel' button
			// All dialogs should be dismissed
		}

		[Ignore]
		[TestMethod]
		public void DeleteRepeatingInvoiceTest() {
			throw new NotImplementedException();

			// Test Case Defined:
			// Select one or more repeating invoices
			// Click 'Delete' button
			// Click 'OK' button
			// Check the item doesn't show up in the list
		}

		[Ignore]
		[TestMethod]
		public void DeleteRepeatingInvoiceThenCancelTest() {
			throw new NotImplementedException();

			// Test Case Defined:
			// Select one or more repeating invoices
			// Click 'Delete' button
			// Click 'Cancel' button
			// Check the item should still exist in the list
		}

		[Ignore]
		[TestMethod]
		public void SortRepeatingInvoiceTest() {
			throw new NotImplementedException();
			
			// Test Case Defined:
			// foreach ColumnHeaders
			//     Click once to sort
			//     Check results
			//     Click again to sort otherwise
			//     Check results again
			// end foreach
		}
	}
}
