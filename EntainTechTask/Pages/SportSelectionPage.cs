using Microsoft.Playwright;

namespace LiveBettingTests.PageObjects
{
    public class SportSelectionPage : BasePage
    {
        private const string AZSportsSelector = "//span[text()='A-Z Sports']";
        private const string SportTabTemplate = "//vn-menu-item/a/vn-menu-item-text-content/span[text()='Tennis']";

        public SportSelectionPage(IPage page) : base(page) { }

        // Select a sport from the A-Z list
        public async Task SelectSport(string sportName)
        {
            await ClickElement(AZSportsSelector);
            await ClickElement(string.Format(SportTabTemplate, sportName));
        }

        // Check that the sport page is loaded
        public async Task<bool> IsSportPageLoaded(string sportName)
        {
            return await IsElementVisible($"//h1[contains(text(),'{sportName}')]");
        }
    }
}
