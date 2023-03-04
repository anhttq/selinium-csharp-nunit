using AssetManagementTestProject.TestData;
using CoreFramework.DriverCore;

namespace AssetManagementTestProject.PageObj;

public class CreateNewCategoryPage : WebDriverAction
{
    #region CHANGE PASSWORD
    public readonly string TfCategoryName = "//input[@id='name']";
    public readonly string TfCategoryPrefix = "//input[contains(@id, 'prefix')]";
    public readonly string BtnSaveNewCategory = "(//span[text()='Save'])[2]";
    public readonly string BtnClose = "//button[@aria-label='Close']";
    public readonly string BtnCreateNewCategory = "//span[text()='Add New Category']";
    public readonly string BtnCloseAfterCreateSuccess = "//span[text()='Close']";
    #endregion
    public readonly string MsgCreateCategorySuccess = "//p[text()='New Category is created successfully!']";
    #region ERROR MESSAGES
    public readonly string ErrorMsgInvalidName = "//div[text()='Category name length should be 6 - 50 characters!']";
    public readonly string ErrorMsgInvalidPrefixOnlyUpperCase = "//div[text()='Prefix should contain only uppercase alphabetic characters!']";
    public readonly string ErrorMsgInvalidPrefixInvalidLength = "//div[text()='Prefix length should be 2 - 8 characters!']";

    #endregion

    public CreateNewCategoryPage() : base()
    {
    }
    public void CreateNewCategory(string validName, string validPrefix)
    {
        SendKeys(TfCategoryName, validName);
        SendKeys(TfCategoryPrefix, validPrefix);
        Click(BtnSaveNewCategory);
        WaitToBeVisible(MsgCreateCategorySuccess);
        Click(BtnCloseAfterCreateSuccess);
    }
    public void SendInvalidInfo(string invalidName, string invalidPrefix)
    {
        SendKeys(TfCategoryName, invalidName);
        SendKeys(TfCategoryPrefix, invalidPrefix);
    }
}

