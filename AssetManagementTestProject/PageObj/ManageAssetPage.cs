using AssetManagementTestProject.DataFromUI;
using CoreFramework.DriverCore;
using static AssetManagementTestProject.DAO.ViewUserDAO;

namespace AssetManagementTestProject.PageObj;
public class ManageAssetPage : WebDriverAction
{
    public readonly string BtnCreateNewAsset = "//button[contains(@class, 'ant-btn css-1wismvm ant-btn-primary ant-btn-dangerous ml-3')]";
    public readonly string HeaderAssetList = "//h1[text()='Asset List']";
    public readonly string FirstRowOfAssetList = "(//tr[@class='ant-table-row ant-table-row-level-0'])[1]";
    public readonly string BtnEditAssetAtTop = "(//button[@class='ant-btn css-1wismvm ant-btn-default ant-btn-icon-only mr-2'])[1]";
    public readonly string PathManageAsset = "admin/manage-asset";
    public ManageAssetPage() : base()
    {
    }
}

