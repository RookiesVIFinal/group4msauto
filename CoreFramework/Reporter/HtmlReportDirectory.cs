using CoreFramework.Utilities;

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
        REPORT_FOLDER_PATH = REPORT_ROOT + "\\latest reports";
        REPORT_FILE_PATH = REPORT_FOLDER_PATH + "\\report.html";
        SCREENSHOT_PATH = REPORT_FOLDER_PATH + "\\screenshot";

        ACTUAL_SCREENSHOT_PATH = REPORT_FOLDER_PATH + "\\actual";
        DIFFERENCE_SCREENSHOT_PATH = REPORT_FOLDER_PATH + "\\difference";
        BASELINE_SCREENSHOT_PATH = FilePath.GetCurrentDirectoryPath() + "\\resources\\baseline";

        FilePath.CreateIfNotExists(REPORT_ROOT);
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
            var newPath = REPORT_ROOT + "\\report_" + dirInfo.CreationTime.ToString().Replace(":", ".").Replace("/", "-");
            Directory.Move(reportFolder, newPath);
        }

    }

}
