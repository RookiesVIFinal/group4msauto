using CoreFramework.DriverCore;
using NUnit.Framework;
using TheRookiesApp.DAO;

namespace AssetManagementTestProject.Asserter;

public class AssignmentListAsserter : WebDriverBase
{
    public AssignmentListAsserter() : base()
    {
    }

    public static void AssertViewAssignmentLists(IEnumerable<AssignmentListDAO> expectedUsers,
    IEnumerable<AssignmentListDAO> actualUsers)
    {
        // use when asserting two user list in ViewUser
        Asserter.AssertListEquals((e, a) => AssertViewAssignment(e, a), expectedUsers, actualUsers);
    }
    public static void AssertViewAssignment(AssignmentListDAO expected, AssignmentListDAO actual)
    {
        // Use when asserting two users in ViewUser
        Assert.That(expected.AssetCode, Is.EqualTo(actual.AssetCode));
        Assert.That(expected.AssetName, Is.EqualTo(actual.AssetName));
        Assert.That(expected.AssignedTo, Is.EqualTo(actual.AssignedTo));
        Assert.That(expected.AssignedBy, Is.EqualTo(actual.AssignedBy));
        Assert.That(expected.AssignedDate, Is.EqualTo(actual.AssignedDate));
        Assert.That(expected.State, Is.EqualTo(actual.State));
    }
    public static void AssertDetailedAssignment(AssignmentListDAO expected, AssignmentListDAO actual)
    {
        // Use when asserting two users in ViewUser
        Assert.That(expected.AssetCode, Is.EqualTo(actual.AssetCode));
        Assert.That(expected.AssetName, Is.EqualTo(actual.AssetName));
        Assert.That(expected.Specification, Is.EqualTo(actual.Specification));
        Assert.That(expected.AssignedTo, Is.EqualTo(actual.AssignedTo));
        Assert.That(expected.AssignedBy, Is.EqualTo(actual.AssignedBy));
        Assert.That(expected.AssignedDate, Is.EqualTo(actual.AssignedDate));
        Assert.That(expected.State, Is.EqualTo(actual.State));
        Assert.That(expected.Note, Is.EqualTo(actual.Note));
    }
}