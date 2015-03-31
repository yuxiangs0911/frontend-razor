using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webtool
{
    public class VersionControlSystemTool
    {
        public static void UpdateSvn(string projectDirectory)
        {
            string command = "svn update " + projectDirectory;
            ProcessTool.ExecuteCommand(command);
        }

        public static void CommitSvn(string projectDirectory, string message)
        {
            string command = string.Format("svn add {0} --force&svn commit {0} -m '{1}'", projectDirectory, message);
            ProcessTool.ExecuteCommand(command);
        }
    }
}
