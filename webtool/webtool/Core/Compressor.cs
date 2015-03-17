using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webtool
{
    public class Compressor
    {
        public static void Compress(string projectDirectory, string output)
        {
            // compress css
            CompressCss(projectDirectory, output);
            // compress javascript
            CompressJs(projectDirectory, output);
        }

        public static void CompressCss(string projectDirectory, string output)
        {
            DirectoryInfo cssDirectory = Directory.CreateDirectory(Path.Combine(projectDirectory, "css"));
            if (cssDirectory.Exists)
            {
                FileInfo[] files = cssDirectory.GetFiles();
                FileInfo firstFile = files[0];
                // 把所有css文件合并成一个css文件
                if (files.Length > 1)
                {
                    for (int i = 1; i < files.Length; i++)
                    {
                        using (StreamWriter sw = firstFile.AppendText())
                        {
                            using (StreamReader sr = files[i].OpenText())
                            {
                                sw.Write(sr.ReadToEnd());
                            }
                        }
                    }
                }
                //CompressFile(firstFile.FullName);
            }
        }

        public static void CompressJs(string projectDirectory, string output)
        {
            DirectoryInfo jsDirectory = Directory.CreateDirectory(Path.Combine(projectDirectory, "scripts"));
            if (jsDirectory.Exists)
            {
                CompressJsFile(jsDirectory.FullName);
            }
        }

        private static void CompressJsFile(string directory)
        {
            DirectoryInfo jsDirectory = Directory.CreateDirectory(directory);
            foreach (DirectoryInfo dir in jsDirectory.GetDirectories())
            {
                CompressJsFile(dir.FullName);
            }
            foreach (FileInfo file in jsDirectory.GetFiles())
            {
                //CompressFile(file.FullName);
            }
        }

        public static void CompressFile(string fileFullName, string type)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            baseDirectory = baseDirectory.Substring(0, baseDirectory.LastIndexOf("\\"));
            string command = string.Format("java -jar {0}\\compiler.jar --js {1}\\{2}", baseDirectory, fileFullName);

            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";//要执行的程序名称 
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;//不显示程序窗口 
            p.Start();//启动程序 
            p.StandardInput.WriteLine(command + "&exit");

            string compressJs = p.StandardOutput.ReadToEnd();
            System.IO.File.WriteAllText(fileFullName, compressJs);
        }

        private static void ClearDirectory(string directory)
        {
            DirectoryInfo rootDirectory = CreateFolder(directory);
            foreach (var file in rootDirectory.GetFiles())
            {
                file.Delete();
            }
            foreach (var d in rootDirectory.GetDirectories())
            {
                d.Delete(true);
            }
        }
        private static DirectoryInfo CreateFolder(string folder)
        {
            DirectoryInfo di = new DirectoryInfo(folder);
            if (!di.Exists)
            {
                di.Create();
            }
            return di;
        }
    }
}
