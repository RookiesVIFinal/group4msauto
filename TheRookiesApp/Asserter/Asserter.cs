using Core_Framework.DriverCore;
using FluentAssertions;
using NUnit.Framework;
using TheRookiesApp.DAO;

namespace AssetManagementTestProject.Asserter;
/// <summary>
/// Assertions for strings/DAO/List DAO objects
/// Also check order
/// Alternatives if FluentAssertions fails
/// </summary>
public class Asserter : WebDriverBase
{
    public Asserter() : base()
    {
    }

    #region CONVERTED JSON FLUENT ASSERTION

    public static void AssertListStringEquals(string actual, string expected)
    {
        // Compare two deserialized JSON strings
        AssertEquals(actual, expected);
        //actual.Should().BeEquivalentTo(expected);
    }
    #endregion

    #region DAO LIST WITH FLUENT ASSERTION
    public static void AssertUserListsEquals(List<UserListDAO> actual, List<UserListDAO> expected)
    {
        AssertEquals(actual, expected);
        //actual.Should().BeEquivalentTo(expected);
    }
    public static void AssertAssignmentListsEquals(List<AssignmentListDAO> actual, List<AssignmentListDAO> expected)
    {
        AssertEquals(actual, expected);
        //actual.Should().BeEquivalentTo(expected);
    }
    public static void AssertAssetListsEquals(List<AssetListDAO> actual, List<AssetListDAO> expected)
    {
        AssertEquals(actual, expected);
        //actual.Should().BeEquivalentTo(expected);
    }
    public static void AssertReturningListsEquals(List<ReturningListDAO> actual, List<ReturningListDAO> expected)
    {
        AssertEquals(actual, expected);
        //actual.Should().BeEquivalentTo(expected);
    }
    public static void AssertReportListsEquals(List<ReportListDAO> actual, List<ReportListDAO> expected)
    {
        AssertEquals(actual, expected);
        //actual.Should().BeEquivalentTo(expected);
    }
    #endregion

    #region DAO WITH FLUENT EQUAL ASSERTION
    public static void AssertUserEquals(UserListDAO actual, UserListDAO expected)
    {
        AssertEquals(actual, expected);
        //actual.Should().BeEquivalentTo(expected);
    }
    public static void AssertAssignmentEquals(AssignmentListDAO actual, AssignmentListDAO expected)
    {
        AssertEquals(actual, expected);
        //actual.Should().BeEquivalentTo(expected);
    }
    public static void AssertAssetListsEquals(AssetListDAO actual, AssetListDAO expected)
    {
        AssertEquals(actual, expected);
        //actual.Should().BeEquivalentTo(expected);
    }
    public static void AssertReturningListsEquals(ReturningListDAO actual, ReturningListDAO expected)
    {
        AssertEquals(actual, expected);
        //actual.Should().BeEquivalentTo(expected);
    }
    public static void AssertReportListsEquals(ReportListDAO actual, ReportListDAO expected)
    {
        AssertEquals(actual, expected);
        //actual.Should().BeEquivalentTo(expected);
    }
    #endregion

    #region DAO WITH FLUENT EQUAL ASSERTION
    public static void AssertUserListAscending(List<UserListDAO> list)
    {
        list.Should().BeInAscendingOrder();
        TestContext.WriteLine("List is sorted in ascending order");
    }
    public static void AssertUserListDescending(List<UserListDAO> list)
    {
        list.Should().BeInDescendingOrder();
        TestContext.WriteLine("List is sorted in descending order");

    }
    public static void AssertAssignmentListAscending(List<AssignmentListDAO> list)
    {
        list.Should().BeInAscendingOrder();
        TestContext.WriteLine("List is sorted in ascending order");
    }
    public static void AsserAssignmentListDescending(List<AssignmentListDAO> list)
    {
        list.Should().BeInDescendingOrder();
        TestContext.WriteLine("List is sorted in descending order");

    }
    public static void AssertAssetListAscending(List<AssetListDAO> list)
    {
        list.Should().BeInAscendingOrder();
        TestContext.WriteLine("List is sorted in ascending order");
    }
    public static void AssertAssetListDescending(List<AssetListDAO> list)
    {
        list.Should().BeInDescendingOrder();
        TestContext.WriteLine("List is sorted in descending order");

    }
    public static void AssertReturningListAscending(List<ReturningListDAO> list)
    {
        list.Should().BeInAscendingOrder();
        TestContext.WriteLine("List is sorted in ascending order");
    }
    public static void AssertReturningListDescending(List<ReturningListDAO> list)
    {
        list.Should().BeInDescendingOrder();
        TestContext.WriteLine("List is sorted in descending order");

    }
    public static void AssertReportListAscending(List<ReportListDAO> list)
    {
        list.Should().BeInAscendingOrder();
        TestContext.WriteLine("List is sorted in ascending order");
    }
    public static void AssertReportListDescending(List<ReportListDAO> list)
    {
        list.Should().BeInDescendingOrder();
        TestContext.WriteLine("List is sorted in descending order");

    }
    #endregion

    #region IN CASE FLUENT ASSERTION FAILS
    public static void AssertListEquals<TE, TA>(Action<TE, TA> asserter,
        IEnumerable<TE> expected, IEnumerable<TA> actual)
    {
        // Allow user to freely define that on which properties you want to do the assertions:
        IList<TA> actualList = actual.ToList();
        IList<TE> expectedList = expected.ToList();

        Assert.True(
            actualList.Count == expectedList.Count,
            $"Lists have different sizes. Expected list: {expectedList.Count}, actual list: {actualList.Count}");

        for (var i = 0; i < expectedList.Count; i++)
        {
            try
            {
                asserter.Invoke(expectedList[i], actualList[i]);
            }
            catch (Exception e)
            {
                Assert.True(false, $"Assertion failed because: {e.Message}");
            }
        }
    }
    #endregion

}