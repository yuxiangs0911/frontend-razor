using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webtool
{
    public class RazorTool
    {
        public static void Build(DirectoryInfo projectDirectoryInfo, DirectoryInfo outputDirectoryInfo, string ignoreDirectory)
        {
            ignoreDirectory = "App_Data,bin,Shared,Properties,obj,aspnet_client," + ignoreDirectory;
        }

        private static void BuildImpl(DirectoryInfo projectDirectoryInfo, DirectoryInfo currentDirectoryInfo, DirectoryInfo outputDirectoryInfo, string ignoreDirectory)
        {
            foreach (var file in projectDirectoryInfo.GetFiles())
            {
                if (file.Extension == ".cshtml")
                {

                }
                else
                {
                    string targetPath = Path.Combine(outputDirectoryInfo.FullName, projectDirectoryInfo.FullName.Substring(currentDirectoryInfo.FullName.Length + 1));
                    DirectoryInfo targetDirInfo = DirectoryTool.CreateDirectory(targetPath);
                    File.Copy(file.FullName, targetDirInfo.FullName, true);
                }
            }

            DirectoryInfo[] directories = projectDirectoryInfo.GetDirectories();
            foreach (var dir in directories)
            {
                // ignore folder
                if (ignoreDirectory.Contains(dir.Name))
                {
                    continue;
                }
                BuildImpl(projectDirectoryInfo, dir, outputDirectoryInfo, ignoreDirectory);
            }
        }


    }
}
