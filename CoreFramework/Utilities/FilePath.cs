using NUnit.Framework;

namespace CoreFramework.Utilities;

internal class FilePath
{
    public static void CreateFolder(string path)
    {
        Directory.CreateDirectory(path);
    }

    public static void DeleteFolder(string path)
    {
        Directory.Delete(path);
    }

    public static void CreateFile(string path)
    {
        File.Create(path);
    }

    public static void DeleteFile(string path)
    {
        File.Delete(path);
    }

    public static string GetCurrentDirectoryPath()
    {
        // report folder in bin/Debug/net 6.0
        var path = TestContext.CurrentContext.TestDirectory;
        return path;
    }

    public static void CreateIfNotExists(string path)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

    }

}
