//using AssetManagementTestProject.DAO;
//using NUnit.Framework;

//namespace AssetManagementTestProject.Asserter;

//public class UserListAsserter
//{

//    public static void AssertViewUserLists(IEnumerable<UserDAO> expectedUsers, 
//        IEnumerable<UserDAO> actualUsers)
//    {
//        // use when asserting two user list in ViewUser
//        Asserter.AssertListEquals((e, a) => AssertViewUsers(e, a), expectedUsers, actualUsers);
//    }
//    public static void AssertViewUsers(UserDAO expected, UserDAO actual)
//    {
//        // Use when asserting two users in ViewUser
//        Assert.That(expected.staffCode, Is.EqualTo(actual.staffCode));
//        Assert.That(expected.fullName, Is.EqualTo(actual.fullName));
//        Assert.That(expected.userName, Is.EqualTo(actual.userName));
//        Assert.That(expected.joinedDate, Is.EqualTo(actual.joinedDate));
//        Assert.That(expected.type, Is.EqualTo(actual.type));
//    }
//    public static void AssertDetailedUsers(UserDAO expected, UserDAO actual)
//    {
//        // Use when asserting two users in ViewUser
//        Assert.That(expected.staffCode, Is.EqualTo(actual.staffCode));
//        Assert.That(expected.fullName, Is.EqualTo(actual.fullName));
//        Assert.That(expected.dateOfBirth, Is.EqualTo(actual.dateOfBirth));
//        Assert.That(expected.gender, Is.EqualTo(actual.gender));
//        Assert.That(expected.type, Is.EqualTo(actual.type));
//        Assert.That(expected.location, Is.EqualTo(actual.location));
//    }
//}
