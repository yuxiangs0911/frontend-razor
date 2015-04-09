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
            string cmd = "node {0} -o {1}";
            cmd = string.Format(cmd, rjsPath, buildFilePath);
            ProcessTool.ExecuteCommand(cmd);
        }

        public static OptimizationModel Get(string projectDirectory, string scriptName)
        {
            string scriptPath = Path.Combine(projectDirectory, scriptName);
            buildFilePath = Path.Combine(scriptPath, "build.js");
            //string buildJs = File.ReadAllText(buildFilePath).Substring(1);
            //buildJs = buildJs.Substring(0, buildJs.Length - 1);
            //Regex.Replace(buildJs, "", "");
            //OptimizationModel model = JsonConvert.DeserializeObject<OptimizationModel>(buildJs);
            //return model;
            return null;
        }
    }
}
