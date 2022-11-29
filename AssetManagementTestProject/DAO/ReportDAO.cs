namespace AssetManagementTestProject.DAO;

public class ReportDAO
{
    public string Category { get; private set; }
    public int Total { get; private set; }
    public int Assigned { get; private set; }
    public int Available { get; private set; }
    public int NotAvailable { get; private set; }
    public int WaitForRecycle { get; private set; }
    public int Recycled { get; private set; }


    /// <summary>
    /// To check View Report list - 7 props
    /// </summary>
    /// <param name="category"></param>
    /// <param name="total"></param>
    /// <param name="assigned"></param>
    /// <param name="available"></param>
    /// <param name="notAvailable"></param>
    /// <param name="waitForRecycle"></param>
    /// <param name="recycled"></param>
    public ReportDAO(string category, int total, int assigned, 
        int available, int notAvailable, int waitForRecycle, int recycled)
    {
        Category = category;
        Total = total;
        Assigned = assigned;
        Available = available;
        NotAvailable = notAvailable;
        WaitForRecycle = waitForRecycle;
        Recycled = recycled;
    }
}
