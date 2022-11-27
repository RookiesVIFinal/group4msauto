namespace Automation_Test_Framework.DAO;

public class AssetListDAO
{
    public string? AssetCode { get; set; }
    public string? AssetName { get; set; }
    public string? Category { get; set; }
    public string? State { get; set; }

    public AssetListDAO(string assetCode, string assetName, string category, string state)
    {
        this.AssetCode = assetCode;
        this.AssetName = assetName;
        this.Category = category;
        this.State = state;
    }

}
