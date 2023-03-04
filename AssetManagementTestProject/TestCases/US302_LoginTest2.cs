using AssetManagementTestProject.PageObj;
using AssetManagementTestProject.TestSetup;
using NUnit.Framework;

namespace AssetManagementTestProject.TestCases;

public class US302_LoginTest2 : NUnitWebTestSetup
{
    public US302_LoginTest2(string browser) : base(browser)
    {
    }

    //[Test]
    //public void TC03_UserCanLoginWithNewPassword()
    //{
    //    LoginPage?.Login(NewAdminUsername, NewAdminPassword);
    //    ChangePw1stTime?.ChangePwFirstTimeLogIn(Constant.ADMIN_PASSWORD);
    //    DriverBaseAction?.WaitToBeVisible(HomePage.HeaderMyAssignment);
    //    HomePage?.SelectLogout();
    //    LogoutPopup?.LogOutOfPage();
    //    LoginPage?.Login(NewAdminUsername, Constant.ADMIN_PASSWORD);
    //    DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
    //    Asserter?.AssertElementIsDisplayed(HomePage.HeaderHomePage);
    //}
    //[Test]
    //public void TC04To07_StaffCanLoginToTheApp()
    //{
    //    LoginPage?.Login(LoginTestData.STAFF_USERNAME, LoginTestData.STAFF_PASSWORD);
    //    Asserter?.AssertElementIsDisplayed(MenuBarLeft.BtnHomeInMenu);
    //    Asserter?.AssertElementIsDisplayed(HomePage.HeaderMyAssignment);
    //}
    //[Test]
    //public void TC08To14_AdminCanLoginToTheApp()
    //{
    //    LoginPage?.Login(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD);
    //    Asserter?.AssertElementIsDisplayed(MenuBarLeft.BtnHomeInMenu);
    //    Asserter?.AssertElementIsDisplayed(MenuBarLeft.BtnManageUserInMenu);
    //    Asserter?.AssertElementIsDisplayed(MenuBarLeft.BtnManageAssetInMenu);
    //    Asserter?.AssertElementIsDisplayed(MenuBarLeft.BtnManageAssignmentInMenu);
    //    Asserter?.AssertElementIsDisplayed(MenuBarLeft.BtnManageReturningInMenu);
    //    Asserter?.AssertElementIsDisplayed(MenuBarLeft.BtnReportInMenu);
    //    Asserter?.AssertElementIsDisplayed(HomePage.HeaderMyAssignment);
    //    Asserter?.AssertElementIsDisplayed(HomePage.BtnAcceptAssignment);
    //    Asserter?.AssertElementIsDisplayed(HomePage.BtnDeclineAssignment);
    //    Asserter?.AssertElementIsDisplayed(HomePage.BtnRequestReturnAsset);
    //}

}
