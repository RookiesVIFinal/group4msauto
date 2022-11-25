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
}
