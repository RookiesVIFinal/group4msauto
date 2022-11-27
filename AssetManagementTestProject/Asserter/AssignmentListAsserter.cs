//using AssetManagementTestProject.DAO;
//using NUnit.Framework;

//namespace AssetManagementTestProject.Asserter;

//public class AssignmentListAsserter
//{

//    public static void AssertViewAssignmentLists(IEnumerable<AssignmentDAO> expectedUsers, 
//        IEnumerable<AssignmentDAO> actualUsers)
//    {
//        // use when asserting two user list in ViewUser
//        Asserter.AssertListEquals((e, a) => AssertViewAssignment(e, a), expectedUsers, actualUsers);
//    }
//    public static void AssertViewAssignment(AssignmentDAO expected, AssignmentDAO actual)
//    {
//        // Use when asserting two users in ViewUser
//        Assert.That(expected.assetCode, Is.EqualTo(actual.assetCode));
//        Assert.That(expected.assetName, Is.EqualTo(actual.assetName));
//        Assert.That(expected.assignedTo, Is.EqualTo(actual.assignedTo));
//        Assert.That(expected.assignedBy, Is.EqualTo(actual.assignedBy));
//        Assert.That(expected.assignedDate, Is.EqualTo(actual.assignedDate));
//        Assert.That(expected.state, Is.EqualTo(actual.state));
//    }
//    public static void AssertDetailedAssignment(AssignmentDAO expected, AssignmentDAO actual)
//    {
//        // Use when asserting two users in ViewUser
//        Assert.That(expected.assetCode, Is.EqualTo(actual.assetCode));
//        Assert.That(expected.assetName, Is.EqualTo(actual.assetName));
//        Assert.That(expected.specification, Is.EqualTo(actual.specification));
//        Assert.That(expected.assignedTo, Is.EqualTo(actual.assignedTo));
//        Assert.That(expected.assignedBy, Is.EqualTo(actual.assignedBy));
//        Assert.That(expected.assignedDate, Is.EqualTo(actual.assignedDate));
//        Assert.That(expected.state, Is.EqualTo(actual.state));
//        Assert.That(expected.note, Is.EqualTo(actual.note));
//    }
//}
