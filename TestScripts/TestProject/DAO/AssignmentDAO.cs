namespace TestProject.DAO;

public class AssignmentDAO
{
    public string assetCode { get; set; }
    public string assetName { get; set; }
    public string user { get; set; }
    public string assignedBy { get; set; }
    public string assignedDate { get; set; }
    public string state { get; set; }


    public AssignmentDAO(string assetCode, string assetName,
        string user, string assignedBy, string assignedDate, string state)
    {
        this.assetCode = assetCode;
        this.assetName = assetName;
        this.user = user;
        this.assignedBy = assignedBy;
        this.assignedDate = assignedDate;
        this.state = state;
    }
}
