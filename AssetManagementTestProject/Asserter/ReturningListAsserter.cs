//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using AssetManagementTestProject.DAO;
//using NUnit.Framework;

//namespace AssetManagementTestProject.Asserter;

//public class ReturningListAsserter
//{

//    public static void AssertViewAssetLists(IEnumerable<ReturningDAO> expectedUsers, 
//        IEnumerable<ReturningDAO> actualUsers)
//    {
//        // use when asserting two user list in ViewUser
//        Asserter.AssertListEquals((e, a) => AssertViewReturning(e, a), expectedUsers, actualUsers);
//    }
//    public static void AssertViewReturning(ReturningDAO expected, ReturningDAO actual)
//    {
//        // Use when asserting two users in ViewUser
//        Assert.That(expected.assetCode, Is.EqualTo(actual.assetCode));
//        Assert.That(expected.assetName, Is.EqualTo(actual.assetName));
//        Assert.That(expected.requestedBy, Is.EqualTo(actual.requestedBy));
//        Assert.That(expected.assignedDate, Is.EqualTo(actual.assignedDate));
//        Assert.That(expected.acceptedBy, Is.EqualTo(actual.acceptedBy));
//        Assert.That(expected.returnedDate, Is.EqualTo(actual.returnedDate));
//        Assert.That(expected.state, Is.EqualTo(actual.state));

//    }
//}
