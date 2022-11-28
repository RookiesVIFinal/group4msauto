//using Core_Framework.DriverCore;
//using NUnit.Framework;
//using OpenQA.Selenium;
//using TheRookiesApp.DAO;

//namespace AssetManagementTestProject.Asserter;

//public class UserListAsserter : WebDriverBase
//{
//    public UserListAsserter(IWebDriver? driver) : base(driver)
//    {
//    }

//    public static void AssertViewUserLists(IEnumerable<UserListDAO> expectedUsers,
//        IEnumerable<UserListDAO> actualUsers)
//    {
//        // use when asserting two user list in ViewUser
//        Asserter.AssertListEquals((e, a) => AssertViewUsers(e, a), expectedUsers, actualUsers);
//    }
//    public static void AssertViewUsers(UserListDAO expected, UserListDAO actual)
//    {
//        // Use when asserting two users in ViewUser
//        Assert.That(expected.StaffCode, Is.EqualTo(actual.StaffCode));
//        Assert.That(expected.FullName, Is.EqualTo(actual.FullName));
//        Assert.That(expected.UserName, Is.EqualTo(actual.UserName));
//        Assert.That(expected.JoinedDate, Is.EqualTo(actual.JoinedDate));
//        Assert.That(expected.Type, Is.EqualTo(actual.Type));
//    }
//    public static void AssertDetailedUsers(UserListDAO expected, UserListDAO actual)
//    {
//        // Use when asserting two users in ViewUser
//        Assert.That(expected.StaffCode, Is.EqualTo(actual.StaffCode));
//        Assert.That(expected.FullName, Is.EqualTo(actual.FullName));
//        Assert.That(expected.DateOfBirth, Is.EqualTo(actual.DateOfBirth));
//        Assert.That(expected.Gender, Is.EqualTo(actual.Gender));
//        Assert.That(expected.Type, Is.EqualTo(actual.Type));
//        Assert.That(expected.Location, Is.EqualTo(actual.Location));
//    }
//}