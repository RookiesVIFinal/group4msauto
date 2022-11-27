namespace AssetManagementTestProject.DAO;

public class ReturningDAO
{
    public string AssetCode { get; set; }
    public string AssetName { get; set; }
    public string RequestedBy { get; set; }
    public string AssignedDate { get; set; }
    public string AcceptedBy { get; set; }
    public string ReturnedDate { get; set; }
    public string State { get; set; }


    // To check View Request list - 7 props
    public ReturningDAO(string assetCode, string assetName, string requestedBy, 
        string assignedDate, string acceptedBy, string returnedDate, string state)
    {
        AssetCode = assetCode;
        AssetName = assetName;
        RequestedBy = requestedBy;
        AssignedDate = assignedDate;
        AcceptedBy = acceptedBy;
        ReturnedDate = returnedDate;
        State = state;
    }
}
