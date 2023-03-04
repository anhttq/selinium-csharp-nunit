using CoreFramework.DriverCore;
using CoreFramework.Reporter;
using NUnit.Framework.Interfaces;
using NUnit.Framework;
using AventStack.ExtentReports.Configuration;
using CoreFramework.Configs;

namespace CoreFramework.NUnitTestSetup;

[TestFixtureSource(typeof(CrossBrowserData),
    nameof(CrossBrowserData.BrowserConfiguration))]
public class NUnitTestSetup
{
    protected WebDriverAction? DriverBaseAction;
    private readonly string Device = "PC";
    private readonly string Category = "Phase2_TestProject";
    protected ConfigManager? ConfigManager_;

    private readonly string _browser;
    private readonly int _width;
    private readonly int _height;

    public NUnitTestSetup(string browser)
    {
        _browser = browser;
    }

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        HtmlReport.CreateReport();
        HtmlReport.CreateTest(TestContext.CurrentContext.Test.ClassName).AssignDevice(Device).AssignCategory(Category);
        HtmlReportDirectory.InitBaselineConfigDirectories(_browser);
    }

    [SetUp]
    public void SetUp()
    {
        HtmlReport.CreateNode(TestContext.CurrentContext.Test.ClassName, TestContext.CurrentContext.Test.Name);
        WebDriverManager.InitDriver(_browser);
    }

    [TearDown]
    public void TearDown()
    {
        TestStatus testStatus = TestContext.CurrentContext.Result.Outcome.Status;
        if (testStatus.Equals(TestStatus.Passed))
        {
            HtmlReport.Pass("PASSED: Test case passed");
        }
        else
        {
            HtmlReport.Fail("FAILED: Test errors: " + TestContext.CurrentContext.Result.Message, DriverBaseAction.TakeScreenShot());
        }
        WebDriverManager.CloseDriver();
    }
    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        HtmlReport.Flush();
    }
}

