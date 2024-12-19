using NUnit.Framework;
using LiveBettingTests.PageObjects;

namespace LiveBettingTests.Tests
{
    [TestFixture]
    public class LiveOddsTests : BaseTest
    {
        [Test]
        public async Task VerifyLiveOddsAreUpdated()
        {
            var liveBettingPage = new LiveBettingPage(page);

            // Step 1: Navigate to Live Betting Page
            await liveBettingPage.NavigateToLiveBettingPage();

            // Step 2: Capture Initial Odds
            string initialOdds = await liveBettingPage.CaptureOdds();

            // Step 3: Wait for Odds Change
            await liveBettingPage.WaitForOddsChange();

            // Step 4: Verify Odds Have Changed
            string updatedOdds = await liveBettingPage.CaptureOdds();
            Assert.AreNotEqual(initialOdds, updatedOdds, "The odds did not update dynamically.");
        }
    }
}
