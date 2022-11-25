namespace TestProject.DAO;

public class RequestForReturnDAO
{
    public string assetCode { get; set; }
    public string assetName { get; set; }
    public string requestedBy { get; set; }
    public string assignedDate { get; set; }
    public string acceptedBy { get; set; }
    public string returnedDate { get; set; }
    public string state { get; set; }


    // To check View Request list - 7 props
    public RequestForReturnDAO(string assetCode, string assetName, string requestedBy, 
        string assignedDate, string acceptedBy, string returnedDate, string state)
    {
        this.assetCode = assetCode;
        this.assetName = assetName;
        this.requestedBy = requestedBy;
        this.assignedDate = assignedDate;
        this.acceptedBy = acceptedBy;
        this.returnedDate = returnedDate;
        this.state = state;
    }
}
