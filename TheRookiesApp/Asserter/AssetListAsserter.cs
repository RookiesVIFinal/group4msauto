using CoreFramework.DriverCore;
using NUnit.Framework;
using TheRookiesApp.DAO;

// ------------------------------- IN CASE FLUENT ASSERTION FAILS -------------------------------
namespace TheRookiesApp.Asserter;

public class AssetListAsserter : WebDriverBase
{
    public AssetListAsserter() : base()
    {
    }

    public static void AssertViewAssetLists(IEnumerable<AssetListDAO> expectedUsers,
        IEnumerable<AssetListDAO> actualUsers)
    {
        // use when asserting two user list in ViewUser
        Asserter.AssertListEquals((e, a) => AssertViewAsset(e, a), expectedUsers, actualUsers);
    }
    public static void AssertViewAsset(AssetListDAO expected, AssetListDAO actual)
    {
        // Use when asserting two users in ViewUser
        Assert.That(expected.AssetCode, Is.EqualTo(actual.AssetCode));
        Assert.That(expected.AssetName, Is.EqualTo(actual.AssetName));
        Assert.That(expected.Category, Is.EqualTo(actual.Category));
        Assert.That(expected.State, Is.EqualTo(actual.State));
    }
    public static void AssertDetailedAsset(AssetListDAO expected, AssetListDAO actual)
    {
        // Use when asserting two users in ViewUser
        Assert.That(expected.AssetCode, Is.EqualTo(actual.AssetCode));
        Assert.That(expected.AssetName, Is.EqualTo(actual.AssetName));
        Assert.That(expected.Category, Is.EqualTo(actual.Category));
        Assert.That(expected.State, Is.EqualTo(actual.State));
        Assert.That(expected.Specification, Is.EqualTo(actual.Specification));
        Assert.That(expected.InstalledDate, Is.EqualTo(actual.InstalledDate));
    }
}
