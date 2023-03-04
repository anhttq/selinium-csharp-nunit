
public class Constant
{
    #region URLS
    public static string BASE_URL = "https://group4b6ms.azurewebsites.net/";
    public static string BASE_API = "https://group4b6msapi.azurewebsites.net/";
    #endregion
    #region DEFAULT ADMIN USERNAME-PW
    public const string ADMIN_USERNAME_HN = "adminhn";
    public const string ADMIN_USERNAME_HCM = "adminhcm";
    public const string ADMIN_PASSWORD = "Admin@1234";
    #endregion
    #region USER INFO
    public const string GENDER_MALE = "Male";
    public const string GENDER_FEMALE = "Female";
    public enum Genders
    {
        Male,
        Female
    }
    public const string ROLE_ADMIN = "Admin";
    public const string ROLE_STAFF = "Staff";
    public enum Roles
    {
        Admin,
        Staff
    }
    public const string LOCATION_HANOI = "HaNoi";
    public const string LOCATION_HCM = "HoChiMinh";
    public enum Locations
    {
        HaNoi,
        HoChiMinh
    }
    #endregion
    public const string USER_CAN_BE_DISABLED_MSG = "User can be disabled";

    public const string BASELINE_IMAGE_LOGO = @"C:\Users\anh.thaithiquynh\Pictures\baseline_logo.PNG";
}

