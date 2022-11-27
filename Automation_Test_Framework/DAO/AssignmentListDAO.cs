namespace Automation_Test_Framework.DAO;

public class AssignmentListDAO
{
    public string? No { get; set; }
    public string? AssetCode { get; set; }
    public string? AssetName { get; set; }
    public string? Assignedto { get; set; }
    public string? Assignedby { get; set; }
    public string? AssignedDate { get; set; }
    public string? State { get; set; }

    public AssignmentListDAO(string assetCode, string assetName, string assignedTo, string assignedBy,
                               string assignedDate, string state)
    {
        this.AssetCode = assetCode;
        this.AssetName = assetName;
        this.Assignedto = assignedTo;
        this.Assignedby = assignedBy;
        this.AssignedDate = assignedDate;
        this.State = state;
    }

}
