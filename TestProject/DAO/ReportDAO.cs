namespace TestProject.DAO;

public class ReportDAO
{
    public string category { get; set; }
    public int total { get; set; }
    public int assigned { get; set; }
    public int available { get; set; }
    public int notAvailable { get; set; }
    public int waitForRecycle { get; set; }
    public int recycled { get; set; }


    // To check View Report list - 7 props
    public ReportDAO(string category, int total, int assigned, 
        int available, int notAvailable, int waitForRecycle, int recycled)
    {
        this.category = category;
        this.total = total;
        this.assigned = assigned;
        this.available = available;
        this.notAvailable = notAvailable;
        this.waitForRecycle = waitForRecycle;
        this.recycled = recycled;
    }
}
