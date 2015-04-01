using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webtool
{
    public class BuildModel
    {
        public string appDir { get; set; }
        public string baseUrl { get; set; }
        public string dir { get; set; }
        public string mainConfigFile { get; set; }
        public string optimizeCss { get; set; }
        public string fileExclusionRegExp { get; set; }
        public bool removeCombined { get; set; }
        public List<BuildModuleModel> modules { get; set; }
    }

    public class BuildModuleModel
    {
        public string Name { get; set; }
        public List<string> include { get; set; }
    }
}
