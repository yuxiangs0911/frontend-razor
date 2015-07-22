using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TidyManaged;

namespace webtool
{
    public class RazorTool
    {
        private static readonly List<string> ignoreFiles = new List<string> { ".csproj", ".user", ".Debug.config", ".Release.config", "webtool.json" };

        public static void Build(DirectoryInfo projectDirectoryInfo, DirectoryInfo outputDirectoryInfo, string ignoreDirectory, string url, Project project)
        {
            ignoreDirectory = "App_Data,bin,Shared,shared,Properties,obj,aspnet_client," + ignoreDirectory;
            BuildImpl(projectDirectoryInfo, projectDirectoryInfo, outputDirectoryInfo, ignoreDirectory.Split(',').ToList(), url, project);
        }

        private static void BuildImpl(DirectoryInfo projectDirectoryInfo, DirectoryInfo currentDirectoryInfo, DirectoryInfo outputDirectoryInfo, List<string> ignoreDirectories, string url, Project project)
        {
            string targetPath = string.Empty;
            DirectoryInfo targetDirInfo = null;
            string subFolder = string.Empty;
            if (projectDirectoryInfo.FullName == currentDirectoryInfo.FullName)
            {
                targetPath = outputDirectoryInfo.FullName;
                targetDirInfo = outputDirectoryInfo;
            }
            else
            {
                subFolder = currentDirectoryInfo.FullName.Substring(projectDirectoryInfo.FullName.Length + 1);
                targetPath = Path.Combine(outputDirectoryInfo.FullName, subFolder);
                targetDirInfo = DirectoryTool.CreateDirectory(targetPath);
            }

            foreach (var file in currentDirectoryInfo.GetFiles())
            {

                if (ignoreFiles.Any(m => m.EndsWith(file.Extension)))
                {
                    continue;
                }

                if (file.Extension == ".cshtml")
                {
                    if (project.structure.view != "\\")
                    {
                        if (!currentDirectoryInfo.FullName.Contains(project.structure.view))
                        {
                            continue;
                        }
                    }
                    BuildHtml(projectDirectoryInfo.FullName, file, targetPath, url);
                }
                else
                {
                    string targetFilePath = Path.Combine(targetPath, file.Name);
                    File.Copy(file.FullName, targetFilePath, true);
                }
            }

            DirectoryInfo[] directories = currentDirectoryInfo.GetDirectories();
            foreach (var dir in directories)
            {
                // ignore folder
                if (ignoreDirectories.Any(m =>
                {
                    if (m.StartsWith("\\"))
                    {
                        return dir.FullName.Substring(projectDirectoryInfo.FullName.Length) == m;
                    }
                    else
                    {
                        return m == dir.Name;
                    }
                }))
                {
                    continue;
                }
                BuildImpl(projectDirectoryInfo, dir, outputDirectoryInfo, ignoreDirectories, url, project);
            }
        }

        private static void BuildHtml(string projectPath, FileInfo sourceFile, string targetPath, string url)
        {
            string fileUrl = string.Concat(url, "/", sourceFile.FullName.Substring(projectPath.Length + 1));
            string html = HttpTool.GetHtml(fileUrl);
            html = html.Replace(".cshtml", ".html");
            string htmlFilePath = Path.Combine(targetPath, sourceFile.Name.Replace(".cshtml", ".html"));
            File.WriteAllText(htmlFilePath, html, UTF8Encoding.UTF8);
        }
    }
}
