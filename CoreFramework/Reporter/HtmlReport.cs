using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;
using CoreFramework.APICore;
using CoreFramework.Reporter.ExtentMarkup;
using NUnit.Framework;


namespace CoreFramework.Reporter;

internal class HtmlReport
{
    //private static int testCaseIndex;
    //private static string testCaseName;
    private static ExtentReports _report;
    private static ExtentTest _extentTestSuite;
    private static ExtentTest _extentTestCase;
    

    // ------------------------------- CREATE EXTENTREPORT  -------------------------------

    public static ExtentReports CreateReport()
    {
        // Check if report is initialized
        // Many methods below do the same thing
        if (_report == null)
        {
            _report = CreateInstance();
        }
        return _report;
    }
    public static ExtentReports CreateInstance()
    {
        // Formatting
        HtmlReportDirectory.InitReportDirection(); // create a report folder
        ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter
            (HtmlReportDirectory.REPORT_FILE_PATH);
        htmlReporter.Config.DocumentTitle = "Automation Test Report";
        htmlReporter.Config.ReportName = "Automation Test Report";
        htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.
            Configuration.Theme.Standard;
        htmlReporter.Config.Encoding = "UTF-8";

        // Create a report obj
        ExtentReports report = new ExtentReports();
        report.AttachReporter(htmlReporter);
        return report;
    }
    
    public static void Flush()
    {
        if (_report != null)
        {
            _report.Flush();
        }
    }
    
    public static ExtentTest CreateTest(string className, string classDescription ="")
    {
        // Tạo 1 suite trong file HTML (cột bên trái)
        if (_report == null)
        {
            _report = CreateInstance();
        }
        _extentTestSuite = _report.CreateTest(className, classDescription);
        return _extentTestSuite; 
    }
    
    public static ExtentTest CreateNode(string className, string testcase, 
        string description = "")
    {
        // Tạo các cases trong suite (cột bên phải)
        if (_extentTestSuite == null)
        {
            _extentTestSuite = CreateTest(className);
        }
        _extentTestCase = _extentTestSuite.CreateNode(testcase, description);
        return _extentTestCase;
    }

    public static ExtentTest GetParent()
    {
        return _extentTestSuite;
    }


    public static ExtentTest GetNode()
    {
        return _extentTestCase;
    }

    public static ExtentTest GetTest()
    {
        if (GetNode() == null)
        {
            return GetParent();
        }
        return GetNode();
    }

    // PASS OR FAIL

    public static void Pass(string des)
    {
        // Pass with no screenshot
        GetTest().Pass(des);
        TestContext.WriteLine(des);
        //MarkupPassLabel(des);
    }

    public static void Pass (string des, string path)
    {
        // Pass with screenshot
        GetTest().Pass(des).AddScreenCaptureFromPath(path);
        TestContext.WriteLine(des);
        //MarkupPassLabel(des);
    }

    public static void Fail(string des)
    {
        // normal fail message
        GetTest().Fail(des);
        TestContext.WriteLine(des);
    }

    public static void Fail(string des, string path)
    {

        // fail message with a screenshot
        GetTest().Fail(des).AddScreenCaptureFromPath(path);
        TestContext.WriteLine(des);
    }

    public static void Fail (string des, string ex, string path)
    {
        // add failed example? and path to screenshot
        GetTest().Fail(des).Fail(ex).AddScreenCaptureFromPath(path);
        TestContext.WriteLine(des);
    }

    // INFO
    public static void Info(string des)
    {
        GetTest().Info(des);
        TestContext.WriteLine(des);
    }
    public static void Info(APIRequest request, APIResponse response)
    {
        GetTest().Info(MarkupHelperPlus.CreateAPIRequestLog(request, response));
        TestContext.Progress.WriteLine();
    }
    public static void Warning (string des)
    {
        GetTest().Warning(des);
        TestContext.WriteLine(des);
    }
    public static void Skip(string des)
    {
        GetTest().Skip(des);
        TestContext.WriteLine(des);
    }

    // ------------------------------- MARKUP  -------------------------------

    //public static void MarkUpHtml()
    //{
    // Inject HTML code to report
    //    var htmlMarkUp = HtmlInjector.CreateHtml();
    //    var m = MarkupHelper.CreateLabel(htmlMarkUp, ExtentColor.Transparent);
    //    /* Similar syntax to Java
    //     * return Log(Status.Info, m);
    //     */
    //    GetTest().Info(m);
    //}
    public static void MarkupPassJson(string json)
    {
      GetTest().Info(MarkupHelper.CreateCodeBlock(json, CodeLanguage.Json));
    }
    public static void MarkupTable(string[][] someInts)
    {
        GetTest().Info(MarkupHelper.CreateTable(someInts));
    }
    // LABELS
    public static void MarkupPassLabel(string text)
    {
        GetTest().Pass(MarkupHelper.CreateLabel(text, ExtentColor.Green));
    }
    public static void MarkupFailLabel(string text)
    {
        GetTest().Fail(MarkupHelper.CreateLabel(text, ExtentColor.Red));
    }
    public static void MarkupWarningLabel(string text)
    {
        GetTest().Warning(MarkupHelper.CreateLabel(text, ExtentColor.Orange));
    }
    public static void MarkupSkipLabel(string text)
    {
        GetTest().Skip(MarkupHelper.CreateLabel(text, ExtentColor.Blue));
    }
    public static void MarkupXML(string code)
    {
        GetTest().Info(MarkupHelper.CreateCodeBlock(code, CodeLanguage.Xml));
    }

    // ------------------------------- API  -------------------------------

    public static void CreateAPIRequestLog_(APIRequest request, APIResponse response)
    {
        GetTest().Info(MarkupHelperPlus.CreateAPIRequestLog(request, response));
    }
    //public static void CreateAPIRequestLogRS(APIRequestRS request, APIResponseRS response)
    //{
    //    GetTest().Info(MarkupHelperPlus.CreateAPIRequestLogRS(request, response));
    //}
}
