using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webtool
{
    public class CompressionTool
    {
        public static void Compress(DirectoryInfo projectDirectoryInfo, Structure structure)
        {
            DirectoryInfo cssDirInfo = DirectoryTool.CreateDirectory(Path.Combine(projectDirectoryInfo.FullName, structure.css));
            DirectoryInfo scriptDirInfo = DirectoryTool.CreateDirectory(Path.Combine(projectDirectoryInfo.FullName, structure.script));

            MergeCss(cssDirInfo);
        }

        private static void MergeCss(DirectoryInfo cssDirInfo)
        {
            var cssFiles = cssDirInfo.GetFiles();
            if (cssFiles.Length < 2)
            {
                return;
            }
            var firstCssFile = cssFiles[0];
            for (int i = 1; i < cssFiles.Length; i++)
            {
                var cssFile = cssFiles[i];
                string text = File.ReadAllText(cssFile.FullName);
                using (var sw = firstCssFile.AppendText())
                {
                    sw.Write(text);
                }

                cssFile.Delete();
            }
        }
    }
}
