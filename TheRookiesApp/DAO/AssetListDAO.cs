namespace TheRookiesApp.DAO;

public class AssetListDAO
{
    public string? AssetCode { get; set; }
    public string? AssetName { get; set; }
    public string? Category { get; set; }
    public string? State { get; set; }
    public string Specification { get; set; }
    public string InstalledDate { get; set; }

    public AssetListDAO(string assetCode, string assetName, string category, string state, 
                        string specification, string installedDate)
    {
        this.AssetCode = assetCode;
        this.AssetName = assetName;
        this.Category = category;
        this.State = state;
        this.Specification = specification;
        this.InstalledDate = installedDate;
    }

    /// <summary>
    /// To check Create + Edit Asset - 5 props
    /// </summary>
    /// <param name="assetName"></param>
    /// <param name="category"></param>
    /// <param name="specification"></param>
    /// <param name="installedDate"></param>
    /// <param name="state"></param>
    /// 
    public AssetListDAO(string assetName, string category, string specification, string installedDate, string state)
    {
        this.AssetName = assetName;
        this.Category = category;
        this.InstalledDate = installedDate;
        this.State = state;
        this.Specification = specification;
    }
    /// <summary>
    /// To check View Asset list - 4 props
    /// </summary>
    /// <param name="assetCode"></param>
    /// <param name="assetName"></param>
    /// <param name="category"></param>
    /// <param name="state"></param>
    /// 
    public AssetListDAO(string assetCode, string assetName, string category, string state)
    {
        this.AssetCode = assetCode;
        this.AssetName = assetName;
        this.Category = category;
        this.State = state;
    }

}
