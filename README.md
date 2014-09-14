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

From command line, do some thing.

### CI

Although untested, the project should be able to run on CI servers like TeamCity using standard configuration built-in for `MSTEST`.
Browser types, login credentials can be set by CI automatically through `App.config` file.
