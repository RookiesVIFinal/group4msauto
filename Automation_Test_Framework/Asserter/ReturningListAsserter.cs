//using Core_Framework.DriverCore;
//using NUnit.Framework;
//using OpenQA.Selenium;
//using TheRookiesApp.DAO;

//namespace AssetManagementTestProject.Asserter;

//public class ReturningListAsserter : WebDriverBase
//{
//    public ReturningListAsserter(IWebDriver? driver) : base(driver)
//    {
//    }

//    public static void AssertViewAssetLists(IEnumerable<ReturningListDAO> expectedUsers,
//        IEnumerable<ReturningListDAO> actualUsers)
//    {
//        // use when asserting two user list in ViewUser
//        Asserter.AssertListEquals((e, a) => AssertViewReturning(e, a), expectedUsers, actualUsers);
//    }
//    public static void AssertViewReturning(ReturningListDAO expected, ReturningListDAO actual)
//    {
//        // Use when asserting two users in ViewUser
//        Assert.That(expected.AssetCode, Is.EqualTo(actual.AssetCode));
//        Assert.That(expected.AssetName, Is.EqualTo(actual.AssetName));
//        Assert.That(expected.RequestedBy, Is.EqualTo(actual.RequestedBy));
//        Assert.That(expected.AssignedDate, Is.EqualTo(actual.AssignedDate));
//        Assert.That(expected.AcceptedBy, Is.EqualTo(actual.AcceptedBy));
//        Assert.That(expected.ReturnedDate, Is.EqualTo(actual.ReturnedDate));
//        Assert.That(expected.State, Is.EqualTo(actual.State));

//    }
//}