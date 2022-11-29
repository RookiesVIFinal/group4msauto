namespace AssetManagementTestProject.DAO;

public class ReturningDAO
{
    public string AssetCode { get; private set; }
    public string AssetName { get; private set; }
    public string RequestedBy { get; private set; }
    public string AssignedDate { get; private set; }
    public string AcceptedBy { get; private set; }
    public string ReturnedDate { get; private set; }
    public string State { get; private set; }


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
