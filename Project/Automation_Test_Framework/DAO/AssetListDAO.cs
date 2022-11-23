namespace Automation_Test_Framework.DAO;

public class AssetListDAO
{
    public string? AssetCode { get; set; }
    public string? AssetName { get; set; }
    public string? Category { get; set; }
    public string? State { get; set; }

    public AssetListDAO(string assetcode, string assetname, string category, string state)
    {
        this.AssetCode = assetcode;
        this.AssetName = assetname;
        this.Category = category;
        this.State = state;
    }

    public sealed class RecordRowComparator : Comparer<AssetListDAO>
    {
        public override int Compare(AssetListDAO? x, AssetListDAO? y)
        {
            var compareResult = String.Equals(x?.AssetCode, y?.AssetCode) &&
                String.Equals(x?.AssetName, y?.AssetName) &&
                String.Equals(x?.Category, y?.Category) &&
                String.Equals(x?.State, y?.State);
            if (compareResult)
            {
                return 0;
            }
            return 1;
        }
    }
}
