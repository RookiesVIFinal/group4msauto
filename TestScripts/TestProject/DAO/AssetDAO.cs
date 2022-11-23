namespace TestProject.DAO;

public class AssetDAO
{
    public string assetCode { get; set; }
    public string assetName { get; set; }
    public string category { get; set; }
    public string state { get; set; }
    public string specification { get; set; }
    public string installedDate { get; set; }


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
}
