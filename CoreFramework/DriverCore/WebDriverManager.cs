using System.Drawing;
using CoreFramework.Configs;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;

namespace CoreFramework.DriverCore;

public class WebDriverManager
{
    public static AsyncLocal<IWebDriver> _driver = new AsyncLocal<IWebDriver>();

    public static IWebDriver? CreateLocalDriver(string browser,
        int? screenWidth = null, int? screenHeight = null)
    {
        IWebDriver? LocalDriver = null;
        switch (browser)
        {
            case "chrome":
                //ChromeOptions options = new ChromeOptions();
                //options.AddArgument("--headless");
                LocalDriver = new ChromeDriver();
                break;
            case "firefox":
                LocalDriver = new FirefoxDriver();
                break;
            case "safari":
                LocalDriver = new SafariDriver();
                break;
        }
        LocalDriver.Manage().Window.Maximize();
        LocalDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        return LocalDriver;
    }
    public static IWebDriver? CreateRemoteDriver(string browser)
    {
        Uri DOCKER_GRID_HUB_URI = new Uri("http://localhost:4444/wd/hub");
        RemoteWebDriver? RemoteDriver;
        switch (browser)
        {
            case "chrome":
                ChromeOptions chromeCapability = new ChromeOptions
                {
                    BrowserVersion = "",
                    PlatformName = "LINUX",
                };
                chromeCapability.AddArgument("--start-maximized");
                RemoteDriver = new RemoteWebDriver(DOCKER_GRID_HUB_URI, chromeCapability.ToCapabilities());
                break;
            case "firefox":
                FirefoxOptions firefoxCapability = new FirefoxOptions
                {
                    BrowserVersion = "",
                    PlatformName = "LINUX",
                };
                firefoxCapability.AddArgument("--start-maximized");
                RemoteDriver = new RemoteWebDriver(DOCKER_GRID_HUB_URI, firefoxCapability.ToCapabilities());
                break;
            default:
                throw new ArgumentException($"{browser} is not supported remotely.");
        }
        return RemoteDriver;
    }
    public static void InitDriver(string browser, int? width = null, int? height = null)
    {
        FrameworkConfiguration frameworkConfiguration = ConfigManager.GetConfig<FrameworkConfiguration>("Framework");
        IWebDriver newDriver = null;
        if (frameworkConfiguration.ExecuteLocation.Equals("local"))
        {
            newDriver = CreateLocalDriver(browser, width, height);

            if (newDriver == null)
                throw new Exception($"{browser} browser is not supported locally");
            _driver.Value = newDriver;
        }
        else if (frameworkConfiguration.ExecuteLocation.Equals("docker"))
        {
            newDriver = CreateRemoteDriver(browser);
            if (newDriver == null)
                throw new Exception($"{browser} browser is not supported on Docker");
            _driver.Value = newDriver;
        }
        else
        {
            throw new Exception($"{frameworkConfiguration.ExecuteLocation} is invalid. Choose 'local' or 'docker'.");
        }

    }

    public static IWebDriver GetCurrentDriver()
    {
        return _driver.Value;
    }

    public static void CloseDriver()
    {
        if (_driver.Value != null)
        {
            _driver.Value.Quit();
            _driver.Value.Dispose();
        } 
    }
}

