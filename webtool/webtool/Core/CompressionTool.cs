using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace webtool
{
    public class CompressionTool
    {
        private static string cssMergedName = "site.min.css";
        private static string cssMergedFullName;
        private static string rjsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Libs\\r.js");

        public static void Compress(DirectoryInfo projectDirectoryInfo, Structure structure)
        {
            DirectoryInfo scriptDirInfo = DirectoryTool.CreateDirectory(Path.Combine(projectDirectoryInfo.FullName, structure.script));
            MergeCss(projectDirectoryInfo.FullName, structure.css, structure.view);

            string cmd = "node {0} -o {1}";
            cmd = string.Format(cmd, rjsPath, Path.Combine(scriptPath, "build.js"));
            ProcessTool.ExecuteCommand(cmd);
        }

        private static void MergeCss(string projectDirectory, string cssDirectory, string htmlDirectory)
        {
            List<FileInfo> cssFiles = new List<FileInfo>();
            string[] cssDirectoies = cssDirectory.Split(',');
            foreach (var d in cssDirectoies)
            {
                var di = new DirectoryInfo(Path.Combine(projectDirectory, d));
                if (di.Exists)
                {
                    cssFiles.AddRange(di.GetFiles());
                }
            }
            cssFiles = cssFiles.Where(m => m.Extension == ".css").ToList();
            if (cssFiles.Count < 2)
            {
                return;
            }
            var firstCssFile = cssFiles[0];
            for (int i = 1; i < cssFiles.Count; i++)
            {
                var cssFile = cssFiles[i];
                string text = File.ReadAllText(cssFile.FullName);
                using (var sw = firstCssFile.AppendText())
                {
                    sw.Write(text);
                }
                cssFile.Delete();
            }
            cssMergedFullName = Path.Combine(firstCssFile.DirectoryName, cssMergedName);
            firstCssFile.MoveTo(cssMergedFullName);
            MergeHtmlCssTag(Directory.CreateDirectory(DirectoryTool.GetDirectory(projectDirectory, htmlDirectory)), cssDirectoies[0], cssMergedName);
        }
        private static void MergeHtmlCssTag(DirectoryInfo htmlDirectoryInfo, string cssDirectoryName, string cssMergedName)
        {
            Regex r = new Regex("<link .* rel=\"stylesheet\" .*/>");
            string siteMinCssTag = string.Format("<link href=\"{0}/{1}\" rel=\"stylesheet\" />", cssDirectoryName, cssMergedName);
            List<FileInfo> htmls = new List<FileInfo>();
            GetHtmls(htmls, htmlDirectoryInfo);
            foreach (var html in htmls)
            {
                string text = File.ReadAllText(html.FullName);
                var m = r.Match(text);
                if (m.Success)
                {
                    text = r.Replace(text, "");
                    text = text.Insert(m.Index, siteMinCssTag);
                    File.WriteAllText(html.FullName, text, Encoding.UTF8);
                }
            }
        }
        private static void GetHtmls(List<FileInfo> files, DirectoryInfo htmlDirectoryInfo)
        {
            files.AddRange(htmlDirectoryInfo.GetFiles().Where(m => m.Extension == ".html"));
            foreach (var d in htmlDirectoryInfo.GetDirectories())
            {
                GetHtmls(files, d);
            }
        }
    }
}
