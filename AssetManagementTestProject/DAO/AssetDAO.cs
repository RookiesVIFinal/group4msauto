namespace AssetManagementTestProject.DAO;

public class AssetDAO
{
    public string AssetCode { get; private set; }
    public string AssetName { get; private set; }
    public string Category { get; private set; }
    public string State { get; private set; }
    public string Specification { get; private set; }
    public string InstalledDate { get; private set; }

    /// <summary>
    /// To check detailed asset - 6 properties
    /// </summary>
    /// <param name="assetCode"></param>
    /// <param name="assetName"></param>
    /// <param name="category"></param>
    /// <param name="state"></param>
    /// <param name="specification"></param>
    /// <param name="installedDate"></param>
    public AssetDAO(string assetCode, string assetName, 
        string category, string state, string specification, string installedDate)
    {
        AssetCode = assetCode;
        AssetName = assetName;
        Category = category;
        State = state;
        Specification = specification;
        InstalledDate = installedDate;
    }
    /// <summary>
    /// To check Create + Edit Asset - 5 props
    /// </summary>
    /// <param name="assetName"></param>
    /// <param name="category"></param>
    /// <param name="specification"></param>
    /// <param name="installedDate"></param>
    /// <param name="state"></param>
    public AssetDAO(string assetName, string category, string specification, string installedDate, string state)
    {
        AssetName = assetName;
        Category = category;
        InstalledDate = installedDate;
        State = state;
        Specification = specification;
    }
    /// <summary>
    /// To check View Asset list - 4 props
    /// </summary>
    /// <param name="assetCode"></param>
    /// <param name="assetName"></param>
    /// <param name="category"></param>
    /// <param name="state"></param>
    public AssetDAO(string assetCode, string assetName, string category, string state)
    {
        AssetCode = assetCode;
        AssetName = assetName;
        Category = category;
        State = state;
    }
}
