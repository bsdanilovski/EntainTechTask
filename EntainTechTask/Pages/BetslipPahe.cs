using Microsoft.Playwright;

namespace LiveBettingTests.PageObjects
{
    public class BetslipPage : BasePage
    {
        private const string BetslipItemSelector = "div.betslip-item";

        public BetslipPage(IPage page) : base(page) { }

        // Verify if a pick is in the Betslip
        public async Task<bool> IsPickInBetslip(string pickText)
        {
            return await IsElementVisible($"//div[@class='betslip-item' and contains(text(), '{pickText}')]");
        }
    }
}
