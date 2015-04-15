using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace webtool
{
    public class CompressionService
    {
        private static string rjsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Libs\\r.js");
        private static string buildFilePath;

        public static void Compress(DirectoryInfo projectDirectoryInfo, Structure structure)
        {
            DirectoryInfo scriptDirInfo = DirectoryTool.CreateDirectory(Path.Combine(projectDirectoryInfo.FullName, structure.script));
            string scriptPath = Path.Combine(projectDirectoryInfo.FullName, structure.script);
            buildFilePath = Path.Combine(scriptPath, "build.js");
            string cmd = "node {0} -o {1}";
            cmd = string.Format(cmd, rjsPath, buildFilePath);
            ProcessTool.ExecuteCommand(cmd);
        }
    }
}
