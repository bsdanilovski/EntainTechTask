using Microsoft.Playwright;

namespace LiveBettingTests.Utilities
{
    public static class CommonHelpers
    {
        public static async Task WaitForTextChange(IPage page, string selector, string initialText)
        {
            await page.WaitForFunctionAsync(
                $"document.querySelector('{selector}').innerText !== '{initialText}'");
        }
    }
}

