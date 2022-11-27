//using AssetManagementTestProject.DAO;
//using NUnit.Framework;

//// ------------------------------- IN CASE FLUENT ASSERTION FAILS -------------------------------
//namespace AssetManagementTestProject.Asserter;

//public class AssetListAsserter
//{

//    public static void AssertViewAssetLists(IEnumerable<AssetDAO> expectedUsers, 
//        IEnumerable<AssetDAO> actualUsers)
//    {
//        // use when asserting two user list in ViewUser
//        Asserter.AssertListEquals((e, a) => AssertViewAsset(e, a), expectedUsers, actualUsers);
//    }
//    public static void AssertViewAsset(AssetDAO expected, AssetDAO actual)
//    {
//        // Use when asserting two users in ViewUser
//        Assert.That(expected.assetCode, Is.EqualTo(actual.assetCode));
//        Assert.That(expected.assetName, Is.EqualTo(actual.assetName));
//        Assert.That(expected.category, Is.EqualTo(actual.category));
//        Assert.That(expected.state, Is.EqualTo(actual.state));
//    }
//    public static void AssertDetailedAsset(AssetDAO expected, AssetDAO actual)
//    {
//        // Use when asserting two users in ViewUser
//        Assert.That(expected.assetCode, Is.EqualTo(actual.assetCode));
//        Assert.That(expected.assetName, Is.EqualTo(actual.assetName));
//        Assert.That(expected.category, Is.EqualTo(actual.category));
//        Assert.That(expected.state, Is.EqualTo(actual.state));
//        Assert.That(expected.specification, Is.EqualTo(actual.specification));
//        Assert.That(expected.installedDate, Is.EqualTo(actual.installedDate));
//    }
//}
