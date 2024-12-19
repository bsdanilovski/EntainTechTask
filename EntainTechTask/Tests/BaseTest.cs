using LiveBettingTests.Config;
using Microsoft.Playwright;

namespace LiveBettingTests.Tests
{
    public class BaseTest
    {
        protected IPage page;
        protected IBrowser browser;

        [SetUp]
        public async Task Setup()
        {
            var playwright = await Playwright.CreateAsync();

            // Read configuration dynamically
            var browserType = ConfigReader.GetBrowser();
            var headlessMode = ConfigReader.IsHeadless();
            var timeout = ConfigReader.GetTimeout();
            var (width, height) = ConfigReader.GetViewportSize("Desktop");

            browser = browserType.ToLower() switch
            {
                "chromium" => await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = headlessMode }),
                "firefox" => await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions { Headless = headlessMode }),
                "webkit" => await playwright.Webkit.LaunchAsync(new BrowserTypeLaunchOptions { Headless = headlessMode }),
                _ => throw new ArgumentException($"Unsupported browser: {browserType}")
            };

            var context = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize { Width = width, Height = height }
            });

            page = await context.NewPageAsync();
            await page.GotoAsync(ConfigReader.GetBaseUrl());
        }

        [TearDown]
        public async Task TearDown()
        {
            if (browser != null) await browser.CloseAsync();
        }
    }
}
