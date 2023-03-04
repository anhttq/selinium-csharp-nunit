using CoreFramework.DriverCore;
using CoreFramework.Reporter;
using CoreFramework.Utilities;
using Emgu.CV;
using FluentAssertions;

namespace CoreFramework.Asserter;

public class Asserter : WebDriverAction
{
    public Asserter() : base()
    {
    }
    #region ELEMENT DISPLAY ASSERTION
    public void AssertElementIsDisplayed(string locator)
    {
        try
        {
            VerifyElementIsDisplayed(locator).Should().BeTrue();
            HtmlReport.Pass("[" + GetDateTimeStamp() + "] Element [" + locator + "] is displayed");
        }
        catch (Exception excep)
        {
            HtmlReport.Fail("[" + GetDateTimeStamp() + "] Element is not displayed");
            throw excep;
        }
    }
    #endregion

    #region CHECK EQUALS
    public void AssertObjectsEquals(object actual, object expected)
    {
        try
        {
            actual.Should().BeEquivalentTo(expected);
            HtmlReport.Pass("[" + GetDateTimeStamp() + "] Actual data ["
            + actual.ToString() + "] matches " +
                "with expected data [" + expected.ToString() + "]");
        }
        catch (Exception excep)
        {
            HtmlReport.Fail("[" + GetDateTimeStamp() + "] Actual data ["
            + actual + "] does not match " +
                "with expected data [" + expected + "]");
            // Exception excep = new Exception("Two objects are not equal.");
            throw excep;
        }
    }

    #endregion

    #region CHECK ORDER
    public void AssertListAscending(List<string> list)
    {
        try
        {
            list.Should().BeInAscendingOrder();
            HtmlReport.Pass("[" + GetDateTimeStamp() + "] List is sorted in ascending order"
            + list.ToString());
        }
        catch (Exception excep)
        {
            HtmlReport.Fail("[" + GetDateTimeStamp() + "] List is not sorted in ascending order"
            + list.ToString());
            throw excep;
        }
    }
    public void AssertListDescending(List<string> list)
    {
        try
        {
            list.Should().BeInDescendingOrder();
            HtmlReport.Pass("[" + GetDateTimeStamp() + "] List is sorted in descending order"
            + list.ToString());
        }
        catch (Exception excep)
        {
            HtmlReport.Fail("[" + GetDateTimeStamp() + "] List is not sorted in descending order"
            + list.ToString());
            throw excep;
        }
    }
    #endregion
}
