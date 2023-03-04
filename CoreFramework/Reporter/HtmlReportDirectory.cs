using CoreFramework.Utilities;

namespace CoreFramework.Reporter;
public class HtmlReportDirectory
{
    public static string? REPORT_ROOT { get; set; }
    public static string? REPORT_FOLDER_PATH { get; set; }
    public static string? REPORT_FILE_PATH { get; set; }
    public static string? SCREENSHOT_PATH { get; set; }
    public static string? SCREENSHOT_PATH_CONFIG { get; set; }
    public static string? SCREENSHOT_PATH_SCREENSIZE { get; set; }
    public static string? ACTUAL_SCREENSHOT_PATH { get; set; }
    public static string? ACTUAL_SCREENSHOT_PATH_CONFIG_BROWSER { get; set; }
    public static string? ACTUAL_SCREENSHOT_PATH_CONFIG_SCREENSIZE { get; set; }
    public static string? DIFFERENCE_SCREENSHOT_PATH { get; set; }
    public static string? DIFFERENCE_SCREENSHOT_PATH_CONFIG_BROWSER { get; set; }
    public static string? DIFFERENCE_SCREENSHOT_PATH_CONFIG_SCREENSIZE { get; set; }

    public static string? BASELINE_SCREENSHOT_PATH { get; set; }
    public static string? BASELINE_SCREENSHOT_PATH_CONFIG_BROWSER { get; set; }
    public static string? BASELINE_SCREENSHOT_PATH_CONFIG_SCREENSIZE { get; set; }

    public static string? BASELINE_IMAGE_FILE_PATH { get; private set; }
    public static string? DIFFERENCE_IMAGE_FILE_PATH { get; private set; }
    public static string? MERGED_IMAGE_FILE_PATH { get; private set; }
    public static string? ACTUAL_IMAGE_FILE_PATH { get; private set; }


    public static void InitReportDirectories()
    {
        string projectPath = FilePaths.GetCurrentDirectoryPath();
        REPORT_ROOT = projectPath + "\\reports";
        REPORT_FOLDER_PATH = REPORT_ROOT + "\\latest_reports";
        REPORT_FILE_PATH = REPORT_FOLDER_PATH + "\\report.html";
        SCREENSHOT_PATH = REPORT_FOLDER_PATH + "\\screenshot";
        ACTUAL_SCREENSHOT_PATH = REPORT_FOLDER_PATH + "\\actual_screenshot";
        DIFFERENCE_SCREENSHOT_PATH = REPORT_FOLDER_PATH + "\\difference_screenshot";
        BASELINE_SCREENSHOT_PATH = FilePaths.GetCurrentDirectoryPath() + "\\Resource\\Baseline";

        FilePaths.CreateFolderIfNotExists(REPORT_ROOT);
        CheckExistReportAndRename(REPORT_FOLDER_PATH); // Check if latest report exists
        FilePaths.CreateFolderIfNotExists(REPORT_FOLDER_PATH);
        FilePaths.CreateFolderIfNotExists(SCREENSHOT_PATH);
        FilePaths.CreateFolderIfNotExists(ACTUAL_SCREENSHOT_PATH);
        FilePaths.CreateFolderIfNotExists(DIFFERENCE_SCREENSHOT_PATH);
        FilePaths.CreateFolderIfNotExists(BASELINE_SCREENSHOT_PATH);
    }
    private static void CheckExistReportAndRename(string reportFolder)
    {
        if (Directory.Exists(reportFolder))
        {
            DirectoryInfo dirInfo = new DirectoryInfo(reportFolder);
            var newPath = REPORT_ROOT + "\\report_" + dirInfo.CreationTime.
                ToString().Replace(":", ".").Replace("/", "-");
            Directory.Move(reportFolder, newPath);
        }
    }
    public static void InitBaselineConfigDirectories(string browserConfig)
    {
        BASELINE_SCREENSHOT_PATH_CONFIG_BROWSER = HtmlReportDirectory.BASELINE_SCREENSHOT_PATH + "\\" + browserConfig;
        FilePaths.CreateFolderIfNotExists(HtmlReportDirectory.BASELINE_SCREENSHOT_PATH_CONFIG_BROWSER);
    }
    public static void InitReportConfigDirectories(string browsername, int browserWidth, int browserHeight)
    {
        // Setup path to ss for each browser config
        ACTUAL_SCREENSHOT_PATH_CONFIG_BROWSER = HtmlReportDirectory.ACTUAL_SCREENSHOT_PATH + "\\" + browsername;
        DIFFERENCE_SCREENSHOT_PATH_CONFIG_BROWSER = HtmlReportDirectory.DIFFERENCE_SCREENSHOT_PATH + "\\" + browsername;
        SCREENSHOT_PATH_CONFIG = HtmlReportDirectory.SCREENSHOT_PATH + "\\" + browsername;

        ACTUAL_SCREENSHOT_PATH_CONFIG_SCREENSIZE = ACTUAL_SCREENSHOT_PATH_CONFIG_BROWSER + "\\" + (browserWidth + "x" + browserHeight);
        DIFFERENCE_SCREENSHOT_PATH_CONFIG_SCREENSIZE = DIFFERENCE_SCREENSHOT_PATH_CONFIG_BROWSER + "\\" + (browserWidth + "x" + browserHeight);
        SCREENSHOT_PATH_SCREENSIZE = SCREENSHOT_PATH_CONFIG + "\\" + (browserWidth + "x" + browserHeight);

        FilePaths.CreateFolderIfNotExists(ACTUAL_SCREENSHOT_PATH_CONFIG_BROWSER);
        FilePaths.CreateFolderIfNotExists(DIFFERENCE_SCREENSHOT_PATH_CONFIG_BROWSER);
        FilePaths.CreateFolderIfNotExists(SCREENSHOT_PATH_CONFIG);

        FilePaths.CreateFolderIfNotExists(ACTUAL_SCREENSHOT_PATH_CONFIG_SCREENSIZE);
        FilePaths.CreateFolderIfNotExists(DIFFERENCE_SCREENSHOT_PATH_CONFIG_SCREENSIZE);
        FilePaths.CreateFolderIfNotExists(SCREENSHOT_PATH_SCREENSIZE);
    }
}

