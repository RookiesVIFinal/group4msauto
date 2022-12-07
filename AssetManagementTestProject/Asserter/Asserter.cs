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
    #region STRING FLUENT ASSERTION
    public void AssertUrlsEquals(string actual, string expected)
    {
        AssertEquals(actual, expected);
    }
    #endregion
    #region ELEMENT DISPLAY ASSERTION
    public void AssertElementIsDisplayed(string locator)
    {
        IsElementDisplayed(locator).Should().BeTrue();
    }
    #endregion

    #region CHECK EQUALS
    public void AssertViewUserEquals(ViewUserDAO.ViewUserInList actual, ViewUserDAO.ViewUserInList expected)
    {
        AssertEquals(actual, expected);
    }
    public void AssertDetailedUserEquals(ViewUserDAO.ViewDetailedUser actual, ViewUserDAO.ViewDetailedUser expected)
    {
        AssertEquals(actual, expected);
    }

    #endregion

    #region CHECK ORDER
    public void AssertUserListAscending(List<ViewUserDAO.ViewUserInList> list)
    {
        list.Should().BeInAscendingOrder();
        TestContext.WriteLine("List is sorted in ascending order");
    }
    public void AssertUserListDescending(List<ViewUserDAO.ViewUserInList> list)
    {
        list.Should().BeInDescendingOrder();
        TestContext.WriteLine("List is sorted in descending order");

    }
    #endregion
}