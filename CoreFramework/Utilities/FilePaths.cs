using NUnit.Framework;

namespace CoreFramework.Utilities;
public class FilePaths
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
    public static void CreateIfNotExists(string path)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
    }
    public static string GetCurrentDirectoryPath()
    {
        var path = TestContext.CurrentContext.TestDirectory; 
        return path;
    }
}

