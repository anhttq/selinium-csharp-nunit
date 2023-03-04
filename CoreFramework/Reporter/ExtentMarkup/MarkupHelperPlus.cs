using AventStack.ExtentReports.MarkupUtils;
using CoreFramework.APICore;
using CoreFramework.Utilities;

namespace CoreFramework.Reporter.ExtentMarkup;
public class MarkupHelperPlus
{
    public static IMarkup CreateAPIRequestLog(APIRequest request)
    {
        return new APIRequestLog(request);
    }
    public static IMarkup CreateAPIResponseLog(APIRequest request, APIResponse response)
    {
        return new APIResponseLog(request, response);
    }

    public static IMarkup CreateImageCompareLog(string imageName, ImageProcessor imageProcessor)
    {
        return new ImageCompareLog(imageName, imageProcessor);
    }
}

