namespace TheRookiesApp.DAO;

public class AssignmentListDAO
{
    public string? No { get; set; }
    public string? AssetCode { get; set; }
    public string? AssetName { get; set; }
    public string User { get; set; }
    public string? AssignedTo { get; set; }
    public string? AssignedBy { get; set; }
    public string? AssignedDate { get; set; }
    public string? State { get; set; }
    public string Note { get; set; }
    public string Specification { get; set; }

    /// <summary>
    /// To check View Assignment - 6 properties
    /// </summary>
    /// <param name="assetCode"></param>
    /// <param name="assetName"></param>
    /// <param name="assignedTo"></param>
    /// <param name="assignedBy"></param>
    /// <param name="assignedDate"></param>
    /// <param name="state"></param>

    public AssignmentListDAO(string assetCode, string assetName, string assignedTo, string assignedBy,
                               string assignedDate, string state)
    {
        this.AssetCode = assetCode;
        this.AssetName = assetName;
        this.AssignedTo = assignedTo;
        this.AssignedBy = assignedBy;
        this.AssignedDate = assignedDate;
        this.State = state;
    }

    /// <summary>
    /// To check Create + Edit Assignment - 4 properties
    /// </summary>
    /// <param name="user"></param>
    /// <param name="assetName"></param>
    /// <param name="assignedDate"></param>
    /// <param name="note"></param>
    /// 
    public AssignmentListDAO(string user, string assetName,
         string assignedDate, string note)
    {
        this.User = user;
        this.AssetName = assetName;
        this.AssignedDate = assignedDate;
        this.Note = note;
    }

    /// <summary>
    /// To check Detailed Assignment Info - 8 properties
    /// </summary>
    /// <param name="assetCode"></param>
    /// <param name="assetName"></param>
    /// <param name="specification"></param>
    /// <param name="assignedTo"></param>
    /// <param name="assignedBy"></param>
    /// <param name="assignedDate"></param>
    /// <param name="state"></param>
    /// <param name="note"></param>
    public AssignmentListDAO(string assetCode, string assetName,
        string specification, string assignedTo, string assignedBy,
        string assignedDate, string state, string note)
    {
        this.AssetCode = assetCode;
        this.AssetName = assetName;
        this.Specification = specification;
        this.AssignedTo = assignedTo;
        this.AssignedBy = assignedBy;
        this.AssignedDate = assignedDate;
        this.State = state;
        this.Note = note;
    }
}
