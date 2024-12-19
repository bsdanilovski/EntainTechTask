# Live Betting Page Test Automation

## Overview
This project automates the testing of key functionalities on the Live Betting page of the bwin sports betting website using Playwright with C# bindings and NUnit as the test framework.

### Key Features
1. Page Object Model (POM): Provides modular, reusable, and maintainable page interaction methods.
2. Configuration Management: Centralized  settings such as browser type, base URL, and test environment in TestConfig.json
3. Explicit Waits: Ensures stability of tests by waiting for elements before interacting.
4. Responsive Testing: Runs tests on both desktop and mobile viewports.
4. Assertions: Verifies key functionalities, such as adding picks to the betslip, validating live odds updates, and checking the sports sorting feature.

### Technologies Used
* Programming Language: C#
* Test Framework: NUnit
* Browser Automation: Microsoft Playwright
* IDE: Visual Studio 2022
* Configuration: JSON (for environment and browser settings)
* Dependency Management: NuGet

### Prerequisites
Ensure the following are installed on your machine

* Visual Studio 2022 or later
* .NET 6 SDK or higher
* Node.js (required for Playwright binaries)
* Install Playwright dependencies with: 
    `playwright install`
* Browser Drivers: Playwright will download necessary browser drivers automatically.

### Setup
1. Install .NET SDK: [Download Here](https://dotnet.microsoft.com/download)
2.  Clone the repository: `git clone <repository-url>
3. Navigate to the project directory: `cd LiveBettingTests`
4. Restore dependencies:Open the project in Visual Studio and restore the required NuGet packages `dotnet restore`
5. Install Playwright Browsers Ensure Playwright browsers are installed: `playwright install`
6. Build the project: `dotnet build`

## Project Structure
   
    LiveBettingTests
      * Config
        * TestConfig.json
      * Pages
        * BasePage.cs
        * BetslipPage.cs
        * LiveBettingPage
        * SportSelectionPage.cs
      * Tests
        * BaseTest.cs
        * BetslipTests.cs
        * LiveOddsTests.cs
        * SportSortingTests.cs
      * Utilities
        * Helpers.cs
      README.md

## Configuration
  The configuration file `TestConfig.json` contains the following elements:
 - `BaseUrl`: The base URL of the site to be tested.
 - `Browser`: The browser to be used (e.g., `chromium`, `firefox`, `webkit`).
 - `Headless`: Boolean indicating whether to run in headless mode.
 - `Viewports`: A list of viewport configurations (name, width, height).
 - `Sports`: A list of sports to be tested.

## Running Tests
 1. To run all tests: `dotnet test`
 2. To run tests with a specific viewport or other configuration, update the relevant settings in the `TestConfig.json` file.

## Test Scenarios

The following test scenarios are automated:
- Adding Pick to Betslip
- Validate Live Odds Updates
- Check Sport Sorting

## Execution Modes

You can specify the browser and viewport size via the TestConfig.json file. By default:
* Tests run in Chromium.
* Tests are executed in headless mode.

To debug tests, set "Headless": false in TestConfig.json.

## Troubleshooting

* Timeout Errors:
Ensure elements are properly located and that the page is fully loaded. Adjust the Timeout value in TestConfig.json.

* Incorrect Selectors:
Use browser developer tools (F12) to inspect elements and verify the locators

* Playwright Installation Issues:
Reinstall Playwright browsers: `playwright install --force`











