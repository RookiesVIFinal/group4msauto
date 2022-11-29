using AssetManagementTestProject.DAO;
using FluentAssertions;
using CoreFramework.DriverCore;
using OpenQA.Selenium;
using NUnit.Framework;

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


    #region STRING FLUENT ASSERTION
    public static void AssertStringEquals(string actual, string expected)
    {
        AssertEquals(actual, expected);
    }
    #endregion


    #region DAO LIST WITH FLUENT ASSERTION
    public static void AssertUserListsEquals(List<UserDAO> actual, List<UserDAO> expected)
    {
        AssertEquals(actual, expected);
        //actual.Should().BeEquivalentTo(expected);
    }
    public static void AssertAssignmentListsEquals(List<AssignmentDAO> actual, List<AssignmentDAO> expected)
    {
        AssertEquals(actual, expected);
    }
    public static void AssertAssetListsEquals(List<AssetDAO> actual, List<AssetDAO> expected)
    {
        AssertEquals(actual, expected);
    }
    public static void AssertReturningListsEquals(List<ReturningDAO> actual, List<ReturningDAO> expected)
    {
        AssertEquals(actual, expected);
    }
    public static void AssertReportListsEquals(List<ReportDAO> actual, List<ReportDAO> expected)
    {
        AssertEquals(actual, expected);
    }

    #endregion


    #region DAO WITH FLUENT EQUAL ASSERTION
    public static void AssertUserEquals(UserDAO actual, UserDAO expected)
    {
        AssertEquals(actual, expected);
    }
    public static void AssertAssignmentEquals(AssignmentDAO actual, AssignmentDAO expected)
    {
        AssertEquals(actual, expected);
    }
    public static void AssertAssetListsEquals(AssetDAO actual, AssetDAO expected)
    {
        AssertEquals(actual, expected);
    }
    public static void AssertReturningListsEquals(ReturningDAO actual, ReturningDAO expected)
    {
        AssertEquals(actual, expected);
    }
    public static void AssertReportListsEquals(ReportDAO actual, ReportDAO expected)
    {
        AssertEquals(actual, expected);
    }

    #endregion


    #region DAO WITH FLUENT EQUAL ASSERTION
    public static void AssertUserListAscending(List<UserDAO> list)
    {
        /// TODO: Make this as a WebDriverAction method
        list.Should().BeInAscendingOrder();
        TestContext.WriteLine("List is sorted in ascending order");
    }
    public static void AssertUserListDescending(List<UserDAO> list)
    {
        list.Should().BeInDescendingOrder();
        TestContext.WriteLine("List is sorted in descending order");

    }
    public static void AssertAssignmentListAscending(List<AssignmentDAO> list)
    {
        list.Should().BeInAscendingOrder();
        TestContext.WriteLine("List is sorted in ascending order");
    }
    public static void AsserAssignmentListDescending(List<AssignmentDAO> list)
    {
        list.Should().BeInDescendingOrder();
        TestContext.WriteLine("List is sorted in descending order");

    }
    public static void AssertAssetListAscending(List<AssetDAO> list)
    {
        list.Should().BeInAscendingOrder();
        TestContext.WriteLine("List is sorted in ascending order");
    }
    public static void AssertAssetListDescending(List<AssetDAO> list)
    {
        list.Should().BeInDescendingOrder();
        TestContext.WriteLine("List is sorted in descending order");

    }
    public static void AssertReturningListAscending(List<ReturningDAO> list)
    {
        list.Should().BeInAscendingOrder();
        TestContext.WriteLine("List is sorted in ascending order");
    }
    public static void AssertReturningListDescending(List<ReturningDAO> list)
    {
        list.Should().BeInDescendingOrder();
        TestContext.WriteLine("List is sorted in descending order");

    }
    public static void AssertReportListAscending(List<ReportDAO> list)
    {
        list.Should().BeInAscendingOrder();
        TestContext.WriteLine("List is sorted in ascending order");
    }
    public static void AssertReportListDescending(List<ReportDAO> list)
    {
        list.Should().BeInDescendingOrder();
        TestContext.WriteLine("List is sorted in descending order");

    }

    #endregion
}


