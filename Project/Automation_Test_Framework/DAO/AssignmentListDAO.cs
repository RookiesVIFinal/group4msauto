namespace Automation_Test_Framework.DAO;

public class AssignmentListDAO
{
    public string? No { get; set; }
    public string? AssetCode { get; set; }
    public string? AssetName { get; set; }
    public string? Assignedto { get; set; }
    public string? Assignedby { get; set; }
    public string? AssignedDate { get; set; }
    public string? State { get; set; }

    public AssignmentListDAO(string assetcode, string assetname, string assignedto, string assignedby,
                               string assigneddate, string state)
    {
        this.AssetCode = assetcode;
        this.AssetName = assetname;
        this.Assignedto = assignedto;
        this.Assignedby = assignedby;
        this.AssignedDate = assigneddate;
        this.State = state;
    }

    public sealed class RecordRowComparator : Comparer<AssignmentListDAO>
    {
        public override int Compare(AssignmentListDAO? x, AssignmentListDAO? y)
        {
            var compareResult = String.Equals(x?.AssetCode, y?.AssetCode) &&
                String.Equals(x?.AssetName, y?.AssetName) &&
                String.Equals(x?.Assignedto, y?.Assignedto) &&
                String.Equals(x?.Assignedby, y?.Assignedby) &&
                String.Equals(x?.AssignedDate, y?.AssignedDate) &&
                String.Equals(x?.State, y?.State);
            if (compareResult)
            {
                return 0;
            }
            return 1;
        }
    }
}
