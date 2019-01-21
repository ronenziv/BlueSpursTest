using System.Configuration;

namespace BlueSpursTest.External.BESTBUYServices.Implementation
{
    /// <summary>Handle settings from config</summary>
    internal static class SettingsManager
    {
        private static string _BestBuyAPIKey;
        public static string BestBuyAPIKey
        {
            get
            {
                if (_BestBuyAPIKey == default(string))
                {
                    _BestBuyAPIKey = ConfigurationManager.AppSettings["BestBuyAPIKey"];
                }
                return _BestBuyAPIKey;
            }
        }
    }
}