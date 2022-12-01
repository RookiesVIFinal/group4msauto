namespace AssetManagementTestProject.DAO;

public class AssignmentDAO
{
    public string AssetCode { get; private set; }
    public string AssetName { get; private set; }
    public string User { get; private set; }
    public string AssignedTo { get; private set; }
    public string AssignedBy { get; private set; }
    public string AssignedDate { get; private set; }
    public string State { get; private set; }
    public string Note { get; private set; }
    public string Specification { get; private set; }

    /// <summary>
    /// To check View Assignment - 6 properties
    /// </summary>
    /// <param name="assetCode"></param>
    /// <param name="assetName"></param>
    /// <param name="assignedTo"></param>
    /// <param name="assignedBy"></param>
    /// <param name="assignedDate"></param>
    /// <param name="state"></param>
    public AssignmentDAO(string assetCode, string assetName,
        string assignedTo, string assignedBy, string assignedDate, string state)
    {
        AssetCode = assetCode;
        AssetName = assetName;
        AssignedTo = assignedTo;
        AssignedBy = assignedBy;
        AssignedDate = assignedDate;
        State = state;
    }

    /// <summary>
    /// To check Create + Edit Assignment - 4 properties
    /// </summary>
    /// <param name="user"></param>
    /// <param name="assetName"></param>
    /// <param name="assignedDate"></param>
    /// <param name="note"></param>
    public AssignmentDAO(string user, string assetName,
         string assignedDate, string note)
    {
        User = user;
        AssetName = assetName;
        AssignedDate = assignedDate;
        Note = note;
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
    public AssignmentDAO(string assetCode, string assetName,
        string specification, string assignedTo, string assignedBy, 
        string assignedDate, string state, string note)
    {
        AssetCode = assetCode;
        AssetName = assetName;
        Specification = specification;
        AssignedTo = assignedTo;
        AssignedBy = assignedBy;
        AssignedDate = assignedDate;
        State = state;
        Note = note;
    }
}
