using CoreFramework.Configs;
using NUnit.Framework;
using System.Collections;

namespace CoreFramework
{
    public class CrossBrowserData
    {
        public static IEnumerable LatestConfigurations
        {
            get
            {
                yield return new TestFixtureData("chrome");
                yield return new TestFixtureData("firefox");
            }
        }

        public static IEnumerable SimpleConfiguration
        {
            get 
            {
                yield return new TestFixtureData("chrome");
            }
        }

        public static IEnumerable BrowserConfiguration()
        {
            string browserDefault = ConfigManager.GetConfig<BrowserConfiguration>("BrowserConfig").BrowserConfig_;
            string browserType = TestContext.Parameters.Get("browserType", browserDefault);
                if (browserType.Equals("simple"))
                {
                    return SimpleConfiguration;
                }
                else
                {
                    return LatestConfigurations;
                }
        }

    }
}
