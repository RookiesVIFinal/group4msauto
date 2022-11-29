using CoreFramework.Utilities;
using NUnit.Framework;

namespace CoreFramework.Reporter;

internal class HtmlReportDirectory
{
    public static string? REPORT_ROOT { get; set; }
    public static string? REPORT_FOLDER_PATH { get; set; }
    public static string? REPORT_FILE_PATH { get; set; }
    public static string? SCREENSHOT_PATH { get; set; }
    public static string? ACTUAL_SCREENSHOT_PATH { get; set; }
    public static string? DIFFERENCE_SCREENSHOT_PATH { get; set; }
    public static string? BASELINE_SCREENSHOT_PATH { get; set; }

    public static void InitReportDirection()
    {
        string projectPath = FilePath.GetCurrentDirectoryPath();
        REPORT_ROOT = projectPath + "\\reports";
        REPORT_FOLDER_PATH = REPORT_ROOT + "\\Latest Reports";
        REPORT_FILE_PATH = REPORT_FOLDER_PATH + "\\report.html";
        SCREENSHOT_PATH = REPORT_FOLDER_PATH + "\\Screenshot";
        ACTUAL_SCREENSHOT_PATH = REPORT_FOLDER_PATH + "\\Actual";
        DIFFERENCE_SCREENSHOT_PATH = REPORT_FOLDER_PATH + "\\Difference";
        BASELINE_SCREENSHOT_PATH = FilePath.GetCurrentDirectoryPath() + "\\Resources\\Baseline";

        FilePath.CreateIfNotExists(REPORT_ROOT);
        TestContext.Progress.Write(REPORT_ROOT);
        CheckExistReportAndRename(REPORT_FOLDER_PATH);
        FilePath.CreateIfNotExists(REPORT_FOLDER_PATH);
        FilePath.CreateIfNotExists(SCREENSHOT_PATH);
        FilePath.CreateIfNotExists(ACTUAL_SCREENSHOT_PATH);
        FilePath.CreateIfNotExists(DIFFERENCE_SCREENSHOT_PATH);
        FilePath.CreateIfNotExists(BASELINE_SCREENSHOT_PATH);

    }

    private static void CheckExistReportAndRename(string reportFolder)
    {
        if (Directory.Exists(reportFolder))
        {
            DirectoryInfo dirInfo = new(reportFolder);
            var newPath = REPORT_ROOT + "\\Report_" + dirInfo.CreationTime.ToString().Replace(":", ".").Replace("/", "-");
            TestContext.Progress.Write("new: " + newPath);
            Directory.Move(reportFolder, newPath);
        }

    }

}
