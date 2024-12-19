using Microsoft.Playwright;

namespace LiveBettingTests.PageObjects
{
    public abstract class BasePage
    {
        protected readonly IPage _page;

        // Constructor: All pages receive the Playwright `IPage` object
        protected BasePage(IPage page)
        {
            _page = page;
        }

        // Navigate to a specific URL
        public async Task GotoPage(string url)
        {
            await _page.GotoAsync(url);
        }

        // Wait for an element to be visible
        public async Task WaitForElementVisible(string selector, int timeout = 5000)
        {
            await _page.WaitForSelectorAsync(selector, new PageWaitForSelectorOptions
            {
                State = WaitForSelectorState.Visible,
                Timeout = timeout
            });
        }

        // Click on an element
        public async Task ClickElement(string selector)
        {
            await _page.ClickAsync(selector);
        }

        // Get text from an element
        public async Task<string> GetElementText(string selector)
        {
            return await _page.TextContentAsync(selector);
        }

        // Check if an element is visible
        public async Task<bool> IsElementVisible(string selector)
        {
            return await _page.Locator(selector).IsVisibleAsync();
        }
    }
}
