using AssetManagementTestProject.DAO;
using CoreFramework.DriverCore;
using FluentAssertions;
using NUnit.Framework;

namespace AssetManagementTestProject.Asserter;

public class Asserter : WebDriverAction
{
    public Asserter() : base()
    {
    }
    #region URL FLUENT ASSERTION
    public void AssertUrlsEquals(string actual, string expected)
    {
        AssertEquals(actual, expected);
    }
    #endregion

    #region ELEMENTS DISPLAY FLUENT ASSERTION
    public void AssertElementIsDisplayed(string locator)
    {
        IsElementDisplayed(locator).Should().BeTrue();
    }

    public void AssertElementsAreDisplayed(List<string> locators)
    {
        foreach (string locator in locators)
        {
            AssertElementIsDisplayed(locator);
        }
    }
    #endregion

    #region STRING FLUENT ASSERTION
    public void AssertStringEquals(string actual, string expected)
    {
        AssertEquals(actual, expected);
    }

    #endregion
    #region DAO LIST WITH FLUENT ASSERTION
    public void AssertUserListsEquals(List<ViewUserDAO> actual, List<ViewUserDAO> expected)
    {
        AssertEquals(actual, expected);
    }
    #endregion

    #region DAO WITH FLUENT EQUAL ASSERTION
    public void AssertUserEquals(ViewUserDAO actual, ViewUserDAO expected)
    {
        AssertEquals(actual, expected);
    }
    #endregion


    #region DAO WITH FLUENT EQUAL ASSERTION
    public void AssertUserListAscending(List<ViewUserDAO> list)
    {
        /// TODO: Make this as a WebDriverAction method
        list.Should().BeInAscendingOrder();
        TestContext.WriteLine("List is sorted in ascending order");
    }
    public void AssertUserListDescending(List<ViewUserDAO> list)
    {
        list.Should().BeInDescendingOrder();
        TestContext.WriteLine("List is sorted in descending order");

    }
    #endregion
}


