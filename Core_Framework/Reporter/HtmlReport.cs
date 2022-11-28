﻿using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;
using Core_Framework.API_Core;
using Core_Framework.Reporter.ExtentMarkup;
using NUnit.Framework;

namespace Core_Framework.Reporter;

internal class HtmlReport
{
    private static ExtentReports? _report;
    private static ExtentTest? _extentTestSuite;
    private static ExtentTest? _extentTestCase;

    // ------------------------------- CREATE EXTENTREPORT  -------------------------------

    public static ExtentReports CreateReport()
    {
        if (_report == null)
        {
            _report = CreateInstance();
        }
        return _report;
    }

    private static ExtentReports CreateInstance()
    {
        HtmlReportDirectory.InitReportDirection();
        ExtentHtmlReporter? htmlReporter = new ExtentHtmlReporter(HtmlReportDirectory.REPORT_FILE_PATH);
        htmlReporter.Config.DocumentTitle = "Automation Test Report";
        htmlReporter.Config.ReportName = "Automation Test Report";
        htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
        htmlReporter.Config.Encoding = "UTF-8";

        ExtentReports? report = new();
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

    public static ExtentTest CreateTest(string className, string classDescription = "")
    {
        if (_report == null)
        {
            _report = CreateInstance();
        }
        _extentTestSuite = _report.CreateTest(className, classDescription);
        return _extentTestSuite;
    }

    public static ExtentTest CreateNode(string className, string testcase, string description = "")
    {
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

    public static void Pass(string des)
    {
        GetTest().Pass(MarkupHelper.CreateLabel(des, ExtentColor.Green));
        TestContext.WriteLine(des);
    }

    public static void Pass(string des, string path)
    {
        GetTest().Pass(des).AddScreenCaptureFromPath(path);
        TestContext.WriteLine(des);
    }

    public static void Fail(string des, string path)
    {
        GetTest().Fail(MarkupHelper.CreateLabel(des, ExtentColor.Green)).AddScreenCaptureFromPath(path);
        TestContext.WriteLine(des);
    }

    public static void Fail(string des, string ex, string path)
    {
        GetTest().Fail(des).Fail(ex).AddScreenCaptureFromPath(path);
        TestContext.WriteLine(des);
    }

    public static void Fail(string des)
    {

        GetTest().Fail(des);
        TestContext.WriteLine(des);
    }

    public static void Info(string des)
    {
        GetTest().Info(des);
        TestContext.WriteLine(des);
    }

    public static void Warning(string des)
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
    public static void MarkUpJson(string json)
    {
        GetTest().Info(MarkupHelper.CreateCodeBlock(json, CodeLanguage.Json));
    }

    public static void MarkUpTable(string[][] someInts)
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
    public static void CreateAPIRequestLog(APIRequest request, APIResponse response)
    {
        GetTest().Info(MarkupHelperPlus.CreateAPIRequestLog(request, response));
    }

}