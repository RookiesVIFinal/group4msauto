namespace TheRookiesApp.DAO;

public class ReportListDAO
{
    public string Category { get; set; }
    public int Total { get; set; }
    public int Assigned { get; set; }
    public int Available { get; set; }
    public int NotAvailable { get; set; }
    public int WaitForRecycle { get; set; }
    public int Recycled { get; set; }


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
    public ReportListDAO(string category, int total, int assigned,
        int available, int notAvailable, int waitForRecycle, int recycled)
    {
        this.Category = category;
        this.Total = total;
        this.Assigned = assigned;
        this.Available = available;
        this.NotAvailable = notAvailable;
        this.WaitForRecycle = waitForRecycle;
        this.Recycled = recycled;
    }
}
