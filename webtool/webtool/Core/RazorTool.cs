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

        private static void BuildImpl(DirectoryInfo projectDirectoryInfo, string ignoreDirectory)
        {
            DirectoryInfo[] directories = projectDirectoryInfo.GetDirectories();
            foreach (var dir in directories)
            {
                if (ignoreDirectory.Contains(dir.Name))
                {
                    continue;
                }
                foreach (var file in dir.GetFiles())
                {
                    
                }
                BuildImpl(projectDirectoryInfo, ignoreDirectory);
            }
        }

    }
}
