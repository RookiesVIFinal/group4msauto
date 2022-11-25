namespace TestProject.DAO;

public class AssignmentDAO
{
    public string assetCode { get; set; }
    public string assetName { get; set; }
    public string user { get; set; }
    public string assignedTo { get; set; }
    public string assignedBy { get; set; }
    public string assignedDate { get; set; }
    public string state { get; set; }
    public string note { get; set; }
    public string specification { get; set; }

    // To check View Assignment - 6 properties
    public AssignmentDAO(string assetCode, string assetName,
        string assignedTo, string assignedBy, string assignedDate, string state)
    {
        this.assetCode = assetCode;
        this.assetName = assetName;
        this.assignedTo = assignedTo;
        this.assignedBy = assignedBy;
        this.assignedDate = assignedDate;
        this.state = state;
    }

    // To check Create + Edit Assignment - 4 properties
    public AssignmentDAO(string user, string assetName,
         string assignedDate, string note)
    {
        this.user = user;
        this.assetName = assetName;
        this.assignedDate = assignedDate;
        this.note = note;
    }
    // To check Detailed Assignment Info - 8 properties
    public AssignmentDAO(string assetCode, string assetName,
        string specification, string assignedTo, string assignedBy, 
        string assignedDate, string state, string note)
    {
        this.assetCode = assetCode;
        this.assetName = assetName;
        this.specification = specification;
        this.assignedTo = assignedTo;
        this.assignedBy = assignedBy;
        this.assignedDate = assignedDate;
        this.state = state;
        this.note = note;
    }
}
