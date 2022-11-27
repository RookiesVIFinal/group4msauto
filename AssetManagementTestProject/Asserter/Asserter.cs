using AssetManagementTestProject.DAO;
using FluentAssertions;
using CoreFramework.DriverCore;
using OpenQA.Selenium;
using NUnit.Framework;

namespace AssetManagementTestProject.Asserter;

public class Asserter : WebDriverAction
{
    public Asserter(IWebDriver? driver) : base(driver)
    {
    }


    // ------------------------------- CONVERTED JSON FLUENT ASSERTION -------------------------------

    public static void AssertListStringEquals(string actual, string expected)
    {
        // Compare two deserialized JSON strings
        AssertEquals(actual, expected);
        //actual.Should().BeEquivalentTo(expected);
    }
    // ------------------------------- DAO LIST WITH FLUENT ASSERTION -------------------------------

    public static void AssertUserListsEquals(List<UserDAO> actual, List<UserDAO> expected)
    {
        AssertEquals(actual, expected);
        //actual.Should().BeEquivalentTo(expected);
    }
    public static void AssertAssignmentListsEquals(List<AssignmentDAO> actual, List<AssignmentDAO> expected)
    {
        AssertEquals(actual, expected);
        //actual.Should().BeEquivalentTo(expected);
    }
    public static void AssertAssetListsEquals(List<AssetDAO> actual, List<AssetDAO> expected)
    {
        AssertEquals(actual, expected);
        //actual.Should().BeEquivalentTo(expected);
    }
    public static void AssertReturningListsEquals(List<ReturningDAO> actual, List<ReturningDAO> expected)
    {
        AssertEquals(actual, expected);
        //actual.Should().BeEquivalentTo(expected);
    }
    public static void AssertReportListsEquals(List<ReportDAO> actual, List<ReportDAO> expected)
    {
        AssertEquals(actual, expected);
        //actual.Should().BeEquivalentTo(expected);
    }
    // ------------------------------- DAO WITH FLUENT EQUAL ASSERTION -------------------------------
    public static void AssertUserEquals(UserDAO actual, UserDAO expected)
    {
        AssertEquals(actual, expected);
        //actual.Should().BeEquivalentTo(expected);
    }
    public static void AssertAssignmentEquals(AssignmentDAO actual, AssignmentDAO expected)
    {
        AssertEquals(actual, expected);
        //actual.Should().BeEquivalentTo(expected);
    }
    public static void AssertAssetListsEquals(AssetDAO actual, AssetDAO expected)
    {
        AssertEquals(actual, expected);
        //actual.Should().BeEquivalentTo(expected);
    }
    public static void AssertReturningListsEquals(ReturningDAO actual, ReturningDAO expected)
    {
        AssertEquals(actual, expected);
        //actual.Should().BeEquivalentTo(expected);
    }
    public static void AssertReportListsEquals(ReportDAO actual, ReportDAO expected)
    {
        AssertEquals(actual, expected);
        //actual.Should().BeEquivalentTo(expected);
    }

    // ------------------------------- DAO WITH FLUENT EQUAL ASSERTION -------------------------------
    public static void AssertUserListAscending(List<UserDAO> list)
    {
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


    // ------------------------------- IN CASE FLUENT ASSERTION FAILS -------------------------------
    //public static void AssertListEquals<TE, TA>(Action<TE, TA> asserter, 
    //    IEnumerable<TE> expected, IEnumerable<TA> actual)
    //{
    //    // Allow user to freely define that on which properties you want to do the assertions:
    //    IList<TA> actualList = actual.ToList();
    //    IList<TE> expectedList = expected.ToList();

    //    Assert.True(
    //        actualList.Count == expectedList.Count,
    //        $"Lists have different sizes. Expected list: {expectedList.Count}, actual list: {actualList.Count}");

    //    for (var i = 0; i < expectedList.Count; i++)
    //    {
    //        try
    //        {
    //            asserter.Invoke(expectedList[i], actualList[i]);
    //        }
    //        catch (Exception e)
    //        {
    //            Assert.True(false, $"Assertion failed because: {e.Message}");
    //        }
    //    }
    //}

}
