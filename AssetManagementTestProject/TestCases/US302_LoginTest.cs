using AssetManagementTestProject.PageObj;
using AssetManagementTestProject.TestSetup;
using NUnit.Framework;
using ServiceStack;

namespace AssetManagementTestProject.TestCases;

public class US302_LoginTest : NUnitWebTestSetup
{
    public US302_LoginTest(string browser) : base(browser)
    {
    }
    //[Test, Order(3)]
    //[Category("DemoTest_1")]
    //public void TC01_UserLoginSuccess()
    //{
    //    LoginPage?.Login(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD);
    //    DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
    //    Asserter?.AssertElementIsDisplayed(HomePage.HeaderHomePage);
    //}
    [Test]
    [Category("TestImageComparison")]
    public void TestGuruLogo()
    {
        // Thread.Sleep(2000);
        DriverBaseAction?.WaitToBeVisible(Guru99Page.LogoPath);
        Assert.True(DriverBaseAction.CompareImages(Guru99Page.TestingPath, "testing", 90));
        Assert.True(DriverBaseAction.CompareImages(Guru99Page.LogoPath, "logo", 90));
    }
}
