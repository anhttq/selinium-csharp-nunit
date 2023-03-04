using AssetManagementTestProject.DAO;
using AssetManagementTestProject.TestSetup;
using CoreFramework.DriverCore;
using System.Globalization;

namespace AssetManagementTestProject.PageObj;
public class CreateAssetPage : WebDriverAction
{
    #region BUTTONS AND TEXT FIELDS
    public readonly string BtnSave = "//span[text()='Save']";
    public readonly string BtnCancel = "//span[text()='Cancel']";
    public readonly string BtnCloseAfterCreateSuccess = "//span[text()='Close']";
    public readonly string DatePickInstalledDate = "//input[contains(@id, 'formCreateAsset_installedDate')]";
    public readonly string DropBarCategory = "//input[@id='formCreateAsset_categoryId']";
    public readonly string TfName = "//input[contains(@id, 'formCreateAsset_name')]";
    public readonly string TfSpecification = "//textarea[contains(@id, 'formCreateAsset_specification')]";
    public string BtnState = "//span[text()='{0}']";
    public string OptionCategory = "//div[text()='{0}']";
    #endregion
    #region ERROR MESSAGES
    public readonly string ErrorMsgInvalidName = "//div[text()='Asset name length should be 6 - 50 characters']";
    public readonly string ErrorMsgInvalidSpecification = "//div[text()='Specification length should be 6 - 255 characters!']";
    #endregion
    
    public CreateAssetPage() : base()
    {
    }
    public void CreateNewAsset(CreateAssetDAO.CreateAssetUI assetInfo)
    {
        SendKeys(TfName, assetInfo.Name);
        SelectCategory(assetInfo.Category);
        InputSpecification(assetInfo.Specification);
        SelectInstalledDate(assetInfo.InstalledDate);
        SelectState(assetInfo.State);
        Click(BtnSave);
        Click(BtnCloseAfterCreateSuccess);
    }
    public void SendInvalidInfo(CreateAssetDAO.CreateAssetUI assetInfo)
    {
        SendKeys(TfName, assetInfo.Name);
        SelectCategory(assetInfo.Category);
        SendKeys(TfSpecification,assetInfo.Specification);
        SelectInstalledDate(assetInfo.InstalledDate);
        SelectState(assetInfo.State);
    }
    public void SelectDate(string dateTimeString, string dateField)
    {
        DateTime dateTime = DateTime.ParseExact(dateTimeString, "yyyy/MM/dd", CultureInfo.InvariantCulture);
        SendKeys(dateField, dateTime.ToString("yyyy/MM/dd"));
    }
    public void SelectInstalledDate(string dateTimeString)
    {
        SelectDate(dateTimeString, DatePickInstalledDate);
        PressEnter(DatePickInstalledDate);
    }
    public void InputSpecification(string specification)
    {
        WaitToBeVisible(TfSpecification);
        SendKeys(TfSpecification, specification);
    }
    public void SelectCategory(string category)
    {
        FindElementByXpath(DropBarCategory).Click();
        OptionCategory = string.Format(OptionCategory, category);
        Click(OptionCategory);
    }
    public void SelectState(string state)
    {
        BtnState = string.Format(BtnState, state);
        FindElementByXpath(BtnState).Click();
    }
    public string ReturnCategory(string category)
    {
        OptionCategory = string.Format(OptionCategory, category);
        return OptionCategory;
    }
}
