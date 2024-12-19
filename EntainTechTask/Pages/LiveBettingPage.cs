using Microsoft.Playwright;

namespace LiveBettingTests.PageObjects
{
    public class LiveBettingPage : BasePage
    {
        // Selectors
        private const string EventViewSelector = "//ms-sub-navigation/ds-tabs-group/div/div/ul/li[2]/div";
        private const string PickSelector ="/ms-live-events-navigation/ms-nav-tree/ms-tree-item[4]/div/div[2]";
        private const string OddsIndicator = "span.odds-update-indicator";

        public LiveBettingPage(IPage page) : base(page) { }

        // Navigate to the Live Betting Page
        public async Task NavigateToLiveBettingPage()
        {
            await GotoPage(Config.PlaywrightSettings.BaseUrl);
        }

        // Add a pick to Betslip
        public async Task<string> AddPickToBetslip()
        {
            await ClickElement(EventViewSelector);
            var pickText = await GetElementText(PickSelector);
            await ClickElement(PickSelector);
            return pickText;
        }

        // Capture current odds
        public async Task<string> CaptureOdds()
        {
            return await GetElementText(PickSelector);
        }

        // Wait for odds change indicator
        public async Task WaitForOddsChange()
        {
            await WaitForElementVisible(OddsIndicator);
        }
    }
}
