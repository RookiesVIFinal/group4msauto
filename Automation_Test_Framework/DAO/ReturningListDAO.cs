namespace TheRookiesApp.DAO;

public class ReturningListDAO
{
    public string AssetCode { get; set; }
    public string AssetName { get; set; }
    public string RequestedBy { get; set; }
    public string AssignedDate { get; set; }
    public string AcceptedBy { get; set; }
    public string ReturnedDate { get; set; }
    public string State { get; set; }


    // To check View Request list - 7 props
    public ReturningListDAO(string assetCode, string assetName, string requestedBy,
        string assignedDate, string acceptedBy, string returnedDate, string state)
    {
        this.AssetCode = assetCode;
        this.AssetName = assetName;
        this.RequestedBy = requestedBy;
        this.AssignedDate = assignedDate;
        this.AcceptedBy = acceptedBy;
        this.ReturnedDate = returnedDate;
        this.State = state;
    }
}