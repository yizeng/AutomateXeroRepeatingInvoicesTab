AutomateXeroRepeatingInvoicesTab
================================

## Frameworks used

- .NET Framework 4.0
- Visual Studio Unit Testing (VS 2010)
- Selenium 2.43.0 C# binding
- ChromeDriver 2.10.0
- IEDriver 2.43.0

## Environment tested

- Windows 7
- Visual Studio 2010 Ultimate
- Chrome 37, Firefox 32.0.1, IE 10

## Xero account

Login credentials are needed in `App.config` file.

## Solution Structure

- AutomateRepeatingInvoicesTab
    + Four samples tests for repeating invoices tab
    + Many more tests defined but not implemented yet
- Binaries
    + Selenium
    + ChromeDriver
    + IEDriver
- Helpers
    + Some helper classes for the tests
- UiComponents
    + Page objects created representing application UI elements

## Run tests

### Maunally

1. Add login credential in `/RepeatingInvoicesTabTests/App.config` file
2. Open a command line prompt and switch repository
3. Clean Solution

		"C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\devenv.exe" "AutomateRepeatingInvoicesTab.sln" /Clean

4. Build Solution

		"C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\devenv.exe" "AutomateRepeatingInvoicesTab.sln" /Build Release

5. Run tests

		"C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\mstest.exe" /testcontainer:"RepeatingInvoicesTabTests/bin/Release/RepeatingInvoicesTabTests.dll" /testsettings:"Local.testsettings"

### CI

Although untested, the project should be able to run on CI servers like TeamCity using standard configuration built-in for `MSTEST`.
Browser types, login credentials can be set by CI automatically through `App.config` file.
