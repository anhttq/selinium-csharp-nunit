using AssetManagementTestProject.DAO;
namespace AssetManagementTestProject.TestData
{
    public class CreateAssetData
    {
        public static CreateAssetDAO.CreateAssetUI NEW_ASSET_UI = new CreateAssetDAO.CreateAssetUI
        (
            "Macbook Pro",
            "Laptop",
            "AAAAAAAAAAAAAAAAAAAAAAAAAA",
            "2022/11/01",
            "Available"
        );
        public static CreateAssetDAO.CreateAssetUI INVALID_INFO = new CreateAssetDAO.CreateAssetUI
        (
            "M",
            "Laptop",
            "222",
            "2022/11/01",
            "Available"
        );
    }
}
