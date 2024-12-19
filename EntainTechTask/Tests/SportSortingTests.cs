using NUnit.Framework;
using LiveBettingTests.PageObjects;

namespace LiveBettingTests.Tests
{
    [TestFixture]
    public class SportSortingTests : BaseTest
    {
        [Test]
        public async Task VerifySportSelectionLoadsCorrectPage()
        {
            var sportSelectionPage = new SportSelectionPage(page);
            string sportName = "Tennis";

            // Step 1: Select Sport
            await sportSelectionPage.SelectSport(sportName);

            // Step 2: Verify the Page is Loaded
            bool isLoaded = await sportSelectionPage.IsSportPageLoaded(sportName);
            Assert.IsTrue(isLoaded, $"The {sportName} sport page was not loaded successfully.");
        }
    }
}
