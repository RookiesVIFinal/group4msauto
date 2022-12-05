using AssetManagementTestProject.DAO;
using FluentAssertions;
using CoreFramework.DriverCore;
using NUnit.Framework;
using System.Security;

namespace AssetManagementTestProject.Asserter;

public class Asserter : WebDriverAction
{
    /// <summary>
    /// Assertions for strings/DAO/List DAO objects
    /// Also check order
    /// Alternatives if FluentAssertions fails
    /// </summary>
    public Asserter() : base()
    {
    }
    #region URL FLUENT ASSERTION
    public void AssertUrlEquals(string actual, string expected)
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
        foreach(string locator in locators)
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
    public void AssertUserListsEquals(List<UserDAO> actual, List<UserDAO> expected)
    {
        AssertEquals(actual, expected);
    }
    public void AssertAssignmentListsEquals(List<AssignmentDAO> actual, List<AssignmentDAO> expected)
    {
        AssertEquals(actual, expected);
    }
    public void AssertAssetListsEquals(List<AssetDAO> actual, List<AssetDAO> expected)
    {
        AssertEquals(actual, expected);
    }
    public void AssertReturningListsEquals(List<ReturningDAO> actual, List<ReturningDAO> expected)
    {
        AssertEquals(actual, expected);
    }
    public void AssertReportListsEquals(List<ReportDAO> actual, List<ReportDAO> expected)
    {
        AssertEquals(actual, expected);
    }
    #endregion

    #region DAO WITH FLUENT EQUAL ASSERTION
    public void AssertUserEquals(UserDAO actual, UserDAO expected)
    {
        AssertEquals(actual, expected);
    }
    public void AssertAssignmentEquals(AssignmentDAO actual, AssignmentDAO expected)
    {
        AssertEquals(actual, expected);
    }
    public void AssertAssetListsEquals(AssetDAO actual, AssetDAO expected)
    {
        AssertEquals(actual, expected);
    }
    public void AssertReturningListsEquals(ReturningDAO actual, ReturningDAO expected)
    {
        AssertEquals(actual, expected);
    }
    public void AssertReportListsEquals(ReportDAO actual, ReportDAO expected)
    {
        AssertEquals(actual, expected);
    }

    #endregion


    #region DAO WITH FLUENT EQUAL ASSERTION
    public void AssertUserListAscending(List<UserDAO> list)
    {
        /// TODO: Make this as a WebDriverAction method
        list.Should().BeInAscendingOrder();
        TestContext.WriteLine("List is sorted in ascending order");
    }
    public void AssertUserListDescending(List<UserDAO> list)
    {
        list.Should().BeInDescendingOrder();
        TestContext.WriteLine("List is sorted in descending order");

    }
    public void AssertAssignmentListAscending(List<AssignmentDAO> list)
    {
        list.Should().BeInAscendingOrder();
        TestContext.WriteLine("List is sorted in ascending order");
    }
    public void AsserAssignmentListDescending(List<AssignmentDAO> list)
    {
        list.Should().BeInDescendingOrder();
        TestContext.WriteLine("List is sorted in descending order");

    }
    public void AssertAssetListAscending(List<AssetDAO> list)
    {
        list.Should().BeInAscendingOrder();
        TestContext.WriteLine("List is sorted in ascending order");
    }
    public void AssertAssetListDescending(List<AssetDAO> list)
    {
        list.Should().BeInDescendingOrder();
        TestContext.WriteLine("List is sorted in descending order");

    }
    public void AssertReturningListAscending(List<ReturningDAO> list)
    {
        list.Should().BeInAscendingOrder();
        TestContext.WriteLine("List is sorted in ascending order");
    }
    public void AssertReturningListDescending(List<ReturningDAO> list)
    {
        list.Should().BeInDescendingOrder();
        TestContext.WriteLine("List is sorted in descending order");

    }
    public void AssertReportListAscending(List<ReportDAO> list)
    {
        list.Should().BeInAscendingOrder();
        TestContext.WriteLine("List is sorted in ascending order");
    }
    public void AssertReportListDescending(List<ReportDAO> list)
    {
        list.Should().BeInDescendingOrder();
        TestContext.WriteLine("List is sorted in descending order");

    }

    #endregion
}


