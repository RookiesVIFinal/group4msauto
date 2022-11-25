namespace TestProject.DAO;

public class AssetDAO
{
    public string assetCode { get; set; }
    public string assetName { get; set; }
    public string category { get; set; }
    public string state { get; set; }
    public string specification { get; set; }
    public string installedDate { get; set; }

    // To check detailed asset - 6 properties
    public AssetDAO(string assetCode, string assetName, 
        string category, string state, string specification, string installedDate)
    {
        this.assetCode = assetCode;
        this.assetName = assetName;
        this.category = category;
        this.state = state;
        this.specification = specification;
        this.installedDate = installedDate;
    }
    // To check Create + Edit Asset - 5 props
    public AssetDAO(string assetName, string category, string specification, string installedDate, string state)
    {
        this.assetName = assetName;
        this.category = category;
        this.installedDate = installedDate;
        this.state = state;
        this.specification = specification;
    }
    // To check View Asset list - 4 props
    public AssetDAO(string assetCode, string assetName, string category, string state)
    {
        this.assetCode = assetCode;
        this.assetName = assetName;
        this.category = category;
        this.state = state;
    }
}
