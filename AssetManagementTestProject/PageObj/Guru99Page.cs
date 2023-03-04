using CoreFramework.DriverCore;

namespace AssetManagementTestProject.PageObj;
public class Guru99Page : WebDriverAction
{
    public readonly string LogoPath = "//*[@alt='Guru99 Demo Sites']";
    public readonly string TestingPath = "//td[@width='20%'][1]";
    public Guru99Page() : base()
    {
    }
}
