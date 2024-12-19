using NUnit.Framework;
using LiveBettingTests.PageObjects;

namespace LiveBettingTests.Tests
{
    [TestFixture]
    public class BetslipTests : BaseTest
    {
        [Test]
        public async Task VerifyPickIsAddedToBetslip()
        {
            var liveBettingPage = new LiveBettingPage(page);
            var betslipPage = new BetslipPage(page);

            // Step 1: Navigate to Live Betting Page
            await liveBettingPage.NavigateToLiveBettingPage();

            // Step 2: Add a Pick to Betslip
            string pickText = await liveBettingPage.AddPickToBetslip();

            // Step 3: Validate Pick is in Betslip
            bool isInBetslip = await betslipPage.IsPickInBetslip(pickText);
            Assert.IsTrue(isInBetslip, $"The pick '{pickText}' was not added to the Betslip.");
        }
    }
}
