using AventStack.ExtentReports.MarkupUtils;
using CoreFramework.APICore;
using CoreFramework.DriverCore;
using CoreFramework.Utilities;
using NUnit.Framework;

namespace CoreFramework.Reporter.ExtentMarkup;

public class ImageCompareLog : IMarkup
{
    private ImageProcessor _imageProcessor { get; set; }
    private string _imageName;
    public ImageCompareLog(string imageName, ImageProcessor imageProcessor)
    {
        _imageProcessor = imageProcessor;
        _imageName = imageName;

    }

    public string GetMarkup()
    {
        string log = $@"
                    <table>
                        <tbody>
                          <tr>
                            <p>[{WebDriverAction.GetDateTimeStamp()}] Actual image [{_imageName}] does not match with baseline image with 
                                    similarity rate of [{Math.Round(WebDriverAction.SimilarRate)}%]</p>
                          </tr>
                          <tr>
                            <td>Baseline</td>
                            <td>Actual</td>
                            <td>Difference</td>
                           </tr>
                           <tr>
                            <td>
                                <img class=""r-img"" title="""" onerror=""this.style.display=&quot;none&quot;"" 
                                    data-featherlight=""{Path.GetRelativePath(HtmlReportDirectory.REPORT_FOLDER_PATH, 
                                        WebDriverAction.BaselineImgFilePath)}"" 
                                    src=""{Path.GetRelativePath(HtmlReportDirectory.REPORT_FOLDER_PATH, 
                                        WebDriverAction.BaselineImgFilePath)}"" 
                                    data-src=""{Path.GetRelativePath(HtmlReportDirectory.REPORT_FOLDER_PATH, 
                                        WebDriverAction.BaselineImgFilePath)}"">
                            </td>
                            <td>
                                <img class=""r-img"" title="""" onerror=""this.style.display=&quot;none&quot;"" 
                                    data-featherlight=""{Path.GetRelativePath(HtmlReportDirectory.REPORT_FOLDER_PATH, 
                                        WebDriverAction.ActualImgFilePath)}"" 
                                    src=""{Path.GetRelativePath(HtmlReportDirectory.REPORT_FOLDER_PATH, 
                                        WebDriverAction.ActualImgFilePath)}"" 
                                    data-src=""{Path.GetRelativePath(HtmlReportDirectory.REPORT_FOLDER_PATH, 
                                        WebDriverAction.ActualImgFilePath)}"">
                            </td>
                            <td>
                                <img class=""r-img"" title="""" onerror=""this.style.display=&quot;none&quot;"" 
                                    data-featherlight=""{Path.GetRelativePath(HtmlReportDirectory.REPORT_FOLDER_PATH, 
                                        WebDriverAction.MergedImgFilePath)}"" 
                                    src=""{Path.GetRelativePath(HtmlReportDirectory.REPORT_FOLDER_PATH, 
                                        WebDriverAction.MergedImgFilePath)}"" 
                                    data-src=""{Path.GetRelativePath(HtmlReportDirectory.REPORT_FOLDER_PATH, 
                                        WebDriverAction.MergedImgFilePath)}"">
                            </td>
                          </tr>
                        <tbody>
                    </table>
                    ";
        return log;
    }
}



