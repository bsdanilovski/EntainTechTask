using System.Text.Json;

namespace LiveBettingTests.Config
{
    public static class ConfigReader
    {
        private static JsonDocument _config;

        // Static constructor to load the configuration when class is first accessed
        static ConfigReader()
        {
            LoadConfig();
        }

        private static void LoadConfig()
        {
            // Resolve the absolute path of the TestConfig.json file
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var jsonFilePath = Path.Combine(baseDirectory, "TestData", "TestConfig.json");

            if (!File.Exists(jsonFilePath))
            {
                throw new FileNotFoundException($"Configuration file not found: {jsonFilePath}");
            }

            var jsonContent = File.ReadAllText(jsonFilePath);
            _config = JsonDocument.Parse(jsonContent);
        }

        public static string GetBaseUrl() =>
            _config.RootElement.GetProperty("BaseUrl").GetString();

        public static string GetBrowser() =>
            _config.RootElement.GetProperty("Browser").GetString();

        public static bool IsHeadless() =>
            _config.RootElement.GetProperty("Headless").GetBoolean();

        public static int GetTimeout() =>
            _config.RootElement.GetProperty("Timeout").GetInt32();

        public static (int Width, int Height) GetViewportSize(string device)
        {
            var viewport = _config.RootElement.GetProperty("Viewports").GetProperty(device);
            int width = viewport.GetProperty("Width").GetInt32();
            int height = viewport.GetProperty("Height").GetInt32();
            return (width, height);
        }

        public static List<string> GetSportsList()
        {
            var sports = _config.RootElement.GetProperty("Sports");
            var sportsList = new List<string>();

            foreach (var sport in sports.EnumerateArray())
            {
                sportsList.Add(sport.GetString());
            }

            return sportsList;
        }
    }
}
