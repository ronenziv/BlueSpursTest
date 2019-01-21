using System.Configuration;

namespace BlueSpursTest.External.WALMARTServices.Implementation
{
    /// <summary>Handle settings from config</summary>
    internal static class SettingsManager
    {
        private static string _WallmartAPIKey;
        public static string WallmartAPIKey
        {
            get
            {
                if (_WallmartAPIKey == default(string))
                {
                    _WallmartAPIKey = ConfigurationManager.AppSettings["WallmartAPIKey"];
                }
                return _WallmartAPIKey;
            }
        }
    }
}