using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webtool
{
    public class DirectoryTool
    {
        public static DirectoryInfo CreateDirectory(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            if (!di.Exists)
            {
                di.Create();
            }
            return di;
        }

        public static void ClearDirectory(DirectoryInfo directory)
        {
            foreach (var d in directory.GetDirectories())
            {
                d.Delete(true);
            }
        }

        public static string GetDirectory(string projectDirectory, string releativePath)
        {
            if (releativePath == "\\" || releativePath == "/" || releativePath == "//")
            {
                return projectDirectory;
            }
            else
            {
                return Path.Combine(projectDirectory, releativePath);
            }
        }
    }
}
